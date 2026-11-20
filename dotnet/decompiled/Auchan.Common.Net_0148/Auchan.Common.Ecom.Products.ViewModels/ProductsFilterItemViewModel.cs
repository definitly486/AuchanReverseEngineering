using System.ComponentModel;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class ProductsFilterItemViewModel : ElementViewModel, INotifyPropertyChanged
{
	[CompilerGenerated]
	private bool _003CSelected_003Ek__BackingField;

	public string Title { get; }

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
				RaisePropertyChanged("Selected");
			}
		}
	}

	public int Count { get; }

	public string Code { get; }

	public ProductsFilterItemViewModel(string title, bool selected, int count, string code)
	{
		Title = title;
		Selected = selected;
		Count = count;
		Code = code;
	}
}
