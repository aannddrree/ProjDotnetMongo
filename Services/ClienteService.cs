using System.Collections.Generic;
using MongoDB.Driver;
using ProjDotnetMongo.Models;
using ProjDotnetMongo.Utils;

namespace ProjDotnetMongo.Services
{
    public class ClienteService
    {
        private readonly IMongoCollection<Cliente> _clientes;

        public ClienteService(IProjMongoDotnetDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clientes = database.GetCollection<Cliente>(settings.ClienteCollectionName);
        }

        public List<Cliente> Get() =>
            _clientes.Find(cliente => true).ToList();

        public Cliente Get(string id) =>
            _clientes.Find<Cliente>(cliente => cliente.Id == id).FirstOrDefault();

        public Cliente Create(Cliente cliente)
        {
            _clientes.InsertOne(cliente);
            return cliente;
        }

        public void Update(string id, Cliente clienteIn) =>
            _clientes.ReplaceOne(cliente => cliente.Id == id, clienteIn);

        public void Remove(Cliente clienteIn) =>
            _clientes.DeleteOne(cliente => cliente.Id == clienteIn.Id);

        public void Remove(string id) => 
            _clientes.DeleteOne(cliente => cliente.Id == id);   
    }
}