using Microsoft.AspNetCore.Http;

namespace TestRS.Core.Services;

public interface IArchiverService
{
    public byte[] ArchiveFile(IFormFile file);
}
