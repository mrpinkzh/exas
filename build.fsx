#r @"packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Core
open Fake.Core.Globbing.Operators
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.DotNet.Paket
open Fake.FileHelper
open Fake.IO

Paket.PaketRestoreDefaults

let buildDir = "./build/"
let packDir = "./pack/"
let binDir = "./bin/"

let release = Fake.ReleaseNotesHelper.LoadReleaseNotes "RELEASE_NOTES.md"
let version = release.AssemblyVersion + "." + Fake.BuildServerHelper.buildVersion

let isLocalBuild = Fake.BuildServerHelper.buildServer = Fake.BuildServerHelper.BuildServer.LocalBuild

let productDesc = "see: https://github.com/mrpinkzh/exas"

Target.Create "clean" (fun _ ->
   CleanDir buildDir
   CleanDir packDir
   CleanDir binDir
)

Target.Create "dotnet-restore" (fun _ -> 
    DotNetCli.Restore (fun p -> p)
)

Target.Create "version" (fun _ ->
    AssemblyInfoFile.CreateCSharp "./src/ExAs/Properties/Version.cs"
        [Fake.DotNet.AssemblyInfo.Version version
         Fake.DotNet.AssemblyInfo.FileVersion version
         Fake.DotNet.AssemblyInfo.Description productDesc]
)

Target.Create "compile-src" (fun _ ->
   !! "src/**/*.csproj"
      |> MsBuild.MSBuildWithDefaults ""
      |> Trace.Log "compile-src output: "
)

Target.Create "copy-src" (fun _ -> 
    !! "src/**/*.csproj"
        |> Seq.map (fun projectFile -> Path.getDirectory projectFile )
        |> Seq.map (fun projectDirectory -> 
            Shell.CopyDir buildDir (projectDirectory + "/bin/Release") (fun s -> true)
            projectDirectory
        )
        |> Trace.Log "copied to directories: "
)

Target.Create "compile-test" (fun _ ->
   !! "tests/**/*.csproj"
      |> MsBuild.MSBuildWithDefaults ""
      |> Trace.Log "compile-test output: "
)

Target.Create "test" (fun _ ->
   !! (buildDir + "/*.Tests.dll")
      |> NUnit(fun p ->
         { p with
            ToolPath = "packages/NUnit.Runners/tools"
            OutputFile = buildDir + "/TestResults.xml" } 
         )
)

Target.Create "appveyor-test-publish" (fun _ ->
    AppVeyor.UploadTestResultsXml AppVeyor.TestResultsType.NUnit "./build"
)

Target.Create "pack-nuget" (fun _ ->
    CopyFiles packDir [buildDir + "ExAs.dll"]

    // on a local build the version would contain a "LocalBuild" string which nuget cannot handle
    let nugetVersion = if isLocalBuild
                       then release.AssemblyVersion
                       else version

    NuGet (fun p -> 
            { p with Version = nugetVersion
                     Description = productDesc
                     WorkingDir = packDir
                     AccessKey = getBuildParamOrDefault "nugetkey" ""
                     OutputPath = binDir
                     ReleaseNotes = toLines release.Notes
                     Files = [("ExAs.dll", Some "lib", None)] })
          "ExtendedAssertions.nuspec"
)

Target.Create "publish" (fun _ ->
    match release.Date with
    | Some date -> Paket.Push(fun p ->
                     { p with WorkingDir = binDir })
    | None -> log "no release date, no release"
)

Target.Create "complete" (fun _ ->
    Trace.log "completed build"
)

"clean"
  ==> "dotnet-restore"
  ==> "version"
  ==> "compile-src"
  ==> "copy-src"
  ==> "compile-test"
//  ==> "test"
//  ==> "pack-nuget" 
//  ==> "publish"
  ==> "complete"

//RunTargetOrDefault "pack-nuget"

Target.RunOrDefault "complete"