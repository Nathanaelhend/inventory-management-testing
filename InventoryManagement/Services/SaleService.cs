using InventoryManagement.models;
using InventoryManagement.Models;
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
        _http.BaseAddress = new Uri("https://uptight-amendment-ocean.ngrok-free.dev/");
    }

    public async Task<List<Sale>> GetSale()
    {
        var response = await _http.GetAsync("api/sales");
        var json = await response.Content.ReadAsStringAsync();
        System.Diagnostics.Debug.WriteLine($"GetSale API response: {json}");

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to get sales: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }

        var sales = JsonConvert.DeserializeObject<List<Sale>>(json) ?? new List<Sale>();

        var deduped = sales
            .GroupBy(s => (s.noOrder ?? string.Empty).Trim(), StringComparer.OrdinalIgnoreCase)
            .Select(g => g.OrderByDescending(x => x.total).First())
            .ToList();

        System.Diagnostics.Debug.WriteLine($"GetSale: {sales.Count} deduped sales count: {deduped.Count}");

        return deduped;
    }

    public async Task<SaleDetailResponse> GetSaleById(string noOrder)
    {
        var url = $"api/sales/{Uri.EscapeDataString(noOrder)}";
        var response = await _http.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to get sale by ID: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }

        return JsonConvert.DeserializeObject<SaleDetailResponse>(json);
    }

    public async Task CreateSale(string noOrder, Sale sale)
    {
        await UpdateSale(noOrder, sale);
    }

    public async Task AddLine(string noOrder, SaleLineRequest line)
    {
        if(string.IsNullOrWhiteSpace(noOrder))
        {
            throw new Exception("noOrder cannot be null or whitespace when adding a line.");
        }

        var content = new StringContent(JsonConvert.SerializeObject(line), Encoding.UTF8, "application/json");

        var response = await _http.PostAsync($"api/sales/{noOrder}/lines", content);

        if(!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to add line to sale {noOrder}: {(int)response.StatusCode} ({response.StatusCode})\n{err}");
        }
    }

    public async Task DeleteLine(string noOrder, string pcode)
    {
        var response = await _http.DeleteAsync($"api/sales/{noOrder}/lines/{pcode}");
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateLine(string noOrder, string pcode, SaleLineRequest line)
    {
        var content = new StringContent(JsonConvert.SerializeObject(line), Encoding.UTF8, "application/json");

        var response = await _http.PutAsync($"api/sales/{noOrder}/lines/{pcode}", content);

        if(!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to update line {pcode} in sale {noOrder}: {(int)response.StatusCode} ({response.StatusCode})\n{err}");
        }
    }

    public async Task UpdateSale(string noOrder, Sale sale)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(sale), Encoding.UTF8, "application/json");

        var response = await _http.PutAsync($"api/sales/{Uri.EscapeDataString(noOrder)}", content);
        var body = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to update sale {noOrder}: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }

    public async Task DeleteSale(string noOrder)
    {
        var response = await _http.DeleteAsync($"api/sales/{Uri.EscapeUriString(noOrder)}");
        var body = await response.
            Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception($"Delete failed: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }

    public async Task CancelSale(string noOrder)
    {
        var response = await _http.PutAsync($"api/sales/{Uri.EscapeDataString(noOrder)}/cancel", null);
        var body = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Cancel failed: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }
}
