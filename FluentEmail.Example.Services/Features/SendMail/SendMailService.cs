using FluentEmail.Core;
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

        await email.SendAsync();
    }
}
