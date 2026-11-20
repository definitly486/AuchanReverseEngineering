using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/KeyFrameArray", DoNotGenerateAcw = true)]
public class KeyFrameArray : Java.Lang.Object
{
	[Register("androidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomArray", DoNotGenerateAcw = true)]
	public class CustomArray : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomArray", typeof(CustomArray));

		private static Delegate? cb_append_Append_ILandroidx_constraintlayout_core_motion_CustomAttribute__V;

		private static Delegate? cb_clear_Clear_V;

		private static Delegate? cb_dump_Dump_V;

		private static Delegate? cb_keyAt_KeyAt_I_I;

		private static Delegate? cb_remove_Remove_I_V;

		private static Delegate? cb_size_Size_I;

		private static Delegate? cb_valueAt_ValueAt_I_Landroidx_constraintlayout_core_motion_CustomAttribute_;

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

		protected CustomArray(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CustomArray()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetAppend_ILandroidx_constraintlayout_core_motion_CustomAttribute_Handler()
		{
			return new global::_JniMarshal_PPIL_V(n_Append_ILandroidx_constraintlayout_core_motion_CustomAttribute_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Append_ILandroidx_constraintlayout_core_motion_CustomAttribute_(nint jnienv, nint native__this, int position, nint native_value)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				CustomArray? customArray = Java.Lang.Object.GetObject<CustomArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CustomAttribute value = Java.Lang.Object.GetObject<CustomAttribute>(native_value, JniHandleOwnership.DoNotTransfer);
				customArray.Append(position, value);
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

		[Register("append", "(ILandroidx/constraintlayout/core/motion/CustomAttribute;)V", "GetAppend_ILandroidx_constraintlayout_core_motion_CustomAttribute_Handler")]
		public unsafe virtual void Append(int position, CustomAttribute? value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(position);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("append.(ILandroidx/constraintlayout/core/motion/CustomAttribute;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetClearHandler()
		{
			return new global::_JniMarshal_PP_V(n_Clear);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Clear(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<CustomArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

		[Register("clear", "()V", "GetClearHandler")]
		public unsafe virtual void Clear()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetDumpHandler()
		{
			return new global::_JniMarshal_PP_V(n_Dump);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Dump(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<CustomArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dump();
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

		[Register("dump", "()V", "GetDumpHandler")]
		public unsafe virtual void Dump()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("dump.()V", this, null);
		}

		private static Delegate GetKeyAt_IHandler()
		{
			return new global::_JniMarshal_PPI_I(n_KeyAt_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_KeyAt_I(nint jnienv, nint native__this, int i)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CustomArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).KeyAt(i);
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

		[Register("keyAt", "(I)I", "GetKeyAt_IHandler")]
		public unsafe virtual int KeyAt(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return _members.InstanceMethods.InvokeVirtualInt32Method("keyAt.(I)I", this, ptr);
		}

		private static Delegate GetRemove_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_Remove_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Remove_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<CustomArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove(position);
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

		[Register("remove", "(I)V", "GetRemove_IHandler")]
		public unsafe virtual void Remove(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(I)V", this, ptr);
		}

		private static Delegate GetSizeHandler()
		{
			return new global::_JniMarshal_PP_I(n_Size);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_Size(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CustomArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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

		[Register("size", "()I", "GetSizeHandler")]
		public unsafe virtual int Size()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
		}

		private static Delegate GetValueAt_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_ValueAt_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_ValueAt_I(nint jnienv, nint native__this, int i)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CustomArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueAt(i));
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

		[Register("valueAt", "(I)Landroidx/constraintlayout/core/motion/CustomAttribute;", "GetValueAt_IHandler")]
		public unsafe virtual CustomAttribute? ValueAt(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return Java.Lang.Object.GetObject<CustomAttribute>(_members.InstanceMethods.InvokeVirtualObjectMethod("valueAt.(I)Landroidx/constraintlayout/core/motion/CustomAttribute;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("androidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar", DoNotGenerateAcw = true)]
	public class CustomVar : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar", typeof(CustomVar));

		private static Delegate? cb_append_Append_ILandroidx_constraintlayout_core_motion_CustomVariable__V;

		private static Delegate? cb_clear_Clear_V;

		private static Delegate? cb_dump_Dump_V;

		private static Delegate? cb_keyAt_KeyAt_I_I;

		private static Delegate? cb_remove_Remove_I_V;

		private static Delegate? cb_size_Size_I;

		private static Delegate? cb_valueAt_ValueAt_I_Landroidx_constraintlayout_core_motion_CustomVariable_;

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

		protected CustomVar(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CustomVar()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetAppend_ILandroidx_constraintlayout_core_motion_CustomVariable_Handler()
		{
			return new global::_JniMarshal_PPIL_V(n_Append_ILandroidx_constraintlayout_core_motion_CustomVariable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Append_ILandroidx_constraintlayout_core_motion_CustomVariable_(nint jnienv, nint native__this, int position, nint native_value)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				CustomVar? customVar = Java.Lang.Object.GetObject<CustomVar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CustomVariable value = Java.Lang.Object.GetObject<CustomVariable>(native_value, JniHandleOwnership.DoNotTransfer);
				customVar.Append(position, value);
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

		[Register("append", "(ILandroidx/constraintlayout/core/motion/CustomVariable;)V", "GetAppend_ILandroidx_constraintlayout_core_motion_CustomVariable_Handler")]
		public unsafe virtual void Append(int position, CustomVariable? value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(position);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("append.(ILandroidx/constraintlayout/core/motion/CustomVariable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetClearHandler()
		{
			return new global::_JniMarshal_PP_V(n_Clear);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Clear(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<CustomVar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

		[Register("clear", "()V", "GetClearHandler")]
		public unsafe virtual void Clear()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetDumpHandler()
		{
			return new global::_JniMarshal_PP_V(n_Dump);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Dump(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<CustomVar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dump();
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

		[Register("dump", "()V", "GetDumpHandler")]
		public unsafe virtual void Dump()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("dump.()V", this, null);
		}

		private static Delegate GetKeyAt_IHandler()
		{
			return new global::_JniMarshal_PPI_I(n_KeyAt_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_KeyAt_I(nint jnienv, nint native__this, int i)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CustomVar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).KeyAt(i);
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

		[Register("keyAt", "(I)I", "GetKeyAt_IHandler")]
		public unsafe virtual int KeyAt(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return _members.InstanceMethods.InvokeVirtualInt32Method("keyAt.(I)I", this, ptr);
		}

		private static Delegate GetRemove_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_Remove_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Remove_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<CustomVar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove(position);
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

		[Register("remove", "(I)V", "GetRemove_IHandler")]
		public unsafe virtual void Remove(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(I)V", this, ptr);
		}

		private static Delegate GetSizeHandler()
		{
			return new global::_JniMarshal_PP_I(n_Size);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_Size(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CustomVar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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

		[Register("size", "()I", "GetSizeHandler")]
		public unsafe virtual int Size()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
		}

		private static Delegate GetValueAt_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_ValueAt_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_ValueAt_I(nint jnienv, nint native__this, int i)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CustomVar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueAt(i));
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

		[Register("valueAt", "(I)Landroidx/constraintlayout/core/motion/CustomVariable;", "GetValueAt_IHandler")]
		public unsafe virtual CustomVariable? ValueAt(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return Java.Lang.Object.GetObject<CustomVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("valueAt.(I)Landroidx/constraintlayout/core/motion/CustomVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/KeyFrameArray", typeof(KeyFrameArray));

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

	protected KeyFrameArray(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe KeyFrameArray()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}
}
