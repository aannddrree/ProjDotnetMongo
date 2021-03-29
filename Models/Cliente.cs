using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjDotnetMongo.Models
{
    public class Cliente
    {
        #region Propriedades

            [BsonId]    
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            public string Nome { get; set; }
            public ContaExterna ContaExterna { get; set; }

        #endregion
    }
}