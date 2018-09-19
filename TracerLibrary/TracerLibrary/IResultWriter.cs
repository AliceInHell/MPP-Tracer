using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TracerLibrary
{
    public interface IResultWriter
    {
        void write(MemoryStream ms);
    }
}
