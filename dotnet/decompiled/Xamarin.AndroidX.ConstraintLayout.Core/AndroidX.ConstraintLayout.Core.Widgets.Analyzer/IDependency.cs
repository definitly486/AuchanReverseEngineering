using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/Dependency", "", "AndroidX.ConstraintLayout.Core.Widgets.Analyzer.IDependencyInvoker")]
public interface IDependency : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("update", "(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", "GetUpdate_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler:AndroidX.ConstraintLayout.Core.Widgets.Analyzer.IDependencyInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	void Update(IDependency? p0);
}
