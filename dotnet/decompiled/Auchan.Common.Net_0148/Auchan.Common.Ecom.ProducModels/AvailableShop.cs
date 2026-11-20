using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Auchan.Common.Net;

namespace Auchan.Common.Ecom.ProducModels;

public class AvailableShop : INotifyPropertyChanged
{
	[CompilerGenerated]
	private int? _003CId_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CName_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CAddressString_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CApplied_003Ek__BackingField;

	[CompilerGenerated]
	private decimal? _003CQty_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CWorking_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsLessOrEqualTwo_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CQtyText_003Ek__BackingField;

	public int? Id
	{
		[CompilerGenerated]
		get
		{
			return _003CId_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!Nullable.Equals(_003CId_003Ek__BackingField, value))
			{
				_003CId_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Id);
			}
		}
	}

	public string? Name
	{
		[CompilerGenerated]
		get
		{
			return _003CName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CName_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CName_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Name);
			}
		}
	}

	public string? AddressString
	{
		[CompilerGenerated]
		get
		{
			return _003CAddressString_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CAddressString_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddressString_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.AddressString);
			}
		}
	}

	public bool Applied
	{
		[CompilerGenerated]
		get
		{
			return _003CApplied_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CApplied_003Ek__BackingField != value)
			{
				_003CApplied_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Applied);
			}
		}
	}

	public decimal? Qty
	{
		[CompilerGenerated]
		get
		{
			return _003CQty_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!Nullable.Equals(_003CQty_003Ek__BackingField, value))
			{
				_003CQty_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Qty);
			}
		}
	}

	public string? Working
	{
		[CompilerGenerated]
		get
		{
			return _003CWorking_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CWorking_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CWorking_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.Working);
			}
		}
	}

	public bool IsLessOrEqualTwo
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLessOrEqualTwo_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsLessOrEqualTwo_003Ek__BackingField != value)
			{
				_003CIsLessOrEqualTwo_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.IsLessOrEqualTwo);
			}
		}
	}

	public string? QtyText
	{
		[CompilerGenerated]
		get
		{
			return _003CQtyText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CQtyText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CQtyText_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.QtyText);
			}
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	[GeneratedCode("PropertyChanged.Fody", "4.1.0.0")]
	[DebuggerNonUserCode]
	protected void _003C_003EOnPropertyChanged(PropertyChangedEventArgs? eventArgs)
	{
		this.PropertyChanged?.Invoke(this, eventArgs);
	}
}
