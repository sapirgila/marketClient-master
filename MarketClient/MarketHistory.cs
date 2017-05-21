using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MarketClient
{
    public class MarketHistory
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("mainLogger");
        private static readonly log4net.ILog log2 = log4net.LogManager.GetLogger("LoggerOfHistoryRequests");
        private static readonly log4net.ILog historyLog = log4net.LogManager.GetLogger("HistoryLog");

        public void changeFile(int id, bool isCancel)
        {
            bool flag = false;
            char typeOfRequest = 'o';
            int whereToStart;
            string[] lines = File.ReadAllLines("C:\\Users\\talgever\\Desktop\\talLog\\historyRequestsLog.txt");
            File.Delete("C:\\Users\\talgever\\Desktop\\talLog\\historyRequestsLog.txt");
            StreamWriter SR = new StreamWriter("C:\\Users\\talgever\\Desktop\\talLog\\historyRequestsLog.txt");
            string detailsOnTheRequest ="";
            string checkingLine="";
            for(int i=0;i<lines.Length && !flag ;i=i+2)
            {
                typeOfRequest = lines[i][0];
                whereToStart = lines[i].IndexOf(' ');
                checkingLine = lines[i].Substring(whereToStart + 1);
                int thisId = Convert.ToInt32(checkingLine);
                if (thisId==id)
                {
                    flag = true;
                    detailsOnTheRequest = lines[i + 1];
                    lines[i] = "";
                    lines[i + 1] = "";
                }
;            }
            for (int i = 0; i < lines.Length; i++)
            {
                if (!(lines[i].Equals("")))
                {
                    SR.WriteLine(lines[i]);
                }
            }
            if (isCancel)
            {
                if (typeOfRequest=='b')
                {
                    historyLog.Info("Buy Request Has Been Cancelled, Id: " + id);
                    historyLog.Info(detailsOnTheRequest);
                    
                }
                else if (typeOfRequest == 's')
                {
                    historyLog.Info("Sell Request Has Been Cancelled, Id: " + id);
                    historyLog.Info(detailsOnTheRequest);
                }
            }
            SR.Dispose();
        }

        public string[] showHistory()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\talgever\\Desktop\\talLog\\historyRequestsLog.txt");
            MarketClient client = new MarketClient();
            MarketUserData user = client.SendQueryUserRequest();
            List<int> requests = user.getRequestsList();
            char typeOfRequest = 'o';
            int whereToStart;
            string detailsOnTheRequest;
            int id;

            for (int i = 0; i < lines.Length; i=i+2)
            {
                typeOfRequest = lines[i][0];
                whereToStart = lines[i].IndexOf(' ');
                id = Convert.ToInt32(lines[i].Substring(whereToStart + 1));
                if (!(requests.Contains(id)))
                {
                    detailsOnTheRequest = lines[i + 1];
                    if (typeOfRequest=='b')
                    {
                        historyLog.Info("Buy Request Has Approved, Id: " + id);
                        historyLog.Info(detailsOnTheRequest);
                    }
                    else if (typeOfRequest == 's')
                    {
                        historyLog.Info("Sell Request Has Approved, Id: " + id);
                        historyLog.Info(detailsOnTheRequest);
                    }
                    changeFile(id, false);
                }
            }

            lines = File.ReadAllLines("C:\\Users\\talgever\\Desktop\\talLog\\historyLog.txt");
            string[] linesToPass = new string[lines.Length];

            for (int i=0;i<lines.Length;i++)
            {
                linesToPass[i]=String.Copy(lines[i]);
                Console.WriteLine(linesToPass[i]);
            }
            return linesToPass;
        }

    }
}
