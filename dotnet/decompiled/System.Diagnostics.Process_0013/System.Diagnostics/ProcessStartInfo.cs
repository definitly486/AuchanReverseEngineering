using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Diagnostics;

[DebuggerDisplay("FileName = {FileName}, Arguments = {BuildArguments()}, WorkingDirectory = {WorkingDirectory}")]
public sealed class ProcessStartInfo
{
	private string _fileName;

	private string _arguments;

	private string _directory;

	private Collection<string> _argumentList;

	public string Arguments => _arguments ?? string.Empty;

	internal bool HasArgumentList
	{
		get
		{
			if (_argumentList != null)
			{
				return _argumentList.Count != 0;
			}
			return false;
		}
	}

	[Editor("System.Diagnostics.Design.StartFileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string FileName
	{
		get
		{
			return _fileName ?? string.Empty;
		}
		[param: AllowNull]
		set
		{
			_fileName = value;
		}
	}

	[Editor("System.Diagnostics.Design.WorkingDirectoryEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string WorkingDirectory
	{
		get
		{
			return _directory ?? string.Empty;
		}
		[param: AllowNull]
		set
		{
			_directory = value;
		}
	}

	internal string BuildArguments()
	{
		if (HasArgumentList)
		{
			Span<char> initialBuffer = stackalloc char[256];
			System.Text.ValueStringBuilder stringBuilder = new System.Text.ValueStringBuilder(initialBuffer);
			AppendArgumentsTo(ref stringBuilder);
			return stringBuilder.ToString();
		}
		return Arguments;
	}

	internal void AppendArgumentsTo(ref System.Text.ValueStringBuilder stringBuilder)
	{
		if (_argumentList != null && _argumentList.Count > 0)
		{
			foreach (string argument in _argumentList)
			{
				System.PasteArguments.AppendArgument(ref stringBuilder, argument);
			}
			return;
		}
		if (!string.IsNullOrEmpty(Arguments))
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append(Arguments);
		}
	}
}
