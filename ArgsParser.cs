using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TDDExam
{
    internal class ArgsParser
    {
        private string textData;
        private List<TexiPriceArgs> args = new List<TexiPriceArgs>();

        public ArgsParser(string textData)
        {
            this.textData = textData;

            this.args = ParseData(textData);
        }

        private List<TexiPriceArgs> ParseData(string textData)
        {
            string pattern = @"(?<mil>\d+)公里,等待(?<time>\d+)分钟";
            MatchCollection matches = Regex.Matches(textData, pattern);

            foreach (Match match in matches)
            {
                string mil = match.Groups["mil"].Value;
                string time = match.Groups["time"].Value;

                try
                {
                    args.Add(new TexiPriceArgs(int.Parse(mil), int.Parse(time)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"parser failed : {mil} {time}");
                }

            }

            return args;
        }

        public List<TexiPriceArgs> GetArgs()
        {
            return args;
        }
    }
}