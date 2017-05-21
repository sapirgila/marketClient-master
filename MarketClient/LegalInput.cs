using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    public static class LegalInput
    {
        public static int islegalInput(int commodityFlag)
        {
            int flag = 1;
            int temp = 0;
            string input;
            while (flag == 1)
            {
                input = Console.ReadLine();
                try
                {
                    temp = Convert.ToInt32(input);
                    if ((temp == 0) && (commodityFlag == 1))
                    {
                        flag = 0;
                    }
                    if ((temp <= 0) && (flag == 1))
                    {
                        Console.WriteLine("Please Enter Just A Legal Input Number Value");
                    }
                    else
                    {
                        flag = 0;
                    }
                }
                catch
                {
                    Console.WriteLine("You Entered Illegal Input, Please Enter A Legal One");
                }
            }
            return temp;
        }
        public static int answer()
        {
            int flag = 1;
            int temp = 0;
            string input;
            while (flag == 1)
            {
                input = Console.ReadLine();
                try
                {
                    temp = Convert.ToInt32(input);
                    if ((temp <= 0) || (temp > 10))
                    {
                        Console.WriteLine("Please Enter Numbers Between 1-9");
                    }
                    else
                    {
                        flag = 0;
                    }
                }
                catch
                {
                    Console.WriteLine("You Entered Illegal Input, Please Try Again And Enter Just A Number Between 1-9");
                }
            }
            return temp;
        }
    }
}
