using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SimbirsoftTestApp
{
    public class HtmlLoader
    {
        private Uri _url;
        private WebClient _webClient;

        public HtmlLoader(string url, WebClient webClient)
        {
            _url = new Uri(url);
            _webClient = webClient;
            DownloadHtmlDocument();
        }

        public void DownloadHtmlDocument()
        {
            try
            {
                _webClient.DownloadFile(_url, _url.Host + ".html");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string LoadHtmlDocument()
        {
            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(_webClient.DownloadString(_url));
                var documentNode = doc.DocumentNode.SelectSingleNode("//body").InnerText;
                return documentNode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
