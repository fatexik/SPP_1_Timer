using System;
using System.Diagnostics;
using System.Threading;

namespace TracerLibrary
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;

        public Tracer()
        {
            _traceResult = new TraceResult();
        }

        public void startTrace()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            if (!_traceResult.threadsResults.ContainsKey(currentThreadId))
            {
                _traceResult.createNewThread(currentThreadId);
                _traceResult.threadsResults[currentThreadId].timer.Start();
            }
            else
            {
                if (_traceResult.threadsResults.Count > 0)
                {
                    MethodResult methodResult = _traceResult.getMethodsCurrentThread(currentThreadId);
                    StackFrame newFrame = new StackFrame(1);
                    string className = newFrame.GetMethod().DeclaringType.ToString();
                    string methodName = newFrame.GetMethod().Name;
                    methodResult.methodName = methodName;
                    methodResult.className = className;
                    methodResult.timer.Start();
                    _traceResult.threadsResults[currentThreadId].stack.Push(methodResult);
                }
            }
        }

        public void stopTrace()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            if (_traceResult.threadsResults.ContainsKey(currentThreadId))
            {
                int threadMethodsCount = _traceResult.threadsResults[currentThreadId].stack.Count;
                if (threadMethodsCount > 0)
                {
                    MethodResult methodResult = _traceResult.threadsResults[currentThreadId].stack.Pop();
                    methodResult.timer.Stop();
                    methodResult.time = methodResult.timer.ElapsedMilliseconds;
                }
                else
                {
                    if (threadMethodsCount == 0)
                    {
                        _traceResult.threadsResults[currentThreadId].timer.Stop();
                        _traceResult.threadsResults[currentThreadId].time =
                            _traceResult.threadsResults[currentThreadId].timer.ElapsedMilliseconds;
                    }
                }
            }
        }

        public TraceResult getTraceResult()
        {
            foreach (ThreadResult threadResult in _traceResult.threadsResults.Values)
            {
                _traceResult.threads.Add(threadResult);
            }

            return _traceResult;
        }
    }
}