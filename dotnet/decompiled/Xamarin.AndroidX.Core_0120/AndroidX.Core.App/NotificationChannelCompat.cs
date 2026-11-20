using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Media;
using Android.Net;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.App;

[Register("androidx/core/app/NotificationChannelCompat", DoNotGenerateAcw = true)]
public class NotificationChannelCompat : Java.Lang.Object
{
	[Register("androidx/core/app/NotificationChannelCompat$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/NotificationChannelCompat$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Landroidx_core_app_NotificationChannelCompat_;

		private static Delegate? cb_setConversationId_SetConversationId_Ljava_lang_String_Ljava_lang_String__Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setDescription_SetDescription_Ljava_lang_String__Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setGroup_SetGroup_Ljava_lang_String__Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setImportance_SetImportance_I_Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setLightColor_SetLightColor_I_Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setLightsEnabled_SetLightsEnabled_Z_Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setName_SetName_Ljava_lang_CharSequence__Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setShowBadge_SetShowBadge_Z_Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setSound_SetSound_Landroid_net_Uri_Landroid_media_AudioAttributes__Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setVibrationEnabled_SetVibrationEnabled_Z_Landroidx_core_app_NotificationChannelCompat_Builder_;

		private static Delegate? cb_setVibrationPattern_SetVibrationPattern_arrayJ_Landroidx_core_app_NotificationChannelCompat_Builder_;

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

		[Register(".ctor", "(Ljava/lang/String;I)V", "")]
		public unsafe Builder(string? id, int importance)
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
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(importance);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;I)V", this, ptr);
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

		[Register("build", "()Landroidx/core/app/NotificationChannelCompat;", "GetBuildHandler")]
		public unsafe virtual NotificationChannelCompat? Build()
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Landroidx/core/app/NotificationChannelCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetConversationId_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_SetConversationId_Ljava_lang_String_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetConversationId_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_parentChannelId, nint native_conversationId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string parentChannelId = JNIEnv.GetString(native_parentChannelId, JniHandleOwnership.DoNotTransfer);
				string conversationId = JNIEnv.GetString(native_conversationId, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetConversationId(parentChannelId, conversationId));
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

		[Register("setConversationId", "(Ljava/lang/String;Ljava/lang/String;)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetConversationId_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? SetConversationId(string? parentChannelId, string? conversationId)
		{
			nint num = JNIEnv.NewString(parentChannelId);
			nint num2 = JNIEnv.NewString(conversationId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setConversationId.(Ljava/lang/String;Ljava/lang/String;)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
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

		[Register("setDescription", "(Ljava/lang/String;)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetDescription_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? SetDescription(string? description)
		{
			nint num = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDescription.(Ljava/lang/String;)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetSetGroup_Ljava_lang_String_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetGroup_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetGroup_Ljava_lang_String_(nint jnienv, nint native__this, nint native_groupId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string text = JNIEnv.GetString(native_groupId, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetGroup(text));
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

		[Register("setGroup", "(Ljava/lang/String;)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetGroup_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? SetGroup(string? groupId)
		{
			nint num = JNIEnv.NewString(groupId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setGroup.(Ljava/lang/String;)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetSetImportance_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetImportance_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetImportance_I(nint jnienv, nint native__this, int importance)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetImportance(importance));
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

		[Register("setImportance", "(I)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetImportance_IHandler")]
		public unsafe virtual Builder? SetImportance(int importance)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(importance);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setImportance.(I)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetLightColor_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetLightColor_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetLightColor_I(nint jnienv, nint native__this, int argb)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLightColor(argb));
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

		[Register("setLightColor", "(I)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetLightColor_IHandler")]
		public unsafe virtual Builder? SetLightColor(int argb)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(argb);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLightColor.(I)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetLightsEnabled_ZHandler()
		{
			return new global::_JniMarshal_PPB_L(n_SetLightsEnabled_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetLightsEnabled_Z(nint jnienv, nint native__this, sbyte native_lights)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool lightsEnabled = native_lights != 0;
				return JNIEnv.ToLocalJniHandle(builder.SetLightsEnabled(lightsEnabled));
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

		[Register("setLightsEnabled", "(Z)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetLightsEnabled_ZHandler")]
		public unsafe virtual Builder? SetLightsEnabled(bool lights)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(lights ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLightsEnabled.(Z)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

		[Register("setName", "(Ljava/lang/CharSequence;)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetName_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual Builder? SetName(ICharSequence? name)
		{
			nint num = CharSequence.ToLocalJniHandle(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setName.(Ljava/lang/CharSequence;)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

		private static Delegate GetSetShowBadge_ZHandler()
		{
			return new global::_JniMarshal_PPB_L(n_SetShowBadge_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetShowBadge_Z(nint jnienv, nint native__this, sbyte native_showBadge)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool showBadge = native_showBadge != 0;
				return JNIEnv.ToLocalJniHandle(builder.SetShowBadge(showBadge));
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

		[Register("setShowBadge", "(Z)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetShowBadge_ZHandler")]
		public unsafe virtual Builder? SetShowBadge(bool showBadge)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(showBadge ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setShowBadge.(Z)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetSound_Landroid_net_Uri_Landroid_media_AudioAttributes_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_SetSound_Landroid_net_Uri_Landroid_media_AudioAttributes_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetSound_Landroid_net_Uri_Landroid_media_AudioAttributes_(nint jnienv, nint native__this, nint native_sound, nint native_audioAttributes)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Uri sound = Java.Lang.Object.GetObject<Uri>(native_sound, JniHandleOwnership.DoNotTransfer);
				AudioAttributes audioAttributes = Java.Lang.Object.GetObject<AudioAttributes>(native_audioAttributes, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSound(sound, audioAttributes));
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

		[Register("setSound", "(Landroid/net/Uri;Landroid/media/AudioAttributes;)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetSound_Landroid_net_Uri_Landroid_media_AudioAttributes_Handler")]
		public unsafe virtual Builder? SetSound(Uri? sound, AudioAttributes? audioAttributes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sound?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(audioAttributes?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSound.(Landroid/net/Uri;Landroid/media/AudioAttributes;)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sound);
				GC.KeepAlive(audioAttributes);
			}
		}

		private static Delegate GetSetVibrationEnabled_ZHandler()
		{
			return new global::_JniMarshal_PPB_L(n_SetVibrationEnabled_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetVibrationEnabled_Z(nint jnienv, nint native__this, sbyte native_vibration)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool vibrationEnabled = native_vibration != 0;
				return JNIEnv.ToLocalJniHandle(builder.SetVibrationEnabled(vibrationEnabled));
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

		[Register("setVibrationEnabled", "(Z)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetVibrationEnabled_ZHandler")]
		public unsafe virtual Builder? SetVibrationEnabled(bool vibration)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(vibration ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setVibrationEnabled.(Z)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetVibrationPattern_arrayJHandler()
		{
			return new global::_JniMarshal_PPL_L(n_SetVibrationPattern_arrayJ);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetVibrationPattern_arrayJ(nint jnienv, nint native__this, nint native_vibrationPattern)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				long[] array = (long[])JNIEnv.GetArray(native_vibrationPattern, JniHandleOwnership.DoNotTransfer, typeof(long));
				nint result = JNIEnv.ToLocalJniHandle(builder.SetVibrationPattern(array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_vibrationPattern);
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

		[Register("setVibrationPattern", "([J)Landroidx/core/app/NotificationChannelCompat$Builder;", "GetSetVibrationPattern_arrayJHandler")]
		public unsafe virtual Builder? SetVibrationPattern(long[]? vibrationPattern)
		{
			nint num = JNIEnv.NewArray(vibrationPattern);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setVibrationPattern.([J)Landroidx/core/app/NotificationChannelCompat$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (vibrationPattern != null)
				{
					JNIEnv.CopyArray(num, vibrationPattern);
					JNIEnv.DeleteLocalRef(num);
				}
				GC.KeepAlive(vibrationPattern);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/NotificationChannelCompat", typeof(NotificationChannelCompat));

	private static Delegate? cb_getAudioAttributes_GetAudioAttributes_Landroid_media_AudioAttributes_;

	private static Delegate? cb_getConversationId_GetConversationId_Ljava_lang_String_;

	private static Delegate? cb_getDescription_GetDescription_Ljava_lang_String_;

	private static Delegate? cb_getGroup_GetGroup_Ljava_lang_String_;

	private static Delegate? cb_getId_GetId_Ljava_lang_String_;

	private static Delegate? cb_getImportance_GetImportance_I;

	private static Delegate? cb_isImportantConversation_IsImportantConversation_Z;

	private static Delegate? cb_getLightColor_GetLightColor_I;

	private static Delegate? cb_getLockscreenVisibility_GetLockscreenVisibility_I;

	private static Delegate? cb_getName_GetName_Ljava_lang_CharSequence_;

	private static Delegate? cb_getParentChannelId_GetParentChannelId_Ljava_lang_String_;

	private static Delegate? cb_getSound_GetSound_Landroid_net_Uri_;

	private static Delegate? cb_canBubble_CanBubble_Z;

	private static Delegate? cb_canBypassDnd_CanBypassDnd_Z;

	private static Delegate? cb_canShowBadge_CanShowBadge_Z;

	private static Delegate? cb_getVibrationPattern_GetVibrationPattern_arrayJ;

	private static Delegate? cb_shouldShowLights_ShouldShowLights_Z;

	private static Delegate? cb_shouldVibrate_ShouldVibrate_Z;

	private static Delegate? cb_toBuilder_ToBuilder_Landroidx_core_app_NotificationChannelCompat_Builder_;

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

	public unsafe virtual AudioAttributes? AudioAttributes
	{
		[Register("getAudioAttributes", "()Landroid/media/AudioAttributes;", "GetGetAudioAttributesHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AudioAttributes>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAudioAttributes.()Landroid/media/AudioAttributes;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? ConversationId
	{
		[Register("getConversationId", "()Ljava/lang/String;", "GetGetConversationIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getConversationId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual string? Group
	{
		[Register("getGroup", "()Ljava/lang/String;", "GetGetGroupHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getGroup.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual int Importance
	{
		[Register("getImportance", "()I", "GetGetImportanceHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImportance.()I", this, null);
		}
	}

	public unsafe virtual bool IsImportantConversation
	{
		[Register("isImportantConversation", "()Z", "GetIsImportantConversationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isImportantConversation.()Z", this, null);
		}
	}

	public unsafe virtual int LightColor
	{
		[Register("getLightColor", "()I", "GetGetLightColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLightColor.()I", this, null);
		}
	}

	public unsafe virtual int LockscreenVisibility
	{
		[Register("getLockscreenVisibility", "()I", "GetGetLockscreenVisibilityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLockscreenVisibility.()I", this, null);
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

	public unsafe virtual string? ParentChannelId
	{
		[Register("getParentChannelId", "()Ljava/lang/String;", "GetGetParentChannelIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getParentChannelId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Uri? Sound
	{
		[Register("getSound", "()Landroid/net/Uri;", "GetGetSoundHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSound.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected NotificationChannelCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetAudioAttributesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAudioAttributes);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAudioAttributes(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AudioAttributes);
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

	private static Delegate GetGetConversationIdHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetConversationId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConversationId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConversationId);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Description);
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

	private static Delegate GetGetGroupHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetGroup);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetGroup(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Group);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
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

	private static Delegate GetGetImportanceHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetImportance);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetImportance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Importance;
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

	private static Delegate GetIsImportantConversationHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsImportantConversation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsImportantConversation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsImportantConversation ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLightColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLightColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLightColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LightColor;
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

	private static Delegate GetGetLockscreenVisibilityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLockscreenVisibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLockscreenVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LockscreenVisibility;
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
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NameFormatted);
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

	private static Delegate GetGetParentChannelIdHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetParentChannelId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParentChannelId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParentChannelId);
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

	private static Delegate GetGetSoundHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSound);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSound(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Sound);
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

	private static Delegate GetCanBubbleHandler()
	{
		return new global::_JniMarshal_PP_B(n_CanBubble);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanBubble(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanBubble() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canBubble", "()Z", "GetCanBubbleHandler")]
	public unsafe virtual bool CanBubble()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canBubble.()Z", this, null);
	}

	private static Delegate GetCanBypassDndHandler()
	{
		return new global::_JniMarshal_PP_B(n_CanBypassDnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanBypassDnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanBypassDnd() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canBypassDnd", "()Z", "GetCanBypassDndHandler")]
	public unsafe virtual bool CanBypassDnd()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canBypassDnd.()Z", this, null);
	}

	private static Delegate GetCanShowBadgeHandler()
	{
		return new global::_JniMarshal_PP_B(n_CanShowBadge);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanShowBadge(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanShowBadge() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canShowBadge", "()Z", "GetCanShowBadgeHandler")]
	public unsafe virtual bool CanShowBadge()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShowBadge.()Z", this, null);
	}

	private static Delegate GetGetVibrationPatternHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetVibrationPattern);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetVibrationPattern(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVibrationPattern());
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

	[Register("getVibrationPattern", "()[J", "GetGetVibrationPatternHandler")]
	public unsafe virtual long[]? GetVibrationPattern()
	{
		return (long[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getVibrationPattern.()[J", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(long));
	}

	private static Delegate GetShouldShowLightsHandler()
	{
		return new global::_JniMarshal_PP_B(n_ShouldShowLights);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldShowLights(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldShowLights() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("shouldShowLights", "()Z", "GetShouldShowLightsHandler")]
	public unsafe virtual bool ShouldShowLights()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldShowLights.()Z", this, null);
	}

	private static Delegate GetShouldVibrateHandler()
	{
		return new global::_JniMarshal_PP_B(n_ShouldVibrate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldVibrate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldVibrate() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("shouldVibrate", "()Z", "GetShouldVibrateHandler")]
	public unsafe virtual bool ShouldVibrate()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldVibrate.()Z", this, null);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NotificationChannelCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToBuilder());
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

	[Register("toBuilder", "()Landroidx/core/app/NotificationChannelCompat$Builder;", "GetToBuilderHandler")]
	public unsafe virtual Builder? ToBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("toBuilder.()Landroidx/core/app/NotificationChannelCompat$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
