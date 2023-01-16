using BlazorNorthwindUI.Models;

using System.Threading.Tasks;

namespace BlazorNorthwindUI.Services
{
    public interface ICategoryService
    {
        Task<CategoryListViewModel[]> GetCategories();
    }
}
