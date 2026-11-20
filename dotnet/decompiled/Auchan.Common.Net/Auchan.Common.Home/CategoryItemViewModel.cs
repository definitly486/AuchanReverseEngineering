using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Ecom;

namespace Auchan.Common.Home;

public class CategoryItemViewModel : BaseItemViewModel
{
	[CompilerGenerated]
	private bool _003CIsExpanded_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsHighlighted_003Ek__BackingField;

	public Category Category { get; }

	public long Id => Category.Id;

	public string Title => Category.Name;

	public IReadOnlyList<Category> Categories => Category.Items;

	public string Code => Category.Code;

	public bool IsGradientColor => Category.Code == "tovary-dlya-dachi";

	public bool IsExpanded
	{
		[CompilerGenerated]
		get
		{
			return _003CIsExpanded_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsExpanded_003Ek__BackingField != value)
			{
				_003CIsExpanded_003Ek__BackingField = value;
				RaisePropertyChanged("IsExpanded");
			}
		}
	}

	public bool IsHighlighted
	{
		[CompilerGenerated]
		get
		{
			return _003CIsHighlighted_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsHighlighted_003Ek__BackingField != value)
			{
				_003CIsHighlighted_003Ek__BackingField = value;
				RaisePropertyChanged("IsHighlighted");
			}
		}
	}

	public CategoryItemViewModel(Category category)
	{
		Category = category;
	}
}
