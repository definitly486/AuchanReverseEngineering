using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

internal class CodeGenerationHelper
{
	public static void GenerateMethodCall(ILGenerator gen, CodeExpression target, MethodBase method, params CodeExpression[] parameters)
	{
		Type[] array = Type.EmptyTypes;
		if (parameters.Length != 0)
		{
			ParameterInfo[] parameters2 = method.GetParameters();
			array = new Type[parameters2.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = parameters2[i].ParameterType;
			}
		}
		GenerateMethodCall(gen, target, method, array, parameters);
	}

	public static void GenerateMethodCall(ILGenerator gen, CodeExpression target, CodeMethod method, params CodeExpression[] parameters)
	{
		GenerateMethodCall(gen, target, method.MethodBase, method.ParameterTypes, parameters);
	}

	private static void GenerateMethodCall(ILGenerator gen, CodeExpression target, MethodBase method, Type[] parameterTypes, params CodeExpression[] parameters)
	{
		if (parameterTypes.Length != parameters.Length)
		{
			throw GetMethodException(method, "Invalid number of parameters, expected " + parameterTypes.Length + ", found " + parameters.Length + ".");
		}
		OpCode opcode;
		if (target != null)
		{
			target.Generate(gen);
			Type resultType = target.GetResultType();
			if (resultType.IsValueType)
			{
				LocalBuilder local = gen.DeclareLocal(resultType);
				gen.Emit(OpCodes.Stloc, local);
				gen.Emit(OpCodes.Ldloca, local);
				opcode = OpCodes.Call;
			}
			else
			{
				opcode = OpCodes.Callvirt;
			}
		}
		else
		{
			opcode = OpCodes.Call;
		}
		for (int i = 0; i < parameterTypes.Length; i++)
		{
			try
			{
				CodeExpression codeExpression = parameters[i];
				codeExpression.Generate(gen);
				GenerateSafeConversion(gen, parameterTypes[i], codeExpression.GetResultType());
			}
			catch (InvalidOperationException ex)
			{
				throw GetMethodException(method, "Parameter " + i + ". " + ex.Message);
			}
		}
		if (method is MethodInfo)
		{
			gen.Emit(opcode, (MethodInfo)method);
		}
		else if (method is ConstructorInfo)
		{
			gen.Emit(opcode, (ConstructorInfo)method);
		}
	}

	public static Exception GetMethodException(MethodBase method, string msg)
	{
		return new InvalidOperationException("Call to method " + method.DeclaringType?.ToString() + "." + method.Name + ": " + msg);
	}

	public static void GenerateSafeConversion(ILGenerator gen, Type targetType, Type sourceType)
	{
		if (!targetType.IsAssignableFrom(sourceType))
		{
			throw new InvalidOperationException("Invalid type conversion. Found '" + sourceType?.ToString() + "', expected '" + targetType?.ToString() + "'.");
		}
		if (targetType == typeof(object) && sourceType.IsValueType)
		{
			gen.Emit(OpCodes.Box, sourceType);
		}
	}

	public static void LoadFromPtr(ILGenerator ig, Type t)
	{
		if (t == typeof(int))
		{
			ig.Emit(OpCodes.Ldind_I4);
		}
		else if (t == typeof(uint))
		{
			ig.Emit(OpCodes.Ldind_U4);
		}
		else if (t == typeof(short))
		{
			ig.Emit(OpCodes.Ldind_I2);
		}
		else if (t == typeof(ushort))
		{
			ig.Emit(OpCodes.Ldind_U2);
		}
		else if (t == typeof(char))
		{
			ig.Emit(OpCodes.Ldind_U2);
		}
		else if (t == typeof(byte))
		{
			ig.Emit(OpCodes.Ldind_U1);
		}
		else if (t == typeof(sbyte))
		{
			ig.Emit(OpCodes.Ldind_I1);
		}
		else if (t == typeof(ulong))
		{
			ig.Emit(OpCodes.Ldind_I8);
		}
		else if (t == typeof(long))
		{
			ig.Emit(OpCodes.Ldind_I8);
		}
		else if (t == typeof(float))
		{
			ig.Emit(OpCodes.Ldind_R4);
		}
		else if (t == typeof(double))
		{
			ig.Emit(OpCodes.Ldind_R8);
		}
		else if (t == typeof(bool))
		{
			ig.Emit(OpCodes.Ldind_I1);
		}
		else if (t == typeof(nint))
		{
			ig.Emit(OpCodes.Ldind_I);
		}
		else if (t.IsEnum)
		{
			if (t == typeof(Enum))
			{
				ig.Emit(OpCodes.Ldind_Ref);
			}
			else
			{
				LoadFromPtr(ig, Enum.GetUnderlyingType(t));
			}
		}
		else if (t.IsValueType)
		{
			ig.Emit(OpCodes.Ldobj, t);
		}
		else
		{
			ig.Emit(OpCodes.Ldind_Ref);
		}
	}

	public static void SaveToPtr(ILGenerator ig, Type t)
	{
		if (t == typeof(int))
		{
			ig.Emit(OpCodes.Stind_I4);
		}
		else if (t == typeof(uint))
		{
			ig.Emit(OpCodes.Stind_I4);
		}
		else if (t == typeof(short))
		{
			ig.Emit(OpCodes.Stind_I2);
		}
		else if (t == typeof(ushort))
		{
			ig.Emit(OpCodes.Stind_I2);
		}
		else if (t == typeof(char))
		{
			ig.Emit(OpCodes.Stind_I2);
		}
		else if (t == typeof(byte))
		{
			ig.Emit(OpCodes.Stind_I1);
		}
		else if (t == typeof(sbyte))
		{
			ig.Emit(OpCodes.Stind_I1);
		}
		else if (t == typeof(ulong))
		{
			ig.Emit(OpCodes.Stind_I8);
		}
		else if (t == typeof(long))
		{
			ig.Emit(OpCodes.Stind_I8);
		}
		else if (t == typeof(float))
		{
			ig.Emit(OpCodes.Stind_R4);
		}
		else if (t == typeof(double))
		{
			ig.Emit(OpCodes.Stind_R8);
		}
		else if (t == typeof(bool))
		{
			ig.Emit(OpCodes.Stind_I1);
		}
		else if (t == typeof(nint))
		{
			ig.Emit(OpCodes.Stind_I);
		}
		else if (t.IsEnum)
		{
			if (t == typeof(Enum))
			{
				ig.Emit(OpCodes.Stind_Ref);
			}
			else
			{
				SaveToPtr(ig, Enum.GetUnderlyingType(t));
			}
		}
		else if (t.IsValueType)
		{
			ig.Emit(OpCodes.Stobj, t);
		}
		else
		{
			ig.Emit(OpCodes.Stind_Ref);
		}
	}

	public static bool IsNumber(Type t)
	{
		TypeCode typeCode = Type.GetTypeCode(t);
		if ((uint)(typeCode - 5) <= 9u)
		{
			return true;
		}
		return false;
	}
}
