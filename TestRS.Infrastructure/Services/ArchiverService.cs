using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using TestRS.Core.Services;

namespace TestRS.Infrastructure.Services;
public class ArchiverService : IArchiverService
{
    private readonly ILogger<ArchiverService> _logger;

    public ArchiverService(ILogger<ArchiverService> logger)
    {
        _logger = logger;
    }

    public byte[] ArchiveFile(IFormFile file)
    {
        _logger.LogInformation("Started archiving file");
        using (var memoryStream = new MemoryStream())
        {
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                var entry = archive.CreateEntry(file.FileName);
                using (var stream = entry.Open())
                {
                    file.CopyTo(stream);
                }
            }

            _logger.LogInformation("Finished archiving file");
            return memoryStream.ToArray();
        }
    }
}