using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WEB_Basics_Project.Data.MongoDB.Models
{
    public class Hotline
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int HotlineID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Area { get; set; }
        public string Operator { get; set; }
    }
}