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

namespace HelpDesk2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SDE _sde;

        public MainWindow()
        {
            InitializeComponent();

            _sde = new SDE();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Kill everything.
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _sde.Show();
        }

        private void VenueComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem item = e.AddedItems[0] as ComboBoxItem;
                _sde.VenueName = item.Content as String;
            }
            catch
            {
                // Do nothing.
            }
        }

        //private void SpeakingWithComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        ComboBoxItem item = e.AddedItems[0] as ComboBoxItem;
        //        _sde.SpokeTo = item.Content as String;
        //    }
        //    catch
        //    {
        //        // Do nothing.
        //    }
        //}

        private void SpeakingWithComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox tb = e.OriginalSource as TextBox;
                _sde.SpokeTo = tb.Text as String;
            }
            catch
            {
                // Do nothing.
            }
        }

        private void FakeCall1Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FakeCall2Button_Click(object sender, RoutedEventArgs e)
        {

        }

        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Details> details = new List<Details>();
            details.Add(new Details() {CategoryName = "Cashier", Detail = "Cashier Reprint"});
            details.Add(new Details() {CategoryName = "Cashier", Detail = "Cashier Active in another PC"});
            details.Add(new Details() {CategoryName = "Cashier", Detail = "Cashier Cancel voucher"});
            details.Add(new Details() {CategoryName = "Cashier", Detail = "Cashier Autoprint On"});
            details.Add(new Details() { CategoryName = "Cashier", Detail = "Cashier Shortpay"});

            details.Add(new Details() { CategoryName = "EGM", Detail = "EGM Invalid Meters" });
            details.Add(new Details() { CategoryName = "EGM", Detail = "EGM Autopay Failed" });
            details.Add(new Details() { CategoryName = "EGM", Detail = "EGM RAM Clear" });
            details.Add(new Details() { CategoryName = "EGM", Detail = "EGM Disabled" });
            details.Add(new Details() { CategoryName = "EGM", Detail = "EGM Event Queue Full" });

            details.Add(new Details() { CategoryName = "Loyalty", Detail = "Loyalty CSS Offline" });
            details.Add(new Details() { CategoryName = "Loyalty", Detail = "Loyalty Pager" });
            details.Add(new Details() { CategoryName = "Loyalty", Detail = "Loyalty Barrel Draw" });
            details.Add(new Details() { CategoryName = "Loyalty", Detail = "Loyalty POS" });
            details.Add(new Details() { CategoryName = "Loyalty", Detail = "Loyalty Embosser" });

            details.Add(new Details() { CategoryName = "Maxgaming Loyalty", Detail = "Maxgaming Loyalty Vector" });
            details.Add(new Details() { CategoryName = "Maxgaming Loyalty", Detail = "Maxgaming Loyalty Kiosk" });
            details.Add(new Details() { CategoryName = "Maxgaming Loyalty", Detail = "Maxgaming Loyalty MPC" });
            details.Add(new Details() { CategoryName = "Maxgaming Loyalty", Detail = "Maxgaming Loyalty Software" });
            details.Add(new Details() { CategoryName = "Maxgaming Loyalty", Detail = "Maxgaming Loyalty Barrel Draw" });

            details.Add(new Details() { CategoryName = "Maxn DMS", Detail = "Maxn DMS Additional" });
            details.Add(new Details() { CategoryName = "Maxn DMS", Detail = "Maxn DMS Disposal" });
            details.Add(new Details() { CategoryName = "Maxn DMS", Detail = "Maxn DMS 100 Percent Connectivity" });
            details.Add(new Details() { CategoryName = "Maxn DMS", Detail = "Maxn DMS Static Meter" });
            details.Add(new Details() { CategoryName = "Maxn DMS", Detail = "Maxn DMS Maintenance" });

            details.Add(new Details() { CategoryName = "Maxn SWL", Detail = "Maxn SWL General Audit" });
            details.Add(new Details() { CategoryName = "Maxn SWL", Detail = "Maxn SWL 485 Card" });
            details.Add(new Details() { CategoryName = "Maxn SWL", Detail = "Maxn SWL Replace DCU" });
            details.Add(new Details() { CategoryName = "Maxn SWL", Detail = "Maxn SWL Replace VP" });
            details.Add(new Details() { CategoryName = "Maxn SWL", Detail = "Maxn SWL Plasma Offline" });
            var comboBox = sender as ComboBox;
            string category = comboBox?.SelectedItem as string;
            if (!string.IsNullOrEmpty(category))
            {
                this.CBDetails.ItemsSource = details.Where(s => s.CategoryName == category).Select(s => s.Detail);
                this.CBDetails.SelectedIndex = 0;
            }
        }

        private void ComboBox_Loaded(object sender, EventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Cashier");
            data.Add("EGM");
            data.Add("Loyalty");
            data.Add("Maxgaming Loyalty");
            data.Add("Maxn DMS");
            data.Add("Maxn SWL");
            var comboBox = sender as ComboBox;
            if (comboBox != null) comboBox.ItemsSource = data;
        }

        
    }
}
