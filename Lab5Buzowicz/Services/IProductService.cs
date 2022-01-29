using System.Collections.Generic;
using System.Threading.Tasks;
using Lab5Buzowicz.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5Buzowicz.Services
{
    public interface IProductService
    {
        Task Add(ProductModel product);
        ProductEntity Index(int? id);
        List<ProductEntity> List();
    }
}
