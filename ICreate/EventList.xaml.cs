using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

namespace ICreate
{
    public partial class EventList : PhoneApplicationPage
    {
        public EventList()
        {
            InitializeComponent();
            //---pullToRefresh
            var objWP8PullDetector = new WP8PullDetector();
            objWP8PullDetector.Bind(eventList);
            //objWP8PullDetector.Unbind(); To unbind from compression detection
            objWP8PullDetector.Compression += objWP8PullDetector_Compression;
            //---
            eventList.DataContext = this;
            update();
        }

        void objWP8PullDetector_Compression(object sender, CompressionEventArgs e)
        {
            update();
        }

        public static List<Event> Events;
        public static Event currentEvent;

        private async Task<int> loop (CancellationToken ct)
        {
            
            
                await Task.Delay(1000);
                return 1;
        }
        private async void update()
        {
            var cts = new CancellationTokenSource();
            this.updateProgressBar.IsIndeterminate = true;
            string result = await ServerAPI.getEvents();
            Events = JsonConvert.DeserializeObject<List<Event>>(result);
            eventList.ItemsSource = Events;
            await loop(cts.Token);
            this.updateProgressBar.IsIndeterminate = false;
            cts.Cancel();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void SearchButton_Click(object sender, EventArgs e)
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


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            update();
        }

        private void eventList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EventPage.currentEvent = (Event)(eventList.SelectedItem);
            NavigationService.Navigate(new Uri("/EventPage.xaml", UriKind.Relative));
        }
    }
}