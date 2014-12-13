
using System;
using System.Collections.Generic;
using System.Device.Location;

public class User
{
    public string UserName { get; set; }
    public int UserId { get; set; }
}

public class Comment
{
    public User user { get; set; }
    public string text { get; set; }
}

public class Event
{
    public User user { get; set; }
    public int id { get; set; }
    public GeoCoordinate coordinate { get; set; }
    public string description { get; set; }
    public string MySquareDescriprion { get; set; }
    public int category { get; set; }
    public DateTime time { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public List<Comment> comments { get; set; }

    public Event(DateTime time, double latitude, double longitude, String description, int category)
    {
        id = 0;
        MySquareDescriprion = "";
        for (int i = 0; i < description.Length; ++i)
        {
            MySquareDescriprion += description[i];
            if (((i % 20) == 0) && (i > 0))
            {
                MySquareDescriprion += '\n';
            }
            if (i == 100)
            {
                break;
            }
        }

        this.time = time;
        this.latitude = latitude;
        this.longitude = longitude;
        this.coordinate = new GeoCoordinate(latitude, longitude);
        this.description = description;
        this.category = category;
    }
}