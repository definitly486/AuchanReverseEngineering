using System.Runtime.CompilerServices;

namespace System.Net;

public class Authorization
{
	private bool _mutualAuth;

	[CompilerGenerated]
	private readonly string _003CConnectionGroupId_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CComplete_003Ek__BackingField;

	public string? Message { get; }

	internal bool Complete
	{
		[CompilerGenerated]
		set
		{
			_003CComplete_003Ek__BackingField = value;
		}
	}

	public Authorization(string? token)
		: this(token, finished: true)
	{
	}

	public Authorization(string? token, bool finished)
		: this(token, finished, null)
	{
	}

	public Authorization(string? token, bool finished, string? connectionGroupId)
		: this(token, finished, connectionGroupId, mutualAuth: false)
	{
	}

	internal Authorization(string token, bool finished, string connectionGroupId, bool mutualAuth)
	{
		Message = (string.IsNullOrEmpty(token) ? null : token);
		_003CConnectionGroupId_003Ek__BackingField = (string.IsNullOrEmpty(connectionGroupId) ? null : connectionGroupId);
		Complete = finished;
		_mutualAuth = mutualAuth;
	}
}
