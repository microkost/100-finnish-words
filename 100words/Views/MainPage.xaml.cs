using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; //tile design library

namespace words100
{
    public sealed partial class MainPage : Page
    {
        List<Phrase> vocabulary; //globally used vocabulary
        DispatcherTimer dispatcherTimer; //refresh values event
        private static Random rng = new Random();
        
        //static settings in computer
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            
        public MainPage()
        {
            this.InitializeComponent();

            vocabulary = Dictionary.GetListOfWords();
            RefreshVocabulary();

            var refreshTimeFromSettings = localSettings.Values["100wordsRefreshTime"];
            if (refreshTimeFromSettings == null)
            {
                //= 10; //set time default
            }
            else
            {
                //timer is x = refreshTimeFromSettings;
            }

            //dispatcherTimer uwp call method every hour
            DispatcherTimerSetup();


            //uwp settings menu : timer value, language order, reminder of live tile
            //change timer
            //localSettings.Values["100wordsRefreshTime"] = 1;

        }
        internal void RefreshVocabulary()
        {
            vocabulary = Shuffle(vocabulary); //mix it
            if (vocabulary.Count == 0) //last word is removed
            {
                vocabulary = Dictionary.GetListOfWords(); //get new words
                vocabulary = Shuffle(vocabulary); //randomize first one
            }
            MakePhraseVisible(vocabulary.First()); //show it            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshVocabulary(); //called from gui
        }

        public void MakePhraseVisible(Phrase phrase)
        {
            string lang0 = phrase.wordFI;
            string lang1 = phrase.wordEN;
            string lang2 = phrase.wordCZ;

            wFI.Text = lang0;
            wEN.Text = lang1;
            wCZ.Text = lang2;

            var notification = new TileNotification(GetNotificationScheme(lang0, lang1, lang2).GetXml());
            //notification.ExpirationTime = DateTimeOffset.UtcNow.AddMinutes(1); //how long from active to just logo
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);

            return;
        }

        public List<Phrase> Shuffle<Phrase>(List<Phrase> list) //mixing available dictionary to show first element
        {
            try
            {
                list.RemoveAt(0); //remove already showed word
            }
            catch
            {
                return null; //when last word was removed
            }

            int n = list.Count;
            while (n > 1) //doing mixing
            {
                n--;
                int k = rng.Next(n + 1);
                Phrase value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_TimeElapsedEvent;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(10);
            //dispatcherTimer.Interval = new TimeSpan(0, 1, 0); //represents three hours and thirty minutes new TimeSpan(3, 30, 0);
            dispatcherTimer.Start(); //IsEnabled should now be true after calling start
        }
        void DispatcherTimer_TimeElapsedEvent(object sender, object e) //countdown event method
        {
            dispatcherTimer.Stop();
            RefreshVocabulary(); //reoder vocabulary and show it again
            dispatcherTimer.Start();
        }

        internal TileContent GetNotificationScheme(string word0, string word1, string word2)
        {
            //https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/create-adaptive-tiles

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    DisplayName = "100 finnish words",
                    Branding = TileBranding.NameAndLogo, //text should be name of dictionary

                    //TileLarge (only for desktop)
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = word0,
                                    HintStyle = AdaptiveTextStyle.HeaderNumeral, //super size
                                    HintWrap = true
                                },

                                new AdaptiveText()
                                {
                                    Text = word1,
                                    HintStyle = AdaptiveTextStyle.TitleSubtle, //big
                                    HintWrap = true
                                },

                                new AdaptiveText()
                                {
                                    Text = word2,
                                    HintStyle = AdaptiveTextStyle.TitleSubtle, //big
                                    HintWrap = true
                                },
                            }
                        }
                    },

                    //TileWide
                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = word0,
                                    HintStyle = AdaptiveTextStyle.HeaderNumeral //extra size
                                },

                                new AdaptiveText()
                                {
                                    Text = String.Format("{0} / {1}", word1, word2),
                                    HintStyle = AdaptiveTextStyle.BodySubtle, //two words on same line, medium
                                    HintWrap = true
                                },
                            }
                        }
                    },

                    //TileMedium
                    TileMedium = new TileBinding()
                    {
                        Branding = TileBranding.Logo,
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = word0,
                                    HintStyle = AdaptiveTextStyle.TitleNumeral //big size
                                },

                                new AdaptiveText()
                                {
                                    Text = word1,
                                    HintStyle = AdaptiveTextStyle.Caption //small bold
                                },

                                new AdaptiveText()
                                {
                                    Text = word2,
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle //small
                                }
                            }
                        }
                    },

                    //TileSmall - not used, cannot effectively show something
                }
            };
            return content;
        }
    }
}
