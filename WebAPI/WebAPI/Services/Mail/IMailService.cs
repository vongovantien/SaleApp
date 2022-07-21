namespace WebAPI.Services.Mail
{
    public interface IMailService
    {
        void SendEmail(Message message);
    }
}
