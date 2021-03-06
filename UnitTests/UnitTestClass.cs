﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TracerLibrary;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class UnitTestClass
    {
        private TestClass _testClass;
        private ITracer _tracer;

        [TestInitialize]
        public void SetUp()
        {
            _tracer = new Tracer();
            _testClass = new TestClass(_tracer);
        }

        [TestMethod]
        public void threadTimeTest()
        {
            _tracer.StartTrace();

            Thread.Sleep(10);

            _tracer.StopTrace();

            Assert.IsTrue(10 <= _tracer.GetTraceResult().threads[0].time);
        }

        [TestMethod]
        public void someMethodTimeTest()
        {
            _tracer.StartTrace();
            _testClass.someMethod();
            _tracer.StopTrace();

            Assert.IsTrue(10 <= _tracer.GetTraceResult().threads[0].methods[0].time);
        }

        [TestMethod]
        public void someMethodNameTest()
        {
            _tracer.StartTrace();
            _testClass.someMethod();
            _tracer.StopTrace();

            Assert.AreEqual("someMethod", _tracer.GetTraceResult().threads[0].methods[0].methodName);
        }

        [TestMethod]
        public void someMethodClassNameTest()
        {
            _tracer.StartTrace();
            _testClass.someMethod();
            _tracer.StopTrace();

            Assert.AreEqual("UnitTests.TestClass", _tracer.GetTraceResult().threads[0].methods[0].className);
        }

        [TestMethod]
        public void anotherMethodTimeTest()
        {
            TraceResult result = Measure(() => _testClass.anotherMethod());

            Assert.IsTrue(20 <= result.threads[0].methods[0].time);
        }

        public void insertedMethodNameTest()
        {
            Assert.AreEqual("anotherMethod", _tracer.GetTraceResult().threads[0].methods[1].methods[0].methodName);
        }

        public void insertedMethodClassNameTest()
        {
            Assert.AreEqual("anotherMethod", _tracer.GetTraceResult().threads[0].methods[1].methods[0].className);
        }

        public TraceResult Measure(Action action)
        {
            _tracer.StartTrace();
            action();
            _tracer.StopTrace();
            return _tracer.GetTraceResult();
        }
    }
}
