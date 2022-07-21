namespace WebAPI.Services
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            BucketName = "";
            Region = "";
            AwsAccessKey = "";
            AwsSecretAccessKey = "";
            AwsSessionToken = "";
        }

        public string BucketName { get; set; }
        public string Region { get; set; }
        public string AwsAccessKey { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string AwsSessionToken { get; set; }
    }
}
