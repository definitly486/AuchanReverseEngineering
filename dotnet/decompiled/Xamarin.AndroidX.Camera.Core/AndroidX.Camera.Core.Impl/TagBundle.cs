using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/TagBundle", DoNotGenerateAcw = true)]
public class TagBundle : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/TagBundle", typeof(TagBundle));

	private static Delegate? cb_getTag_Ljava_lang_String_;

	private static Delegate? cb_listKeys;

	[Register("mTagMap")]
	protected IDictionary? MTagMap
	{
		get
		{
			return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("mTagMap.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaDictionary.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mTagMap.Ljava/util/Map;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	protected TagBundle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/util/Map;)V", "")]
	protected unsafe TagBundle(IDictionary<string, Java.Lang.Object> tagMap)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaDictionary<string, Java.Lang.Object>.ToLocalJniHandle(tagMap);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Map;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Map;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tagMap);
		}
	}

	[Register("create", "(Landroid/util/Pair;)Landroidx/camera/core/impl/TagBundle;", "")]
	public unsafe static TagBundle Create(Pair source)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TagBundle>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/util/Pair;)Landroidx/camera/core/impl/TagBundle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(source);
		}
	}

	[Register("emptyBundle", "()Landroidx/camera/core/impl/TagBundle;", "")]
	public unsafe static TagBundle EmptyBundle()
	{
		return Java.Lang.Object.GetObject<TagBundle>(_members.StaticMethods.InvokeObjectMethod("emptyBundle.()Landroidx/camera/core/impl/TagBundle;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("from", "(Landroidx/camera/core/impl/TagBundle;)Landroidx/camera/core/impl/TagBundle;", "")]
	public unsafe static TagBundle From(TagBundle otherTagBundle)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(otherTagBundle?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TagBundle>(_members.StaticMethods.InvokeObjectMethod("from.(Landroidx/camera/core/impl/TagBundle;)Landroidx/camera/core/impl/TagBundle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(otherTagBundle);
		}
	}

	private static Delegate GetGetTag_Ljava_lang_String_Handler()
	{
		if ((object)cb_getTag_Ljava_lang_String_ == null)
		{
			cb_getTag_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetTag_Ljava_lang_String_));
		}
		return cb_getTag_Ljava_lang_String_;
	}

	private static nint n_GetTag_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key)
	{
		TagBundle? tagBundle = Java.Lang.Object.GetObject<TagBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(tagBundle.GetTag(key));
	}

	[Register("getTag", "(Ljava/lang/String;)Ljava/lang/Object;", "GetGetTag_Ljava_lang_String_Handler")]
	public unsafe virtual Java.Lang.Object? GetTag(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTag.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetListKeysHandler()
	{
		if ((object)cb_listKeys == null)
		{
			cb_listKeys = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ListKeys));
		}
		return cb_listKeys;
	}

	private static nint n_ListKeys(nint jnienv, nint native__this)
	{
		return JavaSet<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<TagBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListKeys());
	}

	[Register("listKeys", "()Ljava/util/Set;", "GetListKeysHandler")]
	public unsafe virtual ICollection<string> ListKeys()
	{
		return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("listKeys.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("toString", "()Ljava/lang/String;", "")]
	public unsafe sealed override string ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
