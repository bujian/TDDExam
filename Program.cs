using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExam
{
    class Program
    {
        static string pricePrintFormat = "收费{0}元";

        static void Main(string[] args)
        {
            string textData = GetTestData(args);

            if (string.IsNullOrEmpty(textData))
            {
                Console.WriteLine("Get Test Data Failed");
            }
            else
            {
                var parser = new ArgsParser(textData);
                var texiArgs = parser.GetArgs();
                var priceCal = new TexiPriceCalculor();
                texiArgs.ForEach(arg => Console.WriteLine(string.Format(pricePrintFormat, priceCal.GetPrice(arg))));
            }

            Console.ReadKey();
            
        }

        static string GetTestData(string[] args)
        {
            string ret = "";
            if (args.Length < 1)
            {
                Console.WriteLine("args is null");
                return ret;
            }

            string path = args[0];
            if (!File.Exists(path))
            {
                Console.WriteLine($"file is not exit : {path}");
            }
            else
            {
                ret = File.ReadAllText(path); 
            }

            return ret;
        }

    }
}
