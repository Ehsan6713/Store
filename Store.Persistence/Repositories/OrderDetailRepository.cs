﻿using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repositories
{
    public class OrderDetailRepository:GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly StoreDbContext storeDbContext;

        public OrderDetailRepository(StoreDbContext storeDbContext):base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
    }
}