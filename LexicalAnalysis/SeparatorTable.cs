using System;
using System.Collections.Generic;
using System.Text;

namespace LexicalAnalysis
{
    class SeparatorTable
    {
        int count = 0;
        string word;
        public SeparatorTable(string w)
        {
            this.count++;
            this.word = w;
        }
        public int getNumber()
        {
            return count;
        }
        public string getWord()
        {
            return word;
        }
    }
}
