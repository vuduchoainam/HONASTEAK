using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HONASTEAK.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}