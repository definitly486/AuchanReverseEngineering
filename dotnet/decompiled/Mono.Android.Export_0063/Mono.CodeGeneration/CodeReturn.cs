using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeReturn : CodeStatement
{
	private CodeExpression retValue;

	private CodeBuilder codeBuilder;

	internal CodeReturn(CodeBuilder codeBuilder, CodeExpression retValue)
	{
		this.codeBuilder = codeBuilder;
		this.retValue = retValue;
	}

	public override void Generate(ILGenerator gen)
	{
		if (retValue != null)
		{
			retValue.Generate(gen);
		}
		gen.Emit(OpCodes.Br, codeBuilder.ReturnLabel);
	}
}
