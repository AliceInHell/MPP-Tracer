using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace TracerLibrary
{
    public class Serializer : ISerializer
    {
        private XmlSerializer newXmlFormatter = new XmlSerializer(typeof(TraceResult));

        public MemoryStream serializeToXml(TraceResult result)
        {
            MemoryStream ms = new MemoryStream();         
            newXmlFormatter.Serialize(ms, result);
            ms.Position = 0;

            return ms;
        }

        public MemoryStream serializeToJson(TraceResult result)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result, Formatting.Indented));
            return new MemoryStream(byteArray);
        }

        public TraceResult deserialize(MemoryStream ms)
        {
            return (TraceResult)newXmlFormatter.Deserialize(ms);
        }
    }
}
