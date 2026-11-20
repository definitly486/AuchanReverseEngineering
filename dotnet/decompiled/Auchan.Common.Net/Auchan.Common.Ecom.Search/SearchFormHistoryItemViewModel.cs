using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Search;

public class SearchFormHistoryItemViewModel : ElementViewModel
{
	[CompilerGenerated]
	private string _003CText_003Ek__BackingField;

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return _003CText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CText_003Ek__BackingField = value;
				RaisePropertyChanged("Text");
			}
		}
	}

	public SearchFormHistoryItemViewModel(string text)
	{
		Text = text;
	}
}
