using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Kitchen.Api.Models
{
    public class Review : RecipeBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string RecipeId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}
