#r @"packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Core
open Fake.Core.Globbing.Operators
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.DotNet.Paket
open Fake.DotNet.NuGet
open Fake.FileHelper
open Fake.IO

Paket.PaketRestoreDefaults

let buildDir = "./build-src/"
let testBuildDir = "./build-test/"
let packDir = "./pack/"
let binDir = "./bin/"

let release = Fake.ReleaseNotesHelper.LoadReleaseNotes "RELEASE_NOTES.md"
let version = release.AssemblyVersion + "." + Fake.BuildServerHelper.buildVersion

let isLocalBuild = Fake.BuildServerHelper.buildServer = Fake.BuildServerHelper.BuildServer.LocalBuild

let productDesc = "see: https://github.com/mrpinkzh/exas"

Target.Create "clean" (fun _ ->
   CleanDir buildDir
   CleanDir testBuildDir
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

let copyReleaseBuildArtefactsToFolder = fun targetDir rootSource ->
    !! (rootSource + "/**/*.csproj")
        |> Seq.map (fun projectFile -> Path.getDirectory projectFile )
        |> Seq.map (fun projectDirectory -> 
            Shell.CopyDir targetDir (projectDirectory + "/bin/Release") (fun s -> true)
            projectDirectory
        )
        |> Trace.Log "copied to directories: "

Target.Create "copy-src" (fun _ -> 
    copyReleaseBuildArtefactsToFolder buildDir "src"
)

Target.Create "compile-test" (fun _ ->
   !! "tests/**/*.csproj"
      |> MsBuild.MSBuildWithDefaults ""
      |> Trace.Log "compile-test output: "
)

Target.Create "copy-test" (fun _ ->
    copyReleaseBuildArtefactsToFolder testBuildDir "tests"
)

Target.Create "nunit" (fun _ ->
    !! (testBuildDir + "/net471/**/*.Tests.dll")
        |> Fake.DotNet.Testing.NUnit3.NUnit3 (fun p -> 
            { p with ResultSpecs = [(testBuildDir + "TestResult.xml")] })
)

Target.Create "appveyor-test-publish" (fun _ ->
    AppVeyor.UploadTestResultsXml AppVeyor.TestResultsType.NUnit testBuildDir
)

Target.Create "pack-nuget" (fun _ ->
    CopyDir (packDir + "lib") buildDir (fun _ -> true)

    // on a local build the version would contain a "LocalBuild" string which nuget cannot handle
    let nugetVersion = if isLocalBuild
                       then release.AssemblyVersion
                       else version

    Fake.DotNet.NuGet.NuGet.NuGet (fun p -> 
            { p with Version = nugetVersion
                     Description = productDesc
                     WorkingDir = packDir
                     AccessKey = getBuildParamOrDefault "nugetkey" ""
                     OutputPath = binDir
                     ReleaseNotes = String.toLines release.Notes
                     Files = [(@"lib/**/*", None, Some "lib/**/*.pdb" )] })
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
  ==> "copy-test"
  ==> "nunit"
  ==> "pack-nuget" 
//  ==> "publish"
  ==> "complete"

//RunTargetOrDefault "pack-nuget"

Target.RunOrDefault "complete"