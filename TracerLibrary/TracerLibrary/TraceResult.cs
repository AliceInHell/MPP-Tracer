using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TracerLibrary
{
    [Serializable]
    [DataContract]
    public class TraceResult
    {
        [DataMember]
        public List<ThreadResult> threads;
    }
}
