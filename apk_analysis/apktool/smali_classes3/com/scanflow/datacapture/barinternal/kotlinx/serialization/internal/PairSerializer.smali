.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/KeyValueSerializer;
.source "Tuples.kt"


# instance fields
.field private final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method public static synthetic $r8$lambda$PyYh3K_WyfkMELTGMAMFhINXUbo(Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer;->descriptor$lambda$0(Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method public constructor <init>(Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/KSerializer;)V
    .locals 2

    const-string v0, "keySerializer"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "valueSerializer"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 90
    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/KeyValueSerializer;-><init>(Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/KSerializer;Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    const/4 v0, 0x0

    .line 91
    new-array v0, v0, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer$$ExternalSyntheticLambda0;

    invoke-direct {v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer$$ExternalSyntheticLambda0;-><init>(Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/KSerializer;)V

    const-string p1, "kotlin.Pair"

    invoke-static {p1, v0, v1}, Lkotlinx/serialization/descriptors/SerialDescriptorsKt;->buildClassSerialDescriptor(Ljava/lang/String;[Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/jvm/functions/Function1;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private static final descriptor$lambda$0(Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/KSerializer;Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 8

    const-string v0, "$this$buildClassSerialDescriptor"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 92
    invoke-interface {p0}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v3

    const/16 v6, 0xc

    const/4 v7, 0x0

    const-string v2, "first"

    const/4 v4, 0x0

    const/4 v5, 0x0

    move-object v1, p2

    invoke-static/range {v1 .. v7}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->element$default(Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialDescriptor;Ljava/util/List;ZILjava/lang/Object;)V

    .line 93
    invoke-interface {p1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v3

    const-string v2, "second"

    invoke-static/range {v1 .. v7}, Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;->element$default(Lkotlinx/serialization/descriptors/ClassSerialDescriptorBuilder;Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialDescriptor;Ljava/util/List;ZILjava/lang/Object;)V

    .line 94
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object v0
.end method


# virtual methods
.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 91
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method protected getKey(Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Ljava/lang/Object;
    .locals 1

    const-string v0, "<this>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 95
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getFirst()Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic getKey(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 86
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer;->getKey(Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method protected getValue(Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Ljava/lang/Object;
    .locals 1

    const-string v0, "<this>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 96
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getSecond()Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic getValue(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 86
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer;->getValue(Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method protected toResult(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;
    .locals 0

    .line 98
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic toResult(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 86
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PairSerializer;->toResult(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object p1

    return-object p1
.end method
