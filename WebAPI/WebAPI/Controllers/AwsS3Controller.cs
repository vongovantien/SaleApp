
using Microsoft.AspNetCore.Mvc;
using WebAPI.IServices;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwsS3Controller : ControllerBase
    {

        private readonly IAws3Services _awsS3Service;
        private readonly IConfiguration _config;
        public AwsS3Controller(IAws3Services awsS3Service, IConfiguration config)
        {
            _awsS3Service = awsS3Service;
            _config = config;
        }

        //[HttpPost("upload")]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    var result = await _awsS3Service.UploadFileAsync(file);
        //    return Ok(new
        //    {
        //        path = result
        //    });
        //}

        [HttpPost(Name = "UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            // Process the file
            await using var memoryStr = new MemoryStream();
            await file.CopyToAsync(memoryStr);

            var fileExt = Path.GetExtension(file.Name);
            var objName = $"{Guid.NewGuid()}.{fileExt}";

            var s3Obj = new S3Object()
            {
                BucketName = "sale-app-image",
                InputStream = memoryStr,
                Name = objName
            };

            var cred = new AwsCredentials()
            {
                AwsKey = _config["AwsConfiguration:AWSAccessKey"],
                AwsSecretKey = _config["AwsConfiguration:AWSSecretKey"]
            };

            var result = await _awsS3Service.UploadFileAsync(s3Obj, cred);

            return Ok(result);
        }

        //[HttpGet("{documentName}")]
        //public IActionResult GetDocumentFromS3(string documentName)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(documentName))
        //            return new ReturnMessage("The 'documentName' parameter is required", (int)HttpStatusCode.BadRequest);

        //        _aws3Services = new Aws3Services(_appConfiguration.AwsAccessKey, _appConfiguration.AwsSecretAccessKey, _appConfiguration.AwsSessionToken, _appConfiguration.Region, _appConfiguration.BucketName);

        //        var document = _aws3Services.DownloadFileAsync(documentName).Result;

        //        return File(document, "application/octet-stream", documentName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ValidateException(ex);
        //    }
        //}

        //[HttpPost]
        //public IActionResult UploadDocumentToS3(IFormFile file)
        //{
        //    try
        //    {
        //        if (file is null || file.Length <= 0)
        //            return ReturnMessage("file is required to upload", (int)HttpStatusCode.BadRequest);

        //        var _aws3Services = new Aws3Services(_appConfiguration.AwsAccessKey, _appConfiguration.AwsSecretAccessKey, _appConfiguration.AwsSessionToken, _appConfiguration.Region, _appConfiguration.BucketName);

        //        var result = _aws3Services.UploadFileAsync(file);

        //        return ReturnMessage(string.Empty, (int)HttpStatusCode.Created);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnMessage(ex.Message, (int)HttpStatusCode.InternalServerError);
        //    }
        //}

        //private IActionResult ReturnMessage(string v, int badRequest)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpDelete("{documentName}")]
        //public IActionResult DeletetDocumentFromS3(string documentName)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(documentName))
        //            return ReturnMessage("The 'documentName' parameter is required", (int)HttpStatusCode.BadRequest);

        //        _aws3Services = new Aws3Services(_appConfiguration.AwsAccessKey, _appConfiguration.AwsSecretAccessKey, _appConfiguration.AwsSessionToken, _appConfiguration.Region, _appConfiguration.BucketName);

        //        _aws3Services.DeleteFileAsync(documentName);

        //        return ReturnMessage(string.Format("The document '{0}' is deleted successfully", documentName));
        //    }
        //    catch (Exception ex)
        //    {
        //        return ValidateException(ex);
        //    }
        //}

        //private async Task DeleteFile(string fileName, string versionId)
        //{
        //    DeleteObjectRequest request = new DeleteObjectRequest
        //    {
        //        BucketName = _bucketName,
        //        Key = fileName
        //    };

        //    if (!string.IsNullOrEmpty(versionId))
        //        request.VersionId = versionId;

        //    await _awsS3Client.DeleteObjectAsync(request);
        //}

        //public bool IsFileExists(string fileName, string versionId)
        //{
        //    try
        //    {
        //        GetObjectMetadataRequest request = new GetObjectMetadataRequest()
        //        {
        //            BucketName = _bucketName,
        //            Key = fileName,
        //            VersionId = !string.IsNullOrEmpty(versionId) ? versionId : null
        //        };

        //        var response = _awsS3Client.GetObjectMetadataAsync(request).Result;

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException is AmazonS3Exception awsEx)
        //        {
        //            if (string.Equals(awsEx.ErrorCode, "NoSuchBucket"))
        //                return false;

        //            else if (string.Equals(awsEx.ErrorCode, "NotFound"))
        //                return false;
        //        }

        //        throw;
        //    }
        //}


    }
}