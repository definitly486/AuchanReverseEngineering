using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeBlock : CodeItem
{
	private ArrayList statements = new ArrayList();

	public void Add(CodeItem code)
	{
		statements.Add(code);
	}

	public static CodeBlock operator +(CodeBlock cb, CodeExpression e)
	{
		cb.Add(e);
		return cb;
	}

	public override void Generate(ILGenerator gen)
	{
		foreach (CodeItem statement in statements)
		{
			if (statement is CodeExpression)
			{
				((CodeExpression)statement).GenerateAsStatement(gen);
			}
			else
			{
				statement.Generate(gen);
			}
		}
	}
}
