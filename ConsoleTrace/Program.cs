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
        static void threadFunc(object tracer)
        {
            ((ITracer)tracer).StartTrace();

            Auto someCar = new Auto((ITracer)tracer);
            someCar.startDriving();

            ((ITracer)tracer).StopTrace();
        }

        static void Main(string[] args)
        {
            ITracer _tracer = new Tracer();

            //new thread
            Thread secondThread = new Thread(new ParameterizedThreadStart(threadFunc));
            secondThread.Start(_tracer);

            //lets work in this thread
            _tracer.StartTrace();

            Auto someCar = new Auto(_tracer);
            someCar.startDriving();
            someCar.stopDriving();

            _tracer.StopTrace();

            TraceResult result = _tracer.GetTraceResult();


            //output
            ResultWriter newWriter = new ResultWriter();
            Serializer newSerializer = new Serializer();
            newWriter.write(newSerializer.serializeToXml(result));
            Console.WriteLine();
            newWriter.write(newSerializer.serializeToJson(result));

            Console.ReadLine();
        }
    }
}
