using System;
using System.Collections.Generic;
using Domain.Contracts;
using System.Text;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Repositories;

namespace Infraestructure.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private ICreditoRepository _CreditoRepository;
        public ICreditoRepository CreditoRepository { get { return _CreditoRepository ?? (_CreditoRepository = new CreditoRepository(_dbContext)); } }


        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }

    }
}
