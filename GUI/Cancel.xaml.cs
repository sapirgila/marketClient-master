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
    /// Interaction logic for Cancel.xaml
    /// </summary>
    public partial class Cancel : Window
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("mainLogger");
        private static readonly log4net.ILog log2 = log4net.LogManager.GetLogger("LoggerOfHistoryRequests");
        MainWindow Parent;
        public Cancel(MainWindow Parent)
        {
            InitializeComponent();
            this.Parent = Parent;
            this.Closed += new EventHandler(On_Closed);
        }
        private void On_Closed(object sender, EventArgs e)
        {
            Parent.Show();
        }

        private void RECEIPT_NUMBER_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reciept_NumberTB.Text = MainWindow.legalInput(Reciept_NumberTB.Text);
        }

        private void SUBMIT_Click(object sender, RoutedEventArgs e)
        {
            if (Reciept_NumberTB.Text != "")
            {
                log.Info("The User Decided To Cancel A Request");
                MarketClient.MarketHistory mH = new MarketClient.MarketHistory();
                MarketClient.MarketClient client = new MarketClient.MarketClient();

                try
                {
                    bool ans = client.SendCancelBuySellRequest(Convert.ToInt32(Reciept_NumberTB.Text));
                    if (ans)
                    {
                        log.Info("The Request Cancelled");
                        MessageBox.Show("Your Cancelling Was Made Successfully");
                        mH.changeFile(Convert.ToInt32(Reciept_NumberTB.Text), true);
                    }
                    else
                    {
                        log.Info("The Cancel Didnt Happen");
                        MessageBox.Show("Your Cancelling Didnt Happen");
                    }
                }
                catch
                {
                    log.Error("Error While Trying To Cancel The Request");
                    MessageBox.Show("Error: something went wrong..");
                }
            }
        }

        private void recieptNumberTextChanged(object sender, TextCompositionEventArgs e)
        {
            Reciept_NumberTB.Text = MainWindow.legalInput(Reciept_NumberTB.Text);
        }
    }
}
