using System.Threading;
using TracerLibrary;

namespace ConsoleApplication1
{
    public class Kitchen
    {
        private ITracer _tracer;
        private Cook _cook;

        public Kitchen(ITracer tracer)
        {
            _tracer = tracer;
            _cook = new Cook(_tracer);
        }

        public void kitchenStart()
        {
            _tracer.startTrace();
            
            Thread.Sleep(8);
            
            _cook.cookFood();
            
            _tracer.stopTrace();
            
        }

        public void kitchenStop()
        {
            _tracer.startTrace();
            
            Thread.Sleep(8);
            
            _cook.cleanKitchen();
            
            _tracer.stopTrace();
            
        }
    }
}