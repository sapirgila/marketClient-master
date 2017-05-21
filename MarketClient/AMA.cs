using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using MarketClient;
using MarketClient.Utils;

 namespace MarketClient
{
    
    public class AMA
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("mainLogger");
        private static readonly log4net.ILog log2 = log4net.LogManager.GetLogger("LoggerOfHistoryRequests");
        Timer myTimer;
        //arrays for keeping track on movements in the market
        int[,] marketScanForBuying;
        int[,] marketScanForSelling;
        //names of the commodities on the market
        List<string> commoditiesNames;
        //for selling/buying
        MarketClient client;

        //arrays hold in cell number :     0               1                                                 2            3         4
        //in buying marketScan         nameOfCommoditie   index Of The Latest Price Change In Our Faver   price 1   > price 2  > price 3 --> BUY!
        //in selling marketScan        nameOfCommoditie   index Of The Latest Price Change In Our Faver   price 1   < price 2  < price 3 --> SELL!
        public AMA()
        {
            myTimer = new Timer(20000);
            client = new MarketClient();
            MarketUserData myData= client.SendQueryUserRequest();
            commoditiesNames = myData.getCommoditiesNames();
            marketScanForBuying = new int[commoditiesNames.Count, 5];
            marketScanForSelling = new int[commoditiesNames.Count, 5];
            //Initialize an array with initial values
            int i = 0;
            foreach (string k in commoditiesNames)
            {
                //cell 0 holds name of commities
                marketScanForBuying[i, 0] = int.Parse(k);
                marketScanForSelling[i, 0] = int.Parse(k);
                i++;
            }
        }
        public void AMA_Activate()
        {
            MarketCommodityOffer offerOnTheMarket;
            for (int i = 0;i<marketScanForBuying.Length;i++)
            {
                offerOnTheMarket = client.SendQueryMarketRequest(marketScanForBuying[i,0]);
                //setting index in cell 1
                marketScanForBuying[i, 1] = 2;
                marketScanForSelling[i, 1] = 2;
                //setting first asked price on the market in cell 2
                marketScanForBuying[i, 2] = offerOnTheMarket.getAskedPrice();
                marketScanForSelling[i,2]= offerOnTheMarket.getAskedPrice();
            }
            myTimer.Elapsed += new ElapsedEventHandler(marketScanner);
            myTimer.AutoReset = true;
            myTimer.Enabled = true;
     
        }
        void marketScanner(object sender, EventArgs e)
        {
            MarketCommodityOffer offerOnTheMarket;
            int currentPriceOnTheMarket = 0;
            int index;
            int latestMarketAcquisitionReceipt, latestMarketSellingReceipt;
            //Auto-pilot in charge of buying if a commoditie show a decline in price
            for (int i = 0; i < marketScanForBuying.GetLength(0); i++)
            {
                offerOnTheMarket = client.SendQueryMarketRequest(marketScanForBuying[i,0]);
                currentPriceOnTheMarket = offerOnTheMarket.getAskedPrice();
                index = marketScanForBuying[i, 1];
                if (index <= 3)
                {
                    if (marketScanForBuying[i, index] > currentPriceOnTheMarket)
                    {
                        index++;
                        marketScanForBuying[i, 1] = index;
                        marketScanForBuying[i, index] = currentPriceOnTheMarket;
                       
                    }
                }
                if (index == 4)
                {
                    if(marketScanForBuying[i, index] > currentPriceOnTheMarket)
                    {
                        marketScanForBuying[i, 1] = 2;
                        latestMarketAcquisitionReceipt = client.SendBuyRequest(offerOnTheMarket.getBiddingPrice() + 1, marketScanForBuying[i, 0], 3);
                        //somthing to put on log
                        offerOnTheMarket = client.SendQueryMarketRequest(marketScanForBuying[i, 0]);
                        marketScanForBuying[i, 2] = offerOnTheMarket.getBiddingPrice();
                    }
                }
            }
            //Auto-pilot in charge of selling if a commoditie show a rise in asked price
            for (int i = 0; i < marketScanForSelling.GetLength(0); i++)
            {
                offerOnTheMarket = client.SendQueryMarketRequest(marketScanForSelling[i, 0]);
                currentPriceOnTheMarket = offerOnTheMarket.getAskedPrice();
                index = marketScanForSelling[i, 1];
                if (index <= 3)
                {
                    if (marketScanForSelling[i, index] < currentPriceOnTheMarket)
                    {
                        index++;
                        marketScanForSelling[i, 1] = index;
                        marketScanForSelling[i, index] = currentPriceOnTheMarket;

                    }
                }
                if (index == 4)
                {
                    if (marketScanForBuying[i, index] < currentPriceOnTheMarket)
                    {
                        marketScanForBuying[i, 1] = 2;
                        latestMarketSellingReceipt = client.SendSellRequest(currentPriceOnTheMarket, marketScanForSelling[i, 0], 3);
                        //somthing to put on log
                        offerOnTheMarket = client.SendQueryMarketRequest(marketScanForSelling[i, 0]);
                        marketScanForBuying[i, 2] = offerOnTheMarket.getBiddingPrice();
                    }
                }
            }
        }

        public void AMA_StopAutoPilot()
        {
            myTimer.Stop();
        } 
    } 
}
