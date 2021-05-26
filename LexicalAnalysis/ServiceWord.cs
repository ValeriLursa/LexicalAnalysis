using System;
using System.Collections.Generic;
using System.Text;

namespace LexicalAnalysis
{
    class ServiceWord
    {
        int count;
        string word;
        public ServiceWord(string w, int c)
        {
            this.count = c;
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
