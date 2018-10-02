using System.Threading;
using TracerLibrary;

namespace Tests
{
    public class TestClass
    {
        private ITracer _tracer;

        public TestClass(ITracer _tracer)
        {
            this._tracer = _tracer;
        }

        public void method()
        {
            _tracer.startTrace();
            Thread.Sleep(10);
            _tracer.stopTrace();
        }

        public void methodWithMethod()
        {
            _tracer.startTrace();
            Thread.Sleep(10);
            this.method();
            _tracer.stopTrace();
        }
    }
}