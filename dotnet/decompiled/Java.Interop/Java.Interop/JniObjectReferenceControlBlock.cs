using System.Runtime.InteropServices;

namespace Java.Interop;

internal struct JniObjectReferenceControlBlock
{
	public nint handle;

	public int handle_type;

	public nint weak_handle;

	public int refs_added;

	public static readonly int Size = Marshal.SizeOf<JniObjectReferenceControlBlock>();

	public unsafe static JniObjectReferenceControlBlock* Alloc(JniObjectReference reference)
	{
		JniObjectReferenceControlBlock* ptr = (JniObjectReferenceControlBlock*)NativeMemory.AllocZeroed(1u, (uint)Size);
		ptr->handle = reference.Handle;
		ptr->handle_type = (int)reference.Type;
		return ptr;
	}

	public unsafe static void Free(ref JniObjectReferenceControlBlock* value)
	{
		if (value != null)
		{
			NativeMemory.Free(value);
			value = null;
		}
	}
}
