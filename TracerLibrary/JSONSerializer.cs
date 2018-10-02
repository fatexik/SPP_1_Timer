using System.IO;
using System.Text;
using Newtonsoft.Json;
namespace TracerLibrary
{
    public class JSONSerializer:ISerializer
    {
        public MemoryStream serialize(TraceResult traceResult)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(traceResult, Formatting.Indented));
            return new MemoryStream(bytes);
        }
    }
}