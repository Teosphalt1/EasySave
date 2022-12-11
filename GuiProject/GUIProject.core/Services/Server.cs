using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using GuiProject;
using GUIProject;
using System.Threading;
using GUIProject.core.Services.Strategies;

namespace GuiProject
{
    public class Server
    {

        public IPAddress myIp { get; private set; }
        public int port { get; private set; }
        public bool serverStatus = true;
        private TcpListener tcpListener { get; set; }
        public Socket socketForClient { get; set; }

        public NetworkStream networkStream { get; set; }
        public StreamReader streamReader { get; set; }
        public StreamWriter streamWriter { get; set; }

        public ManualResetEvent manualResetEvent = new ManualResetEvent(true);
        public IList<Thread> threadList = new List<Thread>();


        public Server(IPAddress myIp, int port)
        {
            this.myIp = myIp;
            this.port = port;
        }

        public void TryConnection(Server server)
        {
            server.startListening();
            server.acceptClient();
            string messageFromClient = "";
            string messageToClient = "";
            //Thread thread = new Thread(()=> UTILISATION DE THREAD IMPOSSIBLE CAR FERME LA CONNEXION, UTILISATION DE LOCK POUR LE MAINTENIR EN VIE ? 
            listeningClient(server, messageFromClient);
        }


        public void startListening()
        {
            try
            {
                tcpListener = new TcpListener(myIp, port);
                tcpListener.Start();
            }
            catch
            {
                Console.WriteLine("Could not start ");
            }
        }

        public void acceptClient()
        {
            try
            {
                socketForClient = tcpListener.AcceptSocket();
            }
            catch
            {
                Console.WriteLine("Could not accept client");
            }
        }

        //allows server to exchange data with the client 

        public void clientData()
        {
            //client data
            networkStream = new NetworkStream(socketForClient);

            //allows us to read from the client 
            streamReader = new StreamReader(networkStream);

            //allows us to write to the client
            streamWriter = new StreamWriter(networkStream);
        }

        public void disconnect()
        {
            networkStream.Close();
            streamReader.Close();
            streamWriter.Close();
            socketForClient.Close();
        }

        public void listeningClient(Server server, string messageFromClient)
        {
            try
            {
                server.clientData();

                while (server.serverStatus)
                {
                    if (server.socketForClient.Connected)
                    {
                        messageFromClient = server.streamReader.ReadLine();
                        switch (messageFromClient)
                        {
                            case "Execute_Save" :
                                server.streamWriter.WriteLine("Currently executing save");
                                server.streamWriter.Flush();

                                //EXECUTING ALL SAVES
                                string blockIfRunningAll = "";
                                string cryptFilesAll = "NothingToCrypt";
                                
                                new ExecuteAllTheSaves().ExecuteSave(blockIfRunningAll, threadList, cryptFilesAll, manualResetEvent);
                                break;

                            case "Execute_One_Save":

                                Thread.Sleep(8000);
                                string myId = streamReader.ReadLine();


                                server.streamWriter.WriteLine($"Currently executing save {myId}");
                                server.streamWriter.Flush();
                                // EXECUTING SAVE {ID}
                                // get premier message qui dit de faire une save, puis get un second message qui donne l'id, meme intervale de temps d'attente pour pas poser de bugs
                                //obliger le client a mettre un id NUMERIQUE avant d'envoyer le message execute 1 save 
                                string blockIfRunningOne = "";
                                string cryptFilesOne = "NothingToCrypt";

                                int intId = Int16.Parse(myId);
                                ServiceDB serviced = new ServiceDB();
                                serviced.GenerateSaveWork();
                                if (intId >= serviced.GetAll().FirstOrDefault().id && intId <= serviced.GetAll().LastOrDefault().id)
                                {
                                    new ExecuteOneSave().ExecuteSave(myId, blockIfRunningOne, threadList, cryptFilesOne, manualResetEvent);
                                    server.streamWriter.WriteLine($"Save work {myId} executing");
                                }
                                else
                                {
                                    server.streamWriter.WriteLine("Bad ID BOUFFON");
                                }


                                break;

                            case "Play":
                                server.streamWriter.WriteLine("OH NON CA RECOMMENCE");
                                server.streamWriter.Flush();
                                manualResetEvent.Set();
                                server.streamWriter.WriteLine("JOUE JOUE JOUE");
                                server.streamWriter.Flush();
                                //if (playing = true)
                                //  {
                                //      server.streamWriter.WriteLine("Already playing");
                                //      server.streamWriter.Flush();
                                //  }
                                //else 
                                //  {
                                //      server.streamWriter.WriteLine("Save now playing");
                                //      server.streamWriter.Flush();
                                //      Play();
                                //  }
                                break;
                             case "Pause":
                                server.streamWriter.WriteLine("MI TEMPS");
                                server.streamWriter.Flush();
                                manualResetEvent.Reset();
                                server.streamWriter.WriteLine("ALLER PAUSE TA MERE LA");
                                server.streamWriter.Flush();


                                //if (pausing = true)
                                //  {
                                //      server.streamWriter.WriteLine("Already pausing");
                                //      server.streamWriter.Flush();
                                //  }
                                //else 
                                //  {
                                //      server.streamWriter.WriteLine("Save now pausing");
                                //      server.streamWriter.Flush();
                                //      Pause();
                                //  }
                                break;
                            case "Stop":


                                if (threadList != null)
                                {
                                    foreach (Thread thread in threadList)
                                    {
                                        thread.Interrupt();
                                    }
                                }
                                threadList.Clear();
                                server.streamWriter.WriteLine("ARRETEZ VOUS");
                                server.streamWriter.Flush();


                                //if ((pausing = true)||(playing = true))
                                //  {
                                //      server.streamWriter.WriteLine("Save work stopped");
                                //      server.streamWriter.Flush();
                                //      Stop();
                                //  }
                                //else 
                                //  {
                                //      server.streamWriter.WriteLine("Nothing is currently executing, can't stop nothing");
                                //      server.streamWriter.Flush();
                                //  }
                                break;
                            case "Display_Works":
                                server.streamWriter.WriteLine("Currently displaying works");
                                server.streamWriter.Flush();
                                // DISPLAY SAVE WORKS
                                break;
                        }
                    }
                }
            }
            catch
            {
                server.disconnect();
            }


        }

    }
}