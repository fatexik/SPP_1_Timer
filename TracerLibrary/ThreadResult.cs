using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TracerLibrary
{
    public class ThreadResult
    {
        [DataMember] public int id;
        [DataMember] public long time;
        [XmlIgnore] public Stopwatch timer;
        [XmlIgnore] public Stack<MethodResult> stack;
        [DataMember] public List<MethodResult> methodsResults;

        public ThreadResult()
        {
            
        }
        
        public ThreadResult(int keyThread)
        {
            id = keyThread;
            timer = new Stopwatch();
            stack = new Stack<MethodResult>();
            methodsResults = new List<MethodResult>();
        }
    }
}