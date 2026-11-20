using System;
using System.Text;

namespace DryIoc;

public struct DecoratorRegistrationInfo
{
	public Factory Factory;

	public Type DecoratorType;

	public DecoratorRegistrationInfo(Factory factory, Type decoratorType)
	{
		Factory = factory;
		DecoratorType = decoratorType;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("DecoratorType=`").Print(DecoratorType).Append('`');
		return stringBuilder.Append(" with Factory=`").Append(Factory).Append('`')
			.ToString();
	}
}
