using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MapsNavigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string totalDistance;
        public String TotalDistance
        {
            get { return totalDistance; }
            set
            {
                totalDistance = value;
                OnPropertyChanged("TotalDistance");
            }
        }
        private string labelNorthSouth;
        public string LabelNorthSouth
        {
            get { return labelNorthSouth; }
            set
            {
                labelNorthSouth = value;
                OnPropertyChanged("labelNorthSouth");
            }
        }
        private string labelEastWest;
        public string LabelEastWest
        {
            get { return labelEastWest; }
            set
            {
                labelEastWest = value;
                OnPropertyChanged("labelEastWest");
            }
        }
        private string blocksNorthSouth;
        public String BlocksNorthSouth 
        {
            get { return blocksNorthSouth; } 
            set 
            {
                blocksNorthSouth = value;
                OnPropertyChanged("BlocksNorthSouth");
            } 
        }
        private string blocksEastWest;
        public String BlocksEastWest
        {
            get { return blocksEastWest; }
            set
            {
                blocksEastWest = value;
                OnPropertyChanged("BlocksEastWest");
            }
        }
        private string lastFacing;
        public String LastFacing
        {
            get { return lastFacing; }
            set
            {
                lastFacing = value;
                OnPropertyChanged("LastFacing");
            }
        }
        private string errorMessage;
        public String ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        private void OnStartUp(object sender, RoutedEventArgs e)
        {
            //trigger placeholder text and initialize variables
            txt_MN_Input.RaiseEvent(new RoutedEventArgs(LostFocusEvent, txt_MN_Input));
            btn_MN_ResetForm.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            //Set data contexts
            this.DataContext = this;
        }

        private void txt_MN_Input_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_MN_Input.Text == String.Empty)
            {
                txt_MN_Input.Foreground = Brushes.Gray;
                txt_MN_Input.Opacity = 0.75;
                txt_MN_Input.Text = MessageText.inputPlaceholder;
            }
        }

        private void txt_MN_Input_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_MN_Input.Text == MessageText.inputPlaceholder || txt_MN_Input.Text == String.Empty)
            {
                txt_MN_Input.Text = String.Empty;
                txt_MN_Input.Foreground = Brushes.Black;
                txt_MN_Input.Opacity = 1;
            }
        }

        private void btn_MN_CalculateDistance_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage = String.Empty;

            if (!CalculateDistance.ValidateDirectionsInput(txt_MN_Input.Text, out List<String> newList))
            {
                ErrorMessage = MessageText.errorMessage;
                return;
            }

            Coordinates newCoordinates = CalculateDistance.TraverseDirections(newList);

            TotalDistance = newCoordinates.TotalDistance().ToString();
            LastFacing = newCoordinates.facing;

            if (newCoordinates.north < 0)
            {
                BlocksNorthSouth = Math.Abs(newCoordinates.north).ToString();
                LabelNorthSouth = MessageText.blocksSouth;
            }
            else
            {
                BlocksNorthSouth = newCoordinates.north.ToString();
                LabelNorthSouth = MessageText.blocksNorth;
            }

            if (newCoordinates.east < 0)
            {
                BlocksEastWest = Math.Abs(newCoordinates.east).ToString();
                LabelEastWest = MessageText.blocksWest;
            }
            else
            {
                BlocksEastWest = newCoordinates.east.ToString();
                LabelEastWest = MessageText.blocksEast;
            }
        }

        private void btn_MN_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_MN_ResetForm_Click(object sender, RoutedEventArgs e)
        {
            txt_MN_Input.Text = String.Empty;
            tb_MN_ErrorMessage.Text = String.Empty;
            TotalDistance = "0";
            BlocksNorthSouth = "0";
            BlocksEastWest = "0";
            LastFacing = "North";
            LabelNorthSouth = MessageText.blocksNorth;
            LabelEastWest = MessageText.blocksEast;
            txt_MN_Input.RaiseEvent(new RoutedEventArgs(LostFocusEvent, txt_MN_Input));
        }

        private void txt_MN_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_MN_CalculateDistance.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
