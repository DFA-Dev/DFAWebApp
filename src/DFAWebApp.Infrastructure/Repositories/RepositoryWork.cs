using DFAWebApp.Domain.Interfaces;
using DFAWebApp.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DFAWebApp.Infrastructure.Repositories
{
    public class RepositoryWork : IRepositoryWork
    {
        private readonly DFAWebAppDbContext _dbContext;
        private readonly IConfiguration _config;
        private IUserRepository _userRepository;

        public RepositoryWork(DFAWebAppDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_dbContext, _config);

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
