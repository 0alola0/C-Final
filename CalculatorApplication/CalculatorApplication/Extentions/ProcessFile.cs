using System;
using Newtonsoft.Json;

namespace CalculatorApplication.Extentions
{
    public static class ProcessFile
    {
        public static string path = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/EventStorage";

        public static string CreatePath(string month, string day, string pathSuffix)
        {
            string constructedPath = path + $@"{day}.{month}.{pathSuffix}";
            return constructedPath;

        }

        public static void SaveFile(string serializedEvent, string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            using (StreamWriter sw = File.AppendText(filePath))
            {
                
                sw.WriteLine("---");
                sw.WriteLine(serializedEvent);
                sw.WriteLine("---");
            }
        }

        public static void DeleteFile(string serializedEvent, string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("no such file");
            }
            else
            {
               File.WriteAllText(filePath, string.Empty);

                foreach (var item in serializedEvent)
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {

                        sw.WriteLine("---");
                        sw.WriteLine(item);
                        sw.WriteLine("---");
                    }

                }
            }
        }

    }
}

