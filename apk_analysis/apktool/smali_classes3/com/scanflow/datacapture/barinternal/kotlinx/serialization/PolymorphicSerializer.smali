.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/AbstractPolymorphicSerializer;
.source "PolymorphicSerializer.kt"


# instance fields
.field private _annotations:Ljava/util/List;

.field private final baseClass:Lkotlin/reflect/KClass;

.field private final descriptor$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;


# direct methods
.method public static synthetic $r8$lambda$6EKP3bxERH5YJPjPHsTd5thYe-8(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;)Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->descriptor_delegate$lambda$1(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$KIOp2r6bAbWdljehXTvxkt0OQzY(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->descriptor_delegate$lambda$1$lambda$0(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method public constructor <init>(Lkotlin/reflect/KClass;)V
    .locals 1

    const-string v0, "baseClass"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 69
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/AbstractPolymorphicSerializer;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->baseClass:Lkotlin/reflect/KClass;

    .line 79
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->_annotations:Ljava/util/List;

    .line 81
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->PUBLICATION:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer$$ExternalSyntheticLambda0;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;)V

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyKt;->lazy(Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->descriptor$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    return-void
.end method

.method private static final descriptor_delegate$lambda$1(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;)Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 4

    .line 82
    sget-object v0, Lkotlinx/serialization/descriptors/PolymorphicKind$OPEN;->INSTANCE:Lkotlinx/serialization/descriptors/PolymorphicKind$OPEN;

    const/4 v1, 0x0

    new-array v1, v1, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer$$ExternalSyntheticLambda1;

    invoke-direct {v2, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;)V

    const-string v3, "kotlinx.serialization.Polymorphic"

    invoke-static {v3, v0, v1, v2}, Lkotlinx/serialization/descriptors/SerialDescriptorsKt;->buildSerialDescriptor(Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialKind;[Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/jvm/functions/Function1;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    .line 89
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->getBaseClass()Lkotlin/reflect/KClass;

    move-result-object p0

    invoke-static {v0, p0}, Lkotlinx/serialization/descriptors/ContextAwareKt;->withContext(Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/reflect/KClass;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p0

    return-object p0
.end method

.method private static final descriptor_delegate$lambda$1$lambda$0(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 8

    const-string v1, "$this$buildSerialDescriptor"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 83
    sget-object v1, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    invoke-static {v1}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->serializer(Lkotlin/jvm/internal/StringCompanionObject;)Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v2

    const/16 v5, 0xc

    const/4 v6, 0x0

    const-string v1, "type"

    const/4 v3, 0x0

    const/4 v4, 0x0

    move-object v0, p1

    invoke-static/range {v0 .. v6}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->element$default(Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialDescriptor;Ljava/util/List;ZILjava/lang/Object;)V

    .line 86
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "kotlinx.serialization.Polymorphic<"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->getBaseClass()Lkotlin/reflect/KClass;

    move-result-object v1

    invoke-interface {v1}, Lkotlin/reflect/KClass;->getSimpleName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v1, 0x3e

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    sget-object v3, Lkotlinx/serialization/descriptors/SerialKind$CONTEXTUAL;->INSTANCE:Lkotlinx/serialization/descriptors/SerialKind$CONTEXTUAL;

    const/4 v0, 0x0

    new-array v4, v0, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    const/16 v6, 0x8

    const/4 v7, 0x0

    const/4 v5, 0x0

    invoke-static/range {v2 .. v7}, Lkotlinx/serialization/descriptors/SerialDescriptorsKt;->buildSerialDescriptor$default(Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialKind;[Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v2

    const/16 v5, 0xc

    const/4 v6, 0x0

    .line 84
    const-string v1, "value"

    const/4 v3, 0x0

    const/4 v4, 0x0

    move-object v0, p1

    invoke-static/range {v0 .. v6}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->element$default(Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialDescriptor;Ljava/util/List;ZILjava/lang/Object;)V

    .line 88
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->_annotations:Ljava/util/List;

    invoke-virtual {p1, v0}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->setAnnotations(Ljava/util/List;)V

    .line 89
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object v0
.end method


# virtual methods
.method public getBaseClass()Lkotlin/reflect/KClass;
    .locals 1

    .line 69
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->baseClass:Lkotlin/reflect/KClass;

    return-object v0
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 81
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->descriptor$delegate:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 93
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "kotlinx.serialization.PolymorphicSerializer(baseClass: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->getBaseClass()Lkotlin/reflect/KClass;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
