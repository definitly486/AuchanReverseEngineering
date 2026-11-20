using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.SupportChat.Models;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.SupportChat;

public interface IBeesenderFileUploader
{
	Task<Result<UploadFileResult, ServiceError>> UploadFileAsync(FileResult fileResult, CancellationToken cancellationToken = default(CancellationToken));
}
