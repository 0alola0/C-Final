using System;
namespace CalculatorApplication.Extentions
{
    public static class ProcessException
    {
        public static string exPath = @"c:/Users/macuser/Desktop/C#final/CalculatorApplication/CalculatorApplication/ExceptionStorage/PastExceptions.txt";


        public static void ProcessSingleException(string message, string trace)
        {
            using (StreamWriter sw = File.AppendText(exPath))
            {
                string exceptionText = $"here is the error message: {message}, and trace {trace}";
                sw.WriteLine("---");
                sw.WriteLine(exceptionText);
                sw.WriteLine("---");
            }
        }


        public static void ReadExceptions()
        {
            if (!File.Exists(exPath))
            {
                Console.WriteLine("a file for errors does not exist, perhaps there are no errors yet");
            }

            else
            {
                string fileText = File.ReadAllText(exPath);
                var splittedExces = fileText.Split("---");

                foreach (var item in splittedExces)
                {

                    Console.WriteLine($"error: {item}");

                }
            }

        }
    }
}

