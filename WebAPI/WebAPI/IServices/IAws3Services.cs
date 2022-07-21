using WebAPI.ViewModel;

namespace WebAPI.IServices
{
    public interface IAws3Services
    {
        Task<S3ResponseDto> UploadFileAsync(S3Object s3obj, AwsCredentials awsCredentials);
        Task<byte[]> DownloadFileAsync(string file);

        Task<string> UploadFileAsync(IFormFile formFile);
    }
}
