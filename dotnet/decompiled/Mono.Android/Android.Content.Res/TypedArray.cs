using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Content.Res;

[Register("android/content/res/TypedArray", DoNotGenerateAcw = true)]
public class TypedArray : Java.Lang.Object, IAutoCloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/res/TypedArray", typeof(TypedArray));

	private static Delegate? cb_getIndexCount_GetIndexCount_I;

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_getBoolean_GetBoolean_IZ_Z;

	private static Delegate? cb_getColor_GetColor_II_I;

	private static Delegate? cb_getDimension_GetDimension_IF_F;

	private static Delegate? cb_getDimensionPixelSize_GetDimensionPixelSize_II_I;

	private static Delegate? cb_getDrawable_GetDrawable_I_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_getFloat_GetFloat_IF_F;

	private static Delegate? cb_getIndex_GetIndex_I_I;

	private static Delegate? cb_getInt_GetInt_II_I;

	private static Delegate? cb_getInteger_GetInteger_II_I;

	private static Delegate? cb_getResourceId_GetResourceId_II_I;

	private static Delegate? cb_getString_GetString_I_Ljava_lang_String_;

	private static Delegate? cb_getText_GetText_I_Ljava_lang_CharSequence_;

	private static Delegate? cb_peekValue_PeekValue_I_Landroid_util_TypedValue_;

	private static Delegate? cb_recycle_Recycle_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int IndexCount
	{
		[Register("getIndexCount", "()I", "GetGetIndexCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIndexCount.()I", this, null);
		}
	}

	protected TypedArray(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetIndexCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetIndexCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIndexCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndexCount;
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

	[SupportedOSPlatform("android31.0")]
	private static Delegate GetCloseHandler()
	{
		return new _JniMarshal_PP_V(n_Close);
	}

	[SupportedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	[SupportedOSPlatform("android31.0")]
	[Register("close", "()V", "GetCloseHandler", ApiSince = 31)]
	public unsafe virtual void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}

	private static Delegate GetGetBoolean_IZHandler()
	{
		return new _JniMarshal_PPIB_B(n_GetBoolean_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetBoolean_IZ(nint jnienv, nint native__this, int index, sbyte native_defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			TypedArray? typedArray = Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool defValue = native_defValue != 0;
			return typedArray.GetBoolean(index, defValue) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("getBoolean", "(IZ)Z", "GetGetBoolean_IZHandler")]
	public unsafe virtual bool GetBoolean(int index, bool defValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defValue ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("getBoolean.(IZ)Z", this, ptr);
	}

	private static Delegate GetGetColor_IIHandler()
	{
		return new _JniMarshal_PPII_I(n_GetColor_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColor_II(nint jnienv, nint native__this, int index, int defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetColor(index, defValue).ToArgb();
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

	[Register("getColor", "(II)I", "GetGetColor_IIHandler")]
	public unsafe virtual Color GetColor(int index, int defValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defValue);
		return new Color(_members.InstanceMethods.InvokeVirtualInt32Method("getColor.(II)I", this, ptr));
	}

	private static Delegate GetGetDimension_IFHandler()
	{
		return new _JniMarshal_PPIF_F(n_GetDimension_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetDimension_IF(nint jnienv, nint native__this, int index, float defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDimension(index, defValue);
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

	[Register("getDimension", "(IF)F", "GetGetDimension_IFHandler")]
	public unsafe virtual float GetDimension(int index, float defValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defValue);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getDimension.(IF)F", this, ptr);
	}

	private static Delegate GetGetDimensionPixelSize_IIHandler()
	{
		return new _JniMarshal_PPII_I(n_GetDimensionPixelSize_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDimensionPixelSize_II(nint jnienv, nint native__this, int index, int defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDimensionPixelSize(index, defValue);
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

	[Register("getDimensionPixelSize", "(II)I", "GetGetDimensionPixelSize_IIHandler")]
	public unsafe virtual int GetDimensionPixelSize(int index, int defValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defValue);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getDimensionPixelSize.(II)I", this, ptr);
	}

	private static Delegate GetGetDrawable_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetDrawable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDrawable_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDrawable(index));
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

	[Register("getDrawable", "(I)Landroid/graphics/drawable/Drawable;", "GetGetDrawable_IHandler")]
	public unsafe virtual Drawable? GetDrawable(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDrawable.(I)Landroid/graphics/drawable/Drawable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetFloat_IFHandler()
	{
		return new _JniMarshal_PPIF_F(n_GetFloat_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloat_IF(nint jnienv, nint native__this, int index, float defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFloat(index, defValue);
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

	[Register("getFloat", "(IF)F", "GetGetFloat_IFHandler")]
	public unsafe virtual float GetFloat(int index, float defValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defValue);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getFloat.(IF)F", this, ptr);
	}

	private static Delegate GetGetIndex_IHandler()
	{
		return new _JniMarshal_PPI_I(n_GetIndex_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIndex_I(nint jnienv, nint native__this, int at)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetIndex(at);
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

	[Register("getIndex", "(I)I", "GetGetIndex_IHandler")]
	public unsafe virtual int GetIndex(int at)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(at);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getIndex.(I)I", this, ptr);
	}

	private static Delegate GetGetInt_IIHandler()
	{
		return new _JniMarshal_PPII_I(n_GetInt_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInt_II(nint jnienv, nint native__this, int index, int defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInt(index, defValue);
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

	[Register("getInt", "(II)I", "GetGetInt_IIHandler")]
	public unsafe virtual int GetInt(int index, int defValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defValue);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getInt.(II)I", this, ptr);
	}

	private static Delegate GetGetInteger_IIHandler()
	{
		return new _JniMarshal_PPII_I(n_GetInteger_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInteger_II(nint jnienv, nint native__this, int index, int defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInteger(index, defValue);
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

	[Register("getInteger", "(II)I", "GetGetInteger_IIHandler")]
	public unsafe virtual int GetInteger(int index, int defValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defValue);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getInteger.(II)I", this, ptr);
	}

	private static Delegate GetGetResourceId_IIHandler()
	{
		return new _JniMarshal_PPII_I(n_GetResourceId_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetResourceId_II(nint jnienv, nint native__this, int index, int defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetResourceId(index, defValue);
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

	[Register("getResourceId", "(II)I", "GetGetResourceId_IIHandler")]
	public unsafe virtual int GetResourceId(int index, int defValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defValue);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getResourceId.(II)I", this, ptr);
	}

	private static Delegate GetGetString_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetString_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetString_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetString(index));
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

	[Register("getString", "(I)Ljava/lang/String;", "GetGetString_IHandler")]
	public unsafe virtual string? GetString(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getString.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetText_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetText_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetText_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTextFormatted(index));
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

	[Register("getText", "(I)Ljava/lang/CharSequence;", "GetGetText_IHandler")]
	public unsafe virtual ICharSequence? GetTextFormatted(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getText.(I)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public string? GetText(int index)
	{
		return GetTextFormatted(index)?.ToString();
	}

	private static Delegate GetPeekValue_IHandler()
	{
		return new _JniMarshal_PPI_L(n_PeekValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PeekValue_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeekValue(index));
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

	[Register("peekValue", "(I)Landroid/util/TypedValue;", "GetPeekValue_IHandler")]
	public unsafe virtual TypedValue? PeekValue(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<TypedValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("peekValue.(I)Landroid/util/TypedValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRecycleHandler()
	{
		return new _JniMarshal_PP_V(n_Recycle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Recycle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TypedArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Recycle();
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

	[Register("recycle", "()V", "GetRecycleHandler")]
	public unsafe virtual void Recycle()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("recycle.()V", this, null);
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
