using System.Collections.Generic;

namespace words100
{
    public static class Dictionary
    {
        public static List<string> GetListOfLanguages() 
        {
            List<string> lang = new List<string>(); //manually managed
            lang.Add("Finnish");
            lang.Add("English");
            lang.Add("Czech");
            lang.Add("Polish");
            return lang;
        }

        public static List<Phrase> GetListOfWords()
        {
            //basic 100
            List<Phrase> dict = new List<Phrase>() //manually managed
            {
                new Phrase("Suomi", "English", "Česky"), //this first line is never show
                new Phrase("Moi", "Hello", "Ahoj"),
                new Phrase("Heippa", "Bye", "Nashledanou"),
                new Phrase("Olla", "To be", "Mít")
            };

            //extended

            //urban

            return dict;
        }
    }
}
