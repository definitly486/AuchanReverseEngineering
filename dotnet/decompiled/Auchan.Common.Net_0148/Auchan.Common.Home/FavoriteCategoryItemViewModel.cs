using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Net;

namespace Auchan.Common.Home;

public class FavoriteCategoryItemViewModel : IBindable, INotifyPropertyChanged
{
	[CompilerGenerated]
	private readonly string _003CId_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CCode_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CDescription_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CName_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CImage_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CPreferenceType_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CPreferenceValue_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CSelected_003Ek__BackingField;

	public string Id
	{
		[CompilerGenerated]
		get
		{
			return _003CId_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (!string.Equals(_003CId_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CId_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Id);
			}
		}
	} = "";

	public string Code
	{
		[CompilerGenerated]
		get
		{
			return _003CCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (!string.Equals(_003CCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCode_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Code);
			}
		}
	} = "";

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return _003CDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (!string.Equals(_003CDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDescription_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Description);
			}
		}
	} = "";

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return _003CName_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (!string.Equals(_003CName_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CName_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Name);
			}
		}
	} = "";

	public string Image
	{
		[CompilerGenerated]
		get
		{
			return _003CImage_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (!string.Equals(_003CImage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CImage_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Image);
			}
		}
	} = "";

	public int PreferenceType
	{
		[CompilerGenerated]
		get
		{
			return _003CPreferenceType_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (_003CPreferenceType_003Ek__BackingField != value)
			{
				_003CPreferenceType_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.PreferenceValueText);
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.PreferenceType);
			}
		}
	}

	public int PreferenceValue
	{
		[CompilerGenerated]
		get
		{
			return _003CPreferenceValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (_003CPreferenceValue_003Ek__BackingField != value)
			{
				_003CPreferenceValue_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.PreferenceValueText);
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.PreferenceValue);
			}
		}
	}

	public string PreferenceValueText => $"{PreferenceValue}" + ((PreferenceType == 4) ? "%" : "");

	public bool Selected
	{
		[CompilerGenerated]
		get
		{
			return _003CSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSelected_003Ek__BackingField != value)
			{
				_003CSelected_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Selected);
			}
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	[GeneratedCode("PropertyChanged.Fody", "4.1.0.0")]
	[DebuggerNonUserCode]
	protected void _003C_003EOnPropertyChanged(PropertyChangedEventArgs eventArgs)
	{
		this.PropertyChanged?.Invoke(this, eventArgs);
	}
}
