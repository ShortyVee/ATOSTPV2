using System;
using System.Collections.Generic;
using ATO_STP_System.Helpers;
using SQLite;
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

namespace ATO_STP_System
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {

        Uri _page1 = new Uri("Pages/Page1.xaml", UriKind.Relative);
        Uri _page2 = new Uri("Pages/Page2.xaml", UriKind.Relative);
        Uri _page3 = new Uri("Pages/Page3.xaml", UriKind.Relative);
        Uri _page4 = new Uri("Pages/Page4.xaml", UriKind.Relative);

        public Page3()
        {
            InitializeComponent();
            /*this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.60);
            */

            //Populate database fields into "contentBlock" field
            /*
            GetImportedFileList(DatabaseHelpers.employerDB);
            GetImportedFileList(DatabaseHelpers.employeeDB);
            */

            //Use this same code on the next page to run the validation scripts PAYEVNT and PAYEVNTEMP, display errors after loading screen


        }

        private void Next_Button(object sender, RoutedEventArgs e)
        {
            navigatePages();
        }


            public void navigatePages()
        {
            Uri currentUri = ((MainWindow)Application.Current.MainWindow)._NavigationFrame.NavigationService.Source;

            Uri newUri = _page1;

            if (currentUri != null)
            {
                string uriString = currentUri.ToString();

                switch (uriString)
                {
                    case "Pages/Page1.xaml":
                        newUri = _page2;
                        break;
                    case "Pages/Page2.xaml":
                        newUri = _page3;
                        break;
                    case "Pages/Page3.xaml":
                        newUri = _page4;
                        break;
                    default:
                        newUri = _page1;
                        break;
                }
            }
            else
            {
                newUri = _page2;
            }
          ((MainWindow)Application.Current.MainWindow)._NavigationFrame.NavigationService.Navigate(newUri);
        }
    }
    /*
    public static List<string> GetImportedFileList(String databasePath)
    {
        List<string> ImportedFiles = new List<string>();
        using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=" + databasePath))
        {
            connect.Open();
            using (SQLiteCommand fmd = connect.CreateCommand())
            {
                fmd.CommandText = @"SELECT DISTINCT FileName FROM Import";
                SQLiteDataReader r = fmd.ExecuteReader();
                while (r.Read())
                {
                    string FileNames = (string)r["FileName"];

                    ImportedFiles.Add(FileNames);
                }

                connect.Close();
            }
        }
        return ImportedFiles;
    }
    */
}
