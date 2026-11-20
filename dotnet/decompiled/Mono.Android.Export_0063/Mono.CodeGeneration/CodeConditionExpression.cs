using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal abstract class CodeConditionExpression : CodeExpression
{
	public virtual void GenerateForBranch(ILGenerator gen, Label label, bool jumpCase)
	{
		Generate(gen);
		if (jumpCase)
		{
			gen.Emit(OpCodes.Brtrue, label);
		}
		else
		{
			gen.Emit(OpCodes.Brfalse, label);
		}
	}
}
