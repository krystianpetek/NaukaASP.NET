using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFirstMVCApp.Models
{
    public class FilmyGatunekModel
    {
        public List<Filmy>? Filmy { get; set; }
        public SelectList? Gatunki { get; set; }
        public string? GatunekFilmu { get; set; }
        public string? SearchString { get; set; }
    }
}
