using Microsoft.AspNetCore.Identity.UI.Services;

// Criar a classe mock logo abaixo ou em um novo arquivo
public class AuthMessageSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Não faz nada, apenas pula o envio para não quebrar a aplicação
        return Task.CompletedTask;
    }
}