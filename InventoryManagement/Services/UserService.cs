using InventoryManagement.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class UserService
{
    private readonly HttpClient _http;
    public UserService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:3000/");
    }
    public async Task<List<User>> GetUsers()
    {
        var response = await _http.GetAsync("api/users");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<User>>(json);
    }
    public async Task AddUser(User user)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(user),
            Encoding.UTF8,
            "application/json"
        );
        var response = await _http.PostAsync("api/users", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateUser(string id, User user)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(user),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PutAsync($"api/users/{id}", content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
    }

    public async Task DeleteUser(int id)
    {
        var response = await _http.DeleteAsync($"api/users/{id}");
        response.EnsureSuccessStatusCode();
    }
}