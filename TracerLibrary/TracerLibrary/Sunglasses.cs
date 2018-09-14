using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            _tracer.StopTrace();
        }
    }
}
