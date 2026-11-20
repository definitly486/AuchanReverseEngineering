using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/Attribution", DoNotGenerateAcw = true)]
public class Attribution : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/Attribution$Author", DoNotGenerateAcw = true)]
	public class Author : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/Attribution$Author", typeof(Author));

		private static Delegate? cb_getEmail_GetEmail_Ljava_lang_String_;

		private static Delegate? cb_getName_GetName_Ljava_lang_String_;

		private static Delegate? cb_getUri_GetUri_Ljava_lang_String_;

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

		public unsafe virtual string? Email
		{
			[Register("getEmail", "()Ljava/lang/String;", "GetGetEmailHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEmail.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string? Uri
		{
			[Register("getUri", "()Ljava/lang/String;", "GetGetUriHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getUri.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Author(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Author()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe Author(string name, string? uri, string? email)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(name);
			nint num2 = JNIEnv.NewString(uri);
			nint num3 = JNIEnv.NewString(email);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue(num3);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				JNIEnv.DeleteLocalRef(num3);
			}
		}

		private static Delegate GetGetEmailHandler()
		{
			if ((object)cb_getEmail_GetEmail_Ljava_lang_String_ == null)
			{
				cb_getEmail_GetEmail_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEmail));
			}
			return cb_getEmail_GetEmail_Ljava_lang_String_;
		}

		private static nint n_GetEmail(nint jnienv, nint native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Author>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Email);
		}

		private static Delegate GetGetNameHandler()
		{
			if ((object)cb_getName_GetName_Ljava_lang_String_ == null)
			{
				cb_getName_GetName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
			}
			return cb_getName_GetName_Ljava_lang_String_;
		}

		private static nint n_GetName(nint jnienv, nint native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Author>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
		}

		private static Delegate GetGetUriHandler()
		{
			if ((object)cb_getUri_GetUri_Ljava_lang_String_ == null)
			{
				cb_getUri_GetUri_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUri));
			}
			return cb_getUri_GetUri_Ljava_lang_String_;
		}

		private static nint n_GetUri(nint jnienv, nint native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Author>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Uri);
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
			Author? author = Java.Lang.Object.GetObject<Author>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
			author.Serialize(archive);
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

	[Register("com/yandex/mapkit/Attribution$Link", DoNotGenerateAcw = true)]
	public class Link : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/Attribution$Link", typeof(Link));

		private static Delegate? cb_getHref_GetHref_Ljava_lang_String_;

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

		public unsafe virtual string Href
		{
			[Register("getHref", "()Ljava/lang/String;", "GetGetHrefHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getHref.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Link(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Link()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe Link(string href)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(href);
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

		private static Delegate GetGetHrefHandler()
		{
			if ((object)cb_getHref_GetHref_Ljava_lang_String_ == null)
			{
				cb_getHref_GetHref_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHref));
			}
			return cb_getHref_GetHref_Ljava_lang_String_;
		}

		private static nint n_GetHref(nint jnienv, nint native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Link>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Href);
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
			Link? link = Java.Lang.Object.GetObject<Link>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
			link.Serialize(archive);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/Attribution", typeof(Attribution));

	private static Delegate? cb_getAvatarImage_GetAvatarImage_Lcom_yandex_mapkit_Image_;

	private static Delegate? cb_getAuthor_GetAuthor_Lcom_yandex_mapkit_Attribution_Author_;

	private static Delegate? cb_getLink_GetLink_Lcom_yandex_mapkit_Attribution_Link_;

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

	public unsafe virtual Image? AvatarImage
	{
		[Register("getAvatarImage", "()Lcom/yandex/mapkit/Image;", "GetGetAvatarImageHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Image>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAvatarImage.()Lcom/yandex/mapkit/Image;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static string? NativeName
	{
		[Register("getNativeName", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getNativeName.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Attribution(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Attribution()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/Attribution$Author;Lcom/yandex/mapkit/Attribution$Link;Lcom/yandex/mapkit/Image;)V", "")]
	public unsafe Attribution(Author? author, Link? link, Image? avatarImage)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(author?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(link?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(avatarImage?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/Attribution$Author;Lcom/yandex/mapkit/Attribution$Link;Lcom/yandex/mapkit/Image;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/Attribution$Author;Lcom/yandex/mapkit/Attribution$Link;Lcom/yandex/mapkit/Image;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(author);
			GC.KeepAlive(link);
			GC.KeepAlive(avatarImage);
		}
	}

	private static Delegate GetGetAvatarImageHandler()
	{
		if ((object)cb_getAvatarImage_GetAvatarImage_Lcom_yandex_mapkit_Image_ == null)
		{
			cb_getAvatarImage_GetAvatarImage_Lcom_yandex_mapkit_Image_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAvatarImage));
		}
		return cb_getAvatarImage_GetAvatarImage_Lcom_yandex_mapkit_Image_;
	}

	private static nint n_GetAvatarImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Attribution>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AvatarImage);
	}

	private static Delegate GetGetAuthorHandler()
	{
		if ((object)cb_getAuthor_GetAuthor_Lcom_yandex_mapkit_Attribution_Author_ == null)
		{
			cb_getAuthor_GetAuthor_Lcom_yandex_mapkit_Attribution_Author_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAuthor));
		}
		return cb_getAuthor_GetAuthor_Lcom_yandex_mapkit_Attribution_Author_;
	}

	private static nint n_GetAuthor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Attribution>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAuthor());
	}

	[Register("getAuthor", "()Lcom/yandex/mapkit/Attribution$Author;", "GetGetAuthorHandler")]
	public unsafe virtual Author? GetAuthor()
	{
		return Java.Lang.Object.GetObject<Author>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAuthor.()Lcom/yandex/mapkit/Attribution$Author;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetLinkHandler()
	{
		if ((object)cb_getLink_GetLink_Lcom_yandex_mapkit_Attribution_Link_ == null)
		{
			cb_getLink_GetLink_Lcom_yandex_mapkit_Attribution_Link_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLink));
		}
		return cb_getLink_GetLink_Lcom_yandex_mapkit_Attribution_Link_;
	}

	private static nint n_GetLink(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Attribution>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLink());
	}

	[Register("getLink", "()Lcom/yandex/mapkit/Attribution$Link;", "GetGetLinkHandler")]
	public unsafe virtual Link? GetLink()
	{
		return Java.Lang.Object.GetObject<Link>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLink.()Lcom/yandex/mapkit/Attribution$Link;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
		Attribution? attribution = Java.Lang.Object.GetObject<Attribution>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		attribution.Serialize(archive);
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
