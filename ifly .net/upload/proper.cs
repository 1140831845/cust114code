using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upload
{
    class Proper
    {
        public Proper() { }
        public Proper(string proper, int w)
        {
            properNouns = proper;
            weight = w;
        }
        public BsonObjectId _id { get; set; }
        public string properNouns { get; set; }
        public int weight { get; set; }
    }
}
