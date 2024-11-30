namespace FluentEmail.Example.Models;

public class EmailRequestModel
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string[] CC { get; set; }
    public string[] BCC { get; set; }

}
