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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ShowHistory.xaml
    /// </summary>
    public partial class ShowHistory : Window
    {
        MainWindow Parent;
        public ShowHistory(MainWindow Parent)
        {
            InitializeComponent();
            this.Parent = Parent;
            this.Closed += new EventHandler(On_Closed);
            this.showDetails();
        }
        private void On_Closed(object sender, EventArgs e)
        {
            Parent.Show();
        }
        public void showDetails()
        {
            listBox.Items.Add("The History Market-Algo Info:");
            MarketClient.MarketHistory showH = new MarketClient.MarketHistory();
            string[] linesToPrint = showH.showHistory();
            for (int i = 0; i < linesToPrint.Length; i++) {
                listBox.Items.Add(linesToPrint[i]);
            }
        }
    }
}
