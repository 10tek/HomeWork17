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
            var i = 0;

            foreach (XmlElement chanelElement in rootElement.ChildNodes)
            {
                XmlElement itemsElement = chanelElement.GetElementsByTagName("item")[i++] as XmlElement;

                XmlElement titleElement = itemsElement.GetElementsByTagName("title")[0] as XmlElement;
                XmlElement linkElement = itemsElement.GetElementsByTagName("link")[0] as XmlElement;
                XmlElement descriptionElement = itemsElement.GetElementsByTagName("description")[0] as XmlElement;
                XmlElement pubDateElement = itemsElement.GetElementsByTagName("pubDate")[0] as XmlElement;

                items.Add(new Item
                {
                    Title = titleElement.InnerText,
                    Link = linkElement.InnerText,
                    Description = descriptionElement.InnerText,
                    PubDate = pubDateElement.InnerText,
                });


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
