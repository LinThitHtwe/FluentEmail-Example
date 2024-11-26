using FluentEmail.Example.Api.Models;
using System.Threading.Tasks;

namespace FluentEmail.Example.Api.Services;

public interface IEmailService
{
    Task Send(EmailMetadata emailMetadata);
    Task SendUsingTemplate(EmailMetadata emailMetadata,User user,string templateFile);
}
