using External.Service.Reniec.Dto;
using External.Service.Reniec.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace External.Service.Reniec.Service
{
    public class Reniec : IReniec
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<ReniecDto> Get(string dni)
        {
            try
            {
                string url = $"https://netcodip.com:8070/api/reniec?dni={dni}";

                // Realiza la solicitud GET a la URL construida
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    ReniecDto person = JsonConvert.DeserializeObject<ReniecDto>(responseData);
                    return person;
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consumir la API: {ex.Message}");
                return null;
            }
        }
    }
}
