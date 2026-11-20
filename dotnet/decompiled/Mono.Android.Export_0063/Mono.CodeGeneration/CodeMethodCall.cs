using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeMethodCall : CodeExpression
{
	private CodeExpression target;

	private CodeExpression[] parameters;

	private MethodBase method;

	private CodeMethod codeMethod;

	public CodeMethodCall(CodeExpression target, MethodBase method, params CodeExpression[] parameters)
	{
		this.target = target;
		this.parameters = parameters;
		this.method = method;
	}

	public CodeMethodCall(MethodInfo method, params CodeExpression[] parameters)
	{
		this.parameters = parameters;
		this.method = method;
	}

	public override void Generate(ILGenerator gen)
	{
		if (codeMethod != null)
		{
			CodeGenerationHelper.GenerateMethodCall(gen, target, codeMethod, parameters);
		}
		else
		{
			CodeGenerationHelper.GenerateMethodCall(gen, target, method, parameters);
		}
	}

	public override void GenerateAsStatement(ILGenerator gen)
	{
		Generate(gen);
		if (GetResultType() != typeof(void))
		{
			gen.Emit(OpCodes.Pop);
		}
	}

	public override Type GetResultType()
	{
		if (codeMethod != null)
		{
			return codeMethod.ReturnType;
		}
		if (method is MethodInfo)
		{
			return ((MethodInfo)method).ReturnType;
		}
		return typeof(void);
	}
}
