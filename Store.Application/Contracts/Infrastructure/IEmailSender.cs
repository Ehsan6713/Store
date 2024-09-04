using Store.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        public Task<bool> SendEmail(Email email);
    }
}
