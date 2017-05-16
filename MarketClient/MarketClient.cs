using DataLayer;
using MarketClient.DataEntries;
using MarketClient.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    public class MarketClient : IMarketClient
    {
        public int SendBuyRequest(int price, int commodity, int amount)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            Token myToken = new Token();
            string token=myToken.CreatToken();
            BuyRequest request = new BuyRequest(price,amount,"buy",commodity);
            string response = client.SendPostRequest("http://ise172.ise.bgu.ac.il", "user26", token, request);
            try
            {
                int temp = Convert.ToInt32(response);
                return temp;
            }
            catch
            {
                throw new MarketException(response);
            }

        }
     
        public int SendSellRequest(int price, int commodity, int amount)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            Token myToken = new Token();
            string token = myToken.CreatToken();
            SellRequest request = new SellRequest(price, amount, "sell", commodity);
            string response = client.SendPostRequest("http://ise172.ise.bgu.ac.il", "user26", token, request);
            try
            {
                int temp = Convert.ToInt32(response);
                return temp;
            }
            catch
            {
                throw new MarketException(response);
            }
        }
        public bool SendCancelBuySellRequest(int id)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            Token myToken = new Token();
            string token = myToken.CreatToken();
            CancelRequest request = new CancelRequest("cancelBuySell", id);
            string response = client.SendPostRequest("http://ise172.ise.bgu.ac.il", "user26", token, request);
            if (response == "Ok")
                return true;
            else
                return false;
        }
        public MarketUserData SendQueryUserRequest()
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            Token myToken = new Token();
            string token = myToken.CreatToken();
            UserQuery request = new UserQuery("queryUser");
            MarketUserData response = client.SendPostRequest<UserQuery,MarketUserData>("http://ise172.ise.bgu.ac.il", "user26", token, request);
            return response;
        }
        public MarketItemQuery SendQueryBuySellRequest(int id)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            Token myToken = new Token();
            string token = myToken.CreatToken();
            BuySellQuery request = new BuySellQuery("queryBuySell",id);
            MarketItemQuery response = client.SendPostRequest<BuySellQuery, MarketItemQuery>("http://ise172.ise.bgu.ac.il", "user26", token, request);
            return response;
        }
        public MarketCommodityOffer SendQueryMarketRequest(int commodity)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            Token myToken = new Token();
            string token = myToken.CreatToken();
            ItemQuery request = new ItemQuery("queryMarket", commodity);
            MarketCommodityOffer response = client.SendPostRequest<ItemQuery, MarketCommodityOffer>("http://ise172.ise.bgu.ac.il", "user26", token, request);
            return response;
        }
        public UserRequest[] SendQueryUserRequestsRequest()
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            Token myToken = new Token();
            string token = myToken.CreatToken();
            QueryUserRequestsRequest request = new QueryUserRequestsRequest();
            UserRequest[] response = client.SendPostRequest<QueryUserRequestsRequest, UserRequest[]>("http://ise172.ise.bgu.ac.il", "user26", token, request);
            return response;
        }

        public MarketRequestObject[] SendQueryAllMarketRequest()
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            Token myToken = new Token();
            string token = myToken.CreatToken();
            QueryAllMarketRequest request = new QueryAllMarketRequest();
            MarketRequestObject[] response = client.SendPostRequest<QueryAllMarketRequest, MarketRequestObject[]>("http://ise172.ise.bgu.ac.il", "user26", token, request);
            return response;
        }
    }
}
