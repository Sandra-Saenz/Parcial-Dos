using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infraestructure.Base;

namespace Infraestructure
{
    public class CreditoContext : DbContextBase
    {
        public CreditoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Credito> Creditos { get; set; }
    }
}
