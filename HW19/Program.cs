using System;
using System.Collections.Generic;
using System.Xml;

namespace HW19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();

            XmlDocument document = new XmlDocument();
            document.Load(@"https://habrahabr.ru/rss/interesting/");

            XmlElement rootElement = document.DocumentElement;

            foreach (XmlElement chanelElement in rootElement.ChildNodes)
            {

                foreach (XmlElement itemElement in chanelElement.ChildNodes)
                {
                    XmlElement titleElement = itemElement.GetElementsByTagName("title")[0] as XmlElement;
                    XmlElement linkElement = itemElement.GetElementsByTagName("link")[0] as XmlElement;
                    XmlElement descriptionElement = itemElement.GetElementsByTagName("description")[0] as XmlElement;
                    XmlElement pubDateElement = itemElement.GetElementsByTagName("pubDate")[0] as XmlElement;

                    items.Add(new Item
                    {
                        Title = titleElement.InnerText,
                        Link = linkElement.InnerText,
                        Description = descriptionElement.InnerText,
                        PubDate = pubDateElement.InnerText,
                    });

                }
            }

            foreach (var item in items)
            {
                Console.WriteLine("<item>");
                Console.WriteLine($"    <title> {item.Title} </title>");
                Console.WriteLine($"    <link> {item.Link} </link>");
                Console.WriteLine($"    <description> {item.Description} </description>");
                Console.WriteLine($"    <pubDate> {item.PubDate} </pubDate>");
                Console.WriteLine("</item>");
            }



        }
    }
}
