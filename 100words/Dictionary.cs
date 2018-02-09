using System.Collections.Generic;

namespace words100
{
    public static class Dictionary
    {
        public static List<string> GetListOfLanguages() 
        {
            List<string> lang = new List<string>(); //manually managed
            //if less than 3 then update code! (index null reference)
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
                new Phrase("Suomi", "English", "Česky", "Polski"), //this first line is never showed
                new Phrase("Moi", "Hello", "Ahoj", "Cześć"),
                new Phrase("Heippa", "Bye", "Nashledanou", "Do widzenia"),
                new Phrase("Olla", "To be", "Být", "Być")
                //more phrases should be added withoud additional changes
            };

            //extended

            //urban

            return dict;
        }
    }
}
