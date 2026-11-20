using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content.PM;

[SupportedOSPlatform("android25.0")]
[Register("android/content/pm/ShortcutInfo", DoNotGenerateAcw = true, ApiSince = 25)]
public sealed class ShortcutInfo : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android25.0")]
	[Register("android/content/pm/ShortcutInfo$Builder", DoNotGenerateAcw = true, ApiSince = 25)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/ShortcutInfo$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Landroid_content_pm_ShortcutInfo_;

		private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Icon__Landroid_content_pm_ShortcutInfo_Builder_;

		private static Delegate? cb_setIntent_SetIntent_Landroid_content_Intent__Landroid_content_pm_ShortcutInfo_Builder_;

		private static Delegate? cb_setLongLabel_SetLongLabel_Ljava_lang_CharSequence__Landroid_content_pm_ShortcutInfo_Builder_;

		private static Delegate? cb_setShortLabel_SetShortLabel_Ljava_lang_CharSequence__Landroid_content_pm_ShortcutInfo_Builder_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[SupportedOSPlatform("android25.0")]
		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;)V", "", ApiSince = 25)]
		public unsafe Builder(Context? context, string? id)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(context);
			}
		}

		[SupportedOSPlatform("android25.0")]
		private static Delegate GetBuildHandler()
		{
			return new _JniMarshal_PP_L(n_Build);
		}

		[SupportedOSPlatform("android25.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Build(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
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

		[SupportedOSPlatform("android25.0")]
		[Register("build", "()Landroid/content/pm/ShortcutInfo;", "GetBuildHandler", ApiSince = 25)]
		public unsafe virtual ShortcutInfo Build()
		{
			return Java.Lang.Object.GetObject<ShortcutInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Landroid/content/pm/ShortcutInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[SupportedOSPlatform("android25.0")]
		private static Delegate GetSetIcon_Landroid_graphics_drawable_Icon_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetIcon_Landroid_graphics_drawable_Icon_);
		}

		[SupportedOSPlatform("android25.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetIcon_Landroid_graphics_drawable_Icon_(nint jnienv, nint native__this, nint native_icon)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Icon icon = Java.Lang.Object.GetObject<Icon>(native_icon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetIcon(icon));
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

		[SupportedOSPlatform("android25.0")]
		[Register("setIcon", "(Landroid/graphics/drawable/Icon;)Landroid/content/pm/ShortcutInfo$Builder;", "GetSetIcon_Landroid_graphics_drawable_Icon_Handler", ApiSince = 25)]
		public unsafe virtual Builder SetIcon(Icon? icon)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIcon.(Landroid/graphics/drawable/Icon;)Landroid/content/pm/ShortcutInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(icon);
			}
		}

		[SupportedOSPlatform("android25.0")]
		private static Delegate GetSetIntent_Landroid_content_Intent_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetIntent_Landroid_content_Intent_);
		}

		[SupportedOSPlatform("android25.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetIntent_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_intent)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetIntent(intent));
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

		[SupportedOSPlatform("android25.0")]
		[Register("setIntent", "(Landroid/content/Intent;)Landroid/content/pm/ShortcutInfo$Builder;", "GetSetIntent_Landroid_content_Intent_Handler", ApiSince = 25)]
		public unsafe virtual Builder SetIntent(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIntent.(Landroid/content/Intent;)Landroid/content/pm/ShortcutInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		[SupportedOSPlatform("android25.0")]
		private static Delegate GetSetLongLabel_Ljava_lang_CharSequence_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetLongLabel_Ljava_lang_CharSequence_);
		}

		[SupportedOSPlatform("android25.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetLongLabel_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_longLabel)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence longLabel = Java.Lang.Object.GetObject<ICharSequence>(native_longLabel, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetLongLabel(longLabel));
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

		[SupportedOSPlatform("android25.0")]
		[Register("setLongLabel", "(Ljava/lang/CharSequence;)Landroid/content/pm/ShortcutInfo$Builder;", "GetSetLongLabel_Ljava_lang_CharSequence_Handler", ApiSince = 25)]
		public unsafe virtual Builder SetLongLabel(ICharSequence longLabel)
		{
			nint num = CharSequence.ToLocalJniHandle(longLabel);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLongLabel.(Ljava/lang/CharSequence;)Landroid/content/pm/ShortcutInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(longLabel);
			}
		}

		[SupportedOSPlatform("android25.0")]
		public Builder SetLongLabel(string longLabel)
		{
			Java.Lang.String obj = ((longLabel == null) ? null : new Java.Lang.String(longLabel));
			Builder result = SetLongLabel(obj);
			obj?.Dispose();
			return result;
		}

		[SupportedOSPlatform("android25.0")]
		private static Delegate GetSetShortLabel_Ljava_lang_CharSequence_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetShortLabel_Ljava_lang_CharSequence_);
		}

		[SupportedOSPlatform("android25.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetShortLabel_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_shortLabel)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence shortLabel = Java.Lang.Object.GetObject<ICharSequence>(native_shortLabel, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetShortLabel(shortLabel));
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

		[SupportedOSPlatform("android25.0")]
		[Register("setShortLabel", "(Ljava/lang/CharSequence;)Landroid/content/pm/ShortcutInfo$Builder;", "GetSetShortLabel_Ljava_lang_CharSequence_Handler", ApiSince = 25)]
		public unsafe virtual Builder SetShortLabel(ICharSequence shortLabel)
		{
			nint num = CharSequence.ToLocalJniHandle(shortLabel);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setShortLabel.(Ljava/lang/CharSequence;)Landroid/content/pm/ShortcutInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(shortLabel);
			}
		}

		[SupportedOSPlatform("android25.0")]
		public Builder SetShortLabel(string shortLabel)
		{
			Java.Lang.String obj = ((shortLabel == null) ? null : new Java.Lang.String(shortLabel));
			Builder result = SetShortLabel(obj);
			obj?.Dispose();
			return result;
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/ShortcutInfo", typeof(ShortcutInfo));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal ShortcutInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android25.0")]
	[Register("describeContents", "()I", "", ApiSince = 25)]
	public unsafe int DescribeContents()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
	}

	[SupportedOSPlatform("android25.0")]
	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "", ApiSince = 25)]
	public unsafe void WriteToParcel(Parcel? dest, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
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
