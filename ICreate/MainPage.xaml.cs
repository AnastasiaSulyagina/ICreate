using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ICreate.Resources;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Media;
using System.Device.Location;
using System.Windows.Input;
using Microsoft.Phone.Maps.Toolkit;
using Windows.Data.Json;
using System.Collections.ObjectModel;

namespace ICreate
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        int tapFlag = 0;
        public MainPage()
        {
            InitializeComponent();

        }

       
        private void Pushpin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            bool anotherFlag = false;
            if (tapFlag != 0)
            {
                ObservableCollection<DependencyObject> children = MapExtensions.GetChildren(map);

                foreach (DependencyObject obj in children)
                {
                    Pushpin pin;
                    try
                    {
                        pin = (Pushpin)obj;
                    }
                    catch (Exception )
                    {
                        continue;
                    }
                    if (pin.Content == null)
                    {
                        pin.Content = "";
                    }
                    if (pin != null)
                    {
                        string s = pin.Content as String;
                        string s2 = ((Pushpin)sender).Content as String;
                        if (s == s2 && s2 != "")
                        {
                            EventPage.currentEvent = (Event)pin.Tag;
                            anotherFlag = true;
                            tapFlag = 1;
                            NavigationService.Navigate(new Uri("/EventPage.xaml", UriKind.Relative));
                        }
                        else
                        {
                            pin.Content = "";
                        }
                    }
                }
                if (tapFlag != 1)
                    tapFlag = 0;
            }
            //((Pushpin)sender).Content = (((Pushpin)sender).Tag as Event).description;
            if (!anotherFlag)
            {
                map.SetView(((Pushpin)sender).GeoCoordinate, map.ZoomLevel, 0.0, 0.0);
                ((Pushpin)sender).Content = (((Pushpin)sender).Tag as Event).MySquareDescriprion;
                tapFlag = 1;
            }
            //pin.Content = (pin.Tag as Event).description;
            // MessageBox.Show((pin.Tag as Event).description);
        }


        private async void update()
        {
            string result = await ServerAPI.getEvents();
            List<Event> Events = JsonConvert.DeserializeObject<List<Event>>(result);
            foreach (Event i in Events)
            {
                //Pushpin pin = new Pushpin();
                //pin.Tap += PushpinTap;
                ObservableCollection<DependencyObject> children = MapExtensions.GetChildren(map);
                Pushpin pin = new Pushpin()
                {
                    Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xC0, 0x39, 0x2B)),
                    GeoCoordinate = new GeoCoordinate(i.latitude, i.longitude),
                    Tag = i,
                    Content = "",
                };
                pin.Tap += Pushpin_Tap;
                children.Add(pin);

            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddEvent.xaml", UriKind.Relative));
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
        }

        private void ToListButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EventList.xaml", UriKind.Relative));
        }

        private void Map_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "e1de1865-d095-4a72-a985-9e33520aa3ea";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "hHyrNfIWmRCD8m6rGJErqw";
            map.SetView(ServerAPI.coordinate, 3.0, 0.0, 0.0);
            update();

        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private void Map_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Point pt = e.GetPosition(map);
            ServerAPI.coordinate = map.ConvertViewportPointToGeoCoordinate(pt);
            
            // The pushpin to add to the map.
           /* Pushpin pin = new Pushpin();
            pin.GeoCoordinate = ServerAPI.coordinate;
            pin.Background = new SolidColorBrush(Color.FromArgb(0xFF,0xC0,0x39,0x2B));
            
            var mapOverlay = new MapOverlay();
            mapOverlay.Content = pin;
            mapOverlay.GeoCoordinate = ServerAPI.coordinate;
            var mapLayer = new MapLayer();
            mapLayer.Add(mapOverlay);
            map.Layers.Add(mapLayer); */
            NavigationService.Navigate(new Uri("/AddEvent.xaml", UriKind.Relative));
           
        }

        private void Map_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tapFlag == 1)
            {
                tapFlag = 2;
                return;
            }

            ObservableCollection<DependencyObject> children = MapExtensions.GetChildren(map);

            foreach (DependencyObject obj in children)
            {
                Pushpin pin;
                try
                {
                    pin = (Pushpin)obj;
                }
                catch (Exception eeee)
                {
                    continue;
                }
                if (pin.Content == null)
                {
                    pin.Content = "";
                }
                if (pin != null)
                {
                    string s = pin.Content as String;
                    if (s != "")
                    {
                        pin.Content = "";
                    }
                }
            }
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            update();
        }

    }
}