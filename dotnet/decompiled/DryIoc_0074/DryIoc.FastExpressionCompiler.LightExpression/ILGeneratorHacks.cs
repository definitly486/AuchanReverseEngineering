using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public static class ILGeneratorHacks
{
	private static readonly Func<ILGenerator, Type, int> _getNextLocalVarIndex;

	internal static int PostInc(ref int i)
	{
		return i++;
	}

	static ILGeneratorHacks()
	{
		_getNextLocalVarIndex = (ILGenerator i, Type t) => i.DeclareLocal(t).LocalIndex;
		TypeInfo typeInfo = typeof(ILGenerator).GetTypeInfo();
		FieldInfo declaredField = typeInfo.GetDeclaredField("m_localSignature");
		if (declaredField == null)
		{
			return;
		}
		FieldInfo declaredField2 = typeInfo.GetDeclaredField("m_localCount");
		if (declaredField2 == null)
		{
			return;
		}
		MethodInfo methodInfo = null;
		foreach (MethodInfo declaredMethod2 in typeof(SignatureHelper).GetTypeInfo().GetDeclaredMethods("AddArgument"))
		{
			ParameterInfo[] parameters = declaredMethod2.GetParameters();
			if (parameters.Length == 2 && parameters[0].ParameterType == typeof(Type) && parameters[1].ParameterType == typeof(bool))
			{
				methodInfo = declaredMethod2;
				break;
			}
		}
		if (!(methodInfo == null))
		{
			MethodInfo declaredMethod = typeof(ILGeneratorHacks).GetTypeInfo().GetDeclaredMethod("PostInc");
			DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(int), new Type[3]
			{
				typeof(ExpressionCompiler.ArrayClosure),
				typeof(ILGenerator),
				typeof(Type)
			}, typeof(ExpressionCompiler.ArrayClosure), skipVisibility: true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Ldfld, declaredField);
			iLGenerator.Emit(OpCodes.Ldarg_2);
			iLGenerator.Emit(OpCodes.Ldc_I4_0);
			iLGenerator.Emit(OpCodes.Call, methodInfo);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Ldflda, declaredField2);
			iLGenerator.Emit(OpCodes.Call, declaredMethod);
			iLGenerator.Emit(OpCodes.Ret);
			_getNextLocalVarIndex = (Func<ILGenerator, Type, int>)dynamicMethod.CreateDelegate(typeof(Func<ILGenerator, Type, int>), ExpressionCompiler.EmptyArrayClosure);
		}
	}

	public static int GetNextLocalVarIndex(this ILGenerator il, Type t)
	{
		return _getNextLocalVarIndex(il, t);
	}
}
