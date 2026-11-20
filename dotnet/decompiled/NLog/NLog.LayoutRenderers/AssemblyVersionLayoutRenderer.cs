using System;
using System.Reflection;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("assembly-version")]
[ThreadAgnostic]
public class AssemblyVersionLayoutRenderer : LayoutRenderer
{
	private string? _default;

	private string _format = "major.minor.build.revision";

	private const string DefaultFormat = "major.minor.build.revision";

	private string? _assemblyVersion;

	[DefaultParameter]
	public string Name { get; set; } = string.Empty;

	public AssemblyVersionType Type { get; set; }

	public string Default
	{
		get
		{
			return _default ?? GenerateDefaultValue();
		}
		set
		{
			_default = value;
		}
	}

	public string Format
	{
		get
		{
			return _format;
		}
		set
		{
			_format = value?.ToLowerInvariant() ?? string.Empty;
		}
	}

	protected override void InitializeLayoutRenderer()
	{
		_assemblyVersion = null;
		base.InitializeLayoutRenderer();
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		string text = _assemblyVersion ?? (_assemblyVersion = ApplyFormatToVersion(GetVersion()));
		if (text == null)
		{
			text = GenerateDefaultValue();
		}
		builder.Append(text);
	}

	private string ApplyFormatToVersion(string version)
	{
		if (version == null)
		{
			return Default;
		}
		if (StringHelpers.IsNullOrWhiteSpace(version))
		{
			return Default;
		}
		if (version == "0.0.0.0" && _default != null)
		{
			return Default;
		}
		if (Format.Equals("major.minor.build.revision", StringComparison.OrdinalIgnoreCase))
		{
			return version;
		}
		string[] array = version.SplitAndTrimTokens('.');
		version = Format.Replace("major", array[0]).Replace("minor", (array.Length > 1) ? array[1] : "0").Replace("build", (array.Length > 2) ? array[2] : "0")
			.Replace("revision", (array.Length > 3) ? array[3] : "0");
		return version;
	}

	private string GenerateDefaultValue()
	{
		return string.Format("Could not find value for {0} assembly and version type {1}", string.IsNullOrEmpty(Name) ? "entry" : Name, Type);
	}

	private string GetVersion()
	{
		try
		{
			Assembly assembly = GetAssembly();
			return Type switch
			{
				AssemblyVersionType.File => assembly?.GetFirstCustomAttribute<AssemblyFileVersionAttribute>()?.Version ?? string.Empty, 
				AssemblyVersionType.Informational => assembly?.GetFirstCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? string.Empty, 
				_ => assembly?.GetName()?.Version?.ToString() ?? string.Empty, 
			};
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "${assembly-version} - Failed to load assembly {0}", new ReadOnlySpan<object>(new object[1] { Name }));
			if (ex.MustBeRethrown())
			{
				throw;
			}
			return string.Empty;
		}
	}

	protected virtual Assembly GetAssembly()
	{
		if (string.IsNullOrEmpty(Name))
		{
			return Assembly.GetEntryAssembly();
		}
		return Assembly.Load(new AssemblyName(Name));
	}
}
