namespace System.Linq.Expressions;

internal static class Strings
{
	internal static string VariableMustNotBeByRef(object p0, object p1)
	{
		return System.SR.Format("VariableMustNotBeByRef", p0, p1);
	}

	internal static string AmbiguousMatchInExpandoObject(object p0)
	{
		return System.SR.Format("AmbiguousMatchInExpandoObject", p0);
	}

	internal static string SameKeyExistsInExpando(object p0)
	{
		return System.SR.Format("SameKeyExistsInExpando", p0);
	}

	internal static string KeyDoesNotExistInExpando(object p0)
	{
		return System.SR.Format("KeyDoesNotExistInExpando", p0);
	}

	internal static string InvalidMetaObjectCreated(object p0)
	{
		return System.SR.Format("InvalidMetaObjectCreated", p0);
	}

	internal static string BinderNotCompatibleWithCallSite(object p0, object p1, object p2)
	{
		return System.SR.Format("BinderNotCompatibleWithCallSite", p0, p1, p2);
	}

	internal static string DynamicBindingNeedsRestrictions(object p0, object p1)
	{
		return System.SR.Format("DynamicBindingNeedsRestrictions", p0, p1);
	}

	internal static string DynamicObjectResultNotAssignable(object p0, object p1, object p2, object p3)
	{
		return System.SR.Format("DynamicObjectResultNotAssignable", p0, p1, p2, p3);
	}

	internal static string DynamicBinderResultNotAssignable(object p0, object p1, object p2)
	{
		return System.SR.Format("DynamicBinderResultNotAssignable", p0, p1, p2);
	}

	internal static string DuplicateVariable(object p0)
	{
		return System.SR.Format("DuplicateVariable", p0);
	}

	internal static string TypeParameterIsNotDelegate(object p0)
	{
		return System.SR.Format("TypeParameterIsNotDelegate", p0);
	}

	internal static string ExtensionNodeMustOverrideProperty(object p0)
	{
		return System.SR.Format("ExtensionNodeMustOverrideProperty", p0);
	}

	internal static string UserDefinedOperatorMustBeStatic(object p0)
	{
		return System.SR.Format("UserDefinedOperatorMustBeStatic", p0);
	}

	internal static string UserDefinedOperatorMustNotBeVoid(object p0)
	{
		return System.SR.Format("UserDefinedOperatorMustNotBeVoid", p0);
	}

	internal static string CoercionOperatorNotDefined(object p0, object p1)
	{
		return System.SR.Format("CoercionOperatorNotDefined", p0, p1);
	}

	internal static string UnaryOperatorNotDefined(object p0, object p1)
	{
		return System.SR.Format("UnaryOperatorNotDefined", p0, p1);
	}

	internal static string BinaryOperatorNotDefined(object p0, object p1, object p2)
	{
		return System.SR.Format("BinaryOperatorNotDefined", p0, p1, p2);
	}

	internal static string ReferenceEqualityNotDefined(object p0, object p1)
	{
		return System.SR.Format("ReferenceEqualityNotDefined", p0, p1);
	}

	internal static string OperandTypesDoNotMatchParameters(object p0, object p1)
	{
		return System.SR.Format("OperandTypesDoNotMatchParameters", p0, p1);
	}

	internal static string OverloadOperatorTypeDoesNotMatchConversionType(object p0, object p1)
	{
		return System.SR.Format("OverloadOperatorTypeDoesNotMatchConversionType", p0, p1);
	}

	internal static string EqualityMustReturnBoolean(object p0)
	{
		return System.SR.Format("EqualityMustReturnBoolean", p0);
	}

	internal static string CannotAutoInitializeValueTypeElementThroughProperty(object p0)
	{
		return System.SR.Format("CannotAutoInitializeValueTypeElementThroughProperty", p0);
	}

	internal static string CannotAutoInitializeValueTypeMemberThroughProperty(object p0)
	{
		return System.SR.Format("CannotAutoInitializeValueTypeMemberThroughProperty", p0);
	}

	internal static string IncorrectTypeForTypeAs(object p0)
	{
		return System.SR.Format("IncorrectTypeForTypeAs", p0);
	}

	internal static string ExpressionTypeCannotInitializeArrayType(object p0, object p1)
	{
		return System.SR.Format("ExpressionTypeCannotInitializeArrayType", p0, p1);
	}

	internal static string ArgumentTypeDoesNotMatchMember(object p0, object p1)
	{
		return System.SR.Format("ArgumentTypeDoesNotMatchMember", p0, p1);
	}

	internal static string ArgumentMemberNotDeclOnType(object p0, object p1)
	{
		return System.SR.Format("ArgumentMemberNotDeclOnType", p0, p1);
	}

	internal static string ExpressionTypeDoesNotMatchReturn(object p0, object p1)
	{
		return System.SR.Format("ExpressionTypeDoesNotMatchReturn", p0, p1);
	}

	internal static string ExpressionTypeDoesNotMatchAssignment(object p0, object p1)
	{
		return System.SR.Format("ExpressionTypeDoesNotMatchAssignment", p0, p1);
	}

	internal static string ExpressionTypeDoesNotMatchLabel(object p0, object p1)
	{
		return System.SR.Format("ExpressionTypeDoesNotMatchLabel", p0, p1);
	}

	internal static string ExpressionTypeNotInvocable(object p0)
	{
		return System.SR.Format("ExpressionTypeNotInvocable", p0);
	}

	internal static string InstanceFieldNotDefinedForType(object p0, object p1)
	{
		return System.SR.Format("InstanceFieldNotDefinedForType", p0, p1);
	}

	internal static string FieldInfoNotDefinedForType(object p0, object p1, object p2)
	{
		return System.SR.Format("FieldInfoNotDefinedForType", p0, p1, p2);
	}

	internal static string MemberNotFieldOrProperty(object p0)
	{
		return System.SR.Format("MemberNotFieldOrProperty", p0);
	}

	internal static string MethodContainsGenericParameters(object p0)
	{
		return System.SR.Format("MethodContainsGenericParameters", p0);
	}

	internal static string MethodIsGeneric(object p0)
	{
		return System.SR.Format("MethodIsGeneric", p0);
	}

	internal static string MethodNotPropertyAccessor(object p0, object p1)
	{
		return System.SR.Format("MethodNotPropertyAccessor", p0, p1);
	}

	internal static string PropertyDoesNotHaveGetter(object p0)
	{
		return System.SR.Format("PropertyDoesNotHaveGetter", p0);
	}

	internal static string PropertyDoesNotHaveSetter(object p0)
	{
		return System.SR.Format("PropertyDoesNotHaveSetter", p0);
	}

	internal static string PropertyDoesNotHaveAccessor(object p0)
	{
		return System.SR.Format("PropertyDoesNotHaveAccessor", p0);
	}

	internal static string NotAMemberOfType(object p0, object p1)
	{
		return System.SR.Format("NotAMemberOfType", p0, p1);
	}

	internal static string NotAMemberOfAnyType(object p0)
	{
		return System.SR.Format("NotAMemberOfAnyType", p0);
	}

	internal static string ParameterExpressionNotValidAsDelegate(object p0, object p1)
	{
		return System.SR.Format("ParameterExpressionNotValidAsDelegate", p0, p1);
	}

	internal static string PropertyNotDefinedForType(object p0, object p1)
	{
		return System.SR.Format("PropertyNotDefinedForType", p0, p1);
	}

	internal static string InstancePropertyNotDefinedForType(object p0, object p1)
	{
		return System.SR.Format("InstancePropertyNotDefinedForType", p0, p1);
	}

	internal static string InstanceAndMethodTypeMismatch(object p0, object p1, object p2)
	{
		return System.SR.Format("InstanceAndMethodTypeMismatch", p0, p1, p2);
	}

	internal static string TypeMissingDefaultConstructor(object p0)
	{
		return System.SR.Format("TypeMissingDefaultConstructor", p0);
	}

	internal static string ElementInitializerMethodNoRefOutParam(object p0, object p1)
	{
		return System.SR.Format("ElementInitializerMethodNoRefOutParam", p0, p1);
	}

	internal static string TypeNotIEnumerable(object p0)
	{
		return System.SR.Format("TypeNotIEnumerable", p0);
	}

	internal static string UnhandledBinary(object p0)
	{
		return System.SR.Format("UnhandledBinary", p0);
	}

	internal static string UnhandledBindingType(object p0)
	{
		return System.SR.Format("UnhandledBindingType", p0);
	}

	internal static string UnhandledUnary(object p0)
	{
		return System.SR.Format("UnhandledUnary", p0);
	}

	internal static string UserDefinedOpMustHaveConsistentTypes(object p0, object p1)
	{
		return System.SR.Format("UserDefinedOpMustHaveConsistentTypes", p0, p1);
	}

	internal static string UserDefinedOpMustHaveValidReturnType(object p0, object p1)
	{
		return System.SR.Format("UserDefinedOpMustHaveValidReturnType", p0, p1);
	}

	internal static string LogicalOperatorMustHaveBooleanOperators(object p0, object p1)
	{
		return System.SR.Format("LogicalOperatorMustHaveBooleanOperators", p0, p1);
	}

	internal static string MethodWithArgsDoesNotExistOnType(object p0, object p1)
	{
		return System.SR.Format("MethodWithArgsDoesNotExistOnType", p0, p1);
	}

	internal static string GenericMethodWithArgsDoesNotExistOnType(object p0, object p1)
	{
		return System.SR.Format("GenericMethodWithArgsDoesNotExistOnType", p0, p1);
	}

	internal static string MethodWithMoreThanOneMatch(object p0, object p1)
	{
		return System.SR.Format("MethodWithMoreThanOneMatch", p0, p1);
	}

	internal static string LabelTargetAlreadyDefined(object p0)
	{
		return System.SR.Format("LabelTargetAlreadyDefined", p0);
	}

	internal static string LabelTargetUndefined(object p0)
	{
		return System.SR.Format("LabelTargetUndefined", p0);
	}

	internal static string AmbiguousJump(object p0)
	{
		return System.SR.Format("AmbiguousJump", p0);
	}

	internal static string NonLocalJumpWithValue(object p0)
	{
		return System.SR.Format("NonLocalJumpWithValue", p0);
	}

	internal static string InvalidLvalue(object p0)
	{
		return System.SR.Format("InvalidLvalue", p0);
	}

	internal static string UndefinedVariable(object p0, object p1, object p2)
	{
		return System.SR.Format("UndefinedVariable", p0, p1, p2);
	}

	internal static string CannotCloseOverByRef(object p0, object p1)
	{
		return System.SR.Format("CannotCloseOverByRef", p0, p1);
	}

	internal static string UnexpectedVarArgsCall(object p0)
	{
		return System.SR.Format("UnexpectedVarArgsCall", p0);
	}

	internal static string MustRewriteToSameNode(object p0, object p1, object p2)
	{
		return System.SR.Format("MustRewriteToSameNode", p0, p1, p2);
	}

	internal static string MustRewriteChildToSameType(object p0, object p1, object p2)
	{
		return System.SR.Format("MustRewriteChildToSameType", p0, p1, p2);
	}

	internal static string MustRewriteWithoutMethod(object p0, object p1)
	{
		return System.SR.Format("MustRewriteWithoutMethod", p0, p1);
	}

	internal static string TryNotSupportedForMethodsWithRefArgs(object p0)
	{
		return System.SR.Format("TryNotSupportedForMethodsWithRefArgs", p0);
	}

	internal static string TryNotSupportedForValueTypeInstances(object p0)
	{
		return System.SR.Format("TryNotSupportedForValueTypeInstances", p0);
	}

	internal static string TestValueTypeDoesNotMatchComparisonMethodParameter(object p0, object p1)
	{
		return System.SR.Format("TestValueTypeDoesNotMatchComparisonMethodParameter", p0, p1);
	}

	internal static string SwitchValueTypeDoesNotMatchComparisonMethodParameter(object p0, object p1)
	{
		return System.SR.Format("SwitchValueTypeDoesNotMatchComparisonMethodParameter", p0, p1);
	}

	internal static string ExpressionTypeDoesNotMatchConstructorParameter(object p0, object p1)
	{
		return System.SR.Format("ExpressionTypeDoesNotMatchConstructorParameter", p0, p1);
	}

	internal static string TypeContainsGenericParameters(object p0)
	{
		return System.SR.Format("TypeContainsGenericParameters", p0);
	}

	internal static string TypeIsGeneric(object p0)
	{
		return System.SR.Format("TypeIsGeneric", p0);
	}

	internal static string InvalidNullValue(object p0)
	{
		return System.SR.Format("InvalidNullValue", p0);
	}

	internal static string InvalidObjectType(object p0, object p1)
	{
		return System.SR.Format("InvalidObjectType", p0, p1);
	}

	internal static string ExpressionTypeDoesNotMatchMethodParameter(object p0, object p1, object p2)
	{
		return System.SR.Format("ExpressionTypeDoesNotMatchMethodParameter", p0, p1, p2);
	}

	internal static string ExpressionTypeDoesNotMatchParameter(object p0, object p1)
	{
		return System.SR.Format("ExpressionTypeDoesNotMatchParameter", p0, p1);
	}

	internal static string IncorrectNumberOfMethodCallArguments(object p0)
	{
		return System.SR.Format("IncorrectNumberOfMethodCallArguments", p0);
	}
}
