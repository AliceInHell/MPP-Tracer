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
        void write(object o);
    }

    public class ConsoleWriter : IConsoleWriter
    {
        private XmlSerializer newXmlFormatter = new XmlSerializer(typeof(TraceResult));
        private DataContractJsonSerializer newJSONFormatter = new DataContractJsonSerializer(typeof(TraceResult));

        public void write(object o)
        {
            newXmlFormatter.Serialize(Console.Out, o);
            //newJSONFormatter.WriteObject(Console.Out, o);
        }
    }
}
