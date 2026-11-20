using System;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public interface IDeferredLinkSupport
{
	Task<Result<Uri, DomainError>> GetAsync();
}
