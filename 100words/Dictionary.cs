using System.Collections.Generic;

namespace words100
{
    internal static class Dictionary
    {
        public static List<Phrase> getListOfWords()
        {
            List<Phrase> dict = new List<Phrase>()
            {
                new Phrase("Moi", "Hello", "Ahoj"),
                new Phrase("Heippa", "Bye", "Nashledanou")
            };

            return dict;
        }
    }
}
