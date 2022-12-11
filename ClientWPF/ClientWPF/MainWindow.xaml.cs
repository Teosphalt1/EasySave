using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using ClientWPF;
using ClientWPF.core;

namespace ClientWPF
{
    public partial class MainWindow : Window
    {
        static string myIp = "127.0.0.1";
        static int port = 3000;
        public Client client = new Client(myIp, port);
        public string messageFromServer = "";
        public string messageToServer = "";
        public MainWindow()
        {
            InitializeComponent();
            client.ConnectToServer();
            MessageBox.Show("Connected to server");
            Thread.Sleep(1000);
            client.serverData();
        }
        public void Get_Messages(object sender, RoutedEventArgs e)
        {
            try
            {
                messageFromServer = client.streamReader.ReadLine();
                while (messageFromServer != "")
                {
                    Retour.Text = messageFromServer;
                    messageFromServer = "";
                }
            }
            catch
            {
                MessageBox.Show($"No new message");
            }
        }
          public void LeftMenu_Click(object sender, RoutedEventArgs e)
        {
            string menuType = ((Button)sender).Tag.ToString();
            switch (menuType)
            {
                case "PauseSaveWorks":
                    messageToServer = "Pause";
                    client.streamWriter.WriteLine($"{messageToServer}");
                    client.streamWriter.Flush();
                    break;
                case "StartSaveWorks":
                    messageToServer = "Play";
                    client.streamWriter.WriteLine($"{messageToServer}");
                    client.streamWriter.Flush();
                    break;
                case "StopSaveWorks":
                    messageToServer = "Stop";
                    client.streamWriter.WriteLine($"{messageToServer}");
                    client.streamWriter.Flush();
                    break;
            }
        }
        public void Execute_AllSaves(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Execute all save work");
            messageToServer = "Execute_Save";
            client.streamWriter.WriteLine($"{messageToServer}");
            client.streamWriter.Flush();
        }
        public void ExecuteOne(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Execute selected save");
            messageToServer = "Execute_One_Save";
            client.streamWriter.WriteLine($"{messageToServer}");
            client.streamWriter.Flush();
            Thread.Sleep(4000);
            messageToServer = ID_Message.Text;
            client.streamWriter.WriteLine($"{messageToServer}");
            client.streamWriter.Flush();
        }
    }
}
