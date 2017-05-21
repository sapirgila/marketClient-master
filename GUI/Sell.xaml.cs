using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MarketClient;
using MarketClient.Utils;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Buy.xaml
    /// </summary>
    public partial class Sell : Window
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("mainLogger");
        private static readonly log4net.ILog log2 = log4net.LogManager.GetLogger("LoggerOfHistoryRequests");
        MainWindow Parent;

        public Sell(MainWindow Parent)
        {
            InitializeComponent();
            this.Parent = Parent;
            this.Closed += new EventHandler(On_Closed);
        }
        private void On_Closed(object sender, EventArgs e)
        {
            Hide();
            Parent.Show();
        }

        private void priceTextChanged(object sender, TextCompositionEventArgs e)
        {
            priceTB.Text = MainWindow.legalInput(priceTB.Text);
        }

        private void commodityTextChanged(object sender, TextCompositionEventArgs e)
        {
            commodityTB.Text = MainWindow.legalInput(commodityTB.Text);
        }

        private void amountTextChanged(object sender, TextCompositionEventArgs e)
        {
            amountTB.Text = MainWindow.legalInput(amountTB.Text);
        }

        private void submitButtonClicked(object sender, RoutedEventArgs e)
        {
            if ((priceTB.Text != "") && (amountTB.Text != "") && (commodityTB.Text != ""))
            {
                MarketClient.MarketClient client = new MarketClient.MarketClient();
                int Serveranswer;
                try
                {
                    Serveranswer = client.SendBuyRequest(Convert.ToInt32(priceTB.Text), Convert.ToInt32(commodityTB.Text), Convert.ToInt32(amountTB.Text));
                    log.Info("The Sell Request Has Been Made, The Request Id Is: " + Serveranswer);
                    log.Info("Price: " + priceTB.Text + ", Commodity: " + commodityTB.Text + ", Amount: " + amountTB.Text);
                    log2.Info("sell " + Serveranswer);
                    log2.Info("Price: " + priceTB.Text + ", Commodity: " + commodityTB.Text + ", Amount: " + amountTB.Text);
                    MessageBox.Show("Your Sell Request ID Is: " + Serveranswer);
                }
                catch (MarketException ex)
                {
                    log.Error("Error While Trying To Make A Buy Request: " + ex.Message);
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
