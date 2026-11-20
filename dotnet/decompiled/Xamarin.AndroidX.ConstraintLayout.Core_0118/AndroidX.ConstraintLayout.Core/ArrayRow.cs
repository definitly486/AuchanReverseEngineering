using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core;

[Register("androidx/constraintlayout/core/ArrayRow", DoNotGenerateAcw = true)]
public class ArrayRow : Java.Lang.Object
{
	[Register("androidx/constraintlayout/core/ArrayRow$ArrayRowVariables", "", "AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker")]
	public interface IArrayRowVariables : IJavaObject, IDisposable, IJavaPeerable
	{
		int CurrentSize
		{
			[Register("getCurrentSize", "()I", "GetGetCurrentSizeHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
			get;
		}

		[Register("add", "(Landroidx/constraintlayout/core/SolverVariable;FZ)V", "GetAdd_Landroidx_constraintlayout_core_SolverVariable_FZHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		void Add(SolverVariable? p0, float p1, bool p2);

		[Register("clear", "()V", "GetClearHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		void Clear();

		[Register("contains", "(Landroidx/constraintlayout/core/SolverVariable;)Z", "GetContains_Landroidx_constraintlayout_core_SolverVariable_Handler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		bool Contains(SolverVariable? p0);

		[Register("display", "()V", "GetDisplayHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		void Display();

		[Register("divideByAmount", "(F)V", "GetDivideByAmount_FHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		void DivideByAmount(float p0);

		[Register("get", "(Landroidx/constraintlayout/core/SolverVariable;)F", "GetGet_Landroidx_constraintlayout_core_SolverVariable_Handler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		float Get(SolverVariable? p0);

		[Register("getVariable", "(I)Landroidx/constraintlayout/core/SolverVariable;", "GetGetVariable_IHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		SolverVariable? GetVariable(int p0);

		[Register("getVariableValue", "(I)F", "GetGetVariableValue_IHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		float GetVariableValue(int p0);

		[Register("indexOf", "(Landroidx/constraintlayout/core/SolverVariable;)I", "GetIndexOf_Landroidx_constraintlayout_core_SolverVariable_Handler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		int IndexOf(SolverVariable? p0);

		[Register("invert", "()V", "GetInvertHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		void Invert();

		[Register("put", "(Landroidx/constraintlayout/core/SolverVariable;F)V", "GetPut_Landroidx_constraintlayout_core_SolverVariable_FHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		void Put(SolverVariable? p0, float p1);

		[Register("remove", "(Landroidx/constraintlayout/core/SolverVariable;Z)F", "GetRemove_Landroidx_constraintlayout_core_SolverVariable_ZHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		float Remove(SolverVariable? p0, bool p1);

		[Register("sizeInBytes", "()I", "GetSizeInBytesHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		int SizeInBytes();

		[Register("use", "(Landroidx/constraintlayout/core/ArrayRow;Z)F", "GetUse_Landroidx_constraintlayout_core_ArrayRow_ZHandler:AndroidX.ConstraintLayout.Core.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		float Use(ArrayRow? p0, bool p1);
	}

	[Register("androidx/constraintlayout/core/ArrayRow$ArrayRowVariables", DoNotGenerateAcw = true)]
	internal class IArrayRowVariablesInvoker : Java.Lang.Object, IArrayRowVariables, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables = new XAPeerMembers("androidx/constraintlayout/core/ArrayRow$ArrayRowVariables", typeof(IArrayRowVariablesInvoker));

		private static Delegate? cb_getCurrentSize_GetCurrentSize_I;

		private static Delegate? cb_add_Add_Landroidx_constraintlayout_core_SolverVariable_FZ_V;

		private static Delegate? cb_clear_Clear_V;

		private static Delegate? cb_contains_Contains_Landroidx_constraintlayout_core_SolverVariable__Z;

		private static Delegate? cb_display_Display_V;

		private static Delegate? cb_divideByAmount_DivideByAmount_F_V;

		private static Delegate? cb_get_Get_Landroidx_constraintlayout_core_SolverVariable__F;

		private static Delegate? cb_getVariable_GetVariable_I_Landroidx_constraintlayout_core_SolverVariable_;

		private static Delegate? cb_getVariableValue_GetVariableValue_I_F;

		private static Delegate? cb_indexOf_IndexOf_Landroidx_constraintlayout_core_SolverVariable__I;

		private static Delegate? cb_invert_Invert_V;

		private static Delegate? cb_put_Put_Landroidx_constraintlayout_core_SolverVariable_F_V;

		private static Delegate? cb_remove_Remove_Landroidx_constraintlayout_core_SolverVariable_Z_F;

		private static Delegate? cb_sizeInBytes_SizeInBytes_I;

		private static Delegate? cb_use_Use_Landroidx_constraintlayout_core_ArrayRow_Z_F;

		private static nint java_class_ref => _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.ManagedPeerType;

		public unsafe int CurrentSize => _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractInt32Method("getCurrentSize.()I", this, null);

		public IArrayRowVariablesInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetGetCurrentSizeHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetCurrentSize);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetCurrentSize(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentSize;
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

		private static Delegate GetAdd_Landroidx_constraintlayout_core_SolverVariable_FZHandler()
		{
			return new global::_JniMarshal_PPLFB_V(n_Add_Landroidx_constraintlayout_core_SolverVariable_FZ);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Add_Landroidx_constraintlayout_core_SolverVariable_FZ(nint jnienv, nint native__this, nint native_p0, float p1, sbyte native_p2)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IArrayRowVariables? arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p2 = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				bool p3 = native_p2 != 0;
				arrayRowVariables.Add(p2, p1, p3);
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

		public unsafe void Add(SolverVariable? p0, float p1, bool p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2 ? ((sbyte)1) : ((sbyte)0));
				_members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractVoidMethod("add.(Landroidx/constraintlayout/core/SolverVariable;FZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
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
				Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

		public unsafe void Clear()
		{
			_members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetContains_Landroidx_constraintlayout_core_SolverVariable_Handler()
		{
			return new global::_JniMarshal_PPL_B(n_Contains_Landroidx_constraintlayout_core_SolverVariable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_Contains_Landroidx_constraintlayout_core_SolverVariable_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IArrayRowVariables? arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return arrayRowVariables.Contains(p) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool Contains(SolverVariable? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Landroidx/constraintlayout/core/SolverVariable;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDisplayHandler()
		{
			return new global::_JniMarshal_PP_V(n_Display);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Display(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Display();
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

		public unsafe void Display()
		{
			_members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractVoidMethod("display.()V", this, null);
		}

		private static Delegate GetDivideByAmount_FHandler()
		{
			return new global::_JniMarshal_PPF_V(n_DivideByAmount_F);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_DivideByAmount_F(nint jnienv, nint native__this, float p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DivideByAmount(p0);
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

		public unsafe void DivideByAmount(float p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractVoidMethod("divideByAmount.(F)V", this, ptr);
		}

		private static Delegate GetGet_Landroidx_constraintlayout_core_SolverVariable_Handler()
		{
			return new global::_JniMarshal_PPL_F(n_Get_Landroidx_constraintlayout_core_SolverVariable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_Get_Landroidx_constraintlayout_core_SolverVariable_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				IArrayRowVariables? arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return arrayRowVariables.Get(p);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe float Get(SolverVariable? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractSingleMethod("get.(Landroidx/constraintlayout/core/SolverVariable;)F", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetGetVariable_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_GetVariable_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetVariable_I(nint jnienv, nint native__this, int p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVariable(p0));
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

		public unsafe SolverVariable? GetVariable(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<SolverVariable>(_members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractObjectMethod("getVariable.(I)Landroidx/constraintlayout/core/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetVariableValue_IHandler()
		{
			return new global::_JniMarshal_PPI_F(n_GetVariableValue_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetVariableValue_I(nint jnienv, nint native__this, int p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVariableValue(p0);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe float GetVariableValue(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractSingleMethod("getVariableValue.(I)F", this, ptr);
		}

		private static Delegate GetIndexOf_Landroidx_constraintlayout_core_SolverVariable_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_IndexOf_Landroidx_constraintlayout_core_SolverVariable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_IndexOf_Landroidx_constraintlayout_core_SolverVariable_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IArrayRowVariables? arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return arrayRowVariables.IndexOf(p);
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

		public unsafe int IndexOf(SolverVariable? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractInt32Method("indexOf.(Landroidx/constraintlayout/core/SolverVariable;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetInvertHandler()
		{
			return new global::_JniMarshal_PP_V(n_Invert);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Invert(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Invert();
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

		public unsafe void Invert()
		{
			_members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractVoidMethod("invert.()V", this, null);
		}

		private static Delegate GetPut_Landroidx_constraintlayout_core_SolverVariable_FHandler()
		{
			return new global::_JniMarshal_PPLF_V(n_Put_Landroidx_constraintlayout_core_SolverVariable_F);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Put_Landroidx_constraintlayout_core_SolverVariable_F(nint jnienv, nint native__this, nint native_p0, float p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IArrayRowVariables? arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p2 = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				arrayRowVariables.Put(p2, p1);
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

		public unsafe void Put(SolverVariable? p0, float p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractVoidMethod("put.(Landroidx/constraintlayout/core/SolverVariable;F)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetRemove_Landroidx_constraintlayout_core_SolverVariable_ZHandler()
		{
			return new _JniMarshal_PPLB_F(n_Remove_Landroidx_constraintlayout_core_SolverVariable_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_Remove_Landroidx_constraintlayout_core_SolverVariable_Z(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				IArrayRowVariables? arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				bool p2 = native_p1 != 0;
				return arrayRowVariables.Remove(p, p2);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe float Remove(SolverVariable? p0, bool p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
				return _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractSingleMethod("remove.(Landroidx/constraintlayout/core/SolverVariable;Z)F", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetSizeInBytesHandler()
		{
			return new global::_JniMarshal_PP_I(n_SizeInBytes);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_SizeInBytes(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SizeInBytes();
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

		public unsafe int SizeInBytes()
		{
			return _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractInt32Method("sizeInBytes.()I", this, null);
		}

		private static Delegate GetUse_Landroidx_constraintlayout_core_ArrayRow_ZHandler()
		{
			return new _JniMarshal_PPLB_F(n_Use_Landroidx_constraintlayout_core_ArrayRow_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_Use_Landroidx_constraintlayout_core_ArrayRow_Z(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				IArrayRowVariables? arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ArrayRow p = Java.Lang.Object.GetObject<ArrayRow>(native_p0, JniHandleOwnership.DoNotTransfer);
				bool p2 = native_p1 != 0;
				return arrayRowVariables.Use(p, p2);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe float Use(ArrayRow? p0, bool p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
				return _members_androidx_constraintlayout_core_ArrayRow_ArrayRowVariables.InstanceMethods.InvokeAbstractSingleMethod("use.(Landroidx/constraintlayout/core/ArrayRow;Z)F", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/ArrayRow", typeof(ArrayRow));

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	private static Delegate? cb_getKey_GetKey_Landroidx_constraintlayout_core_SolverVariable_;

	private static Delegate? cb_addError_AddError_Landroidx_constraintlayout_core_LinearSystem_I_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_addError_AddError_Landroidx_constraintlayout_core_SolverVariable__V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_createRowDimensionRatio_CreateRowDimensionRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_F_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createRowEqualDimension_CreateRowEqualDimension_FFFLandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_I_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createRowEqualMatchDimensions_CreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable__Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createRowEquals_CreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createRowEquals_CreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_I_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createRowGreaterThan_CreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createRowGreaterThan_CreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable__Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createRowLowerThan_CreateRowLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_createRowWithAngle_CreateRowWithAngle_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_F_Landroidx_constraintlayout_core_ArrayRow_;

	private static Delegate? cb_getPivotCandidate_GetPivotCandidate_Landroidx_constraintlayout_core_LinearSystem_arrayZ_Landroidx_constraintlayout_core_SolverVariable_;

	private static Delegate? cb_pickPivot_PickPivot_Landroidx_constraintlayout_core_SolverVariable__Landroidx_constraintlayout_core_SolverVariable_;

	private static Delegate? cb_reset_Reset_V;

	private static Delegate? cb_updateFromFinalVariable_UpdateFromFinalVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_Z_V;

	private static Delegate? cb_updateFromRow_UpdateFromRow_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_ArrayRow_Z_V;

	private static Delegate? cb_updateFromSynonymVariable_UpdateFromSynonymVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_Z_V;

	private static Delegate? cb_updateFromSystem_UpdateFromSystem_Landroidx_constraintlayout_core_LinearSystem__V;

	[Register("variables")]
	public IArrayRowVariables? Variables
	{
		get
		{
			return Java.Lang.Object.GetObject<IArrayRowVariables>(_members.InstanceFields.GetObjectValue("variables.Landroidx/constraintlayout/core/ArrayRow$ArrayRowVariables;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("variables.Landroidx/constraintlayout/core/ArrayRow$ArrayRowVariables;", this, new JniObjectReference(num));
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

	public unsafe virtual bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmpty.()Z", this, null);
		}
	}

	public unsafe virtual SolverVariable? Key
	{
		[Register("getKey", "()Landroidx/constraintlayout/core/SolverVariable;", "GetGetKeyHandler")]
		get
		{
			return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKey.()Landroidx/constraintlayout/core/SolverVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ArrayRow(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ArrayRow()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/Cache;)V", "")]
	public unsafe ArrayRow(Cache? cache)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cache?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/Cache;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/Cache;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cache);
		}
	}

	private static Delegate GetIsEmptyHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsEmpty);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEmpty(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetKeyHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetKey);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKey(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Key);
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

	private static Delegate GetAddError_Landroidx_constraintlayout_core_LinearSystem_IHandler()
	{
		return new global::_JniMarshal_PPLI_L(n_AddError_Landroidx_constraintlayout_core_LinearSystem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddError_Landroidx_constraintlayout_core_LinearSystem_I(nint jnienv, nint native__this, nint native_system, int strength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.AddError(system, strength));
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

	[Register("addError", "(Landroidx/constraintlayout/core/LinearSystem;I)Landroidx/constraintlayout/core/ArrayRow;", "GetAddError_Landroidx_constraintlayout_core_LinearSystem_IHandler")]
	public unsafe virtual ArrayRow? AddError(LinearSystem? system, int strength)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(strength);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("addError.(Landroidx/constraintlayout/core/LinearSystem;I)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(system);
		}
	}

	private static Delegate GetAddError_Landroidx_constraintlayout_core_SolverVariable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddError_Landroidx_constraintlayout_core_SolverVariable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddError_Landroidx_constraintlayout_core_SolverVariable_(nint jnienv, nint native__this, nint native_error)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable error = Java.Lang.Object.GetObject<SolverVariable>(native_error, JniHandleOwnership.DoNotTransfer);
			arrayRow.AddError(error);
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

	[Register("addError", "(Landroidx/constraintlayout/core/SolverVariable;)V", "GetAddError_Landroidx_constraintlayout_core_SolverVariable_Handler")]
	public unsafe virtual void AddError(SolverVariable? error)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addError.(Landroidx/constraintlayout/core/SolverVariable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(error);
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
			Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	private static Delegate GetCreateRowDimensionRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FHandler()
	{
		return new _JniMarshal_PPLLLLF_L(n_CreateRowDimensionRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowDimensionRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_F(nint jnienv, nint native__this, nint native_variableA, nint native_variableB, nint native_variableC, nint native_variableD, float ratio)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableA = Java.Lang.Object.GetObject<SolverVariable>(native_variableA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableB = Java.Lang.Object.GetObject<SolverVariable>(native_variableB, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableC = Java.Lang.Object.GetObject<SolverVariable>(native_variableC, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableD = Java.Lang.Object.GetObject<SolverVariable>(native_variableD, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowDimensionRatio(variableA, variableB, variableC, variableD, ratio));
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

	[Register("createRowDimensionRatio", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;F)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowDimensionRatio_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FHandler")]
	public unsafe virtual ArrayRow? CreateRowDimensionRatio(SolverVariable? variableA, SolverVariable? variableB, SolverVariable? variableC, SolverVariable? variableD, float ratio)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(variableB?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(variableC?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(variableD?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(ratio);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowDimensionRatio.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;F)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(variableA);
			GC.KeepAlive(variableB);
			GC.KeepAlive(variableC);
			GC.KeepAlive(variableD);
		}
	}

	private static Delegate GetCreateRowEqualDimension_FFFLandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_IHandler()
	{
		return new _JniMarshal_PPFFFLILILILI_L(n_CreateRowEqualDimension_FFFLandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowEqualDimension_FFFLandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_I(nint jnienv, nint native__this, float currentWeight, float totalWeights, float nextWeight, nint native_variableStartA, int marginStartA, nint native_variableEndA, int marginEndA, nint native_variableStartB, int marginStartB, nint native_variableEndB, int marginEndB)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableStartA = Java.Lang.Object.GetObject<SolverVariable>(native_variableStartA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableEndA = Java.Lang.Object.GetObject<SolverVariable>(native_variableEndA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableStartB = Java.Lang.Object.GetObject<SolverVariable>(native_variableStartB, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableEndB = Java.Lang.Object.GetObject<SolverVariable>(native_variableEndB, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowEqualDimension(currentWeight, totalWeights, nextWeight, variableStartA, marginStartA, variableEndA, marginEndA, variableStartB, marginStartB, variableEndB, marginEndB));
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

	[Register("createRowEqualDimension", "(FFFLandroidx/constraintlayout/core/SolverVariable;ILandroidx/constraintlayout/core/SolverVariable;ILandroidx/constraintlayout/core/SolverVariable;ILandroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowEqualDimension_FFFLandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_IHandler")]
	public unsafe virtual ArrayRow? CreateRowEqualDimension(float currentWeight, float totalWeights, float nextWeight, SolverVariable? variableStartA, int marginStartA, SolverVariable? variableEndA, int marginEndA, SolverVariable? variableStartB, int marginStartB, SolverVariable? variableEndB, int marginEndB)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[11];
			*ptr = new JniArgumentValue(currentWeight);
			ptr[1] = new JniArgumentValue(totalWeights);
			ptr[2] = new JniArgumentValue(nextWeight);
			ptr[3] = new JniArgumentValue(variableStartA?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(marginStartA);
			ptr[5] = new JniArgumentValue(variableEndA?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(marginEndA);
			ptr[7] = new JniArgumentValue(variableStartB?.Handle ?? IntPtr.Zero);
			ptr[8] = new JniArgumentValue(marginStartB);
			ptr[9] = new JniArgumentValue(variableEndB?.Handle ?? IntPtr.Zero);
			ptr[10] = new JniArgumentValue(marginEndB);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowEqualDimension.(FFFLandroidx/constraintlayout/core/SolverVariable;ILandroidx/constraintlayout/core/SolverVariable;ILandroidx/constraintlayout/core/SolverVariable;ILandroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(variableStartA);
			GC.KeepAlive(variableEndA);
			GC.KeepAlive(variableStartB);
			GC.KeepAlive(variableEndB);
		}
	}

	private static Delegate GetCreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Handler()
	{
		return new _JniMarshal_PPFFFLLLL_L(n_CreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_(nint jnienv, nint native__this, float currentWeight, float totalWeights, float nextWeight, nint native_variableStartA, nint native_variableEndA, nint native_variableStartB, nint native_variableEndB)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableStartA = Java.Lang.Object.GetObject<SolverVariable>(native_variableStartA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableEndA = Java.Lang.Object.GetObject<SolverVariable>(native_variableEndA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableStartB = Java.Lang.Object.GetObject<SolverVariable>(native_variableStartB, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableEndB = Java.Lang.Object.GetObject<SolverVariable>(native_variableEndB, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowEqualMatchDimensions(currentWeight, totalWeights, nextWeight, variableStartA, variableEndA, variableStartB, variableEndB));
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

	[Register("createRowEqualMatchDimensions", "(FFFLandroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Handler")]
	public unsafe virtual ArrayRow? CreateRowEqualMatchDimensions(float currentWeight, float totalWeights, float nextWeight, SolverVariable? variableStartA, SolverVariable? variableEndA, SolverVariable? variableStartB, SolverVariable? variableEndB)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(currentWeight);
			ptr[1] = new JniArgumentValue(totalWeights);
			ptr[2] = new JniArgumentValue(nextWeight);
			ptr[3] = new JniArgumentValue(variableStartA?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(variableEndA?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(variableStartB?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(variableEndB?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowEqualMatchDimensions.(FFFLandroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(variableStartA);
			GC.KeepAlive(variableEndA);
			GC.KeepAlive(variableStartB);
			GC.KeepAlive(variableEndB);
		}
	}

	private static Delegate GetCreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IHandler()
	{
		return new global::_JniMarshal_PPLLI_L(n_CreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I(nint jnienv, nint native__this, nint native_variableA, nint native_variableB, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableA = Java.Lang.Object.GetObject<SolverVariable>(native_variableA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableB = Java.Lang.Object.GetObject<SolverVariable>(native_variableB, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowEquals(variableA, variableB, margin));
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

	[Register("createRowEquals", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IHandler")]
	public unsafe virtual ArrayRow? CreateRowEquals(SolverVariable? variableA, SolverVariable? variableB, int margin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(variableB?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowEquals.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(variableA);
			GC.KeepAlive(variableB);
		}
	}

	private static Delegate GetCreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_IHandler()
	{
		return new global::_JniMarshal_PPLI_L(n_CreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_I(nint jnienv, nint native__this, nint native_variable, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variable = Java.Lang.Object.GetObject<SolverVariable>(native_variable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowEquals(variable, value));
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

	[Register("createRowEquals", "(Landroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowEquals_Landroidx_constraintlayout_core_SolverVariable_IHandler")]
	public unsafe virtual ArrayRow? CreateRowEquals(SolverVariable? variable, int value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(variable?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowEquals.(Landroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(variable);
		}
	}

	private static Delegate GetCreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IHandler()
	{
		return new _JniMarshal_PPLLLI_L(n_CreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I(nint jnienv, nint native__this, nint native_variableA, nint native_variableB, nint native_slack, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableA = Java.Lang.Object.GetObject<SolverVariable>(native_variableA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableB = Java.Lang.Object.GetObject<SolverVariable>(native_variableB, JniHandleOwnership.DoNotTransfer);
			SolverVariable slack = Java.Lang.Object.GetObject<SolverVariable>(native_slack, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowGreaterThan(variableA, variableB, slack, margin));
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

	[Register("createRowGreaterThan", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IHandler")]
	public unsafe virtual ArrayRow? CreateRowGreaterThan(SolverVariable? variableA, SolverVariable? variableB, SolverVariable? slack, int margin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(variableB?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(slack?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(margin);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowGreaterThan.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(variableA);
			GC.KeepAlive(variableB);
			GC.KeepAlive(slack);
		}
	}

	private static Delegate GetCreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_Handler()
	{
		return new _JniMarshal_PPLIL_L(n_CreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_(nint jnienv, nint native__this, nint native_a, int b, nint native_slack)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable slack = Java.Lang.Object.GetObject<SolverVariable>(native_slack, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowGreaterThan(a, b, slack));
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

	[Register("createRowGreaterThan", "(Landroidx/constraintlayout/core/SolverVariable;ILandroidx/constraintlayout/core/SolverVariable;)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowGreaterThan_Landroidx_constraintlayout_core_SolverVariable_ILandroidx_constraintlayout_core_SolverVariable_Handler")]
	public unsafe virtual ArrayRow? CreateRowGreaterThan(SolverVariable? a, int b, SolverVariable? slack)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b);
			ptr[2] = new JniArgumentValue(slack?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowGreaterThan.(Landroidx/constraintlayout/core/SolverVariable;ILandroidx/constraintlayout/core/SolverVariable;)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(slack);
		}
	}

	private static Delegate GetCreateRowLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IHandler()
	{
		return new _JniMarshal_PPLLLI_L(n_CreateRowLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_I(nint jnienv, nint native__this, nint native_variableA, nint native_variableB, nint native_slack, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableA = Java.Lang.Object.GetObject<SolverVariable>(native_variableA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableB = Java.Lang.Object.GetObject<SolverVariable>(native_variableB, JniHandleOwnership.DoNotTransfer);
			SolverVariable slack = Java.Lang.Object.GetObject<SolverVariable>(native_slack, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowLowerThan(variableA, variableB, slack, margin));
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

	[Register("createRowLowerThan", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowLowerThan_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_IHandler")]
	public unsafe virtual ArrayRow? CreateRowLowerThan(SolverVariable? variableA, SolverVariable? variableB, SolverVariable? slack, int margin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(variableB?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(slack?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(margin);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowLowerThan.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;I)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(variableA);
			GC.KeepAlive(variableB);
			GC.KeepAlive(slack);
		}
	}

	private static Delegate GetCreateRowWithAngle_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FHandler()
	{
		return new _JniMarshal_PPLLLLF_L(n_CreateRowWithAngle_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateRowWithAngle_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_F(nint jnienv, nint native__this, nint native_at, nint native_ab, nint native_bt, nint native_bb, float angleComponent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable at = Java.Lang.Object.GetObject<SolverVariable>(native_at, JniHandleOwnership.DoNotTransfer);
			SolverVariable ab = Java.Lang.Object.GetObject<SolverVariable>(native_ab, JniHandleOwnership.DoNotTransfer);
			SolverVariable bt = Java.Lang.Object.GetObject<SolverVariable>(native_bt, JniHandleOwnership.DoNotTransfer);
			SolverVariable bb = Java.Lang.Object.GetObject<SolverVariable>(native_bb, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowWithAngle(at, ab, bt, bb, angleComponent));
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

	[Register("createRowWithAngle", "(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;F)Landroidx/constraintlayout/core/ArrayRow;", "GetCreateRowWithAngle_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_Landroidx_constraintlayout_core_SolverVariable_FHandler")]
	public unsafe virtual ArrayRow? CreateRowWithAngle(SolverVariable? at, SolverVariable? ab, SolverVariable? bt, SolverVariable? bb, float angleComponent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(at?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(ab?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(bt?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(bb?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(angleComponent);
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowWithAngle.(Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;Landroidx/constraintlayout/core/SolverVariable;F)Landroidx/constraintlayout/core/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(at);
			GC.KeepAlive(ab);
			GC.KeepAlive(bt);
			GC.KeepAlive(bb);
		}
	}

	private static Delegate GetGetPivotCandidate_Landroidx_constraintlayout_core_LinearSystem_arrayZHandler()
	{
		return new global::_JniMarshal_PPLL_L(n_GetPivotCandidate_Landroidx_constraintlayout_core_LinearSystem_arrayZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPivotCandidate_Landroidx_constraintlayout_core_LinearSystem_arrayZ(nint jnienv, nint native__this, nint native_system, nint native_avoid)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			bool[] array = (bool[])JNIEnv.GetArray(native_avoid, JniHandleOwnership.DoNotTransfer, typeof(bool));
			nint result = JNIEnv.ToLocalJniHandle(arrayRow.GetPivotCandidate(system, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_avoid);
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

	[Register("getPivotCandidate", "(Landroidx/constraintlayout/core/LinearSystem;[Z)Landroidx/constraintlayout/core/SolverVariable;", "GetGetPivotCandidate_Landroidx_constraintlayout_core_LinearSystem_arrayZHandler")]
	public unsafe virtual SolverVariable? GetPivotCandidate(LinearSystem? system, bool[]? avoid)
	{
		nint num = JNIEnv.NewArray(avoid);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPivotCandidate.(Landroidx/constraintlayout/core/LinearSystem;[Z)Landroidx/constraintlayout/core/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (avoid != null)
			{
				JNIEnv.CopyArray(num, avoid);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(system);
			GC.KeepAlive(avoid);
		}
	}

	private static Delegate GetPickPivot_Landroidx_constraintlayout_core_SolverVariable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_PickPivot_Landroidx_constraintlayout_core_SolverVariable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PickPivot_Landroidx_constraintlayout_core_SolverVariable_(nint jnienv, nint native__this, nint native_exclude)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable exclude = Java.Lang.Object.GetObject<SolverVariable>(native_exclude, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.PickPivot(exclude));
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

	[Register("pickPivot", "(Landroidx/constraintlayout/core/SolverVariable;)Landroidx/constraintlayout/core/SolverVariable;", "GetPickPivot_Landroidx_constraintlayout_core_SolverVariable_Handler")]
	public unsafe virtual SolverVariable? PickPivot(SolverVariable? exclude)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(exclude?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("pickPivot.(Landroidx/constraintlayout/core/SolverVariable;)Landroidx/constraintlayout/core/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(exclude);
		}
	}

	private static Delegate GetResetHandler()
	{
		return new global::_JniMarshal_PP_V(n_Reset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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

	[Register("reset", "()V", "GetResetHandler")]
	public unsafe virtual void Reset()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
	}

	private static Delegate GetUpdateFromFinalVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_ZHandler()
	{
		return new _JniMarshal_PPLLB_V(n_UpdateFromFinalVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateFromFinalVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_Z(nint jnienv, nint native__this, nint native_system, nint native_variable, sbyte native_removeFromDefinition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			SolverVariable variable = Java.Lang.Object.GetObject<SolverVariable>(native_variable, JniHandleOwnership.DoNotTransfer);
			bool removeFromDefinition = native_removeFromDefinition != 0;
			arrayRow.UpdateFromFinalVariable(system, variable, removeFromDefinition);
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

	[Register("updateFromFinalVariable", "(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/SolverVariable;Z)V", "GetUpdateFromFinalVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_ZHandler")]
	public unsafe virtual void UpdateFromFinalVariable(LinearSystem? system, SolverVariable? variable, bool removeFromDefinition)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(variable?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(removeFromDefinition ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromFinalVariable.(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/SolverVariable;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
			GC.KeepAlive(variable);
		}
	}

	private static Delegate GetUpdateFromRow_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_ArrayRow_ZHandler()
	{
		return new _JniMarshal_PPLLB_V(n_UpdateFromRow_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_ArrayRow_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateFromRow_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_ArrayRow_Z(nint jnienv, nint native__this, nint native_system, nint native_definition, sbyte native_removeFromDefinition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			ArrayRow definition = Java.Lang.Object.GetObject<ArrayRow>(native_definition, JniHandleOwnership.DoNotTransfer);
			bool removeFromDefinition = native_removeFromDefinition != 0;
			arrayRow.UpdateFromRow(system, definition, removeFromDefinition);
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

	[Register("updateFromRow", "(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/ArrayRow;Z)V", "GetUpdateFromRow_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_ArrayRow_ZHandler")]
	public unsafe virtual void UpdateFromRow(LinearSystem? system, ArrayRow? definition, bool removeFromDefinition)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(definition?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(removeFromDefinition ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromRow.(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/ArrayRow;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
			GC.KeepAlive(definition);
		}
	}

	private static Delegate GetUpdateFromSynonymVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_ZHandler()
	{
		return new _JniMarshal_PPLLB_V(n_UpdateFromSynonymVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateFromSynonymVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_Z(nint jnienv, nint native__this, nint native_system, nint native_variable, sbyte native_removeFromDefinition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			SolverVariable variable = Java.Lang.Object.GetObject<SolverVariable>(native_variable, JniHandleOwnership.DoNotTransfer);
			bool removeFromDefinition = native_removeFromDefinition != 0;
			arrayRow.UpdateFromSynonymVariable(system, variable, removeFromDefinition);
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

	[Register("updateFromSynonymVariable", "(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/SolverVariable;Z)V", "GetUpdateFromSynonymVariable_Landroidx_constraintlayout_core_LinearSystem_Landroidx_constraintlayout_core_SolverVariable_ZHandler")]
	public unsafe virtual void UpdateFromSynonymVariable(LinearSystem? system, SolverVariable? variable, bool removeFromDefinition)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(variable?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(removeFromDefinition ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromSynonymVariable.(Landroidx/constraintlayout/core/LinearSystem;Landroidx/constraintlayout/core/SolverVariable;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
			GC.KeepAlive(variable);
		}
	}

	private static Delegate GetUpdateFromSystem_Landroidx_constraintlayout_core_LinearSystem_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateFromSystem_Landroidx_constraintlayout_core_LinearSystem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateFromSystem_Landroidx_constraintlayout_core_LinearSystem_(nint jnienv, nint native__this, nint native_system)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ArrayRow? arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			arrayRow.UpdateFromSystem(system);
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

	[Register("updateFromSystem", "(Landroidx/constraintlayout/core/LinearSystem;)V", "GetUpdateFromSystem_Landroidx_constraintlayout_core_LinearSystem_Handler")]
	public unsafe virtual void UpdateFromSystem(LinearSystem? system)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromSystem.(Landroidx/constraintlayout/core/LinearSystem;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
		}
	}
}
