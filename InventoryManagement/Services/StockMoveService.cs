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
        _http.BaseAddress = new Uri("https://uptight-amendment-ocean.ngrok-free.dev/");
    }

    public async Task<String> GenerateNumber()
    {
        var response = await _http.GetAsync("api/stock-move/number-movein");
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to generate stock move number: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }
        var result = JsonConvert.DeserializeObject<dynamic>(json);
        return result?.name?.ToString() ?? string.Empty;
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

        var result = JsonConvert.DeserializeObject<StockMoveResponse>(json);
        return result?.data ?? new List<StockMove>();
    }

    public async Task<StockMove> GetStockMoveByName(string name)
    {
        var url = $"api/stock-move/{Uri.EscapeDataString(name)}";
        var response = await _http.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();

        if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to get stock move by name: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }

        var detail = JsonConvert.DeserializeObject<StockMoveDetailResponse>(json);

        if (detail?.header == null) return null;

        var sm = detail.header;
        sm.lines = detail.lines ?? new List<StockMoveLine>();
        return sm;
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

    public async Task UpdateReceipt(string name, StockMoveDetailResponse sm)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(sm), Encoding.UTF8, "application/json");

        var response = await _http.PutAsync($"api/stock-move/{Uri.EscapeDataString(name)}", content);
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to update receipt {name}: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }

    public async Task ConfirmReceipt(string name, StockMoveDetailResponse sm)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(sm), Encoding.UTF8, "application/json");
        var response = await _http.PutAsync($"api/stock-move/{Uri.EscapeDataString(name)}/confirm", content);
        var body = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to confirm receipt {name}: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }
}
