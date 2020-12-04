using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kitchen.Api.Models
{
    public class RecipeBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Type { get; set; }
    }

}
