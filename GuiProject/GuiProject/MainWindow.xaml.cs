using GuiProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace GuiProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                mutex.ReleaseMutex();
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("only one instance at a time");
                Application.Current.Shutdown();
            }
            
        }
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        [STAThread]

        private void LanguageSelection_Click(object sender, RoutedEventArgs e)
        {
            string lang = ((Button)sender).Tag.ToString();
            Console_Launch();
            switch (lang)
            {
                case "French":
                    LangHelper.ChangeLanguage("fr");
                    Content = new FunctionalPage();
                    break;
                case "English":
                    LangHelper.ChangeLanguage("");
                    Content = new FunctionalPage();
                    break;
                default:
                    throw new NotImplementedException("");
                    break;
            }
        }

        static void Console_Launch()
        {
            Console.Title = "SERVER";

            IPAddress myIp = IPAddress.Parse("127.0.0.1");
            int port = 3000;

            Server server = new Server(myIp, port);


            //
            server.startListening();
            Console.WriteLine("Server started");

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Waiting for connection");

            //if somebody wants to connect, accept it
            server.acceptClient();
            Console.WriteLine("Client connected");

            string messageFromClient = "";
            string messageToClient = "";

            try
            {
                server.clientData();

                
                while (server.serverStatus)
                {

                    
                    if (server.socketForClient.Connected)
                    {
                        
                        messageFromClient = server.streamReader.ReadLine();
                        
                        Console.WriteLine($"Client : {messageFromClient}");

                        
                        if (messageFromClient == "exit")
                        {
                            server.serverStatus = false; 
                            server.streamReader.Close();
                            server.streamWriter.Close();
                            server.networkStream.Close();
                            return;
                        }

                        else if (messageFromClient == "Connection succesfull")
                        {
                            Console.WriteLine("Client connected to server");
                        }

                        else if (messageFromClient == "Display save work")
                        {
                            Console.WriteLine("Display save work to client");
                        }

                        else if (messageFromClient == "Execute all save work")
                        {
                            Console.WriteLine("Execute all save work");
                        }

                        Console.Write("Server : ");
                        
                        messageToClient = Console.ReadLine();
                        
                        server.streamWriter.WriteLine(messageToClient);

                        server.streamWriter.Flush();
                    }
                }

                
                Console.WriteLine("Client disconnected");
                server.disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
