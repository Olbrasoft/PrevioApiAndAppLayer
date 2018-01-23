using System;
using System.Globalization;
using System.Web.Configuration;

namespace Moon.Globalization.DAL.FromConfig.Web
{
    /// <summary>
    /// Vrátí culturu z webconfigu ze sekce 
    /// globalization enableClientBasedCulture="true" culture="auto:en-US" uiCulture="auto:en"
    /// Spoléhá na zadání uiCulture="auto:en-US" or uiCulture="auto:en"
    /// Pokud se nepodaří získat Culture z webconfig, vrátí null
    /// </summary>
    public class DefaultCultureWebConfigReadOnlyRepository: IDefaultCultureReadOnlyRepository
    {
        /// <summary>
        /// Pokusí se získat Cutire z Webconfig jinak vratí první, kterou vrací  IEnableCultureReadOnlyRepository
        /// </summary>
        
        /// <returns>Pokud WbeConfig obsahuje nastaveni UICulture ve formatu auto:en nebo  auto:en-US Vrací Cultre podle webconfig
        /// jinak vrací první kterou vrací  null </returns>
        public virtual CultureInfo GetDefaultCulture()
        {
            var config = WebConfigurationManager.OpenWebConfiguration("/");

            // Get the section related object.
            var configSection = (GlobalizationSection)config.GetSection("system.web/globalization");
            var uiCulture = configSection.UICulture;
            if (uiCulture == "") return null;
            return uiCulture.Contains(":") ? new CultureInfo(uiCulture.Substring(uiCulture.LastIndexOf(":", StringComparison.Ordinal) + 1)) : null;
        }
    }
   
}
