.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;
.super Ljava/lang/Object;
.source "ConvertInterleavedToSingle.java"


# direct methods
.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 10

    .line 399
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_0

    move v0, v2

    .line 402
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_7

    .line 403
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 404
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 405
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    move v0, v2

    .line 409
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 410
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 411
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 412
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_2
    if-ge v4, v5, :cond_1

    .line 416
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    add-int/lit8 v7, v3, 0x1

    aget v8, v6, v3

    add-int/2addr v3, v1

    .line 417
    aget v6, v6, v7

    add-float/2addr v8, v6

    .line 418
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v7, v4, 0x1

    const/high16 v9, 0x40000000    # 2.0f

    div-float/2addr v8, v9

    aput v8, v6, v4

    move v4, v7

    goto :goto_2

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_4

    move v0, v2

    .line 424
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 425
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 426
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 427
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_4
    if-ge v4, v5, :cond_3

    .line 431
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    add-int/lit8 v7, v3, 0x1

    aget v8, v6, v3

    add-int/lit8 v9, v3, 0x2

    .line 432
    aget v7, v6, v7

    add-float/2addr v8, v7

    add-int/2addr v3, v1

    .line 433
    aget v6, v6, v9

    add-float/2addr v8, v6

    .line 434
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v7, v4, 0x1

    const/high16 v9, 0x40400000    # 3.0f

    div-float/2addr v8, v9

    aput v8, v6, v4

    move v4, v7

    goto :goto_4

    :cond_3
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_4
    move v1, v2

    .line 440
    :goto_5
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v3, :cond_7

    .line 441
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 442
    invoke-virtual {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v2

    .line 444
    :goto_6
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_6

    add-int v6, v3, v0

    const/4 v7, 0x0

    :goto_7
    if-ge v3, v6, :cond_5

    .line 448
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    add-int/lit8 v9, v3, 0x1

    aget v3, v8, v3

    add-float/2addr v7, v3

    move v3, v9

    goto :goto_7

    .line 450
    :cond_5
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v8, v4, 0x1

    int-to-float v9, v0

    div-float/2addr v7, v9

    aput v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v8

    goto :goto_6

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_7
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V
    .locals 13

    .line 458
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_0

    move v0, v2

    .line 461
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_7

    .line 462
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 463
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 464
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    move v0, v2

    .line 468
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 469
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 470
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 471
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_2
    if-ge v4, v5, :cond_1

    .line 475
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    add-int/lit8 v7, v3, 0x1

    aget-wide v8, v6, v3

    add-int/2addr v3, v1

    .line 476
    aget-wide v10, v6, v7

    add-double/2addr v8, v10

    .line 477
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v7, v4, 0x1

    const-wide/high16 v10, 0x4000000000000000L    # 2.0

    div-double/2addr v8, v10

    aput-wide v8, v6, v4

    move v4, v7

    goto :goto_2

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_4

    move v0, v2

    .line 483
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 484
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 485
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 486
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_4
    if-ge v4, v5, :cond_3

    .line 490
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    add-int/lit8 v7, v3, 0x1

    aget-wide v8, v6, v3

    add-int/lit8 v10, v3, 0x2

    .line 491
    aget-wide v11, v6, v7

    add-double/2addr v8, v11

    add-int/2addr v3, v1

    .line 492
    aget-wide v10, v6, v10

    add-double/2addr v8, v10

    .line 493
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v7, v4, 0x1

    const-wide/high16 v10, 0x4008000000000000L    # 3.0

    div-double/2addr v8, v10

    aput-wide v8, v6, v4

    move v4, v7

    goto :goto_4

    :cond_3
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_4
    move v1, v2

    .line 499
    :goto_5
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v3, :cond_7

    .line 500
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 501
    invoke-virtual {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v2

    .line 503
    :goto_6
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_6

    add-int v6, v3, v0

    const-wide/16 v7, 0x0

    :goto_7
    if-ge v3, v6, :cond_5

    .line 507
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    add-int/lit8 v10, v3, 0x1

    aget-wide v11, v9, v3

    add-double/2addr v7, v11

    move v3, v10

    goto :goto_7

    .line 509
    :cond_5
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v9, v4, 0x1

    int-to-double v10, v0

    div-double/2addr v7, v10

    aput-wide v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v9

    goto :goto_6

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_7
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V
    .locals 10

    .line 222
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_0

    move v0, v2

    .line 225
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_7

    .line 226
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 227
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 228
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    move v0, v2

    .line 232
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 233
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 234
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 235
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_2
    if-ge v4, v5, :cond_1

    .line 239
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v7, v3, 0x1

    aget-short v8, v6, v3

    add-int/2addr v3, v1

    .line 240
    aget-short v6, v6, v7

    add-int/2addr v8, v6

    .line 241
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v7, v4, 0x1

    div-int/2addr v8, v1

    int-to-short v8, v8

    aput-short v8, v6, v4

    move v4, v7

    goto :goto_2

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_4

    move v0, v2

    .line 247
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 248
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 249
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 250
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_4
    if-ge v4, v5, :cond_3

    .line 254
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v7, v3, 0x1

    aget-short v8, v6, v3

    add-int/lit8 v9, v3, 0x2

    .line 255
    aget-short v7, v6, v7

    add-int/2addr v8, v7

    add-int/2addr v3, v1

    .line 256
    aget-short v6, v6, v9

    add-int/2addr v8, v6

    .line 257
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v7, v4, 0x1

    div-int/2addr v8, v1

    int-to-short v8, v8

    aput-short v8, v6, v4

    move v4, v7

    goto :goto_4

    :cond_3
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_4
    move v1, v2

    .line 263
    :goto_5
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v3, :cond_7

    .line 264
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 265
    invoke-virtual {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v2

    .line 267
    :goto_6
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_6

    add-int v6, v3, v0

    move v7, v2

    :goto_7
    if-ge v3, v6, :cond_5

    .line 271
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v9, v3, 0x1

    aget-short v3, v8, v3

    add-int/2addr v7, v3

    move v3, v9

    goto :goto_7

    .line 273
    :cond_5
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v4, 0x1

    div-int/2addr v7, v0

    int-to-short v7, v7

    aput-short v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v8

    goto :goto_6

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_7
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V
    .locals 10

    .line 281
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_0

    move v0, v2

    .line 284
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_7

    .line 285
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 286
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 287
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    move v0, v2

    .line 291
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 292
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 293
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 294
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_2
    if-ge v4, v5, :cond_1

    .line 298
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    add-int/lit8 v7, v3, 0x1

    aget v8, v6, v3

    add-int/2addr v3, v1

    .line 299
    aget v6, v6, v7

    add-int/2addr v8, v6

    .line 300
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v7, v4, 0x1

    div-int/2addr v8, v1

    aput v8, v6, v4

    move v4, v7

    goto :goto_2

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_4

    move v0, v2

    .line 306
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 307
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 308
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 309
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_4
    if-ge v4, v5, :cond_3

    .line 313
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    add-int/lit8 v7, v3, 0x1

    aget v8, v6, v3

    add-int/lit8 v9, v3, 0x2

    .line 314
    aget v7, v6, v7

    add-int/2addr v8, v7

    add-int/2addr v3, v1

    .line 315
    aget v6, v6, v9

    add-int/2addr v8, v6

    .line 316
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v7, v4, 0x1

    div-int/2addr v8, v1

    aput v8, v6, v4

    move v4, v7

    goto :goto_4

    :cond_3
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_4
    move v1, v2

    .line 322
    :goto_5
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v3, :cond_7

    .line 323
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 324
    invoke-virtual {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v2

    .line 326
    :goto_6
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_6

    add-int v6, v3, v0

    move v7, v2

    :goto_7
    if-ge v3, v6, :cond_5

    .line 330
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    add-int/lit8 v9, v3, 0x1

    aget v3, v8, v3

    add-int/2addr v7, v3

    move v3, v9

    goto :goto_7

    .line 332
    :cond_5
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v8, v4, 0x1

    div-int/2addr v7, v0

    aput v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v8

    goto :goto_6

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_7
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V
    .locals 13

    .line 340
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_0

    move v0, v2

    .line 343
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_7

    .line 344
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 345
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 346
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    move v0, v2

    .line 350
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 351
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 352
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 353
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_2
    if-ge v4, v5, :cond_1

    .line 357
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    add-int/lit8 v7, v3, 0x1

    aget-wide v8, v6, v3

    add-int/2addr v3, v1

    .line 358
    aget-wide v10, v6, v7

    add-long/2addr v8, v10

    .line 359
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v7, v4, 0x1

    const-wide/16 v10, 0x2

    div-long/2addr v8, v10

    aput-wide v8, v6, v4

    move v4, v7

    goto :goto_2

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_4

    move v0, v2

    .line 365
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 366
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 367
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 368
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_4
    if-ge v4, v5, :cond_3

    .line 372
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    add-int/lit8 v7, v3, 0x1

    aget-wide v8, v6, v3

    add-int/lit8 v10, v3, 0x2

    .line 373
    aget-wide v11, v6, v7

    add-long/2addr v8, v11

    add-int/2addr v3, v1

    .line 374
    aget-wide v10, v6, v10

    add-long/2addr v8, v10

    .line 375
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v7, v4, 0x1

    const-wide/16 v10, 0x3

    div-long/2addr v8, v10

    aput-wide v8, v6, v4

    move v4, v7

    goto :goto_4

    :cond_3
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_4
    move v1, v2

    .line 381
    :goto_5
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v3, :cond_7

    .line 382
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 383
    invoke-virtual {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v2

    .line 385
    :goto_6
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_6

    add-int v6, v3, v0

    const-wide/16 v7, 0x0

    :goto_7
    if-ge v3, v6, :cond_5

    .line 389
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    add-int/lit8 v10, v3, 0x1

    aget-wide v11, v9, v3

    add-long/2addr v7, v11

    move v3, v10

    goto :goto_7

    .line 391
    :cond_5
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v9, v4, 0x1

    int-to-long v10, v0

    div-long/2addr v7, v10

    aput-wide v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v9

    goto :goto_6

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_7
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V
    .locals 10

    .line 104
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_0

    move v0, v2

    .line 107
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_7

    .line 108
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 109
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 110
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    move v0, v2

    .line 114
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 115
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 116
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 117
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_2
    if-ge v4, v5, :cond_1

    .line 121
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v7, v3, 0x1

    aget-byte v8, v6, v3

    add-int/2addr v3, v1

    .line 122
    aget-byte v6, v6, v7

    add-int/2addr v8, v6

    .line 123
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v4, 0x1

    div-int/2addr v8, v1

    int-to-byte v8, v8

    aput-byte v8, v6, v4

    move v4, v7

    goto :goto_2

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_4

    move v0, v2

    .line 129
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 130
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 131
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 132
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_4
    if-ge v4, v5, :cond_3

    .line 136
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v7, v3, 0x1

    aget-byte v8, v6, v3

    add-int/lit8 v9, v3, 0x2

    .line 137
    aget-byte v7, v6, v7

    add-int/2addr v8, v7

    add-int/2addr v3, v1

    .line 138
    aget-byte v6, v6, v9

    add-int/2addr v8, v6

    .line 139
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v4, 0x1

    div-int/2addr v8, v1

    int-to-byte v8, v8

    aput-byte v8, v6, v4

    move v4, v7

    goto :goto_4

    :cond_3
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_4
    move v1, v2

    .line 145
    :goto_5
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v3, :cond_7

    .line 146
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 147
    invoke-virtual {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v2

    .line 149
    :goto_6
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_6

    add-int v6, v3, v0

    move v7, v2

    :goto_7
    if-ge v3, v6, :cond_5

    .line 153
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v9, v3, 0x1

    aget-byte v3, v8, v3

    add-int/2addr v7, v3

    move v3, v9

    goto :goto_7

    .line 155
    :cond_5
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v8, v4, 0x1

    div-int/2addr v7, v0

    int-to-byte v7, v7

    aput-byte v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v8

    goto :goto_6

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_7
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V
    .locals 11

    .line 163
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_0

    move v0, v2

    .line 166
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_7

    .line 167
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 168
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 169
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x2

    const v3, 0xffff

    if-ne v0, v1, :cond_2

    move v0, v2

    .line 173
    :goto_1
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v4, :cond_7

    .line 174
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v4

    .line 175
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v5

    .line 176
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v6, v5

    :goto_2
    if-ge v5, v6, :cond_1

    .line 180
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v8, v4, 0x1

    aget-short v9, v7, v4

    and-int/2addr v9, v3

    add-int/2addr v4, v1

    .line 181
    aget-short v7, v7, v8

    and-int/2addr v7, v3

    add-int/2addr v9, v7

    .line 182
    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v5, 0x1

    div-int/2addr v9, v1

    int-to-short v9, v9

    aput-short v9, v7, v5

    move v5, v8

    goto :goto_2

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_4

    move v0, v2

    .line 188
    :goto_3
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v4, :cond_7

    .line 189
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v4

    .line 190
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v5

    .line 191
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v6, v5

    :goto_4
    if-ge v5, v6, :cond_3

    .line 195
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v8, v4, 0x1

    aget-short v9, v7, v4

    and-int/2addr v9, v3

    add-int/lit8 v10, v4, 0x2

    .line 196
    aget-short v8, v7, v8

    and-int/2addr v8, v3

    add-int/2addr v9, v8

    add-int/2addr v4, v1

    .line 197
    aget-short v7, v7, v10

    and-int/2addr v7, v3

    add-int/2addr v9, v7

    .line 198
    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v5, 0x1

    div-int/2addr v9, v1

    int-to-short v9, v9

    aput-short v9, v7, v5

    move v5, v8

    goto :goto_4

    :cond_3
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_4
    move v1, v2

    .line 204
    :goto_5
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v4, :cond_7

    .line 205
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v4

    .line 206
    invoke-virtual {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v5

    move v6, v2

    .line 208
    :goto_6
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v6, v7, :cond_6

    add-int v7, v4, v0

    move v8, v2

    :goto_7
    if-ge v4, v7, :cond_5

    .line 212
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v10, v4, 0x1

    aget-short v4, v9, v4

    and-int/2addr v4, v3

    add-int/2addr v8, v4

    move v4, v10

    goto :goto_7

    .line 214
    :cond_5
    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v9, v5, 0x1

    div-int/2addr v8, v0

    int-to-short v8, v8

    aput-short v8, v7, v5

    add-int/lit8 v6, v6, 0x1

    move v5, v9

    goto :goto_6

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_7
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 10

    .line 45
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_0

    move v0, v2

    .line 48
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_7

    .line 49
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 50
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 51
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    move v0, v2

    .line 55
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 56
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 57
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 58
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_2
    if-ge v4, v5, :cond_1

    .line 62
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v7, v3, 0x1

    aget-byte v8, v6, v3

    and-int/lit16 v8, v8, 0xff

    add-int/2addr v3, v1

    .line 63
    aget-byte v6, v6, v7

    and-int/lit16 v6, v6, 0xff

    add-int/2addr v8, v6

    .line 64
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v4, 0x1

    div-int/2addr v8, v1

    int-to-byte v8, v8

    aput-byte v8, v6, v4

    move v4, v7

    goto :goto_2

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_4

    move v0, v2

    .line 70
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_7

    .line 71
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 72
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    .line 73
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v5, v4

    :goto_4
    if-ge v4, v5, :cond_3

    .line 77
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v7, v3, 0x1

    aget-byte v8, v6, v3

    and-int/lit16 v8, v8, 0xff

    add-int/lit8 v9, v3, 0x2

    .line 78
    aget-byte v7, v6, v7

    and-int/lit16 v7, v7, 0xff

    add-int/2addr v8, v7

    add-int/2addr v3, v1

    .line 79
    aget-byte v6, v6, v9

    and-int/lit16 v6, v6, 0xff

    add-int/2addr v8, v6

    .line 80
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v4, 0x1

    div-int/2addr v8, v1

    int-to-byte v8, v8

    aput-byte v8, v6, v4

    move v4, v7

    goto :goto_4

    :cond_3
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_4
    move v1, v2

    .line 86
    :goto_5
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v1, v3, :cond_7

    .line 87
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v3

    .line 88
    invoke-virtual {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v2

    .line 90
    :goto_6
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_6

    add-int v6, v3, v0

    move v7, v2

    :goto_7
    if-ge v3, v6, :cond_5

    .line 94
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v9, v3, 0x1

    aget-byte v3, v8, v3

    and-int/lit16 v3, v3, 0xff

    add-int/2addr v7, v3

    move v3, v9

    goto :goto_7

    .line 96
    :cond_5
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v8, v4, 0x1

    div-int/2addr v7, v0

    int-to-byte v7, v7

    aput-byte v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v8

    goto :goto_6

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_7
    return-void
.end method
