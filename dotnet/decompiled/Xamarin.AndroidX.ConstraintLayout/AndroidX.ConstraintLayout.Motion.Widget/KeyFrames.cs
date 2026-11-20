using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Widget;

[Register("androidx/constraintlayout/motion/widget/KeyFrames", DoNotGenerateAcw = true)]
public class KeyFrames : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/KeyFrames", typeof(KeyFrames));

	private static Delegate? cb_getKeys_GetKeys_Ljava_util_Set_;

	private static Delegate? cb_addAllFrames_AddAllFrames_Landroidx_constraintlayout_motion_widget_MotionController__V;

	private static Delegate? cb_addFrames_AddFrames_Landroidx_constraintlayout_motion_widget_MotionController__V;

	private static Delegate? cb_addKey_AddKey_Landroidx_constraintlayout_motion_widget_Key__V;

	private static Delegate? cb_getKeyFramesForView_GetKeyFramesForView_I_Ljava_util_ArrayList_;

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

	public unsafe virtual ICollection<Integer>? Keys
	{
		[Register("getKeys", "()Ljava/util/Set;", "GetGetKeysHandler")]
		get
		{
			return JavaSet<Integer>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeys.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected KeyFrames(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe KeyFrames()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", "")]
	public unsafe KeyFrames(Context? context, XmlReader? parser)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = XmlReaderPullParser.ToLocalJniHandle(parser);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(parser);
		}
	}

	private static Delegate GetGetKeysHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetKeys);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKeys(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaSet<Integer>.ToLocalJniHandle(Java.Lang.Object.GetObject<KeyFrames>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Keys);
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

	private static Delegate GetAddAllFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddAllFrames_Landroidx_constraintlayout_motion_widget_MotionController_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddAllFrames_Landroidx_constraintlayout_motion_widget_MotionController_(nint jnienv, nint native__this, nint native_motionController)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			KeyFrames? keyFrames = Java.Lang.Object.GetObject<KeyFrames>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(native_motionController, JniHandleOwnership.DoNotTransfer);
			keyFrames.AddAllFrames(motionController);
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

	[Register("addAllFrames", "(Landroidx/constraintlayout/motion/widget/MotionController;)V", "GetAddAllFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler")]
	public unsafe virtual void AddAllFrames(MotionController? motionController)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addAllFrames.(Landroidx/constraintlayout/motion/widget/MotionController;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionController);
		}
	}

	private static Delegate GetAddFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddFrames_Landroidx_constraintlayout_motion_widget_MotionController_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFrames_Landroidx_constraintlayout_motion_widget_MotionController_(nint jnienv, nint native__this, nint native_motionController)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			KeyFrames? keyFrames = Java.Lang.Object.GetObject<KeyFrames>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(native_motionController, JniHandleOwnership.DoNotTransfer);
			keyFrames.AddFrames(motionController);
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

	[Register("addFrames", "(Landroidx/constraintlayout/motion/widget/MotionController;)V", "GetAddFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler")]
	public unsafe virtual void AddFrames(MotionController? motionController)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFrames.(Landroidx/constraintlayout/motion/widget/MotionController;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionController);
		}
	}

	private static Delegate GetAddKey_Landroidx_constraintlayout_motion_widget_Key_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddKey_Landroidx_constraintlayout_motion_widget_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddKey_Landroidx_constraintlayout_motion_widget_Key_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			KeyFrames? keyFrames = Java.Lang.Object.GetObject<KeyFrames>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Key key = Java.Lang.Object.GetObject<Key>(native_key, JniHandleOwnership.DoNotTransfer);
			keyFrames.AddKey(key);
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

	[Register("addKey", "(Landroidx/constraintlayout/motion/widget/Key;)V", "GetAddKey_Landroidx_constraintlayout_motion_widget_Key_Handler")]
	public unsafe virtual void AddKey(Key? key)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addKey.(Landroidx/constraintlayout/motion/widget/Key;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(key);
		}
	}

	private static Delegate GetGetKeyFramesForView_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetKeyFramesForView_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKeyFramesForView_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<Key>.ToLocalJniHandle(Java.Lang.Object.GetObject<KeyFrames>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetKeyFramesForView(id));
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

	[Register("getKeyFramesForView", "(I)Ljava/util/ArrayList;", "GetGetKeyFramesForView_IHandler")]
	public unsafe virtual IList<Key>? GetKeyFramesForView(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return JavaList<Key>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyFramesForView.(I)Ljava/util/ArrayList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
