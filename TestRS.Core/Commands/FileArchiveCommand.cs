using MediatR;
using Microsoft.AspNetCore.Http;
using TestRS.Core.Responses;

namespace TestRS.Core.Commands;
public record FileArchiveCommand(IFormFile? File) : IRequest<UploadArchiveResponse>;