namespace PerplexityLang.Utils;

public struct Option<T>
{
    private T? Value { get; set; }
    public bool IsSome => Value != null;

    public Option(T value)
    {
        Value = value;
    }

    public T Unwrap()
    {
        if (IsSome)
        {
            return Value!;
        }

        throw new NullReferenceException("Unwraped value is null");
    }

    public T UnwrapOr(T defaultValue)
    {
        if (IsSome)
        {
            return Value!;
        }

        return defaultValue;
    }
}