using InventoryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PurchaseService
{
    private readonly HttpClient _http;

    public PurchaseService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:3000/");
    }

    public async Task<String> GenerateNumber()
    {
        var response = await _http.GetAsync("api/purchases/number-po");
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to generate purchase number: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }
        var result = JsonConvert.DeserializeObject<dynamic>(json);
        return result?.noOrder?.ToString() ?? string.Empty;
    }

    public async Task<List<Purchase>> GetPurchase()
    {
        var response = await _http.GetAsync("api/purchases");
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"GetPurchase failed: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }

        var result = JsonConvert.DeserializeObject<PurchaseResponse>(json);
        return result?.data ?? new List<Purchase>();
    }

    public async Task<Purchase> GetPurchaseById(string noOrder)
    {
        var url = $"api/purchases/{Uri.EscapeDataString(noOrder)}";
        var response = await _http.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"GET {url} failed: {response.StatusCode}\n{json}");
        }

        var detail = JsonConvert.DeserializeObject<PurchaseDetailResponse>(json);

        if (detail?.header == null) return null;

        var purchase = detail.header;
        purchase.lines = detail.lines ?? new List<PurchaseLine>();

        return purchase;
    }

    public async Task CreatePurchase(string noOrder, Purchase purchase)
    {
        await UpdatePurchase(noOrder, purchase);
    }

    public async Task AddLine(string orderNo, PurchaseLineRequest detail)
    {
        if (string.IsNullOrWhiteSpace(orderNo))
        {
            throw new Exception("Order number cannot be empty!");
        }

        var content = new StringContent(
            JsonConvert.SerializeObject(detail),
            Encoding.UTF8,
            "application/json"
        );

        var url = $"api/purchases/{Uri.EscapeDataString(orderNo)}/lines";
        var response = await _http.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to add purchase line for order {orderNo}:\n{err}");
        }
    }

    public async Task DeleteLine(string orderNo, string prCode)
    {
        var url = $"api/purchases/{Uri.EscapeDataString(orderNo)}/lines/{Uri.EscapeDataString(prCode)}";
        var response = await _http.DeleteAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to delete line: {err}");
        }
    }

    public async Task UpdateLine(string orderNo, string prCode, PurchaseLineRequest detail)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(detail),
            Encoding.UTF8,
            "application/json"
        );

        var url = $"api/purchases/{Uri.EscapeDataString(orderNo)}/lines/{Uri.EscapeDataString(prCode)}";
        var response = await _http.PutAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to update purchase line: {err}");
        }
    }

    public async Task UpdatePurchase(string noOrder, Purchase purchase)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(purchase),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PutAsync($"api/purchases/{Uri.EscapeDataString(noOrder)}", content);
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }

    public async Task ConfirmPurchase(string noOrder, Purchase purchase)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(purchase),
            Encoding.UTF8,
            "application/json"
        );
        var response = await _http.PutAsync($"api/purchases/{Uri.EscapeDataString(noOrder)}/confirm", content);
        var body = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Confirm failed: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }

    public async Task DeletePurchase(string noOrder)
    {
        var response = await _http.DeleteAsync($"api/purchases/{Uri.EscapeDataString(noOrder)}");
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Delete failed: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }

    public async Task CancelPurchase(string noOrder)
    {
        var response = await _http.PutAsync($"api/purchases/{Uri.EscapeDataString(noOrder)}/cancel", null);
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Cancel failed: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }
}