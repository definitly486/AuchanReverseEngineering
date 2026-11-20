using System.Runtime.CompilerServices;

namespace System.Text.Json;

public abstract class JsonNamingPolicy
{
	[CompilerGenerated]
	private static readonly JsonNamingPolicy _003CSnakeCaseLower_003Ek__BackingField = new JsonSnakeCaseLowerNamingPolicy();

	[CompilerGenerated]
	private static readonly JsonNamingPolicy _003CSnakeCaseUpper_003Ek__BackingField = new JsonSnakeCaseUpperNamingPolicy();

	[CompilerGenerated]
	private static readonly JsonNamingPolicy _003CKebabCaseLower_003Ek__BackingField = new JsonKebabCaseLowerNamingPolicy();

	[CompilerGenerated]
	private static readonly JsonNamingPolicy _003CKebabCaseUpper_003Ek__BackingField = new JsonKebabCaseUpperNamingPolicy();

	public static JsonNamingPolicy CamelCase { get; } = new JsonCamelCaseNamingPolicy();

	public abstract string ConvertName(string name);
}
