using System;
using System.Collections.Generic;
using System.Text;

namespace LexicalAnalysis
{
    class Analusis
    {
        //flag 1 - идентификатор, 2 - литера, 3 - разделитель
        string buf = "";

        public void Metod(string s)
        {
            int i = 0;
            int flag = 0;
            this.flag = 0;
            buf = "";
            while (i < s.Length)
            {
                if (Simbol(s[i],ref buf, ref flag) == 1) return;
                i++;
            }
            SintexLexem(buf, 5);

            //word.Count();
        }

        public int  Simbol(char c, ref string  buf, ref int flag)
        {
            if (char.IsLetter(c))
            {
                //если буква
                if ((flag != 1)&&(flag!=0))
                {
                    if (SintexLexem(buf, flag) == 1) return 1;
                    buf = "";
                    flag = 0;
                }
                if (flag == 0)
                {
                    flag = 1;
                }
               
                buf += c;
            }
            else if (char.IsDigit(c))
            {
                //если число
                if (flag == 2)
                {
                    if (SintexLexem(buf, flag) == 1) return 1;
                    buf = "";
                    flag = 0;
                }
                if (flag == 0)
                {
                    flag = 3;
                }
                buf += c;
            }
            else if (c ==' ')
            {
                if (SintexLexem(buf, flag) == 1) return 1;
                buf = "";
                flag = 0;
                return 2;
            }
            else if (Separator(c))
            {
                //разделитель
                if (flag != 2)
                {
                    if (SintexLexem(buf, flag) == 1) return 1;
                    buf = "";
                    flag = 0;
                }
                if (flag == 0) flag = 2;
                buf += c;
            }
            return 5;
        }

        public bool Separator(char c)
        {
            //проверка а разделитель
            switch (c)
            {
                case ':': 
                case '=': 
                case '/':
                case '+':
                case '-':
                case '*':
                case ';':
                case '<':
                case '>':
                    return true;
            }
            return false;
        }
        /*public void ConsolLexem(string buf, int type)
        {
            switch (type)
            {
                case 1:
                    Console.WriteLine($"{buf} : идентификатор");
                    break;
                case 2:
                    Console.WriteLine($"{buf} : разделитель");
                    break;
                case 3:
                    Console.WriteLine($"{buf} : литерал");
                    break;
            }
        }*/
        private ServiceWords word = new ServiceWords();
        private int num = -1;
        public void ConsolLexem(string buf, int type)
        {
            
            switch (type)
            {
                case 1:
                    //
                    //проверить на терминал
                    num = word.CountWord(buf);
                    if (num != -1)
                    {
                        Console.WriteLine($"{buf} : ({type}, {num})");
                    }
                    //проверить на идентификатор
                    else
                    {
                        num = word.CountIdentifier(buf);
                        if (num != -1)
                        {
                            Console.WriteLine($"{buf} : (4, {num})");
                        }
                        else
                        {
                            //если новый идентификатор
                            word.setIdentifier(buf);
                            num = word.CountIdentifier(buf);
                            Console.WriteLine($"{buf} : (4, {num})");
                        }
                    }
                    break;
                case 2:
                    //
                    //проверить на разделитель
                    num = word.CountSeparator(buf);
                    if (num!= -1)
                    {
                        Console.WriteLine($"{buf} : ({type}, {num})");
                    }
                    break;
                case 3:
                    //
                    //проверить на литерал
                    num = word.CountLiterals(buf);
                    if (num != -1)
                    {
                        Console.WriteLine($"{buf} : ({type}, {num})");
                    }
                    else
                    {
                        //если новый литерал
                        word.setLiteral(buf);
                        num = word.CountLiterals(buf);
                        Console.WriteLine($"{buf} : ({type}, {num})");
                    }
                    break;
            }
        
        }
        int flag = 0;
        public int  SintexLexem(string buf, int type)
        {
            //начальное щначение
            if (buf == "for")
            {
                flag = 10;
                return 2;
            }
            if (flag / 10 == 1)
            {
                switch (flag)
                {
                    case 10:
                        //Console.WriteLine(type);
                        if (type != 1)
                        {
                            Console.WriteLine("Ошибка 10");
                            return 1;
                            break;
                        }
                        flag = 11;
                        break;
                    case 11:
                        if (buf != ":=")
                        {
                            Console.WriteLine("Ошибка 11");
                            return 1;
                            break;
                        }
                        flag = 12;
                        break;
                    case 12:
                        //Console.WriteLine(type);
                        //Console.WriteLine(buf);
                        if ((type != 1) && (type != 3))
                        {
                            Console.WriteLine("Ошибка 12");
                            return 1;
                            break;
                        }
                        flag = 13;
                        break;
                    case 13:
                        if (buf != "to")
                        {
                            Console.WriteLine("Ошибка 13");
                            return 1;
                            break;
                        }
                        flag = 14;
                        break;
                    case 14:
                        if ((type != 1) && (type != 3))
                        {
                            Console.WriteLine("Ошибка 14");
                            return 1;
                            break;
                        }
                        flag = 15;
                        break;
                    case 15:
                        if (buf != "do")
                        {
                            Console.WriteLine("Ошибка 15");
                            return 1;
                            break;
                        }
                        flag = 16;
                        break;
                    case 16:
                        if ((type == 5) && (buf != ";"))
                        {
                            Console.WriteLine("Ошибка конца");
                            return 1;
                        }
                        Console.WriteLine("0");
                        break;
                }
                

            }
            return 5;
        }
    }
}
