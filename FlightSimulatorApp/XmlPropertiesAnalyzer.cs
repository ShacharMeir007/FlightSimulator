using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace FlightSimulatorApp
{
    public class XmlPropertiesAnalyzer
    {
        private List<string> getCommends;
        private List<string> propertiesOrder;
        private char _delimiter;

        public char Delimiter
        {
            get => _delimiter;
            set => _delimiter = value;
        }

        public List<string> GetCommends
        {
            get => getCommends;
            set => getCommends = value;
        }

        public List<string> PropertiesOrder
        {
            get => propertiesOrder;
            set => propertiesOrder = value;
        }

        

        public XmlPropertiesAnalyzer()
        {
            getCommends = new List<string>();
            propertiesOrder = new List<string>();
            Analyze();
        }

        private void Analyze()
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {

                xmlDocument.Load("Properties.xml");
            }
            catch (Exception e)
            {
                Console.Error.Write(e);
            }

            if (xmlDocument.DocumentElement != null)
            {
                foreach (XmlNode node in xmlDocument.DocumentElement)
                {
                    if (node.Name == "Delimiter")
                    {
                        this.Delimiter = node.InnerText[0];
                    }
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        switch (child.Name)
                        {
                            case "name":
                                propertiesOrder.Add(child.InnerText);
                                break;
                            case "node":
                                getCommends.Add("get " + child.InnerText);
                                break;
                            default:
                                Console.WriteLine("type: " + child.Name + " value: " + child.InnerText);
                                break;
                        }
                    }
                }
            }
        }
    }
}