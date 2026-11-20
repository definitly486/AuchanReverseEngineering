using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeVariableDeclaration : CodeStatement
{
	private CodeVariableReference var;

	public CodeVariableReference Variable => var;

	public CodeVariableDeclaration(Type type, string name)
	{
		var = new CodeVariableReference(type, name);
	}

	public override void Generate(ILGenerator gen)
	{
		var.LocalBuilder = gen.DeclareLocal(var.Type);
	}
}
