using Amazon.S3;
using Amazon;
using AWSSimpleStorageService.Structures;
using OutSystems.ExternalLibraries.SDK;

namespace AWSSimpleStorageService;
public class AWSS3 : IAWSS3
{
    public GetPreSignedUrlResponseStr GetPreSignedURL(
        [OSParameter(
        Description = "Informações para a autenticação", 
        DataType = OSDataType.InferredFromDotNetType)] 
        AuthenticationInfoStr authenticationInfo,

        [OSParameter(Description = "Dados para a requisição", 
        DataType = OSDataType.InferredFromDotNetType)] 
        GetPreSignedUrlRequestStr getPreSignedUrlRequest)
    {

        static HttpVerb MapStringToHttpVerb(string verbString)
        {                
            if (Enum.TryParse(verbString, ignoreCase: true, out HttpVerb httpVerb))
            {
                return httpVerb;
            }
            return HttpVerb.GET;
        }

        static RegionEndpoint MapRegion(string regionName, RegionEndpoint? defaultRegion = null)
        {
            if (string.IsNullOrEmpty(regionName))
                return defaultRegion ?? RegionEndpoint.USEast1;

            try
            {
                return RegionEndpoint.GetBySystemName(regionName);
            }
            catch
            {
                return defaultRegion ?? RegionEndpoint.USEast1;
            }
        }

        static GetPreSignedUrlResponseStr ParsePreSignedUrl(string preSignedUrl)
        {
            try
            {
                Uri uri = new Uri(preSignedUrl);
                return new GetPreSignedUrlResponseStr()
                {
                    Url = preSignedUrl,
                    BaseUrl = $"{uri.Scheme}://{uri.Host}",
                    Key = uri.AbsolutePath.TrimStart('/'),
                    QueryString = uri.Query.TrimStart('?')
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao processar a URL pré-assinada.", ex);
            }
        }

        AWSConfigsS3.UseSignatureVersion4 = true;
        var s3Client = new AmazonS3Client(
            authenticationInfo.AccessKey, 
            authenticationInfo.SecretAccessKey,
            MapRegion(authenticationInfo.Region));
        
        var request = new Amazon.S3.Model.GetPreSignedUrlRequest
        {
            BucketName = getPreSignedUrlRequest.BucketName,
            Key = getPreSignedUrlRequest.Key,
            Expires = getPreSignedUrlRequest.Expires,
            Verb = MapStringToHttpVerb(getPreSignedUrlRequest.Verb),
            ContentType = getPreSignedUrlRequest.ContentType,
        };

        string urlPreAssinada = s3Client.GetPreSignedURL(request);

        return ParsePreSignedUrl(urlPreAssinada);
    }
}