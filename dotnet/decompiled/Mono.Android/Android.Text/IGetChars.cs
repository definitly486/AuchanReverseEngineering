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
	[Register("getChars", "(II[CI)V", "GetGetChars_IIarrayCIHandler:Android.Text.IGetCharsInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GetChars(int start, int end, char[]? dest, int destoff);
}
