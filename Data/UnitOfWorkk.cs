using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Core.IConfiguration;
using UnitOfWork.Core.IRepositories;
using UnitOfWork.Core.Repositories;

namespace UnitOfWork.Data
{
    public class UnitOfWorkk : IUnitOfWork, IDisposable
    {
        private readonly AplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public UnitOfWorkk(AplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger); //Wiering betwen user repo and IUserRepo
        }

        public async Task CompleteAsynch()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); // Dispose context from garbage collector when not using it
        }

      
    }
}