using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/Headers", "", "Bumptech.Glide.Load.Model.IHeadersInvoker")]
public interface IHeaders : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/model/Headers", typeof(IHeaders), isInterface: true);

	[Register("DEFAULT")]
	static IHeaders? Default => Java.Lang.Object.GetObject<IHeaders>(_members.StaticFields.GetObjectValue("DEFAULT.Lcom/bumptech/glide/load/model/Headers;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NONE")]
	[Obsolete("deprecated")]
	static IHeaders? None => Java.Lang.Object.GetObject<IHeaders>(_members.StaticFields.GetObjectValue("NONE.Lcom/bumptech/glide/load/model/Headers;").Handle, JniHandleOwnership.TransferLocalRef);

	IDictionary<string, string>? Headers
	{
		[Register("getHeaders", "()Ljava/util/Map;", "GetGetHeadersHandler:Bumptech.Glide.Load.Model.IHeadersInvoker, Xamarin.Android.Glide")]
		get;
	}
}
