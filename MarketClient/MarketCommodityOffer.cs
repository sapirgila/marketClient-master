using MarketClient.DataEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.Utils
{
    public class MarketCommodityOffer : IMarketCommodityOffer
    {
        private int ask;
        private int bid;
        public MarketCommodityOffer(int ask, int bid)
        {
            this.ask = ask;
            this.bid = bid;
        }
        public override string ToString()
        {
            string output="The best asked Price for this commodity is:"+ask+"\nThe best bid is:" + bid+"\n";
            return output;
        }
        public int getAskedPrice()
        {
            return this.ask;
        }
        public int getBiddingPrice()
        {
            return this.bid;
        }
    }
}
