//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using GUIProject;
//using GUIProject.core.Services.Strategies;
//using Newtonsoft.Json;

//namespace GuiProject.Pages
//{
//    /// <summary>
//    /// Logique d'interaction pour EnglishPage.xaml
//    /// </summary>
//    public partial class EnglishPage : Page
//    {
//        public EnglishPage()
//        {
//            InitializeComponent();
//        }

//        private void LeftMenu_Click(object sender, RoutedEventArgs e)
//        {
//            string menuType = ((Button)sender).Tag.ToString();

//            switch (menuType)
//            {
//                case "DisplaySaveWorks":
//                    ServiceDB servicedb = new ServiceDB();
//                    servicedb.GenerateSaveWork();
//                    testList.ItemsSource = servicedb.GetAll();
//                    break;
//                case "AddSaveWork":
//                    DateTime now = DateTime.Now;
//                    string mySaveType = "0";
//                    if (saveType.SelectedIndex.ToString() == "0")
//                    {
//                        mySaveType = "complete";
//                    }
//                    else if (saveType.SelectedIndex.ToString() == "1")
//                    {
//                        mySaveType = "differential";
//                    }
//                    SaveWork savework = new SaveWork
//                    {
//                        id = Convert.ToInt16(saveId.Text),
//                        Name = saveName.Text,
//                        FileSource = saveSource.Text,
//                        destPath = saveDest.Text,
//                        type = mySaveType,
//                        time = now.ToString()
//                    };
//                    if (savework != null)
//                    {
//                        new ServiceDB().WriteSaveWork(savework);
//                    }
//                    new ExecuteSaveOnCreation().ExecuteSave();
//                    break;

//                case "ExecuteAllSaveWorks":
//                    new ExecuteAllTheSaves();
//                    MessageBox.Show("Saves done");
//                    break;
//                case "ExecuteOnSaveWork":
//                    string myId = saveWorkToExecuteId.Text;
//                    int intId = Int16.Parse(myId);
//                    ServiceDB serviced = new ServiceDB();
//                    int amountOfSaves = serviced.ToString().Length / 10;

//                    if(intId > 0 && intId <= amountOfSaves)
//                    {
//                        new ExecuteOneSave().ExecuteSave(myId);
//                        MessageBox.Show("Save done");
//                    }
//                    else
//                    {
//                        MessageBox.Show("Bad Id");
//                    }
//                    break;
//                default:
//                    break;
//            }
//        }
//    }
//}
