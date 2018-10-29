using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upload
{
    class Stopword
    {
        public Stopword() { }
        public Stopword(string word, int w)
        {
            stopword = word;
            weight = w;
        }
        public BsonObjectId _id { get; set; }
        public string stopword { get; set; }
	public int weight { get; set; }
    }
}
