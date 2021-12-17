using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace LINQ
{
    internal class googleAppMap : ClassMap<googleApp>
    {
        public googleAppMap()
        {
            Map(m => m.Name).Name(nameof(googleApp.Name));
            Map(m => m.Category).Name(nameof(googleApp.Category));
            Map(m => m.Rating).Name(nameof(googleApp.Rating));
            Map(m => m.Reviews).Name(nameof(googleApp.Reviews));
            Map(m => m.Size).Name(nameof(googleApp.Size));
            Map(m => m.Installs).Name(nameof(googleApp.Installs));
            Map(m => m.Type).Name(nameof(googleApp.Type));
            Map(m => m.Price).Name(nameof(googleApp.Price));
            Map(m => m.Name).Name(nameof(googleApp.Name));
            Map(m => m.ContentRating).Name(nameof(googleApp.ContentRating));
            Map(m => m.LastUpdated).Name(nameof(googleApp.LastUpdated));
            Map(m => m.Genres).Convert(ConvertGenres);
        }
        private List<string> ConvertGenres(ConvertFromStringArgs args)
        {
            var genreString = args.Row.GetField("Genres");
            return genreString.Split(";").ToList();
        }

    }
}