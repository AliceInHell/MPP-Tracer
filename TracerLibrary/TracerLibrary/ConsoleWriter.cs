using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace TracerLibrary
{
    public interface IConsoleWriter
    {
        void consoleWrite(object o);
    }

    public class ConsoleWriter : IConsoleWriter
    {
        public XmlSerializer newXmlFormatter = new XmlSerializer();
        public DataContractJsonSerializer newJSONFormatter = new DataContractJsonSerializer();

        public void consoleWrite(object o)
        {
            newXmlFormatter.Serialize(Console.Out, o);
            newJSONFormatter.WriteObject(Console.Out, o);
        }
    }
}
