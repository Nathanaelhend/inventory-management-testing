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
        if (!_http.DefaultRequestHeaders.Contains("ngrok-skip-browser-warning"))
        {
            _http.DefaultRequestHeaders.Add("ngrok-skip-browser-warning", "true");
        }
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

    public async Task<VendorPaymentDetailResponse> GetPaymentById(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await _http.GetAsync($"api/vendor-payment/{encodedName}");
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Get Vendor payment by ID failed {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }
        return JsonConvert.DeserializeObject<VendorPaymentDetailResponse>(json);
    }

    public async Task CreatePayment(string name, VendorPayment payment)
    {
        await UpdatePayment(name, payment);
    }

    public async Task AddLine(string name, PaymentLineRequest detail)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("No Nota cannot be empty!");
        }

        var content = new StringContent(
            JsonConvert.SerializeObject(detail),
            Encoding.UTF8,
            "application/json"
        );

        var url = $"api/vendor-payment/{Uri.EscapeDataString(name)}/lines";
        var response = await _http.PostAsync(url, content);

        if(!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to add vendor payment line {err}");
        }
    }

    public async Task UpdateLine(string name, string bill_id, PaymentLineRequest detail)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(detail),
            Encoding.UTF8,
            "application/json"
        );

        var url = $"api/vendor-payment/{Uri.EscapeDataString(name)}/lines/{Uri.EscapeDataString(bill_id)}";
        var response = await _http.PutAsync(url, content);

        if(!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to update payment line: {err}");
        }
    }

    public async Task DeleteLine(string name, string bill_name)
    {
        var url = $"api/vendor-payment/{Uri.EscapeDataString(name)}/lines/{Uri.EscapeDataString(bill_name)}";
        var response = await _http.DeleteAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to delete payment line: {err}");
        }
    }

    public async Task UpdatePayment(string name, VendorPayment payment)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(payment),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PutAsync($"api/vendor-payment/{Uri.EscapeDataString(name)}", content);
        var body = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception($"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }
}