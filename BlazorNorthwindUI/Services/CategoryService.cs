using BlazorNorthwindUI.Models;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorNorthwindUI.Services
{

    public class CategoryService : ICategoryService
    {
        private HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<CategoryListViewModel[]> GetCategories()
        {
            return _httpClient.GetFromJsonAsync<CategoryListViewModel[]>("https://localhost:44326/api/category/getall");
        }
    }
}
