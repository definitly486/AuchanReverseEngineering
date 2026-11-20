using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public sealed class DeferredLinkError : DomainError
{
	public required object NativeError { get; init; }

	public override string ToString()
	{
		return NativeError.ToString() ?? "";
	}
}
