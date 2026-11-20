using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Text;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Widget;

[Register("androidx/core/widget/TextViewCompat", DoNotGenerateAcw = true)]
public sealed class TextViewCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/widget/TextViewCompat", typeof(TextViewCompat));

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

	internal TextViewCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getAutoSizeMaxTextSize", "(Landroid/widget/TextView;)I", "")]
	public unsafe static int GetAutoSizeMaxTextSize(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getAutoSizeMaxTextSize.(Landroid/widget/TextView;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getAutoSizeMinTextSize", "(Landroid/widget/TextView;)I", "")]
	public unsafe static int GetAutoSizeMinTextSize(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getAutoSizeMinTextSize.(Landroid/widget/TextView;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getAutoSizeStepGranularity", "(Landroid/widget/TextView;)I", "")]
	public unsafe static int GetAutoSizeStepGranularity(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getAutoSizeStepGranularity.(Landroid/widget/TextView;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getAutoSizeTextAvailableSizes", "(Landroid/widget/TextView;)[I", "")]
	public unsafe static int[]? GetAutoSizeTextAvailableSizes(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return (int[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("getAutoSizeTextAvailableSizes.(Landroid/widget/TextView;)[I", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getAutoSizeTextType", "(Landroid/widget/TextView;)I", "")]
	public unsafe static int GetAutoSizeTextType(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getAutoSizeTextType.(Landroid/widget/TextView;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getCompoundDrawableTintList", "(Landroid/widget/TextView;)Landroid/content/res/ColorStateList;", "")]
	public unsafe static ColorStateList? GetCompoundDrawableTintList(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ColorStateList>(_members.StaticMethods.InvokeObjectMethod("getCompoundDrawableTintList.(Landroid/widget/TextView;)Landroid/content/res/ColorStateList;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getCompoundDrawableTintMode", "(Landroid/widget/TextView;)Landroid/graphics/PorterDuff$Mode;", "")]
	public unsafe static PorterDuff.Mode? GetCompoundDrawableTintMode(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.StaticMethods.InvokeObjectMethod("getCompoundDrawableTintMode.(Landroid/widget/TextView;)Landroid/graphics/PorterDuff$Mode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Obsolete("deprecated")]
	[Register("getCompoundDrawablesRelative", "(Landroid/widget/TextView;)[Landroid/graphics/drawable/Drawable;", "")]
	public unsafe static Drawable[]? GetCompoundDrawablesRelative(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return (Drawable[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("getCompoundDrawablesRelative.(Landroid/widget/TextView;)[Landroid/graphics/drawable/Drawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Drawable));
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getFirstBaselineToTopHeight", "(Landroid/widget/TextView;)I", "")]
	public unsafe static int GetFirstBaselineToTopHeight(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getFirstBaselineToTopHeight.(Landroid/widget/TextView;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getLastBaselineToBottomHeight", "(Landroid/widget/TextView;)I", "")]
	public unsafe static int GetLastBaselineToBottomHeight(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getLastBaselineToBottomHeight.(Landroid/widget/TextView;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Obsolete("deprecated")]
	[Register("getMaxLines", "(Landroid/widget/TextView;)I", "")]
	public unsafe static int GetMaxLines(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getMaxLines.(Landroid/widget/TextView;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Obsolete("deprecated")]
	[Register("getMinLines", "(Landroid/widget/TextView;)I", "")]
	public unsafe static int GetMinLines(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getMinLines.(Landroid/widget/TextView;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("getTextMetricsParams", "(Landroid/widget/TextView;)Landroidx/core/text/PrecomputedTextCompat$Params;", "")]
	public unsafe static PrecomputedTextCompat.Params? GetTextMetricsParams(TextView? textView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<PrecomputedTextCompat.Params>(_members.StaticMethods.InvokeObjectMethod("getTextMetricsParams.(Landroid/widget/TextView;)Landroidx/core/text/PrecomputedTextCompat$Params;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("setAutoSizeTextTypeUniformWithConfiguration", "(Landroid/widget/TextView;IIII)V", "")]
	public unsafe static void SetAutoSizeTextTypeUniformWithConfiguration(TextView? textView, int autoSizeMinTextSize, int autoSizeMaxTextSize, int autoSizeStepGranularity, int unit)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(autoSizeMinTextSize);
			ptr[2] = new JniArgumentValue(autoSizeMaxTextSize);
			ptr[3] = new JniArgumentValue(autoSizeStepGranularity);
			ptr[4] = new JniArgumentValue(unit);
			_members.StaticMethods.InvokeVoidMethod("setAutoSizeTextTypeUniformWithConfiguration.(Landroid/widget/TextView;IIII)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("setAutoSizeTextTypeUniformWithPresetSizes", "(Landroid/widget/TextView;[II)V", "")]
	public unsafe static void SetAutoSizeTextTypeUniformWithPresetSizes(TextView? textView, int[]? presetSizes, int unit)
	{
		nint num = JNIEnv.NewArray(presetSizes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(unit);
			_members.StaticMethods.InvokeVoidMethod("setAutoSizeTextTypeUniformWithPresetSizes.(Landroid/widget/TextView;[II)V", ptr);
		}
		finally
		{
			if (presetSizes != null)
			{
				JNIEnv.CopyArray(num, presetSizes);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(textView);
			GC.KeepAlive(presetSizes);
		}
	}

	[Register("setAutoSizeTextTypeWithDefaults", "(Landroid/widget/TextView;I)V", "")]
	public unsafe static void SetAutoSizeTextTypeWithDefaults(TextView? textView, int autoSizeTextType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(autoSizeTextType);
			_members.StaticMethods.InvokeVoidMethod("setAutoSizeTextTypeWithDefaults.(Landroid/widget/TextView;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("setCompoundDrawableTintList", "(Landroid/widget/TextView;Landroid/content/res/ColorStateList;)V", "")]
	public unsafe static void SetCompoundDrawableTintList(TextView? textView, ColorStateList? tint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(tint?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setCompoundDrawableTintList.(Landroid/widget/TextView;Landroid/content/res/ColorStateList;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
			GC.KeepAlive(tint);
		}
	}

	[Register("setCompoundDrawableTintMode", "(Landroid/widget/TextView;Landroid/graphics/PorterDuff$Mode;)V", "")]
	public unsafe static void SetCompoundDrawableTintMode(TextView? textView, PorterDuff.Mode? tintMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(tintMode?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setCompoundDrawableTintMode.(Landroid/widget/TextView;Landroid/graphics/PorterDuff$Mode;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
			GC.KeepAlive(tintMode);
		}
	}

	[Obsolete("deprecated")]
	[Register("setCompoundDrawablesRelative", "(Landroid/widget/TextView;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;)V", "")]
	public unsafe static void SetCompoundDrawablesRelative(TextView? textView, Drawable? start, Drawable? top, Drawable? end, Drawable? bottom)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(top?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(end?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(bottom?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setCompoundDrawablesRelative.(Landroid/widget/TextView;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
			GC.KeepAlive(start);
			GC.KeepAlive(top);
			GC.KeepAlive(end);
			GC.KeepAlive(bottom);
		}
	}

	[Obsolete("deprecated")]
	[Register("setCompoundDrawablesRelativeWithIntrinsicBounds", "(Landroid/widget/TextView;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;)V", "")]
	public unsafe static void SetCompoundDrawablesRelativeWithIntrinsicBounds(TextView? textView, Drawable? start, Drawable? top, Drawable? end, Drawable? bottom)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(top?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(end?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(bottom?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setCompoundDrawablesRelativeWithIntrinsicBounds.(Landroid/widget/TextView;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
			GC.KeepAlive(start);
			GC.KeepAlive(top);
			GC.KeepAlive(end);
			GC.KeepAlive(bottom);
		}
	}

	[Obsolete("deprecated")]
	[Register("setCompoundDrawablesRelativeWithIntrinsicBounds", "(Landroid/widget/TextView;IIII)V", "")]
	public unsafe static void SetCompoundDrawablesRelativeWithIntrinsicBounds(TextView? textView, int start, int top, int end, int bottom)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(top);
			ptr[3] = new JniArgumentValue(end);
			ptr[4] = new JniArgumentValue(bottom);
			_members.StaticMethods.InvokeVoidMethod("setCompoundDrawablesRelativeWithIntrinsicBounds.(Landroid/widget/TextView;IIII)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Obsolete("deprecated")]
	[Register("setCustomSelectionActionModeCallback", "(Landroid/widget/TextView;Landroid/view/ActionMode$Callback;)V", "")]
	public unsafe static void SetCustomSelectionActionModeCallback(TextView? textView, ActionMode.ICallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members.StaticMethods.InvokeVoidMethod("setCustomSelectionActionModeCallback.(Landroid/widget/TextView;Landroid/view/ActionMode$Callback;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
			GC.KeepAlive(callback);
		}
	}

	[Register("setFirstBaselineToTopHeight", "(Landroid/widget/TextView;I)V", "")]
	public unsafe static void SetFirstBaselineToTopHeight(TextView? textView, int firstBaselineToTopHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(firstBaselineToTopHeight);
			_members.StaticMethods.InvokeVoidMethod("setFirstBaselineToTopHeight.(Landroid/widget/TextView;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("setLastBaselineToBottomHeight", "(Landroid/widget/TextView;I)V", "")]
	public unsafe static void SetLastBaselineToBottomHeight(TextView? textView, int lastBaselineToBottomHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(lastBaselineToBottomHeight);
			_members.StaticMethods.InvokeVoidMethod("setLastBaselineToBottomHeight.(Landroid/widget/TextView;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("setLineHeight", "(Landroid/widget/TextView;I)V", "")]
	public unsafe static void SetLineHeight(TextView? textView, int lineHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(lineHeight);
			_members.StaticMethods.InvokeVoidMethod("setLineHeight.(Landroid/widget/TextView;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("setLineHeight", "(Landroid/widget/TextView;IF)V", "")]
	public unsafe static void SetLineHeight(TextView? textView, int unit, float lineHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(unit);
			ptr[2] = new JniArgumentValue(lineHeight);
			_members.StaticMethods.InvokeVoidMethod("setLineHeight.(Landroid/widget/TextView;IF)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("setPrecomputedText", "(Landroid/widget/TextView;Landroidx/core/text/PrecomputedTextCompat;)V", "")]
	public unsafe static void SetPrecomputedText(TextView? textView, PrecomputedTextCompat? precomputed)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(precomputed?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setPrecomputedText.(Landroid/widget/TextView;Landroidx/core/text/PrecomputedTextCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
			GC.KeepAlive(precomputed);
		}
	}

	[Register("setTextAppearance", "(Landroid/widget/TextView;I)V", "")]
	public unsafe static void SetTextAppearance(TextView? textView, int resId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resId);
			_members.StaticMethods.InvokeVoidMethod("setTextAppearance.(Landroid/widget/TextView;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
		}
	}

	[Register("setTextMetricsParams", "(Landroid/widget/TextView;Landroidx/core/text/PrecomputedTextCompat$Params;)V", "")]
	public unsafe static void SetTextMetricsParams(TextView? textView, PrecomputedTextCompat.Params? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setTextMetricsParams.(Landroid/widget/TextView;Landroidx/core/text/PrecomputedTextCompat$Params;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(textView);
			GC.KeepAlive(@params);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("unwrapCustomSelectionActionModeCallback", "(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode$Callback;", "")]
	public unsafe static ActionMode.ICallback? UnwrapCustomSelectionActionModeCallback(ActionMode.ICallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActionMode.ICallback>(_members.StaticMethods.InvokeObjectMethod("unwrapCustomSelectionActionModeCallback.(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode$Callback;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("wrapCustomSelectionActionModeCallback", "(Landroid/widget/TextView;Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode$Callback;", "")]
	public unsafe static ActionMode.ICallback? WrapCustomSelectionActionModeCallback(TextView? textView, ActionMode.ICallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(textView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActionMode.ICallback>(_members.StaticMethods.InvokeObjectMethod("wrapCustomSelectionActionModeCallback.(Landroid/widget/TextView;Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode$Callback;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(textView);
			GC.KeepAlive(callback);
		}
	}
}
