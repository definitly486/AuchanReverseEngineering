using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SkiaSharp;

public abstract class SKObject : SKNativeObject
{
	private readonly object locker = new object();

	private ConcurrentDictionary<nint, SKObject> ownedObjects;

	private ConcurrentDictionary<nint, SKObject> keepAliveObjects;

	internal ConcurrentDictionary<nint, SKObject> OwnedObjects
	{
		get
		{
			if (ownedObjects == null)
			{
				lock (locker)
				{
					if (ownedObjects == null)
					{
						ownedObjects = new ConcurrentDictionary<nint, SKObject>();
					}
				}
			}
			return ownedObjects;
		}
	}

	internal ConcurrentDictionary<nint, SKObject> KeepAliveObjects
	{
		get
		{
			if (keepAliveObjects == null)
			{
				lock (locker)
				{
					if (keepAliveObjects == null)
					{
						keepAliveObjects = new ConcurrentDictionary<nint, SKObject>();
					}
				}
			}
			return keepAliveObjects;
		}
	}

	public override nint Handle
	{
		get
		{
			return base.Handle;
		}
		protected set
		{
			if (value == IntPtr.Zero)
			{
				DeregisterHandle(Handle, this);
				base.Handle = value;
			}
			else
			{
				base.Handle = value;
				RegisterHandle(Handle, this);
			}
		}
	}

	static SKObject()
	{
		SkiaSharpVersion.CheckNativeLibraryCompatible(throwIfIncompatible: true);
		SKColorSpace.EnsureStaticInstanceAreInitialized();
		SKData.EnsureStaticInstanceAreInitialized();
		SKFontManager.EnsureStaticInstanceAreInitialized();
		SKTypeface.EnsureStaticInstanceAreInitialized();
		SKBlender.EnsureStaticInstanceAreInitialized();
		SKColorFilter.EnsureStaticInstanceAreInitialized();
	}

	internal SKObject(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void DisposeUnownedManaged()
	{
		if (ownedObjects == null)
		{
			return;
		}
		foreach (KeyValuePair<nint, SKObject> ownedObject in ownedObjects)
		{
			SKObject value = ownedObject.Value;
			if (value != null && !value.OwnsHandle)
			{
				value.DisposeInternal();
			}
		}
	}

	protected override void DisposeManaged()
	{
		if (ownedObjects != null)
		{
			foreach (KeyValuePair<nint, SKObject> ownedObject in ownedObjects)
			{
				SKObject value = ownedObject.Value;
				if (value != null && value.OwnsHandle)
				{
					value.DisposeInternal();
				}
			}
			ownedObjects.Clear();
		}
		keepAliveObjects?.Clear();
	}

	protected override void DisposeNative()
	{
		if (this is ISKReferenceCounted obj)
		{
			obj.SafeUnRef();
		}
	}

	internal static TSkiaObject GetOrAddObject<TSkiaObject>(nint handle, Func<nint, bool, TSkiaObject> objectFactory) where TSkiaObject : SKObject
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		return HandleDictionary.GetOrAddObject(handle, owns: true, unrefExisting: true, objectFactory);
	}

	internal static TSkiaObject GetOrAddObject<TSkiaObject>(nint handle, bool owns, bool unrefExisting, Func<nint, bool, TSkiaObject> objectFactory) where TSkiaObject : SKObject
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		return HandleDictionary.GetOrAddObject(handle, owns, unrefExisting, objectFactory);
	}

	internal static void RegisterHandle(nint handle, SKObject instance)
	{
		if (handle != IntPtr.Zero && instance != null)
		{
			HandleDictionary.RegisterHandle(handle, instance);
		}
	}

	internal static void DeregisterHandle(nint handle, SKObject instance)
	{
		if (handle != IntPtr.Zero)
		{
			HandleDictionary.DeregisterHandle(handle, instance);
		}
	}

	internal static T OwnedBy<T>(T child, SKObject owner) where T : SKObject
	{
		if (child != null)
		{
			owner.OwnedObjects[child.Handle] = child;
		}
		return child;
	}

	internal static T Referenced<T>(T owner, SKObject child) where T : SKObject
	{
		if (child != null && owner != null)
		{
			owner.KeepAliveObjects[child.Handle] = child;
		}
		return owner;
	}
}
