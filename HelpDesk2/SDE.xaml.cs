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

namespace HelpDesk2
{
    /// <summary>
    /// Interaction logic for SDE.xaml
    /// </summary>
    public partial class SDE : Window
    {
        public SDE()
        {
            InitializeComponent();

            // Don't close, just hide the window.
            this.Closing += new System.ComponentModel.CancelEventHandler(AppWindow_Closing);
        }

        void AppWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


        public string _venueName;
        public string VenueName
        {
            get { return _venueName; }
            set
            {
                _venueName = value;
                _venueNameText.Text = _venueName;
            }
        }


        public string _spokeTo;
        public string SpokeTo
        {
            get { return _spokeTo; }
            set
            {
                _spokeTo = value;
                _spokeToText.Text = _spokeTo;
            }
        }

        private void SetBackgroundImage(string fileName)
        {
            BitmapImage image = new BitmapImage(new Uri("/HelpDesk2;component/sdeimages/" + fileName, UriKind.Relative));
            _image.Source = image;
        }

        public void NewSRWithTemplate()
        {
            SetBackgroundImage("sr template.png");
            _descriptionTextBox.Text = "EGM # has an event queue full.";
            _descriptionTextBox.Visibility = Visibility.Visible;
            _venueNameText.Visibility = Visibility.Visible;
            _spokeToText.Visibility = Visibility.Visible;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SetBackgroundImage("sr saved.png");
        }

        private void srCloseButton_Click(object sender, RoutedEventArgs e)
        {
            SetBackgroundImage("dashboard.png");
            _descriptionTextBox.Visibility = Visibility.Hidden;
            _venueNameText.Visibility = Visibility.Hidden;
            _spokeToText.Visibility = Visibility.Hidden;
        }
    }
}
