namespace Auchan.Common.Base.Errors.Domain;

public class NoDataError : DomainError
{
	public static NoDataError Empty { get; } = new NoDataError();
}
