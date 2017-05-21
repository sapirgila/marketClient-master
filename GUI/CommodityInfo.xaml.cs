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

namespace GUI
{
    /// <summary>
    /// Interaction logic for CommodityInfo.xaml
    /// </summary>
    public partial class CommodityInfo : Window
    {
        MainWindow Parent;
        public CommodityInfo(MainWindow Parent)
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

        private void Commodity_NumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Commodity_NumberTB.Text = MainWindow.legalInput(Commodity_NumberTB.Text);
        }

        private void SUBMIT_Click(object sender, RoutedEventArgs e)
        {
            if (Commodity_NumberTB.Text != "")
            {
                try
                {
                    MarketClient.MarketClient client = new MarketClient.MarketClient();
                    string theResponse = client.SendQueryMarketRequest(Convert.ToInt32(Commodity_NumberTB.Text)).ToString();
                    MessageBox.Show(theResponse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
