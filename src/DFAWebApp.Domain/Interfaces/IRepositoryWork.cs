using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DFAWebApp.Domain.Interfaces
{
    public interface IRepositoryWork: IDisposable
    {
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
