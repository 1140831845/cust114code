using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search.resultClass
{
    class allResult
    {
	public List<searchResult> jiebaSearchResult { set; get; }
	public List<searchResult> foolSearchResult { set; get; }
	public string jiebaSeg { set; get; }
	public string foolSeg { set; get; }
	public string jiebaKeywords { set; get; }
	public string foolKeywords { set; get; }
    }

    class saveResult : allResult
    {
        public string question { set; get; }
        public string reason { set; get; }
        public int success { set; get; }
    }
}
