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
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System.Device.Location;

public static partial class ServerAPI
{
    public static string token = "";
    public static bool isAuthorized = false;
    public static GeoCoordinate coordinate = new GeoCoordinate(59.875585, 29.825813);

    public static string LogInUrl = "Token";
    public static string RegisterUrl = "api/Account/Register";
    public static string GetEventsUrl = "api/Events";
    public static string AddEventUrl = "api/Events";
    public static string AddCommentUrl = "api/eventComments";
    public static string SubscribeUrl = "api/Friends/Follow";
    //http://customer87-001-site1.myasp.net/";
    //public static string SiteUrl = "http://nbixman-001-site1.myasp.net/";
    public static string SiteUrl = "http://hackaton1-001-site1.myasp.net/";


    public static async Task<bool> logIn(string login, string password)
    {
        var client = new HttpClient();
        var data = "grant_type=password&username=" + login + "&password=" + password;
        var content = new StringContent(data.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");
        try
        {
            var result = await client.PostAsync(SiteUrl + LogInUrl, content);
            string message = result.ReasonPhrase;
            var responseString = await result.Content.ReadAsStringAsync();
            JObject jsonObj = JObject.Parse(responseString);
            token = jsonObj["access_token"].Value<string>();
            isAuthorized = true;
        }

        catch (WebException we)
        {
            token = we.Message;
            isAuthorized = false;
            return false;
        }
        return true;
    }

    public static async Task<bool> register(string login, string password, string confirm)
    {
        var client = new HttpClient();
        var data = JsonConvert.SerializeObject(new
        {
            UserName = login,
            Password = password,
            ConfirmPassword = confirm
        });
        var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
        try
        {
            var result = await client.PostAsync(SiteUrl + RegisterUrl, content);
            var responseString = await result.Content.ReadAsStringAsync();
            await logIn(login, password);
        }
        catch (WebException we)
        {
            token = we.Message;
            isAuthorized = false;
        }
        return true;
    }

    public static async void addEvent(string description)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        try
        {
            var data = JsonConvert.SerializeObject(new
            {
                Latitude = coordinate.Latitude.ToString().Replace(",","."),
                Longitude = coordinate.Longitude.ToString().Replace(",", "."),
                Description = description,
                EventDate = "05.10.2014 21:44:36" 
            });

            var content = new StringContent(data, Encoding.UTF8, "application/json");
            string ss = data.ToString();
            var result = await client.PostAsync(SiteUrl + AddEventUrl, content);
            string message = result.ReasonPhrase;
            string s = await content.ReadAsStringAsync();
             

        }
        catch (Exception exc)
        {
            string message = exc.ToString();
        }

    }

    public static async Task<string> getEvents()
    {
        var client = new HttpClient();
        var result = await client.GetStringAsync(SiteUrl + GetEventsUrl);
        return result;
    }

    
}