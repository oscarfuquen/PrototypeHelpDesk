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
    }
}
