using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class States
    {
        public string Name { get; set; }
        public string FileSource { get; set; }
        public string destPath { get; set; }
        public int totalFiles { get; set; }
        public string time { get; set; }
        public int totalSize { get; set; }
        public int sizeLeft { get; set; }
        public int filesLeft { get; set; }
        public string state { get; set; }
    }
}
