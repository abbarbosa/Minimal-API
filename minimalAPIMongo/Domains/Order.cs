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

        [BsonElement("clientId")]
        public string? ClientId { get; set; }
        
        [BsonElement("productId")]
        public string? ProductId { get; set; }

        [BsonElement("date")]
        public string? Date { get; set; }

        [BsonElement("status")]
        public string? Status {  get; set; }

        public Dictionary<string, string> AdditionalAtributes { get; set; }


        public Order()
        {
            AdditionalAtributes = new Dictionary<string, string>();
        }
    }
}
