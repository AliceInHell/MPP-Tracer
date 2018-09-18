using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace TracerLibrary
{
    public interface IResultWriter
    {
        void write(MemoryStream ms);
    }

    public class ResultWriter : IResultWriter
    {
        private const string tracerResults = "TracerResults.txt";

        public void write(MemoryStream ms)
        {
            StreamReader sr = new StreamReader(ms);
            Console.WriteLine(sr.ReadToEnd());

            using (FileStream fs = new FileStream(tracerResults, FileMode.OpenOrCreate))
            {
                ms.WriteTo(fs);
            }
        }
    }
}
