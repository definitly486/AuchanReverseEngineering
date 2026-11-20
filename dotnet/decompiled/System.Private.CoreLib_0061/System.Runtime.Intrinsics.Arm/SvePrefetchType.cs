namespace System.Runtime.Intrinsics.Arm;

public enum SvePrefetchType : byte
{
	LoadL1Temporal = 0,
	LoadL1NonTemporal = 1,
	LoadL2Temporal = 2,
	LoadL2NonTemporal = 3,
	LoadL3Temporal = 4,
	LoadL3NonTemporal = 5,
	StoreL1Temporal = 8,
	StoreL1NonTemporal = 9,
	StoreL2Temporal = 10,
	StoreL2NonTemporal = 11,
	StoreL3Temporal = 12,
	StoreL3NonTemporal = 13
}
