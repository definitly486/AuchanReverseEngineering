using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeCast : CodeExpression
{
	private Type type;

	private CodeExpression exp;

	public CodeCast(Type type, CodeExpression exp)
	{
		this.type = type;
		this.exp = exp;
	}

	public override void Generate(ILGenerator gen)
	{
		exp.Generate(gen);
		Type resultType = exp.GetResultType();
		if (type.IsAssignableFrom(resultType))
		{
			if (resultType.IsValueType)
			{
				gen.Emit(OpCodes.Box, resultType);
			}
			return;
		}
		if (type.IsValueType && resultType == typeof(object))
		{
			gen.Emit(OpCodes.Unbox, type);
			CodeGenerationHelper.LoadFromPtr(gen, type);
			return;
		}
		if (resultType.IsAssignableFrom(type))
		{
			gen.Emit(OpCodes.Castclass, type);
			return;
		}
		if (CodeGenerationHelper.IsNumber(type) && CodeGenerationHelper.IsNumber(resultType))
		{
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Byte:
				gen.Emit(OpCodes.Conv_U1);
				return;
			case TypeCode.Double:
				gen.Emit(OpCodes.Conv_R8);
				return;
			case TypeCode.Int16:
				gen.Emit(OpCodes.Conv_I2);
				return;
			case TypeCode.Int32:
				gen.Emit(OpCodes.Conv_I4);
				return;
			case TypeCode.Int64:
				gen.Emit(OpCodes.Conv_I8);
				return;
			case TypeCode.SByte:
				gen.Emit(OpCodes.Conv_I1);
				return;
			case TypeCode.Single:
				gen.Emit(OpCodes.Conv_R4);
				return;
			case TypeCode.UInt16:
				gen.Emit(OpCodes.Conv_U2);
				return;
			case TypeCode.UInt32:
				gen.Emit(OpCodes.Conv_U4);
				return;
			case TypeCode.UInt64:
				gen.Emit(OpCodes.Conv_U8);
				return;
			}
		}
		MethodInfo method = type.GetMethod("op_Implicit", new Type[1] { resultType });
		if (method != null)
		{
			gen.Emit(OpCodes.Call, method);
			return;
		}
		MemberInfo[] member = resultType.GetMember("op_Explicit");
		for (int i = 0; i < member.Length; i++)
		{
			MethodInfo methodInfo = (MethodInfo)member[i];
			if (methodInfo.ReturnType == type)
			{
				gen.Emit(OpCodes.Call, methodInfo);
				return;
			}
		}
		throw new InvalidOperationException("Can't cast from " + resultType?.ToString() + " to " + type);
	}

	public override Type GetResultType()
	{
		return type;
	}
}
