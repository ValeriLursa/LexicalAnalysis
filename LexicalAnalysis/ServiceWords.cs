using System;
using System.Collections.Generic;
using System.Text;

namespace LexicalAnalysis
{
    class ServiceWords
    {
        List<ServiceWord> words = new List<ServiceWord>();
        List<ServiceWord> separators = new List<ServiceWord>();
        List<ServiceWord> literals = new List<ServiceWord>();
        List<ServiceWord> identifier = new List<ServiceWord>();
        private int countIdent;
        private int countLit;
        public ServiceWords()
        {
            getWords();
            getSeparator();
            this.countIdent = 0;
            this.countLit = 0;
    }

        private void getWords()
        {
            int i = 1;
            words.Add(new ServiceWord("var",i));
            words.Add(new ServiceWord("int",++i));
            words.Add(new ServiceWord("Boolean", ++i));
            words.Add(new ServiceWord("begin", ++i));
            words.Add(new ServiceWord("end", ++i));
            words.Add(new ServiceWord("for", ++i));
            words.Add(new ServiceWord("to", ++i));
            words.Add(new ServiceWord("do", ++i));
            words.Add(new ServiceWord("while", ++i));
        }
        private void getSeparator()
                {
            int i = 1;
                    separators.Add(new ServiceWord(";",i));
                    separators.Add(new ServiceWord(",", ++i));
                    separators.Add(new ServiceWord(":", ++i));
                    separators.Add(new ServiceWord(":=", ++i));
                    separators.Add(new ServiceWord("+", ++i));
                    separators.Add(new ServiceWord("*", ++i));
                    separators.Add(new ServiceWord("<", ++i));
                    separators.Add(new ServiceWord("<=", ++i));
                    separators.Add(new ServiceWord(">", ++i));
                    separators.Add(new ServiceWord(">=", ++i));
        }
        public int CountWord(string word)
        {
            //поиск по служебным словам
            foreach (ServiceWord i in words)
            {
                if (i.getWord().Equals(word)) return i.getNumber();
            }
            return -1;
        }

        
        public int CountSeparator(string word)
        {
            foreach (ServiceWord i in separators)
            {
                if (i.getWord().Equals(word)) return i.getNumber();
            }
            return -1;
        }

        public int CountIdentifier(string word)
        {
            //поиск по идентифиакторам
            foreach (ServiceWord i in identifier)
            {
                if (i.getWord().Equals(word)) return i.getNumber();
            }
            return -1;
        }

        public int CountLiterals(string word)
        {
            //поиск по литералам
            foreach (ServiceWord i in literals)
            {
                if (i.getWord().Equals(word)) return i.getNumber();
            }
            return -1;
        }
        
        public void setIdentifier(string word)
        {
            identifier.Add(new ServiceWord(word, ++this.countIdent));
        }

        public void setLiteral(string word)
        {
            literals.Add(new ServiceWord(word, ++this.countLit));
        }

        public void Count()
        {
            foreach (ServiceWord i in words)
            {
                Console.WriteLine($"{i.getNumber()} : {i.getWord()}");
            }
        }
    }
}
