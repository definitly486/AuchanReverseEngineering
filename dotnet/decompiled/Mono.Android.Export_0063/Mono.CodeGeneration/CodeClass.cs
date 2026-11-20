using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresDynamicCode("Mono.Android.Export uses dynamic features.")]
[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeClass
{
	private TypeBuilder typeBuilder;

	private ArrayList customAttributes = new ArrayList();

	private ArrayList methods = new ArrayList();

	private ArrayList properties = new ArrayList();

	private ArrayList fields = new ArrayList();

	private Hashtable fieldAttributes = new Hashtable();

	private Type baseType;

	private Type[] interfaces;

	private int varId;

	public TypeBuilder TypeBuilder => typeBuilder;

	public CodeClass(ModuleBuilder mb, string name)
		: this(mb, name, TypeAttributes.Public, typeof(object))
	{
	}

	public CodeClass(ModuleBuilder mb, string name, TypeAttributes attr, Type baseType, params Type[] interfaces)
	{
		typeBuilder = mb.DefineType(name, attr, baseType, interfaces);
		this.baseType = baseType;
		this.interfaces = interfaces;
	}

	public CodeMethod CreateMethod(string name, MethodAttributes attributes, Type returnType, params Type[] parameterTypes)
	{
		CodeMethod codeMethod = new CodeMethod(this, GetMethodName(name), attributes, returnType, parameterTypes);
		methods.Add(codeMethod);
		return codeMethod;
	}

	private string GetMethodName(string name)
	{
		if (name == null)
		{
			return "__Method_" + varId++;
		}
		return name;
	}
}
