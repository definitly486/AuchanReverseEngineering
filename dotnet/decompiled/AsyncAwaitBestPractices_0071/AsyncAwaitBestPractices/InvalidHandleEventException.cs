using System;
using System.Reflection;

namespace AsyncAwaitBestPractices;

public class InvalidHandleEventException : Exception
{
	public InvalidHandleEventException(string message, TargetParameterCountException targetParameterCountException)
		: base(message, targetParameterCountException)
	{
	}
}
