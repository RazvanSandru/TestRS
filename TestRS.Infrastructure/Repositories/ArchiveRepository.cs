using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using TestRS.Core;
using TestRS.Core.Repositories;
using TestRS.Infrastructure.Context;

namespace TestRS.Infrastructure.Repositories;
public class ArchiveRepository : IArchiveRepository
{
    private readonly DapperContext _dapperContext;
    private readonly ILogger<ArchiveRepository> _logger;

    public ArchiveRepository(DapperContext dapperContext, ILogger<ArchiveRepository> logger)
    {
        _dapperContext = dapperContext;
        _logger = logger;
    }

    public async Task Add(Archive archive)
    {
        _logger.LogInformation($"Started adding archive with id: {archive.Id} to database");
        var query = "INSERT INTO [RS].[dbo].[Archives] (Id, FileName, UploadedDate, ArchiveTimeInMiliseconds, Status, Data) " +
                "VALUES (@Id, @FileName, @UploadedDate, @ArchiveTimeInMiliseconds, @Status, @Data)";

        var parameters = new DynamicParameters();
        parameters.Add("Id", archive.Id, DbType.Guid);
        parameters.Add("FileName", archive.FileName, DbType.String);
        parameters.Add("UploadedDate", archive.UploadedDate, DbType.DateTime);
        parameters.Add("ArchiveTimeInMiliseconds", archive.ArchiveTime, DbType.Int32);
        parameters.Add("Status", archive.Status, DbType.Boolean);
        parameters.Add("Data", archive.Data, DbType.Binary);

        try
        {
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            throw;
        }

        _logger.LogInformation($"Finished adding archive with id: {archive.Id} to database");
    }

    public Task<Archive?> GetArchiveById(Guid archiveId)
    {
        throw new NotImplementedException();
    }
}
