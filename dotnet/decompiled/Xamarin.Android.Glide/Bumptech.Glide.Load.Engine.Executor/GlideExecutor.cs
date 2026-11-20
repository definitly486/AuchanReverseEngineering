using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace Bumptech.Glide.Load.Engine.Executor;

[Register("com/bumptech/glide/load/engine/executor/GlideExecutor", DoNotGenerateAcw = true)]
public sealed class GlideExecutor : Java.Lang.Object, IExecutorService, IExecutor, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/bumptech/glide/load/engine/executor/GlideExecutor$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/executor/GlideExecutor$Builder", typeof(Builder));

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

		internal Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("build", "()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
		public unsafe GlideExecutor? Build()
		{
			return Java.Lang.Object.GetObject<GlideExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setName", "(Ljava/lang/String;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", "")]
		public unsafe Builder? SetName(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setName.(Ljava/lang/String;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("setThreadCount", "(I)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", "")]
		public unsafe Builder? SetThreadCount(int threadCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(threadCount);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setThreadCount.(I)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("setThreadFactory", "(Ljava/util/concurrent/ThreadFactory;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", "")]
		public unsafe Builder? SetThreadFactory(IThreadFactory threadFactory)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((threadFactory == null) ? IntPtr.Zero : ((Java.Lang.Object)threadFactory).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setThreadFactory.(Ljava/util/concurrent/ThreadFactory;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(threadFactory);
			}
		}

		[Register("setThreadTimeoutMillis", "(J)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", "")]
		public unsafe Builder? SetThreadTimeoutMillis(long threadTimeoutMillis)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(threadTimeoutMillis);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setThreadTimeoutMillis.(J)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setUncaughtThrowableStrategy", "(Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", "")]
		public unsafe Builder? SetUncaughtThrowableStrategy(IUncaughtThrowableStrategy strategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((strategy == null) ? IntPtr.Zero : ((Java.Lang.Object)strategy).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUncaughtThrowableStrategy.(Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(strategy);
			}
		}
	}

	[Register("com/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy", "", "Bumptech.Glide.Load.Engine.Executor.GlideExecutor/IUncaughtThrowableStrategyInvoker")]
	public interface IUncaughtThrowableStrategy : IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy", typeof(IUncaughtThrowableStrategy), isInterface: true);

		[Register("DEFAULT")]
		static IUncaughtThrowableStrategy? Default => Java.Lang.Object.GetObject<IUncaughtThrowableStrategy>(_members.StaticFields.GetObjectValue("DEFAULT.Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("IGNORE")]
		static IUncaughtThrowableStrategy? Ignore => Java.Lang.Object.GetObject<IUncaughtThrowableStrategy>(_members.StaticFields.GetObjectValue("IGNORE.Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOG")]
		static IUncaughtThrowableStrategy? Log => Java.Lang.Object.GetObject<IUncaughtThrowableStrategy>(_members.StaticFields.GetObjectValue("LOG.Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("THROW")]
		static IUncaughtThrowableStrategy? Throw => Java.Lang.Object.GetObject<IUncaughtThrowableStrategy>(_members.StaticFields.GetObjectValue("THROW.Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("handle", "(Ljava/lang/Throwable;)V", "GetHandle_Ljava_lang_Throwable_Handler:Bumptech.Glide.Load.Engine.Executor.GlideExecutor/IUncaughtThrowableStrategyInvoker, Xamarin.Android.Glide")]
		new void Handle(Throwable? p0);
	}

	[Register("com/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy", DoNotGenerateAcw = true)]
	internal class IUncaughtThrowableStrategyInvoker : Java.Lang.Object, IUncaughtThrowableStrategy, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_executor_GlideExecutor_UncaughtThrowableStrategy = new XAPeerMembers("com/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy", typeof(IUncaughtThrowableStrategyInvoker));

		private static Delegate? cb_handle_Handle_Ljava_lang_Throwable__V;

		private static nint java_class_ref => _members_com_bumptech_glide_load_engine_executor_GlideExecutor_UncaughtThrowableStrategy.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_executor_GlideExecutor_UncaughtThrowableStrategy;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_executor_GlideExecutor_UncaughtThrowableStrategy.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_executor_GlideExecutor_UncaughtThrowableStrategy.ManagedPeerType;

		public IUncaughtThrowableStrategyInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetHandle_Ljava_lang_Throwable_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_Handle_Ljava_lang_Throwable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Handle_Ljava_lang_Throwable_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IUncaughtThrowableStrategy? uncaughtThrowableStrategy = Java.Lang.Object.GetObject<IUncaughtThrowableStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				uncaughtThrowableStrategy.Handle(p);
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

		public new unsafe void Handle(Throwable? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members_com_bumptech_glide_load_engine_executor_GlideExecutor_UncaughtThrowableStrategy.InstanceMethods.InvokeAbstractVoidMethod("handle.(Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/executor/GlideExecutor", typeof(GlideExecutor));

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

	public unsafe bool IsShutdown
	{
		[Register("isShutdown", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isShutdown.()Z", this, null);
		}
	}

	public unsafe bool IsTerminated
	{
		[Register("isTerminated", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isTerminated.()Z", this, null);
		}
	}

	IList IExecutorService.InvokeAll(ICollection tasks)
	{
		return InvokeAll(tasks.Cast<ICallable>().ToList()).ToList();
	}

	IList IExecutorService.InvokeAll(ICollection tasks, long timeout, TimeUnit unit)
	{
		return InvokeAll(tasks.Cast<ICallable>().ToList(), timeout, unit).ToList();
	}

	Java.Lang.Object IExecutorService.InvokeAny(ICollection tasks)
	{
		return InvokeAny(tasks.Cast<ICallable>().ToList());
	}

	Java.Lang.Object IExecutorService.InvokeAny(ICollection tasks, long timeout, TimeUnit unit)
	{
		return InvokeAny(tasks.Cast<ICallable>().ToList(), timeout, unit);
	}

	internal GlideExecutor(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("awaitTermination", "(JLjava/util/concurrent/TimeUnit;)Z", "")]
	public unsafe bool AwaitTermination(long timeout, TimeUnit unit)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(timeout);
			ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("awaitTermination.(JLjava/util/concurrent/TimeUnit;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(unit);
		}
	}

	[Register("calculateBestThreadCount", "()I", "")]
	public unsafe static int CalculateBestThreadCount()
	{
		return _members.StaticMethods.InvokeInt32Method("calculateBestThreadCount.()I", null);
	}

	[Register("execute", "(Ljava/lang/Runnable;)V", "")]
	public unsafe void Execute(IRunnable command)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((command == null) ? IntPtr.Zero : ((Java.Lang.Object)command).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("execute.(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(command);
		}
	}

	[Register("invokeAll", "(Ljava/util/Collection;)Ljava/util/List;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe IList<IFuture> InvokeAll(ICollection<ICallable> tasks)
	{
		nint num = JavaCollection<ICallable>.ToLocalJniHandle(tasks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList<IFuture>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("invokeAll.(Ljava/util/Collection;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tasks);
		}
	}

	[Register("invokeAll", "(Ljava/util/Collection;JLjava/util/concurrent/TimeUnit;)Ljava/util/List;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe IList<IFuture> InvokeAll(ICollection<ICallable> tasks, long timeout, TimeUnit unit)
	{
		nint num = JavaCollection<ICallable>.ToLocalJniHandle(tasks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(timeout);
			ptr[2] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
			return JavaList<IFuture>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("invokeAll.(Ljava/util/Collection;JLjava/util/concurrent/TimeUnit;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tasks);
			GC.KeepAlive(unit);
		}
	}

	[Register("invokeAny", "(Ljava/util/Collection;)Ljava/lang/Object;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe Java.Lang.Object InvokeAny(ICollection<ICallable> tasks)
	{
		nint num = JavaCollection<ICallable>.ToLocalJniHandle(tasks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("invokeAny.(Ljava/util/Collection;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tasks);
		}
	}

	[Register("invokeAny", "(Ljava/util/Collection;JLjava/util/concurrent/TimeUnit;)Ljava/lang/Object;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe Java.Lang.Object? InvokeAny(ICollection<ICallable> tasks, long timeout, TimeUnit unit)
	{
		nint num = JavaCollection<ICallable>.ToLocalJniHandle(tasks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(timeout);
			ptr[2] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("invokeAny.(Ljava/util/Collection;JLjava/util/concurrent/TimeUnit;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tasks);
			GC.KeepAlive(unit);
		}
	}

	[Register("newAnimationBuilder", "()Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", "")]
	public unsafe static Builder? NewAnimationBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newAnimationBuilder.()Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("newAnimationExecutor", "()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewAnimationExecutor()
	{
		return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newAnimationExecutor.()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("deprecated")]
	[Register("newAnimationExecutor", "(ILcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewAnimationExecutor(int threadCount, IUncaughtThrowableStrategy? uncaughtThrowableStrategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(threadCount);
			ptr[1] = new JniArgumentValue((uncaughtThrowableStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)uncaughtThrowableStrategy).Handle);
			return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newAnimationExecutor.(ILcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uncaughtThrowableStrategy);
		}
	}

	[Register("newDiskCacheBuilder", "()Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", "")]
	public unsafe static Builder? NewDiskCacheBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newDiskCacheBuilder.()Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("newDiskCacheExecutor", "()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewDiskCacheExecutor()
	{
		return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newDiskCacheExecutor.()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("deprecated")]
	[Register("newDiskCacheExecutor", "(Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewDiskCacheExecutor(IUncaughtThrowableStrategy? uncaughtThrowableStrategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((uncaughtThrowableStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)uncaughtThrowableStrategy).Handle);
			return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newDiskCacheExecutor.(Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uncaughtThrowableStrategy);
		}
	}

	[Obsolete("deprecated")]
	[Register("newDiskCacheExecutor", "(ILjava/lang/String;Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewDiskCacheExecutor(int threadCount, string? name, IUncaughtThrowableStrategy? uncaughtThrowableStrategy)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(threadCount);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue((uncaughtThrowableStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)uncaughtThrowableStrategy).Handle);
			return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newDiskCacheExecutor.(ILjava/lang/String;Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(uncaughtThrowableStrategy);
		}
	}

	[Register("newSourceBuilder", "()Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", "")]
	public unsafe static Builder? NewSourceBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newSourceBuilder.()Lcom/bumptech/glide/load/engine/executor/GlideExecutor$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("newSourceExecutor", "()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewSourceExecutor()
	{
		return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newSourceExecutor.()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("deprecated")]
	[Register("newSourceExecutor", "(Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewSourceExecutor(IUncaughtThrowableStrategy? uncaughtThrowableStrategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((uncaughtThrowableStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)uncaughtThrowableStrategy).Handle);
			return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newSourceExecutor.(Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uncaughtThrowableStrategy);
		}
	}

	[Obsolete("deprecated")]
	[Register("newSourceExecutor", "(ILjava/lang/String;Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewSourceExecutor(int threadCount, string? name, IUncaughtThrowableStrategy? uncaughtThrowableStrategy)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(threadCount);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue((uncaughtThrowableStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)uncaughtThrowableStrategy).Handle);
			return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newSourceExecutor.(ILjava/lang/String;Lcom/bumptech/glide/load/engine/executor/GlideExecutor$UncaughtThrowableStrategy;)Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(uncaughtThrowableStrategy);
		}
	}

	[Register("newUnlimitedSourceExecutor", "()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", "")]
	public unsafe static GlideExecutor? NewUnlimitedSourceExecutor()
	{
		return Java.Lang.Object.GetObject<GlideExecutor>(_members.StaticMethods.InvokeObjectMethod("newUnlimitedSourceExecutor.()Lcom/bumptech/glide/load/engine/executor/GlideExecutor;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("shutdown", "()V", "")]
	public unsafe void Shutdown()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("shutdown.()V", this, null);
	}

	[Register("shutdownNow", "()Ljava/util/List;", "")]
	public unsafe IList<IRunnable> ShutdownNow()
	{
		return JavaList<IRunnable>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("shutdownNow.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("submit", "(Ljava/lang/Runnable;)Ljava/util/concurrent/Future;", "")]
	public unsafe IFuture Submit(IRunnable task)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((task == null) ? IntPtr.Zero : ((Java.Lang.Object)task).Handle);
			return Java.Lang.Object.GetObject<IFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("submit.(Ljava/lang/Runnable;)Ljava/util/concurrent/Future;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(task);
		}
	}

	[Register("submit", "(Ljava/lang/Runnable;Ljava/lang/Object;)Ljava/util/concurrent/Future;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe IFuture Submit(IRunnable task, Java.Lang.Object? result)
	{
		nint num = JNIEnv.ToLocalJniHandle(result);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((task == null) ? IntPtr.Zero : ((Java.Lang.Object)task).Handle);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("submit.(Ljava/lang/Runnable;Ljava/lang/Object;)Ljava/util/concurrent/Future;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(task);
			GC.KeepAlive(result);
		}
	}

	[Register("submit", "(Ljava/util/concurrent/Callable;)Ljava/util/concurrent/Future;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe IFuture? Submit(ICallable task)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((task == null) ? IntPtr.Zero : ((Java.Lang.Object)task).Handle);
			return Java.Lang.Object.GetObject<IFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("submit.(Ljava/util/concurrent/Callable;)Ljava/util/concurrent/Future;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(task);
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
}
