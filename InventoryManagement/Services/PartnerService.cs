using InventoryManagement.models;
using InventoryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PartnerService
{
    private readonly HttpClient _http;

    public PartnerService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("https://uptight-amendment-ocean.ngrok-free.dev/");
    }

    public async Task<List<Partner>> GetPartner()
    {
        var response = await _http.GetAsync("api/partners");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Partner>>(json);
    }

    public async Task AddPartner(Partner partner)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(partner),
            Encoding.UTF8, "application/json"
            );

        var response = await _http.PostAsync("api/partners", content);

        if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            throw new Exception("Duplicate Data");

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdatePartner(string ccode, string name, string phone, string type)
    {
        var data = new
        {
            cname = name,
            cphone = phone,
            cType = type
        };

        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _http.PutAsync($"api/partners/{ccode}", content);

        if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            throw new Exception("Partner not found");

        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            throw new Exception("Invalid data");
        
        response.EnsureSuccessStatusCode();
    }

    public async Task DeletePartner(int ccode)
    {
        var response = await _http.DeleteAsync($"api/partners/{ccode}");
        response.EnsureSuccessStatusCode();
    }
}