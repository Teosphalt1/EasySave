using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class LaunchProgram
    {
        public LaunchProgram(Context _context)
        {
            DBjson dbjson = new DBjson();
            _context._strategyLanguage.BeginAlgorithmTXT();
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                _context._strategyLanguage.ExecuteASaveTXT();
                string choiceNumberOfSave = Console.ReadLine();
                if (choiceNumberOfSave == "1")
                {
                    _context._strategyLanguage.ExecuteOnAllTheSavesTXT();
                    string choiceType = Console.ReadLine();

                    if (choiceType == "1")
                    {
                        _context._strategyLanguage.AllSaveCompleteTXT();
                    }
                    else if (choiceType == "2")
                    {
                        _context._strategyLanguage.AllSaveDifferentialTXT();
                    }
                    else
                    {
                        _context._strategyLanguage.ErrorBadChoiceTXT();
                    }
                }
                if (choiceNumberOfSave == "2")
                {
                    _context._strategyLanguage.ExecuteOnASpecificSaveTXT();
                    string choiceType = Console.ReadLine();
                    if (choiceType == "1")
                    {
                        _context._strategyLanguage.SpecificSaveCompleteTXT();
                    }
                    else if (choiceType == "2")
                    {
                        _context._strategyLanguage.SpecificSaveDifferentialTXT();
                    }
                    else
                    {
                        _context._strategyLanguage.ErrorBadChoiceTXT();
                    }
                }
            }
            else if (choice == "2")
            {
                dbjson.addNewSaveWork();
                _context._strategyLanguage.AddASaveTXT();
            }
            else if (choice == "3")
            {
                dbjson.displaySaveWorks();
            }
            else
            {
                _context._strategyLanguage.ErrorBadChoiceTXT();
            }
        }
    }
}
