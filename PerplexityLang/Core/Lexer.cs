using PerplexityLang.Utils;

namespace PerplexityLang.Core;

public class Lexer(
    string input
    )
{
    private List<char> _chars = input.ToList();
    private int _position = 0;
    private int _column = 1;
    private int _row = 1;

    public List<Token> Analyzer()
    {
        List<Token> tokens = [];

        while (_position < _chars.Count)
        {
            IfWhiteSpace();
            
            char currentChar = Peek();
            int currentColumn = _column;
            
            switch (currentChar)
            {
                case '(':
                    tokens.Add(new Token(TokenKind.RightParenthesis, "(", _row, currentColumn));
                    break;
                case ')':
                    tokens.Add(new Token(TokenKind.LeftParenthesis, ")", _row, currentColumn));
                    break;
                case '=':
                    switch (PeekNextChar())
                    {
                        case '=':
                            tokens.Add(new Token(TokenKind.Equals, "==", _row, currentColumn));
                            Next();
                            break;
                        case '>':
                            tokens.Add(new Token(TokenKind.GreaterOrEquals, "=>", _row, currentColumn));
                            Next();
                            break;
                        default:
                            tokens.Add(new Token(TokenKind.Assign, "=", _row, currentColumn));
                            break;
                    }
                    break;
                case '<':
                    switch (PeekNextChar())
                    {
                        case '=':
                            tokens.Add(new Token(TokenKind.MinorOrEquals, "<=", _row, currentColumn));
                            Next();
                            break;
                            
                        default:
                            tokens.Add(new Token(TokenKind.MinorThen, "<", _row, currentColumn));
                            break;
                    }
                    break;
                case '>':
                    tokens.Add(new Token(TokenKind.LeftParenthesis, ">", _row, currentColumn));
                    break;
                case '"':
                    string stringValue = "";
                    Next();

                    while (Peek() != '"')
                    {
                        stringValue += Peek();
                        Next();
                    }
                    
                    tokens.Add(new Token(TokenKind.String, stringValue, _row, currentColumn));
                    
                    break;
                default:
                    string numberValue = "";

                    while (Peek().IsDigit())
                    {
                        numberValue += Peek();
                        Next();
                    }

                    if (!numberValue.IsEmpty())
                    {
                        tokens.Add(new Token(TokenKind.Number, numberValue, _row, currentColumn));
                    }

                    string identifierValue = "";

                    while (Peek().IsLetter())
                    {
                        identifierValue += Peek();
                        Next();
                    }

                    if (!identifierValue.IsEmpty())
                    {
                        tokens.Add(new Token(TokenKind.Identifier, identifierValue, _row, currentColumn));
                    } 
                    
                    break;
            }

            if (!currentChar.IsDigit() || !currentChar.IsLetter())
            {
                Next();
            }
        }

        return tokens;
    }

    public void Next()
    {
        if (Peek() == '\n')
        {
            _row++;
            _column = 1;
        }
        else
        {
            _column++;
        }
        
        _position++;
    }

    public char Peek()
    {
        if (_position < _chars.Count)
        {
            return _chars[_position];
        }

        return '\0';
    }

    public char PeekNextChar()
    {
        if (_position+1 < _chars.Count)
        {
            return _chars[_position+1];
        }

        return '\0';
    }

    public void IfWhiteSpace()
    {
        while (Peek().IsWhiteSpace())
        {
            Next();
        }
    }
}