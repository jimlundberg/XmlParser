using System;
using System.Xml;

namespace XmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Temp\\Test.xml");

            XmlNode consumed = doc.DocumentElement.SelectSingleNode("/CONFIG_3155301-034/FileConfiguration/Consumed");
            XmlNode produced = doc.DocumentElement.SelectSingleNode("/CONFIG_3155301-034/FileConfiguration/Produced");

            Console.WriteLine("Consumed = " + consumed.InnerText);
            Console.WriteLine("Produced = " + produced.InnerText);
        }
    }
}
