using PerplexityLang.Core;
using PerplexityLang.Utils;

namespace PerplexityLang;

class Program
{
    static void Main(string[] args)
    {
        Lexer l = new Lexer($"""
                            if(Skeleton == "feiox") return true
                            return false
                            """);
        
        l.Analyzer().ForEach(data =>
        {
            Console.WriteLine(data);
        });
    }
}