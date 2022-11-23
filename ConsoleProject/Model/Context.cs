using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class Context
    {
        public IStrategyLanguage _strategyLanguage;
        public void SetStrategy(IStrategyLanguage strategyLanguage)
        {
            _strategyLanguage = strategyLanguage;
        }
    }
}
