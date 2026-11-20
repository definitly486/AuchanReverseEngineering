using System;
using Android.Runtime;
using Java.Interop;

namespace Java.IO;

[Register("java/io/Serializable", "", "Java.IO.ISerializableInvoker")]
public interface ISerializable : IJavaObject, IDisposable, IJavaPeerable
{
}
