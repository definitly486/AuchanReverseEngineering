.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CollectionLikeSerializer;
.source "CollectionSerializers.kt"


# instance fields
.field private final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method public constructor <init>(Lkotlinx/serialization/KSerializer;)V
    .locals 1

    const-string v0, "primitiveSerializer"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 146
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CollectionLikeSerializer;-><init>(Lkotlinx/serialization/KSerializer;Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 147
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayDescriptor;

    invoke-interface {p1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayDescriptor;-><init>(Lkotlinx/serialization/descriptors/SerialDescriptor;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method


# virtual methods
.method protected final builder()Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;
    .locals 1

    .line 159
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->empty()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/AbstractCollectionSerializer;->toBuilder(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;

    return-object v0
.end method

.method public bridge synthetic builder()Ljava/lang/Object;
    .locals 1

    .line 142
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->builder()Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;

    move-result-object v0

    return-object v0
.end method

.method protected final builderSize(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;)I
    .locals 1

    const-string v0, "<this>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 149
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;->getPosition$kotlinx_serialization_core()I

    move-result p1

    return p1
.end method

.method public bridge synthetic builderSize(Ljava/lang/Object;)I
    .locals 0

    .line 142
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->builderSize(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;)I

    move-result p1

    return p1
.end method

.method protected final checkCapacity(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;I)V
    .locals 1

    const-string v0, "<this>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 151
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;->ensureCapacity$kotlinx_serialization_core(I)V

    return-void
.end method

.method public bridge synthetic checkCapacity(Ljava/lang/Object;I)V
    .locals 0

    .line 142
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->checkCapacity(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;I)V

    return-void
.end method

.method protected final collectionIterator(Ljava/lang/Object;)Ljava/util/Iterator;
    .locals 1

    new-instance p1, Ljava/lang/IllegalStateException;

    .line 154
    const-string v0, "This method lead to boxing and must not be used, use writeContents instead"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public final deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 1

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 179
    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/AbstractCollectionSerializer;->merge(Lkotlinx/serialization/encoding/Decoder;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method protected abstract empty()Ljava/lang/Object;
.end method

.method public final getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 147
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method protected final insert(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;ILjava/lang/Object;)V
    .locals 0

    const-string p2, "<this>"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance p1, Ljava/lang/IllegalStateException;

    .line 157
    const-string p2, "This method lead to boxing and must not be used, use Builder.append instead"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic insert(Ljava/lang/Object;ILjava/lang/Object;)V
    .locals 0

    .line 142
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->insert(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;ILjava/lang/Object;)V

    return-void
.end method

.method public final serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 2

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 173
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/AbstractCollectionSerializer;->collectionSize(Ljava/lang/Object;)I

    move-result v0

    .line 174
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 284
    invoke-interface {p1, v1, v0}, Lkotlinx/serialization/encoding/Encoder;->beginCollection(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Lkotlinx/serialization/encoding/CompositeEncoder;

    move-result-object p1

    .line 175
    invoke-virtual {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->writeContent(Lkotlinx/serialization/encoding/CompositeEncoder;Ljava/lang/Object;I)V

    .line 286
    invoke-interface {p1, v1}, Lkotlinx/serialization/encoding/CompositeEncoder;->endStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)V

    return-void
.end method

.method protected final toResult(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;)Ljava/lang/Object;
    .locals 1

    const-string v0, "<this>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 150
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;->build$kotlinx_serialization_core()Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic toResult(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 142
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArraySerializer;->toResult(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method protected abstract writeContent(Lkotlinx/serialization/encoding/CompositeEncoder;Ljava/lang/Object;I)V
.end method
