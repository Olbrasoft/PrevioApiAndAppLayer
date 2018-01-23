using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using Moon.Convert;

namespace Moon.DAL.FromConfig
{
    /// <summary>
    /// Bázová třída pro repository načítající údaje z webconfigu,
    /// z AppSetings
    /// </summary>
    /// <typeparam name="T">S jakým skutečným typem mají pracovat</typeparam>
   public abstract class BaseConfigAppSetingsReadOnlyRepository<T>:IRepositoryReadOnly<T>
   {
       protected readonly string AppSettingsKey;
       protected readonly string ObjectSeparator;
       protected readonly IParser<T> ConvertToObject;

       //Kolekce v paměti abychom nemusely pořád číst z WebConfigu
       private IEnumerable<T> _objectsFromWebConfig;

       //Pokud je privatni promena prazdna nactu jinak vracim privatni promenou
       protected IEnumerable<T> ObjectsFromWebconfig
       {
           get { return _objectsFromWebConfig ?? (_objectsFromWebConfig = GetObjectsAsStringFromWbeconfig()); }
       }

        /// <summary>
        /// Constructor
        ///  </summary>
        /// <param name="appSettingsKey">pod jakym Key jsou/budou ulozene objekty</param>
        /// <param name="objectSeparator">jak jsou v hodnote value oddelene objekty jako regex</param>
        /// <param name="convertToObject">Třída který umí z načteného stringu udělat Skutečný objekt</param>
       protected BaseConfigAppSetingsReadOnlyRepository(string appSettingsKey, string objectSeparator, IParser<T> convertToObject)
       {
           AppSettingsKey = appSettingsKey;
           ObjectSeparator = objectSeparator;
           ConvertToObject = convertToObject;
       }
       

       /// <summary>
       /// Načtou údaje z webconfigu a vrátí kolekci skutečných objektů
       /// Oddělení objektů se provádí Regex.Split(value,ObjectSeparator)
       /// </summary>
       /// <returns>Pokud se nepodaří nic načíst vrací prázdné pole, jinak vrací pole skutečných objektů</returns>
       private IEnumerable<T> GetObjectsAsStringFromWbeconfig()
       {
           //pokusim se načíst z webconfigu předanej Key
           try
           {
               var value = ConfigurationManager.AppSettings.Get(AppSettingsKey);
               
               //Rozdělíme sivalue na jednotlivé (string) objekty 
               var listStrObject =  Regex.Split(value,ObjectSeparator);

               return listStrObject.Select(ConvertStringToObject).ToArray();

           }
           catch //Nepodařilo se načíst z webconfigu vracím prázdné pole
           {
               return new ArraySegment<T>().ToList();
           }
       }

       
       /// <summary>
       /// Převede string na skutečný objekt Typu T
       /// </summary>
       /// <param name="strObject">Object v podobě stringu</param>
       /// <returns>Skutečný Objekt vytvořený za pomoci předaného stringu</returns>
       protected  T ConvertStringToObject(string strObject)
       {
            return ConvertToObject.Parse(strObject);
       }

        public IQueryable<T> GetQuery(params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
       {
           if (includeProperties.Any())
               throw new NotImplementedException ("This repository not Implemntation includeProperties.");
           
           return ObjectsFromWebconfig.AsQueryable();
       }
   }

}
