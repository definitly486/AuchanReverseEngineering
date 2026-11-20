using System;
using System.Runtime.CompilerServices;

namespace Java.Interop;

public struct JniObjectReference : IEquatable<JniObjectReference>
{
	private uint referenceInfo;

	public nint Handle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
		private set; }

	public JniObjectReferenceType Type => (JniObjectReferenceType)(referenceInfo & 0xFFFF);

	internal JniObjectReferenceFlags Flags
	{
		set
		{
			referenceInfo |= (uint)value & 0xFFFF0000u;
		}
	}

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return Handle != IntPtr.Zero;
		}
	}

	public JniObjectReference(nint handle, JniObjectReferenceType type = JniObjectReferenceType.Invalid)
	{
		referenceInfo = (uint)type;
		Handle = handle;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)Handle).GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		JniObjectReference? jniObjectReference = obj as JniObjectReference?;
		if (jniObjectReference.HasValue)
		{
			return Equals(jniObjectReference.Value);
		}
		return false;
	}

	public bool Equals(JniObjectReference other)
	{
		return Handle == other.Handle;
	}

	public static bool operator ==(JniObjectReference lhs, JniObjectReference rhs)
	{
		return lhs.Handle == rhs.Handle;
	}

	public static bool operator !=(JniObjectReference lhs, JniObjectReference rhs)
	{
		return lhs.Handle != rhs.Handle;
	}

	public JniObjectReference NewGlobalRef()
	{
		return JniEnvironment.Runtime.ObjectReferenceManager.CreateGlobalReference(this);
	}

	public JniObjectReference NewLocalRef()
	{
		return JniEnvironment.Runtime.ObjectReferenceManager.CreateLocalReference(JniEnvironment.CurrentInfo, this);
	}

	internal void Invalidate()
	{
		Handle = IntPtr.Zero;
		referenceInfo = 0u;
	}

	public override string ToString()
	{
		return "0x" + ((IntPtr)Handle).ToString("x") + "/" + ToString(Type);
	}

	private static string ToString(JniObjectReferenceType type)
	{
		return type switch
		{
			JniObjectReferenceType.Global => "G", 
			JniObjectReferenceType.Invalid => "I", 
			JniObjectReferenceType.Local => "L", 
			JniObjectReferenceType.WeakGlobal => "W", 
			_ => type.ToString(), 
		};
	}

	public static void Dispose(ref JniObjectReference reference)
	{
		if (reference.IsValid)
		{
			switch (reference.Type)
			{
			case JniObjectReferenceType.Global:
				JniEnvironment.Runtime.ObjectReferenceManager.DeleteGlobalReference(ref reference);
				break;
			case JniObjectReferenceType.Local:
				JniEnvironment.Runtime.ObjectReferenceManager.DeleteLocalReference(JniEnvironment.CurrentInfo, ref reference);
				break;
			case JniObjectReferenceType.WeakGlobal:
				JniEnvironment.Runtime.ObjectReferenceManager.DeleteWeakGlobalReference(ref reference);
				break;
			default:
				throw new NotImplementedException("Do not know how to dispose: " + reference.Type.ToString() + ".");
			case JniObjectReferenceType.Invalid:
				break;
			}
			reference.Invalidate();
		}
	}

	public static void Dispose(ref JniObjectReference reference, JniObjectReferenceOptions options)
	{
		if (options != JniObjectReferenceOptions.None && reference.IsValid && (options & (JniObjectReferenceOptions)2) != JniObjectReferenceOptions.None)
		{
			Dispose(ref reference);
		}
	}
}
