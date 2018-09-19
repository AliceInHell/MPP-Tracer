using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TracerLibrary
{
    public interface ISerializer
    {
        MemoryStream serialize(TraceResult result);
    }
}
