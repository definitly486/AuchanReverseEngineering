using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.Core.App;

[Register("androidx/core/app/TaskStackBuilder", DoNotGenerateAcw = true)]
public sealed class TaskStackBuilder : Java.Lang.Object, IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/TaskStackBuilder", typeof(TaskStackBuilder));

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

	public unsafe int IntentCount
	{
		[Register("getIntentCount", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getIntentCount.()I", this, null);
		}
	}

	internal TaskStackBuilder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("addNextIntent", "(Landroid/content/Intent;)Landroidx/core/app/TaskStackBuilder;", "")]
	public unsafe TaskStackBuilder? AddNextIntent(Intent? nextIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(nextIntent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TaskStackBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addNextIntent.(Landroid/content/Intent;)Landroidx/core/app/TaskStackBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(nextIntent);
		}
	}

	[Register("addNextIntentWithParentStack", "(Landroid/content/Intent;)Landroidx/core/app/TaskStackBuilder;", "")]
	public unsafe TaskStackBuilder? AddNextIntentWithParentStack(Intent? nextIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(nextIntent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TaskStackBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addNextIntentWithParentStack.(Landroid/content/Intent;)Landroidx/core/app/TaskStackBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(nextIntent);
		}
	}

	[Register("addParentStack", "(Landroid/app/Activity;)Landroidx/core/app/TaskStackBuilder;", "")]
	public unsafe TaskStackBuilder? AddParentStack(Activity? sourceActivity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(sourceActivity?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TaskStackBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addParentStack.(Landroid/app/Activity;)Landroidx/core/app/TaskStackBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(sourceActivity);
		}
	}

	[Register("addParentStack", "(Landroid/content/ComponentName;)Landroidx/core/app/TaskStackBuilder;", "")]
	public unsafe TaskStackBuilder? AddParentStack(ComponentName? sourceActivityName)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(sourceActivityName?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TaskStackBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addParentStack.(Landroid/content/ComponentName;)Landroidx/core/app/TaskStackBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(sourceActivityName);
		}
	}

	[Register("addParentStack", "(Ljava/lang/Class;)Landroidx/core/app/TaskStackBuilder;", "")]
	public unsafe TaskStackBuilder? AddParentStack(Class? sourceActivityClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(sourceActivityClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TaskStackBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addParentStack.(Ljava/lang/Class;)Landroidx/core/app/TaskStackBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(sourceActivityClass);
		}
	}

	[Register("create", "(Landroid/content/Context;)Landroidx/core/app/TaskStackBuilder;", "")]
	public unsafe static TaskStackBuilder? Create(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TaskStackBuilder>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/content/Context;)Landroidx/core/app/TaskStackBuilder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("editIntentAt", "(I)Landroid/content/Intent;", "")]
	public unsafe Intent? EditIntentAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeAbstractObjectMethod("editIntentAt.(I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("deprecated")]
	[Register("from", "(Landroid/content/Context;)Landroidx/core/app/TaskStackBuilder;", "")]
	public unsafe static TaskStackBuilder? From(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TaskStackBuilder>(_members.StaticMethods.InvokeObjectMethod("from.(Landroid/content/Context;)Landroidx/core/app/TaskStackBuilder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Obsolete("deprecated")]
	[Register("getIntent", "(I)Landroid/content/Intent;", "")]
	public unsafe Intent? GetIntent(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIntent.(I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getIntents", "()[Landroid/content/Intent;", "")]
	public unsafe Intent[]? GetIntents()
	{
		return (Intent[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getIntents.()[Landroid/content/Intent;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Intent));
	}

	[Register("getPendingIntent", "(II)Landroid/app/PendingIntent;", "")]
	public unsafe PendingIntent? GetPendingIntent(int requestCode, int flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(requestCode);
		ptr[1] = new JniArgumentValue(flags);
		return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPendingIntent.(II)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getPendingIntent", "(IILandroid/os/Bundle;)Landroid/app/PendingIntent;", "")]
	public unsafe PendingIntent? GetPendingIntent(int requestCode, int flags, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(flags);
			ptr[2] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPendingIntent.(IILandroid/os/Bundle;)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(options);
		}
	}

	[Register("getPendingIntent", "(IILandroid/os/Bundle;Z)Landroid/app/PendingIntent;", "")]
	public unsafe PendingIntent? GetPendingIntent(int requestCode, int flags, Bundle? options, bool isMutable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(flags);
			ptr[2] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(isMutable ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPendingIntent.(IILandroid/os/Bundle;Z)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(options);
		}
	}

	[Register("getPendingIntent", "(IIZ)Landroid/app/PendingIntent;", "")]
	public unsafe PendingIntent? GetPendingIntent(int requestCode, int flags, bool isMutable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(requestCode);
		ptr[1] = new JniArgumentValue(flags);
		ptr[2] = new JniArgumentValue(isMutable ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPendingIntent.(IIZ)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("deprecated")]
	[Register("iterator", "()Ljava/util/Iterator;", "")]
	public unsafe IIterator? Iterator()
	{
		return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("startActivities", "()V", "")]
	public unsafe void StartActivities()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("startActivities.()V", this, null);
	}

	[Register("startActivities", "(Landroid/os/Bundle;)V", "")]
	public unsafe void StartActivities(Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("startActivities.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(options);
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
