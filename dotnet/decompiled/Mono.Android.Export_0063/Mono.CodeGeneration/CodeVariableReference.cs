using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeVariableReference : CodeValueReference
{
	private LocalBuilder localBuilder;

	private Type type;

	private string name;

	public Type Type => type;

	internal LocalBuilder LocalBuilder
	{
		set
		{
			localBuilder = value;
		}
	}

	public CodeVariableReference(Type type, string name)
	{
		this.type = type;
		this.name = name;
	}

	public override void Generate(ILGenerator gen)
	{
		gen.Emit(OpCodes.Ldloc, localBuilder);
	}

	public override void GenerateSet(ILGenerator gen, CodeExpression value)
	{
		value.Generate(gen);
		CodeGenerationHelper.GenerateSafeConversion(gen, type, value.GetResultType());
		gen.Emit(OpCodes.Stloc, localBuilder);
	}

	public override Type GetResultType()
	{
		return type;
	}
}
