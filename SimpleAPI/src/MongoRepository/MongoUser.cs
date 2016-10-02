using Constartors;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepository
{
    [MongoCollection("User")]
    public class MongoUser
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FacebookID { get; set; }

        public MongoUser(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            FacebookID = user.Id;
        }

        public User CreateUser()
        {
            return new User(Email, FacebookID, FirstName, LastName);
        }
    }
}
