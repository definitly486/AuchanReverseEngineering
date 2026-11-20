using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/Image", DoNotGenerateAcw = true)]
public class Image : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/Image$ImageSize", DoNotGenerateAcw = true)]
	public class ImageSize : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/Image$ImageSize", typeof(ImageSize));

		private static Delegate? cb_getHeight_GetHeight_Ljava_lang_Integer_;

		private static Delegate? cb_getSize_GetSize_Ljava_lang_String_;

		private static Delegate? cb_getWidth_GetWidth_Ljava_lang_Integer_;

		private static Delegate? cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;

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

		public unsafe virtual Integer? Height
		{
			[Register("getHeight", "()Ljava/lang/Integer;", "GetGetHeightHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHeight.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Size
		{
			[Register("getSize", "()Ljava/lang/String;", "GetGetSizeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSize.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Integer? Width
		{
			[Register("getWidth", "()Ljava/lang/Integer;", "GetGetWidthHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWidth.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ImageSize(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ImageSize()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Integer;Ljava/lang/Integer;)V", "")]
		public unsafe ImageSize(string size, Integer? width, Integer? height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(size);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(width?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(height?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Integer;Ljava/lang/Integer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Integer;Ljava/lang/Integer;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(width);
				GC.KeepAlive(height);
			}
		}

		private static Delegate GetGetHeightHandler()
		{
			if ((object)cb_getHeight_GetHeight_Ljava_lang_Integer_ == null)
			{
				cb_getHeight_GetHeight_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHeight));
			}
			return cb_getHeight_GetHeight_Ljava_lang_Integer_;
		}

		private static nint n_GetHeight(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ImageSize>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height);
		}

		private static Delegate GetGetSizeHandler()
		{
			if ((object)cb_getSize_GetSize_Ljava_lang_String_ == null)
			{
				cb_getSize_GetSize_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSize));
			}
			return cb_getSize_GetSize_Ljava_lang_String_;
		}

		private static nint n_GetSize(nint jnienv, nint native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ImageSize>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size);
		}

		private static Delegate GetGetWidthHandler()
		{
			if ((object)cb_getWidth_GetWidth_Ljava_lang_Integer_ == null)
			{
				cb_getWidth_GetWidth_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetWidth));
			}
			return cb_getWidth_GetWidth_Ljava_lang_Integer_;
		}

		private static nint n_GetWidth(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ImageSize>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width);
		}

		private static Delegate GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler()
		{
			if ((object)cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V == null)
			{
				cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Serialize_Lcom_yandex_runtime_bindings_Archive_));
			}
			return cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;
		}

		private static void n_Serialize_Lcom_yandex_runtime_bindings_Archive_(nint jnienv, nint native__this, nint native_archive)
		{
			ImageSize? imageSize = Java.Lang.Object.GetObject<ImageSize>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
			imageSize.Serialize(archive);
		}

		[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler")]
		public unsafe virtual void Serialize(IArchive? archive)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(archive);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/Image", typeof(Image));

	private static Delegate? cb_getSizes_GetSizes_Ljava_util_List_;

	private static Delegate? cb_getTags_GetTags_Ljava_util_List_;

	private static Delegate? cb_getUrlTemplate_GetUrlTemplate_Ljava_lang_String_;

	private static Delegate? cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;

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

	public unsafe static string? NativeName
	{
		[Register("getNativeName", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getNativeName.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IList<ImageSize> Sizes
	{
		[Register("getSizes", "()Ljava/util/List;", "GetGetSizesHandler")]
		get
		{
			return JavaList<ImageSize>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSizes.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IList<string> Tags
	{
		[Register("getTags", "()Ljava/util/List;", "GetGetTagsHandler")]
		get
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getTags.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string UrlTemplate
	{
		[Register("getUrlTemplate", "()Ljava/lang/String;", "GetGetUrlTemplateHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getUrlTemplate.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Image(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Image()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;Ljava/util/List;)V", "")]
	public unsafe Image(string urlTemplate, IList<ImageSize> sizes, IList<string> tags)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(urlTemplate);
		nint num2 = JavaList<ImageSize>.ToLocalJniHandle(sizes);
		nint num3 = JavaList<string>.ToLocalJniHandle(tags);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(sizes);
			GC.KeepAlive(tags);
		}
	}

	private static Delegate GetGetSizesHandler()
	{
		if ((object)cb_getSizes_GetSizes_Ljava_util_List_ == null)
		{
			cb_getSizes_GetSizes_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSizes));
		}
		return cb_getSizes_GetSizes_Ljava_util_List_;
	}

	private static nint n_GetSizes(nint jnienv, nint native__this)
	{
		return JavaList<ImageSize>.ToLocalJniHandle(Java.Lang.Object.GetObject<Image>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Sizes);
	}

	private static Delegate GetGetTagsHandler()
	{
		if ((object)cb_getTags_GetTags_Ljava_util_List_ == null)
		{
			cb_getTags_GetTags_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTags));
		}
		return cb_getTags_GetTags_Ljava_util_List_;
	}

	private static nint n_GetTags(nint jnienv, nint native__this)
	{
		return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<Image>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Tags);
	}

	private static Delegate GetGetUrlTemplateHandler()
	{
		if ((object)cb_getUrlTemplate_GetUrlTemplate_Ljava_lang_String_ == null)
		{
			cb_getUrlTemplate_GetUrlTemplate_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUrlTemplate));
		}
		return cb_getUrlTemplate_GetUrlTemplate_Ljava_lang_String_;
	}

	private static nint n_GetUrlTemplate(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<Image>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UrlTemplate);
	}

	private static Delegate GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler()
	{
		if ((object)cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V == null)
		{
			cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Serialize_Lcom_yandex_runtime_bindings_Archive_));
		}
		return cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;
	}

	private static void n_Serialize_Lcom_yandex_runtime_bindings_Archive_(nint jnienv, nint native__this, nint native_archive)
	{
		Image? image = Java.Lang.Object.GetObject<Image>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		image.Serialize(archive);
	}

	[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler")]
	public unsafe virtual void Serialize(IArchive? archive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(archive);
		}
	}
}
