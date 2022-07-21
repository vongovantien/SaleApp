using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using WebAPI.IServices;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class Aws3Services : IAws3Services
    {
        private IAmazonS3 _s3Client;
        public Aws3Services(IAmazonS3 amazonS3)
        {
            _s3Client = amazonS3;
        }

        public async Task<S3ResponseDto> UploadFileAsync(S3Object s3obj, AwsCredentials awsCredentials)
        {
            // Adding AWS credentials
            var credentials = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            // Specify the region
            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var response = new S3ResponseDto();

            try
            {
                // Create the upload request
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = s3obj.InputStream,
                    Key = s3obj.Name,
                    BucketName = s3obj.BucketName,
                };

                // Created an S3 client
                using var client = new AmazonS3Client(credentials, config);

                // upload utility to s3
                var transferUtiltiy = new TransferUtility(client);

                // We are actually uploading the file to S3
                await transferUtiltiy.UploadAsync(uploadRequest);

                response.StatusCode = 200;
                response.Message = $"{s3obj.Name} has been uploaded successfully";
            }
            catch (AmazonS3Exception ex)
            {
                response.StatusCode = (int)ex.StatusCode;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;
        }

        public Task<byte[]> DownloadFileAsync(string file)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            //await using var memoryStr = new MemoryStream();
            //await file.CopyToAsync(memoryStr);

            //var fileExt = Path.GetExtension(file.Name);
            //var objName = $"{Guid.NewGuid()}.{fileExt}";

            //var s3Obj = new S3Object()
            //{
            //    BucketName = "sale-app-image",
            //    InputStream = memoryStr,
            //    Name = objName
            //};

            //var cred = new AwsCredentials()
            //{
            //    AwsKey = _config["AwsConfiguration:AWSAccessKey"],
            //    AwsSecretKey = _config["AwsConfiguration:AWSSecretKey"]
            //};

            //var result = await    _storageService.UploadFileAsync(s3Obj, cred);

            return "ac";
        }
    }
}
