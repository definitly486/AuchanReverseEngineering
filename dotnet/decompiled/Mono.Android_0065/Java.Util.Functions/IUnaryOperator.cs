using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/UnaryOperator", "", "Java.Util.Functions.IUnaryOperatorInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "T" })]
public interface IUnaryOperator : IFunction, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/function/UnaryOperator", typeof(IUnaryOperator), isInterface: true);

	[SupportedOSPlatform("android24.0")]
	[JavaTypeParameters(new string[] { "T" })]
	static new unsafe IUnaryOperator? Identity()
	{
		return Java.Lang.Object.GetObject<IUnaryOperator>(_members.StaticMethods.InvokeObjectMethod("identity.()Ljava/util/function/UnaryOperator;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
