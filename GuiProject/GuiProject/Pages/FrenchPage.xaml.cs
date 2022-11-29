using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using GUIProject;
using GUIProject.core.Services.Strategies;
using Newtonsoft.Json;

namespace GuiProject.Pages
{
    /// <summary>
    /// Logique d'interaction pour FrenchPage.xaml
    /// </summary>
    public partial class FrenchPage : Page
    {
        public FrenchPage()
        {
            InitializeComponent();
        }

        private void LeftMenu_Click(object sender, RoutedEventArgs e)
        {
            string menuType = ((Button)sender).Tag.ToString();

            switch(menuType)
            {
                case "DisplaySaveWorks":
                    ServiceDB servicedb = new ServiceDB();
                    servicedb.GenerateSaveWork();
                    testList.ItemsSource = servicedb.GetAll();
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
                    SaveWork savework = new SaveWork
                    {
                        
                        id = Convert.ToInt16(saveId.Text),
                        Name = saveName.Text,
                        FileSource = saveSource.Text,
                        destPath = saveDest.Text,
                        type = mySaveType,
                        time = now.ToString()
                    };
                    if(savework != null )
                    {
                        new ServiceDB().WriteSaveWork(savework);
                    }
                    new ExecuteSaveOnCreation().ExecuteSave();
                    break;

                case "ExecuteAllSaveWorks":
                    //while (Process.GetProcessesByName("Calculator").Length > 0)
                    //{
                    //    MessageBox.Show("ca tourne");
                    //}
                    new ExecuteAllTheSaves().ExecuteSave();
                    MessageBox.Show("Sauvegardes effectuées");
                    break;
                case "ExecuteOneSaveWork":
                    string myId = saveWorkToExecuteId.Text;
                    int intId = Int16.Parse(myId);
                    ServiceDB serviced = new ServiceDB();
                    int amountOfSaves = serviced.ToString().Length / 10;

                    if(intId > 0 && intId <= amountOfSaves)
                    {
                        new ExecuteOneSave().ExecuteSave(myId);
                        MessageBox.Show("Sauvegarde effectuée");
                    }
                    else
                    {
                        MessageBox.Show("Mauvais Id");
                    }
                    
                    break;
                default:
                    break;
            }
        }
    }
}
