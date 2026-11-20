using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Products.Gluings;

public class GluingValueViewModel : BaseItemViewModel
{
	[CompilerGenerated]
	private GluingValueState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CValue_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CProductCode_003Ek__BackingField;

	public GluingValueState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	}

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return _003CValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CValue_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CValue_003Ek__BackingField = value;
				RaisePropertyChanged("Value");
			}
		}
	}

	public string ProductCode
	{
		[CompilerGenerated]
		get
		{
			return _003CProductCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CProductCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CProductCode_003Ek__BackingField = value;
				RaisePropertyChanged("ProductCode");
			}
		}
	}

	public GluingValueViewModel(string value, string productCode, GluingValueState state)
	{
		Value = value;
		ProductCode = productCode;
		State = state;
	}
}
