using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TracerLibrary
{
    [Serializable]
    [DataContract]
    public class TraceResult
    {
        [XmlIgnore]
        public ConcurrentDictionary<int, ThreadResult> threads;

        [DataMember]
        public List<ThreadResult> Threads;
    }
}
