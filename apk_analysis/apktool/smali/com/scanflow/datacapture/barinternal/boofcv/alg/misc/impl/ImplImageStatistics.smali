.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;
.super Ljava/lang/Object;
.source "ImplImageStatistics.java"


# direct methods
.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F[I)V
    .locals 5

    const/4 v0, 0x0

    .line 1731
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 1738
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_1

    .line 1739
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v0

    add-int/2addr v1, v2

    .line 1740
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, v1

    :goto_1
    if-ge v1, v2, :cond_0

    .line 1743
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v4, v1, 0x1

    aget v1, v3, v1

    sub-float/2addr v1, p1

    float-to-int v1, v1

    aget v3, p2, v1

    add-int/lit8 v3, v3, 0x1

    aput v3, p2, v1

    move v1, v4

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;D[I)V
    .locals 7

    const/4 v0, 0x0

    .line 1992
    invoke-static {p3, v0}, Ljava/util/Arrays;->fill([II)V

    .line 1999
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_1

    .line 2000
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v0

    add-int/2addr v1, v2

    .line 2001
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, v1

    :goto_1
    if-ge v1, v2, :cond_0

    .line 2004
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v4, v1, 0x1

    aget-wide v5, v3, v1

    sub-double/2addr v5, p1

    double-to-int v1, v5

    aget v3, p3, v1

    add-int/lit8 v3, v3, 0x1

    aput v3, p3, v1

    move v1, v4

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 948
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 955
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_1

    .line 956
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v0

    add-int/2addr v1, v2

    .line 957
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, v1

    :goto_1
    if-ge v1, v2, :cond_0

    .line 960
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v4, v1, 0x1

    aget-short v1, v3, v1

    sub-int/2addr v1, p1

    aget v3, p2, v1

    add-int/lit8 v3, v3, 0x1

    aput v3, p2, v1

    move v1, v4

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 1209
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 1216
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_1

    .line 1217
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v0

    add-int/2addr v1, v2

    .line 1218
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, v1

    :goto_1
    if-ge v1, v2, :cond_0

    .line 1221
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v4, v1, 0x1

    aget v1, v3, v1

    sub-int/2addr v1, p1

    aget v3, p2, v1

    add-int/lit8 v3, v3, 0x1

    aput v3, p2, v1

    move v1, v4

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;J[I)V
    .locals 7

    const/4 v0, 0x0

    .line 1470
    invoke-static {p3, v0}, Ljava/util/Arrays;->fill([II)V

    .line 1477
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_1

    .line 1478
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v0

    add-int/2addr v1, v2

    .line 1479
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, v1

    :goto_1
    if-ge v1, v2, :cond_0

    .line 1482
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v4, v1, 0x1

    aget-wide v5, v3, v1

    sub-long/2addr v5, p1

    long-to-int v1, v5

    aget v3, p3, v1

    add-int/lit8 v3, v3, 0x1

    aput v3, p3, v1

    move v1, v4

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 468
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 475
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_1

    .line 476
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v0

    add-int/2addr v1, v2

    .line 477
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, v1

    :goto_1
    if-ge v1, v2, :cond_0

    .line 480
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v4, v1, 0x1

    aget-byte v1, v3, v1

    sub-int/2addr v1, p1

    aget v3, p2, v1

    add-int/lit8 v3, v3, 0x1

    aput v3, p2, v1

    move v1, v4

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 687
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 694
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_1

    .line 695
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v0

    add-int/2addr v1, v2

    .line 696
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, v1

    :goto_1
    if-ge v1, v2, :cond_0

    .line 699
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v4, v1, 0x1

    aget-short v1, v3, v1

    const v3, 0xffff

    and-int/2addr v1, v3

    sub-int/2addr v1, p1

    aget v3, p2, v1

    add-int/lit8 v3, v3, 0x1

    aput v3, p2, v1

    move v1, v4

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 207
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 214
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_1

    .line 215
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v0

    add-int/2addr v1, v2

    .line 216
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, v1

    :goto_1
    if-ge v1, v2, :cond_0

    .line 219
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v4, v1, 0x1

    aget-byte v1, v3, v1

    and-int/lit16 v1, v1, 0xff

    sub-int/2addr v1, p1

    aget v3, p2, v1

    add-int/lit8 v3, v3, 0x1

    aput v3, p2, v1

    move v1, v4

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static max([FIIII)F
    .locals 6

    .line 1545
    aget v0, p0, p1

    const/4 v1, 0x0

    :goto_0
    if-ge v1, p2, :cond_2

    mul-int v2, v1, p4

    add-int/2addr v2, p1

    add-int v3, v2, p3

    :goto_1
    if-ge v2, v3, :cond_1

    .line 1554
    aget v4, p0, v2

    cmpl-float v5, v4, v0

    if-lez v5, :cond_0

    move v0, v4

    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    return v0
.end method

.method public static min([FIIII)F
    .locals 6

    .line 1525
    aget v0, p0, p1

    const/4 v1, 0x0

    :goto_0
    if-ge v1, p2, :cond_2

    mul-int v2, v1, p4

    add-int/2addr v2, p1

    add-int v3, v2, p3

    :goto_1
    if-ge v2, v3, :cond_1

    .line 1534
    aget v4, p0, v2

    cmpg-float v5, v4, v0

    if-gez v5, :cond_0

    move v0, v4

    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    return v0
.end method
