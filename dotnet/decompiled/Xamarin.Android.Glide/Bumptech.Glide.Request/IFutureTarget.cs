using System;
using Android.Runtime;
using Bumptech.Glide.Manager;
using Bumptech.Glide.Request.Target;
using Java.Interop;
using Java.Util.Concurrent;

namespace Bumptech.Glide.Request;

[Register("com/bumptech/glide/request/FutureTarget", "", "Bumptech.Glide.Request.IFutureTargetInvoker")]
[JavaTypeParameters(new string[] { "R" })]
public interface IFutureTarget : ITarget, ILifecycleListener, IJavaObject, IDisposable, IJavaPeerable, IFuture
{
}
