#r @"packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile

RestorePackages()

let buildDir = "./build/"
let release = ReleaseNotesHelper.LoadReleaseNotes "RELEASE_NOTES.md"
let version = release.AssemblyVersion + "." + BuildServerHelper.buildVersion

Target "clean" (fun _ ->
   CleanDir buildDir
)

Target "version" (fun _ ->
    CreateCSharpAssemblyInfo "./src/ExAs/Properties/Version.cs"
        [Attribute.Version version
         Attribute.FileVersion version]
)

Target "compile-src" (fun _ ->
   !! "src/**/*.csproj"
      |> MSBuildRelease buildDir "Build"
      |> Log "compile-src output: "
)

Target "compile-test" (fun _ ->
   !! "tests/**/*.csproj"
      |> MSBuildRelease buildDir "Build"
      |> Log "compile-test output: "
)

Target "test" (fun _ ->
   !! (buildDir + "/*.Tests.dll")
      |> NUnit(fun p ->
         { p with
            ToolPath = "packages/NUnit.Runners/tools"
            OutputFile = buildDir + "/TestResults.xml" } 
         )
)

Target "appveyor-test-publish" (fun _ ->
    AppVeyor.UploadTestResultsXml AppVeyor.TestResultsType.NUnit "./build"
)

Target "default" (fun _ ->
   trace "building exas with fake"
)

"clean"
  ==> "version"
  ==> "compile-src"
  ==> "compile-test"
  ==> "test"
  ==> "default"

RunTargetOrDefault "default"