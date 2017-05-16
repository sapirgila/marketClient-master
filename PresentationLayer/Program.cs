using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.Utils;
using MarketClient;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            Console.WriteLine("Welcome to The Stack Market - your eseyiest way to trade your stacks!");
            Console.WriteLine("This system is using Algo-Trading algorithm design to give you the best tradeing exsperince.");
            Console.WriteLine("So lets get started!");
            while (isRunning)
            {
                Console.WriteLine("You have several options and they are:");
                Console.WriteLine("For submmitimg a buy a request enter '1'");
                Console.WriteLine("For submmitimg a sell a request enter '2'");
                Console.WriteLine("For cancelling a buy/sell request enter '3'");
                Console.WriteLine("For getting an information about your status enter '4'");
                Console.WriteLine("For getting an information about buy/sell request enter '5'");
                Console.WriteLine("For getting the best ask and bid prices of a certain commodity enter '6'");
                Console.WriteLine("For getting All the User Requests enter '7'");
                Console.WriteLine("For getting the Ask and Bid prices of all the commidities enter '8'");
                Console.WriteLine("For Exit enter '9'");
                int answer;
                MarketClient.MarketClient client = new MarketClient.MarketClient();
                int Serveranswer;
                answer = LegalInput.answer();
                if (answer == 1)
                {
                    int price, amount, commodity;
                    Console.WriteLine("You choosed to send a buy request, please enter the price of the commodity:");
                    price = LegalInput.islegalInput(0);
                    Console.WriteLine("Now, please enter the commodity id:");
                    commodity = LegalInput.islegalInput(1);
                    Console.WriteLine("And for last, please enter the amount you want to buy:");
                    amount = LegalInput.islegalInput(0);
                    try
                    {
                        Serveranswer = client.SendBuyRequest(price, commodity, amount);
                        Console.WriteLine("Your Buy Request ID Is: {0}", Serveranswer);
                    }
                    catch (MarketException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        Console.WriteLine("Backing To The Main Menu...");
                    }
                }
                else if (answer == 2)
                {
                    int price, amount, commodity;
                    Console.WriteLine("You choosed to send a sell request, please enter the price of the commodity:");
                    price = LegalInput.islegalInput(0);
                    Console.WriteLine("Now, please enter the commodity id:");
                    commodity = LegalInput.islegalInput(1);
                    Console.WriteLine("And for last, please enter the amount you want to sell:");
                    amount = LegalInput.islegalInput(0);
                    try
                    {
                        Serveranswer = client.SendSellRequest(price, commodity, amount);
                        Console.WriteLine("Your Sell Request ID Is {0}: ", Serveranswer);
                    }
                    catch (MarketException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        Console.WriteLine("Backing To The Main Menu...");
                    }
                }
                else if (answer == 3)
                {
                    int id;
                    Console.WriteLine("You choosed to cancel a buy/sell request, please enter the id of the commodity");
                    id = LegalInput.islegalInput(0);
                    try
                    {
                        bool ans = client.SendCancelBuySellRequest(id);
                        if (ans)
                        {
                            Console.WriteLine("Your Cancelling Was Made Successfully");
                            Console.WriteLine("Backing To The Main Menu...");
                        }
                        else
                        {
                            Console.WriteLine("Your Cancelling Didnt Happen");
                            Console.WriteLine("Backing To The Main Menu...");
                        }
                    }
                    catch {
                        Console.WriteLine("Error: something went wrong..");
                        Console.WriteLine("Backing To The Main Menu...");
                    }
                }
                else if (answer == 4)
                {
                    Console.WriteLine("You choosed to get inforamtion about your playing status");
                    try
                    {
                        string theResponse = (client.SendQueryUserRequest()).ToString();
                        Console.WriteLine(theResponse);
                    }


                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        Console.WriteLine("Backing To The Main Menu...");
                    }
                }
                else if (answer == 5)
                {
                    int id;
                    Console.WriteLine("You choosed to get inforamtion about a specific request, please enter the request id");
                    id = LegalInput.islegalInput(0);
                    try
                    {
                        string theResponse = client.SendQueryBuySellRequest(id).ToString();
                        Console.WriteLine(theResponse);
                    }

                    catch (MarketException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        Console.WriteLine("Backing To The Main Menu...");
                    }
                }
                else if (answer == 6)
                {
                    int commodity;
                    Console.WriteLine("You choosed to get inforamtion about a specific commodity, please enter the commodity id");
                    commodity = LegalInput.islegalInput(1);
                    try
                    {
                        string theResponse = client.SendQueryMarketRequest(commodity).ToString();
                        Console.WriteLine(theResponse);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        Console.WriteLine("Backing To The Main Menu...");
                    }
                }
                else if (answer == 7)
                {
                    try
                    {
                        UserRequest[] requests = client.SendQueryUserRequestsRequest();
                        Console.WriteLine(string.Join<UserRequest>("\n", requests));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        Console.WriteLine("Backing To The Main Menu...");
                    }
                }
                else if (answer==8)
                {
                    try
                    {
                        MarketRequestObject[] obj = client.SendQueryAllMarketRequest();
                        Console.WriteLine(string.Join<MarketRequestObject>("\n", obj));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        Console.WriteLine("Backing To The Main Menu...");
                    }
                }
                else if (answer == 9) { isRunning = false; }
            }
        }
    }
}
