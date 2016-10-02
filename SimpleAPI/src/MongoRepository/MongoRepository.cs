using Constartors;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace MongoRepository
{
    public class MongoRep : IRepository
    {
        IConnectionStringProvider _connectionSting = null;
        MongoRepository<MongoUser> _usersRepository = null;

        public MongoRep(IConnectionStringProvider connectionSting)
        {
            _connectionSting = connectionSting;
            _usersRepository = new MongoRepository<MongoUser>(connectionSting);
        }

        public User[] GetUsers()
        {
            return _usersRepository.
                Find((it) => true).
                GroupBy(it => it.Email).
                Select(it => it.Last().CreateUser()).
                ToArray();
        }

        public void SaveUser(User user)
        {
            _usersRepository.Insert(new MongoUser(user));
        }
    }
}
