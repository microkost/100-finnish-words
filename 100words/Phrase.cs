using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace words100
{
    public class Phrase
    {
        //public string category { get; set; }
        public string wordFI { get; set; }
        public string wordEN { get; set; }
        public string wordCZ { get; set; }

        public string wordPL { get; set; }

        public Phrase(string wordFI, string wordEN, string wordCZ, string wordPL)
        {
            this.wordFI = wordFI;
            this.wordEN = wordEN;
            this.wordCZ = wordCZ;
            this.wordPL = wordPL;
        }

        /*
        public List<string> ToStringList(Phrase ph)
        {
            List<String> result = new List<String>();
            result.Add(ph.wordFI);
            result.Add(ph.wordEN);
            result.Add(ph.wordCZ);
            result.Add(ph.wordPL);
            return result;
        }
        */
    }
}
