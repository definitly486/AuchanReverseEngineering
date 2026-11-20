using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class UnmanagedMarshal
{
	private int count;

	private UnmanagedType t;

	private UnmanagedType tbase;

	private string guid;

	private string mcookie;

	private string marshaltype;

	internal Type marshaltyperef;

	private int param_num;

	private bool has_size;

	private UnmanagedMarshal(UnmanagedType maint, int cnt)
	{
		count = cnt;
		t = maint;
		tbase = maint;
	}

	private UnmanagedMarshal(UnmanagedType maint, UnmanagedType elemt)
	{
		count = 0;
		t = maint;
		tbase = elemt;
	}

	public static UnmanagedMarshal DefineByValArray(int elemCount)
	{
		return new UnmanagedMarshal(UnmanagedType.ByValArray, elemCount);
	}

	public static UnmanagedMarshal DefineByValTStr(int elemCount)
	{
		return new UnmanagedMarshal(UnmanagedType.ByValTStr, elemCount);
	}

	public static UnmanagedMarshal DefineLPArray(UnmanagedType elemType)
	{
		return new UnmanagedMarshal(UnmanagedType.LPArray, elemType);
	}

	public static UnmanagedMarshal DefineUnmanagedMarshal(UnmanagedType unmanagedType)
	{
		return new UnmanagedMarshal(unmanagedType, unmanagedType);
	}

	internal static UnmanagedMarshal DefineLPArrayInternal(UnmanagedType elemType, int sizeConst, int sizeParamIndex)
	{
		return new UnmanagedMarshal(UnmanagedType.LPArray, elemType)
		{
			count = sizeConst,
			param_num = sizeParamIndex,
			has_size = true
		};
	}
}
