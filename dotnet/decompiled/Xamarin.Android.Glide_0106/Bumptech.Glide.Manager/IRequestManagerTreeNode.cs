using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/RequestManagerTreeNode", "", "Bumptech.Glide.Manager.IRequestManagerTreeNodeInvoker")]
public interface IRequestManagerTreeNode : IJavaObject, IDisposable, IJavaPeerable
{
	ICollection<RequestManager> Descendants
	{
		[Register("getDescendants", "()Ljava/util/Set;", "GetGetDescendantsHandler:Bumptech.Glide.Manager.IRequestManagerTreeNodeInvoker, Xamarin.Android.Glide")]
		get;
	}
}
