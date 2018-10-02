using System.Threading;
using TracerLibrary;

namespace ConsoleApplication1
{
    public class Cook
    {
        private ITracer _tracer;
        
        public Cook(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void cookFood()
        {
            _tracer.startTrace();
            Thread.Sleep(10);
            _tracer.stopTrace();
        }

        public void cleanKitchen()
        {
            _tracer.startTrace();
            Thread.Sleep(10);
            _tracer.stopTrace();
        }
    }
}