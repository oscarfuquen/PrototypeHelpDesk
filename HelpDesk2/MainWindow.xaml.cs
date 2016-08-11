using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.String;

namespace HelpDesk2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SDE _sde;
        private static List<Details> CategoryDetails
        {
            get
            {
                List<Details> details = new List<Details>();
                details.Add(new Details() { CategoryName = "Cashier", Detail = "Cashier Reprint" });
                details.Add(new Details() { CategoryName = "Cashier", Detail = "Cashier Active in another PC" });
                details.Add(new Details() { CategoryName = "Cashier", Detail = "Cashier Cancel voucher" });
                details.Add(new Details() { CategoryName = "Cashier", Detail = "Cashier Autoprint On" });
                details.Add(new Details() { CategoryName = "Cashier", Detail = "Cashier Shortpay" });

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
                return details;
            }
        }

        private string speakTo { get;set; }

        public MainWindow()
        {
            InitializeComponent();

            _sde = new SDE();
            this.Closing += MainWindow_Closing;

            SetCallImage(false, false);
            _phoneNoText.FontWeight = FontWeights.Normal;

            bool visibleButtons = false;
            bool.TryParse(ConfigurationManager.AppSettings["VisibleButtons"].ToString(), out visibleButtons);
            if (!visibleButtons)
            {
                this.fake1.Opacity = 0;
                this.fake2.Opacity = 0;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Kill everything.
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Set Venue name.
            try
            {
                ComboBoxItem item = _venueCombo.SelectedItem as ComboBoxItem;
                _sde.VenueName = item.Content as String;
            }
            catch
            {
                // Do nothing.
            }

            // Set speaking with
            try
            {
                ComboBoxItem item = _speakingWithCombo.SelectedItem as ComboBoxItem;
                _sde.SpokeTo = item.Content as String;
            }
            catch
            {
                // Do nothing.
            }

            if (!IsNullOrEmpty(speakTo))
            {
                _sde.SpokeTo = speakTo;
            }

            _sde.Show();
            _sde.Activate();
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

        private void SpeakingWithComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox tb = e.OriginalSource as TextBox;
                speakTo = tb.Text as String;
            }
            catch
            {
                // Do nothing.
            }
        }

        private void SetCallImage(bool isCallInProgress, bool makeSound = true)
        {
            var currentDirectory = Environment.CurrentDirectory;
            if (isCallInProgress)
            {
                SetSound(Path.Combine(Environment.CurrentDirectory, @"icons\telephone-ring-01a.wav"), 3000);
                BitmapImage image = new BitmapImage(new Uri("/HelpDesk2;component/icons/phone_green.png", UriKind.Relative));
                _callImage.Source = image;
            }
            else
            {
                if(makeSound)
                SetSound(Path.Combine(Environment.CurrentDirectory, @"icons\phone-hang-up-1.wav"), 1000);
                BitmapImage image = new BitmapImage(new Uri("/HelpDesk2;component/icons/phone_red.gif", UriKind.Relative));
                _callImage.Source = image;
            }
        }

        private static void SetSound(string sound, int delay = 0)
        {
            var ring = new SoundPlayer(sound);
            ring.Play();
            Thread.Sleep(delay);
            ring.Stop();
        }

        private void FakeCallHangUpButton_Click(object sender, RoutedEventArgs e)
        {
            SetCallImage(false);
            _phoneNoText.FontWeight = FontWeights.Normal;
        }

        private void FakeCall1Button_Click(object sender, RoutedEventArgs e)
        {
            SetCallImage(true);
            _venueIdText.Text = "234";
            _venueCombo.SelectedIndex = 1;
            _speakingWithCombo.SelectedItem = null;
            _phoneNoText.Text = "+61 7 3317 7777";
            _phoneNoText.FontWeight = FontWeights.Bold;
        }

        private void FakeCall2Button_Click(object sender, RoutedEventArgs e)
        {
            SetCallImage(true);
            _venueIdText.Text = "5423";
            _venueCombo.SelectedIndex = 2;
            _speakingWithCombo.SelectedItem = null;
            _phoneNoText.Text = "+61 7 3822 1234";
            _phoneNoText.FontWeight = FontWeights.Bold;
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var details = CategoryDetails;
                var comboBox = sender as ComboBox;
                string category = comboBox?.SelectedItem as string;
                if (!IsNullOrEmpty(category))
                {
                    this.CBDetails.ItemsSource = details.Where(s => s.CategoryName == category).Select(s => s.Detail);
                    this.CBDetails.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void ComboBox_Loaded(object sender, EventArgs e)
        {
            try
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
            catch
            {

            }
        }
    }
}
