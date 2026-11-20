using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace DryIoc;

public class ParameterServiceInfo : ServiceInfo
{
	private new class Typed : ParameterServiceInfo
	{
		internal new sealed class WithDetails : Typed
		{
			public override ServiceDetails Details { get; }

			public WithDetails(ParameterInfo parameter, Type serviceType, ServiceDetails details)
				: base(parameter, serviceType)
			{
				Details = details;
			}
		}

		public override Type ServiceType { get; }

		public Typed(ParameterInfo parameter, Type serviceType)
			: base(parameter)
		{
			ServiceType = serviceType;
		}

		public sealed override ServiceInfo Create(Type serviceType, ServiceDetails details)
		{
			return new WithDetails(Parameter, serviceType, details);
		}
	}

	private sealed class WithDetails : ParameterServiceInfo
	{
		public override ServiceDetails Details { get; }

		public WithDetails(ParameterInfo parameter, ServiceDetails details)
			: base(parameter)
		{
			Details = details;
		}
	}

	public readonly ParameterInfo Parameter;

	public override Type ServiceType => Parameter.ParameterType;

	private ParameterServiceInfo(ParameterInfo p)
	{
		Parameter = p;
	}

	internal static ParameterServiceInfo OrNull(ParameterInfo parameter)
	{
		Type parameterType = parameter.ParameterType;
		if (!parameter.IsOptional)
		{
			if (parameterType.IsByRef)
			{
				return new Typed(parameter, parameterType.GetElementType());
			}
			return null;
		}
		ServiceDetails details = ((parameter.DefaultValue == null) ? ServiceDetails.IfUnresolvedReturnDefault : ServiceDetails.Of(null, null, IfUnresolved.ReturnDefault, parameter.DefaultValue));
		if (parameterType.IsByRef)
		{
			return new Typed.WithDetails(parameter, parameterType.GetElementType(), details);
		}
		return new WithDetails(parameter, details);
	}

	public static ParameterServiceInfo Of(ParameterInfo parameter)
	{
		return OrNull(parameter) ?? new ParameterServiceInfo(parameter);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ParameterServiceInfo Of(ParameterInfo parameter, Type serviceType, ServiceDetails details)
	{
		return new Typed.WithDetails(parameter, serviceType, details);
	}

	public override ServiceInfo Create(Type serviceType, ServiceDetails details)
	{
		if (!(serviceType == ServiceType))
		{
			return new Typed.WithDetails(Parameter, serviceType, details);
		}
		return new WithDetails(Parameter, details);
	}

	public override string ToString()
	{
		return new StringBuilder().Print(this).Append(" as parameter ").Print(Parameter.Name)
			.ToString();
	}
}
