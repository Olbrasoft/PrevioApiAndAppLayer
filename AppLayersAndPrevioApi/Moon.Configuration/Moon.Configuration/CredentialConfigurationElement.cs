using System.Configuration;

namespace Moon.Configuration
{
    /// <summary>
    ///     Přihlášení
    /// </summary>
    public class CredentialConfigurationElement : ConfigurationElement
    {
        /// <summary>
        ///     Gets the Name for key
        /// </summary>
        /// <value>Name.</value>
        [ConfigurationProperty("name", IsRequired = true, IsKey=true)]
        public string Name
        {
            get { return this["name"] as string; }
        }


        /// <summary>
        ///     Gets the UserName.
        /// </summary>
        /// <value>UserName.</value>
        [ConfigurationProperty("userName", IsRequired = true)]
        public string UserName
        {
            get { return this["userName"] as string; }
        }

        /// <summary>
        ///     Gets the Password
        /// </summary>
        /// <value>Password.</value>
        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return this["password"] as string; }
        }
    }
}