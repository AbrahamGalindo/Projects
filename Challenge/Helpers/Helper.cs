using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Challenge.Helpers
{
    public class Helper
    {
        public const int tHigh = 5000;
        public const int tMedium = 3000;
        public const int tLow = 2000;

        public static void Wait(int time) => Thread.Sleep(time);
        public static string GetCurrentPath(string file)
        {
            char separator = Path.DirectorySeparatorChar;
            string currentDir = Directory.GetCurrentDirectory();
            string parentDir = Directory.GetParent(currentDir).FullName;
            parentDir = parentDir + $"{separator}Source{separator}{file}";
            return parentDir;
        }
        public static string GenerateLetters(int lettersNumber)
        {
            string letters = "";
            for (int i = 0; i < lettersNumber; i++)
            {
                letters = letters + ((char)(((int)'A') + GenerateRandomNumber(0, 25))).ToString();
            }
            return letters;
        }

        public static int GenerateRandomNumber(int initial, int final) => new Random().Next(initial, final);
    }
}
