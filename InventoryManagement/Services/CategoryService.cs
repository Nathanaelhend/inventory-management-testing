using InventoryManagement.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class CategoryService
{
    private readonly HttpClient _http;

    public CategoryService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:3000/");
    }

    public async Task<List<Category>> GetCategories()
    {
        var response = await _http.GetAsync("api/categories");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Category>>(json);
    }

    public async Task AddCategory(Category category)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(category),
            Encoding.UTF8, "application/json"
        );

        var response = await _http.PostAsync("api/categories", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateCategory(int id, string name)
    {
        var body = new { catname = name };
        var content = new StringContent(
            JsonConvert.SerializeObject(body),
            Encoding.UTF8,
            "application/json"
            );

        var response = await _http.PutAsync($"api/categories/{id}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteCategory(int id)
    {
        var response = await _http.DeleteAsync($"api/categories/{id}");
        response.EnsureSuccessStatusCode();
    }
}