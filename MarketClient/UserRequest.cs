using System;
using MarketClient.DataEntries;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    public class UserRequest
    {
        public MarketItemQuery request;
        public int id;

        public override string ToString()

        {
            string s = "request: " + request + "id: " + id;
            return s;
        }
    }
}
