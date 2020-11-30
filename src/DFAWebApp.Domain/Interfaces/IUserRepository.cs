using DFAWebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DFAWebApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> Authenticate(string email, string password);
        string GenerateJWTToken(UserModel user);
        Task<UserModel> Create(UserModel user, string password);
        void Update(UserModel user, string password = null);
        void Delete(int id);
        Task<IEnumerable<UserModel>> GetAllUserAsync();
        Task<UserModel> GetWithUsersByIdAsync(int id);
    }
}
