.class public interface abstract Lkotlinx/serialization/descriptors/SerialDescriptor;
.super Ljava/lang/Object;
.source "SerialDescriptor.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lkotlinx/serialization/descriptors/SerialDescriptor$DefaultImpls;
    }
.end annotation


# direct methods
.method public static synthetic access$getAnnotations$jd(Lkotlinx/serialization/descriptors/SerialDescriptor;)Ljava/util/List;
    .locals 0

    .line 145
    invoke-super {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getAnnotations()Ljava/util/List;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic access$isInline$jd(Lkotlinx/serialization/descriptors/SerialDescriptor;)Z
    .locals 0

    .line 145
    invoke-super {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->isInline()Z

    move-result p0

    return p0
.end method

.method public static synthetic access$isNullable$jd(Lkotlinx/serialization/descriptors/SerialDescriptor;)Z
    .locals 0

    .line 145
    invoke-super {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->isNullable()Z

    move-result p0

    return p0
.end method


# virtual methods
.method public getAnnotations()Ljava/util/List;
    .locals 1

    .line 279
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public abstract getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;
.end method

.method public abstract getElementName(I)Ljava/lang/String;
.end method

.method public abstract getElementsCount()I
.end method

.method public abstract getKind()Lkotlinx/serialization/descriptors/SerialKind;
.end method

.method public abstract getSerialName()Ljava/lang/String;
.end method

.method public abstract isElementOptional(I)Z
.end method

.method public isInline()Z
    .locals 1

    .line 0
    const/4 v0, 0x0

    return v0
.end method

.method public isNullable()Z
    .locals 1

    .line 0
    const/4 v0, 0x0

    return v0
.end method
