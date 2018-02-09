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
        List<String> languages; //names of available languages, index numbers are keys
        List<Phrase> vocabulary; //globally used vocabulary
        DispatcherTimer dispatcherTimer; //refresh values event countdown
        private static Random rng = new Random();
        
        //permanent settings in computer
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;              

        public MainPage()
        {
            languages = Dictionary.GetListOfLanguages(); //name of used languages
            vocabulary = Dictionary.GetListOfWords(); //full dictionary

            this.InitializeComponent();           
            RefreshVocabulary(); //shuffle & show

            //automatic timebased refresh of dictionary            
            if (Double.TryParse((string)localSettings.Values["100wordsRefreshTime"], out double timerValue))
            {
                DispatcherTimerSetup(TimeSpan.FromHours(timerValue)); //(hh:mm:ss)
                UpdateTime.Text = timerValue.ToString();
            }
            else //failure
            {
                int value = 120;
                DispatcherTimerSetup(new TimeSpan(0, value, 0)); //set time default when not saved (hh:mm:ss)
                UpdateTime.Text = value.ToString();
            }

            //should do notification when change
            //should be visible on lockscreen

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

        public void MakePhraseVisible(Phrase phrase) //+ List<int> selectedIndexes
        {
            string lang0 = phrase.wordFI;
            string lang1 = phrase.wordEN;
            string lang2 = phrase.wordCZ;

            wFI.Text = lang0;
            //set appropriate flah
            wEN.Text = lang1;
            //set appropriate flah
            wCZ.Text = lang2;
            //set appropriate flah

            var notification = new TileNotification(GetNotificationScheme(lang0, lang1, lang2).GetXml());
            //notification.ExpirationTime = DateTimeOffset.UtcNow.AddMinutes(1); //how long from active to just logo
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);

            return;
        }

        private void ButtonShuffle_Click(object sender, RoutedEventArgs e)
        {
            RefreshVocabulary(); //called from gui
        }        

        private void ButtonSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            //time change
            dispatcherTimer.Stop();
            if (Double.TryParse(UpdateTime.Text, out double timerValue))
            {
                DispatcherTimerSetup(TimeSpan.FromMinutes(timerValue));
                localSettings.Values["100wordsRefreshTime"] = timerValue.ToString();                
            }
            else //failure
            {
                int value = 120;
                DispatcherTimerSetup(new TimeSpan(0, value, 0)); //set time default (hh:mm:ss)
                UpdateTime.Text = value.ToString();
            }            
            dispatcherTimer.Start();

            //lang selection
            List<String> langOrder = new List<String>();
            langOrder.Add(Language1.SelectedItem.ToString());
            langOrder.Add(Language2.SelectedItem.ToString());
            langOrder.Add(Language3.SelectedItem.ToString());
            langOrder.Add(Language4.SelectedItem.ToString());
            //process that list

            MenuSettingsChangeVisibility(); //close menu

            return;
        }
        private void ButtonTile_Click(object sender, RoutedEventArgs e)
        {
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
        public void DispatcherTimerSetup(TimeSpan ts)
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_TimeElapsedEvent;
            dispatcherTimer.Interval = ts;
            dispatcherTimer.Start();
        }

        void DispatcherTimer_TimeElapsedEvent(object sender, object e) //countdown event method
        {
            dispatcherTimer.Stop();
            RefreshVocabulary(); //reoder vocabulary and show it again
            dispatcherTimer.Start();
        }

        private void MenuSettingsChangeVisibility() //used for opening menu view
        {
            //https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/split-view

            if (SettingsView.IsPaneOpen)
            {
                SettingsView.IsPaneOpen = false;
            }
            else
            {
                SettingsView.IsPaneOpen = true;
            }
        }

        internal TileContent GetNotificationScheme(string word0, string word1, string word2) //creating tile "XML" file
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
