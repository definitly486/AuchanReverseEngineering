using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/Intent", DoNotGenerateAcw = true)]
public class Intent : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/Intent", typeof(Intent));

	private static Delegate? cb_getAction_GetAction_Ljava_lang_String_;

	private static Delegate? cb_getClipData_GetClipData_Landroid_content_ClipData_;

	private static Delegate? cb_getComponent_GetComponent_Landroid_content_ComponentName_;

	private static Delegate? cb_getData_GetData_Landroid_net_Uri_;

	private static Delegate? cb_getExtras_GetExtras_Landroid_os_Bundle_;

	private static Delegate? cb_addCategory_AddCategory_Ljava_lang_String__Landroid_content_Intent_;

	private static Delegate? cb_addFlags_AddFlags_I_Landroid_content_Intent_;

	private static Delegate? cb_clone_Clone_Ljava_lang_Object_;

	private static Delegate? cb_describeContents_DescribeContents_I;

	private static Delegate? cb_getBooleanExtra_GetBooleanExtra_Ljava_lang_String_Z_Z;

	private static Delegate? cb_getBundleExtra_GetBundleExtra_Ljava_lang_String__Landroid_os_Bundle_;

	private static Delegate? cb_getIntExtra_GetIntExtra_Ljava_lang_String_I_I;

	private static Delegate? cb_getStringExtra_GetStringExtra_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_putExtra_PutExtra_Ljava_lang_String_Landroid_os_Bundle__Landroid_content_Intent_;

	private static Delegate? cb_putExtra_PutExtra_Ljava_lang_String_Landroid_os_Parcelable__Landroid_content_Intent_;

	private static Delegate? cb_putExtra_PutExtra_Ljava_lang_String_Z_Landroid_content_Intent_;

	private static Delegate? cb_putExtra_PutExtra_Ljava_lang_String_I_Landroid_content_Intent_;

	private static Delegate? cb_putExtra_PutExtra_Ljava_lang_String_Ljava_lang_String__Landroid_content_Intent_;

	private static Delegate? cb_putExtra_PutExtra_Ljava_lang_String_arrayLjava_lang_String__Landroid_content_Intent_;

	private static Delegate? cb_putExtras_PutExtras_Landroid_os_Bundle__Landroid_content_Intent_;

	private static Delegate? cb_putParcelableArrayListExtra_PutParcelableArrayListExtra_Ljava_lang_String_Ljava_util_ArrayList__Landroid_content_Intent_;

	private static Delegate? cb_resolveActivity_ResolveActivity_Landroid_content_pm_PackageManager__Landroid_content_ComponentName_;

	private static Delegate? cb_setAction_SetAction_Ljava_lang_String__Landroid_content_Intent_;

	private static Delegate? cb_setClass_SetClass_Landroid_content_Context_Ljava_lang_Class__Landroid_content_Intent_;

	private static Delegate? cb_setComponent_SetComponent_Landroid_content_ComponentName__Landroid_content_Intent_;

	private static Delegate? cb_setData_SetData_Landroid_net_Uri__Landroid_content_Intent_;

	private static Delegate? cb_setFlags_SetFlags_I_Landroid_content_Intent_;

	private static Delegate? cb_setPackage_SetPackage_Ljava_lang_String__Landroid_content_Intent_;

	private static Delegate? cb_setType_SetType_Ljava_lang_String__Landroid_content_Intent_;

	private static Delegate? cb_writeToParcel_WriteToParcel_Landroid_os_Parcel_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual string? Action
	{
		[Register("getAction", "()Ljava/lang/String;", "GetGetActionHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAction.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ClipData? ClipData
	{
		[Register("getClipData", "()Landroid/content/ClipData;", "GetGetClipDataHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ClipData>(_members.InstanceMethods.InvokeVirtualObjectMethod("getClipData.()Landroid/content/ClipData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ComponentName? Component
	{
		[Register("getComponent", "()Landroid/content/ComponentName;", "GetGetComponentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ComponentName>(_members.InstanceMethods.InvokeVirtualObjectMethod("getComponent.()Landroid/content/ComponentName;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Android.Net.Uri? Data
	{
		[Register("getData", "()Landroid/net/Uri;", "GetGetDataHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getData.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Bundle? Extras
	{
		[Register("getExtras", "()Landroid/os/Bundle;", "GetGetExtrasHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExtras.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public Intent(Context packageContext, Type type)
		: this(packageContext, Java.Lang.Class.FromType(type))
	{
	}

	public Intent SetClass(Context packageContext, Type type)
	{
		return SetClass(packageContext, Java.Lang.Class.FromType(type));
	}

	protected Intent(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Intent()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Ljava/lang/Class;)V", "")]
	public unsafe Intent(Context? packageContext, Class? cls)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(packageContext?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(cls?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/Class;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/Class;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(packageContext);
			GC.KeepAlive(cls);
		}
	}

	[Register(".ctor", "(Landroid/content/Intent;)V", "")]
	public unsafe Intent(Intent? o)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Intent;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Landroid/net/Uri;)V", "")]
	public unsafe Intent(string? action, Android.Net.Uri? uri)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(action);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/net/Uri;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/net/Uri;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(uri);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe Intent(string? action)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(action);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetActionHandler()
	{
		return new _JniMarshal_PP_L(n_GetAction);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAction(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Action);
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

	private static Delegate GetGetClipDataHandler()
	{
		return new _JniMarshal_PP_L(n_GetClipData);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetClipData(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClipData);
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

	private static Delegate GetGetComponentHandler()
	{
		return new _JniMarshal_PP_L(n_GetComponent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetComponent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Component);
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

	private static Delegate GetGetDataHandler()
	{
		return new _JniMarshal_PP_L(n_GetData);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetData(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Data);
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

	private static Delegate GetGetExtrasHandler()
	{
		return new _JniMarshal_PP_L(n_GetExtras);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExtras(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Extras);
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

	private static Delegate GetAddCategory_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_AddCategory_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddCategory_Ljava_lang_String_(nint jnienv, nint native__this, nint native_category)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string category = JNIEnv.GetString(native_category, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.AddCategory(category));
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

	[Register("addCategory", "(Ljava/lang/String;)Landroid/content/Intent;", "GetAddCategory_Ljava_lang_String_Handler")]
	public unsafe virtual Intent AddCategory(string? category)
	{
		nint num = JNIEnv.NewString(category);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("addCategory.(Ljava/lang/String;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetAddFlags_IHandler()
	{
		return new _JniMarshal_PPI_L(n_AddFlags_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddFlags_I(nint jnienv, nint native__this, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddFlags((ActivityFlags)native_flags));
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

	[Register("addFlags", "(I)Landroid/content/Intent;", "GetAddFlags_IHandler")]
	public unsafe virtual Intent AddFlags(ActivityFlags flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)flags);
		return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("addFlags.(I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCloneHandler()
	{
		return new _JniMarshal_PP_L(n_Clone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

	[Register("clone", "()Ljava/lang/Object;", "GetCloneHandler")]
	public new unsafe virtual Java.Lang.Object? Clone()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("createChooser", "(Landroid/content/Intent;Ljava/lang/CharSequence;)Landroid/content/Intent;", "")]
	public unsafe static Intent? CreateChooser(Intent? target, ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Intent>(_members.StaticMethods.InvokeObjectMethod("createChooser.(Landroid/content/Intent;Ljava/lang/CharSequence;)Landroid/content/Intent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(target);
			GC.KeepAlive(title);
		}
	}

	public static Intent? CreateChooser(Intent? target, string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		Intent? result = CreateChooser(target, obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetDescribeContentsHandler()
	{
		return new _JniMarshal_PP_I(n_DescribeContents);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_DescribeContents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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

	[Register("describeContents", "()I", "GetDescribeContentsHandler")]
	public unsafe virtual int DescribeContents()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
	}

	private static Delegate GetGetBooleanExtra_Ljava_lang_String_ZHandler()
	{
		return new _JniMarshal_PPLB_B(n_GetBooleanExtra_Ljava_lang_String_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetBooleanExtra_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_name, sbyte native_defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			bool defaultValue = native_defaultValue != 0;
			return intent.GetBooleanExtra(name, defaultValue) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("getBooleanExtra", "(Ljava/lang/String;Z)Z", "GetGetBooleanExtra_Ljava_lang_String_ZHandler")]
	public unsafe virtual bool GetBooleanExtra(string? name, bool defaultValue)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defaultValue ? ((sbyte)1) : ((sbyte)0));
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getBooleanExtra.(Ljava/lang/String;Z)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetBundleExtra_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetBundleExtra_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBundleExtra_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.GetBundleExtra(name));
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

	[Register("getBundleExtra", "(Ljava/lang/String;)Landroid/os/Bundle;", "GetGetBundleExtra_Ljava_lang_String_Handler")]
	public unsafe virtual Bundle? GetBundleExtra(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBundleExtra.(Ljava/lang/String;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetIntExtra_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLI_I(n_GetIntExtra_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIntExtra_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_name, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return intent.GetIntExtra(name, defaultValue);
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

	[Register("getIntExtra", "(Ljava/lang/String;I)I", "GetGetIntExtra_Ljava_lang_String_IHandler")]
	public unsafe virtual int GetIntExtra(string? name, int defaultValue)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defaultValue);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIntExtra.(Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetStringExtra_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetStringExtra_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStringExtra_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(intent.GetStringExtra(name));
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

	[Register("getStringExtra", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetStringExtra_Ljava_lang_String_Handler")]
	public unsafe virtual string? GetStringExtra(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStringExtra.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("makeRestartActivityTask", "(Landroid/content/ComponentName;)Landroid/content/Intent;", "")]
	public unsafe static Intent? MakeRestartActivityTask(ComponentName? mainActivity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mainActivity?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.StaticMethods.InvokeObjectMethod("makeRestartActivityTask.(Landroid/content/ComponentName;)Landroid/content/Intent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(mainActivity);
		}
	}

	[Register("parseUri", "(Ljava/lang/String;I)Landroid/content/Intent;", "")]
	public unsafe static Intent? ParseUri(string? uri, IntentUriType flags)
	{
		nint num = JNIEnv.NewString(uri);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)flags);
			return Java.Lang.Object.GetObject<Intent>(_members.StaticMethods.InvokeObjectMethod("parseUri.(Ljava/lang/String;I)Landroid/content/Intent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutExtra_Ljava_lang_String_Landroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPLL_L(n_PutExtra_Ljava_lang_String_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutExtra_Ljava_lang_String_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Bundle value = Java.Lang.Object.GetObject<Bundle>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.PutExtra(name, value));
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

	[Register("putExtra", "(Ljava/lang/String;Landroid/os/Bundle;)Landroid/content/Intent;", "GetPutExtra_Ljava_lang_String_Landroid_os_Bundle_Handler")]
	public unsafe virtual Intent PutExtra(string? name, Bundle? value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("putExtra.(Ljava/lang/String;Landroid/os/Bundle;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetPutExtra_Ljava_lang_String_Landroid_os_Parcelable_Handler()
	{
		return new _JniMarshal_PPLL_L(n_PutExtra_Ljava_lang_String_Landroid_os_Parcelable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutExtra_Ljava_lang_String_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			IParcelable value = Java.Lang.Object.GetObject<IParcelable>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.PutExtra(name, value));
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

	[Register("putExtra", "(Ljava/lang/String;Landroid/os/Parcelable;)Landroid/content/Intent;", "GetPutExtra_Ljava_lang_String_Landroid_os_Parcelable_Handler")]
	public unsafe virtual Intent PutExtra(string? name, IParcelable? value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("putExtra.(Ljava/lang/String;Landroid/os/Parcelable;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetPutExtra_Ljava_lang_String_ZHandler()
	{
		return new _JniMarshal_PPLB_L(n_PutExtra_Ljava_lang_String_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutExtra_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_name, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			return JNIEnv.ToLocalJniHandle(intent.PutExtra(name, value));
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

	[Register("putExtra", "(Ljava/lang/String;Z)Landroid/content/Intent;", "GetPutExtra_Ljava_lang_String_ZHandler")]
	public unsafe virtual Intent PutExtra(string? name, bool value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("putExtra.(Ljava/lang/String;Z)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutExtra_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_PutExtra_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutExtra_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_name, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.PutExtra(name, value));
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

	[Register("putExtra", "(Ljava/lang/String;I)Landroid/content/Intent;", "GetPutExtra_Ljava_lang_String_IHandler")]
	public unsafe virtual Intent PutExtra(string? name, int value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("putExtra.(Ljava/lang/String;I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutExtra_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_L(n_PutExtra_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutExtra_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.PutExtra(name, value));
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

	[Register("putExtra", "(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;", "GetPutExtra_Ljava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual Intent PutExtra(string? name, string? value)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("putExtra.(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetPutExtra_Ljava_lang_String_arrayLjava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_L(n_PutExtra_Ljava_lang_String_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutExtra_Ljava_lang_String_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(string));
			nint result = JNIEnv.ToLocalJniHandle(intent.PutExtra(name, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
			}
			return result;
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

	[Register("putExtra", "(Ljava/lang/String;[Ljava/lang/String;)Landroid/content/Intent;", "GetPutExtra_Ljava_lang_String_arrayLjava_lang_String_Handler")]
	public unsafe virtual Intent PutExtra(string? name, string[]? value)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("putExtra.(Ljava/lang/String;[Ljava/lang/String;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (value != null)
			{
				JNIEnv.CopyArray(num2, value);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetPutExtras_Landroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPL_L(n_PutExtras_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutExtras_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_extras)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.PutExtras(extras));
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

	[Register("putExtras", "(Landroid/os/Bundle;)Landroid/content/Intent;", "GetPutExtras_Landroid_os_Bundle_Handler")]
	public unsafe virtual Intent PutExtras(Bundle extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("putExtras.(Landroid/os/Bundle;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(extras);
		}
	}

	private static Delegate GetPutParcelableArrayListExtra_Ljava_lang_String_Ljava_util_ArrayList_Handler()
	{
		return new _JniMarshal_PPLL_L(n_PutParcelableArrayListExtra_Ljava_lang_String_Ljava_util_ArrayList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutParcelableArrayListExtra_Ljava_lang_String_Ljava_util_ArrayList_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			IList<IParcelable> value = JavaList<IParcelable>.FromJniHandle(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.PutParcelableArrayListExtra(name, value));
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

	[Register("putParcelableArrayListExtra", "(Ljava/lang/String;Ljava/util/ArrayList;)Landroid/content/Intent;", "GetPutParcelableArrayListExtra_Ljava_lang_String_Ljava_util_ArrayList_Handler")]
	public unsafe virtual Intent PutParcelableArrayListExtra(string? name, IList<IParcelable>? value)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JavaList<IParcelable>.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("putParcelableArrayListExtra.(Ljava/lang/String;Ljava/util/ArrayList;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetResolveActivity_Landroid_content_pm_PackageManager_Handler()
	{
		return new _JniMarshal_PPL_L(n_ResolveActivity_Landroid_content_pm_PackageManager_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ResolveActivity_Landroid_content_pm_PackageManager_(nint jnienv, nint native__this, nint native_pm)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PackageManager pm = Java.Lang.Object.GetObject<PackageManager>(native_pm, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.ResolveActivity(pm));
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

	[Register("resolveActivity", "(Landroid/content/pm/PackageManager;)Landroid/content/ComponentName;", "GetResolveActivity_Landroid_content_pm_PackageManager_Handler")]
	public unsafe virtual ComponentName? ResolveActivity(PackageManager pm)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pm?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ComponentName>(_members.InstanceMethods.InvokeVirtualObjectMethod("resolveActivity.(Landroid/content/pm/PackageManager;)Landroid/content/ComponentName;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(pm);
		}
	}

	private static Delegate GetSetAction_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetAction_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetAction_Ljava_lang_String_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string action = JNIEnv.GetString(native_action, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.SetAction(action));
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

	[Register("setAction", "(Ljava/lang/String;)Landroid/content/Intent;", "GetSetAction_Ljava_lang_String_Handler")]
	public unsafe virtual Intent SetAction(string? action)
	{
		nint num = JNIEnv.NewString(action);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAction.(Ljava/lang/String;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetClass_Landroid_content_Context_Ljava_lang_Class_Handler()
	{
		return new _JniMarshal_PPLL_L(n_SetClass_Landroid_content_Context_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetClass_Landroid_content_Context_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_packageContext, nint native_cls)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context packageContext = Java.Lang.Object.GetObject<Context>(native_packageContext, JniHandleOwnership.DoNotTransfer);
			Class cls = Java.Lang.Object.GetObject<Class>(native_cls, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.SetClass(packageContext, cls));
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

	[Register("setClass", "(Landroid/content/Context;Ljava/lang/Class;)Landroid/content/Intent;", "GetSetClass_Landroid_content_Context_Ljava_lang_Class_Handler")]
	public unsafe virtual Intent SetClass(Context packageContext, Class cls)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(packageContext?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(cls?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("setClass.(Landroid/content/Context;Ljava/lang/Class;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(packageContext);
			GC.KeepAlive(cls);
		}
	}

	private static Delegate GetSetComponent_Landroid_content_ComponentName_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetComponent_Landroid_content_ComponentName_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetComponent_Landroid_content_ComponentName_(nint jnienv, nint native__this, nint native_component)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ComponentName component = Java.Lang.Object.GetObject<ComponentName>(native_component, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.SetComponent(component));
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

	[Register("setComponent", "(Landroid/content/ComponentName;)Landroid/content/Intent;", "GetSetComponent_Landroid_content_ComponentName_Handler")]
	public unsafe virtual Intent SetComponent(ComponentName? component)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(component?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("setComponent.(Landroid/content/ComponentName;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(component);
		}
	}

	private static Delegate GetSetData_Landroid_net_Uri_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetData_Landroid_net_Uri_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetData_Landroid_net_Uri_(nint jnienv, nint native__this, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri data = Java.Lang.Object.GetObject<Android.Net.Uri>(native_data, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.SetData(data));
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

	[Register("setData", "(Landroid/net/Uri;)Landroid/content/Intent;", "GetSetData_Landroid_net_Uri_Handler")]
	public unsafe virtual Intent SetData(Android.Net.Uri? data)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("setData.(Landroid/net/Uri;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetSetFlags_IHandler()
	{
		return new _JniMarshal_PPI_L(n_SetFlags_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetFlags_I(nint jnienv, nint native__this, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFlags((ActivityFlags)native_flags));
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

	[Register("setFlags", "(I)Landroid/content/Intent;", "GetSetFlags_IHandler")]
	public unsafe virtual Intent SetFlags(ActivityFlags flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)flags);
		return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFlags.(I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetPackage_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetPackage_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetPackage_Ljava_lang_String_(nint jnienv, nint native__this, nint native_packageName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string package = JNIEnv.GetString(native_packageName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.SetPackage(package));
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

	[Register("setPackage", "(Ljava/lang/String;)Landroid/content/Intent;", "GetSetPackage_Ljava_lang_String_Handler")]
	public unsafe virtual Intent SetPackage(string? packageName)
	{
		nint num = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPackage.(Ljava/lang/String;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetType_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetType_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetType_Ljava_lang_String_(nint jnienv, nint native__this, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(intent.SetType(type));
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

	[Register("setType", "(Ljava/lang/String;)Landroid/content/Intent;", "GetSetType_Ljava_lang_String_Handler")]
	public unsafe virtual Intent SetType(string? type)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("setType.(Ljava/lang/String;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native__out, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Intent? intent = Java.Lang.Object.GetObject<Intent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel parcel = Java.Lang.Object.GetObject<Parcel>(native__out, JniHandleOwnership.DoNotTransfer);
			intent.WriteToParcel(parcel, (ParcelableWriteFlags)native_flags);
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

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
	public unsafe virtual void WriteToParcel(Parcel? @out, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@out);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
