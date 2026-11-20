using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common;

namespace Auchan.Common.Controls.AutoLayout;

public class AutoLayoutScreenViewModel : ScreenViewModel
{
	[CompilerGenerated]
	private AutoLayoutViewModel _003CAutoLayout_003Ek__BackingField;

	public AutoLayoutViewModel AutoLayout
	{
		[CompilerGenerated]
		get
		{
			return _003CAutoLayout_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CAutoLayout_003Ek__BackingField, value))
			{
				_003CAutoLayout_003Ek__BackingField = value;
				RaisePropertyChanged("AutoLayout");
			}
		}
	} = new AutoLayoutViewModel();
}
public class AutoLayoutScreenViewModel<T> : ScreenViewModel<T> where T : BrokeredParameter
{
	public AutoLayoutViewModel AutoLayout
	{
		[CompilerGenerated]
		get
		{
			return _003CAutoLayout_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CAutoLayout_003Ek__BackingField, value))
			{
				_003CAutoLayout_003Ek__BackingField = value;
				RaisePropertyChanged("AutoLayout");
			}
		}
	} = new AutoLayoutViewModel();

	protected AutoLayoutScreenViewModel(BrokerToken parameter)
		: base(parameter)
	{
	}
}
