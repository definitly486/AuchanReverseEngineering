using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.ConstraintLayout.Core.Motion.Key;

[Register("androidx/constraintlayout/core/motion/key/MotionKey", DoNotGenerateAcw = true)]
internal class MotionKeyInvoker : MotionKey
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/key/MotionKey", typeof(MotionKeyInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public MotionKeyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("addValues", "(Ljava/util/HashMap;)V", "GetAddValues_Ljava_util_HashMap_Handler")]
	public unsafe override void AddValues(IDictionary<string, SplineSet>? p0)
	{
		nint num = JavaDictionary<string, SplineSet>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addValues.(Ljava/util/HashMap;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	[Register("clone", "()Landroidx/constraintlayout/core/motion/key/MotionKey;", "GetCloneHandler")]
	public unsafe override MotionKey? Clone()
	{
		return Java.Lang.Object.GetObject<MotionKey>(_members.InstanceMethods.InvokeAbstractObjectMethod("clone.()Landroidx/constraintlayout/core/motion/key/MotionKey;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getAttributeNames", "(Ljava/util/HashSet;)V", "GetGetAttributeNames_Ljava_util_HashSet_Handler")]
	public unsafe override void GetAttributeNames(HashSet? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("getAttributeNames.(Ljava/util/HashSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register("getId", "(Ljava/lang/String;)I", "GetGetId_Ljava_lang_String_Handler")]
	public unsafe override int GetId(string? p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeAbstractInt32Method("getId.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
