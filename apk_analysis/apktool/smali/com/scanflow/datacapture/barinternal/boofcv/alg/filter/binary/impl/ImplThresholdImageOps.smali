.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;
.super Ljava/lang/Object;
.source "ImplThresholdImageOps.java"


# direct methods
.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 6

    .line 472
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v0

    int-to-double v0, v0

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result p2

    div-int/lit8 v4, p2, 0x2

    const-wide/high16 v2, -0x4010000000000000L    # -1.0

    move-object v0, p0

    move-object v1, p5

    move-object v5, p6

    .line 476
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    const/4 p0, 0x0

    const/4 p2, 0x1

    if-eqz p4, :cond_2

    move p4, p0

    .line 480
    :goto_0
    iget p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p5, :cond_5

    .line 481
    iget p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p6, p4

    add-int/2addr p5, p6

    .line 482
    iget p6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr p6, v2

    .line 483
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p4

    add-int/2addr v2, v3

    .line 485
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v3, p5

    :goto_1
    if-ge p5, v3, :cond_1

    .line 488
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v4, v4, v2

    mul-float/2addr v4, p3

    .line 490
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v5, v5, p5

    cmpg-float v4, v5, v4

    if-gtz v4, :cond_0

    .line 491
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p2, v4, p6

    goto :goto_2

    .line 493
    :cond_0
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p0, v4, p6

    :goto_2
    add-int/lit8 p5, p5, 0x1

    add-int/lit8 p6, p6, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_1
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    :cond_2
    move p4, p0

    .line 499
    :goto_3
    iget p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p5, :cond_5

    .line 500
    iget p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p6, p4

    add-int/2addr p5, p6

    .line 501
    iget p6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr p6, v2

    .line 502
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p4

    add-int/2addr v2, v3

    .line 504
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v3, p5

    :goto_4
    if-ge p5, v3, :cond_4

    .line 507
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v4, v4, v2

    .line 509
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v5, v5, p5

    mul-float/2addr v5, p3

    cmpl-float v4, v5, v4

    if-lez v4, :cond_3

    .line 510
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p2, v4, p6

    goto :goto_5

    .line 512
    :cond_3
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p0, v4, p6

    :goto_5
    add-int/lit8 p5, p5, 0x1

    add-int/lit8 p6, p6, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_4

    :cond_4
    add-int/lit8 p4, p4, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 7

    .line 373
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v0

    int-to-double v0, v0

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result p2

    div-int/lit8 v4, p2, 0x2

    const-wide/high16 v2, -0x4010000000000000L    # -1.0

    move-object v0, p0

    move-object v1, p5

    move-object v5, p6

    .line 377
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    const p0, 0xffff

    const/4 p2, 0x0

    const/4 p5, 0x1

    if-eqz p4, :cond_2

    move p4, p2

    .line 381
    :goto_0
    iget p6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p6, :cond_5

    .line 382
    iget p6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr p6, v2

    .line 383
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p4

    add-int/2addr v2, v3

    .line 384
    iget v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p4

    add-int/2addr v3, v4

    .line 386
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v4, p6

    :goto_1
    if-ge p6, v4, :cond_1

    .line 389
    iget-object v5, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v5, v5, v3

    and-int/2addr v5, p0

    int-to-float v5, v5

    mul-float/2addr v5, p3

    .line 391
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v6, v6, p6

    and-int/2addr v6, p0

    int-to-float v6, v6

    cmpg-float v5, v6, v5

    if-gtz v5, :cond_0

    .line 392
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p5, v5, v2

    goto :goto_2

    .line 394
    :cond_0
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p2, v5, v2

    :goto_2
    add-int/lit8 p6, p6, 0x1

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_1
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    :cond_2
    move p4, p2

    .line 400
    :goto_3
    iget p6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p6, :cond_5

    .line 401
    iget p6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr p6, v2

    .line 402
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p4

    add-int/2addr v2, v3

    .line 403
    iget v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p4

    add-int/2addr v3, v4

    .line 405
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v4, p6

    :goto_4
    if-ge p6, v4, :cond_4

    .line 408
    iget-object v5, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v5, v5, v3

    and-int/2addr v5, p0

    .line 410
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v6, v6, p6

    and-int/2addr v6, p0

    int-to-float v6, v6

    mul-float/2addr v6, p3

    int-to-float v5, v5

    cmpl-float v5, v6, v5

    if-lez v5, :cond_3

    .line 411
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p5, v5, v2

    goto :goto_5

    .line 413
    :cond_3
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p2, v5, v2

    :goto_5
    add-int/lit8 p6, p6, 0x1

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v3, v3, 0x1

    goto :goto_4

    :cond_4
    add-int/lit8 p4, p4, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 6

    .line 274
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v0

    int-to-double v0, v0

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result p2

    div-int/lit8 v4, p2, 0x2

    const-wide/high16 v2, -0x4010000000000000L    # -1.0

    move-object v0, p0

    move-object v1, p5

    move-object v5, p6

    .line 278
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 p0, 0x0

    const/4 p2, 0x1

    if-eqz p4, :cond_2

    move p4, p0

    .line 282
    :goto_0
    iget p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p5, :cond_5

    .line 283
    iget p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p6, p4

    add-int/2addr p5, p6

    .line 284
    iget p6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr p6, v2

    .line 285
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p4

    add-int/2addr v2, v3

    .line 287
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v3, p5

    :goto_1
    if-ge p5, v3, :cond_1

    .line 290
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v4, v4, v2

    and-int/lit16 v4, v4, 0xff

    int-to-float v4, v4

    mul-float/2addr v4, p3

    .line 292
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v5, v5, p5

    and-int/lit16 v5, v5, 0xff

    int-to-float v5, v5

    cmpg-float v4, v5, v4

    if-gtz v4, :cond_0

    .line 293
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p2, v4, p6

    goto :goto_2

    .line 295
    :cond_0
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p0, v4, p6

    :goto_2
    add-int/lit8 p5, p5, 0x1

    add-int/lit8 p6, p6, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_1
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    :cond_2
    move p4, p0

    .line 301
    :goto_3
    iget p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p5, :cond_5

    .line 302
    iget p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p6, p4

    add-int/2addr p5, p6

    .line 303
    iget p6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr p6, v2

    .line 304
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p4

    add-int/2addr v2, v3

    .line 306
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v3, p5

    :goto_4
    if-ge p5, v3, :cond_4

    .line 309
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v4, v4, v2

    and-int/lit16 v4, v4, 0xff

    .line 311
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v5, v5, p5

    and-int/lit16 v5, v5, 0xff

    int-to-float v5, v5

    mul-float/2addr v5, p3

    int-to-float v4, v4

    cmpl-float v4, v5, v4

    if-lez v4, :cond_3

    .line 312
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p2, v4, p6

    goto :goto_5

    .line 314
    :cond_3
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aput-byte p0, v4, p6

    :goto_5
    add-int/lit8 p5, p5, 0x1

    add-int/lit8 p6, p6, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_4

    :cond_4
    add-int/lit8 p4, p4, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 8

    .line 427
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v0

    int-to-double v0, v0

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result p2

    div-int/lit8 p2, p2, 0x2

    .line 431
    invoke-static {p0, p5, p2, p6, p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    const/4 p2, 0x0

    const/4 p6, 0x1

    if-eqz p4, :cond_2

    move p4, p2

    .line 435
    :goto_0
    iget p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p7, :cond_5

    .line 436
    iget p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v0, p4

    add-int/2addr p7, v0

    .line 437
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 438
    iget v1, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 440
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, p7

    :goto_1
    if-ge p7, v2, :cond_1

    .line 443
    iget-object v3, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v4, v1, 0x1

    aget v1, v3, v1

    mul-float/2addr v1, p3

    .line 444
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v0, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v7, p7, 0x1

    aget p7, v6, p7

    cmpg-float p7, p7, v1

    if-gtz p7, :cond_0

    move p7, p6

    goto :goto_2

    :cond_0
    move p7, p2

    :goto_2
    aput-byte p7, v3, v0

    move v1, v4

    move v0, v5

    move p7, v7

    goto :goto_1

    :cond_1
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    :cond_2
    move p4, p2

    .line 450
    :goto_3
    iget p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p7, :cond_5

    .line 451
    iget p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v0, p4

    add-int/2addr p7, v0

    .line 452
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 453
    iget v1, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 455
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, p7

    :goto_4
    if-ge p7, v2, :cond_4

    .line 458
    iget-object v3, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v4, v1, 0x1

    aget v1, v3, v1

    .line 459
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v0, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v7, p7, 0x1

    aget p7, v6, p7

    mul-float/2addr p7, p3

    cmpl-float p7, p7, v1

    if-lez p7, :cond_3

    move p7, p6

    goto :goto_5

    :cond_3
    move p7, p2

    :goto_5
    aput-byte p7, v3, v0

    move v1, v4

    move v0, v5

    move p7, v7

    goto :goto_4

    :cond_4
    add-int/lit8 p4, p4, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 16

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p5

    .line 328
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v3, v4}, Ljava/lang/Math;->min(II)I

    move-result v3

    int-to-double v3, v3

    move-object/from16 v5, p2

    invoke-virtual {v5, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result v3

    div-int/lit8 v3, v3, 0x2

    move-object/from16 v4, p6

    move-object/from16 v5, p7

    .line 332
    invoke-static {v0, v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    const v3, 0xffff

    const/4 v4, 0x0

    const/4 v5, 0x1

    if-eqz p4, :cond_2

    move v6, v4

    .line 336
    :goto_0
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v7, :cond_5

    .line 337
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v8, v6

    add-int/2addr v7, v8

    .line 338
    iget v8, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v9, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v9, v6

    add-int/2addr v8, v9

    .line 339
    iget v9, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v10, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v6

    add-int/2addr v9, v10

    .line 341
    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v10, v7

    :goto_1
    if-ge v7, v10, :cond_1

    .line 344
    iget-object v11, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v12, v9, 0x1

    aget-short v9, v11, v9

    and-int/2addr v9, v3

    int-to-float v9, v9

    mul-float v9, v9, p3

    .line 345
    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v13, v8, 0x1

    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v15, v7, 0x1

    aget-short v7, v14, v7

    and-int/2addr v7, v3

    int-to-float v7, v7

    cmpg-float v7, v7, v9

    if-gtz v7, :cond_0

    move v7, v5

    goto :goto_2

    :cond_0
    move v7, v4

    :goto_2
    aput-byte v7, v11, v8

    move v9, v12

    move v8, v13

    move v7, v15

    goto :goto_1

    :cond_1
    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_2
    move v6, v4

    .line 351
    :goto_3
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v7, :cond_5

    .line 352
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v8, v6

    add-int/2addr v7, v8

    .line 353
    iget v8, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v9, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v9, v6

    add-int/2addr v8, v9

    .line 354
    iget v9, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v10, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v6

    add-int/2addr v9, v10

    .line 356
    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v10, v7

    :goto_4
    if-ge v7, v10, :cond_4

    .line 359
    iget-object v11, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v12, v9, 0x1

    aget-short v9, v11, v9

    and-int/2addr v9, v3

    int-to-float v9, v9

    .line 360
    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v13, v8, 0x1

    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v15, v7, 0x1

    aget-short v7, v14, v7

    and-int/2addr v7, v3

    int-to-float v7, v7

    mul-float v7, v7, p3

    cmpl-float v7, v7, v9

    if-lez v7, :cond_3

    move v7, v5

    goto :goto_5

    :cond_3
    move v7, v4

    :goto_5
    aput-byte v7, v11, v8

    move v9, v12

    move v8, v13

    move v7, v15

    goto :goto_4

    :cond_4
    add-int/lit8 v6, v6, 0x1

    goto :goto_3

    :cond_5
    return-object v1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 8

    .line 229
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v0

    int-to-double v0, v0

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result p2

    div-int/lit8 p2, p2, 0x2

    .line 233
    invoke-static {p0, p5, p2, p6, p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 p2, 0x0

    const/4 p6, 0x1

    if-eqz p4, :cond_2

    move p4, p2

    .line 237
    :goto_0
    iget p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p7, :cond_5

    .line 238
    iget p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v0, p4

    add-int/2addr p7, v0

    .line 239
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 240
    iget v1, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 242
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, p7

    :goto_1
    if-ge p7, v2, :cond_1

    .line 245
    iget-object v3, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v4, v1, 0x1

    aget-byte v1, v3, v1

    and-int/lit16 v1, v1, 0xff

    int-to-float v1, v1

    mul-float/2addr v1, p3

    .line 246
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v0, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, p7, 0x1

    aget-byte p7, v6, p7

    and-int/lit16 p7, p7, 0xff

    int-to-float p7, p7

    cmpg-float p7, p7, v1

    if-gtz p7, :cond_0

    move p7, p6

    goto :goto_2

    :cond_0
    move p7, p2

    :goto_2
    aput-byte p7, v3, v0

    move v1, v4

    move v0, v5

    move p7, v7

    goto :goto_1

    :cond_1
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    :cond_2
    move p4, p2

    .line 252
    :goto_3
    iget p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, p7, :cond_5

    .line 253
    iget p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v0, p4

    add-int/2addr p7, v0

    .line 254
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 255
    iget v1, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 257
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v2, p7

    :goto_4
    if-ge p7, v2, :cond_4

    .line 260
    iget-object v3, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v4, v1, 0x1

    aget-byte v1, v3, v1

    and-int/lit16 v1, v1, 0xff

    int-to-float v1, v1

    .line 261
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v0, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, p7, 0x1

    aget-byte p7, v6, p7

    and-int/lit16 p7, p7, 0xff

    int-to-float p7, p7

    mul-float/2addr p7, p3

    cmpl-float p7, p7, v1

    if-lez p7, :cond_3

    move p7, p6

    goto :goto_5

    :cond_3
    move p7, p2

    :goto_5
    aput-byte p7, v3, v0

    move v1, v4

    move v0, v5

    move p7, v7

    goto :goto_4

    :cond_4
    add-int/lit8 p4, p4, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 9

    const/4 v0, 0x0

    const/4 v1, 0x1

    if-eqz p3, :cond_2

    move p3, v0

    .line 49
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v2, :cond_5

    .line 50
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p3

    add-int/2addr v2, v3

    .line 51
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 53
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_1
    if-lez v4, :cond_1

    .line 54
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v8, v2, 0x1

    aget v2, v7, v2

    cmpg-float v2, v2, p2

    if-gtz v2, :cond_0

    move v2, v1

    goto :goto_2

    :cond_0
    move v2, v0

    :goto_2
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_1

    :cond_1
    add-int/lit8 p3, p3, 0x1

    goto :goto_0

    :cond_2
    move p3, v0

    .line 60
    :goto_3
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v2, :cond_5

    .line 61
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p3

    add-int/2addr v2, v3

    .line 62
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 64
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_4
    if-lez v4, :cond_4

    .line 65
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v8, v2, 0x1

    aget v2, v7, v2

    cmpl-float v2, v2, p2

    if-lez v2, :cond_3

    move v2, v1

    goto :goto_5

    :cond_3
    move v2, v0

    :goto_5
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_4

    :cond_4
    add-int/lit8 p3, p3, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 11

    const/4 v0, 0x0

    const/4 v1, 0x1

    if-eqz p4, :cond_2

    move p4, v0

    .line 79
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, v2, :cond_5

    .line 80
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p4

    add-int/2addr v2, v3

    .line 81
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p4

    add-int/2addr v3, v4

    .line 83
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_1
    if-lez v4, :cond_1

    .line 84
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v8, v2, 0x1

    aget-wide v9, v7, v2

    cmpg-double v2, v9, p2

    if-gtz v2, :cond_0

    move v2, v1

    goto :goto_2

    :cond_0
    move v2, v0

    :goto_2
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_1

    :cond_1
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    :cond_2
    move p4, v0

    .line 90
    :goto_3
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p4, v2, :cond_5

    .line 91
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p4

    add-int/2addr v2, v3

    .line 92
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p4

    add-int/2addr v3, v4

    .line 94
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_4
    if-lez v4, :cond_4

    .line 95
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v8, v2, 0x1

    aget-wide v9, v7, v2

    cmpl-double v2, v9, p2

    if-lez v2, :cond_3

    move v2, v1

    goto :goto_5

    :cond_3
    move v2, v0

    :goto_5
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_4

    :cond_4
    add-int/lit8 p4, p4, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 9

    const/4 v0, 0x0

    const/4 v1, 0x1

    if-eqz p3, :cond_2

    move p3, v0

    .line 139
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v2, :cond_5

    .line 140
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p3

    add-int/2addr v2, v3

    .line 141
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 143
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_1
    if-lez v4, :cond_1

    .line 144
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v2, 0x1

    aget-short v2, v7, v2

    if-gt v2, p2, :cond_0

    move v2, v1

    goto :goto_2

    :cond_0
    move v2, v0

    :goto_2
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_1

    :cond_1
    add-int/lit8 p3, p3, 0x1

    goto :goto_0

    :cond_2
    move p3, v0

    .line 150
    :goto_3
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v2, :cond_5

    .line 151
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p3

    add-int/2addr v2, v3

    .line 152
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 154
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_4
    if-lez v4, :cond_4

    .line 155
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v2, 0x1

    aget-short v2, v7, v2

    if-le v2, p2, :cond_3

    move v2, v1

    goto :goto_5

    :cond_3
    move v2, v0

    :goto_5
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_4

    :cond_4
    add-int/lit8 p3, p3, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 9

    const/4 v0, 0x0

    const/4 v1, 0x1

    if-eqz p3, :cond_2

    move p3, v0

    .line 199
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v2, :cond_5

    .line 200
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p3

    add-int/2addr v2, v3

    .line 201
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 203
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_1
    if-lez v4, :cond_1

    .line 204
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v8, v2, 0x1

    aget v2, v7, v2

    if-gt v2, p2, :cond_0

    move v2, v1

    goto :goto_2

    :cond_0
    move v2, v0

    :goto_2
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_1

    :cond_1
    add-int/lit8 p3, p3, 0x1

    goto :goto_0

    :cond_2
    move p3, v0

    .line 210
    :goto_3
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v2, :cond_5

    .line 211
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p3

    add-int/2addr v2, v3

    .line 212
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 214
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_4
    if-lez v4, :cond_4

    .line 215
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v8, v2, 0x1

    aget v2, v7, v2

    if-le v2, p2, :cond_3

    move v2, v1

    goto :goto_5

    :cond_3
    move v2, v0

    :goto_5
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_4

    :cond_4
    add-int/lit8 p3, p3, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 10

    const v0, 0xffff

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-eqz p3, :cond_2

    move p3, v1

    .line 169
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v3, :cond_5

    .line 170
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 171
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, p3

    add-int/2addr v4, v5

    .line 173
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_1
    if-lez v5, :cond_1

    .line 174
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v4, 0x1

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v9, v3, 0x1

    aget-short v3, v8, v3

    and-int/2addr v3, v0

    if-gt v3, p2, :cond_0

    move v3, v2

    goto :goto_2

    :cond_0
    move v3, v1

    :goto_2
    int-to-byte v3, v3

    aput-byte v3, v6, v4

    add-int/lit8 v5, v5, -0x1

    move v4, v7

    move v3, v9

    goto :goto_1

    :cond_1
    add-int/lit8 p3, p3, 0x1

    goto :goto_0

    :cond_2
    move p3, v1

    .line 180
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v3, :cond_5

    .line 181
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 182
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, p3

    add-int/2addr v4, v5

    .line 184
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_4
    if-lez v5, :cond_4

    .line 185
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v4, 0x1

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v9, v3, 0x1

    aget-short v3, v8, v3

    and-int/2addr v3, v0

    if-le v3, p2, :cond_3

    move v3, v2

    goto :goto_5

    :cond_3
    move v3, v1

    :goto_5
    int-to-byte v3, v3

    aput-byte v3, v6, v4

    add-int/lit8 v5, v5, -0x1

    move v4, v7

    move v3, v9

    goto :goto_4

    :cond_4
    add-int/lit8 p3, p3, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 9

    const/4 v0, 0x0

    const/4 v1, 0x1

    if-eqz p3, :cond_2

    move p3, v0

    .line 109
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v2, :cond_5

    .line 110
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p3

    add-int/2addr v2, v3

    .line 111
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 113
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_1
    if-lez v4, :cond_1

    .line 114
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v8, v2, 0x1

    aget-byte v2, v7, v2

    and-int/lit16 v2, v2, 0xff

    if-gt v2, p2, :cond_0

    move v2, v1

    goto :goto_2

    :cond_0
    move v2, v0

    :goto_2
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_1

    :cond_1
    add-int/lit8 p3, p3, 0x1

    goto :goto_0

    :cond_2
    move p3, v0

    .line 120
    :goto_3
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p3, v2, :cond_5

    .line 121
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, p3

    add-int/2addr v2, v3

    .line 122
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, p3

    add-int/2addr v3, v4

    .line 124
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_4
    if-lez v4, :cond_4

    .line 125
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v3, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v8, v2, 0x1

    aget-byte v2, v7, v2

    and-int/lit16 v2, v2, 0xff

    if-le v2, p2, :cond_3

    move v2, v1

    goto :goto_5

    :cond_3
    move v2, v0

    :goto_5
    int-to-byte v2, v2

    aput-byte v2, v5, v3

    add-int/lit8 v4, v4, -0x1

    move v3, v6

    move v2, v8

    goto :goto_4

    :cond_4
    add-int/lit8 p3, p3, 0x1

    goto :goto_3

    :cond_5
    return-object p1
.end method
