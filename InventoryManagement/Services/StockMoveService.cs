using InventoryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

public class StockMoveService
{
    private readonly HttpClient _http;

    public StockMoveService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:3000/");
    }

    public async Task<List<StockMove>> GetStockMove()
    {
        var response = await _http.GetAsync("api/stock-move");
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Get Stock Move failed {(int)response.StatusCode} " +
                $"({response.StatusCode})\n{json}"
            );
        }

        return JsonConvert.DeserializeObject<List<StockMove>>(json)
               ?? new List<StockMove>();
    }

    public async Task CreateStockMove(StockMove request) {
        var content = new StringContent(
            JsonConvert.SerializeObject(request),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PostAsync(
            "api/stock-move",
            content
        );

        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Create Stock Move failed: " +
                $"{(int)response.StatusCode} ({response.StatusCode})\n{json}"
            );
        }
    }
}
