using System;
using System.Configuration;
using Moon.Configuration;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Konfigurace pro Previo.Api.Client z configu
    /// </summary>
    public class PrevioApiConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("credentials", IsRequired = true)]
        public GenericConfigurationElementCollection<CredentialConfigurationElement> Credentials
        {
            get { return (GenericConfigurationElementCollection<CredentialConfigurationElement>) this["credentials"]; }
        }


        /// <summary>
        ///     Aby bylo mozne vyhladat v kolekci defaultniho uzivatele musime znat jeho jmeno.
        ///     Pomocna pro vlastnost  DefaultCredential
        /// </summary>
        [ConfigurationProperty("defaultCredentialName")]
        public string DefaultCredentialName
        {
            get { return this["defaultCredentialName"] as string; }
        }

        /// <summary>
        ///     Záklaní adresa na které se nachází api jako string kuli deserializaci nemuze byt primo Uri
        /// </summary>
        [ConfigurationProperty("baseApiUrl")]
        public string BaseApiUrlAsString
        {
            get { return this["baseApiUrl"] as string; }
        }

        /// <summary>
        ///     Defaultní conection
        /// </summary>
        public CredentialConfigurationElement DefaultCredential
        {
            get { return Credentials[DefaultCredentialName]; }
        }

        /// <summary>
        ///     Záklaní adresa na které se nachází api
        /// </summary>
        public Uri BaseApiUrl
        {
            get { return new Uri(BaseApiUrlAsString); }
        }
    }
}