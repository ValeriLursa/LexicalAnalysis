using System;

namespace LexicalAnalysis
{
    class Program
    {
        private static Analusis analusis = new Analusis();
        private static bool flag = true;
        static void Main(string[] args)
        {
            ConsolReading();
            //ConsolStatic();
        }

        static private void ConsolReading()
        {
            while (flag)
            {
                string s = Console.ReadLine();
                if (s == "") Console.WriteLine("Ошибка. Пустая строка");
                if (!s.Equals("q"))
                    analusis.Metod(s);
                else flag = false;
            }
        }
        static private void ConsolStatic()
        {
            string s = "for i:=10 to N2 do y:=i+2;";
            Console.WriteLine(s);
            analusis.Metod(s);
        }
    }
}
