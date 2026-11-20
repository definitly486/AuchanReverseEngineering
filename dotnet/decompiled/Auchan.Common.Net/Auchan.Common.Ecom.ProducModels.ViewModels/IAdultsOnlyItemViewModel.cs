using System.ComponentModel;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.ProducModels.ViewModels;

public interface IAdultsOnlyItemViewModel : INotifyPropertyChanged, IBindable
{
	bool ShouldBlur { get; }

	string AdultsOnlyText => "Для лиц\nстарше 18 лет";
}
