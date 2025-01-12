using AWSSimpleStorageService;
using AWSSimpleStorageService.Structures;

// Crie um objeto de autenticação
var authenticationInfo = new AuthenticationInfoStr
{
    AccessKey = "",
    SecretAccessKey = "",
    Region = "us-east-1"
};

// Crie um objeto para a requisição
var request = new GetPreSignedUrlRequestStr
{
    BucketName = "",
    Key = "",
    Expires = DateTime.UtcNow.AddMinutes(10), // Expiração em 10 minutos
    Verb = "DELETE",
    ContentType = "",
};

var awsS3 = new AWSS3();
GetPreSignedUrlResponseStr preSignedURL = awsS3.GetPreSignedURL(authenticationInfo, request);

Console.WriteLine($"URL pré-assinada: {preSignedURL.Url}");
Console.WriteLine($"URL base: {preSignedURL.BaseUrl}");
Console.WriteLine($"Key: {preSignedURL.Key}");
Console.WriteLine($"Query parameters: {preSignedURL.QueryString}");