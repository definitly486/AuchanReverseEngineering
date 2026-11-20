using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeBuilder
{
	private CodeBlock mainBlock;

	private CodeBlock currentBlock;

	private Stack blockStack = new Stack();

	private int varId;

	private Label returnLabel;

	private ArrayList nestedIfs = new ArrayList();

	private int currentIfSerie = -1;

	private CodeClass codeClass;

	public CodeBlock CurrentBlock => currentBlock;

	internal Label ReturnLabel
	{
		get
		{
			return returnLabel;
		}
		set
		{
			returnLabel = value;
		}
	}

	public CodeBuilder(CodeClass codeClass)
	{
		this.codeClass = codeClass;
		mainBlock = new CodeBlock();
		currentBlock = mainBlock;
	}

	public void Generate(ILGenerator gen)
	{
		mainBlock.Generate(gen);
	}

	public CodeVariableReference DeclareVariable(Type type, CodeExpression initValue)
	{
		string name = "v" + varId++;
		CodeVariableDeclaration codeVariableDeclaration = new CodeVariableDeclaration(type, name);
		currentBlock.Add(codeVariableDeclaration);
		if (initValue != null)
		{
			Assign(codeVariableDeclaration.Variable, initValue);
		}
		return codeVariableDeclaration.Variable;
	}

	public void Assign(CodeValueReference var, CodeExpression val)
	{
		currentBlock.Add(new CodeAssignment(var, val));
	}

	public void Return(CodeExpression exp)
	{
		currentBlock.Add(new CodeReturn(this, exp));
	}

	public static CodeBuilder operator +(CodeBuilder cb, CodeItem e)
	{
		cb.currentBlock.Add(e);
		return cb;
	}
}
