using Microsoft.Extensions.Configuration;

namespace Eticaret.Persistence;

static class Configuration
{
    static public string? ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new ();  
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Eticaret.API"));
            configurationManager.AddJsonFile("appsettings.json");
            
            return configurationManager.GetConnectionString("PostgreSQL");
        } 
        
    }
}