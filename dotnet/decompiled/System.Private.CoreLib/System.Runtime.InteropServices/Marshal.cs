using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;

namespace System.Runtime.InteropServices;

public static class Marshal
{
	private sealed class MarshalerInstanceKeyComparer : IEqualityComparer<(Type, string)>
	{
		public bool Equals((Type, string) lhs, (Type, string) rhs)
		{
			return lhs.CompareTo(rhs) == 0;
		}

		public int GetHashCode((Type, string) key)
		{
			return key.GetHashCode();
		}
	}

	private static Dictionary<(Type, string), ICustomMarshaler> MarshalerInstanceCache;

	public static readonly int SystemDefaultCharSize = 2;

	public static readonly int SystemMaxDBCSCharSize = 3;

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int GetLastPInvokeError();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void SetLastPInvokeError(int error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[RequiresDynamicCode("Marshalling code for the object might not be available. Use the DestroyStructure<T> overload instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static extern void DestroyStructure(nint ptr, Type structuretype);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static extern nint OffsetOf(Type t, string fieldName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[RequiresDynamicCode("Marshalling code for the object might not be available. Use the StructureToPtr<T> overload instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static extern void StructureToPtr(object structure, nint ptr, bool fDeleteOld);

	internal static bool IsPinnable(object obj)
	{
		if (obj == null || obj is string)
		{
			return true;
		}
		return !RuntimeTypeHandle.HasReferences(obj.GetType() as RuntimeType);
	}

	private static void PrelinkCore(MethodInfo m)
	{
		if (!(m is RuntimeMethodInfo))
		{
			throw new ArgumentException("Argument_MustBeRuntimeMethodInfo", "m");
		}
		PrelinkInternal(m);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void PtrToStructureHelper(nint ptr, object structure, bool allowValueClasses);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDelegateForFunctionPointerInternal(QCallTypeHandle t, nint ptr, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetFunctionPointerForDelegateInternal(Delegate d);

	private static Delegate GetDelegateForFunctionPointerInternal(nint ptr, RuntimeType t)
	{
		Delegate o = null;
		GetDelegateForFunctionPointerInternal(new QCallTypeHandle(ref t), ptr, ObjectHandleOnStack.Create(ref o));
		return o;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void PrelinkInternal(MethodInfo m);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int SizeOfHelper(QCallTypeHandle t, bool throwIfNotMarshalable);

	private static int SizeOfHelper(RuntimeType rttype, bool throwIfNotMarshalable)
	{
		return SizeOfHelper(new QCallTypeHandle(ref rttype), throwIfNotMarshalable);
	}

	public static nint GetExceptionPointers()
	{
		throw new PlatformNotSupportedException();
	}

	private unsafe static void SetInvokeArgs(ref string cookie, nint* params_byref)
	{
		ByReference byReference = ByReference.Create(ref cookie);
		Unsafe.Write(params_byref, byReference);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "Implementation detail of MarshalAs.CustomMarshaler")]
	internal unsafe static ICustomMarshaler GetCustomMarshalerInstance(Type type, string cookie)
	{
		(Type, string) key = (type, cookie);
		Dictionary<(Type, string), ICustomMarshaler> dictionary = Volatile.Read(in MarshalerInstanceCache) ?? Interlocked.CompareExchange(ref MarshalerInstanceCache, new Dictionary<(Type, string), ICustomMarshaler>(new MarshalerInstanceKeyComparer()), null) ?? MarshalerInstanceCache;
		bool flag;
		ICustomMarshaler value;
		lock (dictionary)
		{
			flag = dictionary.TryGetValue(key, out value);
		}
		if (!flag)
		{
			RuntimeMethodInfo runtimeMethodInfo;
			try
			{
				runtimeMethodInfo = (RuntimeMethodInfo)type.GetMethod("GetInstance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, new Type[1] { typeof(string) }, null);
			}
			catch (AmbiguousMatchException)
			{
				throw new ApplicationException(SR.Format("CustomMarshaler_MultipleGetInstanceMethods", type.FullName));
			}
			if (runtimeMethodInfo == null || runtimeMethodInfo.ReturnType != typeof(ICustomMarshaler))
			{
				throw new ApplicationException(SR.Format("CustomMarshaler_NoGetInstanceMethod", type.FullName));
			}
			if (runtimeMethodInfo.ContainsGenericParameters)
			{
				throw new TypeLoadException(SR.Format("CustomMarshaler_UnassignedGenericParams", type.FullName));
			}
			Exception exc;
			try
			{
				nint num = 0;
				nint* ptr = &num;
				SetInvokeArgs(ref cookie, ptr);
				value = (ICustomMarshaler)runtimeMethodInfo.InternalInvoke(null, ptr, out exc);
			}
			catch (Exception ex2)
			{
				exc = ex2;
				value = null;
			}
			if (exc != null)
			{
				ExceptionDispatchInfo.Capture(exc).Throw();
			}
			if (value == null)
			{
				throw new ApplicationException(SR.Format("CustomMarshaler_NullReturnForGetInstance", type.FullName));
			}
			lock (dictionary)
			{
				dictionary[key] = value;
			}
		}
		return value;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("GetExceptionCode() may be unavailable in future releases.")]
	public static int GetExceptionCode()
	{
		throw new PlatformNotSupportedException();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("ReadByte(Object, Int32) may be unavailable in future releases.")]
	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	public static byte ReadByte(object ptr, int ofs)
	{
		throw new PlatformNotSupportedException();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("ReadInt16(Object, Int32) may be unavailable in future releases.")]
	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	public static short ReadInt16(object ptr, int ofs)
	{
		throw new PlatformNotSupportedException();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("ReadInt32(Object, Int32) may be unavailable in future releases.")]
	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	public static int ReadInt32(object ptr, int ofs)
	{
		throw new PlatformNotSupportedException();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("ReadInt64(Object, Int32) may be unavailable in future releases.")]
	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	public static long ReadInt64(object ptr, int ofs)
	{
		throw new PlatformNotSupportedException();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("WriteByte(Object, Int32, Byte) may be unavailable in future releases.")]
	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	public static void WriteByte(object ptr, int ofs, byte val)
	{
		throw new PlatformNotSupportedException();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("WriteInt16(Object, Int32, Int16) may be unavailable in future releases.")]
	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	public static void WriteInt16(object ptr, int ofs, short val)
	{
		throw new PlatformNotSupportedException();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("WriteInt32(Object, Int32, Int32) may be unavailable in future releases.")]
	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	public static void WriteInt32(object ptr, int ofs, int val)
	{
		throw new PlatformNotSupportedException();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("WriteInt64(Object, Int32, Int64) may be unavailable in future releases.")]
	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	public static void WriteInt64(object ptr, int ofs, long val)
	{
		throw new PlatformNotSupportedException();
	}

	public static nint AllocHGlobal(int cb)
	{
		return AllocHGlobal((nint)cb);
	}

	public unsafe static string? PtrToStringAnsi(nint ptr)
	{
		if (IsNullOrWin32Atom(ptr))
		{
			return null;
		}
		return new string((sbyte*)ptr);
	}

	public unsafe static string PtrToStringAnsi(nint ptr, int len)
	{
		ArgumentNullException.ThrowIfNull(ptr, "ptr");
		ArgumentOutOfRangeException.ThrowIfNegative(len, "len");
		return new string((sbyte*)ptr, 0, len);
	}

	public unsafe static string? PtrToStringUni(nint ptr)
	{
		if (IsNullOrWin32Atom(ptr))
		{
			return null;
		}
		return new string((char*)ptr);
	}

	public unsafe static string PtrToStringUni(nint ptr, int len)
	{
		ArgumentNullException.ThrowIfNull(ptr, "ptr");
		ArgumentOutOfRangeException.ThrowIfNegative(len, "len");
		return new string((char*)ptr, 0, len);
	}

	public unsafe static string? PtrToStringUTF8(nint ptr)
	{
		if (IsNullOrWin32Atom(ptr))
		{
			return null;
		}
		int byteLength = string.strlen((byte*)ptr);
		return string.CreateStringFromEncoding((byte*)ptr, byteLength, Encoding.UTF8);
	}

	public unsafe static string PtrToStringUTF8(nint ptr, int byteLen)
	{
		ArgumentNullException.ThrowIfNull(ptr, "ptr");
		ArgumentOutOfRangeException.ThrowIfNegative(byteLen, "byteLen");
		return string.CreateStringFromEncoding((byte*)ptr, byteLen, Encoding.UTF8);
	}

	[RequiresDynamicCode("Marshalling code for the object might not be available. Use the SizeOf<T> overload instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int SizeOf(object structure)
	{
		ArgumentNullException.ThrowIfNull(structure, "structure");
		return SizeOfHelper((RuntimeType)structure.GetType(), throwIfNotMarshalable: true);
	}

	public static int SizeOf<T>(T structure)
	{
		ArgumentNullException.ThrowIfNull(structure, "structure");
		return SizeOfHelper((RuntimeType)structure.GetType(), throwIfNotMarshalable: true);
	}

	[RequiresDynamicCode("Marshalling code for the object might not be available. Use the SizeOf<T> overload instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int SizeOf(Type t)
	{
		ArgumentNullException.ThrowIfNull(t, "t");
		RuntimeType obj = (t as RuntimeType) ?? throw new ArgumentException("Argument_MustBeRuntimeType", "t");
		if (obj.IsGenericType)
		{
			throw new ArgumentException("Argument_NeedNonGenericType", "t");
		}
		return SizeOfHelper(obj, throwIfNotMarshalable: true);
	}

	public static int SizeOf<T>()
	{
		RuntimeType obj = (RuntimeType)typeof(T);
		if (obj.IsGenericType)
		{
			throw new ArgumentException("Argument_NeedNonGenericType", "T");
		}
		return SizeOfHelper(obj, throwIfNotMarshalable: true);
	}

	public unsafe static int QueryInterface(nint pUnk, in Guid iid, out nint ppv)
	{
		ArgumentNullException.ThrowIfNull(pUnk, "pUnk");
		fixed (Guid* ptr = &iid)
		{
			fixed (nint* ptr2 = &ppv)
			{
				return ((delegate* unmanaged<nint, Guid*, nint*, int>)(*(*(IntPtr**)pUnk)))(pUnk, ptr, ptr2);
			}
		}
	}

	public unsafe static int AddRef(nint pUnk)
	{
		ArgumentNullException.ThrowIfNull(pUnk, "pUnk");
		return ((delegate* unmanaged<nint, int>)(*(IntPtr*)((nint)(*(IntPtr*)pUnk) + sizeof(void*))))(pUnk);
	}

	public unsafe static int Release(nint pUnk)
	{
		ArgumentNullException.ThrowIfNull(pUnk, "pUnk");
		return ((delegate* unmanaged<nint, int>)(*(IntPtr*)((nint)(*(IntPtr*)pUnk) + (nint)2 * (nint)sizeof(void*))))(pUnk);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public unsafe static nint UnsafeAddrOfPinnedArrayElement(Array arr, int index)
	{
		ArgumentNullException.ThrowIfNull(arr, "arr");
		return (nint)((byte*)Unsafe.AsPointer(in MemoryMarshal.GetArrayDataReference(arr)) + (nuint)((nint)(uint)index * (nint)arr.GetElementSize()));
	}

	public unsafe static nint UnsafeAddrOfPinnedArrayElement<T>(T[] arr, int index)
	{
		ArgumentNullException.ThrowIfNull(arr, "arr");
		return (nint)((byte*)Unsafe.AsPointer(in MemoryMarshal.GetArrayDataReference(arr)) + (nuint)((nint)(uint)index * (nint)Unsafe.SizeOf<T>()));
	}

	public static nint OffsetOf<T>(string fieldName)
	{
		return OffsetOf(typeof(T), fieldName);
	}

	public static void Copy(int[] source, int startIndex, nint destination, int length)
	{
		CopyToNative(source, startIndex, destination, length);
	}

	public static void Copy(char[] source, int startIndex, nint destination, int length)
	{
		CopyToNative(source, startIndex, destination, length);
	}

	public static void Copy(short[] source, int startIndex, nint destination, int length)
	{
		CopyToNative(source, startIndex, destination, length);
	}

	public static void Copy(long[] source, int startIndex, nint destination, int length)
	{
		CopyToNative(source, startIndex, destination, length);
	}

	public static void Copy(float[] source, int startIndex, nint destination, int length)
	{
		CopyToNative(source, startIndex, destination, length);
	}

	public static void Copy(double[] source, int startIndex, nint destination, int length)
	{
		CopyToNative(source, startIndex, destination, length);
	}

	public static void Copy(byte[] source, int startIndex, nint destination, int length)
	{
		CopyToNative(source, startIndex, destination, length);
	}

	public static void Copy(nint[] source, int startIndex, nint destination, int length)
	{
		CopyToNative(source, startIndex, destination, length);
	}

	private unsafe static void CopyToNative<T>(T[] source, int startIndex, nint destination, int length)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		ArgumentNullException.ThrowIfNull(destination, "destination");
		new Span<T>(source, startIndex, length).CopyTo(new Span<T>((void*)destination, length));
	}

	public static void Copy(nint source, int[] destination, int startIndex, int length)
	{
		CopyToManaged(source, destination, startIndex, length);
	}

	public static void Copy(nint source, char[] destination, int startIndex, int length)
	{
		CopyToManaged(source, destination, startIndex, length);
	}

	public static void Copy(nint source, short[] destination, int startIndex, int length)
	{
		CopyToManaged(source, destination, startIndex, length);
	}

	public static void Copy(nint source, long[] destination, int startIndex, int length)
	{
		CopyToManaged(source, destination, startIndex, length);
	}

	public static void Copy(nint source, float[] destination, int startIndex, int length)
	{
		CopyToManaged(source, destination, startIndex, length);
	}

	public static void Copy(nint source, double[] destination, int startIndex, int length)
	{
		CopyToManaged(source, destination, startIndex, length);
	}

	public static void Copy(nint source, byte[] destination, int startIndex, int length)
	{
		CopyToManaged(source, destination, startIndex, length);
	}

	public static void Copy(nint source, nint[] destination, int startIndex, int length)
	{
		CopyToManaged(source, destination, startIndex, length);
	}

	private unsafe static void CopyToManaged<T>(nint source, T[] destination, int startIndex, int length)
	{
		ArgumentNullException.ThrowIfNull(destination, "destination");
		ArgumentNullException.ThrowIfNull(source, "source");
		ArgumentOutOfRangeException.ThrowIfNegative(startIndex, "startIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
		new Span<T>((void*)source, length).CopyTo(new Span<T>(destination, startIndex, length));
	}

	public unsafe static byte ReadByte(nint ptr, int ofs)
	{
		try
		{
			return *(byte*)(ptr + ofs);
		}
		catch (NullReferenceException)
		{
			throw new AccessViolationException();
		}
	}

	public static byte ReadByte(nint ptr)
	{
		return ReadByte(ptr, 0);
	}

	public unsafe static short ReadInt16(nint ptr, int ofs)
	{
		try
		{
			byte* ptr2 = (byte*)(ptr + ofs);
			if (((int)ptr2 & 1) == 0)
			{
				return *(short*)ptr2;
			}
			return Unsafe.ReadUnaligned<short>(ptr2);
		}
		catch (NullReferenceException)
		{
			throw new AccessViolationException();
		}
	}

	public static short ReadInt16(nint ptr)
	{
		return ReadInt16(ptr, 0);
	}

	public unsafe static int ReadInt32(nint ptr, int ofs)
	{
		try
		{
			byte* ptr2 = (byte*)(ptr + ofs);
			if (((int)ptr2 & 3) == 0)
			{
				return *(int*)ptr2;
			}
			return Unsafe.ReadUnaligned<int>(ptr2);
		}
		catch (NullReferenceException)
		{
			throw new AccessViolationException();
		}
	}

	public static int ReadInt32(nint ptr)
	{
		return ReadInt32(ptr, 0);
	}

	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("ReadIntPtr(Object, Int32) may be unavailable in future releases.")]
	public static nint ReadIntPtr(object ptr, int ofs)
	{
		return (nint)ReadInt64(ptr, ofs);
	}

	public static nint ReadIntPtr(nint ptr, int ofs)
	{
		return (nint)ReadInt64(ptr, ofs);
	}

	public static nint ReadIntPtr(nint ptr)
	{
		return ReadIntPtr(ptr, 0);
	}

	public unsafe static long ReadInt64(nint ptr, int ofs)
	{
		try
		{
			byte* ptr2 = (byte*)(ptr + ofs);
			if (((int)ptr2 & 7) == 0)
			{
				return *(long*)ptr2;
			}
			return Unsafe.ReadUnaligned<long>(ptr2);
		}
		catch (NullReferenceException)
		{
			throw new AccessViolationException();
		}
	}

	public static long ReadInt64(nint ptr)
	{
		return ReadInt64(ptr, 0);
	}

	public unsafe static void WriteByte(nint ptr, int ofs, byte val)
	{
		try
		{
			*(byte*)(ptr + ofs) = val;
		}
		catch (NullReferenceException)
		{
			throw new AccessViolationException();
		}
	}

	public static void WriteByte(nint ptr, byte val)
	{
		WriteByte(ptr, 0, val);
	}

	public unsafe static void WriteInt16(nint ptr, int ofs, short val)
	{
		try
		{
			byte* ptr2 = (byte*)(ptr + ofs);
			if (((int)ptr2 & 1) == 0)
			{
				*(short*)ptr2 = val;
			}
			else
			{
				Unsafe.WriteUnaligned(ptr2, val);
			}
		}
		catch (NullReferenceException)
		{
			throw new AccessViolationException();
		}
	}

	public static void WriteInt16(nint ptr, short val)
	{
		WriteInt16(ptr, 0, val);
	}

	public static void WriteInt16(nint ptr, int ofs, char val)
	{
		WriteInt16(ptr, ofs, (short)val);
	}

	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("WriteInt16(Object, Int32, Char) may be unavailable in future releases.")]
	public static void WriteInt16([In][Out] object ptr, int ofs, char val)
	{
		WriteInt16(ptr, ofs, (short)val);
	}

	public static void WriteInt16(nint ptr, char val)
	{
		WriteInt16(ptr, 0, (short)val);
	}

	public unsafe static void WriteInt32(nint ptr, int ofs, int val)
	{
		try
		{
			byte* ptr2 = (byte*)(ptr + ofs);
			if (((int)ptr2 & 3) == 0)
			{
				*(int*)ptr2 = val;
			}
			else
			{
				Unsafe.WriteUnaligned(ptr2, val);
			}
		}
		catch (NullReferenceException)
		{
			throw new AccessViolationException();
		}
	}

	public static void WriteInt32(nint ptr, int val)
	{
		WriteInt32(ptr, 0, val);
	}

	public static void WriteIntPtr(nint ptr, int ofs, nint val)
	{
		WriteInt64(ptr, ofs, val);
	}

	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("WriteIntPtr(Object, Int32, IntPtr) may be unavailable in future releases.")]
	public static void WriteIntPtr(object ptr, int ofs, nint val)
	{
		WriteInt64(ptr, ofs, val);
	}

	public static void WriteIntPtr(nint ptr, nint val)
	{
		WriteIntPtr(ptr, 0, val);
	}

	public unsafe static void WriteInt64(nint ptr, int ofs, long val)
	{
		try
		{
			byte* ptr2 = (byte*)(ptr + ofs);
			if (((int)ptr2 & 7) == 0)
			{
				*(long*)ptr2 = val;
			}
			else
			{
				Unsafe.WriteUnaligned(ptr2, val);
			}
		}
		catch (NullReferenceException)
		{
			throw new AccessViolationException();
		}
	}

	public static void WriteInt64(nint ptr, long val)
	{
		WriteInt64(ptr, 0, val);
	}

	public static void Prelink(MethodInfo m)
	{
		ArgumentNullException.ThrowIfNull(m, "m");
		PrelinkCore(m);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "This only needs to prelink methods that are actually used")]
	public static void PrelinkAll(Type c)
	{
		ArgumentNullException.ThrowIfNull(c, "c");
		MethodInfo[] methods = c.GetMethods();
		for (int i = 0; i < methods.Length; i++)
		{
			Prelink(methods[i]);
		}
	}

	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:AotUnfriendlyApi", Justification = "AOT compilers can see the T.")]
	public static void StructureToPtr<T>([DisallowNull] T structure, nint ptr, bool fDeleteOld)
	{
		StructureToPtr((object)structure, ptr, fDeleteOld);
	}

	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static object? PtrToStructure(nint ptr, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type structureType)
	{
		ArgumentNullException.ThrowIfNull(structureType, "structureType");
		if (ptr == IntPtr.Zero)
		{
			return null;
		}
		if (structureType.IsGenericType)
		{
			throw new ArgumentException("Argument_NeedNonGenericType", "structureType");
		}
		if (!(structureType is RuntimeType))
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "structureType");
		}
		object obj = Activator.CreateInstance(structureType, nonPublic: true);
		PtrToStructureHelper(ptr, obj, allowValueClasses: true);
		return obj;
	}

	[RequiresDynamicCode("Marshalling code for the object might not be available")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void PtrToStructure(nint ptr, object structure)
	{
		ArgumentNullException.ThrowIfNull(ptr, "ptr");
		ArgumentNullException.ThrowIfNull(structure, "structure");
		PtrToStructureHelper(ptr, structure, allowValueClasses: false);
	}

	public static void PtrToStructure<T>(nint ptr, [DisallowNull] T structure)
	{
		ArgumentNullException.ThrowIfNull(ptr, "ptr");
		object obj = structure;
		ArgumentNullException.ThrowIfNull(obj, "structure");
		PtrToStructureHelper(ptr, obj, allowValueClasses: false);
	}

	public static T? PtrToStructure<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(nint ptr)
	{
		if (ptr == IntPtr.Zero)
		{
			return (T)(object)null;
		}
		Type? typeFromHandle = typeof(T);
		if (typeFromHandle.IsGenericType)
		{
			throw new ArgumentException("Argument_NeedNonGenericType", "T");
		}
		object obj = Activator.CreateInstance(typeFromHandle, nonPublic: true);
		PtrToStructureHelper(ptr, obj, allowValueClasses: true);
		return (T)obj;
	}

	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:AotUnfriendlyApi", Justification = "AOT compilers can see the T.")]
	public static void DestroyStructure<T>(nint ptr)
	{
		DestroyStructure(ptr, typeof(T));
	}

	[RequiresAssemblyFiles("Windows only assigns HINSTANCE to assemblies loaded from disk. This API will return -1 for modules without a file on disk.")]
	public static nint GetHINSTANCE(Module m)
	{
		ArgumentNullException.ThrowIfNull(m, "m");
		return -1;
	}

	public static Exception? GetExceptionForHR(int errorCode)
	{
		return GetExceptionForHR(errorCode, IntPtr.Zero);
	}

	public static Exception? GetExceptionForHR(int errorCode, nint errorInfo)
	{
		if (errorCode >= 0)
		{
			return null;
		}
		return GetExceptionForHRInternal(errorCode, errorInfo);
	}

	public static Exception? GetExceptionForHR(int errorCode, in Guid iid, nint pUnk)
	{
		if (errorCode >= 0)
		{
			return null;
		}
		return GetExceptionForHRInternal(errorCode, in iid, pUnk);
	}

	private static Exception GetExceptionForHRInternal(int errorCode, in Guid iid, nint pUnk)
	{
		nint errorInfo = -1;
		return GetExceptionForHRInternal(errorCode, errorInfo);
	}

	private static Exception GetExceptionForHRInternal(int errorCode, nint errorInfo)
	{
		switch (errorCode)
		{
		case -2147475171:
			return new AmbiguousMatchException();
		case -2146232832:
			return new ApplicationException();
		case -2147024809:
			return new ArgumentException();
		case -2146233086:
			return new ArgumentOutOfRangeException();
		case -2147024362:
			return new ArithmeticException();
		case -2146233085:
			return new ArrayTypeMismatchException();
		case -2147024703:
			return new BadImageFormatException();
		case -2147024885:
			return new BadImageFormatException();
		case -2146232827:
			return new CustomAttributeFormatException();
		case -2146233023:
			return new DataMisalignedException();
		case -2147024893:
			return new DirectoryNotFoundException();
		case -2147352558:
			return new DivideByZeroException();
		case -2146233052:
			return new DllNotFoundException();
		case -2146233047:
			return new DuplicateWaitObjectException();
		case -2147024858:
			return new EndOfStreamException();
		case -2146233053:
			return new EntryPointNotFoundException();
		case -2146233088:
			return new Exception();
		case -2146233082:
			return new ExecutionEngineException();
		case -2146233081:
			return new FieldAccessException();
		case -2146232799:
			return new FileLoadException();
		case -2147024894:
			return new FileNotFoundException();
		case -2146233033:
			return new FormatException();
		case -2146233080:
			return new IndexOutOfRangeException();
		case -2146232968:
			return new InsufficientExecutionStackException();
		case -2147467262:
			return new InvalidCastException();
		case -2146232831:
			return new InvalidFilterCriteriaException();
		case -2146233039:
			return new InvalidOleVariantTypeException();
		case -2146233079:
			return new InvalidOperationException();
		case -2146233030:
			return new InvalidProgramException();
		case -2146232800:
			return new IOException();
		case -2146233035:
			return new MarshalDirectiveException();
		case -2146233062:
			return new MemberAccessException();
		case -2146233072:
			return new MethodAccessException();
		case -2146233071:
			return new MissingFieldException();
		case -2146233038:
			return new MissingManifestResourceException();
		case -2146233070:
			return new MissingMemberException();
		case -2146233069:
			return new MissingMethodException();
		case -2146233068:
			return new MulticastNotSupportedException();
		case -2146233048:
			return new NotFiniteNumberException();
		case -2146233067:
			return new NotSupportedException();
		case -2147467261:
			return new NullReferenceException();
		case -2146233029:
			return new OperationCanceledException();
		case -2147024882:
			return new OutOfMemoryException();
		case -2146233066:
			return new OverflowException();
		case -2147024690:
			return new PathTooLongException();
		case -2146233031:
			return new PlatformNotSupportedException();
		case -2146233065:
			return new RankException();
		case -2146232830:
			return new MissingMethodException();
		case -2146233026:
			return new MissingMethodException();
		case -2146233078:
			return new SecurityException();
		case -2146233076:
			return new SerializationException();
		case -2147023895:
			return new StackOverflowException();
		case -2146233064:
			return new SynchronizationLockException();
		case -2146233087:
			return new SystemException();
		case -2146232829:
			return new TargetException();
		case -2146232828:
			return new MissingMethodException();
		case -2147352562:
			return new TargetParameterCountException();
		case -2146233040:
			return new ThreadAbortException();
		case -2146233063:
			return new ThreadInterruptedException();
		case -2146233051:
			return new ThreadStartException();
		case -2146233056:
			return new ThreadStateException();
		case -2146233021:
			return new TypeAccessException();
		case -2146233036:
			return new TypeInitializationException(null);
		case -2146233054:
			return new TypeLoadException();
		case -2146234349:
			return new TypeUnloadedException();
		case -2147024891:
			return new UnauthorizedAccessException();
		case -2146233075:
			return new VerificationException();
		case -2147467263:
			return new NotImplementedException();
		case -2147483629:
		case -2146232798:
			return new ObjectDisposedException(null);
		case -2147287037:
		case -2146828212:
			return new DirectoryNotFoundException
			{
				HResult = errorCode
			};
		case -2147024892:
		case -2147024864:
		case -2147024863:
		case -2147024786:
		case -2147023891:
		case -2147023890:
		case -2147023782:
		case -2147023503:
		case -2146234346:
		case -2146234304:
		case -2146234297:
			return new FileLoadException
			{
				HResult = errorCode
			};
		case -2146828235:
			return new FileNotFoundException
			{
				HResult = errorCode
			};
		default:
			return new COMException(null, errorCode);
		}
	}

	public static void ThrowExceptionForHR(int errorCode)
	{
		if (errorCode < 0)
		{
			throw GetExceptionForHR(errorCode);
		}
	}

	public static void ThrowExceptionForHR(int errorCode, nint errorInfo)
	{
		if (errorCode < 0)
		{
			throw GetExceptionForHR(errorCode, errorInfo);
		}
	}

	public static void ThrowExceptionForHR(int errorCode, in Guid iid, nint pUnk)
	{
		if (errorCode < 0)
		{
			throw GetExceptionForHR(errorCode, in iid, pUnk);
		}
	}

	public static nint SecureStringToBSTR(SecureString s)
	{
		if (s == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.s);
		}
		return s.MarshalToBSTR();
	}

	public static nint SecureStringToCoTaskMemAnsi(SecureString s)
	{
		if (s == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.s);
		}
		return s.MarshalToString(globalAlloc: false, unicode: false);
	}

	public static nint SecureStringToCoTaskMemUnicode(SecureString s)
	{
		if (s == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.s);
		}
		return s.MarshalToString(globalAlloc: false, unicode: true);
	}

	public static nint SecureStringToGlobalAllocAnsi(SecureString s)
	{
		if (s == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.s);
		}
		return s.MarshalToString(globalAlloc: true, unicode: false);
	}

	public static nint SecureStringToGlobalAllocUnicode(SecureString s)
	{
		if (s == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.s);
		}
		return s.MarshalToString(globalAlloc: true, unicode: true);
	}

	public unsafe static nint StringToHGlobalAnsi(string? s)
	{
		if (s == null)
		{
			return IntPtr.Zero;
		}
		long num = (long)(s.Length + 1) * (long)SystemMaxDBCSCharSize;
		int num2 = (int)num;
		if (num2 != num)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.s);
		}
		nint num3 = AllocHGlobal((nint)num2);
		StringToAnsiString(s, (byte*)num3, num2);
		return num3;
	}

	public unsafe static nint StringToHGlobalUni(string? s)
	{
		if (s == null)
		{
			return IntPtr.Zero;
		}
		int num = (s.Length + 1) * 2;
		if (num < s.Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.s);
		}
		nint num2 = AllocHGlobal((nint)num);
		s.CopyTo(new Span<char>((void*)num2, s.Length));
		*(short*)(num2 + (nint)s.Length * (nint)2) = 0;
		return num2;
	}

	private unsafe static nint StringToHGlobalUTF8(string s)
	{
		if (s == null)
		{
			return IntPtr.Zero;
		}
		int maxByteCount = Encoding.UTF8.GetMaxByteCount(s.Length);
		byte* ptr;
		byte* result = (ptr = (byte*)AllocHGlobal(checked(maxByteCount + 1)));
		int bytes = Encoding.UTF8.GetBytes(s.AsSpan(), new Span<byte>(ptr, maxByteCount));
		ptr[bytes] = 0;
		return (nint)result;
	}

	public unsafe static nint StringToCoTaskMemUni(string? s)
	{
		if (s == null)
		{
			return IntPtr.Zero;
		}
		int num = (s.Length + 1) * 2;
		if (num < s.Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.s);
		}
		nint num2 = AllocCoTaskMem(num);
		s.CopyTo(new Span<char>((void*)num2, s.Length));
		*(short*)(num2 + (nint)s.Length * (nint)2) = 0;
		return num2;
	}

	public unsafe static nint StringToCoTaskMemUTF8(string? s)
	{
		if (s == null)
		{
			return IntPtr.Zero;
		}
		int maxByteCount = Encoding.UTF8.GetMaxByteCount(s.Length);
		byte* ptr;
		byte* result = (ptr = (byte*)AllocCoTaskMem(checked(maxByteCount + 1)));
		int bytes = Encoding.UTF8.GetBytes(s.AsSpan(), new Span<byte>(ptr, maxByteCount));
		ptr[bytes] = 0;
		return (nint)result;
	}

	public unsafe static nint StringToCoTaskMemAnsi(string? s)
	{
		if (s == null)
		{
			return IntPtr.Zero;
		}
		long num = (long)(s.Length + 1) * (long)SystemMaxDBCSCharSize;
		int num2 = (int)num;
		if (num2 != num)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.s);
		}
		nint num3 = AllocCoTaskMem(num2);
		StringToAnsiString(s, (byte*)num3, num2);
		return num3;
	}

	public static Guid GenerateGuidForType(Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		if (!(type is RuntimeType))
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "type");
		}
		return type.GUID;
	}

	[RequiresUnreferencedCode("Built-in COM support is not trim compatible", Url = "https://aka.ms/dotnet-illink/com")]
	public static string? GenerateProgIdForType(Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		if (type.IsImport)
		{
			throw new ArgumentException("Argument_TypeMustNotBeComImport", "type");
		}
		if (type.IsGenericType)
		{
			throw new ArgumentException("Argument_NeedNonGenericType", "type");
		}
		ProgIdAttribute customAttribute = type.GetCustomAttribute<ProgIdAttribute>();
		if (customAttribute != null)
		{
			return customAttribute.Value ?? string.Empty;
		}
		return type.FullName;
	}

	[RequiresDynamicCode("Marshalling code for the delegate might not be available. Use the GetDelegateForFunctionPointer<TDelegate> overload instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Delegate GetDelegateForFunctionPointer(nint ptr, Type t)
	{
		ArgumentNullException.ThrowIfNull(t, "t");
		ArgumentNullException.ThrowIfNull(ptr, "ptr");
		if (!(t is RuntimeType runtimeType))
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "t");
		}
		if (runtimeType.IsGenericType)
		{
			throw new ArgumentException("Argument_NeedNonGenericType", "t");
		}
		if (runtimeType.BaseType != typeof(MulticastDelegate) && runtimeType != typeof(MulticastDelegate))
		{
			throw new ArgumentException("Arg_MustBeDelegate", "t");
		}
		return GetDelegateForFunctionPointerInternal(ptr, runtimeType);
	}

	public static TDelegate GetDelegateForFunctionPointer<TDelegate>(nint ptr)
	{
		ArgumentNullException.ThrowIfNull(ptr, "ptr");
		RuntimeType runtimeType = (RuntimeType)typeof(TDelegate);
		if (runtimeType.IsGenericType)
		{
			throw new ArgumentException("Argument_NeedNonGenericType", "TDelegate");
		}
		if (runtimeType.BaseType != typeof(MulticastDelegate) && runtimeType != typeof(MulticastDelegate))
		{
			throw new ArgumentException("Arg_MustBeDelegate", "TDelegate");
		}
		return (TDelegate)(object)GetDelegateForFunctionPointerInternal(ptr, runtimeType);
	}

	[RequiresDynamicCode("Marshalling code for the delegate might not be available. Use the GetFunctionPointerForDelegate<TDelegate> overload instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static nint GetFunctionPointerForDelegate(Delegate d)
	{
		ArgumentNullException.ThrowIfNull(d, "d");
		return GetFunctionPointerForDelegateInternal(d);
	}

	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:AotUnfriendlyApi", Justification = "AOT compilers can see the T.")]
	public static nint GetFunctionPointerForDelegate<TDelegate>(TDelegate d) where TDelegate : notnull
	{
		return GetFunctionPointerForDelegate((Delegate)(object)d);
	}

	public static int GetHRForLastWin32Error()
	{
		int lastPInvokeError = GetLastPInvokeError();
		if ((lastPInvokeError & 0x80000000u) == 2147483648u)
		{
			return lastPInvokeError;
		}
		return (lastPInvokeError & 0xFFFF) | -2147024896;
	}

	public unsafe static void ZeroFreeBSTR(nint s)
	{
		if (s != IntPtr.Zero)
		{
			NativeMemory.Clear((void*)s, SysStringByteLen(s));
			FreeBSTR(s);
		}
	}

	public static void ZeroFreeCoTaskMemAnsi(nint s)
	{
		ZeroFreeCoTaskMemUTF8(s);
	}

	public unsafe static void ZeroFreeCoTaskMemUnicode(nint s)
	{
		if (s != IntPtr.Zero)
		{
			NativeMemory.Clear((void*)s, (nuint)string.wcslen((char*)s) * (nuint)2u);
			FreeCoTaskMem(s);
		}
	}

	public unsafe static void ZeroFreeCoTaskMemUTF8(nint s)
	{
		if (s != IntPtr.Zero)
		{
			NativeMemory.Clear((void*)s, (nuint)string.strlen((byte*)s));
			FreeCoTaskMem(s);
		}
	}

	public unsafe static void ZeroFreeGlobalAllocAnsi(nint s)
	{
		if (s != IntPtr.Zero)
		{
			NativeMemory.Clear((void*)s, (nuint)string.strlen((byte*)s));
			FreeHGlobal(s);
		}
	}

	public unsafe static void ZeroFreeGlobalAllocUnicode(nint s)
	{
		if (s != IntPtr.Zero)
		{
			NativeMemory.Clear((void*)s, (nuint)string.wcslen((char*)s) * (nuint)2u);
			FreeHGlobal(s);
		}
	}

	public unsafe static nint StringToBSTR(string? s)
	{
		if (s == null)
		{
			return IntPtr.Zero;
		}
		nint num = AllocBSTR(s.Length);
		s.CopyTo(new Span<char>((void*)num, s.Length));
		return num;
	}

	public static string PtrToStringBSTR(nint ptr)
	{
		ArgumentNullException.ThrowIfNull(ptr, "ptr");
		return PtrToStringUni(ptr, (int)(SysStringByteLen(ptr) / 2));
	}

	internal unsafe static uint SysStringByteLen(nint s)
	{
		return *(uint*)(s - 4);
	}

	[SupportedOSPlatform("windows")]
	public static Type? GetTypeFromCLSID(Guid clsid)
	{
		return GetTypeFromCLSID(clsid, null, throwOnError: false);
	}

	public static void InitHandle(SafeHandle safeHandle, nint handle)
	{
		safeHandle.SetHandle(handle);
	}

	public static int GetLastWin32Error()
	{
		return GetLastPInvokeError();
	}

	public static string GetLastPInvokeErrorMessage()
	{
		return GetPInvokeErrorMessage(GetLastPInvokeError());
	}

	public static int GetHRForException(Exception? e)
	{
		return e?.HResult ?? 0;
	}

	public static bool AreComObjectsAvailableForCleanup()
	{
		return false;
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static nint CreateAggregatedObject(nint pOuter, object o)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[RequiresUnreferencedCode("Built-in COM support is not trim compatible", Url = "https://aka.ms/dotnet-illink/com")]
	[SupportedOSPlatform("windows")]
	public static object BindToMoniker(string monikerName)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	public static void CleanupUnusedObjectsInCurrentContext()
	{
	}

	[SupportedOSPlatform("windows")]
	public static nint CreateAggregatedObject<T>(nint pOuter, T o) where T : notnull
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[return: NotNullIfNotNull("o")]
	public static object? CreateWrapperOfType(object? o, Type t)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static TWrapper CreateWrapperOfType<T, TWrapper>(T? o)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static void ChangeWrapperHandleStrength(object otp, bool fIsWeak)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static int FinalReleaseComObject(object o)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static nint GetComInterfaceForObject(object o, Type T)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static nint GetComInterfaceForObject(object o, Type T, CustomQueryInterfaceMode mode)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static nint GetComInterfaceForObject<T, TInterface>([DisallowNull] T o)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static object? GetComObjectData(object obj, object key)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static nint GetIDispatchForObject(object o)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static nint GetIUnknownForObject(object o)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void GetNativeVariantForObject(object? obj, nint pDstNativeVariant)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void GetNativeVariantForObject<T>(T? obj, nint pDstNativeVariant)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static object GetTypedObjectForIUnknown(nint pUnk, Type t)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static object GetObjectForIUnknown(nint pUnk)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static object? GetObjectForNativeVariant(nint pSrcNativeVariant)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static T? GetObjectForNativeVariant<T>(nint pSrcNativeVariant)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static object?[] GetObjectsForNativeVariants(nint aSrcNativeVariant, int cVars)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static T[] GetObjectsForNativeVariants<T>(nint aSrcNativeVariant, int cVars)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static int GetStartComSlot(Type t)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static int GetEndComSlot(Type t)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	internal static Type GetTypeFromCLSID(Guid clsid, string server, bool throwOnError)
	{
		if (throwOnError)
		{
			throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
		}
		return null;
	}

	[SupportedOSPlatform("windows")]
	public static string GetTypeInfoName(ITypeInfo typeInfo)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static object GetUniqueObjectForIUnknown(nint unknown)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	public static bool IsComObject(object o)
	{
		ArgumentNullException.ThrowIfNull(o, "o");
		return false;
	}

	public static bool IsTypeVisibleFromCom(Type t)
	{
		ArgumentNullException.ThrowIfNull(t, "t");
		return false;
	}

	[SupportedOSPlatform("windows")]
	public static int ReleaseComObject(object o)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	[SupportedOSPlatform("windows")]
	public static bool SetComObjectData(object obj, object key, object? data)
	{
		throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
	}

	public static string? PtrToStringAuto(nint ptr, int len)
	{
		return PtrToStringUTF8(ptr, len);
	}

	public static string? PtrToStringAuto(nint ptr)
	{
		return PtrToStringUTF8(ptr);
	}

	public static nint StringToHGlobalAuto(string? s)
	{
		return StringToHGlobalUTF8(s);
	}

	public static nint StringToCoTaskMemAuto(string? s)
	{
		return StringToCoTaskMemUTF8(s);
	}

	private static bool IsNullOrWin32Atom(nint ptr)
	{
		return ptr == IntPtr.Zero;
	}

	internal unsafe static int StringToAnsiString(string s, byte* buffer, int bufferLength, bool bestFit = false, bool throwOnUnmappableChar = false)
	{
		int bytes = Encoding.UTF8.GetBytes(s.AsSpan(), new Span<byte>(buffer, bufferLength));
		buffer[bytes] = 0;
		return bytes;
	}

	internal static int GetAnsiStringByteCount(ReadOnlySpan<char> chars)
	{
		return checked(Encoding.UTF8.GetByteCount(chars) + 1);
	}

	internal static void GetAnsiStringBytes(ReadOnlySpan<char> chars, Span<byte> bytes)
	{
		int bytes2 = Encoding.UTF8.GetBytes(chars, bytes);
		bytes[bytes2] = 0;
	}

	public unsafe static nint AllocHGlobal(nint cb)
	{
		return (nint)NativeMemory.Alloc((nuint)cb);
	}

	public unsafe static void FreeHGlobal(nint hglobal)
	{
		NativeMemory.Free((void*)hglobal);
	}

	public unsafe static nint ReAllocHGlobal(nint pv, nint cb)
	{
		return (nint)NativeMemory.Realloc((void*)pv, (nuint)cb);
	}

	public static nint AllocCoTaskMem(int cb)
	{
		return AllocHGlobal((nint)(uint)cb);
	}

	public static void FreeCoTaskMem(nint ptr)
	{
		FreeHGlobal(ptr);
	}

	public unsafe static nint ReAllocCoTaskMem(nint pv, int cb)
	{
		nuint num = (uint)cb;
		if (num == 0 && pv != (nint)0)
		{
			Interop.Sys.Free((void*)pv);
			return IntPtr.Zero;
		}
		return (nint)NativeMemory.Realloc((void*)pv, num);
	}

	internal unsafe static nint AllocBSTR(int length)
	{
		long num = 2L * (long)(uint)length + 8u + 2 + 15;
		if ((ulong)num > 4294967295uL)
		{
			throw new OutOfMemoryException();
		}
		void* num2 = Interop.Sys.Malloc((nuint)((nint)num & ~(nint)15));
		if (num2 == null)
		{
			throw new OutOfMemoryException();
		}
		void* ptr = (byte*)num2 + 8;
		*((int*)ptr - 1) = length * 2;
		((short*)ptr)[length] = 0;
		return (nint)ptr;
	}

	internal unsafe static nint AllocBSTRByteLen(uint length)
	{
		long num = (long)length + 8L + 2 + 15;
		if ((ulong)num > 4294967295uL)
		{
			throw new OutOfMemoryException();
		}
		void* num2 = Interop.Sys.Malloc((nuint)((nint)num & ~(nint)15));
		if (num2 == null)
		{
			throw new OutOfMemoryException();
		}
		void* ptr = (byte*)num2 + 8;
		*((int*)ptr - 1) = (int)length;
		((sbyte*)ptr)[length] = 0;
		*(short*)((byte*)ptr + ((length + 1) & -2)) = 0;
		return (nint)ptr;
	}

	public unsafe static void FreeBSTR(nint ptr)
	{
		if (ptr != (nint)0)
		{
			Interop.Sys.Free((void*)(ptr - 8));
		}
	}

	internal static Type GetTypeFromProgID(string progID, string server, bool throwOnError)
	{
		ArgumentNullException.ThrowIfNull(progID, "progID");
		if (throwOnError)
		{
			throw new PlatformNotSupportedException("PlatformNotSupported_ComInterop");
		}
		return null;
	}

	public static int GetLastSystemError()
	{
		return Interop.Sys.GetErrNo();
	}

	public static void SetLastSystemError(int error)
	{
		Interop.Sys.SetErrNo(error);
	}

	public static string GetPInvokeErrorMessage(int error)
	{
		return Interop.Sys.StrError(error);
	}
}
