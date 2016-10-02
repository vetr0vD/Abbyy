using Constartors;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MongoRepository
{
    public static class MongoHelper
    {
        /// <summary>
        /// Возвращает имя для коллекции типа T
        /// </summary>
        public static string GetCollectionName<T>()
        {
            var mongoCollectionAttr =
                (MongoCollectionAttribute)typeof(T).GetTypeInfo().
                GetCustomAttributes(typeof(MongoCollectionAttribute), true).
                SingleOrDefault();

            if (mongoCollectionAttr != null)
            {
                return mongoCollectionAttr.Name;
            }

            return typeof(T).Name;
        }

        public static IMongoCollection<T> GetCollection<T>(IConnectionStringProvider settings)
        {
            var builder = new MongoUrlBuilder(settings.ConnectionString);

            var mongoClient = new MongoClient(builder.ToMongoUrl());
            var db = mongoClient.GetDatabase(builder.DatabaseName);

            var collectionName = GetCollectionName<T>();

            return db.GetCollection<T>(collectionName);
        }
    }
}
