.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;
.super Ljava/lang/Object;
.source "BuiltInSerializers.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;

.field private static final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveSerialDescriptor;

    const-string v1, "kotlin.time.Instant"

    sget-object v2, Lkotlinx/serialization/descriptors/PrimitiveKind$STRING;->INSTANCE:Lkotlinx/serialization/descriptors/PrimitiveKind$STRING;

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveSerialDescriptor;-><init>(Ljava/lang/String;Lkotlinx/serialization/descriptors/PrimitiveKind;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 44
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 1

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 54
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;

    invoke-interface {p1}, Lkotlinx/serialization/encoding/Decoder;->decodeString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;->parse(Ljava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 44
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 47
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)V
    .locals 1

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 50
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-interface {p1, p2}, Lkotlinx/serialization/encoding/Encoder;->encodeString(Ljava/lang/String;)V

    return-void
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 0

    .line 44
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InstantSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)V

    return-void
.end method
