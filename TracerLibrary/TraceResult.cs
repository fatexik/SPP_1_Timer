using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TracerLibrary
{
    [Serializable]
    [DataContract]
    public class TraceResult
    {
        [XmlIgnore] public ConcurrentDictionary<int, ThreadResult> threadsResults;
        [DataMember] public List<ThreadResult> threads;

        public void createNewThread(int keyThread)
        {
            threadsResults[keyThread] = new ThreadResult(keyThread);
            threads = new List<ThreadResult>();
        }

        public MethodResult getMethodsCurrentThread(int currentThreadId)
        {
            MethodResult currentMethodResult;
            ThreadResult currentThreadResult = this.threadsResults[currentThreadId];
            if (currentThreadResult.stack.Count > 0)
            {
                currentMethodResult = currentThreadResult.stack.Peek();
                currentMethodResult.methods = new List<MethodResult>();
                currentMethodResult.methods.Add(new MethodResult());
                return currentMethodResult.methods.First();
            }
            int currentThreadMethodsResultsLength;
            currentThreadResult.methodsResults.Add(new MethodResult());
            currentThreadMethodsResultsLength = currentThreadResult.methodsResults.Count;
            return currentThreadResult.methodsResults[currentThreadMethodsResultsLength - 1];
        }

        public TraceResult()
        {
            threadsResults = new ConcurrentDictionary<int, ThreadResult>();
        }
    }
}