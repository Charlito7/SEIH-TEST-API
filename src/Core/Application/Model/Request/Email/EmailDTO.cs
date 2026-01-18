
namespace Core.Application.Model.Request.Email;

public sealed class EmailMessageDTO
{
    public required string To { get; init; }
    public string? ToName { get; init; }
    public required string Subject { get; init; }
    public required string HtmlBody { get; init; }
    public string? TextBody { get; init; }

    // Optionnel
    public List<EmailAttachmentDTO> Attachments { get; init; } = new();
}

public sealed class EmailAttachmentDTO
{
    public required string FileName { get; init; }
    public required byte[] Content { get; init; }
    public string ContentType { get; init; } = "application/octet-stream";
}