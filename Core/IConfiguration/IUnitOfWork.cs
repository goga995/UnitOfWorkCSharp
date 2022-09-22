using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Core.IRepositories;

namespace UnitOfWork.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users {get;}

        Task CompleteAsynch();
    }
}