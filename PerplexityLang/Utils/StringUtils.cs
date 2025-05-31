namespace PerplexityLang.Utils;

public static class StringUtils
{
    public static bool IsEmpty(this string? value)
    {
        return value == null || value.Length <= 0;
    }
}