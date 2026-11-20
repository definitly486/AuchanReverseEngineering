using System;
using Android.Database;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/FilterQueryProvider", "", "Android.Widget.IFilterQueryProviderInvoker")]
public interface IFilterQueryProvider : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("runQuery", "(Ljava/lang/CharSequence;)Landroid/database/Cursor;", "GetRunQuery_Ljava_lang_CharSequence_Handler:Android.Widget.IFilterQueryProviderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ICursor? RunQuery(ICharSequence? constraint);
}
