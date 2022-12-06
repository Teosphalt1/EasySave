using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
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
using GuiProject.Language;
using System.Xml.Linq;
using GUIProject;
using GUIProject.core.Services.Strategies;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GuiProject.Pages
{
    /// <summary>
    /// Logique d'interaction pour FunctionalPage.xaml
    /// </summary>
    public partial class FunctionalPage : Page
    {
        public FunctionalPage()
        {
            InitializeComponent();
            
            displaySaveWorkMaj.Text = LangHelper.GetString("Display save work maj");
            displaySaveWorkMin.Content = LangHelper.GetString("Display save work min");
            addSaveWorkMin.Content = LangHelper.GetString("Add save work min");
            addSaveWorkMaj.Text = LangHelper.GetString("Add save work maj");
            name.Text = LangHelper.GetString("Name");
            id.Text = LangHelper.GetString("Id");
            source.Text = LangHelper.GetString("Source");
            saveTypeText.Text = LangHelper.GetString("Save type");
            executeAllSaveWorkMaj.Text= LangHelper.GetString("Execute all save work maj");
            executeAllSaveWorkMin.Content = LangHelper.GetString("Execute all save work min");
            executeSaveWorkMaj.Text = LangHelper.GetString("Execute save work maj");
            executeSaveWorkMin.Content = LangHelper.GetString("Execute save work min");
            complete.Content = LangHelper.GetString("Complete");
            differential.Content = LangHelper.GetString("Differential");
            destination.Text = LangHelper.GetString("Destination");
            blockingSoftware.Text = LangHelper.GetString("Blocking software");
        }
        public IList<Thread> threadList = new List<Thread>();
        public static bool pause = false;
        private void LeftMenu_Click(object sender, RoutedEventArgs e)
        {
            string menuType = ((Button)sender).Tag.ToString();
            
            switch(menuType)
            {
                case "DisplaySaveWorks":
                    ServiceDB servicedb = new ServiceDB();
                    servicedb.GetAll().Clear();
                    servicedb.GenerateSaveWork();
                    ListSaveWorks.Items.Refresh();
                    ListSaveWorks.ItemsSource = servicedb.GetAll();
                    break;
                case "AddSaveWork":
                    DateTime now = DateTime.Now;
                    string mySaveType = "0";
                    if (saveType.SelectedIndex.ToString() == "0")
                    {
                        mySaveType = "complete";
                    }
                    else if (saveType.SelectedIndex.ToString() == "1")
                    {
                        mySaveType = "differential";
                    }

                    if(saveName.Text.Length == 0 || saveSource.Text.Length == 0 || saveDest.Text.Length == 0)
                    {
                        MessageBox.Show($"{LangHelper.GetString("Field missing")}");
                    }
                    else
                    {
                        
                        ServiceDB servicet = new ServiceDB();
                        servicet.GenerateSaveWork();
                        int amountSaves = servicet.GetAll().Count;
                        int newSaveId = 0;
                        if (amountSaves <= 0)
                        {
                            newSaveId = 1;
                        }
                        else
                        {
                            newSaveId = servicet.GetAll().LastOrDefault().id + 1;
                        }
                        SaveWork savework = new SaveWork
                        {
                            id = newSaveId,
                            Name = saveName.Text,
                            FileSource = saveSource.Text,
                            destPath = saveDest.Text,
                            type = mySaveType,
                            time = now.ToString()
                        };
                        if (savework != null)
                        {
                            new ServiceDB().WriteSaveWork(savework);
                        }
                        new ExecuteSaveOnCreation().ExecuteSave();
                        servicet.GetAll().Clear();
                        servicet.GenerateSaveWork();
                        ListSaveWorks.Items.Refresh();
                        ListSaveWorks.ItemsSource = servicet.GetAll();
                        MessageBox.Show($"{LangHelper.GetString("Save work added")}");
                    }
                    break;
                case "ExecuteSaveWorks":
                    string blockIfRunningAll = BlockIfRunning.Text;
                    new ExecuteAllTheSaves().ExecuteSave(blockIfRunningAll, threadList);
                    MessageBox.Show($"{LangHelper.GetString("Save done")}");
                    break;
                case "ExecuteOneSaveWork":
                    string blockIfRunningOne = BlockIfRunning.Text;
                    string myId = saveWorkToExecuteId.Text;
                    if(myId == "")
                    {
                        MessageBox.Show($"{LangHelper.GetString("Bad Id")}");
                    }
                    else
                    {
                        int intId = Int16.Parse(myId);
                        ServiceDB serviced = new ServiceDB();
                        serviced.GenerateSaveWork();
                        if (intId >= serviced.GetAll().FirstOrDefault().id && intId <= serviced.GetAll().LastOrDefault().id)
                        {
                            new ExecuteOneSave().ExecuteSave(myId, blockIfRunningOne);
                            MessageBox.Show($"{LangHelper.GetString("Save done")}");
                        }
                        else
                        {
                            MessageBox.Show($"{LangHelper.GetString("Bad Id")}");
                        }
                    }
                    break;
                //case "PauseSaveWorks":
                //    //MessageBox.Show(pause.ToString() );
                //    Thread t1 = new Thread(() => myPause(pause, threadList));
                //    if (pause == false)
                //    {

                //        pause = true;
                //        t1.Start();
                //        //MessageBox.Show(pause.ToString());
                //    }
                //    else if(pause == true)
                //    {
                //        pause = false;
                //        t1.Start();
                //        //MessageBox.Show(pause.ToString());
                //    }
                //    else
                //    {
                //        break;
                //    }
                //    break;
                case "StopSaveWorks":
                    if (threadList != null)
                    {
                        foreach (Thread thread in threadList)
                        {
                            thread.Interrupt();
                        }
                    }
                    threadList.Clear();
                    break;
                case "StartSaveWorks":
                    //pause = false;
                    //Thread t2 = new Thread(() => myPause(pause));
                    //t1.Abort();
                    break;
                default:
                    break;
            }
        }

        //public void myPause(bool pause, IList<Thread> threadlist)
        //{
        //    //while (pause == true)
        //    //{
        //    //
        //    //MessageBox.Show(threadlist.ToString());
        //    while (pause == true)
        //    {
        //        if(threadlist != null)
        //        {
        //            foreach (Thread thread in threadlist)
        //            {
        //                thread.Interrupt();
        //            }
        //        }
        //        threadlist.Clear();
        //    }
        //    foreach (Thread thread in threadlist)
        //    {
        //        //thread.
        //        thread.Interrupt();
        //    }


        //}
    }
}
