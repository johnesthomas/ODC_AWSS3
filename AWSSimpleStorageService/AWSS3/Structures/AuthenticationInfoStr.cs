using OutSystems.ExternalLibraries.SDK;

namespace AWSSimpleStorageService.Structures;

[OSStructure(
    Description = "Estrutura dos dados de autenticação.")]
public struct AuthenticationInfoStr
{
    [OSStructureField(
        Description = "Access Key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string AccessKey;

    [OSStructureField(
        Description = "Secret Access Key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string SecretAccessKey;

    [OSStructureField(
        Description = "Region",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Region;
}