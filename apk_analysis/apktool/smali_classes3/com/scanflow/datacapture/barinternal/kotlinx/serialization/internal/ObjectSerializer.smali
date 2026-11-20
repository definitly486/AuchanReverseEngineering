.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;
.super Ljava/lang/Object;
.source "ObjectSerializer.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# instance fields
.field private _annotations:Ljava/util/List;

.field private final descriptor$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

.field private final objectInstance:Ljava/lang/Object;


# direct methods
.method public static synthetic $r8$lambda$7oDpqf8KMk_ucBPwlicAd7WQqg4(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->descriptor_delegate$lambda$1$lambda$0(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$uWbFZ4C3GF6_y2c_O5ODy-kpi44(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;)Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->descriptor_delegate$lambda$1(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p0

    return-object p0
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/lang/Object;)V
    .locals 1

    const-string v0, "serialName"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "objectInstance"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 19
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->objectInstance:Ljava/lang/Object;

    .line 30
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p2

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->_annotations:Ljava/util/List;

    .line 32
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->PUBLICATION:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer$$ExternalSyntheticLambda0;

    invoke-direct {v0, p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;)V

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyKt;->lazy(Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->descriptor$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    return-void
.end method

.method private static final descriptor_delegate$lambda$1(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;)Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 3

    .line 33
    sget-object v0, Lkotlinx/serialization/descriptors/StructureKind$OBJECT;->INSTANCE:Lkotlinx/serialization/descriptors/StructureKind$OBJECT;

    const/4 v1, 0x0

    new-array v1, v1, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer$$ExternalSyntheticLambda1;

    invoke-direct {v2, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;)V

    invoke-static {p0, v0, v1, v2}, Lkotlinx/serialization/descriptors/SerialDescriptorsKt;->buildSerialDescriptor(Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialKind;[Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/jvm/functions/Function1;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p0

    return-object p0
.end method

.method private static final descriptor_delegate$lambda$1$lambda$0(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 1

    const-string v0, "$this$buildSerialDescriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 34
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->_annotations:Ljava/util/List;

    invoke-virtual {p1, p0}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->setAnnotations(Ljava/util/List;)V

    .line 35
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method


# virtual methods
.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 3

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 43
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    .line 58
    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/Decoder;->beginStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)Lkotlinx/serialization/encoding/CompositeDecoder;

    move-result-object p1

    .line 44
    invoke-interface {p1}, Lkotlinx/serialization/encoding/CompositeDecoder;->decodeSequentially()Z

    move-result v1

    if-eqz v1, :cond_0

    goto :goto_0

    .line 47
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-interface {p1, v1}, Lkotlinx/serialization/encoding/CompositeDecoder;->decodeElementIndex(Lkotlinx/serialization/descriptors/SerialDescriptor;)I

    move-result v1

    const/4 v2, -0x1

    if-ne v1, v2, :cond_1

    .line 51
    :goto_0
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    .line 60
    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/CompositeDecoder;->endStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)V

    .line 54
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->objectInstance:Ljava/lang/Object;

    return-object p1

    .line 51
    :cond_1
    new-instance p1, Lkotlinx/serialization/SerializationException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unexpected index "

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p1, v0}, Lkotlinx/serialization/SerializationException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 32
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->descriptor$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 1

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 39
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p2

    invoke-interface {p1, p2}, Lkotlinx/serialization/encoding/Encoder;->beginStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)Lkotlinx/serialization/encoding/CompositeEncoder;

    move-result-object p1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p2

    invoke-interface {p1, p2}, Lkotlinx/serialization/encoding/CompositeEncoder;->endStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)V

    return-void
.end method
