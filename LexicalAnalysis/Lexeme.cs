using System;
using System.Collections.Generic;
using System.Text;

namespace LexicalAnalysis
{
    class Lexeme
    {
        string lexeme;
        string type;

        public Lexeme(string l, string t)
        {
            lexeme = l;
            type = t;
        }
    }
}
