using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class Context
    {
        private IStrategyLanguage _strategyLanguage;
        public void SetStrategy(IStrategyLanguage strategyLanguage)
        {
            _strategyLanguage = strategyLanguage;
        }

        public void selectLanguage()
        {
            Console.WriteLine("Tapez FR pour avoir le software en francais or EN to have the english version of the software");
            string language = Console.ReadLine();
            if (language == "FR" || language == "fr")
            {
                SetStrategy(new FrenchStrategy());
                //LaunchProgram();
            }
            else if (language == "EN" || language == "en")
            {
                SetStrategy(new EnglishStrategy());
                //LaunchProgram();
            }
            else
            {
                Console.WriteLine("Erreur mauvaise saisie de langage\nError bad language selection");
            }
        }

        public void LaunchProgram()
        {
            this._strategyLanguage.BeginAlgorithmTXT();
            string choice = Console.ReadLine();
            if(choice == "1")
            {
                this._strategyLanguage.ExecuteASaveTXT();
                string choiceNumberOfSave = Console.ReadLine();
                if (choiceNumberOfSave == "1")
                {
                    this._strategyLanguage.ExecuteOnAllTheSavesTXT();
                    string choiceType = Console.ReadLine();

                    if (choiceType == "1")
                    {
                        this._strategyLanguage.AllSaveCompleteTXT();
                    }
                    else if (choiceType == "2")
                    {
                        this._strategyLanguage.AllSaveDifferentialTXT();
                    }
                    else
                    {
                        this._strategyLanguage.ErrorBadChoiceTXT();
                    }
                }
                if (choiceNumberOfSave == "2")
                {
                    this._strategyLanguage.ExecuteOnASpecificSaveTXT();
                    string choiceType = Console.ReadLine();
                    if (choiceType == "1")
                    {
                        this._strategyLanguage.SpecificSaveCompleteTXT();
                    }
                    else if (choiceType == "2")
                    {
                        this._strategyLanguage.SpecificSaveDifferentialTXT();
                    }
                    else
                    {
                        this._strategyLanguage.ErrorBadChoiceTXT();
                    }
                }
            }
            else if (choice == "2")
            {
                this._strategyLanguage.AddASaveTXT();
            }
            else
            {
                this._strategyLanguage.ErrorBadChoiceTXT();
            }
        }
    }
}
