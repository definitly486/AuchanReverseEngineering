using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Webkit;

[Register("android/webkit/WebSettings", DoNotGenerateAcw = true)]
internal class WebSettingsInvoker : WebSettings
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebSettings", typeof(WebSettingsInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override bool BuiltInZoomControls
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setBuiltInZoomControls.(Z)V", this, ptr);
		}
	}

	public unsafe override string? DefaultTextEncodingName
	{
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setDefaultTextEncodingName.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe override bool DisplayZoomControls
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayZoomControls.(Z)V", this, ptr);
		}
	}

	public unsafe override bool DomStorageEnabled
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDomStorageEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe override bool JavaScriptEnabled
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setJavaScriptEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe override bool LoadWithOverviewMode
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setLoadWithOverviewMode.(Z)V", this, ptr);
		}
	}

	public unsafe override MixedContentHandling MixedContentMode
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setMixedContentMode.(I)V", this, ptr);
		}
	}

	public unsafe override bool UseWideViewPort
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setUseWideViewPort.(Z)V", this, ptr);
		}
	}

	public unsafe override string? UserAgentString
	{
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setUserAgentString.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public WebSettingsInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override void SetSupportMultipleWindows(bool support)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(support ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setSupportMultipleWindows.(Z)V", this, ptr);
	}
}
