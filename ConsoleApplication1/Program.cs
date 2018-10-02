using System;
using System.Threading;
using TracerLibrary;

namespace ConsoleApplication1
{
    internal class Program
    {
        private const string path = "result.txt"; 
        public static void Main(string[] args)
        {
            ITracer tracer = new Tracer();

            Thread secondThread = new Thread(() => newThread(tracer));

            secondThread.Start();

            tracer.startTrace();

            Kitchen kitchen = new Kitchen(tracer);

            kitchen.kitchenStart();

            kitchen.kitchenStop();

            tracer.stopTrace();

            TraceResult traceResult = tracer.getTraceResult();
            XMLSerializer xmlSerializer = new XMLSerializer();
            JSONSerializer jsonSerializer = new JSONSerializer();
            Writer writer = new Writer(path);
            writer.writeResult(jsonSerializer.serialize(traceResult));
            writer.writeResult(xmlSerializer.serialize(traceResult));
        }

        static void newThread(ITracer tracer)
        {
            tracer.startTrace();

            Kitchen kitchen = new Kitchen(tracer);

            kitchen.kitchenStart();

            kitchen.kitchenStop();

            tracer.stopTrace();
        }
    }
}