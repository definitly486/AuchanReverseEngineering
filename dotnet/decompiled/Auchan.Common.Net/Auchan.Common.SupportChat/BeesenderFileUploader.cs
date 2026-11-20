using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Networking;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;
using Refit;

namespace Auchan.Common.SupportChat;

internal sealed class BeesenderFileUploader : IBeesenderFileUploader
{
	private const long FILE_LIMIT = 52428800L;

	private readonly IBeesenderFileServiseAPI _api;

	private readonly IRequestExecutor _requestExecutor;

	public BeesenderFileUploader(IBeesenderFileServiseAPI api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<UploadFileResult, ServiceError>> UploadFileAsync(FileResult fileResult, CancellationToken cancellationToken = default(CancellationToken))
	{
		using Stream stream = await fileResult.OpenReadAsync();
		if (stream.Length > 52428800)
		{
			return Result.SuccessIf<UploadFileResult, ServiceError>(isSuccess: false, (UploadFileResult)null, (ServiceError)new UnsuccessfulStatusCodeError<UploadFileResponseDTO>(HttpStatusCode.BadRequest, "emulated response: file too large", new UploadFileResponseDTO
			{
				Error = "Превышен допустимый объём"
			}));
		}
		string name = Path.GetFileNameWithoutExtension(fileResult.FullPath);
		string fileName = Path.GetFileName(fileResult.FullPath);
		StreamPart file = new StreamPart(stream, fileName, "application/octet-stream");
		return await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken ct) => _api.SendFileAsync(name, file.FileName, file, ct), 240, cancellationToken).Ensure((UploadFileResponseDTO x) => x.IsValid(), new ApiContractError()).Map((UploadFileResponseDTO x) => x.Map());
	}
}
