using System.ComponentModel;
using System.Reflection;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Serialization.Metadata;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class JsonMetadataServices
{
	private static JsonConverter<bool> s_booleanConverter;

	private static JsonConverter<int> s_int32Converter;

	private static JsonConverter<string> s_stringConverter;

	public static JsonConverter<bool> BooleanConverter => s_booleanConverter ?? (s_booleanConverter = new BooleanConverter());

	public static JsonConverter<int> Int32Converter => s_int32Converter ?? (s_int32Converter = new Int32Converter());

	public static JsonConverter<string?> StringConverter => s_stringConverter ?? (s_stringConverter = new StringConverter());

	public static JsonConverter<T> GetEnumConverter<T>(JsonSerializerOptions options) where T : struct, Enum
	{
		ArgumentNullException.ThrowIfNull(options, "options");
		return EnumConverterFactory.Helpers.Create<T>(EnumConverterOptions.AllowNumbers, options);
	}

	public static JsonConverter<T?> GetNullableConverter<T>(JsonSerializerOptions options) where T : struct
	{
		ArgumentNullException.ThrowIfNull(options, "options");
		return new NullableConverter<T>(GetTypedConverter<T>(options.GetConverterInternal(typeof(T))));
	}

	internal static JsonConverter<T> GetTypedConverter<T>(JsonConverter converter)
	{
		JsonConverter<T> jsonConverter = converter as JsonConverter<T>;
		if (jsonConverter == null)
		{
			throw new InvalidOperationException(System.SR.Format("SerializationConverterNotCompatible", jsonConverter, typeof(T)));
		}
		return jsonConverter;
	}

	private static JsonTypeInfo<T> CreateCore<T>(JsonConverter converter, JsonSerializerOptions options)
	{
		JsonTypeInfo<T> jsonTypeInfo = new JsonTypeInfo<T>(converter, options);
		jsonTypeInfo.PopulatePolymorphismMetadata();
		jsonTypeInfo.MapInterfaceTypesToCallbacks();
		converter.ConfigureJsonTypeInfo(jsonTypeInfo, options);
		jsonTypeInfo.IsCustomized = false;
		return jsonTypeInfo;
	}

	private static JsonTypeInfo<T> CreateCore<T>(JsonSerializerOptions options, JsonObjectInfoValues<T> objectInfo)
	{
		JsonConverter<T> converter = GetConverter(objectInfo);
		JsonTypeInfo<T> jsonTypeInfo = new JsonTypeInfo<T>(converter, options);
		if (objectInfo.ObjectWithParameterizedConstructorCreator != null)
		{
			jsonTypeInfo.CreateObjectWithArgs = objectInfo.ObjectWithParameterizedConstructorCreator;
			PopulateParameterInfoValues(jsonTypeInfo, objectInfo.ConstructorParameterMetadataInitializer);
		}
		else
		{
			jsonTypeInfo.SetCreateObjectIfCompatible(objectInfo.ObjectCreator);
			jsonTypeInfo.CreateObjectForExtensionDataProperty = jsonTypeInfo.CreateObject;
		}
		if (objectInfo.PropertyMetadataInitializer != null)
		{
			jsonTypeInfo.SourceGenDelayedPropertyInitializer = objectInfo.PropertyMetadataInitializer;
		}
		else
		{
			jsonTypeInfo.PropertyMetadataSerializationNotSupported = true;
		}
		jsonTypeInfo.ConstructorAttributeProviderFactory = objectInfo.ConstructorAttributeProviderFactory;
		jsonTypeInfo.SerializeHandler = objectInfo.SerializeHandler;
		jsonTypeInfo.NumberHandling = objectInfo.NumberHandling;
		jsonTypeInfo.PopulatePolymorphismMetadata();
		jsonTypeInfo.MapInterfaceTypesToCallbacks();
		converter.ConfigureJsonTypeInfo(jsonTypeInfo, options);
		jsonTypeInfo.IsCustomized = false;
		return jsonTypeInfo;
	}

	private static JsonConverter<T> GetConverter<T>(JsonObjectInfoValues<T> objectInfo)
	{
		JsonConverter<T> jsonConverter = ((objectInfo.ObjectWithParameterizedConstructorCreator != null) ? new LargeObjectWithParameterizedConstructorConverter<T>() : new ObjectDefaultConverter<T>());
		if (objectInfo.SerializeHandler == null)
		{
			return jsonConverter;
		}
		return new JsonMetadataServicesConverter<T>(jsonConverter);
	}

	private static void PopulateParameterInfoValues(JsonTypeInfo typeInfo, Func<JsonParameterInfoValues[]> paramFactory)
	{
		JsonParameterInfoValues[] array = paramFactory?.Invoke();
		if (array != null)
		{
			typeInfo.PopulateParameterInfoValues(array);
		}
		else
		{
			typeInfo.PropertyMetadataSerializationNotSupported = true;
		}
	}

	internal static void PopulateProperties(JsonTypeInfo typeInfo, JsonTypeInfo.JsonPropertyInfoList propertyList, Func<JsonSerializerContext, JsonPropertyInfo[]> propInitFunc)
	{
		JsonSerializerContext arg = typeInfo.Options.TypeInfoResolver as JsonSerializerContext;
		JsonPropertyInfo[] array = propInitFunc(arg);
		JsonTypeInfo.PropertyHierarchyResolutionState state = new JsonTypeInfo.PropertyHierarchyResolutionState(typeInfo.Options);
		JsonPropertyInfo[] array2 = array;
		foreach (JsonPropertyInfo jsonPropertyInfo in array2)
		{
			if (!jsonPropertyInfo.SrcGen_IsPublic)
			{
				if (jsonPropertyInfo.SrcGen_HasJsonInclude)
				{
					ThrowHelper.ThrowInvalidOperationException_JsonIncludeOnInaccessibleProperty(jsonPropertyInfo.MemberName, jsonPropertyInfo.DeclaringType);
				}
			}
			else if (jsonPropertyInfo.MemberType != MemberTypes.Field || jsonPropertyInfo.SrcGen_HasJsonInclude || typeInfo.Options.IncludeFields)
			{
				propertyList.AddPropertyWithConflictResolution(jsonPropertyInfo, ref state);
			}
		}
		if (state.IsPropertyOrderSpecified)
		{
			propertyList.SortProperties();
		}
	}

	private static JsonPropertyInfo<T> CreatePropertyInfoCore<T>(JsonPropertyInfoValues<T> propertyInfoValues, JsonSerializerOptions options)
	{
		JsonPropertyInfo<T> jsonPropertyInfo = new JsonPropertyInfo<T>(propertyInfoValues.DeclaringType, null, options);
		DeterminePropertyName(jsonPropertyInfo, propertyInfoValues.PropertyName, propertyInfoValues.JsonPropertyName);
		jsonPropertyInfo.MemberName = propertyInfoValues.PropertyName;
		jsonPropertyInfo.MemberType = (propertyInfoValues.IsProperty ? MemberTypes.Property : MemberTypes.Field);
		jsonPropertyInfo.SrcGen_IsPublic = propertyInfoValues.IsPublic;
		jsonPropertyInfo.SrcGen_HasJsonInclude = propertyInfoValues.HasJsonInclude;
		jsonPropertyInfo.IsExtensionData = propertyInfoValues.IsExtensionData;
		jsonPropertyInfo.CustomConverter = propertyInfoValues.Converter;
		if (jsonPropertyInfo.IgnoreCondition != JsonIgnoreCondition.Always)
		{
			jsonPropertyInfo.Get = propertyInfoValues.Getter;
			jsonPropertyInfo.Set = propertyInfoValues.Setter;
		}
		jsonPropertyInfo.IgnoreCondition = propertyInfoValues.IgnoreCondition;
		jsonPropertyInfo.JsonTypeInfo = propertyInfoValues.PropertyTypeInfo;
		jsonPropertyInfo.NumberHandling = propertyInfoValues.NumberHandling;
		jsonPropertyInfo.AttributeProviderFactory = propertyInfoValues.AttributeProviderFactory;
		return jsonPropertyInfo;
	}

	private static void DeterminePropertyName(JsonPropertyInfo propertyInfo, string declaredPropertyName, string declaredJsonPropertyName)
	{
		string text = ((declaredJsonPropertyName != null) ? declaredJsonPropertyName : ((propertyInfo.Options.PropertyNamingPolicy != null) ? propertyInfo.Options.PropertyNamingPolicy.ConvertName(declaredPropertyName) : declaredPropertyName));
		if (text == null)
		{
			ThrowHelper.ThrowInvalidOperationException_SerializerPropertyNameNull(propertyInfo);
		}
		propertyInfo.Name = text;
	}

	public static JsonPropertyInfo CreatePropertyInfo<T>(JsonSerializerOptions options, JsonPropertyInfoValues<T> propertyInfo)
	{
		ArgumentNullException.ThrowIfNull(options, "options");
		ArgumentNullException.ThrowIfNull(propertyInfo, "propertyInfo");
		if (propertyInfo.DeclaringType == null)
		{
			throw new ArgumentException("DeclaringType");
		}
		if (propertyInfo.PropertyName == null)
		{
			throw new ArgumentException("PropertyName");
		}
		if (!propertyInfo.IsProperty && propertyInfo.IsVirtual)
		{
			throw new InvalidOperationException(System.SR.Format("FieldCannotBeVirtual", "IsProperty", "IsVirtual"));
		}
		return CreatePropertyInfoCore(propertyInfo, options);
	}

	public static JsonTypeInfo<T> CreateObjectInfo<T>(JsonSerializerOptions options, JsonObjectInfoValues<T> objectInfo) where T : notnull
	{
		ArgumentNullException.ThrowIfNull(options, "options");
		ArgumentNullException.ThrowIfNull(objectInfo, "objectInfo");
		return CreateCore(options, objectInfo);
	}

	public static JsonTypeInfo<T> CreateValueInfo<T>(JsonSerializerOptions options, JsonConverter converter)
	{
		ArgumentNullException.ThrowIfNull(options, "options");
		ArgumentNullException.ThrowIfNull(converter, "converter");
		return CreateCore<T>(converter, options);
	}
}
