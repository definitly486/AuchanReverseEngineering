.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;
.source "PrimitiveArraysSerializers.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 425
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/UByte;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/UByte$Companion;

    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->serializer(Lcom/scanflow/datacapture/barinternal/kotlin/UByte$Companion;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    return-void
.end method


# virtual methods
.method public bridge synthetic collectionSize(Ljava/lang/Object;)I
    .locals 0

    .line 421
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->unbox-impl()[B

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;->collectionSize-GBYM_sE([B)I

    move-result p1

    return p1
.end method

.method protected collectionSize-GBYM_sE([B)I
    .locals 1

    const-string v0, "$this$collectionSize"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 427
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->getSize-impl([B)I

    move-result p1

    return p1
.end method

.method public bridge synthetic empty()Ljava/lang/Object;
    .locals 1

    .line 421
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;->empty-TcUX1vc()[B

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->box-impl([B)Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;

    move-result-object v0

    return-object v0
.end method

.method protected empty-TcUX1vc()[B
    .locals 1

    const/4 v0, 0x0

    .line 429
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->constructor-impl(I)[B

    move-result-object v0

    return-object v0
.end method

.method protected readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;Z)V
    .locals 0

    const-string p4, "decoder"

    invoke-static {p1, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p4, "builder"

    invoke-static {p3, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 432
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p4

    invoke-interface {p1, p4, p2}, Lkotlinx/serialization/encoding/CompositeDecoder;->decodeInlineElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Lkotlinx/serialization/encoding/Decoder;

    move-result-object p1

    invoke-interface {p1}, Lkotlinx/serialization/encoding/Decoder;->decodeByte()B

    move-result p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UByte;->constructor-impl(B)B

    move-result p1

    invoke-virtual {p3, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->append-7apg3OU$kotlinx_serialization_core(B)V

    return-void
.end method

.method public bridge synthetic readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILjava/lang/Object;Z)V
    .locals 0

    .line 421
    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;

    invoke-virtual {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;->readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;Z)V

    return-void
.end method

.method public bridge synthetic toBuilder(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 421
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->unbox-impl()[B

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;->toBuilder-GBYM_sE([B)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;

    move-result-object p1

    return-object p1
.end method

.method protected toBuilder-GBYM_sE([B)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;
    .locals 2

    const-string v0, "$this$toBuilder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 428
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;

    const/4 v1, 0x0

    invoke-direct {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;-><init>([BLkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public bridge synthetic writeContent(Lkotlinx/serialization/encoding/CompositeEncoder;Ljava/lang/Object;I)V
    .locals 0

    .line 421
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->unbox-impl()[B

    move-result-object p2

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArraySerializer;->writeContent-Coi6ktg(Lkotlinx/serialization/encoding/CompositeEncoder;[BI)V

    return-void
.end method

.method protected writeContent-Coi6ktg(Lkotlinx/serialization/encoding/CompositeEncoder;[BI)V
    .locals 3

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "content"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p3, :cond_0

    .line 437
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-interface {p1, v1, v0}, Lkotlinx/serialization/encoding/CompositeEncoder;->encodeInlineElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Lkotlinx/serialization/encoding/Encoder;

    move-result-object v1

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->get-w2LRezQ([BI)B

    move-result v2

    invoke-interface {v1, v2}, Lkotlinx/serialization/encoding/Encoder;->encodeByte(B)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
