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

namespace ICreate
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
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
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

    }
}