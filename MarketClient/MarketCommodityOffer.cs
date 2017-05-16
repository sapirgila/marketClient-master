using MarketClient.DataEntries;
using DataLayer;
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
        private int price;
        public MarketCommodityOffer(int ask, int price)
        {
            this.ask = ask;
            this.price = price;
        }
        public override string ToString()
        {
            string output="The best asked Price for this commodity is:"+ask+"\nThe best bid is:" + price+"\n";
            return output;
        }
        public int getAskedPrice()
        {
            return this.ask;
        }
        public int getBiddingPrice()
        {
            return this.price;
        }
    }
}
