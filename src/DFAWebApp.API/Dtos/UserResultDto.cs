using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFAWebApp.API.Dtos
{
    public class UserResultDto
    {
        public int Id { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
