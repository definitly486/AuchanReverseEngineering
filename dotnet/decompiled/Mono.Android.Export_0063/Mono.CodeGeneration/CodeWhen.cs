using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeWhen : CodeExpression
{
	private CodeExpression condition;

	private CodeExpression trueBlock;

	private CodeExpression falseBlock;

	public CodeWhen(CodeExpression condition, CodeExpression trueResult, CodeExpression falseResult)
	{
		this.condition = condition;
		if (condition.GetResultType() != typeof(bool))
		{
			throw new InvalidOperationException("Condition expression is not boolean");
		}
		if (trueResult.GetResultType() != falseResult.GetResultType())
		{
			throw new InvalidOperationException("The types of the true and false expressions must be the same");
		}
		trueBlock = trueResult;
		falseBlock = falseResult;
	}

	public override void Generate(ILGenerator gen)
	{
		Label label = gen.DefineLabel();
		Label label2 = gen.DefineLabel();
		GenerateCondition(gen, label);
		trueBlock.Generate(gen);
		gen.Emit(OpCodes.Br, label2);
		gen.MarkLabel(label);
		falseBlock.Generate(gen);
		gen.MarkLabel(label2);
	}

	private void GenerateCondition(ILGenerator gen, Label falseLabel)
	{
		if (condition is CodeConditionExpression)
		{
			((CodeConditionExpression)condition).GenerateForBranch(gen, falseLabel, jumpCase: false);
			return;
		}
		condition.Generate(gen);
		gen.Emit(OpCodes.Brfalse, falseLabel);
	}

	public override Type GetResultType()
	{
		return trueBlock.GetResultType();
	}
}
