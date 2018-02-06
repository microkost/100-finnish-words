using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library

namespace words100
{
    public sealed partial class MainPage : Page
    {
        List<Phrase> vocabulary;
        private static Random rng = new Random();        

        public MainPage()
        {
            this.InitializeComponent();
            vocabulary = Dictionary.getListOfWords(); 
            makePhraseVisible(vocabulary.First()); //show it                                  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vocabulary = Shuffle(vocabulary); //mix it
            makePhraseVisible(vocabulary.First()); //show it
        }

        public void makePhraseVisible(Phrase phrase)
        {
            string lang0 = phrase.wordFI;
            string lang1 = phrase.wordEN;
            string lang2 = phrase.wordCZ;

            wFI.Text = lang0;
            wEN.Text = lang1;
            wCZ.Text = lang2;

            var notification = new TileNotification(getNotificationScheme(lang0, lang1, lang2).GetXml());
            //notification.ExpirationTime = DateTimeOffset.UtcNow.AddMinutes(10);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
            return;
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

        internal TileContent getNotificationScheme(string word0, string word1, string word2)
        {
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = word0
                    },

                    new AdaptiveText()
                    {
                        Text = word1,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = word2,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = word0,
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },

                    new AdaptiveText()
                    {
                        Text = word1,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = word2,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
                        }
                    }
                }
            };
            return content;
        }
    }
}
