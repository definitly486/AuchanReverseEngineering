using System.Runtime.InteropServices;

namespace System.Net.NetworkInformation;

internal static class NetworkInterfacePal
{
	public static NetworkInterface[] GetAllNetworkInterfaces()
	{
		return GetAndroidNetworkInterfaces();
	}

	public static bool GetIsNetworkAvailable()
	{
		return TransformNetworkInterfacess(IsSomeNetworkUp);
	}

	internal static AndroidNetworkInterface[] GetAndroidNetworkInterfaces()
	{
		return TransformNetworkInterfacess(ToAndroidNetworkInterfaceArray);
	}

	private unsafe static T TransformNetworkInterfacess<T>(Func<int, nint, int, nint, T> transform)
	{
		int arg = 0;
		int arg2 = 0;
		global::Interop.Sys.NetworkInterfaceInfo* ptr = null;
		global::Interop.Sys.IpAddressInfo* arg3 = null;
		if (global::Interop.Sys.GetNetworkInterfaces(&arg, &ptr, &arg2, &arg3) != 0)
		{
			throw new NetworkInformationException(global::Interop.Sys.GetLastErrorInfo().GetErrorMessage());
		}
		nint hglobal = (nint)ptr;
		try
		{
			return transform(arg, (nint)ptr, arg2, (nint)arg3);
		}
		finally
		{
			Marshal.FreeHGlobal(hglobal);
		}
	}

	private unsafe static AndroidNetworkInterface[] ToAndroidNetworkInterfaceArray(int interfaceCount, nint networkInterfacesPtr, int addressCount, nint addressPtr)
	{
		AndroidNetworkInterface[] array = new AndroidNetworkInterface[interfaceCount];
		global::Interop.Sys.NetworkInterfaceInfo* ptr = (global::Interop.Sys.NetworkInterfaceInfo*)networkInterfacesPtr;
		int num = 0;
		while (num < interfaceCount)
		{
			string name = Marshal.PtrToStringUTF8((nint)ptr->Name);
			array[num] = new AndroidNetworkInterface(name, ptr);
			num++;
			ptr++;
		}
		global::Interop.Sys.IpAddressInfo* ptr2 = (global::Interop.Sys.IpAddressInfo*)addressPtr;
		int num2 = 0;
		while (num2 < addressCount)
		{
			AndroidNetworkInterface[] array2 = array;
			foreach (AndroidNetworkInterface androidNetworkInterface in array2)
			{
				if (androidNetworkInterface.Index == ptr2->InterfaceIndex)
				{
					androidNetworkInterface.AddAddress(ptr2);
					break;
				}
			}
			num2++;
			ptr2++;
		}
		return array;
	}

	private unsafe static bool IsSomeNetworkUp(int interfaceCount, nint networkInterfacesPtr, int addressCount, nint addressPtr)
	{
		global::Interop.Sys.NetworkInterfaceInfo* ptr = (global::Interop.Sys.NetworkInterfaceInfo*)networkInterfacesPtr;
		int num = 0;
		while (num < interfaceCount)
		{
			if (ptr->HardwareType != 24 && ptr->HardwareType != 131 && ptr->OperationalState == 1)
			{
				return true;
			}
			num++;
			ptr++;
		}
		return false;
	}
}
