using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TracerLibrary
{
    public struct TraceResult
    {
        string methodName;
        string className;
        int timeMs;
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
}
