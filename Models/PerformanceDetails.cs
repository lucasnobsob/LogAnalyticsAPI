namespace LogAnalyticsAPI.Models
{
    public class PerformanceDetails
    {
        public TimeSpan ExecutionTime { get; set; }  // Tempo de execução da operação
        public long MemoryUsage { get; set; }  // Memória usada pela operação (em bytes)
    }
}
