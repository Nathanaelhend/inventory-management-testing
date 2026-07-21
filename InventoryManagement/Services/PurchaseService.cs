using InventoryManagement.models;
using InventoryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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

    public async Task<List<Purchase>> GetPurchase()
    {
        var response = await _http.GetAsync("api/purchases");
        response.EnsureSuccessStatusCode();
            
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Purchase>>(json);
    }

    public async Task<PurchaseDetailResponse> GetPurchaseById(string noOrder)
    {
        var response = await _http.GetAsync($"api/purchases/{noOrder}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<PurchaseDetailResponse>(json);
    }

    // =========================
    // CREATE PURCHASE HEADER
    // =========================
    public async Task CreatePurchase(string noOrder, Purchase purchase)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(purchase),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PostAsync($"api/purchases", content);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to create purchase order {noOrder}:\n{err}");
        }
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
    // UPDATE HEADER (SAVE NOTA)
    // =========================
    public async Task UpdatePurchase(string noOrder, Purchase purchase)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(purchase),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PutAsync($"api/purchases/{noOrder}", content);
        response.EnsureSuccessStatusCode();
    }

    // =========================
    // CANCEL PURCHASE
    // =========================
    public async Task CancelPurchase(string noOrder)
    {
        var response = await _http.PutAsync($"api/purchases/{noOrder}/cancel", null);
        response.EnsureSuccessStatusCode();
    }
}
