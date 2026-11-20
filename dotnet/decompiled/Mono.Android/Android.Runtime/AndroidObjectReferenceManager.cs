using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using Java.Interop;

namespace Android.Runtime;

internal class AndroidObjectReferenceManager : JniRuntime.JniObjectReferenceManager
{
	public override int GlobalReferenceCount => RuntimeNativeMethods._monodroid_gref_get();

	public override int WeakGlobalReferenceCount => RuntimeNativeMethods._monodroid_weak_gref_get();

	public override bool LogGlobalReferenceMessages => Logger.LogGlobalRef;

	public override JniObjectReference CreateLocalReference(JniObjectReference value, ref int localReferenceCount)
	{
		JniObjectReference result = base.CreateLocalReference(value, ref localReferenceCount);
		if (Logger.LogLocalRef)
		{
			string name = Thread.CurrentThread.Name;
			int managedThreadId = Thread.CurrentThread.ManagedThreadId;
			StringBuilder stringBuilder = new StringBuilder(new StackTrace(fNeedFileInfo: true).ToString());
			RuntimeNativeMethods._monodroid_lref_log_new(localReferenceCount, result.Handle, 76, name, managedThreadId, stringBuilder, 1);
		}
		return result;
	}

	public override void DeleteLocalReference(ref JniObjectReference value, ref int localReferenceCount)
	{
		if (Logger.LogLocalRef)
		{
			string name = Thread.CurrentThread.Name;
			int managedThreadId = Thread.CurrentThread.ManagedThreadId;
			StringBuilder stringBuilder = new StringBuilder(new StackTrace(fNeedFileInfo: true).ToString());
			RuntimeNativeMethods._monodroid_lref_log_delete(localReferenceCount - 1, value.Handle, 76, name, managedThreadId, stringBuilder, 1);
		}
		base.DeleteLocalReference(ref value, ref localReferenceCount);
	}

	public override void CreatedLocalReference(JniObjectReference value, ref int localReferenceCount)
	{
		base.CreatedLocalReference(value, ref localReferenceCount);
		if (Logger.LogLocalRef)
		{
			string name = Thread.CurrentThread.Name;
			int managedThreadId = Thread.CurrentThread.ManagedThreadId;
			StringBuilder stringBuilder = new StringBuilder(new StackTrace(fNeedFileInfo: true).ToString());
			RuntimeNativeMethods._monodroid_lref_log_new(localReferenceCount, value.Handle, 76, name, managedThreadId, stringBuilder, 1);
		}
	}

	public override void WriteGlobalReferenceLine(string format, params object?[] args)
	{
		RuntimeNativeMethods._monodroid_gref_log(string.Format(CultureInfo.InvariantCulture, format, args));
		RuntimeNativeMethods._monodroid_gref_log("\n");
	}

	public override JniObjectReference CreateGlobalReference(JniObjectReference value)
	{
		JniObjectReference result = base.CreateGlobalReference(value);
		bool logGlobalRef = Logger.LogGlobalRef;
		byte curType = (byte)(logGlobalRef ? GetObjectRefType(value.Type) : 42);
		byte newType = (byte)(logGlobalRef ? GetObjectRefType(result.Type) : 42);
		string threadName = (logGlobalRef ? Thread.CurrentThread.Name : null);
		int threadId = (logGlobalRef ? Thread.CurrentThread.ManagedThreadId : 0);
		StringBuilder stringBuilder = (logGlobalRef ? new StringBuilder(new StackTrace(fNeedFileInfo: true).ToString()) : null);
		int num = RuntimeNativeMethods._monodroid_gref_log_new(value.Handle, curType, result.Handle, newType, threadName, threadId, stringBuilder, 1);
		if (num >= JNIEnvInit.gref_gc_threshold)
		{
			Logger.Log(LogLevel.Warn, "monodroid-gc", num + " outstanding GREFs. Performing a full GC!");
			GC.Collect();
		}
		return result;
	}

	private static byte GetObjectRefType(JniObjectReferenceType type)
	{
		return type switch
		{
			JniObjectReferenceType.Invalid => 73, 
			JniObjectReferenceType.Local => 76, 
			JniObjectReferenceType.Global => 71, 
			JniObjectReferenceType.WeakGlobal => 87, 
			_ => 42, 
		};
	}

	public override void DeleteGlobalReference(ref JniObjectReference value)
	{
		bool logGlobalRef = Logger.LogGlobalRef;
		byte type = (byte)(logGlobalRef ? GetObjectRefType(value.Type) : 42);
		string threadName = (logGlobalRef ? Thread.CurrentThread.Name : null);
		int threadId = (logGlobalRef ? Thread.CurrentThread.ManagedThreadId : 0);
		StringBuilder stringBuilder = (logGlobalRef ? new StringBuilder(new StackTrace(fNeedFileInfo: true).ToString()) : null);
		RuntimeNativeMethods._monodroid_gref_log_delete(value.Handle, type, threadName, threadId, stringBuilder, 1);
		base.DeleteGlobalReference(ref value);
	}

	public override void DeleteWeakGlobalReference(ref JniObjectReference value)
	{
		bool logGlobalRef = Logger.LogGlobalRef;
		byte type = (byte)(logGlobalRef ? GetObjectRefType(value.Type) : 42);
		string threadName = (logGlobalRef ? Thread.CurrentThread.Name : null);
		int threadId = (logGlobalRef ? Thread.CurrentThread.ManagedThreadId : 0);
		StringBuilder stringBuilder = (logGlobalRef ? new StringBuilder(new StackTrace(fNeedFileInfo: true).ToString()) : null);
		RuntimeNativeMethods._monodroid_weak_gref_delete(value.Handle, type, threadName, threadId, stringBuilder, 1);
		base.DeleteWeakGlobalReference(ref value);
	}
}
