using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Products.Modifications;

public class ProductModificationItemViewModel : BaseItemViewModel, IModificationItemViewModel, IBindable, INotifyPropertyChanged
{
	[CompilerGenerated]
	private bool _003CIsValueSelected_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CModificationValue_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CModificationHint_003Ek__BackingField;

	public ProductModification Modification { get; }

	public bool IsValueSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CIsValueSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsValueSelected_003Ek__BackingField != value)
			{
				_003CIsValueSelected_003Ek__BackingField = value;
				RaisePropertyChanged("IsValueSelected");
			}
		}
	}

	public string ModificationValue
	{
		[CompilerGenerated]
		get
		{
			return _003CModificationValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CModificationValue_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CModificationValue_003Ek__BackingField = value;
				RaisePropertyChanged("ModificationValue");
			}
		}
	}

	public string ModificationHint
	{
		[CompilerGenerated]
		get
		{
			return _003CModificationHint_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CModificationHint_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CModificationHint_003Ek__BackingField = value;
				RaisePropertyChanged("ModificationHint");
			}
		}
	}

	public string ModificationTitle => Modification.Name + ":";

	public ObservableRangeCollection<ModificationValueViewModel> Values { get; } = new ObservableRangeCollection<ModificationValueViewModel>();

	public ProductModificationItemViewModel(ProductModification modification, Func<ProductModificationValue, bool, ICollection<IDisposable>, ModificationValueViewModel> viewModelFactory)
	{
		ProductModificationItemViewModel productModificationItemViewModel = this;
		Modification = modification;
		ModificationValue = "не выбрано";
		ModificationHint = "выберите " + modification.Name.ToLower();
		Values.ReplaceRange(modification.Values.Select((ProductModificationValue c) => viewModelFactory(c, arg2: false, productModificationItemViewModel.Disposables)));
	}

	public void OnSelectValue(ModificationValueViewModel selected)
	{
		IsValueSelected = true;
		ModificationValue = selected.Text.ToLower();
		Values.Where((ModificationValueViewModel vm) => vm != selected).ToList().ForEach(delegate(ModificationValueViewModel c)
		{
			c.Selected = false;
		});
	}
}
