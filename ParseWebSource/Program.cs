using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace ParseWebSource
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> proxies = new List<string>();

            string Url = "http://spys.one/socks/";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);

            HtmlNode htmlNode = doc.DocumentNode.SelectSingleNode("//html/body/table[2]/tr[4]/td/table");
            //Определяем количество страниц
            HtmlNode pages = htmlNode.ChildNodes[2].ChildNodes[0];
            Console.WriteLine($"Всего страниц {(pages.ChildNodes.Count - 1) / 2}");
            foreach (HtmlNode temp in htmlNode.ChildNodes)
            {

                //Пропускаем пустые теги и заголовок таблицы
                if (temp.Name == "#text" || temp.ChildNodes.Count < 9 || temp.ChildNodes[0].ChildNodes.Count < 3 )
                    continue;
                else
                {
                    HtmlNode ip = temp.ChildNodes[0].ChildNodes[2].ChildNodes[0];
                    proxies.Add(ip.InnerHtml);
                    Console.WriteLine(ip.InnerHtml);
                }
            }

            Console.ReadKey();
        }
    }
}
