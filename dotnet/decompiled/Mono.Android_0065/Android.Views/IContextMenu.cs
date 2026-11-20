using System;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ContextMenu", "", "Android.Views.IContextMenuInvoker")]
public interface IContextMenu : IMenu, IJavaObject, IDisposable, IJavaPeerable
{
	void ClearHeader();

	IContextMenu? SetHeaderIcon(Drawable? icon);

	IContextMenu? SetHeaderIcon(int iconRes);

	IContextMenu? SetHeaderTitle(int titleRes);

	IContextMenu? SetHeaderTitle(ICharSequence? title);

	IContextMenu? SetHeaderView(View? view);
}
