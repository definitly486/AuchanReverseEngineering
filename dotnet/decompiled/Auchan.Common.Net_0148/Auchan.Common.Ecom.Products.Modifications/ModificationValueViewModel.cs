using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Products.Modifications;

public class ModificationValueViewModel : BaseItemViewModel
{
	private readonly Subject<ModificationValueViewModel> _select = new Subject<ModificationValueViewModel>();

	[CompilerGenerated]
	private bool _003CSelected_003Ek__BackingField;

	public ProductModificationValue Value { get; }

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

	public IReadOnlyList<string> ImageUrls => Value.ImageUrls;

	public string Text => Value.Description;

	public string Key => Value.Key;

	public string Preview => Value.PreviewImageUrl;

	public IObservable<ModificationValueViewModel> OnSelect => _select.Debounce();

	public ModificationValueViewModel(ProductModificationValue value, bool selected)
	{
		Value = value;
		Selected = selected;
	}

	public void Tap()
	{
		Selected = true;
		_select.OnNext(this);
	}
}
