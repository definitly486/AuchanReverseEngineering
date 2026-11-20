using System.Collections.Generic;
using System.ComponentModel;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Products.Modifications;

public interface IModificationsViewModel : IBindable, INotifyPropertyChanged
{
	IReadOnlyList<IModificationItemViewModel> Modifications { get; }

	bool IsWarningVisible { get; }

	void WriteSelected(IModificationItemViewModel vmMod, ModificationValueViewModel vmVal);
}
