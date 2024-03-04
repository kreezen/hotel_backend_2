public class Email : Activity
{
    public required string From { get; set; }
    public required string[] To { get; set; }
    public required string[] Cc { get; set; }
    public required string Subject { get; set; }
    public required string Content { get; set; }
}
