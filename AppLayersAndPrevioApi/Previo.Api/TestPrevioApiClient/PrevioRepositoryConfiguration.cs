using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrevioApiClient
{
    /// <summary>
    /// 
    /// </summary>

    public class PrevioRepositoryConfiguration :Previo.Api.Client.DAL.ConfigurationPrevioRepository
    {
        
        #region Constructors
        public PrevioRepositoryConfiguration()
            : base("hotelubytovani", "uby24hot39",
                                         new Uri("https://api.previo.cz/x1/"))
        {
        }

   
        #endregion

     

      

    }
}
