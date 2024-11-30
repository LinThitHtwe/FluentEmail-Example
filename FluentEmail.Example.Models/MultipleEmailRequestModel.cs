namespace FluentEmail.Example.Models;

public record MultipleEmailRequestModel : BaseEmailModel
{
    public string[] ToEmails { get; set; }
}
