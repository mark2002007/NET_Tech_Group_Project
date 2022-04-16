using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_Basics_Project.Data.Models;

namespace WEB_Basics_Project.Data.DataAccess
{
    public class HotlineDataAccess
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "NET_Tech_Group_Project_DB";
        private const string HotlineCollection = "hotlines";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        /// <summary>
        /// Just gets all Hotlines
        /// </summary>
        /// <returns>List of Hotlines</returns>
        public async Task<List<Hotline>> GetAllHotlines()
        {
            var hotlineCollection = ConnectToMongo<Hotline>(HotlineCollection);
            var results = await hotlineCollection.FindAsync(_ => true);
            return results.ToList();
        }

        /// <summary>
        /// Gets all Hotlines where any of fields matches with paramenter Hotline
        /// </summary>
        /// <param name="hotline"></param>
        /// <returns>List of Hotlines</returns>

        public async Task<List<Hotline>> GetHotlinesWithFilter(Hotline hotline)
        {
            var hotlineCollection = ConnectToMongo<Hotline>(HotlineCollection);
            var results = await hotlineCollection.FindAsync(h =>
                h.HotlineID == hotline.HotlineID ||
                h.Name == hotline.Name ||
                h.Number == hotline.Number ||
                h.Area == hotline.Area ||
                h.Operator == hotline.Operator);
            return results.ToList();
        }
        /// <summary>
        /// Creates Hotline
        /// </summary>
        /// <param name="hotline"></param>
        /// <returns>Result of create opperation</returns>
        public Task AddHotline(Hotline hotline)
        {
            var hotlineCollection = ConnectToMongo<Hotline>(HotlineCollection);
            return hotlineCollection.InsertOneAsync(hotline);
        }
    }
}