using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace TracerLibrary
{
    public class JSONSerializer : ISerializer
    {
        public MemoryStream serialize(TraceResult result)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result, Formatting.Indented));
            return new MemoryStream(byteArray);
        }
    }
}
