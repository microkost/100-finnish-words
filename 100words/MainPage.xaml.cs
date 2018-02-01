using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _100words
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Phrase> vocabulary;
        private static Random rng = new Random();

        public MainPage()
        {
            this.InitializeComponent();

            vocabulary = Dictionary.getListOfWords();            
            textMain.Text = vocabulary.First().wordFI;
            textLang1.Text = vocabulary.First().wordEN;
            textLang2.Text = vocabulary.First().wordCZ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vocabulary = Shuffle(vocabulary); //mix it
            textMain.Text = vocabulary.First().wordFI;
            textLang1.Text = vocabulary.First().wordEN;
            textLang2.Text = vocabulary.First().wordCZ;
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

        private async void SaveToXML()
        {
            /*
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("XXX.xml");
            using (IRandomAccessStream writeStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                System.IO.Stream s = writeStream.AsStreamForWrite();
                System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                settings.Async = true;
                using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(s, settings))
                {
                    writer.WriteStartElement("Order");
                    writer.WriteElementString("OrderID", "y1");
                    writer.WriteElementString("OrderTotal", "y2");
                    writer.WriteElementString("Customer", "y3");
                    writer.WriteElementString("Phone", "y4");
                    writer.Flush();
                    await writer.FlushAsync();
                }
            }
            */            
            return;
        }

    }
}
