﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Controller
{
    class SelectLanguage
    {
        private View _view;
        private Context _context;
        public SelectLanguage()
        {
            _view = new View();
            _context = new Context();
            if (_view.Language == "FR" || _view.Language == "fr")
            {
                _context.SetStrategy(new FrenchStrategy());
                LaunchProgram launchProgram = new LaunchProgram(_context);
            }
            else if (_view.Language == "EN" || _view.Language == "en")
            {
                _context.SetStrategy(new EnglishStrategy());
                LaunchProgram launchProgram = new LaunchProgram(_context);
            }
            else
            {
                Console.WriteLine("Erreur mauvaise saisie de langage\nError bad language selection");
            }
        }
    }
}