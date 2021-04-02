using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        Task CommitAsync();
    }
}
