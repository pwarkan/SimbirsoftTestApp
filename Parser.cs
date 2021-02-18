using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimbirsoftTestApp
{
    class Parser
    {
        private string _text;
        private Dictionary<string, int> _result;
        private char[] _separators = { ' ', '{', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t', '}' };

        public Parser(HtmlLoader htmlLoader)
        {
            _result = new Dictionary<string, int>();
            _text = htmlLoader.LoadHtmlDocument();
        }

        public void Parse()
        {
            try
            {
                foreach (var word in _text.Split(_separators, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (IsLetter(word))
                    {
                        int count = 0;
                        _result.TryGetValue(word, out count);
                        _result[word] = count + 1;
                    }
                }
                Output();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsLetter(string str)
        {

            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

        public void Output()
        {
            foreach (var pair in _result)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
        }
    }
}
