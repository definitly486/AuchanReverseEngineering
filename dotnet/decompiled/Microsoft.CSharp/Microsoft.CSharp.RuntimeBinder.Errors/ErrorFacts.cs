using System;

namespace Microsoft.CSharp.RuntimeBinder.Errors;

internal static class ErrorFacts
{
	public static string GetMessage(ErrorCode code)
	{
		return code switch
		{
			ErrorCode.ERR_BadBinaryOps => "BadBinaryOps", 
			ErrorCode.ERR_BadIndexLHS => "BadIndexLHS", 
			ErrorCode.ERR_BadIndexCount => "BadIndexCount", 
			ErrorCode.ERR_BadUnaryOp => "BadUnaryOp", 
			ErrorCode.ERR_NoImplicitConv => "NoImplicitConv", 
			ErrorCode.ERR_NoExplicitConv => "NoExplicitConv", 
			ErrorCode.ERR_ConstOutOfRange => "ConstOutOfRange", 
			ErrorCode.ERR_AmbigBinaryOps => "AmbigBinaryOps", 
			ErrorCode.ERR_AmbigUnaryOp => "AmbigUnaryOp", 
			ErrorCode.ERR_ValueCantBeNull => "ValueCantBeNull", 
			ErrorCode.ERR_NoSuchMember => "NoSuchMember", 
			ErrorCode.ERR_ObjectRequired => "ObjectRequired", 
			ErrorCode.ERR_AmbigCall => "AmbigCall", 
			ErrorCode.ERR_BadAccess => "BadAccess", 
			ErrorCode.ERR_AssgLvalueExpected => "AssgLvalueExpected", 
			ErrorCode.ERR_NoConstructors => "NoConstructors", 
			ErrorCode.ERR_PropertyLacksGet => "PropertyLacksGet", 
			ErrorCode.ERR_ObjectProhibited => "ObjectProhibited", 
			ErrorCode.ERR_AssgReadonly => "AssgReadonly", 
			ErrorCode.ERR_AssgReadonlyStatic => "AssgReadonlyStatic", 
			ErrorCode.ERR_AssgReadonlyProp => "AssgReadonlyProp", 
			ErrorCode.ERR_UnsafeNeeded => "UnsafeNeeded", 
			ErrorCode.ERR_BadBoolOp => "BadBoolOp", 
			ErrorCode.ERR_MustHaveOpTF => "MustHaveOpTF", 
			ErrorCode.ERR_ConstOutOfRangeChecked => "ConstOutOfRangeChecked", 
			ErrorCode.ERR_AmbigMember => "AmbigMember", 
			ErrorCode.ERR_NoImplicitConvCast => "NoImplicitConvCast", 
			ErrorCode.ERR_InaccessibleGetter => "InaccessibleGetter", 
			ErrorCode.ERR_InaccessibleSetter => "InaccessibleSetter", 
			ErrorCode.ERR_BadArity => "BadArity", 
			ErrorCode.ERR_TypeArgsNotAllowed => "TypeArgsNotAllowed", 
			ErrorCode.ERR_HasNoTypeVars => "HasNoTypeVars", 
			ErrorCode.ERR_NewConstraintNotSatisfied => "NewConstraintNotSatisfied", 
			ErrorCode.ERR_GenericConstraintNotSatisfiedRefType => "GenericConstraintNotSatisfiedRefType", 
			ErrorCode.ERR_GenericConstraintNotSatisfiedNullableEnum => "GenericConstraintNotSatisfiedNullableEnum", 
			ErrorCode.ERR_GenericConstraintNotSatisfiedNullableInterface => "GenericConstraintNotSatisfiedNullableInterface", 
			ErrorCode.ERR_GenericConstraintNotSatisfiedValType => "GenericConstraintNotSatisfiedValType", 
			ErrorCode.ERR_CantInferMethTypeArgs => "CantInferMethTypeArgs", 
			ErrorCode.ERR_RefConstraintNotSatisfied => "RefConstraintNotSatisfied", 
			ErrorCode.ERR_ValConstraintNotSatisfied => "ValConstraintNotSatisfied", 
			ErrorCode.ERR_AmbigUDConv => "AmbigUDConv", 
			ErrorCode.ERR_BindToBogus => "BindToBogus", 
			ErrorCode.ERR_CantCallSpecialMethod => "CantCallSpecialMethod", 
			ErrorCode.ERR_ConvertToStaticClass => "ConvertToStaticClass", 
			ErrorCode.ERR_IncrementLvalueExpected => "IncrementLvalueExpected", 
			ErrorCode.ERR_BadArgCount => "BadArgCount", 
			ErrorCode.ERR_BadArgTypes => "BadArgTypes", 
			ErrorCode.ERR_BadProtectedAccess => "BadProtectedAccess", 
			ErrorCode.ERR_BindToBogusProp2 => "BindToBogusProp2", 
			ErrorCode.ERR_BindToBogusProp1 => "BindToBogusProp1", 
			ErrorCode.ERR_BadDelArgCount => "BadDelArgCount", 
			ErrorCode.ERR_BadDelArgTypes => "BadDelArgTypes", 
			ErrorCode.ERR_BadCtorArgCount => "BadCtorArgCount", 
			ErrorCode.ERR_NonInvocableMemberCalled => "NonInvocableMemberCalled", 
			ErrorCode.ERR_BadNamedArgument => "BadNamedArgument", 
			ErrorCode.ERR_BadNamedArgumentForDelegateInvoke => "BadNamedArgumentForDelegateInvoke", 
			ErrorCode.ERR_DuplicateNamedArgument => "DuplicateNamedArgument", 
			ErrorCode.ERR_NamedArgumentUsedInPositional => "NamedArgumentUsedInPositional", 
			ErrorCode.ERR_BadNonTrailingNamedArgument => "BadNonTrailingNamedArgument", 
			ErrorCode.ERR_DynamicBindingComUnsupported => "DynamicBindingComUnsupported", 
			_ => null, 
		};
	}

	public static string GetMessage(MessageID id)
	{
		string text = id.ToString();
		return System.SR.GetResourceString(text, text);
	}
}
