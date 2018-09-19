using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TracerLibrary;
using System.Threading;

namespace ConsoleTrace
{
    class Program
    {
        static void threadFunc(ITracer tracer)
        {
            tracer.StartTrace();

            Auto someCar = new Auto(tracer);
            someCar.startDriving();

            tracer.StopTrace();
        }

        static void Main(string[] args)
        {
            ITracer _tracer = new Tracer();

            //new thread
            Thread secondThread = new Thread(() => threadFunc(_tracer));
            secondThread.Start();

            //lets work in this thread
            _tracer.StartTrace();

            Auto someCar = new Auto(_tracer);
            someCar.startDriving();
            someCar.stopDriving();

            _tracer.StopTrace();

            TraceResult result = _tracer.GetTraceResult();


            //output
            ResultWriter newWriter = new ResultWriter();
            XMLSerializer newXMLSerializer = new XMLSerializer();
            JSONSerializer newJSONSerializer = new JSONSerializer();
            newWriter.write(newXMLSerializer.serialize(result));
            Console.WriteLine();
            newWriter.write(newJSONSerializer.serialize(result));

            Console.ReadLine();
        }
    }
}
