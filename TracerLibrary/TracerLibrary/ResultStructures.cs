using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TracerLibrary
{
    [Serializable]
    [DataContract]
    public class TraceResult
    {
        [DataMember]
        public ThreadResult[] threads;
    }

    [Serializable]
    [DataContract]
    public class ThreadResult
    {
        [DataMember]
        public int id;
        [DataMember]
        public long time;
        [XmlIgnore]
        public Stopwatch timer;
        [DataMember]
        public MethodResult[] methods;
    }

    [Serializable]
    [DataContract]
    public class MethodResult
    {
        [DataMember]
        public string methodName;
        [DataMember]
        public string className;
        [DataMember]
        public long time;
        [XmlIgnore]
        public Stopwatch timer;
        [DataMember]
        public MethodResult[] methods;
    }    
}
