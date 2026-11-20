using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class DebugInfoExpression : Expression
{
	public readonly SymbolDocumentInfo Document;

	public sealed override ExpressionType NodeType => ExpressionType.DebugInfo;

	public sealed override Type Type => typeof(void);

	public virtual int StartLine { get; }

	public virtual int StartColumn { get; }

	public virtual int EndLine { get; }

	public virtual int EndColumn { get; }

	public virtual bool IsClear => false;

	internal DebugInfoExpression(SymbolDocumentInfo document, int startLine, int startColumn, int endLine, int endColumn)
	{
		Document = document;
		StartLine = startLine;
		StartColumn = startColumn;
		EndLine = endLine;
		EndColumn = endColumn;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> convertedExpressions)
	{
		return System.Linq.Expressions.Expression.DebugInfo(System.Linq.Expressions.Expression.SymbolDocument(Document.FileName), StartLine, StartColumn, EndLine, EndColumn);
	}
}
