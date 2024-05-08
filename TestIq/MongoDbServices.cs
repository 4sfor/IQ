using MongoDB.Driver;
using MongoDB.Bson;
using TestIq.Data;

namespace TestIq
{
    public class MongoDbServices
    {
        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<CustomerModel> collection;
        
        
        
        public MongoDbServices()
        {
            try
            {
                client = new MongoClient("mongodb://127.0.0.1:27017");
                database = client.GetDatabase("IQ");
                collection = database.GetCollection<CustomerModel>("Customer");                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        
        public  List<CustomerModel> GetCustomers()
        {
            try
            {
                return collection.Find(FilterDefinition<CustomerModel>.Empty).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public CustomerModel GetCustomer(string studentId)
        {
            try
            {
                return collection.Find(x => x.Id == studentId).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public void SaveUpdate(CustomerModel customer) 
        {
            try
            {
                var customerobj = collection.Find(x => x.Id == customer.Id).FirstOrDefault();
                if (customerobj == null)
                {
                    collection.InsertOne(customer);
                }
                else
                {
                    collection.ReplaceOne(x => x.Id == customer.Id, customer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        

    }
    
}
