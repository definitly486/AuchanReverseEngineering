using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet;

public interface IVkAuthService
{
	const string VK_ID = "54269263";

	const string VK_AUTH_SCHEME = "vk54269263";

	const string VK_AUTH_HOST = "vk.com";

	Task<Result<Unit, DomainError>> StartAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task ContinueLoginAsync(CancellationToken cancellationToken = default(CancellationToken));

	void SetIntermediateState(Uri? uri);

	void Init(IVkAuthViewModel visualStateModel);
}
