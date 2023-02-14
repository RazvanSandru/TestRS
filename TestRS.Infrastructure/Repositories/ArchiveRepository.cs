using TestRS.Core;
using TestRS.Core.Repositories;

namespace TestRS.Infrastructure.Repositories;
public class ArchiveRepository : IArchiveRepository
{
    public Task Add(Archive archive)
    {
        throw new NotImplementedException();
    }

    public Task<Archive?> GetArchiveById(Guid archiveId)
    {
        throw new NotImplementedException();
    }
}
