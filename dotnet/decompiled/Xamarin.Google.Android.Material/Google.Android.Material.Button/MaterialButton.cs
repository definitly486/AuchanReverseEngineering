using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.Shape;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Button;

[Register("com/google/android/material/button/MaterialButton", DoNotGenerateAcw = true)]
public class MaterialButton : AppCompatButton, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/google/android/material/button/MaterialButton$OnCheckedChangeListener", "", "Google.Android.Material.Button.MaterialButton/IOnCheckedChangeListenerInvoker")]
	public interface IOnCheckedChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCheckedChanged", "(Lcom/google/android/material/button/MaterialButton;Z)V", "GetOnCheckedChanged_Lcom_google_android_material_button_MaterialButton_ZHandler:Google.Android.Material.Button.MaterialButton/IOnCheckedChangeListenerInvoker, Xamarin.Google.Android.Material")]
		void OnCheckedChanged(MaterialButton? p0, bool p1);
	}

	[Register("com/google/android/material/button/MaterialButton$OnCheckedChangeListener", DoNotGenerateAcw = true)]
	internal class IOnCheckedChangeListenerInvoker : Java.Lang.Object, IOnCheckedChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_button_MaterialButton_OnCheckedChangeListener = new XAPeerMembers("com/google/android/material/button/MaterialButton$OnCheckedChangeListener", typeof(IOnCheckedChangeListenerInvoker));

		private static Delegate? cb_onCheckedChanged_OnCheckedChanged_Lcom_google_android_material_button_MaterialButton_Z_V;

		private static nint java_class_ref => _members_com_google_android_material_button_MaterialButton_OnCheckedChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_button_MaterialButton_OnCheckedChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_button_MaterialButton_OnCheckedChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_button_MaterialButton_OnCheckedChangeListener.ManagedPeerType;

		public IOnCheckedChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnCheckedChanged_Lcom_google_android_material_button_MaterialButton_Z(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnCheckedChangeListener? onCheckedChangeListener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MaterialButton p = Java.Lang.Object.GetObject<MaterialButton>(native_p0, JniHandleOwnership.DoNotTransfer);
				bool p2 = native_p1 != 0;
				onCheckedChangeListener.OnCheckedChanged(p, p2);
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

		public unsafe void OnCheckedChanged(MaterialButton? p0, bool p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
				_members_com_google_android_material_button_MaterialButton_OnCheckedChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onCheckedChanged.(Lcom/google/android/material/button/MaterialButton;Z)V", this, ptr);
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

		[UnmanagedCallersOnly]
		private static void n_OnCheckedChanged_Lcom_google_android_material_button_MaterialButton_Z_mm_wrapper(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnCheckedChanged_Lcom_google_android_material_button_MaterialButton_Z(jnienv, native__this, native_p0, native_p1);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class CheckedChangeEventArgs : EventArgs
	{
		private MaterialButton? p0;

		private bool p1;

		public CheckedChangeEventArgs(MaterialButton? p0, bool p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}

	[Register("mono/com/google/android/material/button/MaterialButton_OnCheckedChangeListenerImplementor")]
	internal sealed class IOnCheckedChangeListenerImplementor : Java.Lang.Object, IOnCheckedChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<CheckedChangeEventArgs>? Handler;

		public unsafe IOnCheckedChangeListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnCheckedChanged(MaterialButton? p0, bool p1)
		{
			Handler?.Invoke(sender, new CheckedChangeEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IOnCheckedChangeListenerImplementor value)
		{
			return value.Handler == null;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/button/MaterialButton", typeof(MaterialButton));

	private static Delegate? cb_isCheckable_IsCheckable_Z;

	private static Delegate? cb_setCheckable_SetCheckable_Z_V;

	private static Delegate? cb_isChecked_IsChecked_Z;

	private static Delegate? cb_setChecked_SetChecked_Z_V;

	private static Delegate? cb_getCornerRadius_GetCornerRadius_I;

	private static Delegate? cb_setCornerRadius_SetCornerRadius_I_V;

	private static Delegate? cb_getIcon_GetIcon_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getIconGravity_GetIconGravity_I;

	private static Delegate? cb_setIconGravity_SetIconGravity_I_V;

	private static Delegate? cb_getIconPadding_GetIconPadding_I;

	private static Delegate? cb_setIconPadding_SetIconPadding_I_V;

	private static Delegate? cb_getIconSize_GetIconSize_I;

	private static Delegate? cb_setIconSize_SetIconSize_I_V;

	private static Delegate? cb_getIconTint_GetIconTint_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setIconTint_SetIconTint_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getIconTintMode_GetIconTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setIconTintMode_SetIconTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_getInsetBottom_GetInsetBottom_I;

	private static Delegate? cb_setInsetBottom_SetInsetBottom_I_V;

	private static Delegate? cb_getInsetTop_GetInsetTop_I;

	private static Delegate? cb_setInsetTop_SetInsetTop_I_V;

	private static Delegate? cb_getRippleColor_GetRippleColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setRippleColor_SetRippleColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getShapeAppearanceModel_GetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_setShapeAppearanceModel_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel__V;

	private static Delegate? cb_getStrokeColor_GetStrokeColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setStrokeColor_SetStrokeColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getStrokeWidth_GetStrokeWidth_I;

	private static Delegate? cb_setStrokeWidth_SetStrokeWidth_I_V;

	private static Delegate? cb_isToggleCheckedStateOnClick_IsToggleCheckedStateOnClick_Z;

	private static Delegate? cb_setToggleCheckedStateOnClick_SetToggleCheckedStateOnClick_Z_V;

	private static Delegate? cb_addOnCheckedChangeListener_AddOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener__V;

	private static Delegate? cb_clearOnCheckedChangeListeners_ClearOnCheckedChangeListeners_V;

	private static Delegate? cb_removeOnCheckedChangeListener_RemoveOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener__V;

	private static Delegate? cb_setCornerRadiusResource_SetCornerRadiusResource_I_V;

	private static Delegate? cb_setIconResource_SetIconResource_I_V;

	private static Delegate? cb_setIconTintResource_SetIconTintResource_I_V;

	private static Delegate? cb_setRippleColorResource_SetRippleColorResource_I_V;

	private static Delegate? cb_setStrokeColorResource_SetStrokeColorResource_I_V;

	private static Delegate? cb_setStrokeWidthResource_SetStrokeWidthResource_I_V;

	private static Delegate? cb_toggle_Toggle_V;

	private WeakReference? weak_implementor_AddOnCheckedChangeListener;

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

	public unsafe virtual bool Checkable
	{
		[Register("isCheckable", "()Z", "GetIsCheckableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCheckable.()Z", this, null);
		}
		[Register("setCheckable", "(Z)V", "GetSetCheckable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Checked
	{
		[Register("isChecked", "()Z", "GetIsCheckedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isChecked.()Z", this, null);
		}
		[Register("setChecked", "(Z)V", "GetSetChecked_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setChecked.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int CornerRadius
	{
		[Register("getCornerRadius", "()I", "GetGetCornerRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCornerRadius.()I", this, null);
		}
		[Register("setCornerRadius", "(I)V", "GetSetCornerRadius_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerRadius.(I)V", this, ptr);
		}
	}

	public unsafe virtual Drawable? Icon
	{
		[Register("getIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetIconHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int IconGravity
	{
		[Register("getIconGravity", "()I", "GetGetIconGravityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIconGravity.()I", this, null);
		}
		[Register("setIconGravity", "(I)V", "GetSetIconGravity_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIconGravity.(I)V", this, ptr);
		}
	}

	public unsafe virtual int IconPadding
	{
		[Register("getIconPadding", "()I", "GetGetIconPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIconPadding.()I", this, null);
		}
		[Register("setIconPadding", "(I)V", "GetSetIconPadding_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIconPadding.(I)V", this, ptr);
		}
	}

	public unsafe virtual int IconSize
	{
		[Register("getIconSize", "()I", "GetGetIconSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIconSize.()I", this, null);
		}
		[Register("setIconSize", "(I)V", "GetSetIconSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIconSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? IconTint
	{
		[Register("getIconTint", "()Landroid/content/res/ColorStateList;", "GetGetIconTintHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTint.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setIconTint", "(Landroid/content/res/ColorStateList;)V", "GetSetIconTint_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIconTint.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? IconTintMode
	{
		[Register("getIconTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetIconTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIconTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int InsetBottom
	{
		[Register("getInsetBottom", "()I", "GetGetInsetBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInsetBottom.()I", this, null);
		}
		[Register("setInsetBottom", "(I)V", "GetSetInsetBottom_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInsetBottom.(I)V", this, ptr);
		}
	}

	public unsafe virtual int InsetTop
	{
		[Register("getInsetTop", "()I", "GetGetInsetTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInsetTop.()I", this, null);
		}
		[Register("setInsetTop", "(I)V", "GetSetInsetTop_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInsetTop.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? RippleColor
	{
		[Register("getRippleColor", "()Landroid/content/res/ColorStateList;", "GetGetRippleColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRippleColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setRippleColor", "(Landroid/content/res/ColorStateList;)V", "GetSetRippleColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ShapeAppearanceModel ShapeAppearanceModel
	{
		[Register("getShapeAppearanceModel", "()Lcom/google/android/material/shape/ShapeAppearanceModel;", "GetGetShapeAppearanceModelHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShapeAppearanceModel.()Lcom/google/android/material/shape/ShapeAppearanceModel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setShapeAppearanceModel", "(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", "GetSetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShapeAppearanceModel.(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? StrokeColor
	{
		[Register("getStrokeColor", "()Landroid/content/res/ColorStateList;", "GetGetStrokeColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStrokeColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStrokeColor", "(Landroid/content/res/ColorStateList;)V", "GetSetStrokeColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int StrokeWidth
	{
		[Register("getStrokeWidth", "()I", "GetGetStrokeWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStrokeWidth.()I", this, null);
		}
		[Register("setStrokeWidth", "(I)V", "GetSetStrokeWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool ToggleCheckedStateOnClick
	{
		[Register("isToggleCheckedStateOnClick", "()Z", "GetIsToggleCheckedStateOnClickHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isToggleCheckedStateOnClick.()Z", this, null);
		}
		[Register("setToggleCheckedStateOnClick", "(Z)V", "GetSetToggleCheckedStateOnClick_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setToggleCheckedStateOnClick.(Z)V", this, ptr);
		}
	}

	public event EventHandler<CheckedChangeEventArgs> CheckedChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnCheckedChangeListener, IOnCheckedChangeListenerImplementor>(ref weak_implementor_AddOnCheckedChangeListener, __CreateIOnCheckedChangeListenerImplementor, AddOnCheckedChangeListener, delegate(IOnCheckedChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CheckedChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnCheckedChangeListener, IOnCheckedChangeListenerImplementor.__IsEmpty, delegate(IOnCheckedChangeListener __v)
			{
				RemoveOnCheckedChangeListener(__v);
			}, delegate(IOnCheckedChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CheckedChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected MaterialButton(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe MaterialButton(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe MaterialButton(Context context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe MaterialButton(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetIsCheckableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCheckable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCheckable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Checkable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetCheckable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCheckable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckable_Z(nint jnienv, nint native__this, sbyte native_checkable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool checkable = native_checkable != 0;
			materialButton.Checkable = checkable;
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

	private static Delegate GetIsCheckedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsChecked);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsChecked(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Checked ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetChecked_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetChecked_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetChecked_Z(nint jnienv, nint native__this, sbyte native__checked)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native__checked != 0;
			materialButton.Checked = flag;
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

	private static Delegate GetGetCornerRadiusHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCornerRadius);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCornerRadius(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CornerRadius;
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

	private static Delegate GetSetCornerRadius_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCornerRadius_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCornerRadius_I(nint jnienv, nint native__this, int cornerRadius)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CornerRadius = cornerRadius;
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

	private static Delegate GetGetIconHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Icon);
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

	private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			materialButton.Icon = icon;
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

	private static Delegate GetGetIconGravityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetIconGravity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIconGravity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconGravity;
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

	private static Delegate GetSetIconGravity_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIconGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconGravity_I(nint jnienv, nint native__this, int iconGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconGravity = iconGravity;
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

	private static Delegate GetGetIconPaddingHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetIconPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIconPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconPadding;
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

	private static Delegate GetSetIconPadding_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIconPadding_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconPadding_I(nint jnienv, nint native__this, int iconPadding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconPadding = iconPadding;
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

	private static Delegate GetGetIconSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetIconSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIconSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconSize;
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

	private static Delegate GetSetIconSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIconSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconSize_I(nint jnienv, nint native__this, int iconSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconSize = iconSize;
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

	private static Delegate GetGetIconTintHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetIconTint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIconTint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconTint);
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

	private static Delegate GetSetIconTint_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIconTint_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconTint_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_iconTint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList iconTint = Java.Lang.Object.GetObject<ColorStateList>(native_iconTint, JniHandleOwnership.DoNotTransfer);
			materialButton.IconTint = iconTint;
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

	private static Delegate GetGetIconTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetIconTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIconTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconTintMode);
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

	private static Delegate GetSetIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIconTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_iconTintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode iconTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_iconTintMode, JniHandleOwnership.DoNotTransfer);
			materialButton.IconTintMode = iconTintMode;
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

	private static Delegate GetGetInsetBottomHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetInsetBottom);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInsetBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InsetBottom;
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

	private static Delegate GetSetInsetBottom_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetInsetBottom_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInsetBottom_I(nint jnienv, nint native__this, int insetBottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InsetBottom = insetBottom;
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

	private static Delegate GetGetInsetTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetInsetTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInsetTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InsetTop;
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

	private static Delegate GetSetInsetTop_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetInsetTop_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInsetTop_I(nint jnienv, nint native__this, int insetTop)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InsetTop = insetTop;
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

	private static Delegate GetGetRippleColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRippleColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRippleColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColor);
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

	private static Delegate GetSetRippleColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRippleColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRippleColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_rippleColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList rippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_rippleColor, JniHandleOwnership.DoNotTransfer);
			materialButton.RippleColor = rippleColor;
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

	private static Delegate GetGetShapeAppearanceModelHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetShapeAppearanceModel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetShapeAppearanceModel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShapeAppearanceModel);
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

	private static Delegate GetSetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_(nint jnienv, nint native__this, nint native_shapeAppearanceModel)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapeAppearanceModel shapeAppearanceModel = Java.Lang.Object.GetObject<ShapeAppearanceModel>(native_shapeAppearanceModel, JniHandleOwnership.DoNotTransfer);
			materialButton.ShapeAppearanceModel = shapeAppearanceModel;
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

	private static Delegate GetGetStrokeColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStrokeColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStrokeColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeColor);
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

	private static Delegate GetSetStrokeColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStrokeColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_strokeColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList strokeColor = Java.Lang.Object.GetObject<ColorStateList>(native_strokeColor, JniHandleOwnership.DoNotTransfer);
			materialButton.StrokeColor = strokeColor;
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

	private static Delegate GetGetStrokeWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStrokeWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStrokeWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth;
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

	private static Delegate GetSetStrokeWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStrokeWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeWidth_I(nint jnienv, nint native__this, int strokeWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth = strokeWidth;
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

	private static Delegate GetIsToggleCheckedStateOnClickHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsToggleCheckedStateOnClick);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsToggleCheckedStateOnClick(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToggleCheckedStateOnClick ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetToggleCheckedStateOnClick_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetToggleCheckedStateOnClick_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetToggleCheckedStateOnClick_Z(nint jnienv, nint native__this, sbyte native_toggleCheckedStateOnClick)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool toggleCheckedStateOnClick = native_toggleCheckedStateOnClick != 0;
			materialButton.ToggleCheckedStateOnClick = toggleCheckedStateOnClick;
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

	private static Delegate GetAddOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCheckedChangeListener listener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			materialButton.AddOnCheckedChangeListener(listener);
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

	[Register("addOnCheckedChangeListener", "(Lcom/google/android/material/button/MaterialButton$OnCheckedChangeListener;)V", "GetAddOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener_Handler")]
	public unsafe virtual void AddOnCheckedChangeListener(IOnCheckedChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnCheckedChangeListener.(Lcom/google/android/material/button/MaterialButton$OnCheckedChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetClearOnCheckedChangeListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnCheckedChangeListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnCheckedChangeListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnCheckedChangeListeners();
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

	[Register("clearOnCheckedChangeListeners", "()V", "GetClearOnCheckedChangeListenersHandler")]
	public unsafe virtual void ClearOnCheckedChangeListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnCheckedChangeListeners.()V", this, null);
	}

	private static Delegate GetRemoveOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialButton? materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCheckedChangeListener listener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			materialButton.RemoveOnCheckedChangeListener(listener);
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

	[Register("removeOnCheckedChangeListener", "(Lcom/google/android/material/button/MaterialButton$OnCheckedChangeListener;)V", "GetRemoveOnCheckedChangeListener_Lcom_google_android_material_button_MaterialButton_OnCheckedChangeListener_Handler")]
	public unsafe virtual void RemoveOnCheckedChangeListener(IOnCheckedChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnCheckedChangeListener.(Lcom/google/android/material/button/MaterialButton$OnCheckedChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetCornerRadiusResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCornerRadiusResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCornerRadiusResource_I(nint jnienv, nint native__this, int cornerRadiusResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCornerRadiusResource(cornerRadiusResourceId);
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

	[Register("setCornerRadiusResource", "(I)V", "GetSetCornerRadiusResource_IHandler")]
	public unsafe virtual void SetCornerRadiusResource(int cornerRadiusResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cornerRadiusResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerRadiusResource.(I)V", this, ptr);
	}

	private static Delegate GetSetIconResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIconResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconResource_I(nint jnienv, nint native__this, int iconResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIconResource(iconResourceId);
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

	[Register("setIconResource", "(I)V", "GetSetIconResource_IHandler")]
	public unsafe virtual void SetIconResource(int iconResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setIconResource.(I)V", this, ptr);
	}

	private static Delegate GetSetIconTintResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIconTintResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconTintResource_I(nint jnienv, nint native__this, int iconTintResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIconTintResource(iconTintResourceId);
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

	[Register("setIconTintResource", "(I)V", "GetSetIconTintResource_IHandler")]
	public unsafe virtual void SetIconTintResource(int iconTintResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconTintResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setIconTintResource.(I)V", this, ptr);
	}

	private static Delegate GetSetRippleColorResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetRippleColorResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRippleColorResource_I(nint jnienv, nint native__this, int rippleColorResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRippleColorResource(rippleColorResourceId);
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

	[Register("setRippleColorResource", "(I)V", "GetSetRippleColorResource_IHandler")]
	public unsafe virtual void SetRippleColorResource(int rippleColorResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(rippleColorResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColorResource.(I)V", this, ptr);
	}

	private static Delegate GetSetStrokeColorResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStrokeColorResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeColorResource_I(nint jnienv, nint native__this, int strokeColorResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStrokeColorResource(strokeColorResourceId);
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

	[Register("setStrokeColorResource", "(I)V", "GetSetStrokeColorResource_IHandler")]
	public unsafe virtual void SetStrokeColorResource(int strokeColorResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(strokeColorResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeColorResource.(I)V", this, ptr);
	}

	private static Delegate GetSetStrokeWidthResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStrokeWidthResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeWidthResource_I(nint jnienv, nint native__this, int strokeWidthResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStrokeWidthResource(strokeWidthResourceId);
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

	[Register("setStrokeWidthResource", "(I)V", "GetSetStrokeWidthResource_IHandler")]
	public unsafe virtual void SetStrokeWidthResource(int strokeWidthResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(strokeWidthResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeWidthResource.(I)V", this, ptr);
	}

	private static Delegate GetToggleHandler()
	{
		return new global::_JniMarshal_PP_V(n_Toggle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Toggle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Toggle();
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

	[Register("toggle", "()V", "GetToggleHandler")]
	public unsafe virtual void Toggle()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("toggle.()V", this, null);
	}

	private IOnCheckedChangeListenerImplementor __CreateIOnCheckedChangeListenerImplementor()
	{
		return new IOnCheckedChangeListenerImplementor(this);
	}
}
