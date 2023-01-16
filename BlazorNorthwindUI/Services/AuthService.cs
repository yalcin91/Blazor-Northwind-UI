using Blazor.Extensions.Storage;

using Blazored.LocalStorage;

using BlazorNorthwindUI.Models;

using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace BlazorNorthwindUI.Services
{
    public class AuthService:IAuthService
    {
        private HttpClient _httpClient;
        private LocalStorage _localStorage; // Werkt niet zo goed!
        private ISyncLocalStorageService _localStorageService;
        public bool IsLoggedIn { get; private set; }

        public AuthService(HttpClient httpClient, LocalStorage localStorage, ISyncLocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _localStorageService = localStorageService;
        }

        public async Task<LoginModel> Login(LoginModel loginModel)
        {

            var response = await _httpClient.PostAsJsonAsync("https://localhost:44326/api/auth/login", loginModel);

            var result = await response.Content.ReadFromJsonAsync<LoginModel>();
            //var resultToken = JsonConvert.DeserializeObject(response.ToString().);
            if (!String.IsNullOrEmpty(response.ToString()))
            {
                _localStorageService.SetItem("token", result.Token);
                 SetAuthorizationHeader();
                IsLoggedIn = true;
            }
            return result;
        }

        public  void Logout()
        {
            _localStorageService.RemoveItem("token");
            IsLoggedIn = false;
        }

        private void  SetAuthorizationHeader()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token =  _localStorageService.GetItem<string>("token");
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);    
            }
        }
    }
}
