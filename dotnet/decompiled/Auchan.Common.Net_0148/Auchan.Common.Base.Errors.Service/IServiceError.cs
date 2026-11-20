using System;

namespace Auchan.Common.Base.Errors.Service;

public interface IServiceError
{
	Exception? Exception { get; set; }

	string? Message { get; set; }
}
