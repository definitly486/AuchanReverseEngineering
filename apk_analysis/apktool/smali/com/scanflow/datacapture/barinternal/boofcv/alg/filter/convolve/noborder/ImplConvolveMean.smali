.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean;
.super Ljava/lang/Object;
.source "ImplConvolveMean.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V
    .locals 9

    int-to-float v0, p3

    const/4 v1, 0x0

    .line 269
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v2, :cond_2

    .line 270
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v1

    add-int/2addr v2, v3

    .line 271
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v1

    add-int/2addr v3, v4

    add-int/2addr v3, p2

    add-int v4, v2, p3

    const/4 v5, 0x0

    :goto_1
    if-ge v2, v4, :cond_0

    .line 278
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v6, v6, v2

    add-float/2addr v5, v6

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 280
    :cond_0
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v6, v3, 0x1

    div-float v7, v5, v0

    aput v7, v4, v3

    .line 282
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v3, v2

    sub-int/2addr v3, p3

    :goto_2
    if-ge v2, v3, :cond_1

    .line 284
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    sub-int v7, v2, p3

    aget v7, v4, v7

    sub-float/2addr v5, v7

    .line 285
    aget v4, v4, v2

    add-float/2addr v5, v4

    .line 287
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v7, v6, 0x1

    div-float v8, v5, v0

    aput v8, v4, v6

    add-int/lit8 v2, v2, 0x1

    move v6, v7

    goto :goto_2

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;II)V
    .locals 11

    .line 194
    div-int/lit8 v0, p3, 0x2

    const/4 v1, 0x0

    move v2, v1

    .line 197
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_2

    .line 198
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v2

    add-int/2addr v3, v4

    .line 199
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, v2

    add-int/2addr v4, v5

    add-int/2addr v4, p2

    add-int v5, v3, p3

    move v6, v1

    :goto_1
    const v7, 0xffff

    if-ge v3, v5, :cond_0

    .line 206
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v8, v8, v3

    and-int/2addr v7, v8

    add-int/2addr v6, v7

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 208
    :cond_0
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v4, 0x1

    add-int v9, v6, v0

    div-int/2addr v9, p3

    int-to-short v9, v9

    aput-short v9, v5, v4

    .line 210
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v4, v3

    sub-int/2addr v4, p3

    :goto_2
    if-ge v3, v4, :cond_1

    .line 212
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    sub-int v9, v3, p3

    aget-short v9, v5, v9

    and-int/2addr v9, v7

    sub-int/2addr v6, v9

    .line 213
    aget-short v5, v5, v3

    and-int/2addr v5, v7

    add-int/2addr v6, v5

    .line 215
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v9, v8, 0x1

    add-int v10, v6, v0

    div-int/2addr v10, p3

    int-to-short v10, v10

    aput-short v10, v5, v8

    add-int/lit8 v3, v3, 0x1

    move v8, v9

    goto :goto_2

    :cond_1
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V
    .locals 10

    .line 48
    div-int/lit8 v0, p3, 0x2

    const/4 v1, 0x0

    move v2, v1

    .line 51
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_2

    .line 52
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v2

    add-int/2addr v3, v4

    .line 53
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, v2

    add-int/2addr v4, v5

    add-int/2addr v4, p2

    add-int v5, v3, p3

    move v6, v1

    :goto_1
    if-ge v3, v5, :cond_0

    .line 60
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v7, v7, v3

    and-int/lit16 v7, v7, 0xff

    add-int/2addr v6, v7

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 62
    :cond_0
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v4, 0x1

    add-int v8, v6, v0

    div-int/2addr v8, p3

    int-to-byte v8, v8

    aput-byte v8, v5, v4

    .line 64
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v4, v3

    sub-int/2addr v4, p3

    :goto_2
    if-ge v3, v4, :cond_1

    .line 66
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    sub-int v8, v3, p3

    aget-byte v8, v5, v8

    and-int/lit16 v8, v8, 0xff

    sub-int/2addr v6, v8

    .line 67
    aget-byte v5, v5, v3

    and-int/lit16 v5, v5, 0xff

    add-int/2addr v6, v5

    .line 69
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v8, v7, 0x1

    add-int v9, v6, v0

    div-int/2addr v9, p3

    int-to-byte v9, v9

    aput-byte v9, v5, v7

    add-int/lit8 v3, v3, 0x1

    move v7, v8

    goto :goto_2

    :cond_1
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 11

    .line 294
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;-><init>()V

    invoke-static {p4, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object p4

    .line 295
    invoke-virtual {p4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->grow()Ljava/lang/Object;

    move-result-object p4

    check-cast p4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    .line 296
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v0, p3

    sub-int v1, p3, p2

    add-int/lit8 v1, v1, -0x1

    int-to-float v2, p3

    .line 306
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v3, v1

    .line 307
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    const/4 v5, 0x0

    invoke-static {p4, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;IZ)[F

    move-result-object p4

    move v4, v5

    .line 308
    :goto_0
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v4, v6, :cond_1

    .line 309
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v6, v4

    .line 310
    iget v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v9, p2

    add-int/2addr v8, v9

    add-int/2addr v8, v4

    mul-int/2addr v7, p3

    add-int/2addr v7, v6

    const/4 v9, 0x0

    :goto_1
    if-ge v6, v7, :cond_0

    .line 315
    iget-object v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v10, v10, v6

    add-float/2addr v9, v10

    .line 314
    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v6, v10

    goto :goto_1

    .line 317
    :cond_0
    aput v9, p4, v4

    .line 318
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    div-float/2addr v9, v2

    aput v9, v6, v8

    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_1
    :goto_2
    add-int/lit8 p2, p2, 0x1

    if-ge p2, v3, :cond_3

    .line 323
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v4, p2, v1

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v6

    add-int/2addr p3, v4

    .line 324
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, p2

    add-int/2addr v4, v6

    move v6, v5

    .line 326
    :goto_3
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v6, v7, :cond_2

    .line 327
    aget v7, p4, v6

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    sub-int v9, p3, v0

    aget v9, v8, v9

    sub-float/2addr v7, v9

    .line 328
    aget v8, v8, p3

    add-float/2addr v7, v8

    aput v7, p4, v6

    .line 330
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    div-float/2addr v7, v2

    aput v7, v8, v4

    add-int/lit8 v6, v6, 0x1

    add-int/lit8 p3, p3, 0x1

    add-int/lit8 v4, v4, 0x1

    goto :goto_3

    :cond_2
    goto :goto_2

    :cond_3
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 16

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    .line 222
    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    move-object/from16 v3, p4

    invoke-static {v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object v2

    .line 223
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->grow()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 224
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v3, v3, p3

    sub-int v4, p3, p2

    add-int/lit8 v4, v4, -0x1

    .line 228
    div-int/lit8 v5, p3, 0x2

    .line 235
    iget v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v6, v4

    .line 236
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    const/4 v8, 0x0

    invoke-static {v2, v7, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I

    move-result-object v2

    move v7, v8

    .line 237
    :goto_0
    iget v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    const v10, 0xffff

    if-ge v7, v9, :cond_1

    .line 238
    iget v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v9, v7

    .line 239
    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v13, v13, p2

    add-int/2addr v12, v13

    add-int/2addr v12, v7

    mul-int v11, v11, p3

    add-int/2addr v11, v9

    move v13, v8

    :goto_1
    if-ge v9, v11, :cond_0

    .line 244
    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v14, v14, v9

    and-int/2addr v14, v10

    add-int/2addr v13, v14

    .line 243
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v9, v14

    goto :goto_1

    .line 246
    :cond_0
    aput v13, v2, v7

    .line 247
    iget-object v9, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/2addr v13, v5

    div-int v13, v13, p3

    int-to-short v10, v13

    aput-short v10, v9, v12

    add-int/lit8 v7, v7, 0x1

    goto :goto_0

    :cond_1
    add-int/lit8 v7, p2, 0x1

    :goto_2
    if-ge v7, v6, :cond_3

    .line 252
    iget v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v11, v7, v4

    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v11, v12

    add-int/2addr v9, v11

    .line 253
    iget v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v7

    add-int/2addr v11, v12

    move v12, v8

    .line 255
    :goto_3
    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v12, v13, :cond_2

    .line 256
    aget v13, v2, v12

    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    sub-int v15, v9, v3

    aget-short v15, v14, v15

    and-int/2addr v15, v10

    sub-int/2addr v13, v15

    .line 257
    aget-short v14, v14, v9

    and-int/2addr v14, v10

    add-int/2addr v13, v14

    aput v13, v2, v12

    .line 259
    iget-object v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/2addr v13, v5

    div-int v13, v13, p3

    int-to-short v13, v13

    aput-short v13, v14, v11

    add-int/lit8 v12, v12, 0x1

    add-int/lit8 v9, v9, 0x1

    add-int/lit8 v11, v11, 0x1

    goto :goto_3

    :cond_2
    add-int/lit8 v7, v7, 0x1

    goto :goto_2

    :cond_3
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 11

    .line 76
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    invoke-static {p4, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object p4

    .line 77
    invoke-virtual {p4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->grow()Ljava/lang/Object;

    move-result-object p4

    check-cast p4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 78
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v0, p3

    sub-int v1, p3, p2

    add-int/lit8 v1, v1, -0x1

    .line 82
    div-int/lit8 v2, p3, 0x2

    .line 89
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v3, v1

    .line 90
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    const/4 v5, 0x0

    invoke-static {p4, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I

    move-result-object p4

    move v4, v5

    .line 91
    :goto_0
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v4, v6, :cond_1

    .line 92
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v6, v4

    .line 93
    iget v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v9, p2

    add-int/2addr v8, v9

    add-int/2addr v8, v4

    mul-int/2addr v7, p3

    add-int/2addr v7, v6

    move v9, v5

    :goto_1
    if-ge v6, v7, :cond_0

    .line 98
    iget-object v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v10, v10, v6

    and-int/lit16 v10, v10, 0xff

    add-int/2addr v9, v10

    .line 97
    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v6, v10

    goto :goto_1

    .line 100
    :cond_0
    aput v9, p4, v4

    .line 101
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/2addr v9, v2

    div-int/2addr v9, p3

    int-to-byte v7, v9

    aput-byte v7, v6, v8

    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_1
    :goto_2
    add-int/lit8 p2, p2, 0x1

    if-ge p2, v3, :cond_3

    .line 106
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v6, p2, v1

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v7

    add-int/2addr v4, v6

    .line 107
    iget v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v7, p2

    add-int/2addr v6, v7

    move v7, v5

    .line 109
    :goto_3
    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v7, v8, :cond_2

    .line 110
    aget v8, p4, v7

    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    sub-int v10, v4, v0

    aget-byte v10, v9, v10

    and-int/lit16 v10, v10, 0xff

    sub-int/2addr v8, v10

    .line 111
    aget-byte v9, v9, v4

    and-int/lit16 v9, v9, 0xff

    add-int/2addr v8, v9

    aput v8, p4, v7

    .line 113
    iget-object v9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/2addr v8, v2

    div-int/2addr v8, p3

    int-to-byte v8, v8

    aput-byte v8, v9, v6

    add-int/lit8 v7, v7, 0x1

    add-int/lit8 v4, v4, 0x1

    add-int/lit8 v6, v6, 0x1

    goto :goto_3

    :cond_2
    goto :goto_2

    :cond_3
    return-void
.end method
