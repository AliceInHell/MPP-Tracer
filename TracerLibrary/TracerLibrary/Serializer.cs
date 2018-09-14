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
        void serialize(object o);
    }

    public class Serializer : ISerializer
    {
        private const string xmlFilePath = "xmlResilt.xml";
        private const string jsonFilePath = "jsonResilt.json";
        private XmlSerializer newXmlFormatter = new XmlSerializer(typeof(TraceResult));
        private DataContractJsonSerializer newJsonFormatter = new DataContractJsonSerializer(typeof(TraceResult));

        public void serialize(object someObject)
        {
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.OpenOrCreate))
            {
                newXmlFormatter.Serialize(fs, someObject);
            }

            using (FileStream fs = new FileStream(jsonFilePath, FileMode.OpenOrCreate))
            {
                newJsonFormatter.WriteObject(fs, someObject);
            }
        }
    }
}
