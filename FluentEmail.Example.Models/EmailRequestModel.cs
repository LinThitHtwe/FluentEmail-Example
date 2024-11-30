namespace FluentEmail.Example.Models;

public record EmailRequestModel : BaseEmailModel
{
    public string ToEmail { get; set; }
   
}

