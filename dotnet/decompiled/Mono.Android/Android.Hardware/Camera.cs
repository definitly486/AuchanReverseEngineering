using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Hardware;

[Obsolete("This class is obsoleted in this android platform")]
[Register("android/hardware/Camera", DoNotGenerateAcw = true)]
public class Camera : Java.Lang.Object
{
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("android/hardware/Camera$Area", DoNotGenerateAcw = true)]
	public class Area : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/hardware/Camera$Area", typeof(Area));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Area(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/graphics/Rect;I)V", "")]
		[Obsolete("deprecated")]
		public unsafe Area(Rect? rect, int weight)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(weight);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/Rect;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/Rect;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(rect);
			}
		}
	}

	[Obsolete("This class is obsoleted in this android platform")]
	[Register("android/hardware/Camera$AutoFocusCallback", "", "Android.Hardware.Camera/IAutoFocusCallbackInvoker")]
	public interface IAutoFocusCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Obsolete("deprecated")]
		[Register("onAutoFocus", "(ZLandroid/hardware/Camera;)V", "GetOnAutoFocus_ZLandroid_hardware_Camera_Handler:Android.Hardware.Camera/IAutoFocusCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnAutoFocus(bool success, Camera? camera);
	}

	[Register("android/hardware/Camera$AutoFocusCallback", DoNotGenerateAcw = true)]
	[Obsolete("This class is obsoleted in this android platform")]
	internal class IAutoFocusCallbackInvoker : Java.Lang.Object, IAutoFocusCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_hardware_Camera_AutoFocusCallback = new XAPeerMembers("android/hardware/Camera$AutoFocusCallback", typeof(IAutoFocusCallbackInvoker));

		private static Delegate? cb_onAutoFocus_OnAutoFocus_ZLandroid_hardware_Camera__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_hardware_Camera_AutoFocusCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_hardware_Camera_AutoFocusCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_hardware_Camera_AutoFocusCallback.ManagedPeerType;

		public IAutoFocusCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAutoFocus_ZLandroid_hardware_Camera_(nint jnienv, nint native__this, sbyte native_success, nint native_camera)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IAutoFocusCallback? autoFocusCallback = Java.Lang.Object.GetObject<IAutoFocusCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool success = native_success != 0;
				Camera camera = Java.Lang.Object.GetObject<Camera>(native_camera, JniHandleOwnership.DoNotTransfer);
				autoFocusCallback.OnAutoFocus(success, camera);
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

		public unsafe void OnAutoFocus(bool success, Camera? camera)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(success ? ((sbyte)1) : ((sbyte)0));
				ptr[1] = new JniArgumentValue(camera?.Handle ?? IntPtr.Zero);
				_members_android_hardware_Camera_AutoFocusCallback.InstanceMethods.InvokeAbstractVoidMethod("onAutoFocus.(ZLandroid/hardware/Camera;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(camera);
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
		private static void n_OnAutoFocus_ZLandroid_hardware_Camera__mm_wrapper(nint jnienv, nint native__this, sbyte native_success, nint native_camera)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAutoFocus_ZLandroid_hardware_Camera_(jnienv, native__this, native_success, native_camera);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Obsolete("This class is obsoleted in this android platform")]
	[Register("android/hardware/Camera$Parameters", DoNotGenerateAcw = true)]
	public class Parameters : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/hardware/Camera$Parameters", typeof(Parameters));

		private static Delegate? cb_setFocusAreas_SetFocusAreas_Ljava_util_List__V;

		private static Delegate? cb_getFocusMode_GetFocusMode_Ljava_lang_String_;

		private static Delegate? cb_setFocusMode_SetFocusMode_Ljava_lang_String__V;

		private static Delegate? cb_getMaxNumFocusAreas_GetMaxNumFocusAreas_I;

		private static Delegate? cb_getMaxNumMeteringAreas_GetMaxNumMeteringAreas_I;

		private static Delegate? cb_setMeteringAreas_SetMeteringAreas_Ljava_util_List__V;

		private static Delegate? cb_setPreviewFormat_SetPreviewFormat_I_V;

		private static Delegate? cb_getSceneMode_GetSceneMode_Ljava_lang_String_;

		private static Delegate? cb_setSceneMode_SetSceneMode_Ljava_lang_String__V;

		private static Delegate? cb_getSupportedFocusModes_GetSupportedFocusModes_Ljava_util_List_;

		private static Delegate? cb_getSupportedPreviewFpsRange_GetSupportedPreviewFpsRange_Ljava_util_List_;

		private static Delegate? cb_getSupportedPreviewSizes_GetSupportedPreviewSizes_Ljava_util_List_;

		private static Delegate? cb_getSupportedSceneModes_GetSupportedSceneModes_Ljava_util_List_;

		private static Delegate? cb_setPreviewFpsRange_SetPreviewFpsRange_II_V;

		private static Delegate? cb_setPreviewSize_SetPreviewSize_II_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		[Obsolete("deprecated")]
		public unsafe virtual IList<Area>? FocusAreas
		{
			[Register("setFocusAreas", "(Ljava/util/List;)V", "GetSetFocusAreas_Ljava_util_List_Handler")]
			set
			{
				nint num = JavaList<Area>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setFocusAreas.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(value);
				}
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual string? FocusMode
		{
			[Register("getFocusMode", "()Ljava/lang/String;", "GetGetFocusModeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getFocusMode.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setFocusMode", "(Ljava/lang/String;)V", "GetSetFocusMode_Ljava_lang_String_Handler")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setFocusMode.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual int MaxNumFocusAreas
		{
			[Register("getMaxNumFocusAreas", "()I", "GetGetMaxNumFocusAreasHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxNumFocusAreas.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual int MaxNumMeteringAreas
		{
			[Register("getMaxNumMeteringAreas", "()I", "GetGetMaxNumMeteringAreasHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxNumMeteringAreas.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual IList<Area>? MeteringAreas
		{
			[Register("setMeteringAreas", "(Ljava/util/List;)V", "GetSetMeteringAreas_Ljava_util_List_Handler")]
			set
			{
				nint num = JavaList<Area>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setMeteringAreas.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(value);
				}
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual ImageFormatType PreviewFormat
		{
			[Register("setPreviewFormat", "(I)V", "GetSetPreviewFormat_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((int)value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPreviewFormat.(I)V", this, ptr);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual string? SceneMode
		{
			[Register("getSceneMode", "()Ljava/lang/String;", "GetGetSceneModeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSceneMode.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSceneMode", "(Ljava/lang/String;)V", "GetSetSceneMode_Ljava_lang_String_Handler")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setSceneMode.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual IList<string>? SupportedFocusModes
		{
			[Register("getSupportedFocusModes", "()Ljava/util/List;", "GetGetSupportedFocusModesHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedFocusModes.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual IList<int[]>? SupportedPreviewFpsRange
		{
			[Register("getSupportedPreviewFpsRange", "()Ljava/util/List;", "GetGetSupportedPreviewFpsRangeHandler")]
			get
			{
				return JavaList<int[]>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedPreviewFpsRange.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual IList<Size>? SupportedPreviewSizes
		{
			[Register("getSupportedPreviewSizes", "()Ljava/util/List;", "GetGetSupportedPreviewSizesHandler")]
			get
			{
				return JavaList<Size>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedPreviewSizes.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual IList<string>? SupportedSceneModes
		{
			[Register("getSupportedSceneModes", "()Ljava/util/List;", "GetGetSupportedSceneModesHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedSceneModes.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Parameters(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete]
		private static Delegate GetSetFocusAreas_Ljava_util_List_Handler()
		{
			return new _JniMarshal_PPL_V(n_SetFocusAreas_Ljava_util_List_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetFocusAreas_Ljava_util_List_(nint jnienv, nint native__this, nint native_focusAreas)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Parameters? parameters = Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<Area> focusAreas = JavaList<Area>.FromJniHandle(native_focusAreas, JniHandleOwnership.DoNotTransfer);
				parameters.FocusAreas = focusAreas;
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

		[Obsolete]
		private static Delegate GetGetFocusModeHandler()
		{
			return new _JniMarshal_PP_L(n_GetFocusMode);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetFocusMode(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusMode);
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

		[Obsolete]
		private static Delegate GetSetFocusMode_Ljava_lang_String_Handler()
		{
			return new _JniMarshal_PPL_V(n_SetFocusMode_Ljava_lang_String_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetFocusMode_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Parameters? parameters = Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string focusMode = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				parameters.FocusMode = focusMode;
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

		[Obsolete]
		private static Delegate GetGetMaxNumFocusAreasHandler()
		{
			return new _JniMarshal_PP_I(n_GetMaxNumFocusAreas);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetMaxNumFocusAreas(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxNumFocusAreas;
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

		[Obsolete]
		private static Delegate GetGetMaxNumMeteringAreasHandler()
		{
			return new _JniMarshal_PP_I(n_GetMaxNumMeteringAreas);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetMaxNumMeteringAreas(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxNumMeteringAreas;
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

		[Obsolete]
		private static Delegate GetSetMeteringAreas_Ljava_util_List_Handler()
		{
			return new _JniMarshal_PPL_V(n_SetMeteringAreas_Ljava_util_List_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMeteringAreas_Ljava_util_List_(nint jnienv, nint native__this, nint native_meteringAreas)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Parameters? parameters = Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<Area> meteringAreas = JavaList<Area>.FromJniHandle(native_meteringAreas, JniHandleOwnership.DoNotTransfer);
				parameters.MeteringAreas = meteringAreas;
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

		[Obsolete]
		private static Delegate GetSetPreviewFormat_IHandler()
		{
			return new _JniMarshal_PPI_V(n_SetPreviewFormat_I);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetPreviewFormat_I(nint jnienv, nint native__this, int native_pixel_format)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreviewFormat = (ImageFormatType)native_pixel_format;
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

		[Obsolete]
		private static Delegate GetGetSceneModeHandler()
		{
			return new _JniMarshal_PP_L(n_GetSceneMode);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetSceneMode(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SceneMode);
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

		[Obsolete]
		private static Delegate GetSetSceneMode_Ljava_lang_String_Handler()
		{
			return new _JniMarshal_PPL_V(n_SetSceneMode_Ljava_lang_String_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetSceneMode_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Parameters? parameters = Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string sceneMode = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				parameters.SceneMode = sceneMode;
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

		[Obsolete]
		private static Delegate GetGetSupportedFocusModesHandler()
		{
			return new _JniMarshal_PP_L(n_GetSupportedFocusModes);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetSupportedFocusModes(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedFocusModes);
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

		[Obsolete]
		private static Delegate GetGetSupportedPreviewFpsRangeHandler()
		{
			return new _JniMarshal_PP_L(n_GetSupportedPreviewFpsRange);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetSupportedPreviewFpsRange(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JavaList<int[]>.ToLocalJniHandle(Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedPreviewFpsRange);
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

		[Obsolete]
		private static Delegate GetGetSupportedPreviewSizesHandler()
		{
			return new _JniMarshal_PP_L(n_GetSupportedPreviewSizes);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetSupportedPreviewSizes(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JavaList<Size>.ToLocalJniHandle(Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedPreviewSizes);
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

		[Obsolete]
		private static Delegate GetGetSupportedSceneModesHandler()
		{
			return new _JniMarshal_PP_L(n_GetSupportedSceneModes);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetSupportedSceneModes(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedSceneModes);
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

		[Obsolete]
		private static Delegate GetSetPreviewFpsRange_IIHandler()
		{
			return new _JniMarshal_PPII_V(n_SetPreviewFpsRange_II);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetPreviewFpsRange_II(nint jnienv, nint native__this, int min, int max)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPreviewFpsRange(min, max);
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

		[Obsolete("deprecated")]
		[Register("setPreviewFpsRange", "(II)V", "GetSetPreviewFpsRange_IIHandler")]
		public unsafe virtual void SetPreviewFpsRange(int min, int max)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(min);
			ptr[1] = new JniArgumentValue(max);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPreviewFpsRange.(II)V", this, ptr);
		}

		[Obsolete]
		private static Delegate GetSetPreviewSize_IIHandler()
		{
			return new _JniMarshal_PPII_V(n_SetPreviewSize_II);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetPreviewSize_II(nint jnienv, nint native__this, int width, int height)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Parameters>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPreviewSize(width, height);
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

		[Obsolete("deprecated")]
		[Register("setPreviewSize", "(II)V", "GetSetPreviewSize_IIHandler")]
		public unsafe virtual void SetPreviewSize(int width, int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(width);
			ptr[1] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPreviewSize.(II)V", this, ptr);
		}
	}

	[Obsolete("This class is obsoleted in this android platform")]
	[Register("android/hardware/Camera$Size", DoNotGenerateAcw = true)]
	public class Size : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/hardware/Camera$Size", typeof(Size));

		[Register("height")]
		[Obsolete("deprecated")]
		public int Height => _members.InstanceFields.GetInt32Value("height.I", this);

		[Register("width")]
		[Obsolete("deprecated")]
		public int Width => _members.InstanceFields.GetInt32Value("width.I", this);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Size(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/hardware/Camera;II)V", "")]
		[Obsolete("deprecated")]
		public unsafe Size(Camera? __self, int w, int h)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";II)V";
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(w);
				ptr[2] = new JniArgumentValue(h);
				SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
			}
			finally
			{
				GC.KeepAlive(__self);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/hardware/Camera", typeof(Camera));

	private static Delegate? cb_getParameters_GetParameters_Landroid_hardware_Camera_Parameters_;

	private static Delegate? cb_setParameters_SetParameters_Landroid_hardware_Camera_Parameters__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Camera(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Obsolete("deprecated")]
	[Register("autoFocus", "(Landroid/hardware/Camera$AutoFocusCallback;)V", "")]
	public unsafe void AutoFocus(IAutoFocusCallback? cb)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cb == null) ? IntPtr.Zero : ((Java.Lang.Object)cb).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("autoFocus.(Landroid/hardware/Camera$AutoFocusCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	[Obsolete("deprecated")]
	[Register("cancelAutoFocus", "()V", "")]
	public unsafe void CancelAutoFocus()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("cancelAutoFocus.()V", this, null);
	}

	[Obsolete]
	private static Delegate GetGetParametersHandler()
	{
		return new _JniMarshal_PP_L(n_GetParameters);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParameters(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Camera>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetParameters());
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

	[Obsolete("deprecated")]
	[Register("getParameters", "()Landroid/hardware/Camera$Parameters;", "GetGetParametersHandler")]
	public unsafe virtual Parameters? GetParameters()
	{
		return Java.Lang.Object.GetObject<Parameters>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParameters.()Landroid/hardware/Camera$Parameters;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetSetParameters_Landroid_hardware_Camera_Parameters_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetParameters_Landroid_hardware_Camera_Parameters_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetParameters_Landroid_hardware_Camera_Parameters_(nint jnienv, nint native__this, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Camera? camera = Java.Lang.Object.GetObject<Camera>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parameters parameters = Java.Lang.Object.GetObject<Parameters>(native__params, JniHandleOwnership.DoNotTransfer);
			camera.SetParameters(parameters);
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

	[Obsolete("deprecated")]
	[Register("setParameters", "(Landroid/hardware/Camera$Parameters;)V", "GetSetParameters_Landroid_hardware_Camera_Parameters_Handler")]
	public unsafe virtual void SetParameters(Parameters? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setParameters.(Landroid/hardware/Camera$Parameters;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}
}
