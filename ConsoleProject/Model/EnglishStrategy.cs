using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class EnglishStrategy : IStrategyLanguage
    {
        string saveName;
        public void BeginAlgorithmTXT()
        {
            Console.WriteLine("1-Execute a save work\n2-Add a save work\n3-Show existent save works");
        }

        public void ExecuteASaveTXT()
        {
            Console.WriteLine("1-Execute on all the saves\n2-Execute on a particular save");
        }
        public void AddASaveTXT()
        {
            Console.WriteLine("You've added a new save");
        }

        public void ExecuteOnAllTheSavesTXT()
        {
            Console.WriteLine("1-Execute a complete save\n2-Execute a differential save");
        }

        public void ExecuteOnASpecificSaveTXT()
        {
            Console.WriteLine("Give the exact name of the save");
            saveName = Console.ReadLine();
            Console.WriteLine("1-Execute a complete save\n2-Execute a differential save");
        }

        public void AllSaveCompleteTXT()
        {
            Console.WriteLine("You have done a complete save of every save work");
        }
        public void AllSaveDifferentialTXT()
        {
            Console.WriteLine("You have done a differential save of every save work");
        }

        public void SpecificSaveCompleteTXT()
        {
            Console.WriteLine("You have done a complete save of the save work " + saveName);
        }

        public void SpecificSaveDifferentialTXT()
        {
            Console.WriteLine("You have done a differential save of the save work " + saveName);
        }

        public void ErrorBadChoiceTXT()
        {
            Console.WriteLine("Error not recognized choice");
        }
    }
}
