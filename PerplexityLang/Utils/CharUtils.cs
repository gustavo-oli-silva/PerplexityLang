namespace PerplexityLang.Utils;

public static class CharUtils
{
    public static bool IsDigit(this char value)
    {
        return Char.IsDigit(value);
    }

    public static bool IsLetter(this char value)
    {
        return Char.IsLetter(value);
    }

    public static bool IsWhiteSpace(this char value)
    {
        return Char.IsWhiteSpace(value);
    }

}