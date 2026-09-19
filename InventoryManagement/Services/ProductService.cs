using InventoryManagement.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:3000/");
    }

    public async Task<List<Product>> GetProducts()
    {
        var response = await _http.GetAsync("api/products");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Product>>(json);
    }

    public async Task<int> GetStock(string productCode)
    {
        var response = await _http.GetAsync($"api/products/{productCode}/stock");

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception("Gagal Get Stock");
        }

        var json = await response.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<StockResponse>(json);

        return obj.pQty;
    }

    public async Task AddProduct(Product product)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(product),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PostAsync("api/products", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode} - {response}");
        }

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateProduct(string pcode, Product product)
    {
        var content = new StringContent(
            JsonConvert.SerializeObject(product),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.PutAsync($"api/products/{pcode}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteProduct(string pcode)
    {
        var response = await _http.DeleteAsync($"api/products/{pcode}");
        response.EnsureSuccessStatusCode();
    }
}