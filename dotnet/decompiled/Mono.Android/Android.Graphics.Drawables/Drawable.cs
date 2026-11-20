using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content.PM;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics.Drawables;

[Register("android/graphics/drawable/Drawable", DoNotGenerateAcw = true)]
public abstract class Drawable : Java.Lang.Object
{
	[Register("android/graphics/drawable/Drawable$ConstantState", DoNotGenerateAcw = true)]
	public abstract class ConstantState : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/Drawable$ConstantState", typeof(ConstantState));

		private static Delegate? cb_getChangingConfigurations_GetChangingConfigurations_I;

		private static Delegate? cb_newDrawable_NewDrawable_Landroid_graphics_drawable_Drawable_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract ConfigChanges ChangingConfigurations
		{
			[Register("getChangingConfigurations", "()I", "GetGetChangingConfigurationsHandler")]
			get;
		}

		protected ConstantState(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetChangingConfigurationsHandler()
		{
			return new _JniMarshal_PP_I(n_GetChangingConfigurations);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetChangingConfigurations(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return (int)Java.Lang.Object.GetObject<ConstantState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChangingConfigurations;
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

		private static Delegate GetNewDrawableHandler()
		{
			return new _JniMarshal_PP_L(n_NewDrawable);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_NewDrawable(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstantState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewDrawable());
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

		[Register("newDrawable", "()Landroid/graphics/drawable/Drawable;", "GetNewDrawableHandler")]
		public abstract Drawable NewDrawable();
	}

	[Register("android/graphics/drawable/Drawable$ConstantState", DoNotGenerateAcw = true)]
	internal class ConstantStateInvoker : ConstantState
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/Drawable$ConstantState", typeof(ConstantStateInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override ConfigChanges ChangingConfigurations
		{
			[Register("getChangingConfigurations", "()I", "GetGetChangingConfigurationsHandler")]
			get
			{
				return (ConfigChanges)_members.InstanceMethods.InvokeAbstractInt32Method("getChangingConfigurations.()I", this, null);
			}
		}

		public ConstantStateInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("newDrawable", "()Landroid/graphics/drawable/Drawable;", "GetNewDrawableHandler")]
		public unsafe override Drawable NewDrawable()
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeAbstractObjectMethod("newDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/Drawable", typeof(Drawable));

	private static Delegate? cb_getIntrinsicHeight_GetIntrinsicHeight_I;

	private static Delegate? cb_getIntrinsicWidth_GetIntrinsicWidth_I;

	private static Delegate? cb_getOpacity_GetOpacity_I;

	private static Delegate? cb_draw_Draw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_mutate_Mutate_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_onStateChange_OnStateChange_arrayI_Z;

	private static Delegate? cb_setAlpha_SetAlpha_I_V;

	private static Delegate? cb_setBounds_SetBounds_IIII_V;

	private static Delegate? cb_setColorFilter_SetColorFilter_Landroid_graphics_ColorFilter__V;

	private static Delegate? cb_setTint_SetTint_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Rect Bounds
	{
		[Register("getBounds", "()Landroid/graphics/Rect;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBounds.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setBounds", "(Landroid/graphics/Rect;)V", "GetSetBounds_Landroid_graphics_Rect_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBounds.(Landroid/graphics/Rect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int IntrinsicHeight
	{
		[Register("getIntrinsicHeight", "()I", "GetGetIntrinsicHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIntrinsicHeight.()I", this, null);
		}
	}

	public unsafe virtual int IntrinsicWidth
	{
		[Register("getIntrinsicWidth", "()I", "GetGetIntrinsicWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIntrinsicWidth.()I", this, null);
		}
	}

	public abstract int Opacity
	{
		[Register("getOpacity", "()I", "GetGetOpacityHandler")]
		get;
	}

	protected Drawable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetIntrinsicHeightHandler()
	{
		return new _JniMarshal_PP_I(n_GetIntrinsicHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIntrinsicHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntrinsicHeight;
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

	private static Delegate GetGetIntrinsicWidthHandler()
	{
		return new _JniMarshal_PP_I(n_GetIntrinsicWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIntrinsicWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntrinsicWidth;
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

	[ObsoletedOSPlatform("android29.0")]
	private static Delegate GetGetOpacityHandler()
	{
		return new _JniMarshal_PP_I(n_GetOpacity);
	}

	[ObsoletedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOpacity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Opacity;
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

	private static Delegate GetDraw_Landroid_graphics_Canvas_Handler()
	{
		return new _JniMarshal_PPL_V(n_Draw_Landroid_graphics_Canvas_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Draw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_canvas)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Drawable? drawable = Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			drawable.Draw(canvas);
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

	[Register("draw", "(Landroid/graphics/Canvas;)V", "GetDraw_Landroid_graphics_Canvas_Handler")]
	public abstract void Draw(Canvas canvas);

	private static Delegate GetMutateHandler()
	{
		return new _JniMarshal_PP_L(n_Mutate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Mutate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Mutate());
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

	[Register("mutate", "()Landroid/graphics/drawable/Drawable;", "GetMutateHandler")]
	public unsafe virtual Drawable Mutate()
	{
		return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("mutate.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnStateChange_arrayIHandler()
	{
		return new _JniMarshal_PPL_B(n_OnStateChange_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnStateChange_arrayI(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Drawable? drawable = Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_state, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (drawable.OnStateChange(array) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_state);
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

	[Register("onStateChange", "([I)Z", "GetOnStateChange_arrayIHandler")]
	protected unsafe virtual bool OnStateChange(int[] state)
	{
		nint num = JNIEnv.NewArray(state);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStateChange.([I)Z", this, ptr);
		}
		finally
		{
			if (state != null)
			{
				JNIEnv.CopyArray(num, state);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetSetAlpha_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetAlpha_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAlpha_I(nint jnienv, nint native__this, int alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlpha(alpha);
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

	[Register("setAlpha", "(I)V", "GetSetAlpha_IHandler")]
	public abstract void SetAlpha(int alpha);

	private static Delegate GetSetBounds_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_SetBounds_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBounds_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBounds(left, top, right, bottom);
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

	[Register("setBounds", "(IIII)V", "GetSetBounds_IIIIHandler")]
	public unsafe virtual void SetBounds(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBounds.(IIII)V", this, ptr);
	}

	private static Delegate GetSetColorFilter_Landroid_graphics_ColorFilter_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetColorFilter_Landroid_graphics_ColorFilter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColorFilter_Landroid_graphics_ColorFilter_(nint jnienv, nint native__this, nint native_colorFilter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Drawable? drawable = Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorFilter colorFilter = Java.Lang.Object.GetObject<ColorFilter>(native_colorFilter, JniHandleOwnership.DoNotTransfer);
			drawable.SetColorFilter(colorFilter);
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

	[Register("setColorFilter", "(Landroid/graphics/ColorFilter;)V", "GetSetColorFilter_Landroid_graphics_ColorFilter_Handler")]
	public abstract void SetColorFilter(ColorFilter? colorFilter);

	private static Delegate GetSetTint_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetTint_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTint_I(nint jnienv, nint native__this, int tintColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Drawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTint(tintColor);
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

	[Register("setTint", "(I)V", "GetSetTint_IHandler")]
	public unsafe virtual void SetTint(int tintColor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(tintColor);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTint.(I)V", this, ptr);
	}
}
