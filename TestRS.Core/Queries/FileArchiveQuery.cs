using MediatR;
using TestRS.Core.Responses;

namespace TestRS.Core.Queries;

public record FileArchiveQuery(Guid FileId) : IRequest<GetArchiveResponse>;