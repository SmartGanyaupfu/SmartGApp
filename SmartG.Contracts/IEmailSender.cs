using System;
using SmartG.Shared.DTOs;

namespace SmartG.Contracts
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessageDto message);
        Task SendEmailAsync(EmailMessageDto message);
    }
}

