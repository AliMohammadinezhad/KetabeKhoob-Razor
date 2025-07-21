namespace KetabeKhoob.Razor.Infrastructure.Utils;

public class EnumUtils
{
    public static T ParsEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }
}