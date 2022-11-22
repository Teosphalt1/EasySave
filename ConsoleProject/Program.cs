using ConsoleProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            
            while (true)
            {
                context.selectLanguage();
            }
        }
    }
}