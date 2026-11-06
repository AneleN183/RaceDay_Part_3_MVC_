using System.Text;
using System.Text.Json;

namespace RaceDay_Part_3_MVC.Services
{//beginning of namespace 
    public class ApiService
    {// beginning of class
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {//beginning of constructor 
            _httpClient = httpClientFactory.CreateClient("RaceDayApi");
        }//end of constructor 

        // 1. Method to GET data (used for Events list)
        public async Task<T?> GetAsync<T>(string endpoint)
        {//start of method 
            try
            {//start of try 
                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {//start of if 
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }//end of if 
                return default;
            }//end of try 
            catch (Exception)
            {//start of catch 
                return default;
            }//end of if 
        }//end of method 

        // 2. Method to POST data where we don't care about the response (used for Create Event)
        public async Task<bool> PostAsync<TRequest>(string endpoint, TRequest data)
        {//beginning of method 
            try
            {//beginning of try 
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);
                return response.IsSuccessStatusCode;
            }//end of try 
            catch (Exception)
            {//beginning of catch  
                return false;
            }//end of catch 
        }//end of method 

        // 3. Method to POST data where we DO care about the response (used for Login)
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {//begining  of method 
            try
            {//beginning of try 
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {//beginning of if 
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<TResponse>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }//end of if 
                return default;
            }//end of try 
            catch (Exception)
            {//beginning of catch 
                return default;
            }//end of catch 
        }//end of try 
    }//end of method 
}//end of namespace 