using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Runtime;
using Android.Views;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.App;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/core/app/ComponentActivity", DoNotGenerateAcw = true)]
public class ComponentActivity : Activity, IJavaObject, IDisposable, IJavaPeerable, ILifecycleOwner
{
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("androidx/core/app/ComponentActivity$ExtraData", DoNotGenerateAcw = true)]
	public class ExtraData : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/ComponentActivity$ExtraData", typeof(ExtraData));

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ExtraData(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ExtraData()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/ComponentActivity", typeof(ComponentActivity));

	private static Delegate? cb_getLifecycle_GetLifecycle_Landroidx_lifecycle_Lifecycle_;

	private static Delegate? cb_getExtraData_GetExtraData_Ljava_lang_Class__Landroidx_core_app_ComponentActivity_ExtraData_;

	private static Delegate? cb_putExtraData_PutExtraData_Landroidx_core_app_ComponentActivity_ExtraData__V;

	private static Delegate? cb_superDispatchKeyEvent_SuperDispatchKeyEvent_Landroid_view_KeyEvent__Z;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual AndroidX.Lifecycle.Lifecycle Lifecycle
	{
		[Register("getLifecycle", "()Landroidx/lifecycle/Lifecycle;", "GetGetLifecycleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLifecycle.()Landroidx/lifecycle/Lifecycle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ComponentActivity(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ComponentActivity()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetLifecycleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLifecycle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLifecycle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lifecycle);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetGetExtraData_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetExtraData_Ljava_lang_Class_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExtraData_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_extraDataClass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ComponentActivity? componentActivity = Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class extraDataClass = Java.Lang.Object.GetObject<Class>(native_extraDataClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(componentActivity.GetExtraData(extraDataClass));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("getExtraData", "(Ljava/lang/Class;)Landroidx/core/app/ComponentActivity$ExtraData;", "GetGetExtraData_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "T extends androidx.core.app.ComponentActivity.ExtraData" })]
	public unsafe virtual Java.Lang.Object? GetExtraData(Class extraDataClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(extraDataClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExtraData.(Ljava/lang/Class;)Landroidx/core/app/ComponentActivity$ExtraData;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(extraDataClass);
		}
	}

	[Obsolete]
	private static Delegate GetPutExtraData_Landroidx_core_app_ComponentActivity_ExtraData_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_PutExtraData_Landroidx_core_app_ComponentActivity_ExtraData_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PutExtraData_Landroidx_core_app_ComponentActivity_ExtraData_(nint jnienv, nint native__this, nint native_extraData)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ComponentActivity? componentActivity = Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ExtraData extraData = Java.Lang.Object.GetObject<ExtraData>(native_extraData, JniHandleOwnership.DoNotTransfer);
			componentActivity.PutExtraData(extraData);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("putExtraData", "(Landroidx/core/app/ComponentActivity$ExtraData;)V", "GetPutExtraData_Landroidx_core_app_ComponentActivity_ExtraData_Handler")]
	public unsafe virtual void PutExtraData(ExtraData extraData)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(extraData?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putExtraData.(Landroidx/core/app/ComponentActivity$ExtraData;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(extraData);
		}
	}

	[Register("shouldDumpInternalState", "([Ljava/lang/String;)Z", "")]
	protected unsafe bool ShouldDumpInternalState(string[]? args)
	{
		nint num = JNIEnv.NewArray(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("shouldDumpInternalState.([Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			if (args != null)
			{
				JNIEnv.CopyArray(num, args);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetSuperDispatchKeyEvent_Landroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_SuperDispatchKeyEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SuperDispatchKeyEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ComponentActivity? componentActivity = Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return componentActivity.SuperDispatchKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("superDispatchKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetSuperDispatchKeyEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe virtual bool SuperDispatchKeyEvent(KeyEvent e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("superDispatchKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}
}
