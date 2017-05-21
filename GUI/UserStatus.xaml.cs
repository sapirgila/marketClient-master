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
    /// Interaction logic for UserStatus.xaml
    /// </summary>
    public partial class UserStatus : Window
    {
        MainWindow Parent;
        public UserStatus(MainWindow Parent)
        {
            InitializeComponent();
            this.Parent = Parent;
            this.Closed += new EventHandler(On_Closed);
        }
        private void On_Closed(object sender, EventArgs e)
        {
            Parent.Show();
        }
        public void showDetails()
        {
            try
            {
                MarketClient.MarketClient client = new MarketClient.MarketClient();
                MarketUserData userData = client.SendQueryUserRequest();
                Dictionary<string, int> commodities = userData.getCommodities();

                  foreach (KeyValuePair<string, int> kvp in commodities)
                  {
                      string str = "Commodity Id: " +kvp.Key+", Amount: "+ kvp.Value;
                      listBox2.Items.Add(str);
                  }
                
                FundsTB.Text = (userData.getFunds().ToString()); 
                List<int> requestsList = userData.getRequestsList();
                if (requestsList.Count()==0)
                {
                    listBox3.Items.Add("The Requests List Is Empty");
                }
                for (int k = 0; k < requestsList.Count(); k++)
                {
                    listBox3.Items.Add("The Requests List Is:");
                    int m = k + 1;
                    string str = "Request (" +m+"): "+requestsList[k];
                    listBox3.Items.Add(str);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
