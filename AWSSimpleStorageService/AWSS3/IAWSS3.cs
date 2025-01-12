using AWSSimpleStorageService.Structures;
using OutSystems.ExternalLibraries.SDK;

namespace AWSSimpleStorageService;
[OSInterface
(
    Description = "Ações do Amazon Simple Storage Service(S3).",
    IconResourceName = "AWSSimpleStorageService.Resources.S3Icon.png",
    Name = "AWSSimpleStorageService"
)
]
public interface IAWSS3
{
    [OSAction(
        Description = "Ação para gerar uma URL Pré Assinada(PreSignedURL).",
        ReturnDescription = "Retorna a URL Pré Assinada.",
        ReturnName = "PreSignedURL",
        ReturnType = OSDataType.Text
    )]
    public GetPreSignedUrlResponseStr GetPreSignedURL(
                [OSParameter(
                    Description = "Informações para a autenticação",
                    DataType = OSDataType.InferredFromDotNetType)]
                Structures.AuthenticationInfoStr AuthenticationInfo,
                [OSParameter(
                    Description = "Dados para a requisição",
                    DataType = OSDataType.InferredFromDotNetType)]
                Structures.GetPreSignedUrlRequestStr GetPreSignedUrlRequest);
}
