.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;
.source "Enums.kt"


# instance fields
.field private final elementDescriptors$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

.field private final kind:Lkotlinx/serialization/descriptors/SerialKind;


# direct methods
.method public static synthetic $r8$lambda$h6F9M2HXWZjok_R71paEwKzi_qo(ILjava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;)[Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;->elementDescriptors_delegate$lambda$0(ILjava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;)[Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p0

    return-object p0
.end method

.method public constructor <init>(Ljava/lang/String;I)V
    .locals 7

    const-string v0, "name"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v5, 0x2

    const/4 v6, 0x0

    const/4 v3, 0x0

    move-object v1, p0

    move-object v2, p1

    move v4, p2

    .line 21
    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/GeneratedSerializer;IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 23
    sget-object p1, Lkotlinx/serialization/descriptors/SerialKind$ENUM;->INSTANCE:Lkotlinx/serialization/descriptors/SerialKind$ENUM;

    iput-object p1, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;->kind:Lkotlinx/serialization/descriptors/SerialKind;

    .line 24
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor$$ExternalSyntheticLambda0;

    invoke-direct {p1, v4, v2, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor$$ExternalSyntheticLambda0;-><init>(ILjava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;)V

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyKt;->lazy(Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    move-result-object p1

    iput-object p1, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;->elementDescriptors$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    return-void
.end method

.method private static final elementDescriptors_delegate$lambda$0(ILjava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;)[Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 11

    .line 25
    new-array v0, p0, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    const/4 v1, 0x0

    move v2, v1

    :goto_0
    if-ge v2, p0, :cond_0

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v4, 0x2e

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;->getElementName(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    sget-object v6, Lkotlinx/serialization/descriptors/StructureKind$OBJECT;->INSTANCE:Lkotlinx/serialization/descriptors/StructureKind$OBJECT;

    new-array v7, v1, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    const/16 v9, 0x8

    const/4 v10, 0x0

    const/4 v8, 0x0

    invoke-static/range {v5 .. v10}, Lkotlinx/serialization/descriptors/SerialDescriptorsKt;->buildSerialDescriptor$default(Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialKind;[Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v3

    aput-object v3, v0, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_0
    return-object v0
.end method

.method private final getElementDescriptors()[Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 24
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;->elementDescriptors$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    const/4 v1, 0x0

    if-nez p1, :cond_1

    return v1

    .line 33
    :cond_1
    instance-of v2, p1, Lkotlinx/serialization/descriptors/SerialDescriptor;

    if-nez v2, :cond_2

    return v1

    .line 34
    :cond_2
    check-cast p1, Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object v2

    sget-object v3, Lkotlinx/serialization/descriptors/SerialKind$ENUM;->INSTANCE:Lkotlinx/serialization/descriptors/SerialKind$ENUM;

    if-eq v2, v3, :cond_3

    return v1

    .line 35
    :cond_3
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v2

    invoke-interface {p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_4

    return v1

    .line 36
    :cond_4
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/Platform_commonKt;->cachedSerialNames(Lkotlinx/serialization/descriptors/SerialDescriptor;)Ljava/util/Set;

    move-result-object v2

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/Platform_commonKt;->cachedSerialNames(Lkotlinx/serialization/descriptors/SerialDescriptor;)Ljava/util/Set;

    move-result-object p1

    invoke-static {v2, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_5

    return v1

    :cond_5
    return v0
.end method

.method public getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 28
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;->getElementDescriptors()[Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    .line 149
    aget-object p1, v0, p1

    return-object p1
.end method

.method public getKind()Lkotlinx/serialization/descriptors/SerialKind;
    .locals 1

    .line 23
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/EnumDescriptor;->kind:Lkotlinx/serialization/descriptors/SerialKind;

    return-object v0
.end method

.method public hashCode()I
    .locals 4

    .line 45
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    .line 46
    invoke-static {p0}, Lkotlinx/serialization/descriptors/SerialDescriptorKt;->getElementNames(Lkotlinx/serialization/descriptors/SerialDescriptor;)Ljava/lang/Iterable;

    move-result-object v1

    .line 152
    invoke-interface {v1}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v1

    const/4 v2, 0x1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    mul-int/lit8 v2, v2, 0x1f

    .line 150
    check-cast v3, Ljava/lang/String;

    if-eqz v3, :cond_0

    invoke-virtual {v3}, Ljava/lang/Object;->hashCode()I

    move-result v3

    goto :goto_1

    :cond_0
    const/4 v3, 0x0

    :goto_1
    add-int/2addr v2, v3

    goto :goto_0

    :cond_1
    mul-int/lit8 v0, v0, 0x1f

    add-int/2addr v0, v2

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 9

    .line 41
    invoke-static {p0}, Lkotlinx/serialization/descriptors/SerialDescriptorKt;->getElementNames(Lkotlinx/serialization/descriptors/SerialDescriptor;)Ljava/lang/Iterable;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v2, 0x28

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    const/16 v7, 0x38

    const/4 v8, 0x0

    const-string v1, ", "

    const-string v3, ")"

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->joinToString$default(Ljava/lang/Iterable;Ljava/lang/CharSequence;Ljava/lang/CharSequence;Ljava/lang/CharSequence;ILjava/lang/CharSequence;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
