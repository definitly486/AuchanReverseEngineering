using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Core.Widgets;

[Register("androidx/constraintlayout/core/widgets/Helper", "", "AndroidX.ConstraintLayout.Core.Widgets.IHelperInvoker")]
public interface IHelper : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("add", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", "GetAdd_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler:AndroidX.ConstraintLayout.Core.Widgets.IHelperInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	void Add(ConstraintWidget? p0);

	[Register("removeAllIds", "()V", "GetRemoveAllIdsHandler:AndroidX.ConstraintLayout.Core.Widgets.IHelperInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	void RemoveAllIds();

	[Register("updateConstraints", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", "GetUpdateConstraints_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Handler:AndroidX.ConstraintLayout.Core.Widgets.IHelperInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	void UpdateConstraints(ConstraintWidgetContainer? p0);
}
