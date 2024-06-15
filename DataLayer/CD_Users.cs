using System;
using System.Collections.Generic;
using MongoDB.Driver;
using EntityLayer;
using System.Configuration;

namespace DataLayer
{
    public class CD_Users
    {
        private readonly MongoDbContext _dbContext;

        public CD_Users()
        {
            _dbContext = new MongoDbContext();
        }

        public List<Users> Listar()
        {
            List<Users> list = new List<Users>();

            try
            {
                var collection = _dbContext.GetCollection<Users>("users"); // Asumiendo que la colección en MongoDB se llama "Users"
                list = collection.Find(FilterDefinition<Users>.Empty).ToList();
            }
            catch (Exception ex)
            {
                // Manejar el error de forma apropiada (log, rethrow, etc.)
                Console.WriteLine($"Error al listar usuarios: {ex.Message}");
            }

            return list;
        }
    }
}
