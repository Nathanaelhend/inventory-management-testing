using InventoryManagement.models;
using InventoryManagement.Models;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class PurchaseService
{
    private readonly HttpClient _http;

    public PurchaseService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:3000/");
    }

    public async Task<List<Purchase>> GetPurchase()
    {
        var response = await _http.GetAsync("api/purchases");
        var json = await response.Content.ReadAsStringAsync();
        System.Diagnostics.Debug.WriteLine($"GetPurchase API response: {json}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"GetPurchase failed: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }

        var purchases = JsonConvert.DeserializeObject<List<Purchase>>(json) ?? new List<Purchase>();

        // Temporary client-side dedupe: server may return duplicate rows due to joins
        // Group by normalized noOrder and pick the entry with the largest netAmount (prefer populated header)
        var deduped = purchases
            .GroupBy(p => (p.noOrder ?? string.Empty).Trim(), StringComparer.OrdinalIgnoreCase)
            .Select(g => g.OrderByDescending(x => x.netAmount).First())
            .ToList();

        System.Diagnostics.Debug.WriteLine($"GetPurchase: returned {purchases.Count} items, deduped to {deduped.Count} items");

        return deduped;
    }

    public async Task<PurchaseDetailResponse> GetPurchaseById(string noOrder)
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

        return JsonConvert.DeserializeObject<PurchaseDetailResponse>(json);
    }

    // =========================
    // CREATE PURCHASE HEADER
    // =========================
    public async Task CreatePurchase(string noOrder, Purchase purchase)
    {
        // Since backend creates header automatically when adding first line,
        // we use UpdatePurchase to update the header with complete information
        await UpdatePurchase(noOrder, purchase);
    }

    // =========================
    // ADD LINE (SAVE DETAIL)
    // =========================
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

        var response = await _http.PostAsync($"api/purchases/{orderNo}/lines", content);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to add purchase line for order {orderNo}:\n{err}");
        }
    }

    // =========================
    // DELETE LINE
    // =========================
    public async Task DeleteLine(string orderNo, string prCode)
    {
        var response = await _http.DeleteAsync($"api/purchases/{orderNo}/lines/{prCode}");
        response.EnsureSuccessStatusCode();
    }

    // =========================
    // UPDATE LINE
    // =========================
    public async Task UpdateLine(string orderNo, string prCode, PurchaseLineRequest detail)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(detail),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PutAsync($"api/purchases/{orderNo}/lines/{prCode}", content);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to update purchase line: {err}");
        }
    }

    // =========================
    // UPDATE HEADER (SAVE NOTA)
    // =========================
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
            MessageBox.Show(body);
            throw new Exception($"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
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

    // =========================
    // CANCEL PURCHASE
    // =========================
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
