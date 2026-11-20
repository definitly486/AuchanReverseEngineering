namespace Mono;

internal struct MonoAssemblyName
{
	internal nint name;

	internal nint culture;

	internal nint hash_value;

	internal nint public_key;

	internal unsafe fixed byte public_key_token[17];

	internal uint hash_alg;

	internal uint hash_len;

	internal uint flags;

	internal int major;

	internal int minor;

	internal int build;

	internal int revision;

	internal int arch;
}
