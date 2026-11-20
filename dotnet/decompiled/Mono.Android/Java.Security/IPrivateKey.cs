using System;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Java.Security;

[Register("java/security/PrivateKey", "", "Java.Security.IPrivateKeyInvoker")]
public interface IPrivateKey : IKey, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
}
