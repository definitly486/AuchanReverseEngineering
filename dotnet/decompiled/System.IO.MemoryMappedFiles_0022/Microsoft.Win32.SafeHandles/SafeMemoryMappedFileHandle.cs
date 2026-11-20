using System;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace Microsoft.Win32.SafeHandles;

public sealed class SafeMemoryMappedFileHandle : SafeHandleZeroOrMinusOneIsInvalid
{
	internal SafeFileHandle _fileStreamHandle;

	internal readonly bool _ownsFileHandle;

	internal readonly HandleInheritability _inheritability;

	internal readonly MemoryMappedFileAccess _access;

	internal readonly MemoryMappedFileOptions _options;

	internal readonly long _capacity;

	public override bool IsInvalid => (long)handle <= 0L;

	internal SafeMemoryMappedFileHandle(SafeFileHandle fileHandle, bool ownsFileHandle, HandleInheritability inheritability, MemoryMappedFileAccess access, MemoryMappedFileOptions options, long capacity)
		: base(ownsHandle: true)
	{
		_ownsFileHandle = ownsFileHandle;
		_inheritability = inheritability;
		_access = access;
		_options = options;
		_capacity = capacity;
		nint num;
		if (fileHandle != null)
		{
			bool success = false;
			fileHandle.DangerousAddRef(ref success);
			_fileStreamHandle = fileHandle;
			num = fileHandle.DangerousGetHandle();
		}
		else
		{
			num = IntPtr.MaxValue;
		}
		SetHandle(num);
	}

	protected override bool ReleaseHandle()
	{
		if (_fileStreamHandle != null)
		{
			SetHandle(-1);
			if (_ownsFileHandle)
			{
				_fileStreamHandle.Dispose();
			}
			_fileStreamHandle.DangerousRelease();
			_fileStreamHandle = null;
		}
		return true;
	}
}
