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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ICreate
{
    public partial class Login : PhoneApplicationPage
    {
        public Login()
        {
            InitializeComponent();
            LoginBox.Text = "login";
            PasswordBox.Password = "password";
            PasswordBox.GotFocus += RemovePassword;
            PasswordBox.LostFocus += AddPassword;
            LoginBox.GotFocus += RemoveText;
            LoginBox.LostFocus += AddText;
        }

        public void RemovePassword(object sender, EventArgs e)
        {
            PasswordBox.Password = "";
        }

        public void AddPassword(object sender, EventArgs e)
        {
            if (PasswordBox.Password == "")
                PasswordBox.Password = "password";
        }

        public void RemoveText(object sender, EventArgs e)
        {
             LoginBox.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
             if(LoginBox.Text == "")
                 LoginBox.Text = "login";
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }

        private async void logIn()
        { 
            await ServerAPI.logIn(LoginBox.Text, PasswordBox.Password);
            NavigationService.GoBack();
            //NavigationService.Navigate(new Uri("/AddEvent.xaml", UriKind.Relative));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            logIn();
        }

        private async void register()
        {
            await ServerAPI.register(LoginBox.Text, PasswordBox.Password, PasswordBox.Password);
            NavigationService.GoBack();
            //NavigationService.Navigate(new Uri("/AddEvent.xaml", UriKind.Relative));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            register();
        }

        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void ToMapButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}