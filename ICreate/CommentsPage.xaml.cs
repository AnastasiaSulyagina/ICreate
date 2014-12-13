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
    public partial class CommentsPage : PhoneApplicationPage
    {
        public CommentsPage()
        {
            InitializeComponent();
        }

        private void commentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCommentButton_Click(object sender, RoutedEventArgs e)
        {

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