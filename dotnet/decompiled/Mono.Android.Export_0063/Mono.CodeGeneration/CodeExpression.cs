using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[DefaultMember("Item")]
[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal abstract class CodeExpression : CodeItem
{
	public CodeExpression IsNull => new CodeEquals(this, new CodeLiteral(null, GetResultType()));

	public abstract Type GetResultType();

	public virtual void GenerateAsStatement(ILGenerator gen)
	{
		Generate(gen);
		gen.Emit(OpCodes.Pop);
	}

	public CodeExpression CastTo(Type type)
	{
		return new CodeCast(type, this);
	}
}
