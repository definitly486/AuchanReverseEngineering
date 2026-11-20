using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.View;

[Register("androidx/appcompat/view/ActionMode", DoNotGenerateAcw = true)]
internal class ActionModeInvoker : ActionMode
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/view/ActionMode", typeof(ActionModeInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override Android.Views.View? CustomView
	{
		[Register("getCustomView", "()Landroid/view/View;", "GetGetCustomViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCustomView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCustomView", "(Landroid/view/View;)V", "GetSetCustomView_Landroid_view_View_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setCustomView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe override IMenu? Menu
	{
		[Register("getMenu", "()Landroid/view/Menu;", "GetGetMenuHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IMenu>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMenu.()Landroid/view/Menu;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override MenuInflater? MenuInflater
	{
		[Register("getMenuInflater", "()Landroid/view/MenuInflater;", "GetGetMenuInflaterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MenuInflater>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMenuInflater.()Landroid/view/MenuInflater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override ICharSequence? SubtitleFormatted
	{
		[Register("getSubtitle", "()Ljava/lang/CharSequence;", "GetGetSubtitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSubtitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSubtitle", "(Ljava/lang/CharSequence;)V", "GetSetSubtitle_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setSubtitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe override ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public ActionModeInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("finish", "()V", "GetFinishHandler")]
	public unsafe override void Finish()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("finish.()V", this, null);
	}

	[Register("invalidate", "()V", "GetInvalidateHandler")]
	public unsafe override void Invalidate()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("invalidate.()V", this, null);
	}

	[Register("setSubtitle", "(I)V", "GetSetSubtitle_IHandler")]
	public unsafe override void SetSubtitle(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setSubtitle.(I)V", this, ptr);
	}

	[Register("setTitle", "(I)V", "GetSetTitle_IHandler")]
	public unsafe override void SetTitle(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(I)V", this, ptr);
	}
}
