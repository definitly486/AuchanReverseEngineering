.class public final Lcom/google/flatbuffers/reflection/BaseType;
.super Ljava/lang/Object;
.source "BaseType.java"


# static fields
.field public static final Array:B = 0x11t

.field public static final Bool:B = 0x2t

.field public static final Byte:B = 0x3t

.field public static final Double:B = 0xct

.field public static final Float:B = 0xbt

.field public static final Int:B = 0x7t

.field public static final Long:B = 0x9t

.field public static final MaxBaseType:B = 0x13t

.field public static final None:B = 0x0t

.field public static final Obj:B = 0xft

.field public static final Short:B = 0x5t

.field public static final String:B = 0xdt

.field public static final UByte:B = 0x4t

.field public static final UInt:B = 0x8t

.field public static final ULong:B = 0xat

.field public static final UShort:B = 0x6t

.field public static final UType:B = 0x1t

.field public static final Union:B = 0x10t

.field public static final Vector:B = 0xet

.field public static final Vector64:B = 0x12t

.field public static final names:[Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 21

    .line 29
    const-string v19, "Vector64"

    const-string v20, "MaxBaseType"

    const-string v1, "None"

    const-string v2, "UType"

    const-string v3, "Bool"

    const-string v4, "Byte"

    const-string v5, "UByte"

    const-string v6, "Short"

    const-string v7, "UShort"

    const-string v8, "Int"

    const-string v9, "UInt"

    const-string v10, "Long"

    const-string v11, "ULong"

    const-string v12, "Float"

    const-string v13, "Double"

    const-string v14, "String"

    const-string v15, "Vector"

    const-string v16, "Obj"

    const-string v17, "Union"

    const-string v18, "Array"

    filled-new-array/range {v1 .. v20}, [Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/google/flatbuffers/reflection/BaseType;->names:[Ljava/lang/String;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 7
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static name(I)Ljava/lang/String;
    .locals 1

    .line 31
    sget-object v0, Lcom/google/flatbuffers/reflection/BaseType;->names:[Ljava/lang/String;

    aget-object p0, v0, p0

    return-object p0
.end method
