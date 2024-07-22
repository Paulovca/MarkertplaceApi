namespace MarkertplaceApi.Authority;

public class AppRepository
{
    private static List<Application> _applications = new()
    {
        new Application
        {
            ApplicationId = 1,
            ApplicationName = "Admin",
            ClientId = "53D3C1E6-4587-4AD5-8C6E-A8E4BD59940E",
            Secret = "0673FC70-0514-4011-B4A3-DF9BC03201BC",
            Scopes = "read,write"
        },
        new Application
        {
            ApplicationId = 1,
            ApplicationName = "User",
            ClientId = "E7F2A4D5-89AB-4F16-8A9C-3A4F60D5C7E2",
            Secret = "A8B4F231-6C57-4DF1-832F-D9C0E2A6B8F7",
            Scopes = "read,write"
        },
    };

    public static bool Authenticate(String ClientId, String Secret)
    {
        return _applications.Any(x => x.ClientId == ClientId && x.Secret == Secret);
    }
    
    public static Application? GetApplicationByClientId(string clientId)
    {
        return _applications.FirstOrDefault(x => x.ClientId == clientId);
    }
}