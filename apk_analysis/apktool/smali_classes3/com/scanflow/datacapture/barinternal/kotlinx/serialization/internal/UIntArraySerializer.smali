.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;
.source "PrimitiveArraysSerializers.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 533
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/UInt$Companion;

    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->serializer(Lcom/scanflow/datacapture/barinternal/kotlin/UInt$Companion;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    return-void
.end method


# virtual methods
.method public bridge synthetic collectionSize(Ljava/lang/Object;)I
    .locals 0

    .line 529
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;->unbox-impl()[I

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;->collectionSize--ajY-9A([I)I

    move-result p1

    return p1
.end method

.method protected collectionSize--ajY-9A([I)I
    .locals 1

    const-string v0, "$this$collectionSize"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 535
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;->getSize-impl([I)I

    move-result p1

    return p1
.end method

.method public bridge synthetic empty()Ljava/lang/Object;
    .locals 1

    .line 529
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;->empty--hP7Qyg()[I

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;->box-impl([I)Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;

    move-result-object v0

    return-object v0
.end method

.method protected empty--hP7Qyg()[I
    .locals 1

    const/4 v0, 0x0

    .line 537
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;->constructor-impl(I)[I

    move-result-object v0

    return-object v0
.end method

.method protected readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArrayBuilder;Z)V
    .locals 0

    const-string p4, "decoder"

    invoke-static {p1, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p4, "builder"

    invoke-static {p3, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 540
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p4

    invoke-interface {p1, p4, p2}, Lkotlinx/serialization/encoding/CompositeDecoder;->decodeInlineElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Lkotlinx/serialization/encoding/Decoder;

    move-result-object p1

    invoke-interface {p1}, Lkotlinx/serialization/encoding/Decoder;->decodeInt()I

    move-result p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->constructor-impl(I)I

    move-result p1

    invoke-virtual {p3, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArrayBuilder;->append-WZ4Q5Ns$kotlinx_serialization_core(I)V

    return-void
.end method

.method public bridge synthetic readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILjava/lang/Object;Z)V
    .locals 0

    .line 529
    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArrayBuilder;

    invoke-virtual {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;->readElement(Lkotlinx/serialization/encoding/CompositeDecoder;ILcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArrayBuilder;Z)V

    return-void
.end method

.method public bridge synthetic toBuilder(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 529
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;->unbox-impl()[I

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;->toBuilder--ajY-9A([I)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArrayBuilder;

    move-result-object p1

    return-object p1
.end method

.method protected toBuilder--ajY-9A([I)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArrayBuilder;
    .locals 2

    const-string v0, "$this$toBuilder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 536
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArrayBuilder;

    const/4 v1, 0x0

    invoke-direct {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArrayBuilder;-><init>([ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public bridge synthetic writeContent(Lkotlinx/serialization/encoding/CompositeEncoder;Ljava/lang/Object;I)V
    .locals 0

    .line 529
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;->unbox-impl()[I

    move-result-object p2

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntArraySerializer;->writeContent-CPlH8fI(Lkotlinx/serialization/encoding/CompositeEncoder;[II)V

    return-void
.end method

.method protected writeContent-CPlH8fI(Lkotlinx/serialization/encoding/CompositeEncoder;[II)V
    .locals 3

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "content"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p3, :cond_0

    .line 545
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-interface {p1, v1, v0}, Lkotlinx/serialization/encoding/CompositeEncoder;->encodeInlineElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Lkotlinx/serialization/encoding/Encoder;

    move-result-object v1

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UIntArray;->get-pVg5ArA([II)I

    move-result v2

    invoke-interface {v1, v2}, Lkotlinx/serialization/encoding/Encoder;->encodeInt(I)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
