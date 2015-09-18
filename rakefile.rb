require 'albacore'

msbuild :build do |b|
    b.properties = { :configuration => :Release }
    b.targets = [ :Build ]
    b.solution = "Exas.sln"
end