using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeAssignment : CodeExpression
{
	private CodeValueReference var;

	private CodeExpression exp;

	public CodeAssignment(CodeValueReference var, CodeExpression exp)
	{
		if (var == null)
		{
			throw new ArgumentNullException("var");
		}
		if (exp == null)
		{
			throw new ArgumentNullException("exp");
		}
		this.exp = exp;
		this.var = var;
	}

	public override void Generate(ILGenerator gen)
	{
		var.GenerateSet(gen, exp);
		exp.Generate(gen);
	}

	public override void GenerateAsStatement(ILGenerator gen)
	{
		_ = exp;
		if (var.GetResultType() == typeof(object) && exp.GetResultType().IsValueType)
		{
			var.GenerateSet(gen, new CodeCast(typeof(object), exp));
		}
		else
		{
			var.GenerateSet(gen, exp);
		}
	}

	public override Type GetResultType()
	{
		return var.GetResultType();
	}
}
