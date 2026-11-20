using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Controls.ListPicker;

public class ListPickerItemViewModel : BaseItemViewModel
{
	[CompilerGenerated]
	private bool _003CSelected_003Ek__BackingField;

	public string Text { get; }

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

	public ListPickerItemViewModel(string text, bool selected)
	{
		Text = text;
		Selected = selected;
	}
}
