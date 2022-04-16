using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_Basics_Project.Data.Models;

namespace WEB_Basics_Project.Data.DataAccess
{
    public class VolunteerDataAccess
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "NET_Tech_Group_Project_DB";
        private const string VolunteerCollection = "volunteers";
        
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        /// <summary>
        /// Just gets all Volunteers
        /// </summary>
        /// <returns>List of Volunteers</returns>
        public async Task<List<Volunteer>> GetAllVolunteers()
        {
            var volunteerCollection = ConnectToMongo<Volunteer>(VolunteerCollection);
            var results = await volunteerCollection.FindAsync(_ => true);
            return results.ToList();
        }

        /// <summary>
        /// Gets all Volunteers where any of fields matches with paramenter Volunteer
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>List of Volunteers</returns>
        
        public async Task<List<Volunteer>> GetVolunteersWithFilter (Volunteer volunteer)
        {
            var volunteerCollection = ConnectToMongo<Volunteer>(VolunteerCollection);
            var results = await volunteerCollection.FindAsync(v => 
                v.VolunteerID == volunteer.VolunteerID || 
                v.FirstName == volunteer.FirstName || 
                v.LastName == volunteer.LastName ||
                v.Age == volunteer.Age);
       
            return results.ToList();
        }
        /// <summary>
        /// Creates Volunteer
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>Result of create opperation</returns>
        public Task AddVolunteer(Volunteer volunteer)
        {
            var volunteerCollection = ConnectToMongo<Volunteer>(VolunteerCollection);
            return volunteerCollection.InsertOneAsync(volunteer);
        }
    }
}