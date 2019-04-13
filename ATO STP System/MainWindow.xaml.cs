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
using System.Net.Http;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace ATO_STP_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Uri _page1 = new Uri("Pages/Page1.xaml", UriKind.Relative);
        Uri _page2 = new Uri("Pages/Page2.xaml", UriKind.Relative);
        Uri _page3 = new Uri("Pages/Page3.xaml", UriKind.Relative);
        Uri _page4 = new Uri("Pages/Page4.xaml", UriKind.Relative);

        public MainWindow()
        {
            InitializeComponent();
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.60);
            _NavigationFrame.Navigate(new Page1());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebRequest req = null;
            WebResponse rsp = null;
            try
            {
                string fileName = "C:\ato.payevnt.0003.2018.01.00.PushRequest.sample.xml";
                string uri = "https://test2.ato.sbr.gov.au/services/Single-sync";
                req = WebRequest.Create(uri);
                //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                req.Method = "POST";        // Post method
                req.ContentType = "text/xml";     // content type
                                                  // Wrap the request stream with a text-based writer
                StreamWriter writer = new StreamWriter(req.GetRequestStream());
                // Write the XML text into the stream
                writer.WriteLine(this.GetTextFromXMLFile(fileName));
                writer.Close();
                // Send the data to the webserver
                rsp = req.GetResponse();


                System.Diagnostics.Debug.WriteLine(rsp);

            }
            catch (WebException webEx)
            {
                System.Diagnostics.Debug.WriteLine(webEx);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (req != null) req.GetRequestStream().Close();
                if (rsp != null) rsp.GetResponseStream().Close();
            }
            
        }

        //Function to read xml data from local system
        private string GetTextFromXMLFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine(_NavigationFrame.NavigationService.Source);
            Uri currentUri = _NavigationFrame.NavigationService.Source;

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
            } else
            {
                newUri = _page2;
            }
            _NavigationFrame.NavigationService.Navigate(newUri);
        }
    }



}
