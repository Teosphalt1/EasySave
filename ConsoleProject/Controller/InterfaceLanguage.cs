using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal interface IStrategyLanguage
    {
        void BeginAlgorithmTXT();
        void ExecuteASaveTXT();
        void AddASaveTXT();
        void ExecuteOnAllTheSavesTXT();
        void ExecuteOnASpecificSaveTXT();
        void SaveNameChoiceTXT();
        void ErrorBadChoiceTXT();
        void ErrorTooMuchSaveTXT();
        void ErrorWrongIdTXT();
    }
}
