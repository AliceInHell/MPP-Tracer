using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace TracerLibrary
{
    public interface ISerializer
    {
        MemoryStream serializeToXml(TraceResult result);
        MemoryStream serializeToJson(TraceResult result);
    }

    public class Serializer : ISerializer
    {
        private XmlSerializer newXmlFormatter = new XmlSerializer(typeof(TraceResult));
        private DataContractJsonSerializer newJsonFormatter = new DataContractJsonSerializer(typeof(TraceResult));

        public MemoryStream serializeToXml(TraceResult result)
        {
            MemoryStream ms = new MemoryStream();         
            newXmlFormatter.Serialize(ms, result);
            ms.Position = 0;

            return ms;
        }

        public MemoryStream serializeToJson(TraceResult result)
        {
            MemoryStream ms = new MemoryStream();
            newJsonFormatter.WriteObject(ms, result);
            ms.Position = 0;

            return ms;
        }
    }
}
