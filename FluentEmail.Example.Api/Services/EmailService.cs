using FluentEmail.Core;
using FluentEmail.Example.Api.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FluentEmail.Example.Api.Services;

public class EmailService : IEmailService
{
    private readonly IFluentEmail _fluentEmail;
    private readonly IFluentEmailFactory _fluentEmailFactory;

    public EmailService(IFluentEmail fluentEmail, IFluentEmailFactory fluentEmailFactory)
    {
        _fluentEmail = fluentEmail;
        _fluentEmailFactory = fluentEmailFactory;
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
                          .UsingTemplateFromFile(templateFile, user)
                          .SendAsync();
    }

    public async Task SendWithAttachment(EmailMetadata emailMetadata)
    {
        await _fluentEmail.To(emailMetadata.ToAddress)
                          .Subject(emailMetadata.Subject)
                          .AttachFromFilename(emailMetadata.AttachmentPath,
                          attachmentName: Path.GetFileName(emailMetadata.AttachmentPath))
                          .Body(emailMetadata.Body)
                          .SendAsync();
    }

    public async Task SendMultiple(List<EmailMetadata> emailMetadatas)
    {
        foreach (var emailMetadata in emailMetadatas)
        {
            await _fluentEmailFactory
                  .Create()
                  .To(emailMetadata.ToAddress)
                  .Subject(emailMetadata?.Subject)
                  .Body(emailMetadata?.Body)
                  .SendAsync();
        }
    }

}
