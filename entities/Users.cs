using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
    }
}