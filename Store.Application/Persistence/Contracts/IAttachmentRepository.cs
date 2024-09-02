using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Persistence.Contracts
{
    public interface IAttachmentRepository:IGenericRepository<Domain.Attachment>
    {
    }
}
