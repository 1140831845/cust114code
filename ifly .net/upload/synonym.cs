using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upload
{
    class Synonym
    {
        public Synonym() { }
        public Synonym(string s, string synonym) {
            standard = s;
            synonyms = synonym;
        }
        public BsonObjectId _id { get; set; }
        public string standard { get; set; }
        public string synonyms { get; set; }
    }
}
