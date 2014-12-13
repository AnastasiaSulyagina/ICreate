using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ICreate
{
    public partial class EventPage : PhoneApplicationPage
    {
        public static Event currentEvent;
        public EventPage()
        {
            InitializeComponent();
            descriptionBlock.Text = currentEvent.description;
            userNameBlock.Text = currentEvent.user.UserName;
        }
        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }
    }
}