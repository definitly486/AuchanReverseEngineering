using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Diagnostics;

[Designer("System.Diagnostics.Design.ProcessModuleDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public class ProcessModule : Component
{
	private readonly string _fileName;

	private readonly string _moduleName;

	[CompilerGenerated]
	private nint _003CEntryPointAddress_003Ek__BackingField;

	public string ModuleName => _moduleName;

	public string FileName => _fileName;

	public nint BaseAddress { get; internal set; }

	public int ModuleMemorySize { get; internal set; }

	internal nint EntryPointAddress
	{
		[CompilerGenerated]
		set
		{
			_003CEntryPointAddress_003Ek__BackingField = value;
		}
	}

	internal ProcessModule(string fileName, string moduleName)
	{
		_fileName = fileName;
		_moduleName = moduleName;
	}

	public override string ToString()
	{
		return base.ToString() + " (" + ModuleName + ")";
	}
}
