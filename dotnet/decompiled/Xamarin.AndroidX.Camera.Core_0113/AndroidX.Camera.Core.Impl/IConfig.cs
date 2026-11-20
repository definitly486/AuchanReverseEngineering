using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Config", "", "AndroidX.Camera.Core.Impl.IConfigInvoker")]
public interface IConfig : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Config", typeof(IConfig), isInterface: true);

	[Register("containsOption", "(Landroidx/camera/core/impl/Config$Option;)Z", "GetContainsOption_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	bool ContainsOption(ConfigOption p0);

	[Register("findOptions", "(Ljava/lang/String;Landroidx/camera/core/impl/Config$OptionMatcher;)V", "GetFindOptions_Ljava_lang_String_Landroidx_camera_core_impl_Config_OptionMatcher_Handler:AndroidX.Camera.Core.Impl.IConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	void FindOptions(string p0, IConfigOptionMatcher p1);

	[Register("getOptionPriority", "(Landroidx/camera/core/impl/Config$Option;)Landroidx/camera/core/impl/Config$OptionPriority;", "GetGetOptionPriority_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	ConfigOptionPriority GetOptionPriority(ConfigOption p0);

	[Register("getPriorities", "(Landroidx/camera/core/impl/Config$Option;)Ljava/util/Set;", "GetGetPriorities_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	ICollection<ConfigOptionPriority> GetPriorities(ConfigOption p0);

	[Register("listOptions", "()Ljava/util/Set;", "GetListOptionsHandler:AndroidX.Camera.Core.Impl.IConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	ICollection<ConfigOption> ListOptions();

	[Register("retrieveOption", "(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;", "GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	Java.Lang.Object? RetrieveOption(ConfigOption p0);

	[Register("retrieveOption", "(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)Ljava/lang/Object;", "GetRetrieveOption_Landroidx_camera_core_impl_Config_Option_Ljava_lang_Object_Handler:AndroidX.Camera.Core.Impl.IConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	Java.Lang.Object? RetrieveOption(ConfigOption p0, Java.Lang.Object? p1);

	[Register("retrieveOptionWithPriority", "(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;)Ljava/lang/Object;", "GetRetrieveOptionWithPriority_Landroidx_camera_core_impl_Config_Option_Landroidx_camera_core_impl_Config_OptionPriority_Handler:AndroidX.Camera.Core.Impl.IConfigInvoker, Xamarin.AndroidX.Camera.Core")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	Java.Lang.Object? RetrieveOptionWithPriority(ConfigOption p0, ConfigOptionPriority p1);

	[Register("hasConflict", "(Landroidx/camera/core/impl/Config$OptionPriority;Landroidx/camera/core/impl/Config$OptionPriority;)Z", "")]
	static unsafe bool HasConflict(ConfigOptionPriority priority1, ConfigOptionPriority priority2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(priority1?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(priority2?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasConflict.(Landroidx/camera/core/impl/Config$OptionPriority;Landroidx/camera/core/impl/Config$OptionPriority;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(priority1);
			GC.KeepAlive(priority2);
		}
	}

	[Register("mergeConfigs", "(Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/Config;", "")]
	static unsafe IConfig MergeConfigs(IConfig? extendedConfig, IConfig? baseConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((extendedConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)extendedConfig).Handle);
			ptr[1] = new JniArgumentValue((baseConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)baseConfig).Handle);
			return Java.Lang.Object.GetObject<IConfig>(_members.StaticMethods.InvokeObjectMethod("mergeConfigs.(Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/Config;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(extendedConfig);
			GC.KeepAlive(baseConfig);
		}
	}

	[Register("mergeOptionValue", "(Landroidx/camera/core/impl/MutableOptionsBundle;Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/Config$Option;)V", "")]
	static unsafe void MergeOptionValue(MutableOptionsBundle mergedConfig, IConfig baseConfig, IConfig extendedConfig, ConfigOption opt)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(mergedConfig?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((baseConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)baseConfig).Handle);
			ptr[2] = new JniArgumentValue((extendedConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)extendedConfig).Handle);
			ptr[3] = new JniArgumentValue(opt?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("mergeOptionValue.(Landroidx/camera/core/impl/MutableOptionsBundle;Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/Config$Option;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(mergedConfig);
			GC.KeepAlive(baseConfig);
			GC.KeepAlive(extendedConfig);
			GC.KeepAlive(opt);
		}
	}
}
