using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraCaptureMetaData", DoNotGenerateAcw = true)]
public sealed class CameraCaptureMetaData : Java.Lang.Object
{
	[Register("androidx/camera/core/impl/CameraCaptureMetaData$AeMode", DoNotGenerateAcw = true)]
	public sealed class AeMode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureMetaData$AeMode", typeof(AeMode));

		[Register("OFF")]
		public static AeMode? Off => Java.Lang.Object.GetObject<AeMode>(_members.StaticFields.GetObjectValue("OFF.Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON")]
		public static AeMode? On => Java.Lang.Object.GetObject<AeMode>(_members.StaticFields.GetObjectValue("ON.Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_ALWAYS_FLASH")]
		public static AeMode? OnAlwaysFlash => Java.Lang.Object.GetObject<AeMode>(_members.StaticFields.GetObjectValue("ON_ALWAYS_FLASH.Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_AUTO_FLASH")]
		public static AeMode? OnAutoFlash => Java.Lang.Object.GetObject<AeMode>(_members.StaticFields.GetObjectValue("ON_AUTO_FLASH.Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_AUTO_FLASH_REDEYE")]
		public static AeMode? OnAutoFlashRedeye => Java.Lang.Object.GetObject<AeMode>(_members.StaticFields.GetObjectValue("ON_AUTO_FLASH_REDEYE.Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_EXTERNAL_FLASH")]
		public static AeMode? OnExternalFlash => Java.Lang.Object.GetObject<AeMode>(_members.StaticFields.GetObjectValue("ON_EXTERNAL_FLASH.Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static AeMode? Unknown => Java.Lang.Object.GetObject<AeMode>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal AeMode(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;", "")]
		public unsafe static AeMode? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<AeMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;", "")]
		public unsafe static AeMode[]? Values()
		{
			return (AeMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AeMode));
		}
	}

	[Register("androidx/camera/core/impl/CameraCaptureMetaData$AeState", DoNotGenerateAcw = true)]
	public sealed class AeState : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureMetaData$AeState", typeof(AeState));

		[Register("CONVERGED")]
		public static AeState? Converged => Java.Lang.Object.GetObject<AeState>(_members.StaticFields.GetObjectValue("CONVERGED.Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FLASH_REQUIRED")]
		public static AeState? FlashRequired => Java.Lang.Object.GetObject<AeState>(_members.StaticFields.GetObjectValue("FLASH_REQUIRED.Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INACTIVE")]
		public static AeState? Inactive => Java.Lang.Object.GetObject<AeState>(_members.StaticFields.GetObjectValue("INACTIVE.Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOCKED")]
		public static AeState? Locked => Java.Lang.Object.GetObject<AeState>(_members.StaticFields.GetObjectValue("LOCKED.Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SEARCHING")]
		public static AeState? Searching => Java.Lang.Object.GetObject<AeState>(_members.StaticFields.GetObjectValue("SEARCHING.Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static AeState? Unknown => Java.Lang.Object.GetObject<AeState>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal AeState(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;", "")]
		public unsafe static AeState? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<AeState>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;", "")]
		public unsafe static AeState[]? Values()
		{
			return (AeState[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AeState));
		}
	}

	[Register("androidx/camera/core/impl/CameraCaptureMetaData$AfMode", DoNotGenerateAcw = true)]
	public sealed class AfMode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureMetaData$AfMode", typeof(AfMode));

		[Register("OFF")]
		public static AfMode? Off => Java.Lang.Object.GetObject<AfMode>(_members.StaticFields.GetObjectValue("OFF.Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_CONTINUOUS_AUTO")]
		public static AfMode? OnContinuousAuto => Java.Lang.Object.GetObject<AfMode>(_members.StaticFields.GetObjectValue("ON_CONTINUOUS_AUTO.Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_MANUAL_AUTO")]
		public static AfMode? OnManualAuto => Java.Lang.Object.GetObject<AfMode>(_members.StaticFields.GetObjectValue("ON_MANUAL_AUTO.Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static AfMode? Unknown => Java.Lang.Object.GetObject<AfMode>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal AfMode(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;", "")]
		public unsafe static AfMode? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<AfMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;", "")]
		public unsafe static AfMode[]? Values()
		{
			return (AfMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AfMode));
		}
	}

	[Register("androidx/camera/core/impl/CameraCaptureMetaData$AfState", DoNotGenerateAcw = true)]
	public sealed class AfState : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureMetaData$AfState", typeof(AfState));

		[Register("INACTIVE")]
		public static AfState? Inactive => Java.Lang.Object.GetObject<AfState>(_members.StaticFields.GetObjectValue("INACTIVE.Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOCKED_FOCUSED")]
		public static AfState? LockedFocused => Java.Lang.Object.GetObject<AfState>(_members.StaticFields.GetObjectValue("LOCKED_FOCUSED.Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOCKED_NOT_FOCUSED")]
		public static AfState? LockedNotFocused => Java.Lang.Object.GetObject<AfState>(_members.StaticFields.GetObjectValue("LOCKED_NOT_FOCUSED.Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PASSIVE_FOCUSED")]
		public static AfState? PassiveFocused => Java.Lang.Object.GetObject<AfState>(_members.StaticFields.GetObjectValue("PASSIVE_FOCUSED.Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PASSIVE_NOT_FOCUSED")]
		public static AfState? PassiveNotFocused => Java.Lang.Object.GetObject<AfState>(_members.StaticFields.GetObjectValue("PASSIVE_NOT_FOCUSED.Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SCANNING")]
		public static AfState? Scanning => Java.Lang.Object.GetObject<AfState>(_members.StaticFields.GetObjectValue("SCANNING.Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static AfState? Unknown => Java.Lang.Object.GetObject<AfState>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal AfState(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;", "")]
		public unsafe static AfState? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<AfState>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;", "")]
		public unsafe static AfState[]? Values()
		{
			return (AfState[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AfState));
		}
	}

	[Register("androidx/camera/core/impl/CameraCaptureMetaData$AwbMode", DoNotGenerateAcw = true)]
	public sealed class AwbMode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureMetaData$AwbMode", typeof(AwbMode));

		[Register("AUTO")]
		public static AwbMode? Auto => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("AUTO.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CLOUDY_DAYLIGHT")]
		public static AwbMode? CloudyDaylight => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("CLOUDY_DAYLIGHT.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DAYLIGHT")]
		public static AwbMode? Daylight => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("DAYLIGHT.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FLUORESCENT")]
		public static AwbMode? Fluorescent => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("FLUORESCENT.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INCANDESCENT")]
		public static AwbMode? Incandescent => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("INCANDESCENT.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OFF")]
		public static AwbMode? Off => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("OFF.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SHADE")]
		public static AwbMode? Shade => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("SHADE.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TWILIGHT")]
		public static AwbMode? Twilight => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("TWILIGHT.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static AwbMode? Unknown => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("WARM_FLUORESCENT")]
		public static AwbMode? WarmFluorescent => Java.Lang.Object.GetObject<AwbMode>(_members.StaticFields.GetObjectValue("WARM_FLUORESCENT.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal AwbMode(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;", "")]
		public unsafe static AwbMode? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<AwbMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;", "")]
		public unsafe static AwbMode[]? Values()
		{
			return (AwbMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AwbMode));
		}
	}

	[Register("androidx/camera/core/impl/CameraCaptureMetaData$AwbState", DoNotGenerateAcw = true)]
	public sealed class AwbState : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureMetaData$AwbState", typeof(AwbState));

		[Register("CONVERGED")]
		public static AwbState? Converged => Java.Lang.Object.GetObject<AwbState>(_members.StaticFields.GetObjectValue("CONVERGED.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INACTIVE")]
		public static AwbState? Inactive => Java.Lang.Object.GetObject<AwbState>(_members.StaticFields.GetObjectValue("INACTIVE.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOCKED")]
		public static AwbState? Locked => Java.Lang.Object.GetObject<AwbState>(_members.StaticFields.GetObjectValue("LOCKED.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("METERING")]
		public static AwbState? Metering => Java.Lang.Object.GetObject<AwbState>(_members.StaticFields.GetObjectValue("METERING.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static AwbState? Unknown => Java.Lang.Object.GetObject<AwbState>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal AwbState(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;", "")]
		public unsafe static AwbState? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<AwbState>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;", "")]
		public unsafe static AwbState[]? Values()
		{
			return (AwbState[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AwbState));
		}
	}

	[Register("androidx/camera/core/impl/CameraCaptureMetaData$FlashState", DoNotGenerateAcw = true)]
	public sealed class FlashState : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureMetaData$FlashState", typeof(FlashState));

		[Register("FIRED")]
		public static FlashState? Fired => Java.Lang.Object.GetObject<FlashState>(_members.StaticFields.GetObjectValue("FIRED.Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NONE")]
		public static FlashState? None => Java.Lang.Object.GetObject<FlashState>(_members.StaticFields.GetObjectValue("NONE.Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("READY")]
		public static FlashState? Ready => Java.Lang.Object.GetObject<FlashState>(_members.StaticFields.GetObjectValue("READY.Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static FlashState? Unknown => Java.Lang.Object.GetObject<FlashState>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal FlashState(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;", "")]
		public unsafe static FlashState? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<FlashState>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;", "")]
		public unsafe static FlashState[]? Values()
		{
			return (FlashState[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(FlashState));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureMetaData", typeof(CameraCaptureMetaData));

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

	internal CameraCaptureMetaData(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
