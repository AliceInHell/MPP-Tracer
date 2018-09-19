using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TracerLibrary
{
    public class Sunglasses
    {
        private ITracer _tracer;

        public Sunglasses(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void wear()
        {
            _tracer.StartTrace();

            Thread.Sleep(9);
            
            _tracer.StopTrace();
        }
    }
}
