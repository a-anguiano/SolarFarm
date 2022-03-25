using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment
{
    public class ConsoleIO
    {
        public string GetString(string prompt)
        {
            string result = "";
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                result = Console.ReadLine().Trim();
                if (result.Length == 0)
                {
                    Error("Please input a value\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
        public int GetInt(string prompt)
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
