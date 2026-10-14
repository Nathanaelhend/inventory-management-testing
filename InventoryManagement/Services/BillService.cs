using InventoryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class BillService
{
    private readonly HttpClient _http;

    public BillService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:3000/");
    }

    public async Task<String> GenerateNumber()
    {
        var response = await _http.GetAsync("api/vendor-bill/billno");
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to generate bill number: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }
        var result = JsonConvert.DeserializeObject<dynamic>(json);
        return result?.name?.ToString() ?? string.Empty;
    }

    public async Task<List<VendorBill>> GetBill()
    {
        var response = await _http.GetAsync("api/vendor-bill");
        var json = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Get Vendor bill failed {(int)response.StatusCode}" +
                $"({response.StatusCode}\n{json}"
            );
        }

        var result = JsonConvert.DeserializeObject<VendorBillResponse>(json);
        return result?.data ?? new List<VendorBill>();
    }

    public async Task<VendorBillDetailResponse> GetBillById(int id)
    {
        var response = await _http.GetAsync($"api/vendor-bill/id/{id}");
        var json = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception($"Get Bill failed: {json}");
        }

        return JsonConvert.DeserializeObject<VendorBillDetailResponse>(json);
    }

    public async Task<VendorBillDetailResponse> GetBillByName(string name)
    {
        string encodedName = Uri.EscapeDataString(name);
        var response = await _http.GetAsync($"api/vendor-bill/name/{encodedName}");
        var json = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            return null;
        }

        return JsonConvert.DeserializeObject<VendorBillDetailResponse>(json);
    }

    public async Task<List<VendorBill>> GetBillByVendorId(string vendor_id)
    {
        var response = await _http.GetAsync($"api/vendor-bill/vendor/{vendor_id}");
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Get Vendor bill failed ({(int)response.StatusCode}): {json}");
        }

        // Direct deserialize ke wrapper class
        var result = JsonConvert.DeserializeObject<VendorBillResponse>(json);
        return result?.data ?? new List<VendorBill>();
    }

    public async Task CreateBill(VendorBillDetailResponse request)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(request),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PostAsync(
            "api/vendor-bill",
            content
        );

        var json = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Create Vendor Bill failed: " +
                $"{(int)response.StatusCode} ({response.StatusCode})\n{json}"
            );
        }
    }

    public async Task UpdateVendorBill(int id, VendorBillResponse bill)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(bill),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PutAsync($"api/vendor-bill/{id}", content);
        var body = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Failed to update Bill id: {id}: {(int)response.StatusCode} ({response.StatusCode})\n{body}");
        }
    }

    public async Task ConfirmBill(int id, VendorBill bill)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(bill),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PutAsync($"api/vendor-bill/{id}/confirm", content);
        var body = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Failed to Confirm Vendor Bill id: {id} {(int)response.StatusCode} {body}");
        }
    }
}
