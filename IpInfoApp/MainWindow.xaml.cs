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
using System.Net;
using System.Net.Sockets;

namespace IpInfoApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckByIpButtonClick(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = "";
            if(nameTextBox.Text == "" && ipTextBox.Text != "")
            {
                try
                {
            IPHostEntry ipList = Dns.GetHostByAddress(ipTextBox.Text);

            foreach (var a in ipList.HostName)
            {
                nameTextBox.Text += a.ToString();
            }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void CheckByNameButtonClick(object sender, RoutedEventArgs e)
        {
            ipTextBox.Text = "";
            if (nameTextBox.Text != "" && ipTextBox.Text == "")
            {
                try
                {
                IPHostEntry ipList = Dns.GetHostByName(nameTextBox.Text);
                foreach (var a in ipList.AddressList)
                {
                    ipTextBox.Text += a.ToString() + "\n";
                }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
