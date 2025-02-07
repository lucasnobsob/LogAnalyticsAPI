using LogAnalyticsAPI;
using LogAnalyticsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;

[ApiController]
[Route("api/logs")]
public class LogsController : ControllerBase
{
    private readonly IElasticClient _elasticClient;

    public LogsController(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    [HttpPost]
    public async Task<IActionResult> InsertLog([FromBody] LogEntry log)
    {
        var response = await _elasticClient.IndexDocumentAsync(log);
        return response.IsValid ? 
            Ok("Log inserido com sucesso!") : 
            BadRequest(response.OriginalException?.Message);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchLogs([FromQuery] string sourceFields)
    {
        var fields = sourceFields.Split(',');

        var searchResponse = await _elasticClient.SearchAsync<LogEntry>(s => s
            .Index("logs")
            .Source(src => src
                .Includes(i => i.Fields(fields)))
            .MatchAll());

        var filteredLogs = searchResponse.Documents.Select(log => Utils.GetSelectedProperties(log, fields)).ToList();
        return Ok(filteredLogs);
    }

    [HttpGet]
    public async Task<IActionResult> GetLogs()
    {
        var searchResponse = await _elasticClient.SearchAsync<LogEntry>(s => s
            .Query(q => q.MatchAll())
        );

        return Ok(searchResponse.Documents);
    }

}
