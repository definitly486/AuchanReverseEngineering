using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeEquals : CodeConditionExpression
{
	private CodeExpression exp1;

	private CodeExpression exp2;

	private Type t1;

	private Type t2;

	public CodeEquals(CodeExpression exp1, CodeExpression exp2)
	{
		this.exp1 = exp1;
		this.exp2 = exp2;
		t1 = exp1.GetResultType();
		t2 = exp2.GetResultType();
		if (t1.IsValueType && t2.IsValueType && t1 != t2)
		{
			throw new InvalidOperationException("Can't compare values of different primitive types");
		}
	}

	public override void Generate(ILGenerator gen)
	{
		if (t1.IsPrimitive)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Ceq);
		}
		else
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.EmitCall(OpCodes.Callvirt, t1.GetMethod("Equals", new Type[1] { t2 }), null);
		}
	}

	public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
	{
		if (t1.IsPrimitive)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			if (branchCase)
			{
				gen.Emit(OpCodes.Beq, label);
			}
			else
			{
				gen.Emit(OpCodes.Bne_Un, label);
			}
		}
		else
		{
			Generate(gen);
			if (branchCase)
			{
				gen.Emit(OpCodes.Brtrue, label);
			}
			else
			{
				gen.Emit(OpCodes.Brfalse, label);
			}
		}
	}

	public override Type GetResultType()
	{
		return typeof(bool);
	}
}
