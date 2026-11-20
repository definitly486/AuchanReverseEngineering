using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.AppCompat.View.Menu;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/appcompat/view/menu/MenuView", "", "AndroidX.AppCompat.View.Menu.IMenuViewInvoker")]
public interface IMenuView : IJavaObject, IDisposable, IJavaPeerable
{
	int WindowAnimations
	{
		[Register("getWindowAnimations", "()I", "GetGetWindowAnimationsHandler:AndroidX.AppCompat.View.Menu.IMenuViewInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	[Register("initialize", "(Landroidx/appcompat/view/menu/MenuBuilder;)V", "GetInitialize_Landroidx_appcompat_view_menu_MenuBuilder_Handler:AndroidX.AppCompat.View.Menu.IMenuViewInvoker, Xamarin.AndroidX.AppCompat")]
	void Initialize(MenuBuilder? p0);
}
