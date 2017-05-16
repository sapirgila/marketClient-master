using System;
using MarketClient.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    public class MarketRequestObject
    {
        public MarketCommodityOffer info;
        public int id;

        public override string ToString()
        {
            string s = "";
            s += "info: [ ask: " + info.getAskedPrice() + ", bid: " + info.getBiddingPrice() + " ], id: " + id;
            return s;
        }
    }
}
