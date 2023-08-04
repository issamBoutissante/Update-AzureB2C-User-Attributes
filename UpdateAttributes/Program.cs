using Azure.Identity;
using Microsoft.Graph;
using UpdateAttributes;

try
{
    //you should give you are the "User.ReadWrite.All" permission from azure portal before you start

    var scopes = new[] { "https://graph.microsoft.com/.default" };

    // Multi-tenant apps can use "common",
    // single-tenant apps must use the tenant ID from the Azure portal
    var tenantId = "YOUR_TENANT_ID.onmicrosoft.com";

    // Value from app registration
    var clientId = "YOUR_CLIENT_ID";

    var clientSecret = "YOUR_CLIENT_SECRET";

    var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
    var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

    GraphService graphService = new GraphService(graphClient);

    string userObjectId = "YOUR_USER_OBJECTJ_ID";
    await graphService.GetUserById(userObjectId);
    await graphService.UpdateNames(userObjectId);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
