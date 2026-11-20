.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath;
.super Ljava/lang/Object;
.source "ImplPixelMath.java"


# direct methods
.method public static pow2([FII[FIIII)V
    .locals 5

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p6, :cond_1

    mul-int v1, v0, p2

    add-int/2addr v1, p1

    mul-int v2, v0, p5

    add-int/2addr v2, p4

    add-int v3, v1, p7

    :goto_1
    if-ge v1, v3, :cond_0

    .line 3327
    aget v4, p0, v1

    mul-float/2addr v4, v4

    .line 3328
    aput v4, p3, v2

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static sqrt([FII[FIIII)V
    .locals 6

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p6, :cond_1

    mul-int v1, v0, p2

    add-int/2addr v1, p1

    mul-int v2, v0, p5

    add-int/2addr v2, p4

    add-int v3, v1, p7

    :goto_1
    if-ge v1, v3, :cond_0

    .line 3259
    aget v4, p0, v1

    float-to-double v4, v4

    invoke-static {v4, v5}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v4

    double-to-float v4, v4

    aput v4, p3, v2

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static subtract(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 10

    .line 3035
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v0

    .line 3036
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v1

    const/4 v2, 0x0

    :goto_0
    if-ge v2, v0, :cond_1

    .line 3040
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v3

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v4

    mul-int/2addr v4, v2

    add-int/2addr v3, v4

    .line 3041
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v4

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v5

    mul-int/2addr v5, v2

    add-int/2addr v4, v5

    .line 3042
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v5

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v6

    mul-int/2addr v6, v2

    add-int/2addr v5, v6

    add-int v6, v3, v1

    :goto_1
    if-ge v3, v6, :cond_0

    .line 3047
    iget-object v7, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v8, v8, v3

    iget-object v9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v9, v9, v4

    sub-float/2addr v8, v9

    aput v8, v7, v5

    add-int/lit8 v3, v3, 0x1

    add-int/lit8 v4, v4, 0x1

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method
