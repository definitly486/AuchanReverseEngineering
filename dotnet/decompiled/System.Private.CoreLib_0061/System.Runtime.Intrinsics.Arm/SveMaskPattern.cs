namespace System.Runtime.Intrinsics.Arm;

public enum SveMaskPattern : byte
{
	LargestPowerOf2 = 0,
	VectorCount1 = 1,
	VectorCount2 = 2,
	VectorCount3 = 3,
	VectorCount4 = 4,
	VectorCount5 = 5,
	VectorCount6 = 6,
	VectorCount7 = 7,
	VectorCount8 = 8,
	VectorCount16 = 9,
	VectorCount32 = 10,
	VectorCount64 = 11,
	VectorCount128 = 12,
	VectorCount256 = 13,
	LargestMultipleOf4 = 29,
	LargestMultipleOf3 = 30,
	All = 31
}
