using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;

namespace TracerLibrary
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        private object locker;

        public Tracer()
        {
            locker = new object();

            //structure initialization
            _traceResult = new TraceResult();
            _traceResult.threads = new ConcurrentDictionary<int, ThreadResult>();
        }

        public void StartTrace()
        {
            lock(locker)
            {
                int currentThreadId = Thread.CurrentThread.ManagedThreadId;

                //chooce thread from the array
                if (!_traceResult.threads.ContainsKey(currentThreadId))
                {
                    //unknown thread
                    //initialize thread, threadStack and threadTimer
                    _traceResult.threads[currentThreadId] = new ThreadResult();
                    _traceResult.threads[currentThreadId].id = currentThreadId;
                    _traceResult.threads[currentThreadId].timer = new Stopwatch();
                    _traceResult.threads[currentThreadId].stack = new Stack<MethodResult>();
                    _traceResult.threads[currentThreadId].methods = new List<MethodResult>();

                    //start trace
                    _traceResult.threads[currentThreadId].timer.Start();
                }
                else
                {
                    //define method we are in
                    StackFrame newFrame = new StackFrame(1);
                    string className = newFrame.GetMethod().DeclaringType.ToString();
                    string methodName = newFrame.GetMethod().Name;

                    //chooce method from the array using stack pionter
                    if (_traceResult.threads.Count > 0)
                    {
                        //if called some method from our thread
                        //pointer helps us to deside treePosition
                        MethodResult tmp;
                        if (_traceResult.threads[currentThreadId].stack.Count > 0)
                        {
                            tmp = _traceResult.threads[currentThreadId].stack.Peek();
                            tmp.methods = new List<MethodResult>();
                            tmp.methods.Add(new MethodResult());
                            tmp = tmp.methods[0];
                        }
                        else
                        {
                            _traceResult.threads[currentThreadId].methods.Add(new MethodResult());
                            tmp = _traceResult.threads[currentThreadId].methods[_traceResult.threads[currentThreadId].methods.Count - 1];
                        }
                        tmp.methodName = methodName;
                        tmp.className = className;
                        tmp.timer = new Stopwatch();
                        tmp.methods = new List<MethodResult>();

                        //start trace
                        tmp.timer.Start();

                        //push pointer to the Thread/Method-Result class with timer
                        _traceResult.threads[currentThreadId].stack.Push(tmp);
                    }
                }
            }
        }

        public void StopTrace()
        {
            lock(locker)
            {
                int currentThreadId = Thread.CurrentThread.ManagedThreadId;

                //chooce thread from the array
                if (_traceResult.threads.ContainsKey(currentThreadId))
                {
                    if (_traceResult.threads[currentThreadId].stack.Count > 0)
                    {
                        //exit from threadMethod

                        //pop pionter to stop timer and write result
                        MethodResult tmp = _traceResult.threads[currentThreadId].stack.Pop();
                        tmp.timer.Stop();
                        tmp.time = tmp.timer.ElapsedMilliseconds;
                    }
                    else
                    if (_traceResult.threads[currentThreadId].stack.Count == 0)
                    {
                        //exit from thread

                        //pop pionter to stop timer and write result
                        _traceResult.threads[currentThreadId].timer.Stop();
                        _traceResult.threads[currentThreadId].time = _traceResult.threads[currentThreadId].timer.ElapsedMilliseconds;
                    }
                }
            }
        }

        public TraceResult GetTraceResult()
        {
            XMLSerializer newSerializer = new XMLSerializer();
            lock (locker)
            {
                _traceResult.Threads = new List<ThreadResult>();
                foreach(ThreadResult threadResult in _traceResult.threads.Values)
                {
                    _traceResult.Threads.Add(threadResult);
                }
                return newSerializer.deserialize(newSerializer.serialize(_traceResult));
            }
        }
    }
}
