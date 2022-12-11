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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 10.133.129.169
    ///Spam message en boucle ->Flush text box ????
    ///Renvoie message trop rapide
    public partial class MainWindow : Window
    {
        static string myIp = "127.0.0.1";
        static int port = 3000;
        public Client client = new Client(myIp, port);
        public string messageFromServer = "";
        public string messageToServer = "I'm connected";
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
                //MessageBox.Show($"{messageFromServer}");
                //Retour.Text = messageFromServer;
            }
            catch
            {
                MessageBox.Show($"Pas de nouveau message");
            }
        }
        private void Send_Messages(object sender, RoutedEventArgs e)
        {
            try
            {
                messageToServer = Message.Text;
                client.streamWriter.WriteLine($"{messageToServer}");
                client.streamWriter.Flush();
            }
            catch
            {
                MessageBox.Show($"Pas de message à envoyer");
            }

        }
        /* A IMPLEMENTER
            catch
            {
                MessageBox.Show("Problem reading from server");
            }
            client.disconnect();
        */
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
        public void Display(object sender, RoutedEventArgs e) //METTRE A JOUR QUE CA C'EST L'EXECUTION DE TOUTES LES FILES
        {
            MessageBox.Show("Execute save work");
            messageToServer = "Execute_Save";
            client.streamWriter.WriteLine($"{messageToServer}");
            client.streamWriter.Flush();
        }
        public void ExecuteAll(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ExecAll");
        }
        public void ExecuteOne(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ExecuteOne");
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
