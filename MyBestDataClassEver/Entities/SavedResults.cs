using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestDataClassEver.Entities {
    public class SavedResults {
        [BsonId]
        public string id { get; set; }

        [BsonElement]
        public string BrowserId { get; set; }

        [BsonElement]
        public string Expresion { get; set; }
    }
}
