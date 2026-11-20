using System;
using System.Collections;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/GetChars", "", "Android.Text.IGetCharsInvoker")]
public interface IGetChars : ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	void GetChars(int start, int end, char[]? dest, int destoff);
}
