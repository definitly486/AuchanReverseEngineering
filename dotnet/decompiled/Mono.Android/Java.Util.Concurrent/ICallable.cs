using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/Callable", "", "Java.Util.Concurrent.ICallableInvoker")]
[JavaTypeParameters(new string[] { "V" })]
public interface ICallable : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("call", "()Ljava/lang/Object;", "GetCallHandler:Java.Util.Concurrent.ICallableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? Call();
}
