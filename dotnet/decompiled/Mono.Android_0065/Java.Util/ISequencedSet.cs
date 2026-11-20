using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/SequencedSet", "", "Java.Util.ISequencedSetInvoker", ApiSince = 35)]
[JavaTypeParameters(new string[] { "E" })]
public interface ISequencedSet : ISequencedCollection, ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable, ISet
{
}
