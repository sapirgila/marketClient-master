using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BuySellQuery
    {
        public string type;
        public int id;
        public BuySellQuery (string type, int id)
        {
            this.type = type;
            this.id= id;
        }
    }
}
