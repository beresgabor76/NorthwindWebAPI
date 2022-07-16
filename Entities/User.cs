using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NwOrdersAPI.Entities
{
    // User
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }

}
