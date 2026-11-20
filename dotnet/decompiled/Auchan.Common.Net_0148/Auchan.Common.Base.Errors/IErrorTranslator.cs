using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Base.Errors;

public interface IErrorTranslator
{
	(string title, string description) Translate<T>(T error) where T : DomainError;
}
