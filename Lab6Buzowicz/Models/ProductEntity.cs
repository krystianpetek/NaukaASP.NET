using Microsoft.AspNetCore.Identity;

namespace Lab5Buzowicz.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public IdentityUser Owner { get; set; }
    }
}
