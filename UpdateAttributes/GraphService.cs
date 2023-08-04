using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace UpdateAttributes
{
    public class GraphService
    {
        private readonly GraphServiceClient _graphServiceClient;
        public GraphService(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }
        public async Task GetUserById(string userObjectId)
        {
            try
            {
                // Get user by object ID
                var result = await _graphServiceClient.Users[userObjectId].GetAsync();

                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
        public async Task UpdateNames(string userObjectId)
        {
            var requestBody = new User
            {
                GivenName="new first Name",
                Surname = "new last Name"
            };
            var result = await _graphServiceClient.Users[userObjectId].PatchAsync(requestBody);
        }
    }
}
