using System.ComponentModel;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.PersonalCabinet;

public interface IVkAuthViewModel : INotifyPropertyChanged
{
	VisualState State { get; set; }

	UICommand<BrokerToken> OpenVkSignUpCommand { get; }
}
