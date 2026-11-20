using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/TextWatcher", "", "Android.Text.ITextWatcherInvoker")]
public interface ITextWatcher : INoCopySpan, IJavaObject, IDisposable, IJavaPeerable
{
	void AfterTextChanged(IEditable? s);

	void BeforeTextChanged(ICharSequence? s, int start, int count, int after);

	void OnTextChanged(ICharSequence? s, int start, int before, int count);
}
