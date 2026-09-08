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

    public async Task<VendorBillResponse> GetBillById(int id)
    {
        var url = $"api/vendor-bill/{id}";
        var response = await _http.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();

        if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
        if(!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to get vendor bill: {(int)response.StatusCode} ({response.StatusCode})\n{json}");
        }

        return JsonConvert.DeserializeObject<VendorBillResponse>(json);
    }

    public async Task CreateBill(VendorBill request)
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
}
