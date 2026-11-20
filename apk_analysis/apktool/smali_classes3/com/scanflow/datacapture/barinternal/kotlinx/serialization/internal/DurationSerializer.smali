.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;
.super Ljava/lang/Object;
.source "BuiltInSerializers.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;

.field private static final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;

    .line 20
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveSerialDescriptor;

    const-string v1, "kotlin.time.Duration"

    sget-object v2, Lkotlinx/serialization/descriptors/PrimitiveKind$STRING;->INSTANCE:Lkotlinx/serialization/descriptors/PrimitiveKind$STRING;

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveSerialDescriptor;-><init>(Ljava/lang/String;Lkotlinx/serialization/descriptors/PrimitiveKind;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 18
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 2

    .line 18
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;->deserialize-5sfh64U(Lkotlinx/serialization/encoding/Decoder;)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->box-impl(J)Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;

    move-result-object p1

    return-object p1
.end method

.method public deserialize-5sfh64U(Lkotlinx/serialization/encoding/Decoder;)J
    .locals 2

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 27
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration$Companion;

    invoke-interface {p1}, Lkotlinx/serialization/encoding/Decoder;->decodeString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration$Companion;->parseIsoString-UwyO8pc(Ljava/lang/String;)J

    move-result-wide v0

    return-wide v0
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 20
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 2

    .line 18
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->unbox-impl()J

    move-result-wide v0

    invoke-virtual {p0, p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/DurationSerializer;->serialize-HG0u8IE(Lkotlinx/serialization/encoding/Encoder;J)V

    return-void
.end method

.method public serialize-HG0u8IE(Lkotlinx/serialization/encoding/Encoder;J)V
    .locals 1

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 23
    invoke-static {p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->toIsoString-impl(J)Ljava/lang/String;

    move-result-object p2

    invoke-interface {p1, p2}, Lkotlinx/serialization/encoding/Encoder;->encodeString(Ljava/lang/String;)V

    return-void
.end method
