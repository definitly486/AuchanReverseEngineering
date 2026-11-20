using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Profile.WaitList.Api;

namespace Auchan.Common.Profile;

public class CategoryItemWithCodeViewModel : BaseItemViewModel
{
	[CompilerGenerated]
	private bool _003CSelected_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CCode_003Ek__BackingField;

	[CompilerGenerated]
	private int? _003CCounter_003Ek__BackingField;

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

	public string? Title
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
				RaisePropertyChanged("Title");
			}
		}
	}

	public string? Code
	{
		[CompilerGenerated]
		get
		{
			return _003CCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCode_003Ek__BackingField = value;
				RaisePropertyChanged("Code");
			}
		}
	}

	public int? Counter
	{
		[CompilerGenerated]
		get
		{
			return _003CCounter_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!Nullable.Equals(_003CCounter_003Ek__BackingField, value))
			{
				_003CCounter_003Ek__BackingField = value;
				RaisePropertyChanged("Counter");
			}
		}
	}

	public CategoryItemWithCodeViewModel(WaitListDtos.WaitListCategoryPreview categoryPreview)
	{
		Title = categoryPreview.Name;
		Counter = categoryPreview.ProductsCounter;
		Code = categoryPreview.Code;
	}
}
