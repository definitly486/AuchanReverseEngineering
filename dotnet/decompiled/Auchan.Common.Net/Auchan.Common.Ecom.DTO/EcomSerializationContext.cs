using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Auchan.Common.Ecom.Address.DTO;
using Auchan.Common.Ecom.AddressStoreSelection;

namespace Auchan.Common.Ecom.DTO;

[JsonSerializable(typeof(YandexMapMessageDTO))]
[GeneratedCode("System.Text.Json.SourceGeneration", "10.0.14.37416")]
internal class EcomSerializationContext : JsonSerializerContext, IJsonTypeInfoResolver
{
	private JsonTypeInfo<bool>? _Boolean;

	private JsonTypeInfo<YandexMapMessageDTO>? _YandexMapMessageDTO;

	private JsonTypeInfo<ReceivingMethod>? _ReceivingMethod;

	private JsonTypeInfo<ReceivingMethod?>? _NullableReceivingMethod;

	private JsonTypeInfo<int>? _Int32;

	private JsonTypeInfo<int?>? _NullableInt32;

	private JsonTypeInfo<string>? _String;

	private static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions();

	private const BindingFlags InstanceMemberBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	private static readonly JsonEncodedText PropName_focus = JsonEncodedText.Encode("focus");

	private static readonly JsonEncodedText PropName_fias_id = JsonEncodedText.Encode("fias_id");

	private static readonly JsonEncodedText PropName_delivery_method = JsonEncodedText.Encode("delivery_method");

	private static readonly JsonEncodedText PropName_merchant_id = JsonEncodedText.Encode("merchant_id");

	private static readonly JsonEncodedText PropName_geo_lat = JsonEncodedText.Encode("geo_lat");

	private static readonly JsonEncodedText PropName_geo_lon = JsonEncodedText.Encode("geo_lon");

	private static readonly JsonEncodedText PropName_isNeedSwitching = JsonEncodedText.Encode("isNeedSwitching");

	private static readonly JsonEncodedText PropName____echo_mark = JsonEncodedText.Encode("___echo_mark");

	public JsonTypeInfo<bool> Boolean => _Boolean ?? (_Boolean = (JsonTypeInfo<bool>)base.Options.GetTypeInfo(typeof(bool)));

	public JsonTypeInfo<YandexMapMessageDTO> YandexMapMessageDTO => _YandexMapMessageDTO ?? (_YandexMapMessageDTO = (JsonTypeInfo<YandexMapMessageDTO>)base.Options.GetTypeInfo(typeof(YandexMapMessageDTO)));

	public JsonTypeInfo<ReceivingMethod> ReceivingMethod => _ReceivingMethod ?? (_ReceivingMethod = (JsonTypeInfo<ReceivingMethod>)base.Options.GetTypeInfo(typeof(ReceivingMethod)));

	public JsonTypeInfo<ReceivingMethod?> NullableReceivingMethod => _NullableReceivingMethod ?? (_NullableReceivingMethod = (JsonTypeInfo<ReceivingMethod?>)base.Options.GetTypeInfo(typeof(ReceivingMethod?)));

	public JsonTypeInfo<int> Int32 => _Int32 ?? (_Int32 = (JsonTypeInfo<int>)base.Options.GetTypeInfo(typeof(int)));

	public JsonTypeInfo<int?> NullableInt32 => _NullableInt32 ?? (_NullableInt32 = (JsonTypeInfo<int?>)base.Options.GetTypeInfo(typeof(int?)));

	public JsonTypeInfo<string> String => _String ?? (_String = (JsonTypeInfo<string>)base.Options.GetTypeInfo(typeof(string)));

	public static EcomSerializationContext Default { get; } = new EcomSerializationContext(new JsonSerializerOptions(s_defaultOptions));

	protected override JsonSerializerOptions? GeneratedSerializerOptions { get; } = s_defaultOptions;

	private JsonTypeInfo<bool> Create_Boolean(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<bool> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<bool>(options, JsonMetadataServices.BooleanConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<YandexMapMessageDTO> Create_YandexMapMessageDTO(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<YandexMapMessageDTO> jsonTypeInfo))
		{
			JsonObjectInfoValues<YandexMapMessageDTO> objectInfo = new JsonObjectInfoValues<YandexMapMessageDTO>
			{
				ObjectCreator = null,
				ObjectWithParameterizedConstructorCreator = (object[] args) => new YandexMapMessageDTO
				{
					FiasId = (string)args[0],
					EchoMark = (string)args[1]
				},
				PropertyMetadataInitializer = (JsonSerializerContext _) => YandexMapMessageDTOPropInit(options),
				ConstructorParameterMetadataInitializer = YandexMapMessageDTOCtorParamInit,
				ConstructorAttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = YandexMapMessageDTOSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] YandexMapMessageDTOPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[8];
		JsonPropertyInfoValues<int?> propertyInfo = new JsonPropertyInfoValues<int?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(YandexMapMessageDTO),
			Converter = null,
			Getter = (object obj) => ((YandexMapMessageDTO)obj).Focus,
			Setter = delegate(object obj, int? value)
			{
				((YandexMapMessageDTO)obj).Focus = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Focus",
			JsonPropertyName = "focus",
			AttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetProperty("Focus", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(YandexMapMessageDTO),
			Converter = null,
			Getter = (object obj) => ((YandexMapMessageDTO)obj).FiasId,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "FiasId",
			JsonPropertyName = "fias_id",
			AttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetProperty("FiasId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<ReceivingMethod?> propertyInfo3 = new JsonPropertyInfoValues<ReceivingMethod?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(YandexMapMessageDTO),
			Converter = null,
			Getter = (object obj) => ((YandexMapMessageDTO)obj).ReceivingMethod,
			Setter = delegate(object obj, ReceivingMethod? value)
			{
				((YandexMapMessageDTO)obj).ReceivingMethod = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ReceivingMethod",
			JsonPropertyName = "delivery_method",
			AttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetProperty("ReceivingMethod", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ReceivingMethod?), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<int?> propertyInfo4 = new JsonPropertyInfoValues<int?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(YandexMapMessageDTO),
			Converter = null,
			Getter = (object obj) => ((YandexMapMessageDTO)obj).MerchantId,
			Setter = delegate(object obj, int? value)
			{
				((YandexMapMessageDTO)obj).MerchantId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "MerchantId",
			JsonPropertyName = "merchant_id",
			AttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetProperty("MerchantId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(YandexMapMessageDTO),
			Converter = null,
			Getter = (object obj) => ((YandexMapMessageDTO)obj).Latitude,
			Setter = delegate(object obj, string? value)
			{
				((YandexMapMessageDTO)obj).Latitude = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Latitude",
			JsonPropertyName = "geo_lat",
			AttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetProperty("Latitude", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(YandexMapMessageDTO),
			Converter = null,
			Getter = (object obj) => ((YandexMapMessageDTO)obj).Longitude,
			Setter = delegate(object obj, string? value)
			{
				((YandexMapMessageDTO)obj).Longitude = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Longitude",
			JsonPropertyName = "geo_lon",
			AttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetProperty("Longitude", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		JsonPropertyInfoValues<bool> propertyInfo7 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(YandexMapMessageDTO),
			Converter = null,
			Getter = (object obj) => ((YandexMapMessageDTO)obj).DontShowDeliveryHereText,
			Setter = delegate(object obj, bool value)
			{
				((YandexMapMessageDTO)obj).DontShowDeliveryHereText = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DontShowDeliveryHereText",
			JsonPropertyName = "isNeedSwitching",
			AttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetProperty("DontShowDeliveryHereText", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(YandexMapMessageDTO),
			Converter = null,
			Getter = (object obj) => ((YandexMapMessageDTO)obj).EchoMark,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "EchoMark",
			JsonPropertyName = "___echo_mark",
			AttributeProviderFactory = () => typeof(YandexMapMessageDTO).GetProperty("EchoMark", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		return array;
	}

	private void YandexMapMessageDTOSerializeHandler(Utf8JsonWriter writer, YandexMapMessageDTO? value)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WritePropertyName(PropName_focus);
		JsonSerializer.Serialize(writer, value.Focus, NullableInt32);
		writer.WriteString(PropName_fias_id, value.FiasId);
		writer.WritePropertyName(PropName_delivery_method);
		JsonSerializer.Serialize(writer, value.ReceivingMethod, NullableReceivingMethod);
		writer.WritePropertyName(PropName_merchant_id);
		JsonSerializer.Serialize(writer, value.MerchantId, NullableInt32);
		writer.WriteString(PropName_geo_lat, value.Latitude);
		writer.WriteString(PropName_geo_lon, value.Longitude);
		writer.WriteBoolean(PropName_isNeedSwitching, value.DontShowDeliveryHereText);
		writer.WriteString(PropName____echo_mark, value.EchoMark);
		writer.WriteEndObject();
	}

	private static JsonParameterInfoValues[] YandexMapMessageDTOCtorParamInit()
	{
		return new JsonParameterInfoValues[2]
		{
			new JsonParameterInfoValues
			{
				Name = "FiasId",
				ParameterType = typeof(string),
				Position = 0,
				IsNullable = true,
				IsMemberInitializer = true
			},
			new JsonParameterInfoValues
			{
				Name = "EchoMark",
				ParameterType = typeof(string),
				Position = 1,
				IsNullable = true,
				IsMemberInitializer = true
			}
		};
	}

	private JsonTypeInfo<ReceivingMethod> Create_ReceivingMethod(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ReceivingMethod> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<ReceivingMethod>(options, JsonMetadataServices.GetEnumConverter<ReceivingMethod>(options));
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<ReceivingMethod?> Create_NullableReceivingMethod(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ReceivingMethod?> jsonTypeInfo))
		{
			JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<ReceivingMethod>(options);
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<ReceivingMethod?>(options, nullableConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<int> Create_Int32(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<int> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<int>(options, JsonMetadataServices.Int32Converter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<int?> Create_NullableInt32(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<int?> jsonTypeInfo))
		{
			JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<int>(options);
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<int?>(options, nullableConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<string> Create_String(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<string> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<string>(options, JsonMetadataServices.StringConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	public EcomSerializationContext()
		: base(null)
	{
	}

	public EcomSerializationContext(JsonSerializerOptions options)
		: base(options)
	{
	}

	private static bool TryGetTypeInfoForRuntimeCustomConverter<TJsonMetadataType>(JsonSerializerOptions options, out JsonTypeInfo<TJsonMetadataType> jsonTypeInfo)
	{
		JsonConverter runtimeConverterForType = GetRuntimeConverterForType(typeof(TJsonMetadataType), options);
		if (runtimeConverterForType != null)
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<TJsonMetadataType>(options, runtimeConverterForType);
			return true;
		}
		jsonTypeInfo = null;
		return false;
	}

	private static JsonConverter? GetRuntimeConverterForType(Type type, JsonSerializerOptions options)
	{
		for (int i = 0; i < options.Converters.Count; i++)
		{
			JsonConverter jsonConverter = options.Converters[i];
			if (jsonConverter != null && jsonConverter.CanConvert(type))
			{
				return ExpandConverter(type, jsonConverter, options, validateCanConvert: false);
			}
		}
		return null;
	}

	private static JsonConverter ExpandConverter(Type type, JsonConverter converter, JsonSerializerOptions options, bool validateCanConvert = true)
	{
		if (validateCanConvert && !converter.CanConvert(type))
		{
			throw new InvalidOperationException($"The converter '{converter.GetType()}' is not compatible with the type '{type}'.");
		}
		if (converter is JsonConverterFactory jsonConverterFactory)
		{
			converter = jsonConverterFactory.CreateConverter(type, options);
			if (converter == null || converter is JsonConverterFactory)
			{
				throw new InvalidOperationException($"The converter '{jsonConverterFactory.GetType()}' cannot return null or a JsonConverterFactory instance.");
			}
		}
		return converter;
	}

	public override JsonTypeInfo? GetTypeInfo(Type type)
	{
		base.Options.TryGetTypeInfo(type, out JsonTypeInfo typeInfo);
		return typeInfo;
	}

	JsonTypeInfo? IJsonTypeInfoResolver.GetTypeInfo(Type type, JsonSerializerOptions options)
	{
		if (type == typeof(bool))
		{
			return Create_Boolean(options);
		}
		if (type == typeof(YandexMapMessageDTO))
		{
			return Create_YandexMapMessageDTO(options);
		}
		if (type == typeof(ReceivingMethod))
		{
			return Create_ReceivingMethod(options);
		}
		if (type == typeof(ReceivingMethod?))
		{
			return Create_NullableReceivingMethod(options);
		}
		if (type == typeof(int))
		{
			return Create_Int32(options);
		}
		if (type == typeof(int?))
		{
			return Create_NullableInt32(options);
		}
		if (type == typeof(string))
		{
			return Create_String(options);
		}
		return null;
	}
}
