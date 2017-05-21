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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool autoP;
        private AMA autoPilot;
        public MarketClient.MarketClient client = new MarketClient.MarketClient();
        public MainWindow()
        {
            autoP = false;
            InitializeComponent();

        }
        public static string legalInput(string input)
        {
            try
            {
                int intInput = Convert.ToInt32(input);
                if (intInput < 0) { return ""; }
                return input;
            }
            catch
            {
                return "";
            }
        }

        private void AutoPilot_Click(object sender, RoutedEventArgs e)
        {     
            autoPilot = new AMA();
            autoPilot.AMA_Activate();
            autoP = true;
        }

        private void BUY_Click(object sender, RoutedEventArgs e)
        {
            if (!(autoP))
            {
                Buy buyWindow = new Buy(this);
                Hide();
                buyWindow.Show();
            }
        }

        private void SELL_Click(object sender, RoutedEventArgs e)
        {
            if (!(autoP))
            {
                Sell sellWindow = new Sell(this);
                Hide();
                sellWindow.Show();
            }
        }

        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            if (!(autoP))
            {
                Cancel cancelWindow = new Cancel(this);
                Hide();
                cancelWindow.Show();

            }
        }

        private void REQUEST_INFO_Click(object sender, RoutedEventArgs e)
        {
            if (!(autoP))
            {
                RequestInfo requestInfo = new RequestInfo(this);
                Hide();
                requestInfo.Show();
            }
        }

        private void USER_STATUS_Click(object sender, RoutedEventArgs e)
        {
            if (!(autoP))
            {
                UserStatus userStatusWindow = new UserStatus(this);
                Hide();
                userStatusWindow.Show();
                userStatusWindow.showDetails();
            }
        }

        private void COMMODITY_STATUS_Click(object sender, RoutedEventArgs e)
        {
            CommodityInfo commodityInfoWindow = new CommodityInfo(this);
            Hide();
            commodityInfoWindow.Show();
        }

        private void ALL_USER_REQUEST_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserRequest[] requests = client.SendQueryUserRequestsRequest();
                MessageBox.Show(string.Join<UserRequest>("\n", requests));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: {0}", ex.Message);
                MessageBox.Show("Backing To The Main Menu...");
            }
        }
        private void ALL_COMMODITIES_INFO_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MarketRequestObject[] obj = client.SendQueryAllMarketRequest();
                MessageBox.Show(string.Join<MarketRequestObject>("\n", obj));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: {0}", ex.Message);
                MessageBox.Show("Backing To The Main Menu...");
            }
        }

        private void EXIT_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks For Using Our Software, GoodBye");
            Application.Current.Shutdown();
        }

        private void ShowHistoryButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!(autoP))
            {
                ShowHistory showHistoryWindow = new ShowHistory(this);
                Hide();
                showHistoryWindow.Show();
            }
        }

        private void STOP_AMA_Click(object sender, RoutedEventArgs e)
        {
            autoPilot.AMA_StopAutoPilot();
            autoP = false;

        }
    }
}
