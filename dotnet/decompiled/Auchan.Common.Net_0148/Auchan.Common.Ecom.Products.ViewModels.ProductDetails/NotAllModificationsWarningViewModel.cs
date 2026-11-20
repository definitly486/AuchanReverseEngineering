using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Products.ViewModels.ProductDetails;

public class NotAllModificationsWarningViewModel : NotifyPropertyChanged
{
	[CompilerGenerated]
	private bool _003CIsEnabled_003Ek__BackingField;

	public bool IsEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CIsEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsEnabled_003Ek__BackingField != value)
			{
				_003CIsEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("IsEnabled");
			}
		}
	}

	public string Text => "Выберите цвет и укажите размер для добавления в корзину!";
}
