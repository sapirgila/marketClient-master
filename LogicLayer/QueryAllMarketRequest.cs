using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class QueryAllMarketRequest
    {
        public string type;
        public QueryAllMarketRequest ()
        {
            this.type = "queryAllMarket";
        }
    }
}
