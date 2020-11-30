using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DFAWebApp.Domain.Models
{
    public class UserModel: EntityModel
    {
        public UserModel()
        {
            UserRole = "User";
        }

        public string UserEmail { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string UserRole { get; set; }
    }
}
