using System.IO;
using System.Xml.Serialization;

namespace TracerLibrary
{
    public class XMLSerializer:ISerializer
    {
        private XmlSerializer xmlFormatter = new XmlSerializer(typeof(TraceResult));
        private int startPosition;
        public MemoryStream serialize(TraceResult traceResult)
        {
            MemoryStream memoryStream = new MemoryStream();
            xmlFormatter.Serialize(memoryStream,traceResult);
            memoryStream.Position = startPosition;
            return memoryStream;
        }
    }
}