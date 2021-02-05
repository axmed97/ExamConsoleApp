using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamConsoleApp
{
    static class Utilities
    {
        public static bool IsNumber(string text)
        {
            try
            {
                Convert.ToInt32(text);
                return true;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Please, enter only number!");
                return false;
            }
        }
    }
}
