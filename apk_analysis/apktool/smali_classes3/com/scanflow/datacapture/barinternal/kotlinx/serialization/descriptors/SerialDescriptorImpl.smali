.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;
.super Ljava/lang/Object;
.source "SerialDescriptors.kt"

# interfaces
.implements Lkotlinx/serialization/descriptors/SerialDescriptor;
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CachedNames;


# instance fields
.field private final _hashCode$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

.field private final annotations:Ljava/util/List;

.field private final elementAnnotations:[Ljava/util/List;

.field private final elementDescriptors:[Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private final elementNames:[Ljava/lang/String;

.field private final elementOptionality:[Z

.field private final elementsCount:I

.field private final kind:Lkotlinx/serialization/descriptors/SerialKind;

.field private final name2Index:Ljava/util/Map;

.field private final serialName:Ljava/lang/String;

.field private final serialNames:Ljava/util/Set;

.field private final typeParametersDescriptors:[Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method public static synthetic $r8$lambda$5V-SQfcoD1sJfwkMIDcFMGE0yyI(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;)I
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->_hashCode_delegate$lambda$1(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;)I

    move-result p0

    return p0
.end method

.method public constructor <init>(Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialKind;ILjava/util/List;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)V
    .locals 1

    const-string v0, "serialName"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "kind"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "typeParameters"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "builder"

    invoke-static {p5, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 357
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 358
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->serialName:Ljava/lang/String;

    .line 359
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->kind:Lkotlinx/serialization/descriptors/SerialKind;

    .line 360
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementsCount:I

    .line 365
    invoke-virtual {p5}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->getAnnotations()Ljava/util/List;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->annotations:Ljava/util/List;

    .line 366
    invoke-virtual {p5}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->getElementNames$kotlinx_serialization_core()Ljava/util/List;

    move-result-object p1

    check-cast p1, Ljava/lang/Iterable;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->toHashSet(Ljava/lang/Iterable;)Ljava/util/HashSet;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->serialNames:Ljava/util/Set;

    .line 368
    invoke-virtual {p5}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->getElementNames$kotlinx_serialization_core()Ljava/util/List;

    move-result-object p1

    check-cast p1, Ljava/util/Collection;

    const/4 p2, 0x0

    .line 397
    new-array p3, p2, [Ljava/lang/String;

    invoke-interface {p1, p3}, Ljava/util/Collection;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [Ljava/lang/String;

    .line 368
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementNames:[Ljava/lang/String;

    .line 369
    invoke-virtual {p5}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->getElementDescriptors$kotlinx_serialization_core()Ljava/util/List;

    move-result-object p3

    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/Platform_commonKt;->compactArray(Ljava/util/List;)[Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p3

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementDescriptors:[Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 370
    invoke-virtual {p5}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->getElementAnnotations$kotlinx_serialization_core()Ljava/util/List;

    move-result-object p3

    check-cast p3, Ljava/util/Collection;

    .line 401
    new-array p2, p2, [Ljava/util/List;

    invoke-interface {p3, p2}, Ljava/util/Collection;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object p2

    check-cast p2, [Ljava/util/List;

    .line 370
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementAnnotations:[Ljava/util/List;

    .line 371
    invoke-virtual {p5}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->getElementOptionality$kotlinx_serialization_core()Ljava/util/List;

    move-result-object p2

    check-cast p2, Ljava/util/Collection;

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->toBooleanArray(Ljava/util/Collection;)[Z

    move-result-object p2

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementOptionality:[Z

    .line 372
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->withIndex([Ljava/lang/Object;)Ljava/lang/Iterable;

    move-result-object p1

    .line 402
    new-instance p2, Ljava/util/ArrayList;

    const/16 p3, 0xa

    invoke-static {p1, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->collectionSizeOrDefault(Ljava/lang/Iterable;I)I

    move-result p3

    invoke-direct {p2, p3}, Ljava/util/ArrayList;-><init>(I)V

    .line 403
    invoke-interface {p1}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result p3

    if-eqz p3, :cond_0

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object p3

    .line 404
    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlin/collections/IndexedValue;

    .line 372
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/IndexedValue;->getValue()Ljava/lang/Object;

    move-result-object p5

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/IndexedValue;->getIndex()I

    move-result p3

    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    invoke-static {p5, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object p3

    .line 404
    invoke-interface {p2, p3}, Ljava/util/Collection;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 372
    :cond_0
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/MapsKt;->toMap(Ljava/lang/Iterable;)Ljava/util/Map;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->name2Index:Ljava/util/Map;

    .line 373
    invoke-static {p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/Platform_commonKt;->compactArray(Ljava/util/List;)[Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->typeParametersDescriptors:[Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 374
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl$$ExternalSyntheticLambda0;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;)V

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyKt;->lazy(Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->_hashCode$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    return-void
.end method

.method private static final _hashCode_delegate$lambda$1(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;)I
    .locals 1

    .line 374
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->typeParametersDescriptors:[Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptorKt;->hashCodeImpl(Lkotlinx/serialization/descriptors/SerialDescriptor;[Lkotlinx/serialization/descriptors/SerialDescriptor;)I

    move-result p0

    return p0
.end method

.method private final get_hashCode()I
    .locals 1

    .line 374
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->_hashCode$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Number;

    invoke-virtual {v0}, Ljava/lang/Number;->intValue()I

    move-result v0

    return v0
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 6

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 411
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    .line 412
    :cond_1
    invoke-interface {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v1

    move-object v3, p1

    check-cast v3, Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {v3}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v4

    invoke-static {v1, v4}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    .line 413
    :cond_2
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;

    .line 384
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->typeParametersDescriptors:[Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 385
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->typeParametersDescriptors:[Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-static {v1, p1}, Ljava/util/Arrays;->equals([Ljava/lang/Object;[Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_3

    return v2

    .line 414
    :cond_3
    invoke-interface {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementsCount()I

    move-result p1

    invoke-interface {v3}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementsCount()I

    move-result v1

    if-eq p1, v1, :cond_4

    return v2

    .line 415
    :cond_4
    invoke-interface {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementsCount()I

    move-result p1

    move v1, v2

    :goto_0
    if-ge v1, p1, :cond_7

    .line 416
    invoke-interface {p0, v1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v4

    invoke-interface {v4}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v4

    invoke-interface {v3, v1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v5

    invoke-interface {v5}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_5

    return v2

    .line 417
    :cond_5
    invoke-interface {p0, v1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v4

    invoke-interface {v4}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object v4

    invoke-interface {v3, v1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v5

    invoke-interface {v5}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object v5

    invoke-static {v4, v5}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_6

    return v2

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_7
    return v0
.end method

.method public getAnnotations()Ljava/util/List;
    .locals 1

    .line 365
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->annotations:Ljava/util/List;

    return-object v0
.end method

.method public getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 379
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementDescriptors:[Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 408
    aget-object p1, v0, p1

    return-object p1
.end method

.method public getElementName(I)Ljava/lang/String;
    .locals 1

    .line 376
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementNames:[Ljava/lang/String;

    .line 406
    aget-object p1, v0, p1

    return-object p1
.end method

.method public getElementsCount()I
    .locals 1

    .line 360
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementsCount:I

    return v0
.end method

.method public getKind()Lkotlinx/serialization/descriptors/SerialKind;
    .locals 1

    .line 359
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->kind:Lkotlinx/serialization/descriptors/SerialKind;

    return-object v0
.end method

.method public getSerialName()Ljava/lang/String;
    .locals 1

    .line 358
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->serialName:Ljava/lang/String;

    return-object v0
.end method

.method public getSerialNames()Ljava/util/Set;
    .locals 1

    .line 366
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->serialNames:Ljava/util/Set;

    return-object v0
.end method

.method public hashCode()I
    .locals 1

    .line 389
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->get_hashCode()I

    move-result v0

    return v0
.end method

.method public isElementOptional(I)Z
    .locals 1

    .line 380
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/SerialDescriptorImpl;->elementOptionality:[Z

    .line 409
    aget-boolean p1, v0, p1

    return p1
.end method

.method public isNullable()Z
    .locals 1

    .line 356
    invoke-super {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->isNullable()Z

    move-result v0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 391
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptorKt;->toStringImpl(Lkotlinx/serialization/descriptors/SerialDescriptor;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
