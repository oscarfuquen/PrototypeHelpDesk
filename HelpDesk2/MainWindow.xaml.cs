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

            SetCallImage(false);
            _phoneNoText.FontWeight = FontWeights.Normal;
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

            _sde.Show();
            _sde.Activate();
        }

        private void VenueComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    ComboBoxItem item = e.AddedItems[0] as ComboBoxItem;
            //    _sde.VenueName = item.Content as String;
            //}
            //catch
            //{
            //    // Do nothing.
            //}
        }

        private void SpeakingWithComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    TextBox tb = e.OriginalSource as TextBox;
            //    _sde.SpokeTo = tb.Text as String;
            //}
            //catch
            //{
            //    // Do nothing.
            //}
        }

        private void SetCallImage(bool isCallInProgress)
        {
            if (isCallInProgress)
            {
                BitmapImage image = new BitmapImage(new Uri("/HelpDesk2;component/icons/phone_green.png", UriKind.Relative));
                _callImage.Source = image;
            }
            else
            {
                BitmapImage image = new BitmapImage(new Uri("/HelpDesk2;component/icons/phone_red.gif", UriKind.Relative));
                _callImage.Source = image;
            }
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
    }
}
