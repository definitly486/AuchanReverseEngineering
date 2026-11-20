using Auchan.Common.Base;

namespace Auchan.Common.Common;

public interface IViewModelStateManager
{
	void Started(ScreenViewModel vm);

	void Resumed(ScreenViewModel vm);
}
