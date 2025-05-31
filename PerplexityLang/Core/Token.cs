namespace PerplexityLang.Core;

public class Token
{
    public TokenKind TokenKind { get; set; }
    public string Data { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }

    public Token(TokenKind tokenKind, string data, int row, int column)
    {
        TokenKind = tokenKind;
        Data = data;
        Row = row;
        Column = column;
    }

    public override string ToString()
    {
        return $"TokenKind: {TokenKind} Data: '{Data}' Row: {Row} Column: {Column}";
    }
}