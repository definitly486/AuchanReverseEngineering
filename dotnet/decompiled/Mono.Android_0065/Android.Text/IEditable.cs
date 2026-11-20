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
	new IAppendable? Append(char text);

	new IAppendable? Append(ICharSequence? text, int start, int end);

	new IAppendable? Append(ICharSequence? text);

	void Clear();

	void ClearSpans();

	IEditable? Delete(int st, int en);

	IInputFilter[]? GetFilters();

	IEditable? Insert(int where, ICharSequence? text, int start, int end);

	IEditable? Insert(int where, ICharSequence? text);

	IEditable? Replace(int st, int en, ICharSequence? source, int start, int end);

	IEditable? Replace(int st, int en, ICharSequence? text);

	void SetFilters(IInputFilter[]? filters);
}
