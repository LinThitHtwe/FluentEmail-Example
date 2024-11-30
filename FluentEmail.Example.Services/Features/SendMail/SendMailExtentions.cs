using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FluentEmail.Example.Services.Features.SendMail;

public static class SendMailExtentions
{
    public static void AddSendMailExtentions(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<SendMailService>();
    }
}
