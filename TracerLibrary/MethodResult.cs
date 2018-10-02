using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TracerLibrary
{
    [Serializable]
    [DataContract]
    public class MethodResult
    {
        [DataMember] public string methodName;
        [DataMember] public string className;
        [DataMember] public long time;
        [XmlIgnore] public Stopwatch timer;
        [DataMember] public List<MethodResult> methods;

        public MethodResult()
        {
            timer = new Stopwatch();
            methods = new List<MethodResult>();
        }
    }
}