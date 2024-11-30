namespace FluentEmail.Example.Models;

public class AttachmentModel
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string Base64Content { get; set; }
}