using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repositories
{
    public class AttachmentRepository:GenericRepository<Attachment>, IAttachmentRepository
    {
        private readonly StoreDbContext storeDbContext;

        public AttachmentRepository(StoreDbContext storeDbContext):base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
    }
}
