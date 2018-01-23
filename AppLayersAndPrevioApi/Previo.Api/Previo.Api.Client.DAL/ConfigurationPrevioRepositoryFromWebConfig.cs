using System;
using System.Configuration;

namespace Previo.Api.Client.DAL
{
    /// <summary>
    /// Pro configuraci repositoru z webconfigu
    /// </summary>
    public class ConfigurationPrevioRepositoryFromWebConfig : IConfigurationPrevioRepository
    {
        public ConfigurationPrevioRepositoryFromWebConfig()
        {
            var config = (PrevioApiConfiguration) ConfigurationManager.GetSection("previoApiSeting");
            User = config.DefaultCredential.UserName;
            Password = config.DefaultCredential.Password;
            BaseUrl = config.BaseApiUrl;
        }

        public string User { get; private set; }
        public string Password { get; private set; }
        public Uri BaseUrl { get; private set; }
    }
}