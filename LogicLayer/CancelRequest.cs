using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CancelRequest
    {
        public String type;
        public int id;

        public CancelRequest(string type, int id)
        {
            this.type = type;
            this.id = id;
        }
    }
}
