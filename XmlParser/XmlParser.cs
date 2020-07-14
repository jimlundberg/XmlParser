using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;

namespace XmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load("C:\\Temp\\Test.xml");

            // Get the .xml top node name
            XmlElement root = XmlDoc.DocumentElement;
            String TopNode = root.LocalName;

            XmlNode ConsumedNode = XmlDoc.DocumentElement.SelectSingleNode("/" + TopNode + "/FileConfiguration/Consumed");
            XmlNode ProducedNode = XmlDoc.DocumentElement.SelectSingleNode("/" + TopNode + "/FileConfiguration/Produced");
            XmlNode TransferedNode = XmlDoc.DocumentElement.SelectSingleNode("/" + TopNode + "/FileConfiguration/Transfered");

            int NumFilesConsumed = Convert.ToInt32(ConsumedNode.InnerText);
            int NumFilesProduced = Convert.ToInt32(ProducedNode.InnerText);
            int NumFilesToTransfer = Convert.ToInt32(TransferedNode.InnerText);

            Console.WriteLine("Number of files Consumed = " + NumFilesConsumed);
            Console.WriteLine("Number of files Produced = " + NumFilesProduced);
            Console.WriteLine("Number of files to Transfer = " + NumFilesToTransfer);

            List<string> TransferedFiles = new List<string>(NumFilesToTransfer);
            List<XmlNode> TransFeredFileXml = new List<XmlNode>();
            for (int i = 1; i < NumFilesToTransfer + 1; i++)
            {
                TransferedFiles.Add("/CONFIG_3155301-034/FileConfiguration/Transfered" + i.ToString());
                XmlNode TransferedFileXml = XmlDoc.DocumentElement.SelectSingleNode(TransferedFiles[i-1]);
                Console.WriteLine("Transfered" + i + " = " + TransferedFileXml.InnerText);
            }

            Console.ReadKey();
        }
    }
}
