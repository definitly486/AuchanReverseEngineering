using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresDynamicCode("Mono.Android.Export uses dynamic features.")]
[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeMethod
{
	private MethodBase methodBase;

	private CodeBuilder builder;

	private string name;

	private MethodAttributes attributes;

	private Type returnType;

	private TypeBuilder typeBuilder;

	private Type[] parameterTypes;

	private ArrayList customAttributes = new ArrayList();

	private CodeClass cls;

	public MethodBase MethodBase => methodBase;

	public Type ReturnType => returnType;

	public Type[] ParameterTypes => parameterTypes;

	public CodeBuilder CodeBuilder => builder;

	public bool IsStatic => (attributes & MethodAttributes.Static) != 0;

	internal CodeMethod(CodeClass cls, string name, MethodAttributes attributes, Type returnType, Type[] parameterTypes)
	{
		this.cls = cls;
		typeBuilder = cls.TypeBuilder;
		this.name = name;
		this.attributes = attributes;
		this.returnType = returnType;
		this.parameterTypes = parameterTypes;
		methodBase = typeBuilder.DefineMethod(name, attributes, returnType, parameterTypes);
		builder = new CodeBuilder(cls);
	}

	public CodeArgumentReference GetArg(int n)
	{
		if (n < 0 || n >= parameterTypes.Length)
		{
			throw new InvalidOperationException("Invalid argument number");
		}
		int argNum = (IsStatic ? n : (n + 1));
		return new CodeArgumentReference(parameterTypes[n], argNum, "arg" + n);
	}

	internal void Generate(ILGenerator gen)
	{
		Label label = gen.DefineLabel();
		builder.ReturnLabel = label;
		builder.Generate(gen);
		gen.MarkLabel(label);
		gen.Emit(OpCodes.Ret);
	}
}
