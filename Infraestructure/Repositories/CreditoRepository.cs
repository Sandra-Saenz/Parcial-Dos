using Domain.Entities;
using Domain.Repositories;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositories
{
    public class CreditoRepository :  GenericRepository<Credito>, ICreditoRepository
    {
        public CreditoRepository(IDbContext context)
             : base(context)
        {

        }
    }
}
