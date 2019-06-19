using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public Administrator(int id, string username, string password)
        {
            AdministratorId = id;
            Username = username;
            Password = password;
        }

        public Administrator()
        {

        }
    }
}
