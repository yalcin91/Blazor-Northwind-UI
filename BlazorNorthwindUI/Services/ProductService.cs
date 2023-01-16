using BlazorNorthwindUI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorNorthwindUI.Services
{
    public class ProductService : IProductService
    {
        private HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }

        public async Task Add(ProductViewModel productViewModel)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:44326/api/products/add", productViewModel);
        }

        public Task<ProductViewModel> GetProductById(int productId)
        {
            return _httpClient.GetFromJsonAsync<ProductViewModel>("https://localhost:44326/api/products/getbyid?productid="+productId);
        }

        public Task<ProductListViewModel[]> GetProducts()
        {
            return _httpClient.GetFromJsonAsync<ProductListViewModel[]>("https://localhost:44326/api/products/getall");
        }

        public async Task Save(ProductViewModel productViewModel)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:44326/api/products/update", productViewModel);
        }
    }
}
