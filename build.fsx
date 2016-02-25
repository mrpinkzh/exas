#r @"packages/FAKE/tools/FakeLib.dll"
open Fake

RestorePackages()

let buildDir = "./build/"

Target "clean" (fun _ ->
   CleanDir buildDir
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
         {p with
            ToolPath = "packages/NUnit.Runners/tools" }   
      )
)

Target "default" (fun _ ->
   trace "building exas with fake"
)

"clean"
  ==> "compile-src"
  ==> "compile-test"
  ==> "test"
  ==> "default"

RunTargetOrDefault "default"