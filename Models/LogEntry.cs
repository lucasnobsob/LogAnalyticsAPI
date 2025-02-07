namespace LogAnalyticsAPI.Models
{
    public class LogEntry
    {
        public string Message { get; set; }
        public string Level { get; set; }  // Ex: "Info", "Warning", "Error"
        public DateTime Timestamp { get; set; }
        public string ApplicationName { get; set; }
        public string Environment { get; set; }  // Ex: "Development", "Production"
        public string RequestId { get; set; }  // Caso você queira rastrear cada requisição
        public string UserId { get; set; }  // Id do usuário, se disponível
        public string IpAddress { get; set; }  // IP de origem, se necessário
        public string Url { get; set; }  // URL da requisição, útil para logs de web
        public string HttpMethod { get; set; }  // Método HTTP (GET, POST, etc.)

        // Informações de exceção
        public ExceptionDetails Exception { get; set; }  // Detalhes de uma exceção, caso ocorra

        // Dados de Performance
        public PerformanceDetails Performance { get; set; }  // Dados de tempo e recursos consumidos

        // Outros campos que podem ser úteis
        public string ThreadId { get; set; }  // Id do thread de execução
        public Dictionary<string, string> CustomFields { get; set; }
    }
}
