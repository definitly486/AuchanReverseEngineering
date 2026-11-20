using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App.StrictMode;

[Register("androidx/fragment/app/strictmode/FragmentStrictMode", DoNotGenerateAcw = true)]
public sealed class FragmentStrictMode : Java.Lang.Object
{
	[Register("androidx/fragment/app/strictmode/FragmentStrictMode$Policy", DoNotGenerateAcw = true)]
	public sealed class Policy : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/strictmode/FragmentStrictMode$Policy", typeof(Policy));

		[Register("LAX")]
		public static Policy Lax => Java.Lang.Object.GetObject<Policy>(_members.StaticFields.GetObjectValue("LAX.Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal Policy(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/strictmode/FragmentStrictMode", typeof(FragmentStrictMode));

	[Register("INSTANCE")]
	public static FragmentStrictMode Instance => Java.Lang.Object.GetObject<FragmentStrictMode>(_members.StaticFields.GetObjectValue("INSTANCE.Landroidx/fragment/app/strictmode/FragmentStrictMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe Policy DefaultPolicy
	{
		[Register("getDefaultPolicy", "()Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Policy>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDefaultPolicy.()Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setDefaultPolicy", "(Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDefaultPolicy.(Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	internal FragmentStrictMode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onFragmentReuse", "(Landroidx/fragment/app/Fragment;Ljava/lang/String;)V", "")]
	public unsafe static void OnFragmentReuse(Fragment fragment, string previousFragmentId)
	{
		nint num = JNIEnv.NewString(previousFragmentId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("onFragmentReuse.(Landroidx/fragment/app/Fragment;Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(fragment);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onFragmentTagUsage", "(Landroidx/fragment/app/Fragment;Landroid/view/ViewGroup;)V", "")]
	public unsafe static void OnFragmentTagUsage(Fragment fragment, ViewGroup? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onFragmentTagUsage.(Landroidx/fragment/app/Fragment;Landroid/view/ViewGroup;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(container);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onGetRetainInstanceUsage", "(Landroidx/fragment/app/Fragment;)V", "")]
	public unsafe static void OnGetRetainInstanceUsage(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onGetRetainInstanceUsage.(Landroidx/fragment/app/Fragment;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onGetTargetFragmentRequestCodeUsage", "(Landroidx/fragment/app/Fragment;)V", "")]
	public unsafe static void OnGetTargetFragmentRequestCodeUsage(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onGetTargetFragmentRequestCodeUsage.(Landroidx/fragment/app/Fragment;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onGetTargetFragmentUsage", "(Landroidx/fragment/app/Fragment;)V", "")]
	public unsafe static void OnGetTargetFragmentUsage(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onGetTargetFragmentUsage.(Landroidx/fragment/app/Fragment;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	[Register("onPolicyViolation", "(Landroidx/fragment/app/strictmode/Violation;)V", "")]
	public unsafe void OnPolicyViolation(Violation violation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(violation?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onPolicyViolation.(Landroidx/fragment/app/strictmode/Violation;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(violation);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onSetRetainInstanceUsage", "(Landroidx/fragment/app/Fragment;)V", "")]
	public unsafe static void OnSetRetainInstanceUsage(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onSetRetainInstanceUsage.(Landroidx/fragment/app/Fragment;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onSetTargetFragmentUsage", "(Landroidx/fragment/app/Fragment;Landroidx/fragment/app/Fragment;I)V", "")]
	public unsafe static void OnSetTargetFragmentUsage(Fragment violatingFragment, Fragment targetFragment, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(violatingFragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(targetFragment?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			_members.StaticMethods.InvokeVoidMethod("onSetTargetFragmentUsage.(Landroidx/fragment/app/Fragment;Landroidx/fragment/app/Fragment;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(violatingFragment);
			GC.KeepAlive(targetFragment);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onSetUserVisibleHint", "(Landroidx/fragment/app/Fragment;Z)V", "")]
	public unsafe static void OnSetUserVisibleHint(Fragment fragment, bool isVisibleToUser)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(isVisibleToUser ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("onSetUserVisibleHint.(Landroidx/fragment/app/Fragment;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onWrongFragmentContainer", "(Landroidx/fragment/app/Fragment;Landroid/view/ViewGroup;)V", "")]
	public unsafe static void OnWrongFragmentContainer(Fragment fragment, ViewGroup container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onWrongFragmentContainer.(Landroidx/fragment/app/Fragment;Landroid/view/ViewGroup;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(container);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onWrongNestedHierarchy", "(Landroidx/fragment/app/Fragment;Landroidx/fragment/app/Fragment;I)V", "")]
	public unsafe static void OnWrongNestedHierarchy(Fragment fragment, Fragment expectedParentFragment, int containerId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(expectedParentFragment?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(containerId);
			_members.StaticMethods.InvokeVoidMethod("onWrongNestedHierarchy.(Landroidx/fragment/app/Fragment;Landroidx/fragment/app/Fragment;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(expectedParentFragment);
		}
	}
}
