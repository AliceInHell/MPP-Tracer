using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TracerLibrary
{
    public class Passenger
    {
        private ITracer _tracer;
        private Sunglasses _glasses;

        public Passenger(ITracer tracer)
        {
            _glasses = new Sunglasses(tracer);
            _tracer = tracer;
        }

        public void enjoyDriving()
        {
            _tracer.StartTrace();

            Thread.Sleep(7);
            _glasses.wear();

            _tracer.StopTrace();
        }

        public void leaveAuto()
        {
            _tracer.StartTrace();

            Thread.Sleep(2);

            _tracer.StopTrace();
        }
    }
}
