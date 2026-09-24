using InventoryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class VendorPaymentService
{
    private readonly HttpClient _http;

    public VendorPaymentService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("https://uptight-amendment-ocean.ngrok-free.dev/");
    }

    public async Task<string> GeneratePaymentNumber()
    {
        var response = await _http.GetAsync("api/vendor-payment/ApNo");
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to generate payment number: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }
        var result = JsonConvert.DeserializeObject<dynamic>(json);
        return result?.name?.ToString() ?? string.Empty;
    }

    public async Task<List<VendorPayment>> GetPayments()
    {
        var response = await _http.GetAsync("api/vendor-payment");
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Get Vendor payments failed {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }
        var result = JsonConvert.DeserializeObject<VendorPaymentResponse>(json);
        return result?.data ?? new List<VendorPayment>();
    }

    public async Task<VendorPaymentlDetailResponse> GetPaymentById(int id)
    {
        var response = await _http.GetAsync($"api/vendor-payment/{id}");
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Get Vendor payment by ID failed {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }
        return JsonConvert.DeserializeObject<VendorPaymentlDetailResponse>(json);
    }

    public async Task<VendorPayment> CreatePayment(VendorPayment payment)
    {
        var jsonContent = JsonConvert.SerializeObject(payment);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _http.PostAsync("api/vendor-payment", content);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Create Vendor payment failed {(int)response.StatusCode} ({response.StatusCode})\n{jsonResponse}");
        }
        return JsonConvert.DeserializeObject<VendorPayment>(jsonResponse);
    }
}