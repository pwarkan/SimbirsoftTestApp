using System;
using System.IO;
using System.Linq;
using System.Net;

namespace SimbirsoftTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "site.txt";
            HtmlLoader htmlLoader = new HtmlLoader(File.ReadAllText(Environment.CurrentDirectory + "\\" + fileName), new WebClient());

            Parser parser = new Parser(htmlLoader);
            parser.Parse();
            Console.ReadKey();
        }
    }
}
