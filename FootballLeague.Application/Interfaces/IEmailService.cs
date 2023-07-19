using FootballLeague.Application.DTOs.Email;

namespace FootballLeague.Application.Interfaces;

public interface IEmailService
{
    Task SendAsync(EmailRequestDto request);
}
