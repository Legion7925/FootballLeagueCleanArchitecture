namespace FootballLeague.Application.DTOs.Email;

public class EmailRequestDto
{
    public required string To { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public required string From { get; set; }
}
