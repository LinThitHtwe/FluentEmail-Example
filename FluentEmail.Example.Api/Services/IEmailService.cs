using FluentEmail.Example.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentEmail.Example.Api.Services;

public interface IEmailService
{
    Task Send(EmailMetadata emailMetadata);

    Task SendUsingTemplate(EmailMetadata emailMetadata,User user,string templateFile);
    
    //Task SendWithAttachment(EmailMetadata emailMetadata,User user, string attachmentFile);
    
    Task SendWithAttachment(EmailMetadata emailMetadata);
    
    Task SendMultiple(List<EmailMetadata> emailMetadatas);
}
