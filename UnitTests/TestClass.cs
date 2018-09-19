using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TracerLibrary;
using System.Threading;

namespace UnitTests
{
    public class TestClass
    {
        private ITracer _tracer;

        public TestClass(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void someMethod()
        {
            _tracer.StartTrace();

            Thread.Sleep(10);

            _tracer.StopTrace();
        }

        public void anotherMethod()
        {
            _tracer.StartTrace();

            Thread.Sleep(10);
            this.someMethod();

            _tracer.StopTrace();
        }
    }
}
