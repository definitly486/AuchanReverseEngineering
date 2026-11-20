namespace System.Threading;

internal readonly struct NamedWaitHandleOptionsInternal
{
	private readonly NamedWaitHandleOptions _options;

	private readonly bool _wasSpecified;

	public bool CurrentUserOnly => _options.CurrentUserOnly;

	public bool CurrentSessionOnly => _options.CurrentSessionOnly;

	public bool WasSpecified => _wasSpecified;

	public NamedWaitHandleOptionsInternal(NamedWaitHandleOptions options)
	{
		_options = options;
		_wasSpecified = true;
	}

	public string GetNameWithSessionPrefix(string name)
	{
		if (!name.Contains('\\'))
		{
			if (!CurrentSessionOnly)
			{
				name = "Global\\" + name;
			}
			return name;
		}
		if ((!CurrentSessionOnly) ? (!name.StartsWith("Global\\", StringComparison.Ordinal)) : (!name.StartsWith("Local\\", StringComparison.Ordinal)))
		{
			throw new ArgumentException(SR.Format("NamedWaitHandles_IncompatibleNamePrefix", name), "name");
		}
		return name;
	}
}
