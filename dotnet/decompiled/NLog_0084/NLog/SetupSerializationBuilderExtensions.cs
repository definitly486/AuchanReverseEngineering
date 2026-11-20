using System;
using System.Diagnostics.CodeAnalysis;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.MessageTemplates;
using NLog.Targets;

namespace NLog;

public static class SetupSerializationBuilderExtensions
{
	private sealed class ObjectTypeTransformation<T> : IObjectTypeTransformer
	{
		private readonly IObjectTypeTransformer _original;

		private readonly Func<T, object> _transformer;

		public ObjectTypeTransformation(Func<T, object> transformer, IObjectTypeTransformer original)
		{
			_original = original;
			_transformer = transformer;
		}

		public object? TryTransformObject(object obj)
		{
			if (obj is T arg)
			{
				object obj2 = _transformer(arg);
				if (obj2 != null)
				{
					return obj2;
				}
			}
			return _original?.TryTransformObject(obj);
		}
	}

	private sealed class ObjectTypeTransformation : IObjectTypeTransformer
	{
		private readonly IObjectTypeTransformer _original;

		private readonly Func<object, object> _transformer;

		private readonly Type _objectType;

		public ObjectTypeTransformation(Type objecType, Func<object, object> transformer, IObjectTypeTransformer original)
		{
			_original = original;
			_transformer = transformer;
			_objectType = objecType;
		}

		public object? TryTransformObject(object obj)
		{
			if (_objectType.IsAssignableFrom(obj.GetType()))
			{
				return _transformer(obj);
			}
			return _original?.TryTransformObject(obj);
		}
	}

	public static ISetupSerializationBuilder ParseMessageTemplates(this ISetupSerializationBuilder setupBuilder, bool? enable)
	{
		setupBuilder.LogFactory.ServiceRepository.ParseMessageTemplates(setupBuilder.LogFactory, enable);
		return setupBuilder;
	}

	public static ISetupSerializationBuilder RegisterJsonConverter(this ISetupSerializationBuilder setupBuilder, IJsonConverter jsonConverter)
	{
		setupBuilder.LogFactory.ServiceRepository.RegisterJsonConverter(jsonConverter ?? new DefaultJsonSerializer(setupBuilder.LogFactory.ServiceRepository));
		return setupBuilder;
	}

	public static ISetupSerializationBuilder RegisterValueFormatter(this ISetupSerializationBuilder setupBuilder, IValueFormatter valueFormatter)
	{
		setupBuilder.LogFactory.ServiceRepository.RegisterValueFormatter(valueFormatter ?? new ValueFormatter(setupBuilder.LogFactory.ServiceRepository, legacyStringQuotes: false));
		return setupBuilder;
	}

	public static ISetupSerializationBuilder RegisterValueFormatterWithStringQuotes(this ISetupSerializationBuilder setupBuilder)
	{
		setupBuilder.LogFactory.ServiceRepository.RegisterValueFormatter(new ValueFormatter(setupBuilder.LogFactory.ServiceRepository, legacyStringQuotes: true));
		return setupBuilder;
	}

	public static ISetupSerializationBuilder RegisterObjectTransformation<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(this ISetupSerializationBuilder setupBuilder)
	{
		Guard.ThrowIfNull(setupBuilder, "setupBuilder");
		InternalLogger.Debug("RegisterObjectTransformation for {0} to keep public properties", typeof(T));
		return setupBuilder;
	}

	public static ISetupSerializationBuilder RegisterObjectTransformation<T>(this ISetupSerializationBuilder setupBuilder, Func<T, object> transformer)
	{
		Guard.ThrowIfNull(transformer, "transformer");
		InternalLogger.Debug("RegisterObjectTransformation for {0} to convert safely", typeof(T));
		IObjectTypeTransformer service = setupBuilder.LogFactory.ServiceRepository.GetService<IObjectTypeTransformer>();
		setupBuilder.LogFactory.ServiceRepository.RegisterObjectTypeTransformer(new ObjectTypeTransformation<T>(transformer, service));
		return setupBuilder;
	}

	public static ISetupSerializationBuilder RegisterObjectTransformation(this ISetupSerializationBuilder setupBuilder, Type objectType, Func<object, object> transformer)
	{
		Guard.ThrowIfNull(objectType, "objectType");
		Guard.ThrowIfNull(transformer, "transformer");
		IObjectTypeTransformer service = setupBuilder.LogFactory.ServiceRepository.GetService<IObjectTypeTransformer>();
		setupBuilder.LogFactory.ServiceRepository.RegisterObjectTypeTransformer(new ObjectTypeTransformation(objectType, transformer, service));
		return setupBuilder;
	}
}
