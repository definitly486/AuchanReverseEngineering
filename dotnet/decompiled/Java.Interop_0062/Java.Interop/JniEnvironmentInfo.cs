using System;
using System.Runtime.CompilerServices;

namespace Java.Interop;

internal sealed class JniEnvironmentInfo : IDisposable
{
	private nint environmentPointer;

	private char[]? nameBuffer;

	private bool disposed;

	private JniRuntime? runtime;

	public int LocalReferenceCount { get; internal set; }

	public bool WithinNewObjectScope { get; set; }

	public JniRuntime Runtime
	{
		get
		{
			return runtime ?? throw new NotSupportedException();
		}
		private set
		{
			runtime = value;
		}
	}

	public nint EnvironmentPointer
	{
		get
		{
			return environmentPointer;
		}
		set
		{
			if (disposed)
			{
				throw new ObjectDisposedException("JniEnvironmentInfo");
			}
			if (environmentPointer != value)
			{
				environmentPointer = value;
				nint vm = IntPtr.Zero;
				int javaVM = JniEnvironment.References.GetJavaVM(EnvironmentPointer, out vm);
				if (javaVM < 0)
				{
					throw new InvalidOperationException("JNIEnv::GetJavaVM() returned: " + javaVM);
				}
				JniRuntime registeredRuntime = JniRuntime.GetRegisteredRuntime(vm);
				if (registeredRuntime == null)
				{
					throw new NotSupportedException(string.Format("No JavaVM registered with handle 0x{0}.", ((IntPtr)vm).ToString("x")));
				}
				Runtime = registeredRuntime;
			}
		}
	}

	public bool IsValid
	{
		get
		{
			if (Runtime != null)
			{
				return environmentPointer != IntPtr.Zero;
			}
			return false;
		}
	}

	public JniEnvironmentInfo()
	{
		Runtime = JniRuntime.CurrentRuntime;
		EnvironmentPointer = Runtime._AttachCurrentThread();
	}

	internal JniEnvironmentInfo(nint environmentPointer, JniRuntime runtime)
	{
		EnvironmentPointer = environmentPointer;
		Runtime = runtime;
	}

	internal unsafe JniObjectReference ToJavaName(string jniTypeName)
	{
		if (jniTypeName.IndexOf("/", StringComparison.Ordinal) == -1)
		{
			return JniEnvironment.Strings.NewString(jniTypeName);
		}
		int length = jniTypeName.Length;
		if (length > 512)
		{
			return JniEnvironment.Strings.NewString(jniTypeName.Replace('/', '.'));
		}
		if (nameBuffer == null)
		{
			nameBuffer = new char[512];
		}
		fixed (char* ptr = jniTypeName)
		{
			char[]? array = nameBuffer;
			fixed (char[] array2 = array)
			{
				char* ptr2 = (char*)((array != null && array2.Length != 0) ? Unsafe.AsPointer(ref array2[0]) : null);
				char* ptr3 = ptr;
				char* ptr4 = ptr2;
				char* ptr5 = ptr + length;
				while (ptr3 < ptr5)
				{
					*ptr4 = ((*ptr3 == '/') ? '.' : (*ptr3));
					ptr3++;
					ptr4++;
				}
				return JniEnvironment.Strings.NewString(ptr2, length);
			}
		}
	}

	public void Dispose()
	{
		if (!disposed)
		{
			runtime = null;
			environmentPointer = IntPtr.Zero;
			nameBuffer = null;
			LocalReferenceCount = 0;
			disposed = true;
		}
	}
}
