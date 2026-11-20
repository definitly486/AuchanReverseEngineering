using System.Collections.ObjectModel;
using System.ComponentModel;
using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Products.Modifications;

public interface IModificationItemViewModel : IBindable, INotifyPropertyChanged
{
	string ModificationTitle { get; }

	string ModificationValue { get; }

	string ModificationHint { get; }

	bool IsValueSelected { get; }

	ObservableRangeCollection<ModificationValueViewModel> Values { get; }

	ProductModification Modification { get; }

	void OnSelectValue(ModificationValueViewModel selected);
}
