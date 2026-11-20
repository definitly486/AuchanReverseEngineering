using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/InputFilter", "", "Android.Text.IInputFilterInvoker")]
public interface IInputFilter : IJavaObject, IDisposable, IJavaPeerable
{
	ICharSequence? FilterFormatted(ICharSequence? source, int start, int end, ISpanned? dest, int dstart, int dend);
}
