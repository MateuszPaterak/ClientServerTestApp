using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;
using PluginInterface;
using WebService.Models;
using WpfClient.ViewModels;
using Action = System.Action;

namespace WpfClient.Models
{
    public static class ServiceAgent
    {
        private static HttpClient _client = new HttpClient();
        private static string _baseAddressUri = "http://localhost:57857/";
        static ServiceAgent()
        {
            _client.BaseAddress = new Uri(_baseAddressUri);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<bool> AddUserAsync(User user)
        {
            var response = await _client.PostAsJsonAsync("api/AddUser", user);
            return response.IsSuccessStatusCode;
        }
    }
}
