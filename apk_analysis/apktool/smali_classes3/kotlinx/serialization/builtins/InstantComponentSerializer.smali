.class public final Lkotlinx/serialization/builtins/InstantComponentSerializer;
.super Ljava/lang/Object;
.source "InstantComponentSerializer.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lkotlinx/serialization/KSerializer<",
        "Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;",
        ">;"
    }
.end annotation


# static fields
.field public static final INSTANCE:Lkotlinx/serialization/builtins/InstantComponentSerializer;

.field private static final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method public static synthetic $r8$lambda$tx_B1qSqPA_UIypSNiSuVenFWA8(Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static {p0}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->descriptor$lambda$0(Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method static constructor <clinit>()V
    .locals 3

    new-instance v0, Lkotlinx/serialization/builtins/InstantComponentSerializer;

    invoke-direct {v0}, Lkotlinx/serialization/builtins/InstantComponentSerializer;-><init>()V

    sput-object v0, Lkotlinx/serialization/builtins/InstantComponentSerializer;->INSTANCE:Lkotlinx/serialization/builtins/InstantComponentSerializer;

    const/4 v0, 0x0

    .line 22
    new-array v0, v0, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/builtins/InstantComponentSerializer$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/builtins/InstantComponentSerializer$$ExternalSyntheticLambda0;-><init>()V

    const-string v2, "kotlinx.serialization.InstantComponentSerializer"

    invoke-static {v2, v0, v1}, Lkotlinx/serialization/descriptors/SerialDescriptorsKt;->buildClassSerialDescriptor(Ljava/lang/String;[Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/jvm/functions/Function1;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lkotlinx/serialization/builtins/InstantComponentSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 18
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static final descriptor$lambda$0(Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 5

    const-string v0, "$this$buildClassSerialDescriptor"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 349
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v0

    .line 352
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/LongSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/LongSerializer;

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v2

    .line 353
    const-string v3, "epochSeconds"

    const/4 v4, 0x0

    invoke-virtual {p0, v3, v2, v0, v4}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->element(Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialDescriptor;Ljava/util/List;Z)V

    .line 349
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v0

    .line 352
    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    .line 353
    const-string v2, "nanosecondsOfSecond"

    const/4 v3, 0x1

    invoke-virtual {p0, v2, v1, v0, v3}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->element(Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialDescriptor;Ljava/util/List;Z)V

    .line 25
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method


# virtual methods
.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 10

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 29
    invoke-virtual {p0}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    .line 571
    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/Decoder;->beginStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)Lkotlinx/serialization/encoding/CompositeDecoder;

    move-result-object p1

    const/4 v1, 0x1

    const-wide/16 v2, 0x0

    const/4 v4, 0x0

    move v5, v1

    move v6, v4

    .line 34
    :goto_0
    sget-object v7, Lkotlinx/serialization/builtins/InstantComponentSerializer;->INSTANCE:Lkotlinx/serialization/builtins/InstantComponentSerializer;

    invoke-virtual {v7}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v8

    invoke-interface {p1, v8}, Lkotlinx/serialization/encoding/CompositeDecoder;->decodeElementIndex(Lkotlinx/serialization/descriptors/SerialDescriptor;)I

    move-result v8

    const/4 v9, -0x1

    if-eq v8, v9, :cond_2

    if-eqz v8, :cond_1

    if-ne v8, v1, :cond_0

    .line 39
    invoke-virtual {v7}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v6

    invoke-interface {p1, v6, v1}, Lkotlinx/serialization/encoding/CompositeDecoder;->decodeIntElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)I

    move-result v6

    goto :goto_0

    .line 41
    :cond_0
    new-instance p1, Lkotlinx/serialization/SerializationException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Unexpected index: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v8}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p1, v0}, Lkotlinx/serialization/SerializationException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 37
    :cond_1
    invoke-virtual {v7}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v2

    invoke-interface {p1, v2, v4}, Lkotlinx/serialization/encoding/CompositeDecoder;->decodeLongElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)J

    move-result-wide v2

    move v5, v4

    goto :goto_0

    :cond_2
    if-nez v5, :cond_3

    .line 48
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;

    invoke-virtual {v1, v2, v3, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;->fromEpochSeconds(JI)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object v1

    .line 573
    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/CompositeDecoder;->endStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)V

    return-object v1

    .line 44
    :cond_3
    new-instance p1, Lkotlinx/serialization/MissingFieldException;

    .line 46
    invoke-virtual {v7}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-interface {v0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v0

    .line 44
    const-string v1, "epochSeconds"

    invoke-direct {p1, v1, v0}, Lkotlinx/serialization/MissingFieldException;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 18
    invoke-virtual {p0, p1}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 21
    sget-object v0, Lkotlinx/serialization/builtins/InstantComponentSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)V
    .locals 6

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 53
    invoke-virtual {p0}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    .line 476
    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/Encoder;->beginStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)Lkotlinx/serialization/encoding/CompositeEncoder;

    move-result-object p1

    .line 54
    sget-object v1, Lkotlinx/serialization/builtins/InstantComponentSerializer;->INSTANCE:Lkotlinx/serialization/builtins/InstantComponentSerializer;

    invoke-virtual {v1}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v2

    const/4 v3, 0x0

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->getEpochSeconds()J

    move-result-wide v4

    invoke-interface {p1, v2, v3, v4, v5}, Lkotlinx/serialization/encoding/CompositeEncoder;->encodeLongElement(Lkotlinx/serialization/descriptors/SerialDescriptor;IJ)V

    .line 55
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->getNanosecondsOfSecond()I

    move-result v2

    const/4 v3, 0x1

    if-nez v2, :cond_0

    invoke-virtual {v1}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v2

    invoke-interface {p1, v2, v3}, Lkotlinx/serialization/encoding/CompositeEncoder;->shouldEncodeElementDefault(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 56
    :cond_0
    invoke-virtual {v1}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->getNanosecondsOfSecond()I

    move-result p2

    invoke-interface {p1, v1, v3, p2}, Lkotlinx/serialization/encoding/CompositeEncoder;->encodeIntElement(Lkotlinx/serialization/descriptors/SerialDescriptor;II)V

    .line 478
    :cond_1
    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/CompositeEncoder;->endStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)V

    return-void
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 0

    .line 18
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    invoke-virtual {p0, p1, p2}, Lkotlinx/serialization/builtins/InstantComponentSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)V

    return-void
.end method
