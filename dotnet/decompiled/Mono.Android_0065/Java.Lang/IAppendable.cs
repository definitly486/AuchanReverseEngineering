using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Appendable", "", "Java.Lang.IAppendableInvoker")]
public interface IAppendable : IJavaObject, IDisposable, IJavaPeerable
{
	IAppendable Append(char c);

	IAppendable Append(ICharSequence? csq, int start, int end);

	IAppendable Append(ICharSequence? csq);
}
