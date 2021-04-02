using LF.Domain.Entities;
using LF.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
    }
}
