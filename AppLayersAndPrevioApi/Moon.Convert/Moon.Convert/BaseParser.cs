using System;

namespace Moon.Convert
{
   public abstract class BaseParser<T> :IParser<T>
   {   
    
       protected void ThrowNullOrEmpty(string s)
       {
           if (string.IsNullOrEmpty(s))
           {
               throw new ArgumentNullException("s", "inputparameter cannot be null or empty.");
           }
       }

       public abstract T Parse(string s);
       
       public bool TryParse(string s, out T result)
        {
            try
            {
                result = Parse(s);
                return true;
            }
            catch (Exception)
            {
                result = default(T);
                return false;
            }
        }
   }

   
}
