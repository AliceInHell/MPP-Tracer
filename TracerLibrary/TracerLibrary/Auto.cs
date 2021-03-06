﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

            Thread.Sleep(5);
            _passenger.enjoyDriving();

            _tracer.StopTrace();
        }

        public void stopDriving()
        {
            _tracer.StartTrace();

            Thread.Sleep(3);
            _passenger.leaveAuto();

            _tracer.StopTrace();
        }
    }
}
