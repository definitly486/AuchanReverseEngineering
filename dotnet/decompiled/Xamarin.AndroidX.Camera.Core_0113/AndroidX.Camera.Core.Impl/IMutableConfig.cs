using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/MutableConfig", "", "AndroidX.Camera.Core.Impl.IMutableConfigInvoker")]
public interface IMutableConfig : IConfig, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("insertOption", "(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;Ljava/lang/Object;)V", "GetInsertOption_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_Ljava_lang_Object_Handler:AndroidX.Camera.Core.Impl.IMutableConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	void InsertOption(ConfigOption p0, ConfigOptionPriority p1, Java.Lang.Object? p2);

	[Register("insertOption", "(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V", "GetInsertOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_Handler:AndroidX.Camera.Core.Impl.IMutableConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	void InsertOption(ConfigOption p0, Java.Lang.Object? p1);

	[Register("removeOption", "(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;", "GetRemoveOption_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IMutableConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	Java.Lang.Object? RemoveOption(ConfigOption p0);
}
