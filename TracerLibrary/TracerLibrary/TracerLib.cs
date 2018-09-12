using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TracerLibrary
{
    public struct TraceResult
    {
        public string methodName;
        public string className;
        public long timeMs;
    }

    public interface ITracer
    {
        // вызывается в начале замеряемого метода
        void StartTrace();
​
        // вызывается в конце замеряемого метода
        void StopTrace();
​
        // получить результаты измерений
        TraceResult GetTraceResult();
    }

    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        private Stopwatch _stopWatch =  new Stopwatch();

        public void StartTrace()
        {
            _stopWatch.Start();
        }

        public void StopTrace()
        {
            _stopWatch.Stop();
        }

        public TraceResult GetTraceResult()
        {
            _traceResult.timeMs = _stopWatch.ElapsedMilliseconds;
            return this._traceResult;
        }
    }
}
