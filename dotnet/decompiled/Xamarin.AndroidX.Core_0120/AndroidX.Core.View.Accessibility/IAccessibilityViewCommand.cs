using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace AndroidX.Core.View.Accessibility;

[Register("androidx/core/view/accessibility/AccessibilityViewCommand", "", "AndroidX.Core.View.Accessibility.IAccessibilityViewCommandInvoker")]
public interface IAccessibilityViewCommand : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("perform", "(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityViewCommand$CommandArguments;)Z", "GetPerform_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityViewCommand_CommandArguments_Handler:AndroidX.Core.View.Accessibility.IAccessibilityViewCommandInvoker, Xamarin.AndroidX.Core")]
	bool Perform(Android.Views.View? view, AccessibilityViewCommandCommandArguments? arguments);
}
