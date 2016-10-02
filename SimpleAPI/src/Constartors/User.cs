using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Constartors
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }

        public User(
            string email,
            string id,
            string firstName,
            string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Id = id;
        }
    }
}
