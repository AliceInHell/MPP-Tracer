﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace TracerLibrary
{
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
        private Stack<Object>[] tracerStack;

        public Tracer()
        {
            //structure initialization
            tracerStack[0] = new Stack<Object>();
            _traceResult = new TraceResult();
            _traceResult.threads[0] = new ThreadResult();
        }

        public void StartTrace()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            int i = 0;

            //chooce thread from the array
            while (i < _traceResult.threads.Length && _traceResult.threads[i].id != currentThreadId)
                i++;

            if (i == _traceResult.threads.Length)
            {
                //unknown thread
                //initialize thread, threadStack and threadTimer
                _traceResult.threads[i].id = currentThreadId;
                _traceResult.threads[i].timer = new Stopwatch();
                _traceResult.threads[i].methods[0] = new MethodResult();

                //start trace
                _traceResult.threads[i].timer.Start();

                //push pointer to the Thread/Method-Result class with timer
                tracerStack[i].Push(_traceResult.threads[i]);
            }
            else
            {
                //define method we are in
                StackFrame newFrame = new StackFrame(1);
                string className = newFrame.GetMethod().DeclaringType.ToString();
                string methodName = newFrame.GetMethod().Name;

                //chooce method from the array using stack pionter
                if (tracerStack[i].Count > 1)
                {
                    //if called some method from our thread
                    int j = ((MethodResult)tracerStack[i].Peek()).methods.Length;        //pointer helps us to deside treePosition
                    ((MethodResult)tracerStack[i].Peek()).methods[j] = new MethodResult();
                    ((MethodResult)tracerStack[i].Peek()).methods[j].methodName = methodName;
                    ((MethodResult)tracerStack[i].Peek()).methods[j].className = className;
                    ((MethodResult)tracerStack[i].Peek()).methods[j].timer = new Stopwatch();

                    //start trace
                    ((MethodResult)tracerStack[i].Peek()).methods[j].timer.Start();

                    //push pointer to the Thread/Method-Result class with timer
                    tracerStack[i].Push(((MethodResult)tracerStack[i].Peek()).methods[j]);
                }
                else
                    throw new Exception("");

            }
        }

        public void StopTrace()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            int i = 0;

            //chooce thread from the array
            while (i < _traceResult.threads.Length && _traceResult.threads[i].id != currentThreadId)
                i++;

            if (tracerStack[i].Count > 1)
            {
                //exit from threadMethod

                //pop pionter to stop timer and write result
                MethodResult tmp = (MethodResult)tracerStack[i].Pop();
                tmp.timer.Stop();
                tmp.time = tmp.timer.ElapsedMilliseconds;
            }
            else
            if (tracerStack[i].Count == 1)
            {
                //exit from thread

                //pop pionter to stop timer and write result
                ThreadResult tmp = (ThreadResult)tracerStack[i].Pop();
                tmp.timer.Stop();
                tmp.time = tmp.timer.ElapsedMilliseconds;
            }
            else
                throw new Exception("");

        }

        public TraceResult GetTraceResult()
        {
            return this._traceResult;
        }
    }
}