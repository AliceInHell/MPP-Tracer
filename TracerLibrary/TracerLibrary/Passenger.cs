using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            _glasses.wear();

            _tracer.StopTrace();
        }

        public void leaveAuto()
        {
            _tracer.StartTrace();

            _tracer.StopTrace();
        }
    }
}
