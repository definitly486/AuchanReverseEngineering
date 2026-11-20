using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.Core.OS;

[Register("androidx/core/os/LocaleListCompat", DoNotGenerateAcw = true)]
public sealed class LocaleListCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/os/LocaleListCompat", typeof(LocaleListCompat));

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

	public unsafe static LocaleListCompat? AdjustedDefault
	{
		[Register("getAdjustedDefault", "()Landroidx/core/os/LocaleListCompat;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.StaticMethods.InvokeObjectMethod("getAdjustedDefault.()Landroidx/core/os/LocaleListCompat;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static LocaleListCompat? Default
	{
		[Register("getDefault", "()Landroidx/core/os/LocaleListCompat;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.StaticMethods.InvokeObjectMethod("getDefault.()Landroidx/core/os/LocaleListCompat;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static LocaleListCompat? EmptyLocaleList
	{
		[Register("getEmptyLocaleList", "()Landroidx/core/os/LocaleListCompat;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.StaticMethods.InvokeObjectMethod("getEmptyLocaleList.()Landroidx/core/os/LocaleListCompat;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsEmpty
	{
		[Register("isEmpty", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);
		}
	}

	internal LocaleListCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("create", "([Ljava/util/Locale;)Landroidx/core/os/LocaleListCompat;", "")]
	public unsafe static LocaleListCompat? Create(params Locale[]? localeList)
	{
		nint num = JNIEnv.NewArray(localeList);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.StaticMethods.InvokeObjectMethod("create.([Ljava/util/Locale;)Landroidx/core/os/LocaleListCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (localeList != null)
			{
				JNIEnv.CopyArray(num, localeList);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(localeList);
		}
	}

	[Register("forLanguageTags", "(Ljava/lang/String;)Landroidx/core/os/LocaleListCompat;", "")]
	public unsafe static LocaleListCompat? ForLanguageTags(string? list)
	{
		nint num = JNIEnv.NewString(list);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.StaticMethods.InvokeObjectMethod("forLanguageTags.(Ljava/lang/String;)Landroidx/core/os/LocaleListCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("get", "(I)Ljava/util/Locale;", "")]
	public unsafe Locale? Get(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Locale>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(I)Ljava/util/Locale;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getFirstMatch", "([Ljava/lang/String;)Ljava/util/Locale;", "")]
	public unsafe Locale? GetFirstMatch(string[]? supportedLocales)
	{
		nint num = JNIEnv.NewArray(supportedLocales);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Locale>(_members.InstanceMethods.InvokeAbstractObjectMethod("getFirstMatch.([Ljava/lang/String;)Ljava/util/Locale;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (supportedLocales != null)
			{
				JNIEnv.CopyArray(num, supportedLocales);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(supportedLocales);
		}
	}

	[Register("indexOf", "(Ljava/util/Locale;)I", "")]
	public unsafe int IndexOf(Locale? locale)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locale?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractInt32Method("indexOf.(Ljava/util/Locale;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(locale);
		}
	}

	[Register("matchesLanguageAndScript", "(Ljava/util/Locale;Ljava/util/Locale;)Z", "")]
	public unsafe static bool MatchesLanguageAndScript(Locale? supported, Locale? desired)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(supported?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(desired?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("matchesLanguageAndScript.(Ljava/util/Locale;Ljava/util/Locale;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(supported);
			GC.KeepAlive(desired);
		}
	}

	[Register("size", "()I", "")]
	public unsafe int Size()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
	}

	[Register("toLanguageTags", "()Ljava/lang/String;", "")]
	public unsafe string? ToLanguageTags()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toLanguageTags.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("unwrap", "()Ljava/lang/Object;", "")]
	public unsafe Java.Lang.Object? Unwrap()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("unwrap.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("wrap", "(Landroid/os/LocaleList;)Landroidx/core/os/LocaleListCompat;", "")]
	public unsafe static LocaleListCompat? Wrap(LocaleList? localeList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(localeList?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.StaticMethods.InvokeObjectMethod("wrap.(Landroid/os/LocaleList;)Landroidx/core/os/LocaleListCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(localeList);
		}
	}

	[Obsolete("deprecated")]
	[Register("wrap", "(Ljava/lang/Object;)Landroidx/core/os/LocaleListCompat;", "")]
	public unsafe static LocaleListCompat? Wrap(Java.Lang.Object? localeList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(localeList?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.StaticMethods.InvokeObjectMethod("wrap.(Ljava/lang/Object;)Landroidx/core/os/LocaleListCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(localeList);
		}
	}
}
