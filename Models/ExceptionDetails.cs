namespace LogAnalyticsAPI.Models
{
    public class ExceptionDetails
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string InnerExceptionStackTrace { get; set; }
    }
}
