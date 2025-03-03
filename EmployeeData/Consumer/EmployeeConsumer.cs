using EmployeeData.Interfaces;
using EmployeeData.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
namespace EmployeeData.Consumer
{
    public class EmployeeConsumer : IEmployeeConsumer
    {
        private readonly HttpClient _httpClient;
        IConfiguration _configuration;
        public EmployeeConsumer(HttpClient httpClient, IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate");
            _httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("en-US,en;q=0.5");
            _httpClient.DefaultRequestHeaders.Connection.ParseAdd("keep-alive");
            _httpClient.DefaultRequestHeaders.Add("DNT", "1");
            _httpClient.DefaultRequestHeaders.Host = "dummy.restapiexample.com";
            _httpClient.DefaultRequestHeaders.Add("Priority", "u=0, i");
            _httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:135.0) Gecko/20100101 Firefox/135.0");
            _httpClient.DefaultRequestHeaders.Add("Cookie", "humans_21909=1");
            _configuration = configuration;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                ApiResponseList? apiResponse = new();
                var response = await _httpClient.GetAsync(_configuration.GetSection("Request")["Api"]);
                if (response.IsSuccessStatusCode)
                {
                    Stream? responseStream = await response.Content.ReadAsStreamAsync();

                    if (response.Content.Headers.ContentEncoding.Any(encoding => encoding.Equals("gzip", StringComparison.OrdinalIgnoreCase)))
                    {
                        var decompressedStream = new System.IO.Compression.GZipStream(responseStream, System.IO.Compression.CompressionMode.Decompress);
                        StreamReader? reader = new StreamReader(decompressedStream);
                        string decompressedJson = await reader.ReadToEndAsync();
                        apiResponse = JsonSerializer.Deserialize<ApiResponseList>(decompressedJson);
                    }
                    return apiResponse?.Data ?? new List<Employee>();
                }
                else 
                {
                    throw new HttpRequestException($"{(int)response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Employee> GetEmployeeById(int id) 
        {
            try
            {
                ApiResponseSingle? apiResponse = new();
                var response = await _httpClient.GetAsync(_configuration.GetSection("Request")["Apiv1"]+id);
                if (response.IsSuccessStatusCode)
                {
                    Stream? responseStream = await response.Content.ReadAsStreamAsync();

                    if (response.Content.Headers.ContentEncoding.Any(encoding => encoding.Equals("gzip", StringComparison.OrdinalIgnoreCase)))
                    {
                        var decompressedStream = new System.IO.Compression.GZipStream(responseStream, System.IO.Compression.CompressionMode.Decompress);
                        StreamReader? reader = new StreamReader(decompressedStream);
                        string decompressedJson = await reader.ReadToEndAsync();
                        apiResponse = JsonSerializer.Deserialize<ApiResponseSingle>(decompressedJson);
                    }
                    return apiResponse?.Data.FirstOrDefault() ?? throw new Exception("Employee not found");
                }
                else 
                {
                    throw new HttpRequestException($"{(int)response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex) 
            {
                throw new HttpRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
