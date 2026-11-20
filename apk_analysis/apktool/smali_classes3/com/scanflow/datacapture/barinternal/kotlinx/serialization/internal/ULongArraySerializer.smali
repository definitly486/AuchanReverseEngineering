.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;
.source "PrimitiveArraysSerializers.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 587
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/ULong$Companion;

    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->serializer(Lcom/scanflow/datacapture/barinternal/kotlin/ULong$Companion;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    return-void
.end method


# virtual methods
.method public bridge synthetic collectionSize(Ljava/lang/Object;)I
    .locals 0

    .line 583
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;->unbox-impl()[J

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;->collectionSize-QwZRm1k([J)I

    move-result p1

    return p1
.end method

.method protected collectionSize-QwZRm1k([J)I
    .locals 1

    const-string v0, "$this$collectionSize"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 589
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;->getSize-impl([J)I

    move-result p1

    return p1
.end method

.method public bridge synthetic empty()Ljava/lang/Object;
    .locals 1

    .line 583
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;->empty-Y2RjT0g()[J

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;->box-impl([J)Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;

    move-result-object v0

    return-object v0
.end method

.method protected empty-Y2RjT0g()[J
    .locals 1

    const/4 v0, 0x0

    .line 591
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;->constructor-impl(I)[J

    move-result-object v0

    return-object v0
.end method

.method protected readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArrayBuilder;Z)V
    .locals 0

    const-string p4, "decoder"

    invoke-static {p1, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p4, "builder"

    invoke-static {p3, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 594
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p4

    invoke-interface {p1, p4, p2}, Lkotlinx/serialization/encoding/CompositeDecoder;->decodeInlineElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Lkotlinx/serialization/encoding/Decoder;

    move-result-object p1

    invoke-interface {p1}, Lkotlinx/serialization/encoding/Decoder;->decodeLong()J

    move-result-wide p1

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide p1

    invoke-virtual {p3, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArrayBuilder;->append-VKZWuLQ$kotlinx_serialization_core(J)V

    return-void
.end method

.method public bridge synthetic readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILjava/lang/Object;Z)V
    .locals 0

    .line 583
    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArrayBuilder;

    invoke-virtual {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;->readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArrayBuilder;Z)V

    return-void
.end method

.method public bridge synthetic toBuilder(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 583
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;->unbox-impl()[J

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;->toBuilder-QwZRm1k([J)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArrayBuilder;

    move-result-object p1

    return-object p1
.end method

.method protected toBuilder-QwZRm1k([J)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArrayBuilder;
    .locals 2

    const-string v0, "$this$toBuilder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 590
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArrayBuilder;

    const/4 v1, 0x0

    invoke-direct {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArrayBuilder;-><init>([JLkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public bridge synthetic writeContent(Lkotlinx/serialization/encoding/CompositeEncoder;Ljava/lang/Object;I)V
    .locals 0

    .line 583
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;->unbox-impl()[J

    move-result-object p2

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ULongArraySerializer;->writeContent-0q3Fkuo(Lkotlinx/serialization/encoding/CompositeEncoder;[JI)V

    return-void
.end method

.method protected writeContent-0q3Fkuo(Lkotlinx/serialization/encoding/CompositeEncoder;[JI)V
    .locals 4

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "content"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p3, :cond_0

    .line 599
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-interface {p1, v1, v0}, Lkotlinx/serialization/encoding/CompositeEncoder;->encodeInlineElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Lkotlinx/serialization/encoding/Encoder;

    move-result-object v1

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/ULongArray;->get-s-VKNKU([JI)J

    move-result-wide v2

    invoke-interface {v1, v2, v3}, Lkotlinx/serialization/encoding/Encoder;->encodeLong(J)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
