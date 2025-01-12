using OutSystems.ExternalLibraries.SDK;

namespace AWSSimpleStorageService.Structures;

[OSStructure(Description = "Estrutura de requisição para geração de URL pré-assinada.")]
public struct GetPreSignedUrlRequestStr
{
    [OSStructureField(Description = "Nome do bucket(BucketName)",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BucketName;

    [OSStructureField(Description = "A chave para do objeto para o qual a URL pré-assinada(Key)",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;

    [OSStructureField(Description = "O MIME type que descreve o formato dos dados do objeto(ContentType)",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ContentType;

    [OSStructureField(Description = "A data e hora de expiração da URL pré-assinada(Expires)",
        DataType = OSDataType.DateTime,
        IsMandatory = false)]
    public DateTime Expires;

    [OSStructureField(Description = "O verbo para a URL pré-assinada: GET, PUT, DELETE e HEAD. Valor padrão(default) é GET(Verb)",
        DataType = OSDataType.Text,
        IsMandatory = false,
        DefaultValue = "GET")]
    public string Verb;
}