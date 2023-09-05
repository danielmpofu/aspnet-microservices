using Ordering.APPLICATION.Models;

namespace Ordering.APPLICATION.Contacts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
    
}