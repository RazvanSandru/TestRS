using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TestRS.Core.Commands;
using TestRS.Core.Repositories;
using TestRS.Core.Responses;
using TestRS.Core.Services;

namespace TestRS.Core.Handlers;

public class UploadFileCommandHandler : IRequestHandler<FileArchiveCommand, UploadArchiveResponse>
{
    private readonly IArchiverService _archiverService;
    private readonly IArchiveRepository _archiveRepository;
    private readonly ILogger<UploadFileCommandHandler> _logger;

    public UploadFileCommandHandler(
        IArchiverService archiverService,
        IArchiveRepository archiveRepository,
        ILogger<UploadFileCommandHandler> logger)
    {
        _archiverService = archiverService;
        _archiveRepository = archiveRepository;
        _logger = logger;
    }
    public async Task<UploadArchiveResponse> Handle(FileArchiveCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        _logger.LogInformation($"Started handling FileArchiveCommand for file with id: {id}");

        var isSuccess = false;
        var file = command.File;
        var archive = new Archive();

        try
        {
            var stopWatch = Stopwatch.StartNew();
            var archivedFile = _archiverService.ArchiveFile(command.File!);
            archive.Id = id;
            archive.ArchiveTime = (int)stopWatch.ElapsedMilliseconds;
            archive.FileName = file.FileName;
            archive.UploadedDate = DateTime.Now;
            archive.Status = true;
            archive.Data = archivedFile;

            await _archiveRepository.Add(archive);
            isSuccess = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            throw;
        }

        return new UploadArchiveResponse(archive.Id, isSuccess);
    }
}
