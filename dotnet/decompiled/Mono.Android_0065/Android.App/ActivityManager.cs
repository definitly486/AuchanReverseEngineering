using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.App;

[Register("android/app/ActivityManager", DoNotGenerateAcw = true)]
public class ActivityManager : Java.Lang.Object
{
	[Register("android/app/ActivityManager$RunningAppProcessInfo", DoNotGenerateAcw = true)]
	public class RunningAppProcessInfo : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/ActivityManager$RunningAppProcessInfo", typeof(RunningAppProcessInfo));

		private static Delegate? cb_describeContents_DescribeContents_I;

		private static Delegate? cb_writeToParcel_WriteToParcel_Landroid_os_Parcel_I_V;

		[Register("pid")]
		public int Pid => _members.InstanceFields.GetInt32Value("pid.I", this);

		[Register("processName")]
		public string? ProcessName => JNIEnv.GetString(_members.InstanceFields.GetObjectValue("processName.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected RunningAppProcessInfo(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe RunningAppProcessInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;I[Ljava/lang/String;)V", "")]
		public unsafe RunningAppProcessInfo(string? pProcessName, int pPid, string[]? pArr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(pProcessName);
			nint num2 = JNIEnv.NewArray(pArr);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(pPid);
				ptr[2] = new JniArgumentValue(num2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;I[Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;I[Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				if (pArr != null)
				{
					JNIEnv.CopyArray(num2, pArr);
					JNIEnv.DeleteLocalRef(num2);
				}
				GC.KeepAlive(pArr);
			}
		}

		private static Delegate GetDescribeContentsHandler()
		{
			return new _JniMarshal_PP_I(n_DescribeContents);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_DescribeContents(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<RunningAppProcessInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe virtual int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native_dest, int native_flags)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				RunningAppProcessInfo? runningAppProcessInfo = Java.Lang.Object.GetObject<RunningAppProcessInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
				runningAppProcessInfo.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
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

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel? dest, ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/ActivityManager", typeof(ActivityManager));

	private static Delegate? cb_getDeviceConfigurationInfo_GetDeviceConfigurationInfo_Landroid_content_pm_ConfigurationInfo_;

	private static Delegate? cb_getRunningAppProcesses_GetRunningAppProcesses_Ljava_util_List_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual ConfigurationInfo? DeviceConfigurationInfo => Java.Lang.Object.GetObject<ConfigurationInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeviceConfigurationInfo.()Landroid/content/pm/ConfigurationInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual IList<RunningAppProcessInfo>? RunningAppProcesses => JavaList<RunningAppProcessInfo>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getRunningAppProcesses.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public static ActivityManager? FromContext(Context context)
	{
		return context.GetSystemService("activity") as ActivityManager;
	}

	protected ActivityManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetDeviceConfigurationInfoHandler()
	{
		return new _JniMarshal_PP_L(n_GetDeviceConfigurationInfo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDeviceConfigurationInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActivityManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeviceConfigurationInfo);
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

	private static Delegate GetGetRunningAppProcessesHandler()
	{
		return new _JniMarshal_PP_L(n_GetRunningAppProcesses);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRunningAppProcesses(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<RunningAppProcessInfo>.ToLocalJniHandle(Java.Lang.Object.GetObject<ActivityManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RunningAppProcesses);
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
}
