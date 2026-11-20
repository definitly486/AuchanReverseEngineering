using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Motion.Utils;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Widget;

[Register("androidx/constraintlayout/motion/widget/Key", DoNotGenerateAcw = true)]
internal class KeyInvoker : Key
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/Key", typeof(KeyInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public KeyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("addValues", "(Ljava/util/HashMap;)V", "GetAddValues_Ljava_util_HashMap_Handler")]
	public unsafe override void AddValues(IDictionary<string, ViewSpline>? p0)
	{
		nint num = JavaDictionary<string, ViewSpline>.ToLocalJniHandle(p0);
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

	[Register("clone", "()Landroidx/constraintlayout/motion/widget/Key;", "GetCloneHandler")]
	public unsafe override Key? Clone()
	{
		return Java.Lang.Object.GetObject<Key>(_members.InstanceMethods.InvokeAbstractObjectMethod("clone.()Landroidx/constraintlayout/motion/widget/Key;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setValue", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_String_Ljava_lang_Object_Handler")]
	public unsafe override void SetValue(string? p0, Java.Lang.Object? p1)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setValue.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
		}
	}
}
