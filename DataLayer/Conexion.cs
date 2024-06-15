using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Configuration;

namespace DataLayer
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDbConnectionString"];
            var mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase("SoonDB");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
