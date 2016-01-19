require 'albacore'
require 'albacore/tasks/versionizer'

nugets_restore :restore do |p|
    p.out = 'packages'
    p.exe = '.nuget/nuget.exe'
end

build :build do |b|
    b.sln = "Exas.sln"
    b.prop 'outdir', '../../build/bin'
    b.prop 'Configuration', 'Release'
    b.logging = 'detailed'
    b.target = [ 'Clean', 'Rebuild' ]
end

test_runner :tests do |tests|
    tests.files = FileList['build/bin/*.Tests.dll']
    tests.exe = 'packages\NUnit.Runners.2.6.4\tools\nunit-console.exe'
end

task :default => [ :restore, :build, :tests ]