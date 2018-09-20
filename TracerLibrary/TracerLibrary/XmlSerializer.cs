using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace TracerLibrary
{
    public class XMLSerializer : ISerializer
    {
        private XmlSerializer newXmlFormatter = new XmlSerializer(typeof(TraceResult));

        public MemoryStream serialize(TraceResult result)
        {
            MemoryStream ms = new MemoryStream();         
            newXmlFormatter.Serialize(ms, result);
            ms.Position = 0;

            return ms;
        }

        public TraceResult deserialize(MemoryStream ms)
        {
            return (TraceResult)newXmlFormatter.Deserialize(ms);
        }
    }
}
