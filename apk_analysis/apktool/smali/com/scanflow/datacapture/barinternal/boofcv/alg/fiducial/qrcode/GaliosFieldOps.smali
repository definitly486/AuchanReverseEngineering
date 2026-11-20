.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldOps;
.super Ljava/lang/Object;
.source "GaliosFieldOps.java"


# direct methods
.method public static multiply(IIII)I
    .locals 2

    .line 77
    const/4 v0, 0x0

    :cond_0
    :goto_0
    if-lez p1, :cond_2

    and-int/lit8 v1, p1, 0x1

    if-eqz v1, :cond_1

    xor-int/2addr v0, p0

    :cond_1
    shr-int/lit8 p1, p1, 0x1

    shl-int/lit8 p0, p0, 0x1

    if-lt p0, p3, :cond_0

    xor-int/2addr p0, p2

    goto :goto_0

    :cond_2
    return v0
.end method

.method public static subtract(II)I
    .locals 0

    .line 40
    xor-int/2addr p0, p1

    return p0
.end method
