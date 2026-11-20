namespace DryIoc.FastExpressionCompiler.LightExpression;

public enum NotSupported
{
	NewArrayInit_MultidimensionalArray,
	Quote,
	Dynamic,
	RuntimeVariables,
	MemberInit_MemberBinding,
	MemberInit_ListBinding,
	Try_GotoReturnToTheFollowupLabel,
	Assign_Target,
	TypeEqual
}
