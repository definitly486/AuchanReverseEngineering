using System;

namespace Auchan.Common.Base.Errors.Service;

public abstract class ServiceError : IServiceError
{
	public Exception? Exception { get; set; }

	public virtual string? Message { get; set; }

	public override string ToString()
	{
		return $"{GetType()} Message [{Message}] Exception [{Exception}]";
	}
}
