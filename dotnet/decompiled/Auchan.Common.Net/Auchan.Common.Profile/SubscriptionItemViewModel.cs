using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.PersonalCabinet.DomainModels;

namespace Auchan.Common.Profile;

public class SubscriptionItemViewModel : BaseItemViewModel
{
	[CompilerGenerated]
	private readonly SubscriptionTypeModel _003CType_003Ek__BackingField;

	[CompilerGenerated]
	private readonly SubscriptionCommunicationModel _003CCommType_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CEnabled_003Ek__BackingField;

	public required SubscriptionTypeModel Type
	{
		[CompilerGenerated]
		get
		{
			return _003CType_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (!object.Equals(_003CType_003Ek__BackingField, value))
			{
				_003CType_003Ek__BackingField = value;
				RaisePropertyChanged("Type");
			}
		}
	}

	public required SubscriptionCommunicationModel CommType
	{
		[CompilerGenerated]
		get
		{
			return _003CCommType_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (!object.Equals(_003CCommType_003Ek__BackingField, value))
			{
				_003CCommType_003Ek__BackingField = value;
				RaisePropertyChanged("SubscriptionTitle");
				RaisePropertyChanged("CommType");
			}
		}
	}

	public string SubscriptionTitle => SubscriptionNamesConverter.GetDisplayName(CommType.Title);

	public required bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return _003CEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CEnabled_003Ek__BackingField != value)
			{
				_003CEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("Enabled");
			}
		}
	}
}
