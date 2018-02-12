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
                new Phrase("Olla", "To be", "Být", "Być"), //verb
                new Phrase("Ja", "And", "A", "I"),
                new Phrase("Se", "It", "Ono", "To"),
                new Phrase("Ei", "No", "Ne", "Nie"),
                new Phrase("Joka", "Which", "Který", "Który"),
                new Phrase("Että", "That", "Že", "Tamto"),
                new Phrase("Tämä", "This", "Toto", "To"),
                new Phrase("Hän", "He/She", "On/Ona", "On/Ona"),
                new Phrase("Voida", "Can", "Moci", "Móc"), //verb
                new Phrase("Saada", "To get", "Dostat", "Dostać"),
                new Phrase("Mutta", "But", "Ale", "Ale"),
                new Phrase("Niin", "So", "Takže", "Więc"),
                new Phrase("Kuin", "As", "Jako", "Tak jak"),
                new Phrase("Ne", "Those", "Tyto", "Tamte"),
                new Phrase("Kun", "When", "Když", "Gdy"),
                new Phrase("Tulla", "To come", "Přijít", "Przyjść"),
                new Phrase("Myös", "Also", "Také", "Również"),
                new Phrase("Tai", "Or", "Nebo", "Lub"),
                new Phrase("Kaikki", "All", "Vše", "Wszystko"),
                new Phrase("Aika", "Quite/Time", "Docela/Čas", "Cichy/Czas"),
                new Phrase("Me", "We", "My", "My"),
                new Phrase("Suuri", "Big", "Velký", "Duży"),
                new Phrase("Vuosi", "Year", "Rok", "Rok"),
                new Phrase("Mikä", "What", "Co", "Co"),
                new Phrase("Toinen", "Another", "Další", "Inny"),
                new Phrase("Muu", "Other", "Jiný", "Inny"),
                new Phrase("Minä", "I", "Já", "Ja"),
                new Phrase("Antaa", "To give", "Dát", "Dawać"),
                new Phrase("Pitää", "To have to/To like", "Muset/mít rád", "Mieć/Polubić"),
                new Phrase("Tehdä", "To do", "Dělat", "Do zrobienia"),
                new Phrase("Jo", "Already", "Už", "Już"),
                new Phrase("Vain", "Only", "Pouze", "Tylko"),
                new Phrase("Nyt", "Now", "Teď", "Teraz"),
                new Phrase("Sekä", "Also", "Také", "Również"),
                new Phrase("Sanoa", "To say", "Říct", "Powiedzieć"),
                new Phrase("Kuitenkin", "However", "Nicméně", "Jednak"),
                new Phrase("Nämä", "These", "Tyto", "Te"),
                new Phrase("Käyttää", "To use", "Použít", "Używać"),
                new Phrase("Jos", "If", "Pokud", "Jeśli"),
                new Phrase("Asia", "Thing", "Věc", "Rzecz"),
                new Phrase("Maa", "Country", "Země", "Kraj"),
                new Phrase("Sitten", "Then", "Pak", "Potem"),
                new Phrase("Ottaa", "Take", "Vzít", "Brać"),
                new Phrase("Mukaan", "With", "S", "Z"),
                new Phrase("Ihminen", "Human", "Člověk", "Człowiek"),
                new Phrase("Vielä", "Still", "Pořád", "Nadal"),
                new Phrase("Osa", "Part", "Část", "Część"),
                new Phrase("Oma", "Own", "Vlastnit", "Posiadać"),
                new Phrase("Uusi", "New", "Nový", "Nowy"),
                new Phrase("Päivä", "Day", "Den", "Dzień"),
                new Phrase("Sama", "Same", "Stejný", "Podobnie"),
                new Phrase("Itse", "Myself", "Sám", "Siebie"),
                new Phrase("Hyvä", "Good", "Dobrý", "Dobry"),
                new Phrase("Suorittaa", "To perform", "Vykonat", "Występować"),
                new Phrase("Moni", "Many", "Mnoho", "Wiele"),
                new Phrase("Pieni", "Small", "Malý", "Mały"),
                new Phrase("Jokin", "Some", "Nějaký", "Trochę"),
                new Phrase("Sellainen", "Such", "Takový", "Taki"),
                new Phrase("Kuulua", "To hear", "Slyšet", "Słyszeć"),
                new Phrase("Ensimmäinen", "First", "První", "Pierwszy"),
                new Phrase("Työ", "Job", "Práce", "Praca"),
                new Phrase("Mennä", "To go", "Jít", "Iść"),
                new Phrase("Nähdä", "To see", "Vidět", "Zobaczyć"),
                new Phrase("Jälkeen", "After", "Poté", "Po"),
                new Phrase("Mies", "Man", "Muž", "Mężczyzna"),
                new Phrase("Tapa", "To kill/Habit", "Zabít/Zvyk", "Zabić/Przyzwyczajenie"),
                new Phrase("Alkaa", "To begin", "Začít", "Zaczynać"),
                new Phrase("Paljon", "A lot", "Mnoho", "Dużo"),
                new Phrase("Tässä", "Here", "Tady", "Tutaj"),
                new Phrase("Näin", "So", "Takže", "Więc"),
                new Phrase("Tapahtua", "To happen", "Stát se", "Wydarzyć się"),
                new Phrase("Eräs", "Some", "Nějaký", "Trochę"),
                new Phrase("Vaan", "Only", "Pouze", "Tylko"),
                new Phrase("Mainita", "To mention", "Zmínit", "Wspomnieć"),
                new Phrase("Vaikka", "Even", "Ačkoliv", "Parzysty"),
                new Phrase("Eri", "Different", "Jiný", "Różny"),
                new Phrase("Esittää", "To present", "Přítomen", "Teraźniejszość"),// ?
                new Phrase("Koko", "Whole", "Celý", "Cały"),
                new Phrase("Jumala", "God", "Bůh", "Bóg"),
                new Phrase("Kysymys", "Question", "Otázka", "Pytanie"),
                new Phrase("Käydä", "Visit", "Navštívit", "Odwiedzić"),
                new Phrase("Lapsi", "Kid", "Dítě", "Dziecko"),
                new Phrase("Ennen", "Before", "Před", "Przed"),
                new Phrase("Jäädä", "To stay", "Zůstat", "Zostać"),
                new Phrase("Mieli", "Mind", "Vědomí", "Umysł"),
                new Phrase("Kanssa", "With", "S", "Z"),
                new Phrase("Koska", "Because", "Protože", "Bo"),
                new Phrase("Siellä", "There", "Tam", "Tam"),
                new Phrase("Saattaa", "May", "Smět", "Może"),
                new Phrase("Aina", "Always", "Pokaždé", "Zawsze"),
                new Phrase("Katsoa", "To look", "Dívat se", "Patrzeć"),
                new Phrase("Joutua", "To get", "Dostat", "Dostać"),
                new Phrase("Tietää", "To know", "Vědět", "Wiedzieć"),
                new Phrase("Sillä", "For", "Pro", "Dla"),
                new Phrase("Vanha", "Old", "Starý", "Stary"),
                new Phrase("Silloin", "Then", "Pak", "Potem"),
                new Phrase("Tuntea", "To feel", "Cítit", "Czuć"),
                new Phrase("Nuori", "Young", "Mladý", "Młody"),
                new Phrase("Lähteä", "To leave", "Opustit", "Zostawiać"),
                new Phrase("Päästä", "To get", "Dostat", "Dostać"),
                new Phrase("Puoli", "Half", "Půl", "Pół"),
                new Phrase("Tarvita", "To need", "Potřebovat", "Potrzebować"),
                new Phrase("Juuri", "Just", "Prostě", "Tylko"),
                new Phrase("Kuva", "Picture", "Obrázek", "Obraz"),
                new Phrase("Siinä", "There", "Tam", "Tam"),
                new Phrase("Elämä", "Life", "Život", "Życie"),
                new Phrase("Sana", "Word", "Slovo", "Słowo"),
                new Phrase("Tällainen", "Like", "Líbit", "Lubić"),
                new Phrase("Te", "You", "Vy", "Ty"),
                new Phrase("Todeta", "Note", "Poznamenat", "Notatka"),
                new Phrase("Kerta", "Time", "Pokaždé", "Czas"),
                new Phrase("Kuten", "Like", "Jako", "Jak"),
                new Phrase("Puhua", "To speak", "Mluvit", "Mówić"),
                new Phrase("Määrä", "Amount", "Množství", "Ilość"),
                new Phrase("Usea", "Multiple", "Násobek", "Wielokrotność"),
                new Phrase("Yleinen", "Common", "Společný", "Pospolity"),
                new Phrase("Aivan", "Right", "Správně", "Dobrze"),
                new Phrase("Tehtävä", "Assignment", "Úkol", "Zadanie"),
                new Phrase("Tapaus", "Case", "Případ", "Przypadek"),
                new Phrase("Lisäksi", "Additionally", "Navíc", "Dodatkowo"),
                new Phrase("Missä", "Where", "Kde", "Gdzie"),
                new Phrase("Huomio", "Attention", "Pozor", "Uwaga"),
                new Phrase("Juna", "Train", "Vlak", "Pociąg"),               
                new Phrase("Ratikka", "Tramway", "Tramvaj", "Tramwaj")
                //new Phrase("", "", "", ""),
                //more phrases should be added withoud additional changes
            };

            //extended

            //urban

            return dict;
        }
    }
}
