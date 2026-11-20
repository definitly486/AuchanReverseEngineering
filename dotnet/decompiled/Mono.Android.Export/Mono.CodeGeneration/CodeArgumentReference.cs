using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeArgumentReference : CodeValueReference
{
	private Type type;

	private int argNum;

	private string name;

	public CodeArgumentReference(Type type, int argNum, string name)
	{
		this.type = type;
		this.argNum = argNum;
		this.name = name;
	}

	public override void Generate(ILGenerator gen)
	{
		switch (argNum)
		{
		case 0:
			gen.Emit(OpCodes.Ldarg_0);
			break;
		case 1:
			gen.Emit(OpCodes.Ldarg_1);
			break;
		case 2:
			gen.Emit(OpCodes.Ldarg_2);
			break;
		case 3:
			gen.Emit(OpCodes.Ldarg_3);
			break;
		default:
			gen.Emit(OpCodes.Ldarg, argNum);
			break;
		}
		if (type.IsByRef)
		{
			CodeGenerationHelper.LoadFromPtr(gen, type.GetElementType());
		}
	}

	public override void GenerateSet(ILGenerator gen, CodeExpression value)
	{
		if (type.IsByRef)
		{
			gen.Emit(OpCodes.Ldarg, argNum);
			value.Generate(gen);
			CodeGenerationHelper.GenerateSafeConversion(gen, type.GetElementType(), value.GetResultType());
			CodeGenerationHelper.SaveToPtr(gen, type.GetElementType());
		}
		else
		{
			value.Generate(gen);
			CodeGenerationHelper.GenerateSafeConversion(gen, type, value.GetResultType());
			gen.Emit(OpCodes.Starg, argNum);
		}
	}

	public override Type GetResultType()
	{
		if (!type.IsByRef)
		{
			return type;
		}
		return type.GetElementType();
	}
}
