using MediatR;
using Microsoft.Extensions.Logging;
using TestRS.Core.Queries;
using TestRS.Core.Repositories;
using TestRS.Core.Responses;

namespace TestRS.Web.Handlers;

public class GetArchiveQueryHandler : IRequestHandler<FileArchiveQuery, GetArchiveResponse>
{
    private readonly IArchiveRepository _archiveRepository;
    private readonly ILogger<GetArchiveQueryHandler> _logger;

    public GetArchiveQueryHandler(IArchiveRepository archiveRepository, ILogger<GetArchiveQueryHandler> logger)
    {
        _archiveRepository = archiveRepository;
        _logger = logger;
    }

    public async Task<GetArchiveResponse> Handle(FileArchiveQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Started handling FileArchiveQuery for file with id: {query.FileId}");
        try
        {
            var archive = await _archiveRepository.GetArchiveById(query.FileId);
            _logger.LogInformation($"Finished handling FileArchiveQuery for file with id: {query.FileId}");
            return new GetArchiveResponse(archive);
        }
        catch(Exception ex)
        {
            _logger.LogError($"Error while handling FileArchiveQuery, exception: {ex}");
            throw;
        }
    }
}
