﻿using BlazorNorthwindUI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorNorthwindUI.Services
{
    public interface IProductService
    {
        Task<ProductListViewModel[]> GetProducts();
        Task Add(ProductViewModel productListViewModel);
        Task Save(ProductViewModel productListViewModel);
        Task<ProductViewModel> GetProductById(int productId);
    }
}
