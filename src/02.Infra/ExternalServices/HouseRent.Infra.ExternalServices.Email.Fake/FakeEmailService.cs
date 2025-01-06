using HouseRent.Core.ApplicationServices.Contracts;

namespace HouseRent.Infra.ExternalServices.Email.Fake;

public class FakeEmailService : IEmailService
{
    public Task SendAsync(string email, string subject, string body)
    {
        Console.WriteLine(email);
        Console.WriteLine(email);
        Console.WriteLine(email);
        return Task.CompletedTask;
    }
}
