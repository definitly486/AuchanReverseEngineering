using System.ComponentModel;

namespace System.Diagnostics.CodeAnalysis;

[Flags]
public enum DynamicallyAccessedMemberTypes
{
	None = 0,
	PublicParameterlessConstructor = 1,
	PublicConstructors = 3,
	NonPublicConstructors = 4,
	PublicMethods = 8,
	NonPublicMethods = 0x10,
	PublicFields = 0x20,
	NonPublicFields = 0x40,
	PublicNestedTypes = 0x80,
	NonPublicNestedTypes = 0x100,
	PublicProperties = 0x200,
	NonPublicProperties = 0x400,
	PublicEvents = 0x800,
	NonPublicEvents = 0x1000,
	Interfaces = 0x2000,
	NonPublicConstructorsWithInherited = 0x4004,
	NonPublicMethodsWithInherited = 0x8010,
	NonPublicFieldsWithInherited = 0x10040,
	NonPublicNestedTypesWithInherited = 0x20100,
	NonPublicPropertiesWithInherited = 0x40400,
	NonPublicEventsWithInherited = 0x81000,
	PublicConstructorsWithInherited = 0x100003,
	PublicNestedTypesWithInherited = 0x200080,
	AllConstructors = 0x104007,
	AllMethods = 0x8018,
	AllFields = 0x10060,
	AllNestedTypes = 0x220180,
	AllProperties = 0x40600,
	AllEvents = 0x81800,
	[EditorBrowsable(EditorBrowsableState.Never)]
	All = -1
}
