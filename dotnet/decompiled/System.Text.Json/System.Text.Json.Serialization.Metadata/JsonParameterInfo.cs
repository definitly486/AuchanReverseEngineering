using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization.Metadata;

public abstract class JsonParameterInfo
{
	[CompilerGenerated]
	private readonly object _003CDefaultValue_003Ek__BackingField;

	public int Position { get; }

	public Type ParameterType => MatchingProperty.PropertyType;

	public string Name { get; }

	public bool HasDefaultValue { get; }

	internal object? EffectiveDefaultValue { get; private protected init; }

	public bool IsNullable => MatchingProperty.IsSetNullable;

	public bool IsMemberInitializer { get; }

	internal JsonPropertyInfo MatchingProperty { get; }

	internal JsonConverter EffectiveConverter => MatchingProperty.EffectiveConverter;

	internal bool IgnoreNullTokensOnRead => MatchingProperty.IgnoreNullTokensOnRead;

	internal JsonSerializerOptions Options => MatchingProperty.Options;

	internal byte[] JsonNameAsUtf8Bytes => MatchingProperty.NameAsUtf8Bytes;

	internal JsonNumberHandling? NumberHandling => MatchingProperty.EffectiveNumberHandling;

	internal JsonTypeInfo JsonTypeInfo => MatchingProperty.JsonTypeInfo;

	internal bool ShouldDeserialize => !MatchingProperty.IsIgnored;

	internal bool IsRequiredParameter
	{
		get
		{
			if (!HasDefaultValue)
			{
				return !IsMemberInitializer;
			}
			return false;
		}
	}

	internal JsonParameterInfo(JsonParameterInfoValues parameterInfoValues, JsonPropertyInfo matchingProperty)
	{
		Position = parameterInfoValues.Position;
		Name = parameterInfoValues.Name;
		HasDefaultValue = parameterInfoValues.HasDefaultValue;
		_003CDefaultValue_003Ek__BackingField = (parameterInfoValues.HasDefaultValue ? parameterInfoValues.DefaultValue : null);
		MatchingProperty = matchingProperty;
		IsMemberInitializer = parameterInfoValues.IsMemberInitializer;
	}
}
internal sealed class JsonParameterInfo<T> : JsonParameterInfo
{
	public new T EffectiveDefaultValue { get; }

	public JsonParameterInfo(JsonParameterInfoValues parameterInfoValues, JsonPropertyInfo<T> matchingPropertyInfo)
		: base(parameterInfoValues, matchingPropertyInfo)
	{
		if (parameterInfoValues != null && parameterInfoValues.HasDefaultValue)
		{
			object defaultValue = parameterInfoValues.DefaultValue;
			if (defaultValue != null)
			{
				EffectiveDefaultValue = (T)defaultValue;
			}
		}
		_003CMatchingProperty_003Ek__BackingField = matchingPropertyInfo;
		base.EffectiveDefaultValue = EffectiveDefaultValue;
	}
}
