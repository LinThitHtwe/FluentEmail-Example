using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Example.Models;

namespace FluentEmail.Example.Services.Features.SendMail;

public class SendMailService
{
    private readonly IFluentEmail _fluentEmail;
    private readonly IFluentEmailFactory _fluentEmailFactory;

    public SendMailService(IFluentEmail fluentEmail, IFluentEmailFactory fluentEmailFactory)
    {
        _fluentEmail = fluentEmail;
        _fluentEmailFactory = fluentEmailFactory;
    }

    public async Task Send(EmailRequestModel emailRequestModel)
    {
        var email = _fluentEmail.To(emailRequestModel.ToEmail)
                             .Subject(emailRequestModel.Subject)
                             .Body(emailRequestModel.Body);

        if (emailRequestModel.CC is not null && emailRequestModel.CC.Length > 0)
        {
            email = email.CC(string.Join(",", emailRequestModel.CC));
        }

        if (emailRequestModel.BCC is not null && emailRequestModel.BCC.Length > 0)
        {
            email = email.BCC(string.Join(",", emailRequestModel.BCC));
        }

        if (emailRequestModel.IsUseTemplate)
        {
            email = email.UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/EmailTemplate.cshtml", emailRequestModel);
        }

        if (emailRequestModel.Attachments is not null && emailRequestModel.Attachments.Count > 0)
        {
            foreach (var attachment in emailRequestModel.Attachments)
            {
                var fileBytes = Convert.FromBase64String(attachment.Base64Content);
                email.Attach(new Attachment
                {
                    Filename = attachment.FileName,
                    Data = new MemoryStream(fileBytes),
                    ContentType = attachment.ContentType
                });
            }
        }

        await email.SendAsync();
    }

    public async Task SendMultipleMails(MultipleEmailRequestModel multipleEmailRequestModel)
    {
        foreach (var toEmail in multipleEmailRequestModel.ToEmails)
        {
            var email = _fluentEmailFactory
                .Create()
                .To(toEmail)
                .Subject(multipleEmailRequestModel.Subject)
                .Body(multipleEmailRequestModel.Body);

            if (multipleEmailRequestModel.CC is not null && multipleEmailRequestModel.CC.Length > 0)
            {
                email = email.CC(string.Join(",", multipleEmailRequestModel.CC));
            }

            if (multipleEmailRequestModel.BCC is not null && multipleEmailRequestModel.BCC.Length > 0)
            {
                email = email.BCC(string.Join(",", multipleEmailRequestModel.BCC));
            }

            if (multipleEmailRequestModel.IsUseTemplate)
            {
                email = email.UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/EmailTemplate.cshtml", multipleEmailRequestModel);
            }

            if (multipleEmailRequestModel.Attachments is not null && multipleEmailRequestModel.Attachments.Count > 0)
            {
                foreach (var attachment in multipleEmailRequestModel.Attachments)
                {
                    var fileBytes = Convert.FromBase64String(attachment.Base64Content);
                    email.Attach(new Attachment
                    {
                        Filename = attachment.FileName,
                        Data = new MemoryStream(fileBytes),
                        ContentType = attachment.ContentType
                    });
                }
            }

            await email.SendAsync();
        }
    }
}
