using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/UserProfile", DoNotGenerateAcw = true)]
public class UserProfile : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/profile/UserProfile$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/UserProfile$Builder", typeof(Builder));

		private static Delegate? cb_apply_Apply_Lio_appmetrica_analytics_profile_UserProfileUpdate__Lio_appmetrica_analytics_profile_UserProfile_Builder_;

		private static Delegate? cb_build_Build_Lio_appmetrica_analytics_profile_UserProfile_;

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

		private static Delegate GetApply_Lio_appmetrica_analytics_profile_UserProfileUpdate_Handler()
		{
			if ((object)cb_apply_Apply_Lio_appmetrica_analytics_profile_UserProfileUpdate__Lio_appmetrica_analytics_profile_UserProfile_Builder_ == null)
			{
				cb_apply_Apply_Lio_appmetrica_analytics_profile_UserProfileUpdate__Lio_appmetrica_analytics_profile_UserProfile_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Apply_Lio_appmetrica_analytics_profile_UserProfileUpdate_));
			}
			return cb_apply_Apply_Lio_appmetrica_analytics_profile_UserProfileUpdate__Lio_appmetrica_analytics_profile_UserProfile_Builder_;
		}

		private static nint n_Apply_Lio_appmetrica_analytics_profile_UserProfileUpdate_(nint jnienv, nint native__this, nint native_userProfileUpdate)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UserProfileUpdate userProfileUpdate = Java.Lang.Object.GetObject<UserProfileUpdate>(native_userProfileUpdate, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.Apply(userProfileUpdate));
		}

		[Register("apply", "(Lio/appmetrica/analytics/profile/UserProfileUpdate;)Lio/appmetrica/analytics/profile/UserProfile$Builder;", "GetApply_Lio_appmetrica_analytics_profile_UserProfileUpdate_Handler")]
		public unsafe virtual Builder? Apply(UserProfileUpdate userProfileUpdate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(userProfileUpdate?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("apply.(Lio/appmetrica/analytics/profile/UserProfileUpdate;)Lio/appmetrica/analytics/profile/UserProfile$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(userProfileUpdate);
			}
		}

		private static Delegate GetBuildHandler()
		{
			if ((object)cb_build_Build_Lio_appmetrica_analytics_profile_UserProfile_ == null)
			{
				cb_build_Build_Lio_appmetrica_analytics_profile_UserProfile_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build_Build_Lio_appmetrica_analytics_profile_UserProfile_;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lio/appmetrica/analytics/profile/UserProfile;", "GetBuildHandler")]
		public unsafe virtual UserProfile Build()
		{
			return Java.Lang.Object.GetObject<UserProfile>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/profile/UserProfile;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/UserProfile", typeof(UserProfile));

	private static Delegate? cb_getUserProfileUpdates_GetUserProfileUpdates_Ljava_util_List_;

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

	public unsafe virtual IList<UserProfileUpdate> UserProfileUpdates
	{
		[Register("getUserProfileUpdates", "()Ljava/util/List;", "GetGetUserProfileUpdatesHandler")]
		get
		{
			return JavaList<UserProfileUpdate>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getUserProfileUpdates.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected UserProfile(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetUserProfileUpdatesHandler()
	{
		if ((object)cb_getUserProfileUpdates_GetUserProfileUpdates_Ljava_util_List_ == null)
		{
			cb_getUserProfileUpdates_GetUserProfileUpdates_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUserProfileUpdates));
		}
		return cb_getUserProfileUpdates_GetUserProfileUpdates_Ljava_util_List_;
	}

	private static nint n_GetUserProfileUpdates(nint jnienv, nint native__this)
	{
		return JavaList<UserProfileUpdate>.ToLocalJniHandle(Java.Lang.Object.GetObject<UserProfile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UserProfileUpdates);
	}

	[Register("newBuilder", "()Lio/appmetrica/analytics/profile/UserProfile$Builder;", "")]
	public unsafe static Builder NewBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lio/appmetrica/analytics/profile/UserProfile$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
