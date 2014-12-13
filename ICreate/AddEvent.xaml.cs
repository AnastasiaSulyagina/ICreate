using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ICreate
{
    public partial class AddEvent : PhoneApplicationPage
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ServerAPI.isAuthorized)
            {
                NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
            }
            else///////
            {//////
                var descr = EventDescription.Text;
                ServerAPI.addEvent(descr);
                NavigationService.GoBack();
            }//////
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private async void TimeButton_Click(object sender, EventArgs e)
        {
            //var dpf = new DatePickerFlyout();
            //await dpf.ShowAtAsync(targetFrameWorkElement);
            //var date = dpf.Date;
        }
    }
}