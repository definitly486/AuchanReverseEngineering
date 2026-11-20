using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Camera.Core;
using Com.Scanflow.Datacapture.Config;
using Com.Scanflow.Datacapture.Model;
using Google.Android.Material.Slider;
using Java.Interop;
using Java.Lang;
using Java.Util;
using Kotlin.Enums;

namespace Com.Scanflow.Datacapture.Core.Camera;

[Register("com/scanflow/datacapture/core/camera/ScanflowReader", DoNotGenerateAcw = true)]
public abstract class ScanflowReader : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig", DoNotGenerateAcw = true)]
	public sealed class CameraResolutionConfig : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig", typeof(CameraResolutionConfig));

		[Register("FULL_HD_1080P")]
		public static CameraResolutionConfig FullHd1080p => Java.Lang.Object.GetObject<CameraResolutionConfig>(_members.StaticFields.GetObjectValue("FULL_HD_1080P.Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("HD_720P")]
		public static CameraResolutionConfig Hd720p => Java.Lang.Object.GetObject<CameraResolutionConfig>(_members.StaticFields.GetObjectValue("HD_720P.Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SD_480P")]
		public static CameraResolutionConfig Sd480p => Java.Lang.Object.GetObject<CameraResolutionConfig>(_members.StaticFields.GetObjectValue("SD_480P.Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UHD_4K")]
		public static CameraResolutionConfig Uhd4k => Java.Lang.Object.GetObject<CameraResolutionConfig>(_members.StaticFields.GetObjectValue("UHD_4K.Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe static IEnumEntries Entries
		{
			[Register("getEntries", "()Lkotlin/enums/EnumEntries;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IEnumEntries>(_members.StaticMethods.InvokeObjectMethod("getEntries.()Lkotlin/enums/EnumEntries;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Size Size
		{
			[Register("getSize", "()Landroid/util/Size;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSize.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CameraResolutionConfig(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;", "")]
		public unsafe static CameraResolutionConfig ValueOf(string p0)
		{
			nint num = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<CameraResolutionConfig>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;", "")]
		public unsafe static CameraResolutionConfig[] Values()
		{
			return (CameraResolutionConfig[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(CameraResolutionConfig));
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult", DoNotGenerateAcw = true)]
	public sealed class IDCardScanResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult", typeof(IDCardScanResult));

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

		public unsafe string Address
		{
			[Register("getAddress", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAddress.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setAddress", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAddress.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe Bitmap BackImage
		{
			[Register("getBackImage", "()Landroid/graphics/Bitmap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBackImage.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setBackImage", "(Landroid/graphics/Bitmap;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setBackImage.(Landroid/graphics/Bitmap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string BloodGroup
		{
			[Register("getBloodGroup", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBloodGroup.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setBloodGroup", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setBloodGroup.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe string DateOfIssue
		{
			[Register("getDateOfIssue", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDateOfIssue.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDateOfIssue", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDateOfIssue.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe string Dob
		{
			[Register("getDob", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDob.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDob", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDob.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe string Fathername
		{
			[Register("getFathername", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFathername.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setFathername", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFathername.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe Bitmap FrontImage
		{
			[Register("getFrontImage", "()Landroid/graphics/Bitmap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFrontImage.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setFrontImage", "(Landroid/graphics/Bitmap;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFrontImage.(Landroid/graphics/Bitmap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setName", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe Bitmap ProfileImage
		{
			[Register("getProfileImage", "()Landroid/graphics/Bitmap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getProfileImage.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setProfileImage", "(Landroid/graphics/Bitmap;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setProfileImage.(Landroid/graphics/Bitmap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Sex
		{
			[Register("getSex", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSex.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSex", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setSex.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe string UniqueId
		{
			[Register("getUniqueId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUniqueId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setUniqueId", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setUniqueId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe string ValidTill
		{
			[Register("getValidTill", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getValidTill.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setValidTill", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setValidTill.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe string Year
		{
			[Register("getYear", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getYear.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setYear", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setYear.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		internal IDCardScanResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe IDCardScanResult()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe IDCardScanResult(string p0, string p1, string p2, string p3, string p4, string p5, Bitmap p6, Bitmap p7, Bitmap p8, string p9, string p10, string p11, string p12)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(p0);
			nint num2 = JNIEnv.NewString(p1);
			nint num3 = JNIEnv.NewString(p2);
			nint num4 = JNIEnv.NewString(p3);
			nint num5 = JNIEnv.NewString(p4);
			nint num6 = JNIEnv.NewString(p5);
			nint num7 = JNIEnv.NewString(p9);
			nint num8 = JNIEnv.NewString(p10);
			nint num9 = JNIEnv.NewString(p11);
			nint num10 = JNIEnv.NewString(p12);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[13];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue(num3);
				ptr[3] = new JniArgumentValue(num4);
				ptr[4] = new JniArgumentValue(num5);
				ptr[5] = new JniArgumentValue(num6);
				ptr[6] = new JniArgumentValue(p6?.Handle ?? IntPtr.Zero);
				ptr[7] = new JniArgumentValue(p7?.Handle ?? IntPtr.Zero);
				ptr[8] = new JniArgumentValue(p8?.Handle ?? IntPtr.Zero);
				ptr[9] = new JniArgumentValue(num7);
				ptr[10] = new JniArgumentValue(num8);
				ptr[11] = new JniArgumentValue(num9);
				ptr[12] = new JniArgumentValue(num10);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
				JNIEnv.DeleteLocalRef(num4);
				JNIEnv.DeleteLocalRef(num5);
				JNIEnv.DeleteLocalRef(num6);
				JNIEnv.DeleteLocalRef(num7);
				JNIEnv.DeleteLocalRef(num8);
				JNIEnv.DeleteLocalRef(num9);
				JNIEnv.DeleteLocalRef(num10);
				GC.KeepAlive(p6);
				GC.KeepAlive(p7);
				GC.KeepAlive(p8);
			}
		}

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component10", "()Ljava/lang/String;", "")]
		public unsafe string Component10()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component10.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component11", "()Ljava/lang/String;", "")]
		public unsafe string Component11()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component11.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component12", "()Ljava/lang/String;", "")]
		public unsafe string Component12()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component12.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component13", "()Ljava/lang/String;", "")]
		public unsafe string Component13()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component13.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Ljava/lang/String;", "")]
		public unsafe string Component2()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component3", "()Ljava/lang/String;", "")]
		public unsafe string Component3()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component3.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component4", "()Ljava/lang/String;", "")]
		public unsafe string Component4()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component4.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component5", "()Ljava/lang/String;", "")]
		public unsafe string Component5()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component5.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component6", "()Ljava/lang/String;", "")]
		public unsafe string Component6()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component6.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component7", "()Landroid/graphics/Bitmap;", "")]
		public unsafe Bitmap Component7()
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component7.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component8", "()Landroid/graphics/Bitmap;", "")]
		public unsafe Bitmap Component8()
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component8.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component9", "()Landroid/graphics/Bitmap;", "")]
		public unsafe Bitmap Component9()
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component9.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;", "")]
		public unsafe IDCardScanResult Copy(string dob, string uniqueId, string name, string sex, string year, string address, Bitmap frontImage, Bitmap backImage, Bitmap profileImage, string fathername, string dateOfIssue, string validTill, string bloodGroup)
		{
			nint num = JNIEnv.NewString(dob);
			nint num2 = JNIEnv.NewString(uniqueId);
			nint num3 = JNIEnv.NewString(name);
			nint num4 = JNIEnv.NewString(sex);
			nint num5 = JNIEnv.NewString(year);
			nint num6 = JNIEnv.NewString(address);
			nint num7 = JNIEnv.NewString(fathername);
			nint num8 = JNIEnv.NewString(dateOfIssue);
			nint num9 = JNIEnv.NewString(validTill);
			nint num10 = JNIEnv.NewString(bloodGroup);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[13];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue(num3);
				ptr[3] = new JniArgumentValue(num4);
				ptr[4] = new JniArgumentValue(num5);
				ptr[5] = new JniArgumentValue(num6);
				ptr[6] = new JniArgumentValue(frontImage?.Handle ?? IntPtr.Zero);
				ptr[7] = new JniArgumentValue(backImage?.Handle ?? IntPtr.Zero);
				ptr[8] = new JniArgumentValue(profileImage?.Handle ?? IntPtr.Zero);
				ptr[9] = new JniArgumentValue(num7);
				ptr[10] = new JniArgumentValue(num8);
				ptr[11] = new JniArgumentValue(num9);
				ptr[12] = new JniArgumentValue(num10);
				return Java.Lang.Object.GetObject<IDCardScanResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
				JNIEnv.DeleteLocalRef(num4);
				JNIEnv.DeleteLocalRef(num5);
				JNIEnv.DeleteLocalRef(num6);
				JNIEnv.DeleteLocalRef(num7);
				JNIEnv.DeleteLocalRef(num8);
				JNIEnv.DeleteLocalRef(num9);
				JNIEnv.DeleteLocalRef(num10);
				GC.KeepAlive(frontImage);
				GC.KeepAlive(backImage);
				GC.KeepAlive(profileImage);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnBarcodeScanResultCallbackInvoker")]
	public interface IOnBarcodeScanResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onBatchScanResultSuccess", "(Ljava/util/ArrayList;)V", "GetOnBatchScanResultSuccess_Ljava_util_ArrayList_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnBatchScanResultSuccess(IList<ScanResultSuccess> result);

		[Register("onOneOfManyCodeResult", "(Ljava/util/HashSet;)V", "GetOnOneOfManyCodeResult_Ljava_util_HashSet_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnOneOfManyCodeResult(HashSet results);

		[Register("onOneofManyCodeRemoved", "(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V", "GetOnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnOneofManyCodeRemoved(OneOFManyCodesScanResults result);

		[Register("onOneofManyCodeSelected", "(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V", "GetOnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnOneofManyCodeSelected(OneOFManyCodesScanResults result);

		[Register("onScanBarcodeDetection", "(Z)V", "GetOnScanBarcodeDetection_ZHandler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanBarcodeDetection(bool isDetected);

		[Register("onScanResultFailure", "(Ljava/lang/String;)V", "GetOnScanResultFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultFailure(string error);

		[Register("onScanResultSuccess", "(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V", "GetOnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultSuccess(ScanResultSuccess result);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback", DoNotGenerateAcw = true)]
	internal class IOnBarcodeScanResultCallbackInvoker : Java.Lang.Object, IOnBarcodeScanResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback", typeof(IOnBarcodeScanResultCallbackInvoker));

		private static Delegate cb_onBatchScanResultSuccess_OnBatchScanResultSuccess_Ljava_util_ArrayList__V;

		private static Delegate cb_onOneOfManyCodeResult_OnOneOfManyCodeResult_Ljava_util_HashSet__V;

		private static Delegate cb_onOneofManyCodeRemoved_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V;

		private static Delegate cb_onOneofManyCodeSelected_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V;

		private static Delegate cb_onScanBarcodeDetection_OnScanBarcodeDetection_Z_V;

		private static Delegate cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;

		private static Delegate cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.ManagedPeerType;

		public IOnBarcodeScanResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static void n_OnBatchScanResultSuccess_Ljava_util_ArrayList_(nint jnienv, nint native__this, nint native_result)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<ScanResultSuccess> result = JavaList<ScanResultSuccess>.FromJniHandle(native_result, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnBatchScanResultSuccess(result);
		}

		public unsafe void OnBatchScanResultSuccess(IList<ScanResultSuccess> result)
		{
			nint num = JavaList<ScanResultSuccess>.ToLocalJniHandle(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onBatchScanResultSuccess.(Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(result);
			}
		}

		private static void n_OnOneOfManyCodeResult_Ljava_util_HashSet_(nint jnienv, nint native__this, nint native_results)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			HashSet results = Java.Lang.Object.GetObject<HashSet>(native_results, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnOneOfManyCodeResult(results);
		}

		public unsafe void OnOneOfManyCodeResult(HashSet results)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(results?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onOneOfManyCodeResult.(Ljava/util/HashSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(results);
			}
		}

		private static void n_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_(nint jnienv, nint native__this, nint native_result)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OneOFManyCodesScanResults result = Java.Lang.Object.GetObject<OneOFManyCodesScanResults>(native_result, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnOneofManyCodeRemoved(result);
		}

		public unsafe void OnOneofManyCodeRemoved(OneOFManyCodesScanResults result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onOneofManyCodeRemoved.(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}

		private static void n_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_(nint jnienv, nint native__this, nint native_result)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OneOFManyCodesScanResults result = Java.Lang.Object.GetObject<OneOFManyCodesScanResults>(native_result, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnOneofManyCodeSelected(result);
		}

		public unsafe void OnOneofManyCodeSelected(OneOFManyCodesScanResults result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onOneofManyCodeSelected.(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}

		private static void n_OnScanBarcodeDetection_Z(nint jnienv, nint native__this, bool isDetected)
		{
			Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScanBarcodeDetection(isDetected);
		}

		public unsafe void OnScanBarcodeDetection(bool isDetected)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isDetected);
			_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanBarcodeDetection.(Z)V", this, ptr);
		}

		private static void n_OnScanResultFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnScanResultFailure(error);
		}

		public unsafe void OnScanResultFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess_(nint jnienv, nint native__this, nint native_result)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ScanResultSuccess result = Java.Lang.Object.GetObject<ScanResultSuccess>(native_result, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnScanResultSuccess(result);
		}

		public unsafe void OnScanResultSuccess(ScanResultSuccess result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnBatchScanResultSuccess_Ljava_util_ArrayList__mm_wrapper(nint jnienv, nint native__this, nint native_result)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnBatchScanResultSuccess_Ljava_util_ArrayList_(jnienv, native__this, native_result);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnOneOfManyCodeResult_Ljava_util_HashSet__mm_wrapper(nint jnienv, nint native__this, nint native_results)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnOneOfManyCodeResult_Ljava_util_HashSet_(jnienv, native__this, native_results);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__mm_wrapper(nint jnienv, nint native__this, nint native_result)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_(jnienv, native__this, native_result);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__mm_wrapper(nint jnienv, nint native__this, nint native_result)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_(jnienv, native__this, native_result);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnScanBarcodeDetection_Z_mm_wrapper(nint jnienv, nint native__this, byte isDetected)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnScanBarcodeDetection_Z(jnienv, native__this, isDetected != 0);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnScanResultFailure_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_error)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnScanResultFailure_Ljava_lang_String_(jnienv, native__this, native_error);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess__mm_wrapper(nint jnienv, nint native__this, nint native_result)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess_(jnienv, native__this, native_result);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnCameraResultCallbackInvoker")]
	public interface IOnCameraResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScanResultFailure", "(Ljava/lang/String;)V", "GetOnScanResultFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnCameraResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultFailure(string error);

		[Register("onScanResultSuccess", "(Landroid/graphics/Bitmap;)V", "GetOnScanResultSuccess_Landroid_graphics_Bitmap_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnCameraResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultSuccess(Bitmap bitmap);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback", DoNotGenerateAcw = true)]
	internal class IOnCameraResultCallbackInvoker : Java.Lang.Object, IOnCameraResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback", typeof(IOnCameraResultCallbackInvoker));

		private static Delegate cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;

		private static Delegate cb_onScanResultSuccess_OnScanResultSuccess_Landroid_graphics_Bitmap__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback.ManagedPeerType;

		public IOnCameraResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnScanResultFailure_Ljava_lang_String_Handler()
		{
			if ((object)cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V == null)
			{
				cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultFailure_Ljava_lang_String_));
			}
			return cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;
		}

		private static void n_OnScanResultFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnCameraResultCallback? onCameraResultCallback = Java.Lang.Object.GetObject<IOnCameraResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onCameraResultCallback.OnScanResultFailure(error);
		}

		public unsafe void OnScanResultFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetOnScanResultSuccess_Landroid_graphics_Bitmap_Handler()
		{
			if ((object)cb_onScanResultSuccess_OnScanResultSuccess_Landroid_graphics_Bitmap__V == null)
			{
				cb_onScanResultSuccess_OnScanResultSuccess_Landroid_graphics_Bitmap__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultSuccess_Landroid_graphics_Bitmap_));
			}
			return cb_onScanResultSuccess_OnScanResultSuccess_Landroid_graphics_Bitmap__V;
		}

		private static void n_OnScanResultSuccess_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_bitmap)
		{
			IOnCameraResultCallback? onCameraResultCallback = Java.Lang.Object.GetObject<IOnCameraResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			onCameraResultCallback.OnScanResultSuccess(bitmap);
		}

		public unsafe void OnScanResultSuccess(Bitmap bitmap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Landroid/graphics/Bitmap;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bitmap);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnIDCardScanResultCallbackInvoker")]
	public interface IOnIDCardScanResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScanResultSuccess", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;)V", "GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_IDCardScanResult_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnIDCardScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultSuccess(IDCardScanResult result);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback", DoNotGenerateAcw = true)]
	internal class IOnIDCardScanResultCallbackInvoker : Java.Lang.Object, IOnIDCardScanResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback", typeof(IOnIDCardScanResultCallbackInvoker));

		private static Delegate cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_IDCardScanResult__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback.ManagedPeerType;

		public IOnIDCardScanResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_IDCardScanResult_Handler()
		{
			if ((object)cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_IDCardScanResult__V == null)
			{
				cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_IDCardScanResult__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_IDCardScanResult_));
			}
			return cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_IDCardScanResult__V;
		}

		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_IDCardScanResult_(nint jnienv, nint native__this, nint native_result)
		{
			IOnIDCardScanResultCallback? onIDCardScanResultCallback = Java.Lang.Object.GetObject<IOnIDCardScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDCardScanResult result = Java.Lang.Object.GetObject<IDCardScanResult>(native_result, JniHandleOwnership.DoNotTransfer);
			onIDCardScanResultCallback.OnScanResultSuccess(result);
		}

		public unsafe void OnScanResultSuccess(IDCardScanResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnLicenseValidationCallbackInvoker")]
	public interface IOnLicenseValidationCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onLicenseFailure", "(Ljava/lang/String;)V", "GetOnLicenseFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnLicenseValidationCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnLicenseFailure(string error);

		[Register("onLicenseSuccess", "(Ljava/lang/String;)V", "GetOnLicenseSuccess_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnLicenseValidationCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnLicenseSuccess(string result);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback", DoNotGenerateAcw = true)]
	internal class IOnLicenseValidationCallbackInvoker : Java.Lang.Object, IOnLicenseValidationCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback", typeof(IOnLicenseValidationCallbackInvoker));

		private static Delegate cb_onLicenseFailure_OnLicenseFailure_Ljava_lang_String__V;

		private static Delegate cb_onLicenseSuccess_OnLicenseSuccess_Ljava_lang_String__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback.ManagedPeerType;

		public IOnLicenseValidationCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static void n_OnLicenseFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnLicenseValidationCallback? onLicenseValidationCallback = Java.Lang.Object.GetObject<IOnLicenseValidationCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onLicenseValidationCallback.OnLicenseFailure(error);
		}

		public unsafe void OnLicenseFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback.InstanceMethods.InvokeAbstractVoidMethod("onLicenseFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static void n_OnLicenseSuccess_Ljava_lang_String_(nint jnienv, nint native__this, nint native_result)
		{
			IOnLicenseValidationCallback? onLicenseValidationCallback = Java.Lang.Object.GetObject<IOnLicenseValidationCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string result = JNIEnv.GetString(native_result, JniHandleOwnership.DoNotTransfer);
			onLicenseValidationCallback.OnLicenseSuccess(result);
		}

		public unsafe void OnLicenseSuccess(string result)
		{
			nint num = JNIEnv.NewString(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback.InstanceMethods.InvokeAbstractVoidMethod("onLicenseSuccess.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnLicenseFailure_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_error)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnLicenseFailure_Ljava_lang_String_(jnienv, native__this, native_error);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnLicenseSuccess_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_result)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnLicenseSuccess_Ljava_lang_String_(jnienv, native__this, native_result);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnOneTouchCallbackInvoker")]
	public interface IOnOneTouchCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCompleted", "()V", "GetOnCompletedHandler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnOneTouchCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnCompleted();

		[Register("onStarted", "()V", "GetOnStartedHandler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnOneTouchCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnStarted();
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback", DoNotGenerateAcw = true)]
	internal class IOnOneTouchCallbackInvoker : Java.Lang.Object, IOnOneTouchCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback", typeof(IOnOneTouchCallbackInvoker));

		private static Delegate cb_onCompleted_OnCompleted_V;

		private static Delegate cb_onStarted_OnStarted_V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback.ManagedPeerType;

		public IOnOneTouchCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnCompletedHandler()
		{
			if ((object)cb_onCompleted_OnCompleted_V == null)
			{
				cb_onCompleted_OnCompleted_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCompleted));
			}
			return cb_onCompleted_OnCompleted_V;
		}

		private static void n_OnCompleted(nint jnienv, nint native__this)
		{
			Java.Lang.Object.GetObject<IOnOneTouchCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCompleted();
		}

		public unsafe void OnCompleted()
		{
			_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback.InstanceMethods.InvokeAbstractVoidMethod("onCompleted.()V", this, null);
		}

		private static Delegate GetOnStartedHandler()
		{
			if ((object)cb_onStarted_OnStarted_V == null)
			{
				cb_onStarted_OnStarted_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStarted));
			}
			return cb_onStarted_OnStarted_V;
		}

		private static void n_OnStarted(nint jnienv, nint native__this)
		{
			Java.Lang.Object.GetObject<IOnOneTouchCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStarted();
		}

		public unsafe void OnStarted()
		{
			_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback.InstanceMethods.InvokeAbstractVoidMethod("onStarted.()V", this, null);
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentScanResultCallbackInvoker")]
	public interface IOnTextComponentScanResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScanResultFailure", "(Ljava/lang/String;)V", "GetOnScanResultFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultFailure(string error);

		[Register("onScanResultSuccess", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextComponentScanResult;)V", "GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextComponentScanResult_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultSuccess(TextComponentScanResult result);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback", DoNotGenerateAcw = true)]
	internal class IOnTextComponentScanResultCallbackInvoker : Java.Lang.Object, IOnTextComponentScanResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback", typeof(IOnTextComponentScanResultCallbackInvoker));

		private static Delegate cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;

		private static Delegate cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextComponentScanResult__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback.ManagedPeerType;

		public IOnTextComponentScanResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnScanResultFailure_Ljava_lang_String_Handler()
		{
			if ((object)cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V == null)
			{
				cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultFailure_Ljava_lang_String_));
			}
			return cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;
		}

		private static void n_OnScanResultFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnTextComponentScanResultCallback? onTextComponentScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onTextComponentScanResultCallback.OnScanResultFailure(error);
		}

		public unsafe void OnScanResultFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextComponentScanResult_Handler()
		{
			if ((object)cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextComponentScanResult__V == null)
			{
				cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextComponentScanResult__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextComponentScanResult_));
			}
			return cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextComponentScanResult__V;
		}

		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextComponentScanResult_(nint jnienv, nint native__this, nint native_result)
		{
			IOnTextComponentScanResultCallback? onTextComponentScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextComponentScanResult result = Java.Lang.Object.GetObject<TextComponentScanResult>(native_result, JniHandleOwnership.DoNotTransfer);
			onTextComponentScanResultCallback.OnScanResultSuccess(result);
		}

		public unsafe void OnScanResultSuccess(TextComponentScanResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextComponentScanResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentVinPlateScanResultCallbackInvoker")]
	public interface IOnTextComponentVinPlateScanResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScanResultFailure", "(Ljava/lang/String;)V", "GetOnScanResultFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentVinPlateScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultFailure(string error);

		[Register("onScanResultStatus", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;)V", "GetOnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullStatusResult_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentVinPlateScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultStatus(VinPlateFullStatusResult result);

		[Register("onScanResultSuccess", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;)V", "GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullScanResult_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentVinPlateScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultSuccess(VinPlateFullScanResult result);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback", DoNotGenerateAcw = true)]
	internal class IOnTextComponentVinPlateScanResultCallbackInvoker : Java.Lang.Object, IOnTextComponentVinPlateScanResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback", typeof(IOnTextComponentVinPlateScanResultCallbackInvoker));

		private static Delegate cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;

		private static Delegate cb_onScanResultStatus_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullStatusResult__V;

		private static Delegate cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullScanResult__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback.ManagedPeerType;

		public IOnTextComponentVinPlateScanResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnScanResultFailure_Ljava_lang_String_Handler()
		{
			if ((object)cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V == null)
			{
				cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultFailure_Ljava_lang_String_));
			}
			return cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;
		}

		private static void n_OnScanResultFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnTextComponentVinPlateScanResultCallback? onTextComponentVinPlateScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentVinPlateScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onTextComponentVinPlateScanResultCallback.OnScanResultFailure(error);
		}

		public unsafe void OnScanResultFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetOnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullStatusResult_Handler()
		{
			if ((object)cb_onScanResultStatus_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullStatusResult__V == null)
			{
				cb_onScanResultStatus_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullStatusResult__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullStatusResult_));
			}
			return cb_onScanResultStatus_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullStatusResult__V;
		}

		private static void n_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullStatusResult_(nint jnienv, nint native__this, nint native_result)
		{
			IOnTextComponentVinPlateScanResultCallback? onTextComponentVinPlateScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentVinPlateScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			VinPlateFullStatusResult result = Java.Lang.Object.GetObject<VinPlateFullStatusResult>(native_result, JniHandleOwnership.DoNotTransfer);
			onTextComponentVinPlateScanResultCallback.OnScanResultStatus(result);
		}

		public unsafe void OnScanResultStatus(VinPlateFullStatusResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultStatus.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullScanResult_Handler()
		{
			if ((object)cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullScanResult__V == null)
			{
				cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullScanResult__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullScanResult_));
			}
			return cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullScanResult__V;
		}

		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinPlateFullScanResult_(nint jnienv, nint native__this, nint native_result)
		{
			IOnTextComponentVinPlateScanResultCallback? onTextComponentVinPlateScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentVinPlateScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			VinPlateFullScanResult result = Java.Lang.Object.GetObject<VinPlateFullScanResult>(native_result, JniHandleOwnership.DoNotTransfer);
			onTextComponentVinPlateScanResultCallback.OnScanResultSuccess(result);
		}

		public unsafe void OnScanResultSuccess(VinPlateFullScanResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentVinStickerScanResultCallbackInvoker")]
	public interface IOnTextComponentVinStickerScanResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScanResultFailure", "(Ljava/lang/String;)V", "GetOnScanResultFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentVinStickerScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultFailure(string error);

		[Register("onScanResultStatus", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;)V", "GetOnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullStatusResult_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentVinStickerScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultStatus(VinStickerFullStatusResult result);

		[Register("onScanResultSuccess", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullScanResult;)V", "GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullScanResult_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextComponentVinStickerScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultSuccess(VinStickerFullScanResult result);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback", DoNotGenerateAcw = true)]
	internal class IOnTextComponentVinStickerScanResultCallbackInvoker : Java.Lang.Object, IOnTextComponentVinStickerScanResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback", typeof(IOnTextComponentVinStickerScanResultCallbackInvoker));

		private static Delegate cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;

		private static Delegate cb_onScanResultStatus_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullStatusResult__V;

		private static Delegate cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullScanResult__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback.ManagedPeerType;

		public IOnTextComponentVinStickerScanResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnScanResultFailure_Ljava_lang_String_Handler()
		{
			if ((object)cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V == null)
			{
				cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultFailure_Ljava_lang_String_));
			}
			return cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;
		}

		private static void n_OnScanResultFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnTextComponentVinStickerScanResultCallback? onTextComponentVinStickerScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentVinStickerScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onTextComponentVinStickerScanResultCallback.OnScanResultFailure(error);
		}

		public unsafe void OnScanResultFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetOnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullStatusResult_Handler()
		{
			if ((object)cb_onScanResultStatus_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullStatusResult__V == null)
			{
				cb_onScanResultStatus_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullStatusResult__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullStatusResult_));
			}
			return cb_onScanResultStatus_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullStatusResult__V;
		}

		private static void n_OnScanResultStatus_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullStatusResult_(nint jnienv, nint native__this, nint native_result)
		{
			IOnTextComponentVinStickerScanResultCallback? onTextComponentVinStickerScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentVinStickerScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			VinStickerFullStatusResult result = Java.Lang.Object.GetObject<VinStickerFullStatusResult>(native_result, JniHandleOwnership.DoNotTransfer);
			onTextComponentVinStickerScanResultCallback.OnScanResultStatus(result);
		}

		public unsafe void OnScanResultStatus(VinStickerFullStatusResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultStatus.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullScanResult_Handler()
		{
			if ((object)cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullScanResult__V == null)
			{
				cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullScanResult__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullScanResult_));
			}
			return cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullScanResult__V;
		}

		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_VinStickerFullScanResult_(nint jnienv, nint native__this, nint native_result)
		{
			IOnTextComponentVinStickerScanResultCallback? onTextComponentVinStickerScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentVinStickerScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			VinStickerFullScanResult result = Java.Lang.Object.GetObject<VinStickerFullScanResult>(native_result, JniHandleOwnership.DoNotTransfer);
			onTextComponentVinStickerScanResultCallback.OnScanResultSuccess(result);
		}

		public unsafe void OnScanResultSuccess(VinStickerFullScanResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullScanResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextScanResultCallbackInvoker")]
	public interface IOnTextScanResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScanResultFailure", "(Ljava/lang/String;)V", "GetOnScanResultFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultFailure(string error);

		[Register("onScanResultSuccess", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;)V", "GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextScanResult_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnTextScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultSuccess(TextScanResult result);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback", DoNotGenerateAcw = true)]
	internal class IOnTextScanResultCallbackInvoker : Java.Lang.Object, IOnTextScanResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback", typeof(IOnTextScanResultCallbackInvoker));

		private static Delegate cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;

		private static Delegate cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextScanResult__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback.ManagedPeerType;

		public IOnTextScanResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnScanResultFailure_Ljava_lang_String_Handler()
		{
			if ((object)cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V == null)
			{
				cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultFailure_Ljava_lang_String_));
			}
			return cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;
		}

		private static void n_OnScanResultFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnTextScanResultCallback? onTextScanResultCallback = Java.Lang.Object.GetObject<IOnTextScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onTextScanResultCallback.OnScanResultFailure(error);
		}

		public unsafe void OnScanResultFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextScanResult_Handler()
		{
			if ((object)cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextScanResult__V == null)
			{
				cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextScanResult__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextScanResult_));
			}
			return cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextScanResult__V;
		}

		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_TextScanResult_(nint jnienv, nint native__this, nint native_result)
		{
			IOnTextScanResultCallback? onTextScanResultCallback = Java.Lang.Object.GetObject<IOnTextScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextScanResult result = Java.Lang.Object.GetObject<TextScanResult>(native_result, JniHandleOwnership.DoNotTransfer);
			onTextScanResultCallback.OnScanResultSuccess(result);
		}

		public unsafe void OnScanResultSuccess(TextScanResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback", "", "Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnWebServiceScanResultCallbackInvoker")]
	public interface IOnWebServiceScanResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScanResultFailure", "(Ljava/lang/String;)V", "GetOnScanResultFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnWebServiceScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultFailure(string error);

		[Register("onScanResultSuccess", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$WebServiceScanResult;)V", "GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_WebServiceScanResult_Handler:Com.Scanflow.Datacapture.Core.Camera.ScanflowReader/IOnWebServiceScanResultCallbackInvoker, Scanflow.DataCapture.Core.Maui")]
		void OnScanResultSuccess(WebServiceScanResult result);
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback", DoNotGenerateAcw = true)]
	internal class IOnWebServiceScanResultCallbackInvoker : Java.Lang.Object, IOnWebServiceScanResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback", typeof(IOnWebServiceScanResultCallbackInvoker));

		private static Delegate cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;

		private static Delegate cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_WebServiceScanResult__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback.ManagedPeerType;

		public IOnWebServiceScanResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnScanResultFailure_Ljava_lang_String_Handler()
		{
			if ((object)cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V == null)
			{
				cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultFailure_Ljava_lang_String_));
			}
			return cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;
		}

		private static void n_OnScanResultFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnWebServiceScanResultCallback? onWebServiceScanResultCallback = Java.Lang.Object.GetObject<IOnWebServiceScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onWebServiceScanResultCallback.OnScanResultFailure(error);
		}

		public unsafe void OnScanResultFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetOnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_WebServiceScanResult_Handler()
		{
			if ((object)cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_WebServiceScanResult__V == null)
			{
				cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_WebServiceScanResult__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_WebServiceScanResult_));
			}
			return cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_WebServiceScanResult__V;
		}

		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_core_camera_ScanflowReader_WebServiceScanResult_(nint jnienv, nint native__this, nint native_result)
		{
			IOnWebServiceScanResultCallback? onWebServiceScanResultCallback = Java.Lang.Object.GetObject<IOnWebServiceScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WebServiceScanResult result = Java.Lang.Object.GetObject<WebServiceScanResult>(native_result, JniHandleOwnership.DoNotTransfer);
			onWebServiceScanResultCallback.OnScanResultSuccess(result);
		}

		public unsafe void OnScanResultSuccess(WebServiceScanResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$WebServiceScanResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$TextComponentScanResult", DoNotGenerateAcw = true)]
	public sealed class TextComponentScanResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$TextComponentScanResult", typeof(TextComponentScanResult));

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

		public unsafe Bitmap Image
		{
			[Register("getImage", "()Landroid/graphics/Bitmap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImage.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setImage", "(Landroid/graphics/Bitmap;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setImage.(Landroid/graphics/Bitmap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe IList<string> SuggestedResults
		{
			[Register("getSuggestedResults", "()Ljava/util/ArrayList;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSuggestedResults.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSuggestedResults", "(Ljava/util/ArrayList;)V", "")]
			set
			{
				nint num = JavaList<string>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setSuggestedResults.(Ljava/util/ArrayList;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Text
		{
			[Register("getText", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setText", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setText.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		internal TextComponentScanResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TextComponentScanResult()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/util/ArrayList;)V", "")]
		public unsafe TextComponentScanResult(string p0, Bitmap p1, IList<string> p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(p0);
			nint num2 = JavaList<string>.ToLocalJniHandle(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(num2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/util/ArrayList;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Landroid/graphics/Bitmap;", "")]
		public unsafe Bitmap Component2()
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component3", "()Ljava/util/ArrayList;", "")]
		public unsafe IList<string> Component3()
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component3.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/util/ArrayList;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextComponentScanResult;", "")]
		public unsafe TextComponentScanResult Copy(string text, Bitmap image, IList<string> suggestedResults)
		{
			nint num = JNIEnv.NewString(text);
			nint num2 = JavaList<string>.ToLocalJniHandle(suggestedResults);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<TextComponentScanResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/util/ArrayList;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextComponentScanResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				GC.KeepAlive(image);
				GC.KeepAlive(suggestedResults);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult", DoNotGenerateAcw = true)]
	public sealed class TextScanResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult", typeof(TextScanResult));

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

		public unsafe Float Confidence
		{
			[Register("getConfidence", "()Ljava/lang/Float;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getConfidence.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setConfidence", "(Ljava/lang/Float;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setConfidence.(Ljava/lang/Float;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Bitmap Image
		{
			[Register("getImage", "()Landroid/graphics/Bitmap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImage.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setImage", "(Landroid/graphics/Bitmap;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setImage.(Landroid/graphics/Bitmap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Java.Lang.Double LatitudeObj
		{
			[Register("getLatitudeObj", "()Ljava/lang/Double;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLatitudeObj.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLatitudeObj", "(Ljava/lang/Double;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLatitudeObj.(Ljava/lang/Double;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Java.Lang.Double LongitudeObj
		{
			[Register("getLongitudeObj", "()Ljava/lang/Double;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLongitudeObj.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLongitudeObj", "(Ljava/lang/Double;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLongitudeObj.(Ljava/lang/Double;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Rawtext
		{
			[Register("getRawtext", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRawtext.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setRawtext", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setRawtext.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe string Text
		{
			[Register("getText", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setText", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setText.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		public unsafe string UnprocessResult
		{
			[Register("getUnprocessResult", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUnprocessResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setUnprocessResult", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setUnprocessResult.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		internal TextScanResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TextScanResult()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)V", "")]
		public unsafe TextScanResult(string p0, Bitmap p1, string p2, Float p3, string p4, Java.Lang.Double p5, Java.Lang.Double p6)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(p0);
			nint num2 = JNIEnv.NewString(p2);
			nint num3 = JNIEnv.NewString(p4);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(num2);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(num3);
				ptr[5] = new JniArgumentValue(p5?.Handle ?? IntPtr.Zero);
				ptr[6] = new JniArgumentValue(p6?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
				GC.KeepAlive(p1);
				GC.KeepAlive(p3);
				GC.KeepAlive(p5);
				GC.KeepAlive(p6);
			}
		}

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Landroid/graphics/Bitmap;", "")]
		public unsafe Bitmap Component2()
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component3", "()Ljava/lang/String;", "")]
		public unsafe string Component3()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component3.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component4", "()Ljava/lang/Float;", "")]
		public unsafe Float Component4()
		{
			return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component4.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component5", "()Ljava/lang/String;", "")]
		public unsafe string Component5()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component5.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component6", "()Ljava/lang/Double;", "")]
		public unsafe Java.Lang.Double Component6()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component6.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component7", "()Ljava/lang/Double;", "")]
		public unsafe Java.Lang.Double Component7()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component7.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;", "")]
		public unsafe TextScanResult Copy(string text, Bitmap image, string rawtext, Float p3, string unprocessResult, Java.Lang.Double p5, Java.Lang.Double p6)
		{
			nint num = JNIEnv.NewString(text);
			nint num2 = JNIEnv.NewString(rawtext);
			nint num3 = JNIEnv.NewString(unprocessResult);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(num2);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(num3);
				ptr[5] = new JniArgumentValue(p5?.Handle ?? IntPtr.Zero);
				ptr[6] = new JniArgumentValue(p6?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TextScanResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/Float;Ljava/lang/String;Ljava/lang/Double;Ljava/lang/Double;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
				GC.KeepAlive(image);
				GC.KeepAlive(p3);
				GC.KeepAlive(p5);
				GC.KeepAlive(p6);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult", DoNotGenerateAcw = true)]
	public sealed class VinPlateFullScanResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult", typeof(VinPlateFullScanResult));

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

		public unsafe string Axle1
		{
			[Register("getAxle1", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAxle1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Axle2
		{
			[Register("getAxle2", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAxle2.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Axle3
		{
			[Register("getAxle3", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAxle3.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Axle4
		{
			[Register("getAxle4", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAxle4.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Axle5
		{
			[Register("getAxle5", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAxle5.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Gcw
		{
			[Register("getGcw", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getGcw.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Gvm
		{
			[Register("getGvm", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getGvm.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> SuggestedTypResults
		{
			[Register("getSuggestedTypResults", "()Ljava/util/ArrayList;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSuggestedTypResults.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> SuggestedVinResults
		{
			[Register("getSuggestedVinResults", "()Ljava/util/ArrayList;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSuggestedVinResults.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Typ
		{
			[Register("getTyp", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTyp.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Vin
		{
			[Register("getVin", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getVin.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal VinPlateFullScanResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", "")]
		public unsafe VinPlateFullScanResult(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, IList<string> p9, IList<string> p10)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(p0);
			nint num2 = JNIEnv.NewString(p1);
			nint num3 = JNIEnv.NewString(p2);
			nint num4 = JNIEnv.NewString(p3);
			nint num5 = JNIEnv.NewString(p4);
			nint num6 = JNIEnv.NewString(p5);
			nint num7 = JNIEnv.NewString(p6);
			nint num8 = JNIEnv.NewString(p7);
			nint num9 = JNIEnv.NewString(p8);
			nint num10 = JavaList<string>.ToLocalJniHandle(p9);
			nint num11 = JavaList<string>.ToLocalJniHandle(p10);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[11];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue(num3);
				ptr[3] = new JniArgumentValue(num4);
				ptr[4] = new JniArgumentValue(num5);
				ptr[5] = new JniArgumentValue(num6);
				ptr[6] = new JniArgumentValue(num7);
				ptr[7] = new JniArgumentValue(num8);
				ptr[8] = new JniArgumentValue(num9);
				ptr[9] = new JniArgumentValue(num10);
				ptr[10] = new JniArgumentValue(num11);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
				JNIEnv.DeleteLocalRef(num4);
				JNIEnv.DeleteLocalRef(num5);
				JNIEnv.DeleteLocalRef(num6);
				JNIEnv.DeleteLocalRef(num7);
				JNIEnv.DeleteLocalRef(num8);
				JNIEnv.DeleteLocalRef(num9);
				JNIEnv.DeleteLocalRef(num10);
				JNIEnv.DeleteLocalRef(num11);
				GC.KeepAlive(p9);
				GC.KeepAlive(p10);
			}
		}

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component10", "()Ljava/util/ArrayList;", "")]
		public unsafe IList<string> Component10()
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component10.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component11", "()Ljava/util/ArrayList;", "")]
		public unsafe IList<string> Component11()
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component11.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Ljava/lang/String;", "")]
		public unsafe string Component2()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component3", "()Ljava/lang/String;", "")]
		public unsafe string Component3()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component3.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component4", "()Ljava/lang/String;", "")]
		public unsafe string Component4()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component4.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component5", "()Ljava/lang/String;", "")]
		public unsafe string Component5()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component5.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component6", "()Ljava/lang/String;", "")]
		public unsafe string Component6()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component6.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component7", "()Ljava/lang/String;", "")]
		public unsafe string Component7()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component7.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component8", "()Ljava/lang/String;", "")]
		public unsafe string Component8()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component8.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component9", "()Ljava/lang/String;", "")]
		public unsafe string Component9()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component9.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;", "")]
		public unsafe VinPlateFullScanResult Copy(string typ, string vin, string gvm, string gcw, string axle1, string axle2, string axle3, string axle4, string axle5, IList<string> suggestedTypResults, IList<string> suggestedVinResults)
		{
			nint num = JNIEnv.NewString(typ);
			nint num2 = JNIEnv.NewString(vin);
			nint num3 = JNIEnv.NewString(gvm);
			nint num4 = JNIEnv.NewString(gcw);
			nint num5 = JNIEnv.NewString(axle1);
			nint num6 = JNIEnv.NewString(axle2);
			nint num7 = JNIEnv.NewString(axle3);
			nint num8 = JNIEnv.NewString(axle4);
			nint num9 = JNIEnv.NewString(axle5);
			nint num10 = JavaList<string>.ToLocalJniHandle(suggestedTypResults);
			nint num11 = JavaList<string>.ToLocalJniHandle(suggestedVinResults);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[11];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue(num3);
				ptr[3] = new JniArgumentValue(num4);
				ptr[4] = new JniArgumentValue(num5);
				ptr[5] = new JniArgumentValue(num6);
				ptr[6] = new JniArgumentValue(num7);
				ptr[7] = new JniArgumentValue(num8);
				ptr[8] = new JniArgumentValue(num9);
				ptr[9] = new JniArgumentValue(num10);
				ptr[10] = new JniArgumentValue(num11);
				return Java.Lang.Object.GetObject<VinPlateFullScanResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
				JNIEnv.DeleteLocalRef(num4);
				JNIEnv.DeleteLocalRef(num5);
				JNIEnv.DeleteLocalRef(num6);
				JNIEnv.DeleteLocalRef(num7);
				JNIEnv.DeleteLocalRef(num8);
				JNIEnv.DeleteLocalRef(num9);
				JNIEnv.DeleteLocalRef(num10);
				JNIEnv.DeleteLocalRef(num11);
				GC.KeepAlive(suggestedTypResults);
				GC.KeepAlive(suggestedVinResults);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult", DoNotGenerateAcw = true)]
	public sealed class VinPlateFullStatusResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult", typeof(VinPlateFullStatusResult));

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

		public unsafe bool Axle1
		{
			[Register("getAxle1", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAxle1.()Z", this, null);
			}
		}

		public unsafe bool Axle2
		{
			[Register("getAxle2", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAxle2.()Z", this, null);
			}
		}

		public unsafe bool Axle3
		{
			[Register("getAxle3", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAxle3.()Z", this, null);
			}
		}

		public unsafe bool Axle4
		{
			[Register("getAxle4", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAxle4.()Z", this, null);
			}
		}

		public unsafe bool Axle5
		{
			[Register("getAxle5", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAxle5.()Z", this, null);
			}
		}

		public unsafe bool Gcw
		{
			[Register("getGcw", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getGcw.()Z", this, null);
			}
		}

		public unsafe bool Gvm
		{
			[Register("getGvm", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getGvm.()Z", this, null);
			}
		}

		public unsafe bool Typ
		{
			[Register("getTyp", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getTyp.()Z", this, null);
			}
		}

		public unsafe bool Vin
		{
			[Register("getVin", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getVin.()Z", this, null);
			}
		}

		internal VinPlateFullStatusResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(ZZZZZZZZZ)V", "")]
		public unsafe VinPlateFullStatusResult(bool p0, bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				ptr[4] = new JniArgumentValue(p4);
				ptr[5] = new JniArgumentValue(p5);
				ptr[6] = new JniArgumentValue(p6);
				ptr[7] = new JniArgumentValue(p7);
				ptr[8] = new JniArgumentValue(p8);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ZZZZZZZZZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ZZZZZZZZZ)V", this, ptr);
			}
		}

		[Register("component1", "()Z", "")]
		public unsafe bool Component1()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component1.()Z", this, null);
		}

		[Register("component2", "()Z", "")]
		public unsafe bool Component2()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component2.()Z", this, null);
		}

		[Register("component3", "()Z", "")]
		public unsafe bool Component3()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component3.()Z", this, null);
		}

		[Register("component4", "()Z", "")]
		public unsafe bool Component4()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component4.()Z", this, null);
		}

		[Register("component5", "()Z", "")]
		public unsafe bool Component5()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component5.()Z", this, null);
		}

		[Register("component6", "()Z", "")]
		public unsafe bool Component6()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component6.()Z", this, null);
		}

		[Register("component7", "()Z", "")]
		public unsafe bool Component7()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component7.()Z", this, null);
		}

		[Register("component8", "()Z", "")]
		public unsafe bool Component8()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component8.()Z", this, null);
		}

		[Register("component9", "()Z", "")]
		public unsafe bool Component9()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component9.()Z", this, null);
		}

		[Register("copy", "(ZZZZZZZZZ)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;", "")]
		public unsafe VinPlateFullStatusResult Copy(bool typ, bool vin, bool gvm, bool gcw, bool axle1, bool axle2, bool axle3, bool axle4, bool axle5)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(typ);
			ptr[1] = new JniArgumentValue(vin);
			ptr[2] = new JniArgumentValue(gvm);
			ptr[3] = new JniArgumentValue(gcw);
			ptr[4] = new JniArgumentValue(axle1);
			ptr[5] = new JniArgumentValue(axle2);
			ptr[6] = new JniArgumentValue(axle3);
			ptr[7] = new JniArgumentValue(axle4);
			ptr[8] = new JniArgumentValue(axle5);
			return Java.Lang.Object.GetObject<VinPlateFullStatusResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(ZZZZZZZZZ)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullScanResult", DoNotGenerateAcw = true)]
	public sealed class VinStickerFullScanResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullScanResult", typeof(VinStickerFullScanResult));

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

		public unsafe string AxleOneByTwo
		{
			[Register("getAxleOneByTwo", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAxleOneByTwo.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string AxleThreeByFour
		{
			[Register("getAxleThreeByFour", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAxleThreeByFour.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Category
		{
			[Register("getCategory", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCategory.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Date
		{
			[Register("getDate", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDate.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Gcw
		{
			[Register("getGcw", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getGcw.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> SuggestedTypResults
		{
			[Register("getSuggestedTypResults", "()Ljava/util/ArrayList;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSuggestedTypResults.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> SuggestedVinResults
		{
			[Register("getSuggestedVinResults", "()Ljava/util/ArrayList;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSuggestedVinResults.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Type
		{
			[Register("getType", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Vin
		{
			[Register("getVin", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getVin.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal VinStickerFullScanResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", "")]
		public unsafe VinStickerFullScanResult(string p0, string p1, string p2, string p3, string p4, string p5, string p6, IList<string> p7, IList<string> p8)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(p0);
			nint num2 = JNIEnv.NewString(p1);
			nint num3 = JNIEnv.NewString(p2);
			nint num4 = JNIEnv.NewString(p3);
			nint num5 = JNIEnv.NewString(p4);
			nint num6 = JNIEnv.NewString(p5);
			nint num7 = JNIEnv.NewString(p6);
			nint num8 = JavaList<string>.ToLocalJniHandle(p7);
			nint num9 = JavaList<string>.ToLocalJniHandle(p8);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue(num3);
				ptr[3] = new JniArgumentValue(num4);
				ptr[4] = new JniArgumentValue(num5);
				ptr[5] = new JniArgumentValue(num6);
				ptr[6] = new JniArgumentValue(num7);
				ptr[7] = new JniArgumentValue(num8);
				ptr[8] = new JniArgumentValue(num9);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
				JNIEnv.DeleteLocalRef(num4);
				JNIEnv.DeleteLocalRef(num5);
				JNIEnv.DeleteLocalRef(num6);
				JNIEnv.DeleteLocalRef(num7);
				JNIEnv.DeleteLocalRef(num8);
				JNIEnv.DeleteLocalRef(num9);
				GC.KeepAlive(p7);
				GC.KeepAlive(p8);
			}
		}

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Ljava/lang/String;", "")]
		public unsafe string Component2()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component3", "()Ljava/lang/String;", "")]
		public unsafe string Component3()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component3.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component4", "()Ljava/lang/String;", "")]
		public unsafe string Component4()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component4.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component5", "()Ljava/lang/String;", "")]
		public unsafe string Component5()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component5.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component6", "()Ljava/lang/String;", "")]
		public unsafe string Component6()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component6.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component7", "()Ljava/lang/String;", "")]
		public unsafe string Component7()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component7.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component8", "()Ljava/util/ArrayList;", "")]
		public unsafe IList<string> Component8()
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component8.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component9", "()Ljava/util/ArrayList;", "")]
		public unsafe IList<string> Component9()
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component9.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullScanResult;", "")]
		public unsafe VinStickerFullScanResult Copy(string vin, string date, string category, string gcw, string axleOneByTwo, string axleThreeByFour, string type, IList<string> suggestedTypResults, IList<string> suggestedVinResults)
		{
			nint num = JNIEnv.NewString(vin);
			nint num2 = JNIEnv.NewString(date);
			nint num3 = JNIEnv.NewString(category);
			nint num4 = JNIEnv.NewString(gcw);
			nint num5 = JNIEnv.NewString(axleOneByTwo);
			nint num6 = JNIEnv.NewString(axleThreeByFour);
			nint num7 = JNIEnv.NewString(type);
			nint num8 = JavaList<string>.ToLocalJniHandle(suggestedTypResults);
			nint num9 = JavaList<string>.ToLocalJniHandle(suggestedVinResults);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue(num3);
				ptr[3] = new JniArgumentValue(num4);
				ptr[4] = new JniArgumentValue(num5);
				ptr[5] = new JniArgumentValue(num6);
				ptr[6] = new JniArgumentValue(num7);
				ptr[7] = new JniArgumentValue(num8);
				ptr[8] = new JniArgumentValue(num9);
				return Java.Lang.Object.GetObject<VinStickerFullScanResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullScanResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
				JNIEnv.DeleteLocalRef(num4);
				JNIEnv.DeleteLocalRef(num5);
				JNIEnv.DeleteLocalRef(num6);
				JNIEnv.DeleteLocalRef(num7);
				JNIEnv.DeleteLocalRef(num8);
				JNIEnv.DeleteLocalRef(num9);
				GC.KeepAlive(suggestedTypResults);
				GC.KeepAlive(suggestedVinResults);
			}
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult", DoNotGenerateAcw = true)]
	public sealed class VinStickerFullStatusResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult", typeof(VinStickerFullStatusResult));

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

		public unsafe bool AxleOneByTwo
		{
			[Register("getAxleOneByTwo", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAxleOneByTwo.()Z", this, null);
			}
		}

		public unsafe bool AxleThreeByFour
		{
			[Register("getAxleThreeByFour", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAxleThreeByFour.()Z", this, null);
			}
		}

		public unsafe bool Category
		{
			[Register("getCategory", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getCategory.()Z", this, null);
			}
		}

		public unsafe bool Date
		{
			[Register("getDate", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getDate.()Z", this, null);
			}
		}

		public unsafe bool Gcw
		{
			[Register("getGcw", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getGcw.()Z", this, null);
			}
		}

		public unsafe bool Type
		{
			[Register("getType", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getType.()Z", this, null);
			}
		}

		public unsafe bool Vin
		{
			[Register("getVin", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getVin.()Z", this, null);
			}
		}

		internal VinStickerFullStatusResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(ZZZZZZZ)V", "")]
		public unsafe VinStickerFullStatusResult(bool p0, bool p1, bool p2, bool p3, bool p4, bool p5, bool p6)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				ptr[4] = new JniArgumentValue(p4);
				ptr[5] = new JniArgumentValue(p5);
				ptr[6] = new JniArgumentValue(p6);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ZZZZZZZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ZZZZZZZ)V", this, ptr);
			}
		}

		[Register("component1", "()Z", "")]
		public unsafe bool Component1()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component1.()Z", this, null);
		}

		[Register("component2", "()Z", "")]
		public unsafe bool Component2()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component2.()Z", this, null);
		}

		[Register("component3", "()Z", "")]
		public unsafe bool Component3()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component3.()Z", this, null);
		}

		[Register("component4", "()Z", "")]
		public unsafe bool Component4()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component4.()Z", this, null);
		}

		[Register("component5", "()Z", "")]
		public unsafe bool Component5()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component5.()Z", this, null);
		}

		[Register("component6", "()Z", "")]
		public unsafe bool Component6()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component6.()Z", this, null);
		}

		[Register("component7", "()Z", "")]
		public unsafe bool Component7()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component7.()Z", this, null);
		}

		[Register("copy", "(ZZZZZZZ)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;", "")]
		public unsafe VinStickerFullStatusResult Copy(bool vin, bool date, bool category, bool gcw, bool axleOneByTwo, bool axleThreeByFour, bool type)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(vin);
			ptr[1] = new JniArgumentValue(date);
			ptr[2] = new JniArgumentValue(category);
			ptr[3] = new JniArgumentValue(gcw);
			ptr[4] = new JniArgumentValue(axleOneByTwo);
			ptr[5] = new JniArgumentValue(axleThreeByFour);
			ptr[6] = new JniArgumentValue(type);
			return Java.Lang.Object.GetObject<VinStickerFullStatusResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(ZZZZZZZ)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("com/scanflow/datacapture/core/camera/ScanflowReader$WebServiceScanResult", DoNotGenerateAcw = true)]
	public sealed class WebServiceScanResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader$WebServiceScanResult", typeof(WebServiceScanResult));

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

		public unsafe Bitmap Image
		{
			[Register("getImage", "()Landroid/graphics/Bitmap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImage.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setImage", "(Landroid/graphics/Bitmap;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setImage.(Landroid/graphics/Bitmap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Text
		{
			[Register("getText", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setText", "(Ljava/lang/String;)V", "")]
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setText.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		internal WebServiceScanResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WebServiceScanResult()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Landroid/graphics/Bitmap;)V", "")]
		public unsafe WebServiceScanResult(string p0, Bitmap p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/graphics/Bitmap;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/graphics/Bitmap;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(p1);
			}
		}

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Landroid/graphics/Bitmap;", "")]
		public unsafe Bitmap Component2()
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$WebServiceScanResult;", "")]
		public unsafe WebServiceScanResult Copy(string text, Bitmap image)
		{
			nint num = JNIEnv.NewString(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<WebServiceScanResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$WebServiceScanResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(image);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader", typeof(ScanflowReader));

	private static Delegate cb_bindFlashlightView_BindFlashlightView_Landroid_view_View__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_bindSliderView_BindSliderView_Lcom_google_android_material_slider_Slider__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_captureBatchInventory_CaptureBatchInventory_V;

	private static Delegate cb_captureToScan_CaptureToScan_V;

	private static Delegate cb_doValidateLicense_DoValidateLicense_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_doValidateLicenseWithRetry_DoValidateLicenseWithRetry_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_enableSplitView_EnableSplitView_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_enableTouchZoom_EnableTouchZoom_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_performOneTouchClick_PerformOneTouchClick_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_resetOneToManyCodes_ResetOneToManyCodes_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setAutoExposure_SetAutoExposure_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setAutoFlashlight_SetAutoFlashlight_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setAutoZoom_SetAutoZoom_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setBeepSoundResource_SetBeepSoundResource_I_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setCameraResolution_SetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setEchanceTextCount_SetEchanceTextCount_I_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setEnableDataTracking_SetEnableDataTracking_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setEnableLocationTracking_SetEnableLocationTracking_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setEnableTireAngleDetection_SetEnableTireAngleDetection_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setEnableTirePreProcessing_SetEnableTirePreProcessing_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setEnhanceTextResult_SetEnhanceTextResult_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setIsBatchScanning_SetIsBatchScanning_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setIsContinuousScan_SetIsContinuousScan_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnBarcodeScanResultCallback_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnCameraResultCallback_SetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnIDCardScanResultCallback_SetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnLicenseValidationCallback_SetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnOneTouchCallback_SetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnTextComponentScanResultCallback_SetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnTextComponentVinPlateScanResultCallback_SetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnTextComponentVinStickerScanResultCallback_SetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnTextScanResultCallback_SetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOnWebServiceScanResultCallback_SetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOneToManyCodes_SetOneToManyCodes_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setOneToManyCodesKeepCurrent_SetOneToManyCodesKeepCurrent_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setPlayBeep_SetPlayBeep_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setQrBarcodeDetection_SetQrBarcodeDetection_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setSwitchCategory_SetSwitchCategory_Ljava_lang_String__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setVibrate_SetVibrate_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_setVinNumberColor_SetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_updateConfidenceValue_UpdateConfidenceValue_F_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;

	private static Delegate cb_release_Release_V;

	private static Delegate cb_startCamera_StartCamera_V;

	private static Delegate cb_stopCamera_StopCamera_V;

	private static Delegate cb_getCamera_GetCamera_Landroidx_camera_core_Camera_;

	private static Delegate cb_enableTorch_EnableTorch_Z_V;

	private static Delegate cb_lineZoomIn_LineZoomIn_V;

	private static Delegate cb_lineZoomOut_LineZoomOut_V;

	private static Delegate cb_lineZoomTo_LineZoomTo_F_V;

	private static Delegate cb_zoomIn_ZoomIn_V;

	private static Delegate cb_zoomOut_ZoomOut_V;

	private static Delegate cb_zoomTo_ZoomTo_F_V;

	private static Delegate cb_hasFlashUnit_HasFlashUnit_Z;

	private static Delegate cb_isTorchEnabled_IsTorchEnabled_Z;

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

	public abstract ICamera Camera
	{
		[Register("getCamera", "()Landroidx/camera/core/Camera;", "GetGetCameraHandler")]
		get;
	}

	public abstract bool HasFlashUnit
	{
		[Register("hasFlashUnit", "()Z", "GetHasFlashUnitHandler")]
		get;
	}

	public abstract bool IsTorchEnabled
	{
		[Register("isTorchEnabled", "()Z", "GetIsTorchEnabledHandler")]
		get;
	}

	protected ScanflowReader(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ScanflowReader()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetBindFlashlightView_Landroid_view_View_Handler()
	{
		if ((object)cb_bindFlashlightView_BindFlashlightView_Landroid_view_View__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_bindFlashlightView_BindFlashlightView_Landroid_view_View__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_BindFlashlightView_Landroid_view_View_));
		}
		return cb_bindFlashlightView_BindFlashlightView_Landroid_view_View__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_BindFlashlightView_Landroid_view_View_(nint jnienv, nint native__this, nint native_v)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.BindFlashlightView(v));
	}

	[Register("bindFlashlightView", "(Landroid/view/View;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetBindFlashlightView_Landroid_view_View_Handler")]
	public abstract ScanflowReader BindFlashlightView(View v);

	private static Delegate GetBindSliderView_Lcom_google_android_material_slider_Slider_Handler()
	{
		if ((object)cb_bindSliderView_BindSliderView_Lcom_google_android_material_slider_Slider__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_bindSliderView_BindSliderView_Lcom_google_android_material_slider_Slider__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_BindSliderView_Lcom_google_android_material_slider_Slider_));
		}
		return cb_bindSliderView_BindSliderView_Lcom_google_android_material_slider_Slider__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_BindSliderView_Lcom_google_android_material_slider_Slider_(nint jnienv, nint native__this, nint native_v)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Slider v = Java.Lang.Object.GetObject<Slider>(native_v, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.BindSliderView(v));
	}

	[Register("bindSliderView", "(Lcom/google/android/material/slider/Slider;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetBindSliderView_Lcom_google_android_material_slider_Slider_Handler")]
	public abstract ScanflowReader BindSliderView(Slider v);

	private static Delegate GetCaptureBatchInventoryHandler()
	{
		if ((object)cb_captureBatchInventory_CaptureBatchInventory_V == null)
		{
			cb_captureBatchInventory_CaptureBatchInventory_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_CaptureBatchInventory));
		}
		return cb_captureBatchInventory_CaptureBatchInventory_V;
	}

	private static void n_CaptureBatchInventory(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureBatchInventory();
	}

	[Register("captureBatchInventory", "()V", "GetCaptureBatchInventoryHandler")]
	public abstract void CaptureBatchInventory();

	private static Delegate GetCaptureToScanHandler()
	{
		if ((object)cb_captureToScan_CaptureToScan_V == null)
		{
			cb_captureToScan_CaptureToScan_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_CaptureToScan));
		}
		return cb_captureToScan_CaptureToScan_V;
	}

	private static void n_CaptureToScan(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureToScan();
	}

	[Register("captureToScan", "()V", "GetCaptureToScanHandler")]
	public abstract void CaptureToScan();

	private static Delegate GetDoValidateLicenseHandler()
	{
		if ((object)cb_doValidateLicense_DoValidateLicense_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_doValidateLicense_DoValidateLicense_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DoValidateLicense));
		}
		return cb_doValidateLicense_DoValidateLicense_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_DoValidateLicense(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DoValidateLicense());
	}

	[Register("doValidateLicense", "()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetDoValidateLicenseHandler")]
	public abstract ScanflowReader DoValidateLicense();

	private static Delegate GetDoValidateLicenseWithRetryHandler()
	{
		if ((object)cb_doValidateLicenseWithRetry_DoValidateLicenseWithRetry_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_doValidateLicenseWithRetry_DoValidateLicenseWithRetry_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DoValidateLicenseWithRetry));
		}
		return cb_doValidateLicenseWithRetry_DoValidateLicenseWithRetry_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_DoValidateLicenseWithRetry(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DoValidateLicenseWithRetry());
	}

	[Register("doValidateLicenseWithRetry", "()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetDoValidateLicenseWithRetryHandler")]
	public abstract ScanflowReader DoValidateLicenseWithRetry();

	private static Delegate GetEnableSplitView_ZHandler()
	{
		if ((object)cb_enableSplitView_EnableSplitView_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_enableSplitView_EnableSplitView_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableSplitView_Z));
		}
		return cb_enableSplitView_EnableSplitView_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_EnableSplitView_Z(nint jnienv, nint native__this, bool enableSplitView)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableSplitView(enableSplitView));
	}

	[Register("enableSplitView", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetEnableSplitView_ZHandler")]
	public abstract ScanflowReader EnableSplitView(bool enableSplitView);

	private static Delegate GetEnableTouchZoom_ZHandler()
	{
		if ((object)cb_enableTouchZoom_EnableTouchZoom_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_enableTouchZoom_EnableTouchZoom_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableTouchZoom_Z));
		}
		return cb_enableTouchZoom_EnableTouchZoom_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_EnableTouchZoom_Z(nint jnienv, nint native__this, bool enableTouchZoom)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableTouchZoom(enableTouchZoom));
	}

	[Register("enableTouchZoom", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetEnableTouchZoom_ZHandler")]
	public abstract ScanflowReader EnableTouchZoom(bool enableTouchZoom);

	private static Delegate GetPerformOneTouchClickHandler()
	{
		if ((object)cb_performOneTouchClick_PerformOneTouchClick_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_performOneTouchClick_PerformOneTouchClick_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_PerformOneTouchClick));
		}
		return cb_performOneTouchClick_PerformOneTouchClick_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_PerformOneTouchClick(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PerformOneTouchClick());
	}

	[Register("performOneTouchClick", "()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetPerformOneTouchClickHandler")]
	public abstract ScanflowReader PerformOneTouchClick();

	private static Delegate GetResetOneToManyCodesHandler()
	{
		if ((object)cb_resetOneToManyCodes_ResetOneToManyCodes_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_resetOneToManyCodes_ResetOneToManyCodes_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ResetOneToManyCodes));
		}
		return cb_resetOneToManyCodes_ResetOneToManyCodes_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_ResetOneToManyCodes(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetOneToManyCodes());
	}

	[Register("resetOneToManyCodes", "()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetResetOneToManyCodesHandler")]
	public abstract ScanflowReader ResetOneToManyCodes();

	private static Delegate GetSetAutoExposure_ZHandler()
	{
		if ((object)cb_setAutoExposure_SetAutoExposure_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setAutoExposure_SetAutoExposure_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetAutoExposure_Z));
		}
		return cb_setAutoExposure_SetAutoExposure_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetAutoExposure_Z(nint jnienv, nint native__this, bool autoExposure)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAutoExposure(autoExposure));
	}

	[Register("setAutoExposure", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetAutoExposure_ZHandler")]
	public abstract ScanflowReader SetAutoExposure(bool autoExposure);

	private static Delegate GetSetAutoFlashlight_ZHandler()
	{
		if ((object)cb_setAutoFlashlight_SetAutoFlashlight_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setAutoFlashlight_SetAutoFlashlight_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetAutoFlashlight_Z));
		}
		return cb_setAutoFlashlight_SetAutoFlashlight_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetAutoFlashlight_Z(nint jnienv, nint native__this, bool autoFlash)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAutoFlashlight(autoFlash));
	}

	[Register("setAutoFlashlight", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetAutoFlashlight_ZHandler")]
	public abstract ScanflowReader SetAutoFlashlight(bool autoFlash);

	private static Delegate GetSetAutoZoom_ZHandler()
	{
		if ((object)cb_setAutoZoom_SetAutoZoom_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setAutoZoom_SetAutoZoom_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetAutoZoom_Z));
		}
		return cb_setAutoZoom_SetAutoZoom_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetAutoZoom_Z(nint jnienv, nint native__this, bool autoZoom)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAutoZoom(autoZoom));
	}

	[Register("setAutoZoom", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetAutoZoom_ZHandler")]
	public abstract ScanflowReader SetAutoZoom(bool autoZoom);

	private static Delegate GetSetBeepSoundResource_IHandler()
	{
		if ((object)cb_setBeepSoundResource_SetBeepSoundResource_I_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setBeepSoundResource_SetBeepSoundResource_I_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetBeepSoundResource_I));
		}
		return cb_setBeepSoundResource_SetBeepSoundResource_I_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetBeepSoundResource_I(nint jnienv, nint native__this, int beepSoundResource)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBeepSoundResource(beepSoundResource));
	}

	[Register("setBeepSoundResource", "(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetBeepSoundResource_IHandler")]
	public abstract ScanflowReader SetBeepSoundResource(int beepSoundResource);

	private static Delegate GetSetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig_Handler()
	{
		if ((object)cb_setCameraResolution_SetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setCameraResolution_SetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig_));
		}
		return cb_setCameraResolution_SetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig_(nint jnienv, nint native__this, nint native_size)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraResolutionConfig cameraResolution = Java.Lang.Object.GetObject<CameraResolutionConfig>(native_size, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetCameraResolution(cameraResolution));
	}

	[Register("setCameraResolution", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig_Handler")]
	public abstract ScanflowReader SetCameraResolution(CameraResolutionConfig size);

	private static Delegate GetSetEchanceTextCount_IHandler()
	{
		if ((object)cb_setEchanceTextCount_SetEchanceTextCount_I_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setEchanceTextCount_SetEchanceTextCount_I_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetEchanceTextCount_I));
		}
		return cb_setEchanceTextCount_SetEchanceTextCount_I_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetEchanceTextCount_I(nint jnienv, nint native__this, int echanceTextCount)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEchanceTextCount(echanceTextCount));
	}

	[Register("setEchanceTextCount", "(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEchanceTextCount_IHandler")]
	public abstract ScanflowReader SetEchanceTextCount(int echanceTextCount);

	private static Delegate GetSetEnableDataTracking_ZHandler()
	{
		if ((object)cb_setEnableDataTracking_SetEnableDataTracking_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setEnableDataTracking_SetEnableDataTracking_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetEnableDataTracking_Z));
		}
		return cb_setEnableDataTracking_SetEnableDataTracking_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetEnableDataTracking_Z(nint jnienv, nint native__this, bool isDataTracking)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEnableDataTracking(isDataTracking));
	}

	[Register("setEnableDataTracking", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnableDataTracking_ZHandler")]
	public abstract ScanflowReader SetEnableDataTracking(bool isDataTracking);

	private static Delegate GetSetEnableLocationTracking_ZHandler()
	{
		if ((object)cb_setEnableLocationTracking_SetEnableLocationTracking_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setEnableLocationTracking_SetEnableLocationTracking_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetEnableLocationTracking_Z));
		}
		return cb_setEnableLocationTracking_SetEnableLocationTracking_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetEnableLocationTracking_Z(nint jnienv, nint native__this, bool enableLocationTracking)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEnableLocationTracking(enableLocationTracking));
	}

	[Register("setEnableLocationTracking", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnableLocationTracking_ZHandler")]
	public abstract ScanflowReader SetEnableLocationTracking(bool enableLocationTracking);

	private static Delegate GetSetEnableTireAngleDetection_ZHandler()
	{
		if ((object)cb_setEnableTireAngleDetection_SetEnableTireAngleDetection_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setEnableTireAngleDetection_SetEnableTireAngleDetection_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetEnableTireAngleDetection_Z));
		}
		return cb_setEnableTireAngleDetection_SetEnableTireAngleDetection_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetEnableTireAngleDetection_Z(nint jnienv, nint native__this, bool enableTireAngleDetection)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEnableTireAngleDetection(enableTireAngleDetection));
	}

	[Register("setEnableTireAngleDetection", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnableTireAngleDetection_ZHandler")]
	public abstract ScanflowReader SetEnableTireAngleDetection(bool enableTireAngleDetection);

	private static Delegate GetSetEnableTirePreProcessing_ZHandler()
	{
		if ((object)cb_setEnableTirePreProcessing_SetEnableTirePreProcessing_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setEnableTirePreProcessing_SetEnableTirePreProcessing_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetEnableTirePreProcessing_Z));
		}
		return cb_setEnableTirePreProcessing_SetEnableTirePreProcessing_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetEnableTirePreProcessing_Z(nint jnienv, nint native__this, bool enableTirePreProcessing)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEnableTirePreProcessing(enableTirePreProcessing));
	}

	[Register("setEnableTirePreProcessing", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnableTirePreProcessing_ZHandler")]
	public abstract ScanflowReader SetEnableTirePreProcessing(bool enableTirePreProcessing);

	private static Delegate GetSetEnhanceTextResult_ZHandler()
	{
		if ((object)cb_setEnhanceTextResult_SetEnhanceTextResult_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setEnhanceTextResult_SetEnhanceTextResult_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetEnhanceTextResult_Z));
		}
		return cb_setEnhanceTextResult_SetEnhanceTextResult_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetEnhanceTextResult_Z(nint jnienv, nint native__this, bool isEnhanceTextResult)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEnhanceTextResult(isEnhanceTextResult));
	}

	[Register("setEnhanceTextResult", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnhanceTextResult_ZHandler")]
	public abstract ScanflowReader SetEnhanceTextResult(bool isEnhanceTextResult);

	private static Delegate GetSetIsBatchScanning_ZHandler()
	{
		if ((object)cb_setIsBatchScanning_SetIsBatchScanning_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setIsBatchScanning_SetIsBatchScanning_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetIsBatchScanning_Z));
		}
		return cb_setIsBatchScanning_SetIsBatchScanning_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetIsBatchScanning_Z(nint jnienv, nint native__this, bool isBatchScanning)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIsBatchScanning(isBatchScanning));
	}

	[Register("setIsBatchScanning", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetIsBatchScanning_ZHandler")]
	public abstract ScanflowReader SetIsBatchScanning(bool isBatchScanning);

	private static Delegate GetSetIsContinuousScan_ZHandler()
	{
		if ((object)cb_setIsContinuousScan_SetIsContinuousScan_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setIsContinuousScan_SetIsContinuousScan_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetIsContinuousScan_Z));
		}
		return cb_setIsContinuousScan_SetIsContinuousScan_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetIsContinuousScan_Z(nint jnienv, nint native__this, bool isContinuousScan)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIsContinuousScan(isContinuousScan));
	}

	[Register("setIsContinuousScan", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetIsContinuousScan_ZHandler")]
	public abstract ScanflowReader SetIsContinuousScan(bool isContinuousScan);

	private static Delegate GetSetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback_Handler()
	{
		if ((object)cb_setOnBarcodeScanResultCallback_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnBarcodeScanResultCallback_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback_));
		}
		return cb_setOnBarcodeScanResultCallback_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnBarcodeScanResultCallback onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnBarcodeScanResultCallback(onBarcodeScanResultCallback));
	}

	[Register("setOnBarcodeScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback_Handler")]
	public abstract ScanflowReader SetOnBarcodeScanResultCallback(IOnBarcodeScanResultCallback callback);

	private static Delegate GetSetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback_Handler()
	{
		if ((object)cb_setOnCameraResultCallback_SetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnCameraResultCallback_SetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback_));
		}
		return cb_setOnCameraResultCallback_SetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnCameraResultCallback onCameraResultCallback = Java.Lang.Object.GetObject<IOnCameraResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnCameraResultCallback(onCameraResultCallback));
	}

	[Register("setOnCameraResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback_Handler")]
	public abstract ScanflowReader SetOnCameraResultCallback(IOnCameraResultCallback callback);

	private static Delegate GetSetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback_Handler()
	{
		if ((object)cb_setOnIDCardScanResultCallback_SetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnIDCardScanResultCallback_SetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback_));
		}
		return cb_setOnIDCardScanResultCallback_SetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnIDCardScanResultCallback onIDCardScanResultCallback = Java.Lang.Object.GetObject<IOnIDCardScanResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnIDCardScanResultCallback(onIDCardScanResultCallback));
	}

	[Register("setOnIDCardScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback_Handler")]
	public abstract ScanflowReader SetOnIDCardScanResultCallback(IOnIDCardScanResultCallback callback);

	private static Delegate GetSetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback_Handler()
	{
		if ((object)cb_setOnLicenseValidationCallback_SetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnLicenseValidationCallback_SetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback_));
		}
		return cb_setOnLicenseValidationCallback_SetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnLicenseValidationCallback onLicenseValidationCallback = Java.Lang.Object.GetObject<IOnLicenseValidationCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnLicenseValidationCallback(onLicenseValidationCallback));
	}

	[Register("setOnLicenseValidationCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback_Handler")]
	public abstract ScanflowReader SetOnLicenseValidationCallback(IOnLicenseValidationCallback callback);

	private static Delegate GetSetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback_Handler()
	{
		if ((object)cb_setOnOneTouchCallback_SetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnOneTouchCallback_SetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback_));
		}
		return cb_setOnOneTouchCallback_SetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback_(nint jnienv, nint native__this, nint native_onOneTouchCallback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnOneTouchCallback onOneTouchCallback = Java.Lang.Object.GetObject<IOnOneTouchCallback>(native_onOneTouchCallback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnOneTouchCallback(onOneTouchCallback));
	}

	[Register("setOnOneTouchCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback_Handler")]
	public abstract ScanflowReader SetOnOneTouchCallback(IOnOneTouchCallback onOneTouchCallback);

	private static Delegate GetSetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback_Handler()
	{
		if ((object)cb_setOnTextComponentScanResultCallback_SetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnTextComponentScanResultCallback_SetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback_));
		}
		return cb_setOnTextComponentScanResultCallback_SetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnTextComponentScanResultCallback onTextComponentScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentScanResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnTextComponentScanResultCallback(onTextComponentScanResultCallback));
	}

	[Register("setOnTextComponentScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback_Handler")]
	public abstract ScanflowReader SetOnTextComponentScanResultCallback(IOnTextComponentScanResultCallback callback);

	private static Delegate GetSetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback_Handler()
	{
		if ((object)cb_setOnTextComponentVinPlateScanResultCallback_SetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnTextComponentVinPlateScanResultCallback_SetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback_));
		}
		return cb_setOnTextComponentVinPlateScanResultCallback_SetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnTextComponentVinPlateScanResultCallback onTextComponentVinPlateScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentVinPlateScanResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnTextComponentVinPlateScanResultCallback(onTextComponentVinPlateScanResultCallback));
	}

	[Register("setOnTextComponentVinPlateScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback_Handler")]
	public abstract ScanflowReader SetOnTextComponentVinPlateScanResultCallback(IOnTextComponentVinPlateScanResultCallback callback);

	private static Delegate GetSetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback_Handler()
	{
		if ((object)cb_setOnTextComponentVinStickerScanResultCallback_SetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnTextComponentVinStickerScanResultCallback_SetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback_));
		}
		return cb_setOnTextComponentVinStickerScanResultCallback_SetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnTextComponentVinStickerScanResultCallback onTextComponentVinStickerScanResultCallback = Java.Lang.Object.GetObject<IOnTextComponentVinStickerScanResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnTextComponentVinStickerScanResultCallback(onTextComponentVinStickerScanResultCallback));
	}

	[Register("setOnTextComponentVinStickerScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback_Handler")]
	public abstract ScanflowReader SetOnTextComponentVinStickerScanResultCallback(IOnTextComponentVinStickerScanResultCallback callback);

	private static Delegate GetSetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback_Handler()
	{
		if ((object)cb_setOnTextScanResultCallback_SetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnTextScanResultCallback_SetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback_));
		}
		return cb_setOnTextScanResultCallback_SetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnTextScanResultCallback onTextScanResultCallback = Java.Lang.Object.GetObject<IOnTextScanResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnTextScanResultCallback(onTextScanResultCallback));
	}

	[Register("setOnTextScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback_Handler")]
	public abstract ScanflowReader SetOnTextScanResultCallback(IOnTextScanResultCallback callback);

	private static Delegate GetSetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback_Handler()
	{
		if ((object)cb_setOnWebServiceScanResultCallback_SetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOnWebServiceScanResultCallback_SetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback_));
		}
		return cb_setOnWebServiceScanResultCallback_SetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnWebServiceScanResultCallback onWebServiceScanResultCallback = Java.Lang.Object.GetObject<IOnWebServiceScanResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetOnWebServiceScanResultCallback(onWebServiceScanResultCallback));
	}

	[Register("setOnWebServiceScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback_Handler")]
	public abstract ScanflowReader SetOnWebServiceScanResultCallback(IOnWebServiceScanResultCallback callback);

	private static Delegate GetSetOneToManyCodes_ZHandler()
	{
		if ((object)cb_setOneToManyCodes_SetOneToManyCodes_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOneToManyCodes_SetOneToManyCodes_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetOneToManyCodes_Z));
		}
		return cb_setOneToManyCodes_SetOneToManyCodes_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOneToManyCodes_Z(nint jnienv, nint native__this, bool enableOnetoManyCodes)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOneToManyCodes(enableOnetoManyCodes));
	}

	[Register("setOneToManyCodes", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOneToManyCodes_ZHandler")]
	public abstract ScanflowReader SetOneToManyCodes(bool enableOnetoManyCodes);

	private static Delegate GetSetOneToManyCodesKeepCurrent_ZHandler()
	{
		if ((object)cb_setOneToManyCodesKeepCurrent_SetOneToManyCodesKeepCurrent_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setOneToManyCodesKeepCurrent_SetOneToManyCodesKeepCurrent_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetOneToManyCodesKeepCurrent_Z));
		}
		return cb_setOneToManyCodesKeepCurrent_SetOneToManyCodesKeepCurrent_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetOneToManyCodesKeepCurrent_Z(nint jnienv, nint native__this, bool oneOfManyKeepCurrent)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOneToManyCodesKeepCurrent(oneOfManyKeepCurrent));
	}

	[Register("setOneToManyCodesKeepCurrent", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOneToManyCodesKeepCurrent_ZHandler")]
	public abstract ScanflowReader SetOneToManyCodesKeepCurrent(bool oneOfManyKeepCurrent);

	private static Delegate GetSetPlayBeep_ZHandler()
	{
		if ((object)cb_setPlayBeep_SetPlayBeep_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setPlayBeep_SetPlayBeep_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetPlayBeep_Z));
		}
		return cb_setPlayBeep_SetPlayBeep_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetPlayBeep_Z(nint jnienv, nint native__this, bool playBeep)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPlayBeep(playBeep));
	}

	[Register("setPlayBeep", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetPlayBeep_ZHandler")]
	public abstract ScanflowReader SetPlayBeep(bool playBeep);

	private static Delegate GetSetQrBarcodeDetection_ZHandler()
	{
		if ((object)cb_setQrBarcodeDetection_SetQrBarcodeDetection_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setQrBarcodeDetection_SetQrBarcodeDetection_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetQrBarcodeDetection_Z));
		}
		return cb_setQrBarcodeDetection_SetQrBarcodeDetection_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetQrBarcodeDetection_Z(nint jnienv, nint native__this, bool isQrBarcodeDetection)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetQrBarcodeDetection(isQrBarcodeDetection));
	}

	[Register("setQrBarcodeDetection", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetQrBarcodeDetection_ZHandler")]
	public abstract ScanflowReader SetQrBarcodeDetection(bool isQrBarcodeDetection);

	private static Delegate GetSetSwitchCategory_Ljava_lang_String_Handler()
	{
		if ((object)cb_setSwitchCategory_SetSwitchCategory_Ljava_lang_String__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setSwitchCategory_SetSwitchCategory_Ljava_lang_String__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSwitchCategory_Ljava_lang_String_));
		}
		return cb_setSwitchCategory_SetSwitchCategory_Ljava_lang_String__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetSwitchCategory_Ljava_lang_String_(nint jnienv, nint native__this, nint native_switchCategory)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string switchCategory = JNIEnv.GetString(native_switchCategory, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetSwitchCategory(switchCategory));
	}

	[Register("setSwitchCategory", "(Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetSwitchCategory_Ljava_lang_String_Handler")]
	public abstract ScanflowReader SetSwitchCategory(string switchCategory);

	private static Delegate GetSetVibrate_ZHandler()
	{
		if ((object)cb_setVibrate_SetVibrate_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setVibrate_SetVibrate_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetVibrate_Z));
		}
		return cb_setVibrate_SetVibrate_Z_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetVibrate_Z(nint jnienv, nint native__this, bool vibrate)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVibrate(vibrate));
	}

	[Register("setVibrate", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetVibrate_ZHandler")]
	public abstract ScanflowReader SetVibrate(bool vibrate);

	private static Delegate GetSetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig_Handler()
	{
		if ((object)cb_setVinNumberColor_SetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_setVinNumberColor_SetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig__Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig_));
		}
		return cb_setVinNumberColor_SetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig__Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_SetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig_(nint jnienv, nint native__this, nint native_selectedVinNumberColorConfig)
	{
		ScanflowReader? scanflowReader = Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		VinNumberColorConfig vinNumberColor = Java.Lang.Object.GetObject<VinNumberColorConfig>(native_selectedVinNumberColorConfig, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(scanflowReader.SetVinNumberColor(vinNumberColor));
	}

	[Register("setVinNumberColor", "(Lcom/scanflow/datacapture/config/VinNumberColorConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig_Handler")]
	public abstract ScanflowReader SetVinNumberColor(VinNumberColorConfig selectedVinNumberColorConfig);

	private static Delegate GetUpdateConfidenceValue_FHandler()
	{
		if ((object)cb_updateConfidenceValue_UpdateConfidenceValue_F_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ == null)
		{
			cb_updateConfidenceValue_UpdateConfidenceValue_F_Lcom_scanflow_datacapture_core_camera_ScanflowReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_L(n_UpdateConfidenceValue_F));
		}
		return cb_updateConfidenceValue_UpdateConfidenceValue_F_Lcom_scanflow_datacapture_core_camera_ScanflowReader_;
	}

	private static nint n_UpdateConfidenceValue_F(nint jnienv, nint native__this, float confidence)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateConfidenceValue(confidence));
	}

	[Register("updateConfidenceValue", "(F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetUpdateConfidenceValue_FHandler")]
	public abstract ScanflowReader UpdateConfidenceValue(float confidence);

	private static Delegate GetReleaseHandler()
	{
		if ((object)cb_release_Release_V == null)
		{
			cb_release_Release_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Release));
		}
		return cb_release_Release_V;
	}

	private static void n_Release(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Release();
	}

	[Register("release", "()V", "GetReleaseHandler")]
	public abstract void Release();

	private static Delegate GetStartCameraHandler()
	{
		if ((object)cb_startCamera_StartCamera_V == null)
		{
			cb_startCamera_StartCamera_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StartCamera));
		}
		return cb_startCamera_StartCamera_V;
	}

	private static void n_StartCamera(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartCamera();
	}

	[Register("startCamera", "()V", "GetStartCameraHandler")]
	public abstract void StartCamera();

	private static Delegate GetStopCameraHandler()
	{
		if ((object)cb_stopCamera_StopCamera_V == null)
		{
			cb_stopCamera_StopCamera_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StopCamera));
		}
		return cb_stopCamera_StopCamera_V;
	}

	private static void n_StopCamera(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopCamera();
	}

	[Register("stopCamera", "()V", "GetStopCameraHandler")]
	public abstract void StopCamera();

	private static Delegate GetGetCameraHandler()
	{
		if ((object)cb_getCamera_GetCamera_Landroidx_camera_core_Camera_ == null)
		{
			cb_getCamera_GetCamera_Landroidx_camera_core_Camera_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCamera));
		}
		return cb_getCamera_GetCamera_Landroidx_camera_core_Camera_;
	}

	private static nint n_GetCamera(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Camera);
	}

	private static Delegate GetEnableTorch_ZHandler()
	{
		if ((object)cb_enableTorch_EnableTorch_Z_V == null)
		{
			cb_enableTorch_EnableTorch_Z_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_EnableTorch_Z));
		}
		return cb_enableTorch_EnableTorch_Z_V;
	}

	private static void n_EnableTorch_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableTorch(p0);
	}

	[Register("enableTorch", "(Z)V", "GetEnableTorch_ZHandler")]
	public abstract void EnableTorch(bool p0);

	private static Delegate GetLineZoomInHandler()
	{
		if ((object)cb_lineZoomIn_LineZoomIn_V == null)
		{
			cb_lineZoomIn_LineZoomIn_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_LineZoomIn));
		}
		return cb_lineZoomIn_LineZoomIn_V;
	}

	private static void n_LineZoomIn(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineZoomIn();
	}

	[Register("lineZoomIn", "()V", "GetLineZoomInHandler")]
	public abstract void LineZoomIn();

	private static Delegate GetLineZoomOutHandler()
	{
		if ((object)cb_lineZoomOut_LineZoomOut_V == null)
		{
			cb_lineZoomOut_LineZoomOut_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_LineZoomOut));
		}
		return cb_lineZoomOut_LineZoomOut_V;
	}

	private static void n_LineZoomOut(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineZoomOut();
	}

	[Register("lineZoomOut", "()V", "GetLineZoomOutHandler")]
	public abstract void LineZoomOut();

	private static Delegate GetLineZoomTo_FHandler()
	{
		if ((object)cb_lineZoomTo_LineZoomTo_F_V == null)
		{
			cb_lineZoomTo_LineZoomTo_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_LineZoomTo_F));
		}
		return cb_lineZoomTo_LineZoomTo_F_V;
	}

	private static void n_LineZoomTo_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineZoomTo(p0);
	}

	[Register("lineZoomTo", "(F)V", "GetLineZoomTo_FHandler")]
	public abstract void LineZoomTo(float p0);

	private static Delegate GetZoomInHandler()
	{
		if ((object)cb_zoomIn_ZoomIn_V == null)
		{
			cb_zoomIn_ZoomIn_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ZoomIn));
		}
		return cb_zoomIn_ZoomIn_V;
	}

	private static void n_ZoomIn(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZoomIn();
	}

	[Register("zoomIn", "()V", "GetZoomInHandler")]
	public abstract void ZoomIn();

	private static Delegate GetZoomOutHandler()
	{
		if ((object)cb_zoomOut_ZoomOut_V == null)
		{
			cb_zoomOut_ZoomOut_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ZoomOut));
		}
		return cb_zoomOut_ZoomOut_V;
	}

	private static void n_ZoomOut(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZoomOut();
	}

	[Register("zoomOut", "()V", "GetZoomOutHandler")]
	public abstract void ZoomOut();

	private static Delegate GetZoomTo_FHandler()
	{
		if ((object)cb_zoomTo_ZoomTo_F_V == null)
		{
			cb_zoomTo_ZoomTo_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_ZoomTo_F));
		}
		return cb_zoomTo_ZoomTo_F_V;
	}

	private static void n_ZoomTo_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZoomTo(p0);
	}

	[Register("zoomTo", "(F)V", "GetZoomTo_FHandler")]
	public abstract void ZoomTo(float p0);

	private static Delegate GetHasFlashUnitHandler()
	{
		if ((object)cb_hasFlashUnit_HasFlashUnit_Z == null)
		{
			cb_hasFlashUnit_HasFlashUnit_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasFlashUnit));
		}
		return cb_hasFlashUnit_HasFlashUnit_Z;
	}

	private static bool n_HasFlashUnit(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFlashUnit;
	}

	private static Delegate GetIsTorchEnabledHandler()
	{
		if ((object)cb_isTorchEnabled_IsTorchEnabled_Z == null)
		{
			cb_isTorchEnabled_IsTorchEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsTorchEnabled));
		}
		return cb_isTorchEnabled_IsTorchEnabled_Z;
	}

	private static bool n_IsTorchEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ScanflowReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTorchEnabled;
	}
}
