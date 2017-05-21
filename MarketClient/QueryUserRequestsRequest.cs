using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class QueryUserRequestsRequest
    {
        public string type;
        public QueryUserRequestsRequest()
        {
            this.type = "queryUserRequests";
        }
    }
}
