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
                    _context.SetStrategySaveType(new AllTheSavesStrategy());
                    _context._strategySaveType.ExecuteSave();
                    _context._strategyLanguage.ExecuteOnAllTheSavesTXT();
                }
                if (choiceNumberOfSave == "2")
                {
                    _context._strategyLanguage.SaveNameChoiceTXT();
                    _context.SetStrategySaveType(new SpecificSaveStrategy());
                    _context._strategySaveType.ExecuteSave();
                    _context._strategyLanguage.ExecuteOnASpecificSaveTXT();
                }
            }
            else if (choice == "2")
            {
                //dbjson.addNewSaveWork();
                if(dbjson.addNewSaveWork() == null)
                {
                    _context._strategyLanguage.ErrorBadChoiceTXT();
                }
                {
                    _context._strategyLanguage.AddASaveTXT();
                }
                
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
