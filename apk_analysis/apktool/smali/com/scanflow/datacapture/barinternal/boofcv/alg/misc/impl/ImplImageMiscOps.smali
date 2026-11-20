.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;
.super Ljava/lang/Object;
.source "ImplImageMiscOps.java"


# direct methods
.method public static copy(IIIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V
    .locals 5

    .line 80
    iget v0, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int v1, p0, p4

    if-lt v0, v1, :cond_2

    iget v0, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    add-int v1, p1, p5

    if-lt v0, v1, :cond_2

    .line 82
    iget v0, p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int v1, p2, p4

    if-lt v0, v1, :cond_1

    iget v0, p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    add-int v1, p3, p5

    if-lt v0, v1, :cond_1

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p5, :cond_0

    .line 87
    iget v1, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v2, p1, v0

    iget v3, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v3

    add-int/2addr v1, v2

    add-int/2addr v1, p0

    .line 88
    iget v2, p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v3, p3, v0

    iget v4, p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v4

    add-int/2addr v2, v3

    add-int/2addr v2, p2

    .line 90
    iget-object v3, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget-object v4, p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    invoke-static {v3, v1, v4, v2, p4}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    .line 83
    :cond_1
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Copy region must be contained in the output image"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 81
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Copy region must be contained in the input image"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static fillBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V
    .locals 8

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    if-ge v1, p2, :cond_1

    .line 215
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v4, v1, v3

    add-int/2addr v4, v2

    .line 216
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v5, v1

    add-int/lit8 v5, v5, -0x1

    mul-int/2addr v5, v3

    add-int/2addr v2, v5

    move v3, v0

    .line 217
    :goto_1
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v3, v5, :cond_0

    .line 218
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v4, 0x1

    int-to-byte v7, p1

    aput-byte v7, v5, v4

    add-int/lit8 v4, v2, 0x1

    .line 219
    aput-byte v7, v5, v2

    add-int/lit8 v3, v3, 0x1

    move v2, v4

    move v4, v6

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 225
    :cond_1
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v1, p2

    .line 226
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p2

    add-int/2addr v2, v3

    :goto_2
    if-ge v0, p2, :cond_3

    add-int v3, v2, v0

    .line 230
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v4, v2

    add-int/lit8 v4, v4, -0x1

    sub-int/2addr v4, v0

    move v5, p2

    :goto_3
    if-ge v5, v1, :cond_2

    .line 232
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    int-to-byte v7, p1

    aput-byte v7, v6, v3

    .line 233
    aput-byte v7, v6, v4

    .line 235
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v3, v6

    add-int/2addr v4, v6

    add-int/lit8 v5, v5, 0x1

    goto :goto_3

    :cond_2
    add-int/lit8 v0, v0, 0x1

    goto :goto_2

    :cond_3
    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;)V
    .locals 7

    .line 2462
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    const/4 v1, 0x0

    .line 2464
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v2, :cond_1

    .line 2465
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v3

    mul-int/2addr v3, v1

    add-int/2addr v2, v3

    .line 2466
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v3

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v4

    mul-int/2addr v4, v1

    add-int/2addr v3, v4

    add-int/2addr v3, p1

    .line 2467
    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v4, v0

    add-int/2addr v4, v3

    sub-int/2addr v4, p1

    :goto_1
    if-ge v3, v4, :cond_0

    .line 2469
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v6, v6, v2

    aput v6, v5, v3

    add-int/2addr v3, v0

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;)V
    .locals 9

    .line 3031
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    const/4 v1, 0x0

    .line 3033
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v2, :cond_1

    .line 3034
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v3

    mul-int/2addr v3, v1

    add-int/2addr v2, v3

    .line 3035
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v3

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v4

    mul-int/2addr v4, v1

    add-int/2addr v3, v4

    add-int/2addr v3, p1

    .line 3036
    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v4, v0

    add-int/2addr v4, v3

    sub-int/2addr v4, p1

    :goto_1
    if-ge v3, v4, :cond_0

    .line 3038
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v7, v6, v2

    aput-wide v7, v5, v3

    add-int/2addr v3, v0

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;)V
    .locals 7

    .line 754
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    const/4 v1, 0x0

    .line 756
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v2, :cond_1

    .line 757
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v3

    mul-int/2addr v3, v1

    add-int/2addr v2, v3

    .line 758
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v3

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v4

    mul-int/2addr v4, v1

    add-int/2addr v3, v4

    add-int/2addr v3, p1

    .line 759
    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v4, v0

    add-int/2addr v4, v3

    sub-int/2addr v4, p1

    :goto_1
    if-ge v3, v4, :cond_0

    .line 761
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v6, v6, v2

    aput-short v6, v5, v3

    add-int/2addr v3, v0

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;)V
    .locals 7

    .line 184
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    const/4 v1, 0x0

    .line 186
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v2, :cond_1

    .line 187
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v3

    mul-int/2addr v3, v1

    add-int/2addr v2, v3

    .line 188
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v3

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v4

    mul-int/2addr v4, v1

    add-int/2addr v3, v4

    add-int/2addr v3, p1

    .line 189
    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v4, v0

    add-int/2addr v4, v3

    sub-int/2addr v4, p1

    :goto_1
    if-ge v3, v4, :cond_0

    .line 191
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v6, v6, v2

    aput-byte v6, v5, v3

    add-int/2addr v3, v0

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;)V
    .locals 7

    .line 1324
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    const/4 v1, 0x0

    .line 1326
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v2, :cond_1

    .line 1327
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v3

    mul-int/2addr v3, v1

    add-int/2addr v2, v3

    .line 1328
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v3

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v4

    mul-int/2addr v4, v1

    add-int/2addr v3, v4

    add-int/2addr v3, p1

    .line 1329
    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v4, v0

    add-int/2addr v4, v3

    sub-int/2addr v4, p1

    :goto_1
    if-ge v3, v4, :cond_0

    .line 1331
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v6, v6, v2

    aput v6, v5, v3

    add-int/2addr v3, v0

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;)V
    .locals 9

    .line 1893
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    const/4 v1, 0x0

    .line 1895
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v2, :cond_1

    .line 1896
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v3

    mul-int/2addr v3, v1

    add-int/2addr v2, v3

    .line 1897
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v3

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v4

    mul-int/2addr v4, v1

    add-int/2addr v3, v4

    add-int/2addr v3, p1

    .line 1898
    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v4, v0

    add-int/2addr v4, v3

    sub-int/2addr v4, p1

    :goto_1
    if-ge v3, v4, :cond_0

    .line 1900
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v7, v6, v2

    aput-wide v7, v5, v3

    add-int/2addr v3, v0

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method
