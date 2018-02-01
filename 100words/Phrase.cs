using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100words
{
    public class Phrase
    {
        //public string category { get; set; }
        public string wordFI { get; set; }
        public string wordEN { get; set; }
        public string wordCZ { get; set; }

        public Phrase(string wordFI, string wordEN, string wordCZ)
        {
            this.wordFI = wordFI;
            this.wordEN = wordEN;
            this.wordCZ = wordCZ;
        }
    }
}
