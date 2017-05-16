using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ItemQuery
    {
        public string type;
        public int commodity;
        public ItemQuery (string type, int commodity)
        {
            this.type = type;
            this.commodity = commodity;
        }
    }
}
