using System.Collections.Generic;

namespace words100
{
    public static class Dictionary
    {
        public static List<Phrase> GetListOfWords()
        {
            //basic 100
            List<Phrase> dict = new List<Phrase>()
            {
                new Phrase("Suomi", "English", "Česky"), //this first line is never show
                new Phrase("Moi", "Hello", "Ahoj"),
                new Phrase("Heippa", "Bye", "Nashledanou"),
                new Phrase("Olla", "To have", "Mít")
            };

            //extended

            //urban

            return dict;
        }
    }
}
