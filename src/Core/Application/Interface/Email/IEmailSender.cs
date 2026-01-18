
using Core.Application.Model.Request.Email;
using System.Net.Mail;

namespace Core.Application.Interface.Email;

public interface IEmailSender
{
    Task SendAsync(EmailMessageDTO message, CancellationToken ct = default);
}
