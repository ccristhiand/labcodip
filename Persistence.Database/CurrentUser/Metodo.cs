using Persistence.Database.CurrentUser.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Database.CurrentUser
{
    public class Metodo
    {
        public static ConnectionData GetByConnection()
        {
            string jsonFilePath = @"C:\DataMaster\Connection.json";
            var jsonString = File.ReadAllText(jsonFilePath);
            var response = JsonSerializer.Deserialize<ConnectionData>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return response!;
        }
    }
}
