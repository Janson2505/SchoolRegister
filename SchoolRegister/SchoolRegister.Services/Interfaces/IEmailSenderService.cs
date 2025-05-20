using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Services.Interfaces
{
    interface IEmailSenderService
    {
        Task SendEmailAsync(string to, string from, string subject, string message);
    }
}
