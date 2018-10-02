using System.IO;

namespace TracerLibrary
{
    public interface ISerializer
    {
        MemoryStream serialize(TraceResult traceResult);
    }
}