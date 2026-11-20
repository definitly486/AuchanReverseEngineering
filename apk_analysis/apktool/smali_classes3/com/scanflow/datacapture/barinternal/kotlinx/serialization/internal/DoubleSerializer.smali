.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;
.super Ljava/lang/Object;
.source "Primitives.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;

.field private static final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;

    .line 115
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveSerialDescriptor;

    const-string v1, "kotlin.Double"

    sget-object v2, Lkotlinx/serialization/descriptors/PrimitiveKind$DOUBLE;->INSTANCE:Lkotlinx/serialization/descriptors/PrimitiveKind$DOUBLE;

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveSerialDescriptor;-><init>(Ljava/lang/String;Lkotlinx/serialization/descriptors/PrimitiveKind;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 113
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Double;
    .locals 2

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 117
    invoke-interface {p1}, Lkotlinx/serialization/encoding/Decoder;->decodeDouble()D

    move-result-wide v0

    invoke-static {v0, v1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 113
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Double;

    move-result-object p1

    return-object p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 115
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;D)V
    .locals 1

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 116
    invoke-interface {p1, p2, p3}, Lkotlinx/serialization/encoding/Encoder;->encodeDouble(D)V

    return-void
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 2

    .line 113
    check-cast p2, Ljava/lang/Number;

    invoke-virtual {p2}, Ljava/lang/Number;->doubleValue()D

    move-result-wide v0

    invoke-virtual {p0, p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DoubleSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;D)V

    return-void
.end method
