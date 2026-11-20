.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;
.super Ljava/lang/Object;
.source "SerialDescriptors.kt"

# interfaces
.implements Lkotlinx/serialization/descriptors/SerialDescriptor;


# instance fields
.field private final original:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private final serialName:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Lkotlinx/serialization/descriptors/SerialDescriptor;)V
    .locals 1

    const-string v0, "serialName"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "original"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 124
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->serialName:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 129
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    .line 131
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v3

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_2

    return v0

    :cond_2
    return v2
.end method

.method public getAnnotations()Ljava/util/List;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {v0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getAnnotations()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {v0, p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    return-object p1
.end method

.method public getElementName(I)Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {v0, p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementName(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getElementsCount()I
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {v0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementsCount()I

    move-result v0

    return v0
.end method

.method public getKind()Lkotlinx/serialization/descriptors/SerialKind;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {v0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object v0

    return-object v0
.end method

.method public getSerialName()Ljava/lang/String;
    .locals 1

    .line 124
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->serialName:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    .line 135
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    mul-int/lit8 v0, v0, 0x1f

    .line 136
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-virtual {v1}, Ljava/lang/Object;->hashCode()I

    move-result v1

    add-int/2addr v0, v1

    return v0
.end method

.method public isElementOptional(I)Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {v0, p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->isElementOptional(I)Z

    move-result p1

    return p1
.end method

.method public isNullable()Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/descriptors/WrappedSerialDescriptor;->original:Lkotlinx/serialization/descriptors/SerialDescriptor;

    invoke-interface {v0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->isNullable()Z

    move-result v0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 140
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PluginGeneratedSerialDescriptorKt;->toStringImpl(Lkotlinx/serialization/descriptors/SerialDescriptor;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
