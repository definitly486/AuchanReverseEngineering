using System;
using System.Linq.Expressions;
using System.Text;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class LabelTarget
{
	public virtual Type Type => typeof(void);

	public virtual string Name => null;

	internal System.Linq.Expressions.LabelTarget ToSystemLabelTarget(ref LiveCountArray<LightAndSysExpr> converted)
	{
		int num = converted.Count - 1;
		while (num != -1 && converted.Items[num].LightExpr != this)
		{
			num--;
		}
		if (num != -1)
		{
			return (System.Linq.Expressions.LabelTarget)converted.Items[num].SysExpr;
		}
		System.Linq.Expressions.LabelTarget labelTarget = ((Name == null) ? System.Linq.Expressions.Expression.Label(Type) : System.Linq.Expressions.Expression.Label(Type, Name));
		ref LightAndSysExpr reference = ref converted.PushSlot();
		reference.LightExpr = this;
		reference.SysExpr = labelTarget;
		return labelTarget;
	}

	public override string ToString()
	{
		return this.ToCSharpString(new StringBuilder()).ToString();
	}
}
