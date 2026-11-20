.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;
.super Ljava/lang/Object;
.source "ImplConvolveMean_MT.java"


# direct methods
.method public static synthetic $r8$lambda$0nPwRzCUBJO8YZmLar1pHlIjqNA(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IIIII)V
    .locals 5

    .line 51
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p6

    add-int/2addr v0, v1

    .line 52
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p6

    add-int/2addr v1, v2

    add-int/2addr v1, p2

    add-int p2, v0, p3

    const/4 p6, 0x0

    :goto_0
    if-ge v0, p2, :cond_0

    .line 59
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v2, v2, v0

    and-int/lit16 v2, v2, 0xff

    add-int/2addr p6, v2

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 61
    :cond_0
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v2, v1, 0x1

    add-int v3, p6, p4

    div-int/2addr v3, p5

    int-to-byte v3, v3

    aput-byte v3, p2, v1

    .line 63
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p2, v0

    sub-int/2addr p2, p3

    :goto_1
    if-ge v0, p2, :cond_1

    .line 65
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    sub-int v3, v0, p3

    aget-byte v3, v1, v3

    and-int/lit16 v3, v3, 0xff

    sub-int/2addr p6, v3

    .line 66
    aget-byte v1, v1, v0

    and-int/lit16 v1, v1, 0xff

    add-int/2addr p6, v1

    .line 68
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v2, 0x1

    add-int v4, p6, p4

    div-int/2addr v4, p5

    int-to-byte v4, v4

    aput-byte v4, v1, v2

    add-int/lit8 v0, v0, 0x1

    move v2, v3

    goto :goto_1

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$5gPOZPpNtaszvlAdLShrvocKzq0(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IFIILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;II)V
    .locals 8

    .line 291
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    const/4 v1, 0x0

    invoke-static {p7, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;IZ)[F

    move-result-object v0

    move v2, v1

    .line 292
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    .line 293
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v4, p8, p1

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v5

    add-int/2addr v3, v4

    add-int/2addr v3, v2

    .line 294
    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v6, v6, p8

    add-int/2addr v4, v6

    add-int/2addr v4, v2

    mul-int/2addr v5, p3

    add-int/2addr v5, v3

    const/4 v6, 0x0

    :goto_1
    if-ge v3, v5, :cond_0

    .line 299
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v7, v7, v3

    add-float/2addr v6, v7

    .line 298
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v3, v7

    goto :goto_1

    .line 301
    :cond_0
    aput v6, v0, v2

    .line 302
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    div-float/2addr v6, p4

    aput v6, v3, v4

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    add-int/lit8 p1, p8, 0x1

    move/from16 p3, p9

    :goto_2
    if-ge p1, p3, :cond_3

    .line 307
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v3, p1, p5

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v4

    add-int/2addr v2, v3

    .line 308
    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p1

    add-int/2addr v3, v4

    move v4, v1

    .line 310
    :goto_3
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v4, v5, :cond_2

    .line 311
    aget v5, v0, v4

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    sub-int v7, v2, p6

    aget v7, v6, v7

    sub-float/2addr v5, v7

    .line 312
    aget v6, v6, v2

    add-float/2addr v5, v6

    aput v5, v0, v4

    .line 314
    iget-object v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    div-float/2addr v5, p4

    aput v5, v6, v3

    add-int/lit8 v4, v4, 0x1

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v3, v3, 0x1

    goto :goto_3

    :cond_2
    add-int/lit8 p1, p1, 0x1

    goto :goto_2

    :cond_3
    return-void
.end method

.method public static synthetic $r8$lambda$Gne-nvZeXEla1uxOavuDJbCQX7E(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IIIIILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)V
    .locals 8

    .line 86
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    const/4 v1, 0x0

    move-object/from16 v2, p8

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I

    move-result-object v0

    move v2, v1

    .line 87
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    .line 88
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v4, p9, p1

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v5

    add-int/2addr v3, v4

    add-int/2addr v3, v2

    .line 89
    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v6, v6, p9

    add-int/2addr v4, v6

    add-int/2addr v4, v2

    mul-int/2addr v5, p3

    add-int/2addr v5, v3

    move v6, v1

    :goto_1
    if-ge v3, v5, :cond_0

    .line 94
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v7, v7, v3

    and-int/lit16 v7, v7, 0xff

    add-int/2addr v6, v7

    .line 93
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v3, v7

    goto :goto_1

    .line 96
    :cond_0
    aput v6, v0, v2

    .line 97
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/2addr v6, p4

    div-int/2addr v6, p5

    int-to-byte v5, v6

    aput-byte v5, v3, v4

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    add-int/lit8 p1, p9, 0x1

    move/from16 p3, p10

    :goto_2
    if-ge p1, p3, :cond_3

    .line 102
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v3, p1, p6

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v4

    add-int/2addr v2, v3

    .line 103
    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p1

    add-int/2addr v3, v4

    move v4, v1

    .line 105
    :goto_3
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v4, v5, :cond_2

    .line 106
    aget v5, v0, v4

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    sub-int v7, v2, p7

    aget-byte v7, v6, v7

    and-int/lit16 v7, v7, 0xff

    sub-int/2addr v5, v7

    .line 107
    aget-byte v6, v6, v2

    and-int/lit16 v6, v6, 0xff

    add-int/2addr v5, v6

    aput v5, v0, v4

    .line 109
    iget-object v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/2addr v5, p4

    div-int/2addr v5, p5

    int-to-byte v5, v5

    aput-byte v5, v6, v3

    add-int/lit8 v4, v4, 0x1

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v3, v3, 0x1

    goto :goto_3

    :cond_2
    add-int/lit8 p1, p1, 0x1

    goto :goto_2

    :cond_3
    return-void
.end method

.method public static synthetic $r8$lambda$HsJRtBlB-TyrGjeIrXsVP6FDqQo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IIFI)V
    .locals 5

    .line 257
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p5

    add-int/2addr v0, v1

    .line 258
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p5

    add-int/2addr v1, v2

    add-int/2addr v1, p2

    add-int p2, v0, p3

    const/4 p5, 0x0

    :goto_0
    if-ge v0, p2, :cond_0

    .line 265
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v2, v2, v0

    add-float/2addr p5, v2

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 267
    :cond_0
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v2, v1, 0x1

    div-float v3, p5, p4

    aput v3, p2, v1

    .line 269
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p2, v0

    sub-int/2addr p2, p3

    :goto_1
    if-ge v0, p2, :cond_1

    .line 271
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    sub-int v3, v0, p3

    aget v3, v1, v3

    sub-float/2addr p5, v3

    .line 272
    aget v1, v1, v0

    add-float/2addr p5, v1

    .line 274
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v3, v2, 0x1

    div-float v4, p5, p4

    aput v4, v1, v2

    add-int/lit8 v0, v0, 0x1

    move v2, v3

    goto :goto_1

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$_-Xg89S-iGt0uRugWER9D5wwEMA(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IIIIILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)V
    .locals 9

    .line 224
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    const/4 v1, 0x0

    move-object/from16 v2, p8

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I

    move-result-object v0

    move v2, v1

    .line 225
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    const v4, 0xffff

    if-ge v2, v3, :cond_1

    .line 226
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v5, p9, p1

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, v6

    add-int/2addr v3, v5

    add-int/2addr v3, v2

    .line 227
    iget v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v7, v7, p9

    add-int/2addr v5, v7

    add-int/2addr v5, v2

    mul-int/2addr v6, p3

    add-int/2addr v6, v3

    move v7, v1

    :goto_1
    if-ge v3, v6, :cond_0

    .line 232
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v8, v8, v3

    and-int/2addr v8, v4

    add-int/2addr v7, v8

    .line 231
    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v3, v8

    goto :goto_1

    .line 234
    :cond_0
    aput v7, v0, v2

    .line 235
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/2addr v7, p4

    div-int/2addr v7, p5

    int-to-short v4, v7

    aput-short v4, v3, v5

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    add-int/lit8 p1, p9, 0x1

    move/from16 p3, p10

    :goto_2
    if-ge p1, p3, :cond_3

    .line 240
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v3, p1, p6

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v5

    add-int/2addr v2, v3

    .line 241
    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, p1

    add-int/2addr v3, v5

    move v5, v1

    .line 243
    :goto_3
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_2

    .line 244
    aget v6, v0, v5

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    sub-int v8, v2, p7

    aget-short v8, v7, v8

    and-int/2addr v8, v4

    sub-int/2addr v6, v8

    .line 245
    aget-short v7, v7, v2

    and-int/2addr v7, v4

    add-int/2addr v6, v7

    aput v6, v0, v5

    .line 247
    iget-object v7, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/2addr v6, p4

    div-int/2addr v6, p5

    int-to-short v6, v6

    aput-short v6, v7, v3

    add-int/lit8 v5, v5, 0x1

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v3, v3, 0x1

    goto :goto_3

    :cond_2
    add-int/lit8 p1, p1, 0x1

    goto :goto_2

    :cond_3
    return-void
.end method

.method public static synthetic $r8$lambda$uc2xa_q44mJLRSJ5VABaB5f55sY(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IIIII)V
    .locals 6

    .line 189
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p6

    add-int/2addr v0, v1

    .line 190
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p6

    add-int/2addr v1, v2

    add-int/2addr v1, p2

    add-int p2, v0, p3

    const/4 p6, 0x0

    :goto_0
    const v2, 0xffff

    if-ge v0, p2, :cond_0

    .line 197
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v3, v3, v0

    and-int/2addr v2, v3

    add-int/2addr p6, v2

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 199
    :cond_0
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v3, v1, 0x1

    add-int v4, p6, p4

    div-int/2addr v4, p5

    int-to-short v4, v4

    aput-short v4, p2, v1

    .line 201
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p2, v0

    sub-int/2addr p2, p3

    :goto_1
    if-ge v0, p2, :cond_1

    .line 203
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    sub-int v4, v0, p3

    aget-short v4, v1, v4

    and-int/2addr v4, v2

    sub-int/2addr p6, v4

    .line 204
    aget-short v1, v1, v0

    and-int/2addr v1, v2

    add-int/2addr p6, v1

    .line 206
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v4, v3, 0x1

    add-int v5, p6, p4

    div-int/2addr v5, p5

    int-to-short v5, v5

    aput-short v5, v1, v3

    add-int/lit8 v0, v0, 0x1

    move v3, v4

    goto :goto_1

    :cond_1
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V
    .locals 7

    int-to-float v5, p3

    .line 256
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;

    move-object v1, p0

    move-object v2, p1

    move v3, p2

    move v4, p3

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IIF)V

    const/4 p0, 0x0

    invoke-static {p0, v6, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;II)V
    .locals 8

    .line 186
    div-int/lit8 v5, p3, 0x2

    .line 188
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda2;

    move v6, p3

    move-object v1, p0

    move-object v2, p1

    move v3, p2

    move v4, p3

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IIII)V

    const/4 p0, 0x0

    invoke-static {p0, v7, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V
    .locals 8

    .line 48
    div-int/lit8 v5, p3, 0x2

    .line 50
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;

    move v6, p3

    move-object v1, p0

    move-object v2, p1

    move v3, p2

    move v4, p3

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IIII)V

    const/4 p0, 0x0

    invoke-static {p0, v7, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 9

    .line 280
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;-><init>()V

    invoke-static {p4, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object p4

    .line 281
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v8, p3, v0

    sub-int v0, p3, p2

    add-int/lit8 v7, v0, -0x1

    int-to-float v6, p3

    .line 290
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v0, v7

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda0;

    move-object v2, p0

    move-object v4, p1

    move v3, p2

    move v5, p3

    invoke-direct/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IFII)V

    invoke-static {v3, v0, v5, p4, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IIILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 10

    .line 212
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    invoke-static {p4, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object p4

    .line 213
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v9, p3, v0

    sub-int v0, p3, p2

    add-int/lit8 v8, v0, -0x1

    .line 217
    div-int/lit8 v6, p3, 0x2

    .line 223
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v0, v8

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;

    move v7, p3

    move-object v2, p0

    move-object v4, p1

    move v3, p2

    move v5, p3

    invoke-direct/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IIIII)V

    invoke-static {v3, v0, v5, p4, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IIILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 10

    .line 74
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    invoke-static {p4, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object p4

    .line 75
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v9, p3, v0

    sub-int v0, p3, p2

    add-int/lit8 v8, v0, -0x1

    .line 79
    div-int/lit8 v6, p3, 0x2

    .line 85
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v0, v8

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda3;

    move v7, p3

    move-object v2, p0

    move-object v4, p1

    move v3, p2

    move v5, p3

    invoke-direct/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IIIII)V

    invoke-static {v3, v0, v5, p4, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IIILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V

    return-void
.end method
