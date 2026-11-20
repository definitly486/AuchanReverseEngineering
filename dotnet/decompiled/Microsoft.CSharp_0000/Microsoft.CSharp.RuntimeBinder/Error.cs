using System;

namespace Microsoft.CSharp.RuntimeBinder;

internal static class Error
{
	internal static Exception InternalCompilerError()
	{
		return new RuntimeBinderInternalCompilerException("InternalCompilerError");
	}

	internal static Exception BindPropertyFailedMethodGroup(object p0)
	{
		return new RuntimeBinderException(System.SR.Format("BindPropertyFailedMethodGroup", p0));
	}

	internal static Exception BindPropertyFailedEvent(object p0)
	{
		return new RuntimeBinderException(System.SR.Format("BindPropertyFailedEvent", p0));
	}

	internal static Exception BindInvokeFailedNonDelegate()
	{
		return new RuntimeBinderException("BindInvokeFailedNonDelegate");
	}

	internal static Exception BindStaticRequiresType(string paramName)
	{
		return new ArgumentException("TypeArgumentRequiredForStaticCall", paramName);
	}

	internal static Exception NullReferenceOnMemberException()
	{
		return new RuntimeBinderException("NullReferenceOnMemberException");
	}

	internal static Exception BindCallToConditionalMethod(object p0)
	{
		return new RuntimeBinderException(System.SR.Format("BindCallToConditionalMethod", p0));
	}

	internal static Exception BindToVoidMethodButExpectResult()
	{
		return new RuntimeBinderException("BindToVoidMethodButExpectResult");
	}

	internal static Exception DynamicArgumentNeedsValue(string paramName)
	{
		return new ArgumentException("DynamicArgumentNeedsValue", paramName);
	}
}
