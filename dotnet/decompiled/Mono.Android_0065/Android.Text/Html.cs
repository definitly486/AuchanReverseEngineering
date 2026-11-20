using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Org.Xml.Sax;

namespace Android.Text;

[Register("android/text/Html", DoNotGenerateAcw = true)]
public class Html : Java.Lang.Object
{
	[Register("android/text/Html$ImageGetter", "", "Android.Text.Html/IImageGetterInvoker")]
	public interface IImageGetter : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("getDrawable", "(Ljava/lang/String;)Landroid/graphics/drawable/Drawable;", "GetGetDrawable_Ljava_lang_String_Handler:Android.Text.Html/IImageGetterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		Drawable? GetDrawable(string? source);
	}

	[Register("android/text/Html$ImageGetter", DoNotGenerateAcw = true)]
	internal class IImageGetterInvoker : Java.Lang.Object, IImageGetter, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_text_Html_ImageGetter = new XAPeerMembers("android/text/Html$ImageGetter", typeof(IImageGetterInvoker));

		private static Delegate? cb_getDrawable_GetDrawable_Ljava_lang_String__Landroid_graphics_drawable_Drawable_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_text_Html_ImageGetter;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_text_Html_ImageGetter.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_text_Html_ImageGetter.ManagedPeerType;

		public IImageGetterInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetGetDrawable_Ljava_lang_String_Handler()
		{
			return new _JniMarshal_PPL_L(n_GetDrawable_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetDrawable_Ljava_lang_String_(nint jnienv, nint native__this, nint native_source)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IImageGetter? imageGetter = Java.Lang.Object.GetObject<IImageGetter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string source = JNIEnv.GetString(native_source, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(imageGetter.GetDrawable(source));
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe Drawable? GetDrawable(string? source)
		{
			nint num = JNIEnv.NewString(source);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Drawable>(_members_android_text_Html_ImageGetter.InstanceMethods.InvokeAbstractObjectMethod("getDrawable.(Ljava/lang/String;)Landroid/graphics/drawable/Drawable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
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

	[Register("android/text/Html$TagHandler", "", "Android.Text.Html/ITagHandlerInvoker")]
	public interface ITagHandler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("handleTag", "(ZLjava/lang/String;Landroid/text/Editable;Lorg/xml/sax/XMLReader;)V", "GetHandleTag_ZLjava_lang_String_Landroid_text_Editable_Lorg_xml_sax_XMLReader_Handler:Android.Text.Html/ITagHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void HandleTag(bool opening, string? tag, IEditable? output, IXMLReader? xmlReader);
	}

	[Register("android/text/Html$TagHandler", DoNotGenerateAcw = true)]
	internal class ITagHandlerInvoker : Java.Lang.Object, ITagHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_text_Html_TagHandler = new XAPeerMembers("android/text/Html$TagHandler", typeof(ITagHandlerInvoker));

		private static Delegate? cb_handleTag_HandleTag_ZLjava_lang_String_Landroid_text_Editable_Lorg_xml_sax_XMLReader__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_text_Html_TagHandler;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_text_Html_TagHandler.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_text_Html_TagHandler.ManagedPeerType;

		public ITagHandlerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetHandleTag_ZLjava_lang_String_Landroid_text_Editable_Lorg_xml_sax_XMLReader_Handler()
		{
			return new _JniMarshal_PPBLLL_V(n_HandleTag_ZLjava_lang_String_Landroid_text_Editable_Lorg_xml_sax_XMLReader_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_HandleTag_ZLjava_lang_String_Landroid_text_Editable_Lorg_xml_sax_XMLReader_(nint jnienv, nint native__this, sbyte native_opening, nint native_tag, nint native_output, nint native_xmlReader)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ITagHandler? tagHandler = Java.Lang.Object.GetObject<ITagHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool opening = native_opening != 0;
				string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
				IEditable output = Java.Lang.Object.GetObject<IEditable>(native_output, JniHandleOwnership.DoNotTransfer);
				IXMLReader xmlReader = Java.Lang.Object.GetObject<IXMLReader>(native_xmlReader, JniHandleOwnership.DoNotTransfer);
				tagHandler.HandleTag(opening, tag, output, xmlReader);
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

		public unsafe void HandleTag(bool opening, string? tag, IEditable? output, IXMLReader? xmlReader)
		{
			nint num = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(opening ? ((sbyte)1) : ((sbyte)0));
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue((output == null) ? IntPtr.Zero : ((Java.Lang.Object)output).Handle);
				ptr[3] = new JniArgumentValue((xmlReader == null) ? IntPtr.Zero : ((Java.Lang.Object)xmlReader).Handle);
				_members_android_text_Html_TagHandler.InstanceMethods.InvokeAbstractVoidMethod("handleTag.(ZLjava/lang/String;Landroid/text/Editable;Lorg/xml/sax/XMLReader;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(output);
				GC.KeepAlive(xmlReader);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/Html", typeof(Html));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Html(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
