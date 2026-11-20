using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;
using Android.Runtime;
using Java.Lang;
using Mono.CodeGeneration;

namespace Java.Interop;

[RequiresDynamicCode("Mono.Android.Export uses dynamic features.")]
[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class DynamicCallbackCodeGenerator : CallbackCodeGenerator<Type>
{
	private MethodInfo method;

	private Type delegate_type;

	private static readonly Type[] DelegateCtorSignature = new Type[2]
	{
		typeof(object),
		typeof(nint)
	};

	private static int gen_count;

	private static readonly MethodInfo get_object_method = typeof(Java.Lang.Object).GetMethod("GetObject", new Type[3]
	{
		typeof(nint),
		typeof(nint),
		typeof(JniHandleOwnership)
	});

	private static readonly CodeLiteral do_not_transfer_literal = new CodeLiteral(JniHandleOwnership.DoNotTransfer);

	private Delegate result;

	private DynamicInvokeTypeInfo return_type_info;

	private List<DynamicInvokeTypeInfo> parameter_type_infos;

	public static Delegate Create(MethodInfo method)
	{
		return new DynamicCallbackCodeGenerator(method).GetCallback();
	}

	private static ExportParameterKind GetExportKind(ICustomAttributeProvider m)
	{
		object[] customAttributes = m.GetCustomAttributes(typeof(ExportParameterAttribute), inherit: false);
		int num = 0;
		if (num < customAttributes.Length)
		{
			return ((ExportParameterAttribute)customAttributes[num]).Kind;
		}
		return ExportParameterKind.Unspecified;
	}

	public DynamicCallbackCodeGenerator(MethodInfo method)
	{
		this.method = method;
		return_type_info = DynamicInvokeTypeInfo.Get(method.ReturnType, GetExportKind(method.ReturnParameter));
		List<DynamicInvokeTypeInfo> list = new List<DynamicInvokeTypeInfo>();
		ParameterInfo[] parameters = method.GetParameters();
		foreach (ParameterInfo parameterInfo in parameters)
		{
			list.Add(DynamicInvokeTypeInfo.Get(parameterInfo.ParameterType, GetExportKind(parameterInfo)));
		}
		parameter_type_infos = list;
	}

	public override Type GetDelegateType()
	{
		if (delegate_type == null)
		{
			string text = "callback_delegate_" + EncodeMethodSignature(parameter_type_infos, return_type_info);
			lock (DynamicCallbackFactory.Module)
			{
				delegate_type = DynamicCallbackFactory.Module.GetType(text) ?? CreateDelegateType(text);
			}
		}
		return delegate_type;
		Type CreateDelegateType(string delegateTypeName)
		{
			TypeBuilder typeBuilder = DynamicCallbackFactory.Module.DefineType(delegateTypeName, TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.AutoClass, typeof(MulticastDelegate));
			Type[] array = new Type[parameter_type_infos.Count + 2];
			array[0] = typeof(nint);
			array[1] = typeof(nint);
			for (int i = 0; i < parameter_type_infos.Count; i++)
			{
				array[i + 2] = parameter_type_infos[i].NativeType;
			}
			typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.RTSpecialName, CallingConventions.Standard, DelegateCtorSignature).SetImplementationFlags(MethodImplAttributes.CodeTypeMask);
			typeBuilder.DefineMethod("Invoke", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask, return_type_info.NativeType, array).SetImplementationFlags(MethodImplAttributes.CodeTypeMask);
			return typeBuilder.CreateTypeInfo();
		}
		static string EncodeMethodSignature(List<DynamicInvokeTypeInfo> parameter_types, DynamicInvokeTypeInfo return_type)
		{
			return string.Create(parameter_types.Count + 2, (parameter_types, return_type), delegate(Span<char> span, (List<DynamicInvokeTypeInfo> parameter_types, DynamicInvokeTypeInfo return_type) state)
			{
				int num = 0;
				foreach (DynamicInvokeTypeInfo item in state.parameter_types)
				{
					span[num++] = EncodeType(item.NativeType);
				}
				span[num++] = '_';
				span[num++] = EncodeType(state.return_type.NativeType);
			});
		}
		static char EncodeType(Type type)
		{
			if (type == typeof(bool))
			{
				return 'Z';
			}
			if (type == typeof(byte))
			{
				return 'B';
			}
			if (type == typeof(sbyte))
			{
				return 'B';
			}
			if (type == typeof(char))
			{
				return 'C';
			}
			if (type == typeof(short))
			{
				return 'S';
			}
			if (type == typeof(ushort))
			{
				return 's';
			}
			if (type == typeof(int))
			{
				return 'I';
			}
			if (type == typeof(uint))
			{
				return 'i';
			}
			if (type == typeof(long))
			{
				return 'J';
			}
			if (type == typeof(ulong))
			{
				return 'j';
			}
			if (type == typeof(float))
			{
				return 'F';
			}
			if (type == typeof(double))
			{
				return 'D';
			}
			if (type == typeof(void))
			{
				return 'V';
			}
			return 'L';
		}
	}

	public Delegate GetCallback()
	{
		if ((object)result == null)
		{
			GenerateNativeCallbackDelegate();
		}
		return result;
	}

	public override void GenerateNativeCallbackDelegate()
	{
		int num;
		lock (DynamicCallbackFactory.Module)
		{
			num = gen_count++;
		}
		string text = "dynamic_callback_" + num;
		List<Type> list = new List<Type>();
		list.Add(typeof(nint));
		list.Add(typeof(nint));
		list.AddRange(parameter_type_infos.ConvertAll((DynamicInvokeTypeInfo p) => p.NativeType).ToArray());
		CodeMethod codeMethod = GenerateNativeCallbackDelegate(text);
		DynamicMethod dynamicMethod = new DynamicMethod(text, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, return_type_info.NativeType, list.ToArray(), DynamicCallbackFactory.Module, skipVisibility: true);
		codeMethod.Generate(dynamicMethod.GetILGenerator());
		result = dynamicMethod.CreateDelegate(GetDelegateType());
	}

	private CodeMethod GenerateNativeCallbackDelegate(string generatedMethodName)
	{
		List<Type> list = new List<Type>();
		list.Add(typeof(nint));
		list.Add(typeof(nint));
		list.AddRange(parameter_type_infos.ConvertAll((DynamicInvokeTypeInfo p) => p.NativeType).ToArray());
		CodeMethod codeMethod = DynamicCallbackFactory.CodeClass.CreateMethod(generatedMethodName, MethodAttributes.Static, return_type_info.NativeType, list.ToArray());
		CodeBuilder codeBuilder = codeMethod.CodeBuilder;
		CodeVariableReference target = null;
		if (!method.IsStatic)
		{
			target = codeBuilder.DeclareVariable(method.DeclaringType, new CodeMethodCall(get_object_method.MakeGenericMethod(method.DeclaringType), codeMethod.GetArg(0), codeMethod.GetArg(1), do_not_transfer_literal));
		}
		List<CodeExpression> list2 = new List<CodeExpression>();
		for (int num = 0; num < parameter_type_infos.Count; num++)
		{
			if (parameter_type_infos[num].NeedsPrep)
			{
				list2.Add(parameter_type_infos[num].PrepareCallback(codeMethod.GetArg(num + 2)));
			}
			else
			{
				list2.Add(parameter_type_infos[num].FromNative(codeMethod.GetArg(num + 2)));
			}
		}
		CodeMethodCall codeMethodCall = ((!method.IsStatic) ? new CodeMethodCall(target, method, list2.ToArray()) : new CodeMethodCall(method, list2.ToArray()));
		CodeExpression exp = null;
		if (method.ReturnType == typeof(void))
		{
			codeBuilder.CurrentBlock.Add(codeMethodCall);
		}
		else
		{
			exp = codeBuilder.DeclareVariable(return_type_info.NativeType, return_type_info.ToNative(codeMethodCall));
		}
		new List<CodeStatement>();
		for (int num2 = 0; num2 < parameter_type_infos.Count; num2++)
		{
			codeBuilder.CurrentBlock.Add(parameter_type_infos[num2].CleanupCallback(list2[num2], codeMethod.GetArg(num2)));
		}
		if (method.ReturnType != typeof(void))
		{
			codeBuilder.Return(exp);
		}
		return codeMethod;
	}
}
