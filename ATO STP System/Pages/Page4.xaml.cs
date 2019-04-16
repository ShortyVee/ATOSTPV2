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
using System.ComponentModel;


namespace ATO_STP_System
{
    /// <summary>
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        MessageBoxResult result = MessageBox.Show("The file was transferred successfully!", "Confirmation");


        public Page4()
        {
            InitializeComponent();
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.60);
            //nameofform.Visibility = Visibility.Hidden;
            TimerLoad();

            //nameofform.Visibility = Visibility.Visible;

        }

        public async void TimerLoad()
        {
            await Task.Delay(2000);
            panel.Visibility = Visibility.Hidden;

        }



    }
}

