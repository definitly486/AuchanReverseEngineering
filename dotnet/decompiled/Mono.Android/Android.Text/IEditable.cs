using System;
using System.Collections;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/Editable", "", "Android.Text.IEditableInvoker")]
public interface IEditable : IGetChars, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable, ISpannable, ISpanned, IAppendable
{
	[Register("append", "(C)Landroid/text/Editable;", "GetAppend_CHandler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new IAppendable? Append(char text);

	[Register("append", "(Ljava/lang/CharSequence;II)Landroid/text/Editable;", "GetAppend_Ljava_lang_CharSequence_IIHandler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new IAppendable? Append(ICharSequence? text, int start, int end);

	[Register("append", "(Ljava/lang/CharSequence;)Landroid/text/Editable;", "GetAppend_Ljava_lang_CharSequence_Handler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new IAppendable? Append(ICharSequence? text);

	[Register("clear", "()V", "GetClearHandler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Clear();

	[Register("clearSpans", "()V", "GetClearSpansHandler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void ClearSpans();

	[Register("delete", "(II)Landroid/text/Editable;", "GetDelete_IIHandler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IEditable? Delete(int st, int en);

	[Register("getFilters", "()[Landroid/text/InputFilter;", "GetGetFiltersHandler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IInputFilter[]? GetFilters();

	[Register("insert", "(ILjava/lang/CharSequence;II)Landroid/text/Editable;", "GetInsert_ILjava_lang_CharSequence_IIHandler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IEditable? Insert(int where, ICharSequence? text, int start, int end);

	[Register("insert", "(ILjava/lang/CharSequence;)Landroid/text/Editable;", "GetInsert_ILjava_lang_CharSequence_Handler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IEditable? Insert(int where, ICharSequence? text);

	[Register("replace", "(IILjava/lang/CharSequence;II)Landroid/text/Editable;", "GetReplace_IILjava_lang_CharSequence_IIHandler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IEditable? Replace(int st, int en, ICharSequence? source, int start, int end);

	[Register("replace", "(IILjava/lang/CharSequence;)Landroid/text/Editable;", "GetReplace_IILjava_lang_CharSequence_Handler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IEditable? Replace(int st, int en, ICharSequence? text);

	[Register("setFilters", "([Landroid/text/InputFilter;)V", "GetSetFilters_arrayLandroid_text_InputFilter_Handler:Android.Text.IEditableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetFilters(IInputFilter[]? filters);
}
