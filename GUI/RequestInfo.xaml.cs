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
using MarketClient.Utils;

namespace GUI
{
    /// <summary>
    /// Interaction logic for RequestInfo.xaml
    /// </summary>
    public partial class RequestInfo : Window
    {
        MainWindow Parent;
        public RequestInfo(MainWindow Parent)
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

        private void REQUEST_NUMBER_TextChanged(object sender, TextChangedEventArgs e)
        {
            Request_NumberTB.Text = MainWindow.legalInput(Request_NumberTB.Text);
        }

        private void SUBMIT_Click(object sender, RoutedEventArgs e)
        {
            if (Request_NumberTB.Text != "")
            {
                MarketClient.MarketClient client = new MarketClient.MarketClient();
                try
                {
                    string theResponse = client.SendQueryBuySellRequest(Convert.ToInt32(Request_NumberTB.Text)).ToString();
                    MessageBox.Show(theResponse);
                }

                catch (MarketException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
