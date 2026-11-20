using System;
using System.Runtime.CompilerServices;
using Java.Interop;

namespace Android.Content;

[Serializable]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class ContentProviderAttribute : Attribute, IJniNameProviderAttribute
{
	[CompilerGenerated]
	private string[] _003CAuthorities_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CExported_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CGrantUriPermissions_003Ek__BackingField;

	private string[] Authorities
	{
		[CompilerGenerated]
		set
		{
			_003CAuthorities_003Ek__BackingField = value;
		}
	}

	public bool Exported
	{
		[CompilerGenerated]
		set
		{
			_003CExported_003Ek__BackingField = value;
		}
	}

	public bool GrantUriPermissions
	{
		[CompilerGenerated]
		set
		{
			_003CGrantUriPermissions_003Ek__BackingField = value;
		}
	}

	public string? Name { get; set; }

	string IJniNameProviderAttribute.Name => Name ?? "";

	public ContentProviderAttribute(string[] authorities)
	{
		if (authorities == null)
		{
			throw new ArgumentNullException("authorities");
		}
		if (authorities.Length < 1)
		{
			throw new ArgumentException("At least one authority must be specified.", "authorities");
		}
		Authorities = authorities;
	}
}
