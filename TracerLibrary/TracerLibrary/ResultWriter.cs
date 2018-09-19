using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TracerLibrary
{
    public class ResultWriter : IResultWriter
    {
        private const string tracerResults = "TracerResults.txt";

        public void write(MemoryStream ms)
        {
            StreamReader sr = new StreamReader(ms);
            Console.WriteLine(sr.ReadToEnd());

            using (FileStream fs = new FileStream(tracerResults, FileMode.Append))
            {
                ms.WriteTo(fs);
            }
        }
    }
}
