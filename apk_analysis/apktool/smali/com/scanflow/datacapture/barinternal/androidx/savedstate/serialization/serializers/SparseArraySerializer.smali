.class public final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;
.super Ljava/lang/Object;
.source "BuiltInSerializer.android.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;
    }
.end annotation


# instance fields
.field private final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private final surrogateSerializer:Lkotlinx/serialization/KSerializer;


# direct methods
.method public constructor <init>(Lkotlinx/serialization/KSerializer;)V
    .locals 1

    const-string v0, "elementSerializer"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 387
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 390
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$Companion;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate$Companion;->serializer(Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->surrogateSerializer:Lkotlinx/serialization/KSerializer;

    .line 396
    invoke-interface {p1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method


# virtual methods
.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/util/SparseArray;
    .locals 5

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 408
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->surrogateSerializer:Lkotlinx/serialization/KSerializer;

    check-cast v0, Lkotlinx/serialization/DeserializationStrategy;

    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/Decoder;->decodeSerializableValue(Lkotlinx/serialization/DeserializationStrategy;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;

    .line 409
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->getKeys()Ljava/util/List;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->getValues()Ljava/util/List;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    if-ne v0, v1, :cond_1

    .line 410
    new-instance v0, Landroid/util/SparseArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->getKeys()Ljava/util/List;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    invoke-direct {v0, v1}, Landroid/util/SparseArray;-><init>(I)V

    .line 411
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->getKeys()Ljava/util/List;

    move-result-object v1

    check-cast v1, Ljava/util/Collection;

    invoke-interface {v1}, Ljava/util/Collection;->size()I

    move-result v1

    const/4 v2, 0x0

    :goto_0
    if-ge v2, v1, :cond_0

    .line 412
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->getKeys()Ljava/util/List;

    move-result-object v3

    invoke-interface {v3, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/Number;

    invoke-virtual {v3}, Ljava/lang/Number;->intValue()I

    move-result v3

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;->getValues()Ljava/util/List;

    move-result-object v4

    invoke-interface {v4, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {v0, v3, v4}, Landroid/util/SparseArray;->append(ILjava/lang/Object;)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_0
    return-object v0

    .line 409
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "Failed requirement."

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 386
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/util/SparseArray;

    move-result-object p1

    return-object p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 396
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/util/SparseArray;)V
    .locals 5

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 401
    invoke-virtual {p2}, Landroid/util/SparseArray;->size()I

    move-result v0

    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1, v0}, Ljava/util/ArrayList;-><init>(I)V

    const/4 v2, 0x0

    move v3, v2

    :goto_0
    if-ge v3, v0, :cond_0

    invoke-virtual {p2, v3}, Landroid/util/SparseArray;->keyAt(I)I

    move-result v4

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-virtual {v1, v4}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 402
    :cond_0
    invoke-virtual {p2}, Landroid/util/SparseArray;->size()I

    move-result v0

    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3, v0}, Ljava/util/ArrayList;-><init>(I)V

    :goto_1
    if-ge v2, v0, :cond_1

    invoke-virtual {p2, v2}, Landroid/util/SparseArray;->valueAt(I)Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 400
    :cond_1
    new-instance p2, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;

    invoke-direct {p2, v1, v3}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer$SparseArraySurrogate;-><init>(Ljava/util/List;Ljava/util/List;)V

    .line 404
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->surrogateSerializer:Lkotlinx/serialization/KSerializer;

    check-cast v0, Lkotlinx/serialization/SerializationStrategy;

    invoke-interface {p1, v0, p2}, Lkotlinx/serialization/encoding/Encoder;->encodeSerializableValue(Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)V

    return-void
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 0

    .line 386
    check-cast p2, Landroid/util/SparseArray;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/util/SparseArray;)V

    return-void
.end method
