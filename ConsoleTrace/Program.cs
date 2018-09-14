using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TracerLibrary;

namespace ConsoleTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer _tracer = new Tracer();

            _tracer.StartTrace();

            Auto someCar = new Auto(_tracer);
            someCar.startDrive();
            someCar.stopDriveing();

            _tracer.StopTrace();

            TraceResult result = _tracer.GetTraceResult();

        }
    }
}
