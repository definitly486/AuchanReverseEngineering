using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace SkiaSharp;

internal static class DelegateProxies
{
	public unsafe static readonly delegate* unmanaged[Cdecl]<void*, void*, nint> GRGlGetProcProxy = (delegate* unmanaged[Cdecl]<void*, void*, nint>)(delegate*<void*, void*, nint>)(&GRGlGetProcProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<void*, void*, nint, nint, nint> GRVkGetProcProxy = (delegate* unmanaged[Cdecl]<void*, void*, nint, nint, nint>)(delegate*<void*, void*, nint, nint, nint>)(&GRVkGetProcProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<void*, void*, void> SKBitmapReleaseProxy = (delegate* unmanaged[Cdecl]<void*, void*, void>)(delegate*<void*, void*, void>)(&SKBitmapReleaseProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<void*, void*, void> SKDataReleaseProxy = (delegate* unmanaged[Cdecl]<void*, void*, void>)(delegate*<void*, void*, void>)(&SKDataReleaseProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, SKMatrix*, void*, void> SKGlyphPathProxy = (delegate* unmanaged[Cdecl]<nint, SKMatrix*, void*, void>)(delegate*<nint, SKMatrix*, void*, void>)(&SKGlyphPathProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<void*, void*, void> SKImageRasterReleaseProxy = (delegate* unmanaged[Cdecl]<void*, void*, void>)(delegate*<void*, void*, void>)(&SKImageRasterReleaseProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<void*, void*, void> SKImageRasterReleaseProxyForCoTaskMem = (delegate* unmanaged[Cdecl]<void*, void*, void>)(delegate*<void*, void*, void>)(&SKImageRasterReleaseProxyImplementationForCoTaskMem);

	public unsafe static readonly delegate* unmanaged[Cdecl]<void*, void> SKImageTextureReleaseProxy = (delegate* unmanaged[Cdecl]<void*, void>)(delegate*<void*, void>)(&SKImageTextureReleaseProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint> SKManagedDrawableApproximateBytesUsedProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint>)(delegate*<nint, void*, nint>)(&SKManagedDrawableApproximateBytesUsedProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void> SKManagedDrawableDestroyProxy = (delegate* unmanaged[Cdecl]<nint, void*, void>)(delegate*<nint, void*, void>)(&SKManagedDrawableDestroyProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint, void> SKManagedDrawableDrawProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint, void>)(delegate*<nint, void*, nint, void>)(&SKManagedDrawableDrawProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, SKRect*, void> SKManagedDrawableGetBoundsProxy = (delegate* unmanaged[Cdecl]<nint, void*, SKRect*, void>)(delegate*<nint, void*, SKRect*, void>)(&SKManagedDrawableGetBoundsProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint> SKManagedDrawableMakePictureSnapshotProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint>)(delegate*<nint, void*, nint>)(&SKManagedDrawableMakePictureSnapshotProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void> SKManagedStreamDestroyProxy = (delegate* unmanaged[Cdecl]<nint, void*, void>)(delegate*<nint, void*, void>)(&SKManagedStreamDestroyProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint> SKManagedStreamDuplicateProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint>)(delegate*<nint, void*, nint>)(&SKManagedStreamDuplicateProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint> SKManagedStreamForkProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint>)(delegate*<nint, void*, nint>)(&SKManagedStreamForkProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint> SKManagedStreamGetLengthProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint>)(delegate*<nint, void*, nint>)(&SKManagedStreamGetLengthProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint> SKManagedStreamGetPositionProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint>)(delegate*<nint, void*, nint>)(&SKManagedStreamGetPositionProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, bool> SKManagedStreamHasLengthProxy = (delegate* unmanaged[Cdecl]<nint, void*, bool>)(delegate*<nint, void*, bool>)(&SKManagedStreamHasLengthProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, bool> SKManagedStreamHasPositionProxy = (delegate* unmanaged[Cdecl]<nint, void*, bool>)(delegate*<nint, void*, bool>)(&SKManagedStreamHasPositionProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, bool> SKManagedStreamIsAtEndProxy = (delegate* unmanaged[Cdecl]<nint, void*, bool>)(delegate*<nint, void*, bool>)(&SKManagedStreamIsAtEndProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, int, bool> SKManagedStreamMoveProxy = (delegate* unmanaged[Cdecl]<nint, void*, int, bool>)(delegate*<nint, void*, int, bool>)(&SKManagedStreamMoveProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void*, nint, nint> SKManagedStreamPeekProxy = (delegate* unmanaged[Cdecl]<nint, void*, void*, nint, nint>)(delegate*<nint, void*, void*, nint, nint>)(&SKManagedStreamPeekProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void*, nint, nint> SKManagedStreamReadProxy = (delegate* unmanaged[Cdecl]<nint, void*, void*, nint, nint>)(delegate*<nint, void*, void*, nint, nint>)(&SKManagedStreamReadProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, bool> SKManagedStreamRewindProxy = (delegate* unmanaged[Cdecl]<nint, void*, bool>)(delegate*<nint, void*, bool>)(&SKManagedStreamRewindProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint, bool> SKManagedStreamSeekProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint, bool>)(delegate*<nint, void*, nint, bool>)(&SKManagedStreamSeekProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void*, void*, void*, ulong, void> SKManagedTraceMemoryDumpDumpNumericValueProxy = (delegate* unmanaged[Cdecl]<nint, void*, void*, void*, void*, ulong, void>)(delegate*<nint, void*, void*, void*, void*, ulong, void>)(&SKManagedTraceMemoryDumpDumpNumericValueProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void*, void*, void*, void> SKManagedTraceMemoryDumpDumpStringValueProxy = (delegate* unmanaged[Cdecl]<nint, void*, void*, void*, void*, void>)(delegate*<nint, void*, void*, void*, void*, void>)(&SKManagedTraceMemoryDumpDumpStringValueProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, nint> SKManagedWStreamBytesWrittenProxy = (delegate* unmanaged[Cdecl]<nint, void*, nint>)(delegate*<nint, void*, nint>)(&SKManagedWStreamBytesWrittenProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void> SKManagedWStreamDestroyProxy = (delegate* unmanaged[Cdecl]<nint, void*, void>)(delegate*<nint, void*, void>)(&SKManagedWStreamDestroyProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void> SKManagedWStreamFlushProxy = (delegate* unmanaged[Cdecl]<nint, void*, void>)(delegate*<nint, void*, void>)(&SKManagedWStreamFlushProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<nint, void*, void*, nint, bool> SKManagedWStreamWriteProxy = (delegate* unmanaged[Cdecl]<nint, void*, void*, nint, bool>)(delegate*<nint, void*, void*, nint, bool>)(&SKManagedWStreamWriteProxyImplementation);

	public unsafe static readonly delegate* unmanaged[Cdecl]<void*, void*, void> SKSurfaceRasterReleaseProxy = (delegate* unmanaged[Cdecl]<void*, void*, void>)(delegate*<void*, void*, void>)(&SKSurfaceRasterReleaseProxyImplementation);

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint GRGlGetProcProxyImplementation(void* ctx, void* name)
	{
		GCHandle gch;
		GRGlGetProcedureAddressDelegate gRGlGetProcedureAddressDelegate = Get<GRGlGetProcedureAddressDelegate>((nint)ctx, out gch);
		return gRGlGetProcedureAddressDelegate(Marshal.PtrToStringAnsi((nint)name));
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint GRVkGetProcProxyImplementation(void* ctx, void* name, nint instance, nint device)
	{
		GCHandle gch;
		GRVkGetProcedureAddressDelegate gRVkGetProcedureAddressDelegate = Get<GRVkGetProcedureAddressDelegate>((nint)ctx, out gch);
		return gRVkGetProcedureAddressDelegate(Marshal.PtrToStringAnsi((nint)name), instance, device);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKBitmapReleaseProxyImplementation(void* addr, void* context)
	{
		GCHandle gch;
		SKBitmapReleaseDelegate sKBitmapReleaseDelegate = Get<SKBitmapReleaseDelegate>((nint)context, out gch);
		try
		{
			sKBitmapReleaseDelegate((nint)addr, null);
		}
		finally
		{
			gch.Free();
		}
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKDataReleaseProxyImplementation(void* ptr, void* context)
	{
		GCHandle gch;
		SKDataReleaseDelegate sKDataReleaseDelegate = Get<SKDataReleaseDelegate>((nint)context, out gch);
		try
		{
			sKDataReleaseDelegate((nint)ptr, null);
		}
		finally
		{
			gch.Free();
		}
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKGlyphPathProxyImplementation(nint pathOrNull, SKMatrix* matrix, void* context)
	{
		GCHandle gch;
		SKGlyphPathDelegate sKGlyphPathDelegate = Get<SKGlyphPathDelegate>((nint)context, out gch);
		SKPath path = SKPath.GetObject(pathOrNull, owns: false);
		sKGlyphPathDelegate(path, *matrix);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKImageRasterReleaseProxyImplementation(void* addr, void* context)
	{
		GCHandle gch;
		SKImageRasterReleaseDelegate sKImageRasterReleaseDelegate = Get<SKImageRasterReleaseDelegate>((nint)context, out gch);
		try
		{
			sKImageRasterReleaseDelegate((nint)addr, null);
		}
		finally
		{
			gch.Free();
		}
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKImageRasterReleaseProxyImplementationForCoTaskMem(void* addr, void* context)
	{
		Marshal.FreeCoTaskMem((nint)addr);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKImageTextureReleaseProxyImplementation(void* context)
	{
		GCHandle gch;
		SKImageTextureReleaseDelegate sKImageTextureReleaseDelegate = Get<SKImageTextureReleaseDelegate>((nint)context, out gch);
		try
		{
			sKImageTextureReleaseDelegate(null);
		}
		finally
		{
			gch.Free();
		}
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedDrawableApproximateBytesUsedProxyImplementation(nint d, void* context)
	{
		GCHandle gch;
		SKDrawable userData = GetUserData<SKDrawable>((nint)context, out gch);
		return userData.OnGetApproximateBytesUsed();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKManagedDrawableDestroyProxyImplementation(nint d, void* context)
	{
		GCHandle gch;
		SKDrawable userData = GetUserData<SKDrawable>((nint)context, out gch);
		if (userData != null)
		{
			Interlocked.Exchange(ref userData.fromNative, 1);
			userData.Dispose();
		}
		gch.Free();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKManagedDrawableDrawProxyImplementation(nint d, void* context, nint ccanvas)
	{
		GCHandle gch;
		SKDrawable userData = GetUserData<SKDrawable>((nint)context, out gch);
		userData.OnDraw(SKCanvas.GetObject(ccanvas, owns: false));
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKManagedDrawableGetBoundsProxyImplementation(nint d, void* context, SKRect* rect)
	{
		GCHandle gch;
		SKDrawable userData = GetUserData<SKDrawable>((nint)context, out gch);
		SKRect sKRect = userData.OnGetBounds();
		*rect = sKRect;
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedDrawableMakePictureSnapshotProxyImplementation(nint d, void* context)
	{
		GCHandle gch;
		SKDrawable userData = GetUserData<SKDrawable>((nint)context, out gch);
		return userData.OnSnapshot()?.Handle ?? IntPtr.Zero;
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKManagedStreamDestroyProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		if (userData != null)
		{
			Interlocked.Exchange(ref userData.fromNative, 1);
			userData.Dispose();
		}
		gch.Free();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedStreamDuplicateProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnDuplicate();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedStreamForkProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnFork();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedStreamGetLengthProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnGetLength();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedStreamGetPositionProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnGetPosition();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	[return: MarshalAs(UnmanagedType.I1)]
	private unsafe static bool SKManagedStreamHasLengthProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnHasLength();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	[return: MarshalAs(UnmanagedType.I1)]
	private unsafe static bool SKManagedStreamHasPositionProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnHasPosition();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	[return: MarshalAs(UnmanagedType.I1)]
	private unsafe static bool SKManagedStreamIsAtEndProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnIsAtEnd();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	[return: MarshalAs(UnmanagedType.I1)]
	private unsafe static bool SKManagedStreamMoveProxyImplementation(nint s, void* context, int offset)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnMove(offset);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedStreamPeekProxyImplementation(nint s, void* context, void* buffer, nint size)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnPeek((nint)buffer, size);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedStreamReadProxyImplementation(nint s, void* context, void* buffer, nint size)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnRead((nint)buffer, size);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	[return: MarshalAs(UnmanagedType.I1)]
	private unsafe static bool SKManagedStreamRewindProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnRewind();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	[return: MarshalAs(UnmanagedType.I1)]
	private unsafe static bool SKManagedStreamSeekProxyImplementation(nint s, void* context, nint position)
	{
		GCHandle gch;
		SKAbstractManagedStream userData = GetUserData<SKAbstractManagedStream>((nint)context, out gch);
		return userData.OnSeek(position);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKManagedTraceMemoryDumpDumpNumericValueProxyImplementation(nint d, void* context, void* dumpName, void* valueName, void* units, ulong value)
	{
		GCHandle gch;
		SKTraceMemoryDump userData = GetUserData<SKTraceMemoryDump>((nint)context, out gch);
		userData.OnDumpNumericValue(Marshal.PtrToStringAnsi((nint)dumpName), Marshal.PtrToStringAnsi((nint)valueName), Marshal.PtrToStringAnsi((nint)units), value);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKManagedTraceMemoryDumpDumpStringValueProxyImplementation(nint d, void* context, void* dumpName, void* valueName, void* value)
	{
		GCHandle gch;
		SKTraceMemoryDump userData = GetUserData<SKTraceMemoryDump>((nint)context, out gch);
		userData.OnDumpStringValue(Marshal.PtrToStringAnsi((nint)dumpName), Marshal.PtrToStringAnsi((nint)valueName), Marshal.PtrToStringAnsi((nint)value));
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static nint SKManagedWStreamBytesWrittenProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedWStream userData = GetUserData<SKAbstractManagedWStream>((nint)context, out gch);
		return userData.OnBytesWritten();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKManagedWStreamDestroyProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedWStream userData = GetUserData<SKAbstractManagedWStream>((nint)context, out gch);
		if (userData != null)
		{
			Interlocked.Exchange(ref userData.fromNative, 1);
			userData.Dispose();
		}
		gch.Free();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKManagedWStreamFlushProxyImplementation(nint s, void* context)
	{
		GCHandle gch;
		SKAbstractManagedWStream userData = GetUserData<SKAbstractManagedWStream>((nint)context, out gch);
		userData.OnFlush();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	[return: MarshalAs(UnmanagedType.I1)]
	private unsafe static bool SKManagedWStreamWriteProxyImplementation(nint s, void* context, void* buffer, nint size)
	{
		GCHandle gch;
		SKAbstractManagedWStream userData = GetUserData<SKAbstractManagedWStream>((nint)context, out gch);
		return userData.OnWrite((nint)buffer, size);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static void SKSurfaceRasterReleaseProxyImplementation(void* addr, void* context)
	{
		GCHandle gch;
		SKSurfaceReleaseDelegate sKSurfaceReleaseDelegate = Get<SKSurfaceReleaseDelegate>((nint)context, out gch);
		try
		{
			sKSurfaceReleaseDelegate((nint)addr, null);
		}
		finally
		{
			gch.Free();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Create(object managedDel, out GCHandle gch, out nint contextPtr)
	{
		if (managedDel == null)
		{
			gch = default(GCHandle);
			contextPtr = IntPtr.Zero;
		}
		else
		{
			gch = GCHandle.Alloc(managedDel);
			contextPtr = GCHandle.ToIntPtr(gch);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Get<T>(nint contextPtr, out GCHandle gch)
	{
		if (contextPtr == IntPtr.Zero)
		{
			gch = default(GCHandle);
			return default(T);
		}
		gch = GCHandle.FromIntPtr(contextPtr);
		return (T)gch.Target;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint CreateUserData(object userData, bool makeWeak = false)
	{
		userData = (makeWeak ? new WeakReference(userData) : userData);
		UserDataDelegate managedDel = () => userData;
		Create(managedDel, out var _, out var contextPtr);
		return contextPtr;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetUserData<T>(nint contextPtr, out GCHandle gch)
	{
		UserDataDelegate userDataDelegate = Get<UserDataDelegate>(contextPtr, out gch);
		object obj = userDataDelegate();
		if (!(obj is WeakReference weakReference))
		{
			return (T)obj;
		}
		return (T)weakReference.Target;
	}
}
