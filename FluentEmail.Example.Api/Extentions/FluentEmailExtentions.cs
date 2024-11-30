using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;
using dotenv.net;
using System;

namespace FluentEmail.Example.Api.Extentions;

public static class FluentEmailExtentions
{
    

    public static void AddFluentEmail(this IServiceCollection services, ConfigurationManager configuration)
    {
        var envVars = DotEnv.Read();       
        var emailSettings = configuration.GetSection("EmailSettings");

        var defaultFromEmail = envVars["DEFAULT_EMAIL"];
        var host = emailSettings["SMTPSetting:Host"];
        var port = emailSettings.GetValue<int>("SMTPSetting:Port");
        var enableSsl = emailSettings.GetValue<bool>("SMTPSetting:EnableSsl");
        var username = envVars["EMAIL"];
        var password = envVars["EMAIL_PASSWORD"];

        services.AddFluentEmail(defaultFromEmail)
        .AddSmtpSender(() => new SmtpClient(host, port)
        {
            EnableSsl = enableSsl, 
            Credentials = new NetworkCredential(username, password)
        })
        .AddRazorRenderer();

        //services.AddFluentEmail(defaultFromEmail)
        //         .AddSmtpSender() 
        //        .//AddSmtpSender(host!, port!, username!, password!, enableSsl!)
        //        .AddRazorRenderer();
    }

}
