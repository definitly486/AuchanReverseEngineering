using System;
using Java.Interop;

namespace Android.Runtime;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface)]
public sealed class RegisterAttribute : Attribute, IJniNameProviderAttribute
{
	private string? connector;

	private string name;

	private string? signature;

	public string? Connector
	{
		get
		{
			return connector;
		}
		set
		{
			connector = value;
		}
	}

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public string? Signature
	{
		get
		{
			return signature;
		}
		set
		{
			signature = value;
		}
	}

	public bool DoNotGenerateAcw { get; set; }

	public int ApiSince { get; set; }

	public RegisterAttribute(string name)
	{
		this.name = name;
	}

	public RegisterAttribute(string name, string signature, string connector)
		: this(name)
	{
		this.connector = connector;
		this.signature = signature;
	}
}
