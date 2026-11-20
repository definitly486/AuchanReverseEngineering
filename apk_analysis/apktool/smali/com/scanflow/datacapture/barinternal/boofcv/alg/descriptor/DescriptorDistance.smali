.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/descriptor/DescriptorDistance;
.super Ljava/lang/Object;
.source "DescriptorDistance.java"


# direct methods
.method public static hamming(I)I
    .locals 2

    .line 252
    shr-int/lit8 v0, p0, 0x1

    const v1, 0x55555555

    and-int/2addr v0, v1

    sub-int/2addr p0, v0

    const v0, 0x33333333

    and-int v1, p0, v0

    shr-int/lit8 p0, p0, 0x2

    and-int/2addr p0, v0

    add-int/2addr v1, p0

    shr-int/lit8 p0, v1, 0x4

    add-int/2addr v1, p0

    const p0, 0xf0f0f0f

    and-int/2addr p0, v1

    const v0, 0x1010101

    mul-int/2addr p0, v0

    shr-int/lit8 p0, p0, 0x18

    return p0
.end method
