using OutSystems.ExternalLibraries.SDK;

namespace AWSSimpleStorageService.Structures;

[OSStructure(Description = "Estrutura de resposta da geração de URL pré-assinada.")]
public struct GetPreSignedUrlResponseStr
{
    [OSStructureField(Description = "Url pré-assinada completa",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Url;

    [OSStructureField(Description = "Url base",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BaseUrl;

    [OSStructureField(Description = "A chave do objeto que foi informado para gerar a URL pré-assinada",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;

    [OSStructureField(Description = "Query parameters retornado da URL pré-assinada, contendo " +
        "X-Amz-Expires, X-Amz-Algorithm, X-Amz-Credential, X-Amz-Date, X-Amz-SignedHeaders, X-Amz-Signature",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string QueryString;
}