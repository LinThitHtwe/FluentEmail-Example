using FluentEmail.Core;
using FluentEmail.Example.Api.Models;
using System.Threading.Tasks;

namespace FluentEmail.Example.Api.Services;

public class EmailService : IEmailService
{
    private readonly IFluentEmail _fluentEmail;

    public EmailService(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }

    public async Task Send(EmailMetadata emailMetadata)
    {
        await _fluentEmail.To(emailMetadata.ToAddress)
                          .Subject(emailMetadata.Subject)
                          .Body(emailMetadata.Body)
                          .SendAsync();
    }

    public async Task SendUsingTemplate(EmailMetadata emailMetadata, User user, string templateFile)
    {
        await _fluentEmail.To(emailMetadata.ToAddress)
                          .Subject(emailMetadata.Subject)
                          .UsingTemplateFromFile(templateFile,user)
                          .SendAsync();
    }
}
