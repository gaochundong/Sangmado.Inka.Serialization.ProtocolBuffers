Commands
------------
nuget setApiKey xxx-xxx-xxxx-xxxx

nuget pack ..\Sangmado.Inka.Serialization.ProtocolBuffers\Sangmado.Inka.Serialization.ProtocolBuffers.csproj -IncludeReferencedProjects -Symbols -Build -Prop Configuration=Release -OutputDirectory ".\packages"

nuget push .\packages\Sangmado.Inka.Serialization.ProtocolBuffers.1.0.0.0.nupkg

