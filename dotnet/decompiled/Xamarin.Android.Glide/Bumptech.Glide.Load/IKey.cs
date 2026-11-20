using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Nio.Charset;
using Java.Security;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/Key", "", "Bumptech.Glide.Load.IKeyInvoker")]
public interface IKey : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/Key", typeof(IKey), isInterface: true);

	[Register("CHARSET")]
	static Charset? Charset => Java.Lang.Object.GetObject<Charset>(_members.StaticFields.GetObjectValue("CHARSET.Ljava/nio/charset/Charset;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler:Bumptech.Glide.Load.IKeyInvoker, Xamarin.Android.Glide")]
	bool Equals(Java.Lang.Object? p0);

	[Register("hashCode", "()I", "GetGetHashCodeHandler:Bumptech.Glide.Load.IKeyInvoker, Xamarin.Android.Glide")]
	new int GetHashCode();

	[Register("updateDiskCacheKey", "(Ljava/security/MessageDigest;)V", "GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler:Bumptech.Glide.Load.IKeyInvoker, Xamarin.Android.Glide")]
	void UpdateDiskCacheKey(MessageDigest p0);
}
