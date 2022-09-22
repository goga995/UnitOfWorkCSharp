using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
       // Task<string> GetFirstNameAndLastName(Guid id);
       
    }
}