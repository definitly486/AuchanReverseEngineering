using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentHostCallback", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "H" })]
public abstract class FragmentHostCallback : FragmentContainer
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentHostCallback", typeof(FragmentHostCallback));

	private static Delegate? cb_onDump_OnDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String__V;

	private static Delegate? cb_onFindViewById_OnFindViewById_I_Landroid_view_View_;

	private static Delegate? cb_onGetHost_OnGetHost_Ljava_lang_Object_;

	private static Delegate? cb_onGetLayoutInflater_OnGetLayoutInflater_Landroid_view_LayoutInflater_;

	private static Delegate? cb_onGetWindowAnimations_OnGetWindowAnimations_I;

	private static Delegate? cb_onHasView_OnHasView_Z;

	private static Delegate? cb_onHasWindowAnimations_OnHasWindowAnimations_Z;

	private static Delegate? cb_onRequestPermissionsFromFragment_OnRequestPermissionsFromFragment_Landroidx_fragment_app_Fragment_arrayLjava_lang_String_I_V;

	private static Delegate? cb_onShouldSaveFragmentState_OnShouldSaveFragmentState_Landroidx_fragment_app_Fragment__Z;

	private static Delegate? cb_onShouldShowRequestPermissionRationale_OnShouldShowRequestPermissionRationale_Ljava_lang_String__Z;

	private static Delegate? cb_onStartActivityFromFragment_OnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I_V;

	private static Delegate? cb_onStartActivityFromFragment_OnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle__V;

	private static Delegate? cb_onStartIntentSenderFromFragment_OnStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle__V;

	private static Delegate? cb_onSupportInvalidateOptionsMenu_OnSupportInvalidateOptionsMenu_V;

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Android.App.Activity? Activity
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getActivity", "()Landroid/app/Activity;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.App.Activity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActivity.()Landroid/app/Activity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Context Context
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getContext", "()Landroid/content/Context;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe FragmentManager FragmentManager
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Handler Handler
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getHandler", "()Landroid/os/Handler;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Handler>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getHandler.()Landroid/os/Handler;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected FragmentHostCallback(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/os/Handler;I)V", "")]
	public unsafe FragmentHostCallback(Context context, Handler handler, int windowAnimations)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(windowAnimations);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/os/Handler;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/os/Handler;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(handler);
		}
	}

	private static Delegate GetOnDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_OnDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_prefix, nint native_fd, nint native_writer, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentHostCallback? fragmentHostCallback = Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
			PrintWriter writer = Java.Lang.Object.GetObject<PrintWriter>(native_writer, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
			fragmentHostCallback.OnDump(prefix, fd, writer, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_args);
			}
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

	[Register("onDump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetOnDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
	public unsafe virtual void OnDump(string prefix, FileDescriptor? fd, PrintWriter writer, string[]? args)
	{
		nint num = JNIEnv.NewString(prefix);
		nint num2 = JNIEnv.NewArray(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(fd?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (args != null)
			{
				JNIEnv.CopyArray(num2, args);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(fd);
			GC.KeepAlive(writer);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetOnFindViewById_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_OnFindViewById_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnFindViewById_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFindViewById(id));
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

	[Register("onFindViewById", "(I)Landroid/view/View;", "GetOnFindViewById_IHandler")]
	public unsafe override View? OnFindViewById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onFindViewById.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnGetHostHandler()
	{
		return new global::_JniMarshal_PP_L(n_OnGetHost);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnGetHost(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnGetHost());
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

	[Register("onGetHost", "()Ljava/lang/Object;", "GetOnGetHostHandler")]
	public abstract Java.Lang.Object? OnGetHost();

	private static Delegate GetOnGetLayoutInflaterHandler()
	{
		return new global::_JniMarshal_PP_L(n_OnGetLayoutInflater);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnGetLayoutInflater(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnGetLayoutInflater());
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

	[Register("onGetLayoutInflater", "()Landroid/view/LayoutInflater;", "GetOnGetLayoutInflaterHandler")]
	public unsafe virtual LayoutInflater OnGetLayoutInflater()
	{
		return Java.Lang.Object.GetObject<LayoutInflater>(_members.InstanceMethods.InvokeVirtualObjectMethod("onGetLayoutInflater.()Landroid/view/LayoutInflater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnGetWindowAnimationsHandler()
	{
		return new global::_JniMarshal_PP_I(n_OnGetWindowAnimations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_OnGetWindowAnimations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnGetWindowAnimations();
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

	[Register("onGetWindowAnimations", "()I", "GetOnGetWindowAnimationsHandler")]
	public unsafe virtual int OnGetWindowAnimations()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("onGetWindowAnimations.()I", this, null);
	}

	private static Delegate GetOnHasViewHandler()
	{
		return new global::_JniMarshal_PP_B(n_OnHasView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnHasView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnHasView() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onHasView", "()Z", "GetOnHasViewHandler")]
	public unsafe override bool OnHasView()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("onHasView.()Z", this, null);
	}

	private static Delegate GetOnHasWindowAnimationsHandler()
	{
		return new global::_JniMarshal_PP_B(n_OnHasWindowAnimations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnHasWindowAnimations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnHasWindowAnimations() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onHasWindowAnimations", "()Z", "GetOnHasWindowAnimationsHandler")]
	public unsafe virtual bool OnHasWindowAnimations()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("onHasWindowAnimations.()Z", this, null);
	}

	[Obsolete]
	private static Delegate GetOnRequestPermissionsFromFragment_Landroidx_fragment_app_Fragment_arrayLjava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPLLI_V(n_OnRequestPermissionsFromFragment_Landroidx_fragment_app_Fragment_arrayLjava_lang_String_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRequestPermissionsFromFragment_Landroidx_fragment_app_Fragment_arrayLjava_lang_String_I(nint jnienv, nint native__this, nint native_fragment, nint native_permissions, int requestCode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentHostCallback? fragmentHostCallback = Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
			fragmentHostCallback.OnRequestPermissionsFromFragment(fragment, array, requestCode);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_permissions);
			}
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
	[Register("onRequestPermissionsFromFragment", "(Landroidx/fragment/app/Fragment;[Ljava/lang/String;I)V", "GetOnRequestPermissionsFromFragment_Landroidx_fragment_app_Fragment_arrayLjava_lang_String_IHandler")]
	public unsafe virtual void OnRequestPermissionsFromFragment(Fragment fragment, string[] permissions, int requestCode)
	{
		nint num = JNIEnv.NewArray(permissions);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRequestPermissionsFromFragment.(Landroidx/fragment/app/Fragment;[Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			if (permissions != null)
			{
				JNIEnv.CopyArray(num, permissions);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(fragment);
			GC.KeepAlive(permissions);
		}
	}

	private static Delegate GetOnShouldSaveFragmentState_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnShouldSaveFragmentState_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnShouldSaveFragmentState_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentHostCallback? fragmentHostCallback = Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return fragmentHostCallback.OnShouldSaveFragmentState(fragment) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onShouldSaveFragmentState", "(Landroidx/fragment/app/Fragment;)Z", "GetOnShouldSaveFragmentState_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual bool OnShouldSaveFragmentState(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onShouldSaveFragmentState.(Landroidx/fragment/app/Fragment;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetOnShouldShowRequestPermissionRationale_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnShouldShowRequestPermissionRationale_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnShouldShowRequestPermissionRationale_Ljava_lang_String_(nint jnienv, nint native__this, nint native_permission)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentHostCallback? fragmentHostCallback = Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string permission = JNIEnv.GetString(native_permission, JniHandleOwnership.DoNotTransfer);
			return fragmentHostCallback.OnShouldShowRequestPermissionRationale(permission) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onShouldShowRequestPermissionRationale", "(Ljava/lang/String;)Z", "GetOnShouldShowRequestPermissionRationale_Ljava_lang_String_Handler")]
	public unsafe virtual bool OnShouldShowRequestPermissionRationale(string permission)
	{
		nint num = JNIEnv.NewString(permission);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onShouldShowRequestPermissionRationale.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetOnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_IHandler()
	{
		return new global::_JniMarshal_PPLLI_V(n_OnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I(nint jnienv, nint native__this, nint native_fragment, nint native_intent, int requestCode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentHostCallback? fragmentHostCallback = Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			fragmentHostCallback.OnStartActivityFromFragment(fragment, intent, requestCode);
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

	[Register("onStartActivityFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/Intent;I)V", "GetOnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_IHandler")]
	public unsafe virtual void OnStartActivityFromFragment(Fragment fragment, Intent intent, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStartActivityFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/Intent;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetOnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPLLIL_V(n_OnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_fragment, nint native_intent, int requestCode, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentHostCallback? fragmentHostCallback = Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
			fragmentHostCallback.OnStartActivityFromFragment(fragment, intent, requestCode, options);
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

	[Register("onStartActivityFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/Intent;ILandroid/os/Bundle;)V", "GetOnStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_Handler")]
	public unsafe virtual void OnStartActivityFromFragment(Fragment fragment, Intent intent, int requestCode, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			ptr[3] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStartActivityFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/Intent;ILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	[Obsolete]
	private static Delegate GetOnStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPLLILIIIL_V(n_OnStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_fragment, nint native_intent, int requestCode, nint native_fillInIntent, int flagsMask, int flagsValues, int extraFlags, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentHostCallback? fragmentHostCallback = Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			IntentSender intent = Java.Lang.Object.GetObject<IntentSender>(native_intent, JniHandleOwnership.DoNotTransfer);
			Intent fillInIntent = Java.Lang.Object.GetObject<Intent>(native_fillInIntent, JniHandleOwnership.DoNotTransfer);
			Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
			fragmentHostCallback.OnStartIntentSenderFromFragment(fragment, intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags, options);
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
	[Register("onStartIntentSenderFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", "GetOnStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler")]
	public unsafe virtual void OnStartIntentSenderFromFragment(Fragment fragment, IntentSender intent, int requestCode, Intent? fillInIntent, int flagsMask, int flagsValues, int extraFlags, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			ptr[3] = new JniArgumentValue(fillInIntent?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(flagsMask);
			ptr[5] = new JniArgumentValue(flagsValues);
			ptr[6] = new JniArgumentValue(extraFlags);
			ptr[7] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStartIntentSenderFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
			GC.KeepAlive(fillInIntent);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetOnSupportInvalidateOptionsMenuHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnSupportInvalidateOptionsMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSupportInvalidateOptionsMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentHostCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSupportInvalidateOptionsMenu();
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

	[Register("onSupportInvalidateOptionsMenu", "()V", "GetOnSupportInvalidateOptionsMenuHandler")]
	public unsafe virtual void OnSupportInvalidateOptionsMenu()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onSupportInvalidateOptionsMenu.()V", this, null);
	}
}
