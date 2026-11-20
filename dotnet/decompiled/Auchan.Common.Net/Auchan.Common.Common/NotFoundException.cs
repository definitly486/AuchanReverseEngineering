using System;

namespace Auchan.Common.Common;

public class NotFoundException : Exception
{
	public NotFoundException(string message)
		: base(message)
	{
	}
}
