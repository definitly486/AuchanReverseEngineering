using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal abstract class CodeValueReference : CodeExpression
{
	public abstract void GenerateSet(ILGenerator gen, CodeExpression value);
}
