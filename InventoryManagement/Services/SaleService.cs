using InventoryManagement.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class SaleService
{
    private readonly HttpClient _http;

    public SaleService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:3000/");
    }

    public async Task<List<Sale>> GetSale()
    {
        var response = await _http.GetAsync("api/sales");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Sale>>(json);
    }

    public async Task AddSale(Sale sale)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(sale),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PostAsync("api/sales", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateSale(string noOrder, Sale sale)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(sale),
            Encoding.UTF8,
            "application/json"
        );
        var response = await _http.PutAsync($"api/sales/{noOrder}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteSale(string noOrder)
    {
        var response = await _http.DeleteAsync($"api/sales/{noOrder}");
        response.EnsureSuccessStatusCode();
    }
}
