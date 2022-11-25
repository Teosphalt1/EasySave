using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class FrenchStrategy : IStrategyLanguage
    {
        string saveName;

        public void BeginAlgorithmTXT()
        {
            Console.WriteLine("1-Executer un travail de sauvegarde\n2-Ajouter une sauvegarde\n3-consulter les travaux de sauvegardes");
        }

        public void ExecuteASaveTXT()
        {
            Console.WriteLine("1-Executer la sauvegarde sur tous les travaux\n2-Executer sur un travail");
        }

        public void AddASaveTXT()
        {
            Console.WriteLine("Vous avez ajouté une nouvelle sauvegarde");
        }

        public void ExecuteOnAllTheSavesTXT()
        {
            Console.WriteLine("Vous avez effectué une sauvegarde de tous les travaux");
        }
        public void SaveNameChoiceTXT()
        {
            Console.WriteLine("Entrez l'id du travail de sauvegarde à effectuer");
        }
        public void ExecuteOnASpecificSaveTXT()
        {
            Console.WriteLine("Vous avez effectué la sauvegarde du travail");
        }
        public void ErrorBadChoiceTXT()
        {
            Console.WriteLine("Erreur, choix non reconnu");
        }
    }
}
