using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Products.Gluings;

public class ProductGluingRowViewModel : BaseItemViewModel
{
	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private List<GluingValueViewModel> _003CValues_003Ek__BackingField;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	}

	public List<GluingValueViewModel> Values
	{
		[CompilerGenerated]
		get
		{
			return _003CValues_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CValues_003Ek__BackingField, value))
			{
				_003CValues_003Ek__BackingField = value;
				RaisePropertyChanged("Values");
			}
		}
	}

	public ProductGluingRowViewModel(string title, IEnumerable<GluingValueViewModel> values)
	{
		Title = title + ":";
		Values = values.ToList();
	}
}
