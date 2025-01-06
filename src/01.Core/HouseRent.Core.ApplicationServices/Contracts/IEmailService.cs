namespace HouseRent.Core.ApplicationServices.Contracts;
public interface IEmailService
{
    Task SendAsync(string email, string subject, string body);
}
