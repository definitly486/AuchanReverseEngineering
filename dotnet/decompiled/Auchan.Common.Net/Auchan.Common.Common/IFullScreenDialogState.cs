using System;

namespace Auchan.Common.Common;

public interface IFullScreenDialogState
{
	bool IsVisible { get; }

	IDisposable SetVisible();
}
