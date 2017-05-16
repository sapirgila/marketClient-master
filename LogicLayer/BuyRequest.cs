using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BuyRequest
    {
        public String type;
        public int commodity;
        public int amount;
        public int price;

        public BuyRequest(int price, int amount, string type, int commodity )
        {
            this.type = type;
            this.commodity = commodity;
            this.amount = amount;
            this.price = price;
        }
    }
}
