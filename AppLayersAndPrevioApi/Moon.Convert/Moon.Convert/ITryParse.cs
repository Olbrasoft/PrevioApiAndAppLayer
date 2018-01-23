namespace Moon.Convert
{
   public interface ITryParse<T>
   {
      bool TryParse(string s, out T result);
   }
}
