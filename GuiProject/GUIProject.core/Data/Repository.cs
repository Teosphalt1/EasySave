using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProject
{
    public class Repository
    {
        /// <summary>
        /// 
        /// </summary>
        private static Repository _instance = null;
        public List<SaveWork> SaveWorks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private Repository()
        {
            SaveWorks = new List<SaveWork>();
        }
        /// <summary>
        /// 
        /// </summary>
        public static Repository Instance()
        {
            if (_instance == null)
                _instance = new Repository();
            return _instance;
        }
    }
}
