using Constartors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace MongoRepository
{
    public class MongoRepository<T> 
    {
        private readonly IConnectionStringProvider _settings;

        public MongoRepository(
            IConnectionStringProvider settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            _settings = settings;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var coll = GetCollection();
            return coll.Find(predicate).ToEnumerable();
        }

        public void Insert(T document)
        {
            var coll = GetCollection();
            coll.InsertOne(document);
        }

        public void ReplaceOne(Expression<Func<T, bool>> predicate, T document)
        {
            var coll = GetCollection();
            coll.ReplaceOne<T>(predicate, document);
        }

        public void Remove(Expression<Func<T, bool>> predicate)
        {
            var coll = GetCollection();
            coll.DeleteMany(predicate);
        }

        private IMongoCollection<T> GetCollection()
        {
            return MongoHelper.GetCollection<T>(_settings);
        }
    }
}
