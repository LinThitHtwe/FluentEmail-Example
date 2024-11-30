namespace FluentEmail.Example.Models;

public record EmailRequestModel
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string[] CC { get; set; }
    public string[] BCC { get; set; }
    public bool IsUseTemplate { get; set; }
    public List<AttachmentModel> Attachments { get; set; }
}

public class AttachmentModel
{
    public string FileName { get; set; }
    public string ContentType { get; set; } 
    public string Base64Content { get; set; }
}