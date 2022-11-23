//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleProject
//{
//    class FrenchStrategy : IStrategyLanguage
//    {
//        string saveName;

//        public void BeginAlgorithmTXT()
//        {
//            Console.WriteLine("1-Executer un travail de sauvegarde\n2-Ajouter une sauvegarde\n3-consulter les travaux de sauvegardes");
//        }

//        public void ExecuteASaveTXT()
//        {
//            Console.WriteLine("1-Executer la sauvegarde sur tous les travaux\n2-Executer sur un travail");
//        }

//        public void AddASaveTXT()
//        {
//            Console.WriteLine("Vous avez ajouté une nouvelle sauvegarde");
//        }

//        public void ExecuteOnAllTheSavesTXT()
//        {
//            Console.WriteLine("1-Executer une sauvegarde complète\n2-Executer une sauvegarde différentielle");
//        }
//        public void ExecuteOnASpecificSaveTXT()
//        {
//            Console.WriteLine("Donnez le nom exact de la sauvegarde");
//            saveName = Console.ReadLine();
//            Console.WriteLine("1-Executer une sauvegarde complète\n2-Executer une sauvegarde différentielle");
//        }

//        public void AllSaveCompleteTXT()
//        {
//            Console.WriteLine("Vous avez fait une sauvegarde complète de tous les travaux de sauvegarde");
//        }

//        public void AllSaveDifferentialTXT()
//        {
//            Console.WriteLine("Vous avez fait une sauvegarde différentielle de tous les travaux de sauvegarde");
//        }

//        public void SpecificSaveCompleteTXT()
//        {
//            Console.WriteLine("Vous avez fait une sauvegarde complète de la sauvegarde " + saveName);
//        }

//        public void SpecificSaveDifferentialTXT()
//        {
//            Console.WriteLine("Vous avez fait une sauvegarde différentielle de la sauvegarde " + saveName);
//        }

//        public void ErrorBadChoiceTXT()
//        {
//            Console.WriteLine("Erreur, choix non reconnu");
//        }
//    }
//}
