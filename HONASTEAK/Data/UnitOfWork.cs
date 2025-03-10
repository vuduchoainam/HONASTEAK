﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HONASTEAK.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private DbContextTransaction _transaction;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
            }
        }
        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
        }
        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext?.Dispose();
        }
    }
}