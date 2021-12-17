using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class googleApp
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public float Rating { get; set; }
        public int Reviews { get; set; }
        public string Size { get; set; }
        public string Installs { get; set; }
        public Type Type { get; set; }
        public string Price { get; set; }
        public string ContentRating { get; set; }
        public List<string> Genres { get; set; }
        public  DateTime LastUpdated { get; set; }

        public override string ToString()
        {
            return 
                $"{(Name.Length > 25 ? Name.Substring(0, 25) + "..." : Name),-28} | " +
                $"{Category,-20} | " +
                $"{Rating,-3} | " +
                $"{Reviews,-10} | " +
                $"{Type,-4} | " +
                $"{Price,-7} | " +
                $"{LastUpdated.ToShortDateString(),-10} | " +
                $"{string.Join(",", Genres)}";
        }
    }
    public enum Type
    {
        Free,Paid
    }
    public enum Category
    {
        ART_AND_DESIGN,
        AUTO_AND_VEHICLES,
        BEAUTY,
        BOOKS_AND_REFERENCE,
        BUSINESS,
        COMICS,
        COMMUNICATION,
        DATING,
        EDUCATION,
        ENTERTAINMENT,
        EVENTS,
        FINANCE,
        FOOD_AND_DRINK,
        HEALTH_AND_FITNESS,
        HOUSE_AND_HOME,
        LIBRARIES_AND_DEMO,
        LIFESTYLE,
        GAME,
        FAMILY,
        MEDICAL,
        SOCIAL,
        SHOPPING,
        PHOTOGRAPHY,
        SPORTS,
        TRAVEL_AND_LOCAL,
        TOOLS,
        PERSONALIZATION,
        PRODUCTIVITY,
        PARENTING,
        WEATHER,
        VIDEO_PLAYERS,
        NEWS_AND_MAGAZINES,
        MAPS_AND_NAVIGATION
    }
    
}
