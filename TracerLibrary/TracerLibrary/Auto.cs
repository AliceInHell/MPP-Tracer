using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TracerLibrary
{
    public class Auto
    {
        private ITracer _tracer;
        private Passenger _passenger;

        public Auto(ITracer tracer)
        {
            _tracer = tracer;
            _passenger = new Passenger(_tracer);
        }

        public void startDriving()
        {
            _tracer.StartTrace();

            _passenger.enjoyDriving();

            _tracer.StopTrace();
        }

        public void stopDriving()
        {
            _tracer.StartTrace();

            _passenger.leaveAuto();

            _tracer.StopTrace();
        }
    }
}
