using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _100words
{
    public sealed partial class MainPage : Page
    {
        List<Phrase> vocabulary;
        private static Random rng = new Random();                

        public MainPage()
        {
            this.InitializeComponent();
            vocabulary = Dictionary.getListOfWords();

            wFI.Text = vocabulary.First().wordFI;
            wEN.Text = vocabulary.First().wordEN;
            wCZ.Text = vocabulary.First().wordCZ;            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vocabulary = Shuffle(vocabulary); //mix it
            wFI.Text = vocabulary.First().wordFI;
            wEN.Text = vocabulary.First().wordEN;
            wCZ.Text = vocabulary.First().wordCZ;
        }
        
        public List<Phrase> Shuffle<Phrase>(List<Phrase> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Phrase value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }            
    }
}
