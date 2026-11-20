using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/TypedValues", "", "AndroidX.ConstraintLayout.Core.Motion.Utils.ITypedValuesInvoker")]
public interface ITypedValues : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("getId", "(Ljava/lang/String;)I", "GetGetId_Ljava_lang_String_Handler:AndroidX.ConstraintLayout.Core.Motion.Utils.ITypedValuesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	int GetId(string? p0);

	[Register("setValue", "(IZ)Z", "GetSetValue_IZHandler:AndroidX.ConstraintLayout.Core.Motion.Utils.ITypedValuesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	bool SetValue(int p0, bool p1);

	[Register("setValue", "(IF)Z", "GetSetValue_IFHandler:AndroidX.ConstraintLayout.Core.Motion.Utils.ITypedValuesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	bool SetValue(int p0, float p1);

	[Register("setValue", "(II)Z", "GetSetValue_IIHandler:AndroidX.ConstraintLayout.Core.Motion.Utils.ITypedValuesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	bool SetValue(int p0, int p1);

	[Register("setValue", "(ILjava/lang/String;)Z", "GetSetValue_ILjava_lang_String_Handler:AndroidX.ConstraintLayout.Core.Motion.Utils.ITypedValuesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	bool SetValue(int p0, string? p1);
}
