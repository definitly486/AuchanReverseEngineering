using Auchan.Common.Common.Binding;

namespace Auchan.Common.Base;

public interface IScreenViewModel
{
	UICommand ResumeCommand { get; }

	UICommand PauseCommand { get; }

	bool IsActive { get; }
}
