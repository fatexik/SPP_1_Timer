namespace TracerLibrary
{
    public interface ITracer
    {
        void startTrace();
        void stopTrace();
        TraceResult getTraceResult();
    }
}