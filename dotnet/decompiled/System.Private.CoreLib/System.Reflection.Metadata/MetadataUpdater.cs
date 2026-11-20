using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Reflection.Metadata;

public static class MetadataUpdater
{
	[CompilerGenerated]
	private static readonly bool _003CIsSupported_003Ek__BackingField;

	private static readonly Lazy<string> s_ApplyUpdateCapabilities = new Lazy<string>(InitializeApplyUpdateCapabilities);

	[FeatureSwitchDefinition("System.Reflection.Metadata.MetadataUpdater.IsSupported")]
	public static bool IsSupported
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
	} = ApplyUpdateEnabled(0) != 0;

	public unsafe static void ApplyUpdate(Assembly assembly, ReadOnlySpan<byte> metadataDelta, ReadOnlySpan<byte> ilDelta, ReadOnlySpan<byte> pdbDelta)
	{
		RuntimeAssembly obj = assembly as RuntimeAssembly;
		if ((object)obj == null)
		{
			ArgumentNullException.ThrowIfNull(assembly, "assembly");
			throw new ArgumentException("Argument_MustBeRuntimeAssembly");
		}
		if (obj == typeof(AssemblyExtensions).Assembly)
		{
			throw new InvalidOperationException("InvalidOperation_AssemblyNotEditable");
		}
		nint underlyingNativeHandle = obj.GetUnderlyingNativeHandle();
		fixed (byte* dmeta_bytes = metadataDelta)
		{
			fixed (byte* dil_bytes = ilDelta)
			{
				fixed (byte* dpdb_bytes = pdbDelta)
				{
					ApplyUpdate_internal(underlyingNativeHandle, dmeta_bytes, metadataDelta.Length, dil_bytes, ilDelta.Length, dpdb_bytes, pdbDelta.Length);
				}
			}
		}
	}

	internal static string GetCapabilities()
	{
		return s_ApplyUpdateCapabilities.Value;
	}

	private static string InitializeApplyUpdateCapabilities()
	{
		string applyUpdateCapabilities = GetApplyUpdateCapabilities();
		if (ApplyUpdateEnabled(1) == 0)
		{
			return string.Empty;
		}
		return applyUpdateCapabilities;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int ApplyUpdateEnabled(int justComponentCheck);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string GetApplyUpdateCapabilities();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void ApplyUpdate_internal(nint base_assm, byte* dmeta_bytes, int dmeta_length, byte* dil_bytes, int dil_length, byte* dpdb_bytes, int dpdb_length);
}
