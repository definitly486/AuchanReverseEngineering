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
		[Register("setBuiltInZoomControls", "(Z)V", "GetSetBuiltInZoomControls_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setBuiltInZoomControls.(Z)V", this, ptr);
		}
	}

	public unsafe override string? DefaultTextEncodingName
	{
		[Register("setDefaultTextEncodingName", "(Ljava/lang/String;)V", "GetSetDefaultTextEncodingName_Ljava_lang_String_Handler")]
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
		[Register("setDisplayZoomControls", "(Z)V", "GetSetDisplayZoomControls_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayZoomControls.(Z)V", this, ptr);
		}
	}

	public unsafe override bool DomStorageEnabled
	{
		[Register("setDomStorageEnabled", "(Z)V", "GetSetDomStorageEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDomStorageEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe override bool JavaScriptEnabled
	{
		[Register("setJavaScriptEnabled", "(Z)V", "GetSetJavaScriptEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setJavaScriptEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe override bool LoadWithOverviewMode
	{
		[Register("setLoadWithOverviewMode", "(Z)V", "GetSetLoadWithOverviewMode_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setLoadWithOverviewMode.(Z)V", this, ptr);
		}
	}

	public unsafe override MixedContentHandling MixedContentMode
	{
		[Register("setMixedContentMode", "(I)V", "GetSetMixedContentMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setMixedContentMode.(I)V", this, ptr);
		}
	}

	public unsafe override bool UseWideViewPort
	{
		[Register("setUseWideViewPort", "(Z)V", "GetSetUseWideViewPort_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setUseWideViewPort.(Z)V", this, ptr);
		}
	}

	public unsafe override string? UserAgentString
	{
		[Register("setUserAgentString", "(Ljava/lang/String;)V", "GetSetUserAgentString_Ljava_lang_String_Handler")]
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

	[Register("setSupportMultipleWindows", "(Z)V", "GetSetSupportMultipleWindows_ZHandler")]
	public unsafe override void SetSupportMultipleWindows(bool support)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(support ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setSupportMultipleWindows.(Z)V", this, ptr);
	}
}
