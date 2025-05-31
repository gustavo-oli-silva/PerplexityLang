namespace PerplexityLang.Core;

public enum TokenKind
{
    //Operadores Lógicos
    Assign,
    Equals,
    MinorThen,
    GreatherThen,
    MinorOrEquals,
    GreaterOrEquals,
    
    //Operadores matemáticos
    Plus,
    Minus,
    Number,
    
    //Sintaxe
    LeftParenthesis,
    RightParenthesis,
    Identifier,
    String,
}