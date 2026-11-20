using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace System.Text.Json;

public static class JsonSerializer
{
	[CompilerGenerated]
	private static readonly bool _003CIsReflectionEnabledByDefault_003Ek__BackingField = !AppContext.TryGetSwitch("System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault", out var isEnabled) || isEnabled;

	private static readonly byte[] s_idPropertyName = "$id"u8.ToArray();

	private static readonly byte[] s_refPropertyName = "$ref"u8.ToArray();

	private static readonly byte[] s_typePropertyName = "$type"u8.ToArray();

	private static readonly byte[] s_valuesPropertyName = "$values"u8.ToArray();

	internal static readonly JsonEncodedText s_metadataId = JsonEncodedText.Encode("$id");

	internal static readonly JsonEncodedText s_metadataRef = JsonEncodedText.Encode("$ref");

	internal static readonly JsonEncodedText s_metadataType = JsonEncodedText.Encode("$type");

	internal static readonly JsonEncodedText s_metadataValues = JsonEncodedText.Encode("$values");

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private static JsonTypeInfo GetTypeInfo(JsonSerializerOptions options, Type inputType)
	{
		if (options == null)
		{
			options = JsonSerializerOptions.Default;
		}
		options.MakeReadOnly(populateMissingResolver: true);
		if (!(inputType == JsonTypeInfo.ObjectType))
		{
			return options.GetTypeInfoForRootType(inputType);
		}
		return options.ObjectTypeInfo;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private static JsonTypeInfo<T> GetTypeInfo<T>(JsonSerializerOptions options)
	{
		return (JsonTypeInfo<T>)GetTypeInfo(options, typeof(T));
	}

	private static void ValidateInputType(object value, Type inputType)
	{
		ArgumentNullException.ThrowIfNull(inputType, "inputType");
		if (value != null)
		{
			Type type = value.GetType();
			if (!inputType.IsAssignableFrom(type))
			{
				ThrowHelper.ThrowArgumentException_DeserializeWrongType(inputType, value);
			}
		}
	}

	internal static bool IsValidNumberHandlingValue(JsonNumberHandling handling)
	{
		return JsonHelpers.IsInRangeInclusive((int)handling, 0, 7);
	}

	[return: NotNullIfNotNull("value")]
	internal static T UnboxOnRead<T>(object value)
	{
		if (value == null)
		{
			if (default(T) != null)
			{
				ThrowUnableToCastValue(value);
			}
			return default(T);
		}
		if (value is T)
		{
			return (T)value;
		}
		ThrowUnableToCastValue(value);
		return default(T);
		static void ThrowUnableToCastValue(object obj)
		{
			if (obj == null)
			{
				ThrowHelper.ThrowInvalidOperationException_DeserializeUnableToAssignNull(typeof(T));
			}
			else
			{
				ThrowHelper.ThrowInvalidCastException_DeserializeUnableToAssignValue(obj.GetType(), typeof(T));
			}
		}
	}

	[return: NotNullIfNotNull("value")]
	internal static T UnboxOnWrite<T>(object value)
	{
		if (default(T) != null && value == null)
		{
			ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(typeof(T));
		}
		return (T)value;
	}

	internal static bool TryReadMetadata(JsonConverter converter, JsonTypeInfo jsonTypeInfo, ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		bool allowOutOfOrderMetadataProperties = jsonTypeInfo.Options.AllowOutOfOrderMetadataProperties;
		bool flag = false;
		Utf8JsonReader reader2;
		if (allowOutOfOrderMetadataProperties && !reader.IsFinalBlock)
		{
			reader2 = reader;
			if (!reader2.TrySkipPartial())
			{
				return false;
			}
		}
		else
		{
			reader2 = default(Utf8JsonReader);
		}
		while (true)
		{
			if (state.Current.PropertyState == StackFramePropertyState.None)
			{
				if (!reader.Read())
				{
					return false;
				}
				state.Current.PropertyState = StackFramePropertyState.ReadName;
			}
			if ((int)state.Current.PropertyState < 2)
			{
				if (reader.TokenType == JsonTokenType.EndObject)
				{
					break;
				}
				if ((state.Current.MetadataPropertyNames & MetadataPropertyName.Ref) != MetadataPropertyName.None)
				{
					ThrowHelper.ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties(reader.GetUnescapedSpan(), ref state);
				}
				ReadOnlySpan<byte> unescapedSpan = reader.GetUnescapedSpan();
				switch (state.Current.LatestMetadataPropertyName = GetMetadataPropertyName(unescapedSpan, jsonTypeInfo.PolymorphicTypeResolver))
				{
				case MetadataPropertyName.Id:
					state.Current.JsonPropertyName = s_idPropertyName;
					if (state.ReferenceResolver == null)
					{
						ThrowHelper.ThrowJsonException_MetadataUnexpectedProperty(unescapedSpan, ref state);
					}
					if ((state.Current.MetadataPropertyNames & (MetadataPropertyName.Id | MetadataPropertyName.Ref)) != MetadataPropertyName.None)
					{
						ThrowHelper.ThrowJsonException_MetadataIdCannotBeCombinedWithRef(unescapedSpan, ref state);
					}
					if (!converter.CanHaveMetadata)
					{
						ThrowHelper.ThrowJsonException_MetadataCannotParsePreservedObjectIntoImmutable(converter.Type);
					}
					goto IL_0257;
				case MetadataPropertyName.Ref:
					state.Current.JsonPropertyName = s_refPropertyName;
					if (state.ReferenceResolver == null)
					{
						ThrowHelper.ThrowJsonException_MetadataUnexpectedProperty(unescapedSpan, ref state);
					}
					if (converter.IsValueType)
					{
						ThrowHelper.ThrowJsonException_MetadataInvalidReferenceToValueType(converter.Type);
					}
					if (state.Current.MetadataPropertyNames != MetadataPropertyName.None || flag)
					{
						ThrowHelper.ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties(reader.GetUnescapedSpan(), ref state);
					}
					goto IL_0257;
				case MetadataPropertyName.Type:
					state.Current.JsonPropertyName = jsonTypeInfo.PolymorphicTypeResolver?.CustomTypeDiscriminatorPropertyNameUtf8 ?? s_typePropertyName;
					if (jsonTypeInfo.PolymorphicTypeResolver == null)
					{
						ThrowHelper.ThrowJsonException_MetadataUnexpectedProperty(unescapedSpan, ref state);
					}
					if (state.PolymorphicTypeDiscriminator != null)
					{
						ThrowHelper.ThrowJsonException_DuplicateMetadataProperty(state.Current.JsonPropertyName);
					}
					goto IL_0257;
				case MetadataPropertyName.Values:
					state.Current.JsonPropertyName = s_valuesPropertyName;
					if ((state.Current.MetadataPropertyNames & MetadataPropertyName.Values) != MetadataPropertyName.None)
					{
						ThrowHelper.ThrowJsonException_DuplicateMetadataProperty(s_valuesPropertyName);
					}
					if (flag)
					{
						ThrowHelper.ThrowJsonException_MetadataInvalidPropertyInArrayMetadata(ref state, jsonTypeInfo.Type, in reader);
					}
					goto IL_0257;
				default:
					{
						if (!allowOutOfOrderMetadataProperties)
						{
							break;
						}
						if (!flag)
						{
							flag = true;
							reader2 = reader;
						}
						if ((state.Current.MetadataPropertyNames & MetadataPropertyName.Values) != MetadataPropertyName.None)
						{
							ThrowHelper.ThrowJsonException_MetadataInvalidPropertyInArrayMetadata(ref state, jsonTypeInfo.Type, in reader);
						}
						if (IsMetadataPropertyName(unescapedSpan, null))
						{
							ThrowHelper.ThrowUnexpectedMetadataException(unescapedSpan, ref reader, ref state);
						}
						goto IL_0257;
					}
					IL_0257:
					state.Current.PropertyState = StackFramePropertyState.Name;
					goto IL_0263;
				}
				break;
			}
			goto IL_0263;
			IL_0263:
			if ((int)state.Current.PropertyState < 3)
			{
				if (!reader.Read())
				{
					return false;
				}
				state.Current.PropertyState = StackFramePropertyState.ReadValue;
			}
			switch (state.Current.LatestMetadataPropertyName)
			{
			case MetadataPropertyName.Id:
				if (reader.TokenType != JsonTokenType.String)
				{
					ThrowHelper.ThrowJsonException_MetadataValueWasNotString(reader.TokenType);
				}
				if (state.ReferenceId != null)
				{
					ThrowHelper.ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(s_refPropertyName, ref reader, ref state);
				}
				state.ReferenceId = reader.GetString();
				goto IL_03c4;
			case MetadataPropertyName.Ref:
				if (reader.TokenType != JsonTokenType.String)
				{
					ThrowHelper.ThrowJsonException_MetadataValueWasNotString(reader.TokenType);
				}
				if (state.ReferenceId != null)
				{
					ThrowHelper.ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(s_refPropertyName, ref reader, ref state);
				}
				state.ReferenceId = reader.GetString();
				goto IL_03c4;
			case MetadataPropertyName.Type:
				switch (reader.TokenType)
				{
				case JsonTokenType.String:
					state.PolymorphicTypeDiscriminator = reader.GetString();
					break;
				case JsonTokenType.Number:
					state.PolymorphicTypeDiscriminator = reader.GetInt32();
					break;
				default:
					ThrowHelper.ThrowJsonException_MetadataValueWasNotString(reader.TokenType);
					break;
				}
				goto IL_03c4;
			case MetadataPropertyName.Values:
				if (reader.TokenType != JsonTokenType.StartArray)
				{
					ThrowHelper.ThrowJsonException_MetadataValuesInvalidToken(reader.TokenType);
				}
				if (allowOutOfOrderMetadataProperties)
				{
					flag = true;
					reader2 = reader;
					reader.SkipWithVerify();
					goto IL_03c4;
				}
				break;
			default:
				reader.SkipWithVerify();
				goto IL_03c4;
			}
			state.Current.MetadataPropertyNames |= MetadataPropertyName.Values;
			state.Current.PropertyState = StackFramePropertyState.None;
			break;
			IL_03c4:
			state.Current.MetadataPropertyNames |= state.Current.LatestMetadataPropertyName;
			state.Current.PropertyState = StackFramePropertyState.None;
			state.Current.JsonPropertyName = null;
		}
		if (state.Current.MetadataPropertyNames == MetadataPropertyName.Values)
		{
			ThrowHelper.ThrowJsonException_MetadataStandaloneValuesProperty(ref state, s_valuesPropertyName);
		}
		if (flag)
		{
			reader = reader2;
		}
		return true;
	}

	internal static bool IsMetadataPropertyName(ReadOnlySpan<byte> propertyName, PolymorphicTypeResolver resolver)
	{
		if (propertyName.Length <= 0 || propertyName[0] != 36)
		{
			if (resolver == null)
			{
				return false;
			}
			byte[] customTypeDiscriminatorPropertyNameUtf = resolver.CustomTypeDiscriminatorPropertyNameUtf8;
			return ((customTypeDiscriminatorPropertyNameUtf != null) ? new bool?(((ReadOnlySpan<byte>)customTypeDiscriminatorPropertyNameUtf.AsSpan()).SequenceEqual(propertyName)) : ((bool?)null)) == true;
		}
		return true;
	}

	internal static MetadataPropertyName GetMetadataPropertyName(ReadOnlySpan<byte> propertyName, PolymorphicTypeResolver resolver)
	{
		if (propertyName.Length > 0 && propertyName[0] == 36)
		{
			switch (propertyName.Length)
			{
			case 3:
				if (propertyName.SequenceEqual("$id"u8))
				{
					return MetadataPropertyName.Id;
				}
				break;
			case 4:
				if (propertyName.SequenceEqual("$ref"u8))
				{
					return MetadataPropertyName.Ref;
				}
				break;
			case 5:
				if (resolver?.CustomTypeDiscriminatorPropertyNameUtf8 == null && propertyName.SequenceEqual("$type"u8))
				{
					return MetadataPropertyName.Type;
				}
				break;
			case 7:
				if (propertyName.SequenceEqual("$values"u8))
				{
					return MetadataPropertyName.Values;
				}
				break;
			}
		}
		byte[] array = resolver?.CustomTypeDiscriminatorPropertyNameUtf8;
		if (array != null && propertyName.SequenceEqual(array))
		{
			return MetadataPropertyName.Type;
		}
		return MetadataPropertyName.None;
	}

	internal static void ValidateMetadataForObjectConverter(ref ReadStack state)
	{
		if ((state.Current.MetadataPropertyNames & MetadataPropertyName.Values) != MetadataPropertyName.None)
		{
			ThrowHelper.ThrowJsonException_MetadataUnexpectedProperty(s_valuesPropertyName, ref state);
		}
	}

	internal static T ResolveReferenceId<T>(ref ReadStack state)
	{
		string referenceId = state.ReferenceId;
		object obj = state.ReferenceResolver.ResolveReference(referenceId);
		state.ReferenceId = null;
		try
		{
			return (T)obj;
		}
		catch (InvalidCastException)
		{
			ThrowHelper.ThrowInvalidOperationException_MetadataReferenceOfTypeCannotBeAssignedToType(referenceId, obj.GetType(), typeof(T));
			return default(T);
		}
	}

	internal static JsonPropertyInfo LookupProperty(object obj, ReadOnlySpan<byte> unescapedPropertyName, ref ReadStack state, JsonSerializerOptions options, out bool useExtensionProperty, bool createExtensionProperty = true)
	{
		JsonTypeInfo jsonTypeInfo = state.Current.JsonTypeInfo;
		useExtensionProperty = false;
		byte[] utf8PropertyName;
		JsonPropertyInfo jsonPropertyInfo = jsonTypeInfo.GetProperty(unescapedPropertyName, ref state.Current, out utf8PropertyName);
		state.Current.PropertyIndex++;
		state.Current.JsonPropertyName = utf8PropertyName;
		if (jsonPropertyInfo == null)
		{
			if (jsonTypeInfo.EffectiveUnmappedMemberHandling == JsonUnmappedMemberHandling.Disallow)
			{
				string unmappedPropertyName = JsonHelpers.Utf8GetString(unescapedPropertyName);
				ThrowHelper.ThrowJsonException_UnmappedJsonProperty(jsonTypeInfo.Type, unmappedPropertyName);
			}
			JsonPropertyInfo extensionDataProperty = jsonTypeInfo.ExtensionDataProperty;
			if (extensionDataProperty != null && extensionDataProperty.HasGetter && extensionDataProperty.HasSetter)
			{
				state.Current.JsonPropertyNameAsString = JsonHelpers.Utf8GetString(unescapedPropertyName);
				if (createExtensionProperty)
				{
					CreateExtensionDataProperty(obj, extensionDataProperty, options);
				}
				jsonPropertyInfo = extensionDataProperty;
				useExtensionProperty = true;
			}
			else
			{
				jsonPropertyInfo = JsonPropertyInfo.s_missingProperty;
			}
		}
		state.Current.JsonPropertyInfo = jsonPropertyInfo;
		state.Current.NumberHandling = jsonPropertyInfo.EffectiveNumberHandling;
		return jsonPropertyInfo;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ReadOnlySpan<byte> GetPropertyName(scoped ref ReadStack state, ref Utf8JsonReader reader, JsonSerializerOptions options, out bool isAlreadyReadMetadataProperty)
	{
		ReadOnlySpan<byte> unescapedSpan = reader.GetUnescapedSpan();
		isAlreadyReadMetadataProperty = false;
		if (state.Current.CanContainMetadata && IsMetadataPropertyName(unescapedSpan, state.Current.BaseJsonTypeInfo.PolymorphicTypeResolver))
		{
			if (options.AllowOutOfOrderMetadataProperties)
			{
				isAlreadyReadMetadataProperty = true;
			}
			else
			{
				ThrowHelper.ThrowUnexpectedMetadataException(unescapedSpan, ref reader, ref state);
			}
		}
		return unescapedSpan;
	}

	internal static void CreateExtensionDataProperty(object obj, JsonPropertyInfo jsonPropertyInfo, JsonSerializerOptions options)
	{
		object valueAsObject = jsonPropertyInfo.GetValueAsObject(obj);
		if (valueAsObject != null)
		{
			return;
		}
		Func<object>? obj2 = jsonPropertyInfo.JsonTypeInfo.CreateObject ?? jsonPropertyInfo.JsonTypeInfo.CreateObjectForExtensionDataProperty;
		if (obj2 == null)
		{
			if (jsonPropertyInfo.PropertyType.FullName == "System.Text.Json.Nodes.JsonObject")
			{
				ThrowHelper.ThrowInvalidOperationException_NodeJsonObjectCustomConverterNotAllowedOnExtensionProperty();
			}
			else
			{
				ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(jsonPropertyInfo.PropertyType);
			}
		}
		valueAsObject = obj2();
		jsonPropertyInfo.Set(obj, valueAsObject);
	}

	private static TValue ReadFromSpan<TValue>(ReadOnlySpan<byte> utf8Json, JsonTypeInfo<TValue> jsonTypeInfo, int? actualByteCount = null)
	{
		JsonReaderState state = new JsonReaderState(jsonTypeInfo.Options.GetReaderOptions());
		Utf8JsonReader reader = new Utf8JsonReader(utf8Json, isFinalBlock: true, state);
		ReadStack state2 = default(ReadStack);
		state2.Initialize(jsonTypeInfo);
		return jsonTypeInfo.Deserialize(ref reader, ref state2);
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static ValueTask<TValue?> DeserializeAsync<TValue>(Stream utf8Json, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		ArgumentNullException.ThrowIfNull(utf8Json, "utf8Json");
		return GetTypeInfo<TValue>(options).DeserializeAsync(utf8Json, cancellationToken);
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static TValue? Deserialize<TValue>([StringSyntax("Json")] string json, JsonSerializerOptions? options = null)
	{
		ArgumentNullException.ThrowIfNull(json, "json");
		JsonTypeInfo<TValue> typeInfo = GetTypeInfo<TValue>(options);
		return ReadFromSpan(json.AsSpan(), typeInfo);
	}

	public static TValue? Deserialize<TValue>([StringSyntax("Json")] string json, JsonTypeInfo<TValue> jsonTypeInfo)
	{
		ArgumentNullException.ThrowIfNull(json, "json");
		ArgumentNullException.ThrowIfNull(jsonTypeInfo, "jsonTypeInfo");
		jsonTypeInfo.EnsureConfigured();
		return ReadFromSpan(json.AsSpan(), jsonTypeInfo);
	}

	private static TValue ReadFromSpan<TValue>(ReadOnlySpan<char> json, JsonTypeInfo<TValue> jsonTypeInfo)
	{
		byte[] array = null;
		Span<byte> span = ((json.Length > 85) ? ((Span<byte>)(((long)json.Length > 357913941L) ? new byte[JsonReaderHelper.GetUtf8ByteCount(json)] : (array = ArrayPool<byte>.Shared.Rent(json.Length * 3)))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		try
		{
			int utf8FromText = JsonReaderHelper.GetUtf8FromText(json, span2);
			span2 = span2.Slice(0, utf8FromText);
			return ReadFromSpan(span2, jsonTypeInfo, utf8FromText);
		}
		finally
		{
			if (array != null)
			{
				span2.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
		}
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static TValue? Deserialize<TValue>(ref Utf8JsonReader reader, JsonSerializerOptions? options = null)
	{
		JsonTypeInfo<TValue> typeInfo = GetTypeInfo<TValue>(options);
		return Read(ref reader, typeInfo);
	}

	private static TValue Read<TValue>(ref Utf8JsonReader reader, JsonTypeInfo<TValue> jsonTypeInfo)
	{
		if (reader.CurrentState.Options.CommentHandling == JsonCommentHandling.Allow)
		{
			ThrowHelper.ThrowArgumentException_SerializerDoesNotSupportComments("reader");
		}
		ReadStack state = default(ReadStack);
		state.Initialize(jsonTypeInfo);
		Utf8JsonReader utf8JsonReader = reader;
		try
		{
			Utf8JsonReader reader2 = GetReaderScopedToNextValue(ref reader, ref state);
			return jsonTypeInfo.Deserialize(ref reader2, ref state);
		}
		catch (JsonException)
		{
			reader = utf8JsonReader;
			throw;
		}
	}

	private static Utf8JsonReader GetReaderScopedToNextValue(ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		ReadOnlySpan<byte> jsonData = default(ReadOnlySpan<byte>);
		ReadOnlySequence<byte> jsonData2 = default(ReadOnlySequence<byte>);
		try
		{
			JsonTokenType tokenType = reader.TokenType;
			if ((tokenType == JsonTokenType.None || tokenType == JsonTokenType.PropertyName) && !reader.Read())
			{
				ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedOneCompleteToken, 0);
			}
			switch (reader.TokenType)
			{
			case JsonTokenType.StartObject:
			case JsonTokenType.StartArray:
			{
				long tokenStartIndex = reader.TokenStartIndex;
				if (!reader.TrySkip())
				{
					ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.NotEnoughData, 0);
				}
				long num = reader.BytesConsumed - tokenStartIndex;
				ReadOnlySequence<byte> originalSequence = reader.OriginalSequence;
				if (originalSequence.IsEmpty)
				{
					jsonData = checked(reader.OriginalSpan.Slice((int)tokenStartIndex, (int)num));
				}
				else
				{
					jsonData2 = originalSequence.Slice(tokenStartIndex, num);
				}
				break;
			}
			case JsonTokenType.Number:
			case JsonTokenType.True:
			case JsonTokenType.False:
			case JsonTokenType.Null:
				if (reader.HasValueSequence)
				{
					jsonData2 = reader.ValueSequence;
				}
				else
				{
					jsonData = reader.ValueSpan;
				}
				break;
			case JsonTokenType.String:
			{
				ReadOnlySequence<byte> originalSequence2 = reader.OriginalSequence;
				if (originalSequence2.IsEmpty)
				{
					int length = reader.ValueSpan.Length + 2;
					jsonData = reader.OriginalSpan.Slice((int)reader.TokenStartIndex, length);
				}
				else
				{
					long length2 = (reader.HasValueSequence ? (reader.ValueSequence.Length + 2) : (reader.ValueSpan.Length + 2));
					jsonData2 = originalSequence2.Slice(reader.TokenStartIndex, length2);
				}
				break;
			}
			default:
			{
				byte nextByte = (reader.HasValueSequence ? reader.ValueSequence.First.Span[0] : reader.ValueSpan[0]);
				ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedStartOfValueNotFound, nextByte);
				break;
			}
			}
		}
		catch (JsonReaderException ex)
		{
			ThrowHelper.ReThrowWithPath(ref state, ex);
		}
		if (!jsonData.IsEmpty)
		{
			return new Utf8JsonReader(jsonData, reader.CurrentState.Options);
		}
		return new Utf8JsonReader(jsonData2, reader.CurrentState.Options);
	}

	internal static MetadataPropertyName WriteMetadataForObject(JsonConverter jsonConverter, ref WriteStack state, Utf8JsonWriter writer)
	{
		MetadataPropertyName metadataPropertyName = MetadataPropertyName.None;
		if (state.NewReferenceId != null)
		{
			writer.WriteString(s_metadataId, state.NewReferenceId);
			metadataPropertyName |= MetadataPropertyName.Id;
			state.NewReferenceId = null;
		}
		object polymorphicTypeDiscriminator = state.PolymorphicTypeDiscriminator;
		if (polymorphicTypeDiscriminator != null)
		{
			JsonEncodedText? customTypeDiscriminatorPropertyNameJsonEncoded = state.PolymorphicTypeResolver.CustomTypeDiscriminatorPropertyNameJsonEncoded;
			JsonEncodedText jsonEncodedText;
			if (customTypeDiscriminatorPropertyNameJsonEncoded.HasValue)
			{
				JsonEncodedText valueOrDefault = customTypeDiscriminatorPropertyNameJsonEncoded.GetValueOrDefault();
				jsonEncodedText = valueOrDefault;
			}
			else
			{
				jsonEncodedText = s_metadataType;
			}
			JsonEncodedText propertyName = jsonEncodedText;
			if (polymorphicTypeDiscriminator is string value)
			{
				writer.WriteString(propertyName, value);
			}
			else
			{
				writer.WriteNumber(propertyName, (int)polymorphicTypeDiscriminator);
			}
			metadataPropertyName |= MetadataPropertyName.Type;
			state.PolymorphicTypeDiscriminator = null;
		}
		return metadataPropertyName;
	}

	internal static bool TryGetReferenceForValue(object currentValue, ref WriteStack state, Utf8JsonWriter writer)
	{
		bool alreadyExists;
		string reference = state.ReferenceResolver.GetReference(currentValue, out alreadyExists);
		if (alreadyExists)
		{
			writer.WriteStartObject();
			writer.WriteString(s_metadataRef, reference);
			writer.WriteEndObject();
			state.PolymorphicTypeDiscriminator = null;
			state.PolymorphicTypeResolver = null;
		}
		else
		{
			state.NewReferenceId = reference;
		}
		return alreadyExists;
	}

	public static Task SerializeAsync(Stream utf8Json, object? value, JsonTypeInfo jsonTypeInfo, CancellationToken cancellationToken = default(CancellationToken))
	{
		ArgumentNullException.ThrowIfNull(utf8Json, "utf8Json");
		ArgumentNullException.ThrowIfNull(jsonTypeInfo, "jsonTypeInfo");
		jsonTypeInfo.EnsureConfigured();
		return jsonTypeInfo.SerializeAsObjectAsync(utf8Json, value, cancellationToken);
	}

	public static void Serialize(Stream utf8Json, object? value, JsonTypeInfo jsonTypeInfo)
	{
		ArgumentNullException.ThrowIfNull(utf8Json, "utf8Json");
		ArgumentNullException.ThrowIfNull(jsonTypeInfo, "jsonTypeInfo");
		jsonTypeInfo.EnsureConfigured();
		jsonTypeInfo.SerializeAsObject(utf8Json, value);
	}

	public static string Serialize<TValue>(TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
	{
		ArgumentNullException.ThrowIfNull(jsonTypeInfo, "jsonTypeInfo");
		jsonTypeInfo.EnsureConfigured();
		return WriteString(in value, jsonTypeInfo);
	}

	private static string WriteString<TValue>(in TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
	{
		PooledByteBufferWriter bufferWriter;
		Utf8JsonWriter writer = Utf8JsonWriterCache.RentWriterAndBuffer(jsonTypeInfo.Options, out bufferWriter);
		try
		{
			jsonTypeInfo.Serialize(writer, in value);
			return JsonReaderHelper.TranscodeHelper(bufferWriter.WrittenSpan);
		}
		finally
		{
			Utf8JsonWriterCache.ReturnWriterAndBuffer(writer, bufferWriter);
		}
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static void Serialize<TValue>(Utf8JsonWriter writer, TValue value, JsonSerializerOptions? options = null)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		GetTypeInfo<TValue>(options).Serialize(writer, in value);
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static void Serialize(Utf8JsonWriter writer, object? value, Type inputType, JsonSerializerOptions? options = null)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		ValidateInputType(value, inputType);
		GetTypeInfo(options, inputType).SerializeAsObject(writer, value);
	}

	public static void Serialize<TValue>(Utf8JsonWriter writer, TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		ArgumentNullException.ThrowIfNull(jsonTypeInfo, "jsonTypeInfo");
		jsonTypeInfo.EnsureConfigured();
		jsonTypeInfo.Serialize(writer, in value);
	}
}
