using GuiProject.Pages;
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

namespace GuiProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LanguageSelection_Click(object sender, RoutedEventArgs e)
        {
            string lang = ((Button)sender).Tag.ToString();

            switch(lang)
            {
                case "French":
                    //MessageBox.Show("Français");
                    LangHelper.ChangeLanguage("fr");
                    Content = new FrenchPage();
                    break;
                case "English":
                    //MessageBox.Show("English");
                    LangHelper.ChangeLanguage("");
                    Content = new FrenchPage();
                    break;
                default:
                    throw new NotImplementedException("");
                    break;
            }
        }
    }
}
