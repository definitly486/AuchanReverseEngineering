using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/Layout", DoNotGenerateAcw = true)]
public abstract class Layout : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/Layout", typeof(Layout));

	private static Delegate? cb_getLineCount_GetLineCount_I;

	private static Delegate? cb_getEllipsisCount_GetEllipsisCount_I_I;

	private static Delegate? cb_getLineForVertical_GetLineForVertical_I_I;

	private static Delegate? cb_getLineMax_GetLineMax_I_F;

	private static Delegate? cb_getOffsetForHorizontal_GetOffsetForHorizontal_IF_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract int LineCount { get; }

	protected Layout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetLineCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetLineCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLineCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineCount;
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

	private static Delegate GetGetEllipsisCount_IHandler()
	{
		return new _JniMarshal_PPI_I(n_GetEllipsisCount_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetEllipsisCount_I(nint jnienv, nint native__this, int line)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetEllipsisCount(line);
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

	public abstract int GetEllipsisCount(int line);

	public unsafe int GetLineEnd(int line)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(line);
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("getLineEnd.(I)I", this, ptr);
	}

	private static Delegate GetGetLineForVertical_IHandler()
	{
		return new _JniMarshal_PPI_I(n_GetLineForVertical_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLineForVertical_I(nint jnienv, nint native__this, int vertical)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLineForVertical(vertical);
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

	public unsafe virtual int GetLineForVertical(int vertical)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(vertical);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getLineForVertical.(I)I", this, ptr);
	}

	private static Delegate GetGetLineMax_IHandler()
	{
		return new _JniMarshal_PPI_F(n_GetLineMax_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetLineMax_I(nint jnienv, nint native__this, int line)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLineMax(line);
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

	public unsafe virtual float GetLineMax(int line)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(line);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getLineMax.(I)F", this, ptr);
	}

	private static Delegate GetGetOffsetForHorizontal_IFHandler()
	{
		return new _JniMarshal_PPIF_I(n_GetOffsetForHorizontal_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOffsetForHorizontal_IF(nint jnienv, nint native__this, int line, float horiz)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetOffsetForHorizontal(line, horiz);
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

	public unsafe virtual int GetOffsetForHorizontal(int line, float horiz)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(line);
		ptr[1] = new JniArgumentValue(horiz);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getOffsetForHorizontal.(IF)I", this, ptr);
	}
}
