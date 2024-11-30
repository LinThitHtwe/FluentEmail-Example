using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;
using dotenv.net;
using FluentEmail.Example.Services.Features.Extentions;

namespace FluentEmail.Example.Services.Features.Extentions;

public static class FluentEmailExtentions
{
    public static void AddFluentEmail(this IServiceCollection services)
    {
        var envVars = DotEnv.Read();
        var defaultFromEmail = envVars["DEFAULT_EMAIL"];
        var host = envVars["EMAIL_HOST"];
        var port = Int32.Parse(envVars["EMAIL_PORT"]);
        var username = envVars["EMAIL"];
        var password = envVars["EMAIL_PASSWORD"];

        services.AddFluentEmail(defaultFromEmail)
        .AddSmtpSender(() => new SmtpClient(host, port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(username, password)
        })
        .AddRazorRenderer();
    }
}
