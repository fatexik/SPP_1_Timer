using System;
using System.Threading;
using NUnit.Framework;
using TracerLibrary;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private TestClass _testClass;
        private ITracer _tracer;

        [OneTimeSetUp]
        public void setUp()
        {
            _tracer = new Tracer();
            _testClass = new TestClass(_tracer);
        }
        
        [Test]
        public void Test1()
        {
            _tracer.startTrace();
            Thread.Sleep(10);
            _tracer.stopTrace();
            Assert.IsTrue(10<=_tracer.getTraceResult().threads[0].time);
        }

        [Test]
        public void Test2()
        {
            _tracer.startTrace();
            Thread.Sleep(10);
            _tracer.stopTrace();
            Assert.AreEqual("Test2", _tracer.getTraceResult().threads[0].methodsResults[0].methodName);
        }

        [Test]
        public void Test3()
        {
            _tracer.startTrace();
            Thread.Sleep(10);
            _testClass.method();
            _tracer.stopTrace();
            Assert.AreEqual("method",_tracer.getTraceResult().threads[0].methodsResults[0].methodName);
        }

        [Test]
        public void Test4()
        {
            _tracer.startTrace();
            Thread.Sleep(20);
            _testClass.method();
            _tracer.stopTrace();
            Assert.AreEqual("Tests.TestClass",_tracer.getTraceResult().threads[0].methodsResults[0].className);
        }

        [Test]
        public void Test5()
        {
            _tracer.startTrace();
            Thread.Sleep(20);
            _testClass.methodWithMethod();
            _tracer.stopTrace();
            Assert.AreEqual("method",_tracer.getTraceResult().threads[0].methodsResults[0].methods[0].methodName);
            Assert.AreEqual("Tests.TestClass",_tracer.getTraceResult().threads[0].methodsResults[0].methods[0].className);
        }
    }
}