using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries
{
    public class MarketItemQuery : IMarketItemQuery
    {
        private int price;
        private int amount;
        private string type;
        private string user;
        private int commodity;
        public MarketItemQuery(int price, int amount, string type, string user, int commodity)
        {
            this.price = price;
            this.amount = amount;
            this.type = type;
            this.user = user;
            this.commodity = commodity;
        }
        public override string ToString()
        {
            string output = "The price is:" + price + "\nThe amount is: " + amount + "\nThe type of the request is: " + type + "\nThe user is: " + user + "\nThe commodity id is: " + commodity;
            return output;
        }

    }
}
