using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Profile;

public class CategoryItemViewModel : BaseItemViewModel
{
	private const string ALL_CATEGORIES = "Все";

	[CompilerGenerated]
	private bool _003CSelected_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

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

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("IsAllCategories");
				RaisePropertyChanged("Title");
			}
		}
	}

	public bool IsAllCategories => Title == "Все";

	public CategoryItemViewModel(string title)
	{
		Title = title;
	}

	public static CategoryItemViewModel NewAllCategories()
	{
		return new CategoryItemViewModel("Все")
		{
			Selected = true
		};
	}
}
