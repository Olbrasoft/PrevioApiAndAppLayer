namespace Moon.Convert
{
    public interface IConvert<in TFrom, out TTo>
    {
        TTo Convert(TFrom srcObj);
    }
}
