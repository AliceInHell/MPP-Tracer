using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Diagnostics;

namespace TracerLibrary
{
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
        public List<MethodResult> methods;
    }
}
