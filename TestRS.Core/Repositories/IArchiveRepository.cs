namespace TestRS.Core.Repositories;

public interface IArchiveRepository
{
    Task Add(Archive archive);
    Task<Archive?> GetArchiveById(Guid archiveId);
}
