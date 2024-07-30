using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace minimalAPIMongo.Domains
{
    public class Order
    {
        [BsonId]
        [BsonIgnoreIfDefault]

        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
       
        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("status")]
        public string? Status {  get; set; }


        [BsonElement("clientId")]
        public string? ClientId { get; set; }

        [BsonElement("products")]
        public List<string> Products { get; set; }


        public Dictionary<string, string> AdditionalAtributes { get; set; }


        public Order()
        {
            Products = new List<string>();
        }
    }
}
