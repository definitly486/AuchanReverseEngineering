using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.App;

[Register("androidx/core/app/NotificationChannelGroupCompat", DoNotGenerateAcw = true)]
public class NotificationChannelGroupCompat : Java.Lang.Object
{
	[Register("androidx/core/app/NotificationChannelGroupCompat$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/NotificationChannelGroupCompat$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Landroidx_core_app_NotificationChannelGroupCompat_;

		private static Delegate? cb_setDescription_SetDescription_Ljava_lang_String__Landroidx_core_app_NotificationChannelGroupCompat_Builder_;

		private static Delegate? cb_setName_SetName_Ljava_lang_CharSequence__Landroidx_core_app_NotificationChannelGroupCompat_Builder_;

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

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe Builder(string? id)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetBuildHandler()
		{
			return new global::_JniMarshal_PP_L(n_Build);
		}

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

		[Register("build", "()Landroidx/core/app/NotificationChannelGroupCompat;", "GetBuildHandler")]
		public unsafe virtual NotificationChannelGroupCompat? Build()
		{
			return Java.Lang.Object.GetObject<NotificationChannelGroupCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Landroidx/core/app/NotificationChannelGroupCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetDescription_Ljava_lang_String_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetDescription_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetDescription_Ljava_lang_String_(nint jnienv, nint native__this, nint native_description)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string description = JNIEnv.GetString(native_description, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetDescription(description));
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

		[Register("setDescription", "(Ljava/lang/String;)Landroidx/core/app/NotificationChannelGroupCompat$Builder;", "GetSetDescription_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? SetDescription(string? description)
		{
			nint num = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDescription.(Ljava/lang/String;)Landroidx/core/app/NotificationChannelGroupCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetSetName_Ljava_lang_CharSequence_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetName_Ljava_lang_CharSequence_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetName_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_name)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence name = Java.Lang.Object.GetObject<ICharSequence>(native_name, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetName(name));
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

		[Register("setName", "(Ljava/lang/CharSequence;)Landroidx/core/app/NotificationChannelGroupCompat$Builder;", "GetSetName_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual Builder? SetName(ICharSequence? name)
		{
			nint num = CharSequence.ToLocalJniHandle(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setName.(Ljava/lang/CharSequence;)Landroidx/core/app/NotificationChannelGroupCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(name);
			}
		}

		public Builder? SetName(string? name)
		{
			Java.Lang.String obj = ((name == null) ? null : new Java.Lang.String(name));
			Builder? result = SetName(obj);
			obj?.Dispose();
			return result;
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/NotificationChannelGroupCompat", typeof(NotificationChannelGroupCompat));

	private static Delegate? cb_getChannels_GetChannels_Ljava_util_List_;

	private static Delegate? cb_getDescription_GetDescription_Ljava_lang_String_;

	private static Delegate? cb_getId_GetId_Ljava_lang_String_;

	private static Delegate? cb_isBlocked_IsBlocked_Z;

	private static Delegate? cb_getName_GetName_Ljava_lang_CharSequence_;

	private static Delegate? cb_toBuilder_ToBuilder_Landroidx_core_app_NotificationChannelGroupCompat_Builder_;

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

	public unsafe virtual IList<NotificationChannelCompat>? Channels
	{
		[Register("getChannels", "()Ljava/util/List;", "GetGetChannelsHandler")]
		get
		{
			return JavaList<NotificationChannelCompat>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getChannels.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? Description
	{
		[Register("getDescription", "()Ljava/lang/String;", "GetGetDescriptionHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? Id
	{
		[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsBlocked
	{
		[Register("isBlocked", "()Z", "GetIsBlockedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isBlocked.()Z", this, null);
		}
	}

	public unsafe virtual ICharSequence? NameFormatted
	{
		[Register("getName", "()Ljava/lang/CharSequence;", "GetGetNameHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? Name
	{
		get
		{
			if (NameFormatted != null)
			{
				return NameFormatted.ToString();
			}
			return null;
		}
	}

	protected NotificationChannelGroupCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetChannelsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetChannels);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetChannels(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<NotificationChannelCompat>.ToLocalJniHandle(Java.Lang.Object.GetObject<NotificationChannelGroupCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Channels);
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

	private static Delegate GetGetDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<NotificationChannelGroupCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Description);
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

	private static Delegate GetGetIdHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<NotificationChannelGroupCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
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

	private static Delegate GetIsBlockedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsBlocked);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsBlocked(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelGroupCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsBlocked ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<NotificationChannelGroupCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NameFormatted);
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

	private static Delegate GetToBuilderHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToBuilder);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToBuilder(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NotificationChannelGroupCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToBuilder());
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

	[Register("toBuilder", "()Landroidx/core/app/NotificationChannelGroupCompat$Builder;", "GetToBuilderHandler")]
	public unsafe virtual Builder? ToBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("toBuilder.()Landroidx/core/app/NotificationChannelGroupCompat$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
