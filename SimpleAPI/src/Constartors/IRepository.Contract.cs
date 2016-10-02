using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Constartors
{
    [ContractClassFor(typeof(IRepository))]
    internal abstract class RepositoryContractor : IRepository
    {
        public User[] GetUsers()
        {
            Contract.Ensures(Contract.Result<User[]>() != null);

            return new User[] { };
        }

        public void SaveUser(User user)
        {
            Contract.Ensures(user != null);
        }
    }
}

