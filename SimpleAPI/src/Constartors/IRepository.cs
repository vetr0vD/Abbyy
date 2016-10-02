using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Constartors
{
    [ContractClass(typeof(RepositoryContractor))]

    public interface IRepository
    {
        User[] GetUsers();

        void SaveUser(User user);
    }
}

