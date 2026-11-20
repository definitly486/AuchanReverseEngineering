using System;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/SubMenu", "", "Android.Views.ISubMenuInvoker")]
public interface ISubMenu : IMenu, IJavaObject, IDisposable, IJavaPeerable
{
	IMenuItem? Item { get; }

	void ClearHeader();

	ISubMenu? SetHeaderIcon(Drawable? icon);

	ISubMenu? SetHeaderIcon(int iconRes);

	ISubMenu? SetHeaderTitle(int titleRes);

	ISubMenu? SetHeaderTitle(ICharSequence? title);

	ISubMenu? SetHeaderView(View? view);

	ISubMenu? SetIcon(Drawable? icon);

	ISubMenu? SetIcon(int iconRes);
}
