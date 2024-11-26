using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentEmail.Example.Api.Extentions;

public static class FluentEmailExtentions
{
    public static void AddFluentEmail(this IServiceCollection services, ConfigurationManager configuration)
    {
        var emailSettings = configuration.GetSection("EmailSettings");

        var defaultFromEmail = emailSettings["DefaultFromEmail"];
        var host = emailSettings["SMTPSetting:Host"];
        var port = emailSettings.GetValue<int>("Port");

        services.AddFluentEmail(defaultFromEmail)
                .AddSmtpSender(host, port)
                .AddRazorRenderer();
    }
}
