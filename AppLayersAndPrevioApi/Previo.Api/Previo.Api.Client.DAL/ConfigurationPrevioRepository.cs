using System;

namespace Previo.Api.Client.DAL
{
    public class ConfigurationPrevioRepository : IConfigurationPrevioRepository
    {
        public string User { get; private set; }
        
        public string Password { get; private set; }
        
        public Uri BaseUrl { get; private set; }
        
        public ConfigurationPrevioRepository(string user , string password, Uri baseUrl)
        {
            User = user;
            BaseUrl = baseUrl;
            Password = password;
           
        }

        
    }
}
