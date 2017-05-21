using MarketClient.DataEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    public class MarketUserData : IMarketUserData
    {
        private Dictionary<string, int> commodities;
        //add a function to show the user only the commodites with a int diffrent than 0
        //add a function to show all commodities keys(only the string with no int)
        private double funds;
        private List<int> requests;

        public MarketUserData(Dictionary<string, int> commodities, double funds, List<int> requests)
        {
            this.commodities = commodities;
            this.funds = funds;
            this.requests = requests;

        }
        public List<int> getRequestsList () {
            return requests;
        }
        public List<string> getCommoditiesNames()
        {
            List<string> list = new List<string>(this.commodities.Keys);
            return list;
        }
        public double getFunds() {
            return funds;
        }
        public Dictionary<string, int> getCommodities()
        {
            return this.commodities; 
        }
        public override string ToString()
        {
            string output = "This is the requests lists:\n"; ;
            if (requests.Count() != 0)
            {
                for (int i = 0; i < requests.Count(); i++) { output = output + requests[i] + "\n"; }
            }
            else { output = output + "Your requests list is empty for now" +"\n"; }

            output = output + "This are the commodities list:\n";
            foreach (KeyValuePair<string, int> kvp in commodities)
            {
                output = output + "Key= " + kvp.Key + ", Value = " + kvp.Value + "\n";
            }
            output = output + "This is your remaining funds:" + funds + "\n";
            return output;

            // This is the list of your unresolved requests:
        }
    }
}
