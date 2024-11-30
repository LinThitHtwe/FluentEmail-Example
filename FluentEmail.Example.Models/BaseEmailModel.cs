namespace FluentEmail.Example.Models;

public record BaseEmailModel
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public string[] CC { get; set; }
    public string[] BCC { get; set; }
    public bool IsUseTemplate { get; set; }
    public List<AttachmentModel> Attachments { get; set; }
}
