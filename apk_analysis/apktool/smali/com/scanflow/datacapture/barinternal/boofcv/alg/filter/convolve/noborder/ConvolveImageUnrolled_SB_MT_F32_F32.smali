.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;
.super Ljava/lang/Object;
.source "ConvolveImageUnrolled_SB_MT_F32_F32.java"


# direct methods
.method public static synthetic $r8$lambda$1Me8OYqTdPI6FrNFMs4HDsGJO3Q(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFFFFFFFF[FI)V
    .locals 4

    .line 487
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p17

    add-int/2addr v0, p0

    .line 488
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int p2, p17, p2

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr p0, p2

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 494
    aget p2, p4, p0

    mul-float/2addr p2, p5

    .line 495
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v2, p0, v1

    .line 496
    aget v3, p4, v2

    mul-float/2addr v3, p6

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 498
    aget v3, p4, v2

    mul-float/2addr v3, p7

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 500
    aget v3, p4, v2

    mul-float/2addr v3, p8

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 502
    aget v3, p4, v2

    mul-float/2addr v3, p9

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 504
    aget v3, p4, v2

    mul-float/2addr v3, p10

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 506
    aget v3, p4, v2

    mul-float/2addr v3, p11

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 508
    aget v3, p4, v2

    mul-float v3, v3, p12

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 510
    aget v3, p4, v2

    mul-float v3, v3, p13

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 512
    aget v3, p4, v2

    mul-float v3, v3, p14

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 514
    aget v1, p4, v2

    mul-float v1, v1, p15

    add-float/2addr p2, v1

    add-int/lit8 v1, v0, 0x1

    .line 516
    aput p2, p16, v0

    add-int/lit8 p0, p0, 0x1

    move v0, v1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$7JpHUCzKp7YkofpSyQPtKZ1lDa0(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFF[FI)V
    .locals 1

    .line 115
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p9

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 116
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p9, p2

    add-int/2addr p0, p9

    sub-int/2addr p0, p1

    add-int/2addr p3, p0

    sub-int/2addr p3, p1

    add-int/2addr p0, p1

    :goto_0
    if-ge p0, p3, :cond_0

    add-int/lit8 p1, p0, 0x1

    .line 121
    aget p2, p4, p0

    mul-float/2addr p2, p5

    add-int/lit8 p0, p0, 0x2

    .line 122
    aget p9, p4, p1

    mul-float/2addr p9, p6

    add-float/2addr p2, p9

    .line 123
    aget p0, p4, p0

    mul-float/2addr p0, p7

    add-float/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    .line 125
    aput p2, p8, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$CpC7dBhcFaaATRRq8rXopYigAIY(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFFFFFF[FI)V
    .locals 4

    .line 432
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p15

    add-int/2addr v0, p0

    .line 433
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int p2, p15, p2

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr p0, p2

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 439
    aget p2, p4, p0

    mul-float/2addr p2, p5

    .line 440
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v2, p0, v1

    .line 441
    aget v3, p4, v2

    mul-float/2addr v3, p6

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 443
    aget v3, p4, v2

    mul-float/2addr v3, p7

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 445
    aget v3, p4, v2

    mul-float/2addr v3, p8

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 447
    aget v3, p4, v2

    mul-float/2addr v3, p9

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 449
    aget v3, p4, v2

    mul-float/2addr v3, p10

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 451
    aget v3, p4, v2

    mul-float/2addr v3, p11

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 453
    aget v3, p4, v2

    mul-float v3, v3, p12

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 455
    aget v1, p4, v2

    mul-float v1, v1, p13

    add-float/2addr p2, v1

    add-int/lit8 v1, v0, 0x1

    .line 457
    aput p2, p14, v0

    add-int/lit8 p0, p0, 0x1

    move v0, v1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$MpQFEUsSsJ8rSDcZMq_Hl-RHqTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFFFF[FI)V
    .locals 4

    .line 383
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p13

    add-int/2addr v0, p0

    .line 384
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int p2, p13, p2

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr p0, p2

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 390
    aget p2, p4, p0

    mul-float/2addr p2, p5

    .line 391
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v2, p0, v1

    .line 392
    aget v3, p4, v2

    mul-float/2addr v3, p6

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 394
    aget v3, p4, v2

    mul-float/2addr v3, p7

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 396
    aget v3, p4, v2

    mul-float/2addr v3, p8

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 398
    aget v3, p4, v2

    mul-float/2addr v3, p9

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 400
    aget v3, p4, v2

    mul-float/2addr v3, p10

    add-float/2addr p2, v3

    add-int/2addr v2, v1

    .line 402
    aget v1, p4, v2

    mul-float/2addr v1, p11

    add-float/2addr p2, v1

    add-int/lit8 v1, v0, 0x1

    .line 404
    aput p2, p12, v0

    add-int/lit8 p0, p0, 0x1

    move v0, v1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$QLr8atkEz95sTfymUgMqDlkX5E8(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFFFFFFFF[FI)V
    .locals 3

    .line 220
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p15

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 221
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p2, p2, p15

    add-int/2addr p0, p2

    sub-int/2addr p0, p1

    add-int/2addr p3, p0

    sub-int/2addr p3, p1

    add-int/2addr p0, p1

    :goto_0
    if-ge p0, p3, :cond_0

    add-int/lit8 p1, p0, 0x1

    .line 226
    aget p2, p4, p0

    mul-float/2addr p2, p5

    add-int/lit8 v1, p0, 0x2

    .line 227
    aget v2, p4, p1

    mul-float/2addr v2, p6

    add-float/2addr p2, v2

    add-int/lit8 v2, p0, 0x3

    .line 228
    aget v1, p4, v1

    mul-float/2addr v1, p7

    add-float/2addr p2, v1

    add-int/lit8 v1, p0, 0x4

    .line 229
    aget v2, p4, v2

    mul-float/2addr v2, p8

    add-float/2addr p2, v2

    add-int/lit8 v2, p0, 0x5

    .line 230
    aget v1, p4, v1

    mul-float/2addr v1, p9

    add-float/2addr p2, v1

    add-int/lit8 v1, p0, 0x6

    .line 231
    aget v2, p4, v2

    mul-float/2addr v2, p10

    add-float/2addr p2, v2

    add-int/lit8 v2, p0, 0x7

    .line 232
    aget v1, p4, v1

    mul-float/2addr v1, p11

    add-float/2addr p2, v1

    add-int/lit8 p0, p0, 0x8

    .line 233
    aget v1, p4, v2

    mul-float/2addr v1, p12

    add-float/2addr p2, v1

    .line 234
    aget p0, p4, p0

    mul-float p0, p0, p13

    add-float/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    .line 236
    aput p2, p14, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$WcLprpi05aRbSuN8lgkehHU-oNE(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFF[FI)V
    .locals 3

    .line 340
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p11

    add-int/2addr v0, p0

    .line 341
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int/2addr p11, p2

    iget p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p11, p2

    add-int/2addr p0, p11

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 347
    aget p2, p4, p0

    mul-float/2addr p2, p5

    .line 348
    iget p11, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v1, p0, p11

    .line 349
    aget v2, p4, v1

    mul-float/2addr v2, p6

    add-float/2addr p2, v2

    add-int/2addr v1, p11

    .line 351
    aget v2, p4, v1

    mul-float/2addr v2, p7

    add-float/2addr p2, v2

    add-int/2addr v1, p11

    .line 353
    aget v2, p4, v1

    mul-float/2addr v2, p8

    add-float/2addr p2, v2

    add-int/2addr v1, p11

    .line 355
    aget p11, p4, v1

    mul-float/2addr p11, p9

    add-float/2addr p2, p11

    add-int/lit8 p11, v0, 0x1

    .line 357
    aput p2, p10, v0

    add-int/lit8 p0, p0, 0x1

    move v0, p11

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$a0Q9zkzyELA7gxbyMdBKqs6YoMg(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFFFFFF[FI)V
    .locals 2

    .line 181
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p13

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 182
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p13, p2

    add-int/2addr p0, p13

    sub-int/2addr p0, p1

    add-int/2addr p3, p0

    sub-int/2addr p3, p1

    add-int/2addr p0, p1

    :goto_0
    if-ge p0, p3, :cond_0

    add-int/lit8 p1, p0, 0x1

    .line 187
    aget p2, p4, p0

    mul-float/2addr p2, p5

    add-int/lit8 p13, p0, 0x2

    .line 188
    aget v1, p4, p1

    mul-float/2addr v1, p6

    add-float/2addr p2, v1

    add-int/lit8 v1, p0, 0x3

    .line 189
    aget p13, p4, p13

    mul-float/2addr p13, p7

    add-float/2addr p2, p13

    add-int/lit8 p13, p0, 0x4

    .line 190
    aget v1, p4, v1

    mul-float/2addr v1, p8

    add-float/2addr p2, v1

    add-int/lit8 v1, p0, 0x5

    .line 191
    aget p13, p4, p13

    mul-float/2addr p13, p9

    add-float/2addr p2, p13

    add-int/lit8 p0, p0, 0x6

    .line 192
    aget p13, p4, v1

    mul-float/2addr p13, p10

    add-float/2addr p2, p13

    .line 193
    aget p0, p4, p0

    mul-float/2addr p0, p11

    add-float/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    .line 195
    aput p2, p12, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$hqv83tTs6_GwgzZly0zQz8nKI8Y(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFF[FI)V
    .locals 3

    .line 303
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p9

    add-int/2addr v0, p0

    .line 304
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int/2addr p9, p2

    iget p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p9, p2

    add-int/2addr p0, p9

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 310
    aget p2, p4, p0

    mul-float/2addr p2, p5

    .line 311
    iget p9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v1, p0, p9

    .line 312
    aget v2, p4, v1

    mul-float/2addr v2, p6

    add-float/2addr p2, v2

    add-int/2addr v1, p9

    .line 314
    aget p9, p4, v1

    mul-float/2addr p9, p7

    add-float/2addr p2, p9

    add-int/lit8 p9, v0, 0x1

    .line 316
    aput p2, p8, v0

    add-int/lit8 p0, p0, 0x1

    move v0, p9

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$iEbXn3Oz2NfvK94P5muRbmbu24U(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFFFFFFFFFF[FI)V
    .locals 3

    .line 263
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p17

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 264
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p2, p2, p17

    add-int/2addr p0, p2

    sub-int/2addr p0, p1

    add-int/2addr p3, p0

    sub-int/2addr p3, p1

    add-int/2addr p0, p1

    :goto_0
    if-ge p0, p3, :cond_0

    add-int/lit8 p1, p0, 0x1

    .line 269
    aget p2, p4, p0

    mul-float/2addr p2, p5

    add-int/lit8 v1, p0, 0x2

    .line 270
    aget v2, p4, p1

    mul-float/2addr v2, p6

    add-float/2addr p2, v2

    add-int/lit8 v2, p0, 0x3

    .line 271
    aget v1, p4, v1

    mul-float/2addr v1, p7

    add-float/2addr p2, v1

    add-int/lit8 v1, p0, 0x4

    .line 272
    aget v2, p4, v2

    mul-float/2addr v2, p8

    add-float/2addr p2, v2

    add-int/lit8 v2, p0, 0x5

    .line 273
    aget v1, p4, v1

    mul-float/2addr v1, p9

    add-float/2addr p2, v1

    add-int/lit8 v1, p0, 0x6

    .line 274
    aget v2, p4, v2

    mul-float/2addr v2, p10

    add-float/2addr p2, v2

    add-int/lit8 v2, p0, 0x7

    .line 275
    aget v1, p4, v1

    mul-float/2addr v1, p11

    add-float/2addr p2, v1

    add-int/lit8 v1, p0, 0x8

    .line 276
    aget v2, p4, v2

    mul-float/2addr v2, p12

    add-float/2addr p2, v2

    add-int/lit8 v2, p0, 0x9

    .line 277
    aget v1, p4, v1

    mul-float v1, v1, p13

    add-float/2addr p2, v1

    add-int/lit8 p0, p0, 0xa

    .line 278
    aget v1, p4, v2

    mul-float v1, v1, p14

    add-float/2addr p2, v1

    .line 279
    aget p0, p4, p0

    mul-float p0, p0, p15

    add-float/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    .line 281
    aput p2, p16, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$vt-rBrxEiB-uEOdZHM-Q1KKKTDE(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFFFF[FI)V
    .locals 2

    .line 146
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p11

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 147
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p11, p2

    add-int/2addr p0, p11

    sub-int/2addr p0, p1

    add-int/2addr p3, p0

    sub-int/2addr p3, p1

    add-int/2addr p0, p1

    :goto_0
    if-ge p0, p3, :cond_0

    add-int/lit8 p1, p0, 0x1

    .line 152
    aget p2, p4, p0

    mul-float/2addr p2, p5

    add-int/lit8 p11, p0, 0x2

    .line 153
    aget v1, p4, p1

    mul-float/2addr v1, p6

    add-float/2addr p2, v1

    add-int/lit8 v1, p0, 0x3

    .line 154
    aget p11, p4, p11

    mul-float/2addr p11, p7

    add-float/2addr p2, p11

    add-int/lit8 p0, p0, 0x4

    .line 155
    aget p11, p4, v1

    mul-float/2addr p11, p8

    add-float/2addr p2, p11

    .line 156
    aget p0, p4, p0

    mul-float/2addr p0, p9

    add-float/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    .line 158
    aput p2, p10, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Z
    .locals 4

    .line 51
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    div-int/lit8 v2, v1, 0x2

    const/4 v3, 0x0

    if-ne v0, v2, :cond_6

    rem-int/lit8 v0, v1, 0x2

    if-nez v0, :cond_0

    goto :goto_1

    :cond_0
    const/4 v0, 0x3

    if-eq v1, v0, :cond_5

    const/4 v0, 0x5

    if-eq v1, v0, :cond_4

    const/4 v0, 0x7

    if-eq v1, v0, :cond_3

    const/16 v0, 0x9

    if-eq v1, v0, :cond_2

    const/16 v0, 0xb

    if-eq v1, v0, :cond_1

    return v3

    .line 59
    :cond_1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->horizontal11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 58
    :cond_2
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->horizontal9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 57
    :cond_3
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->horizontal7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 56
    :cond_4
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->horizontal5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 55
    :cond_5
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->horizontal3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    :goto_0
    const/4 p0, 0x1

    return p0

    :cond_6
    :goto_1
    return v3
.end method

.method public static horizontal11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 21

    move-object/from16 v3, p1

    .line 243
    iget-object v5, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v1, p2

    .line 244
    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v2, p0

    .line 246
    iget-object v4, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    move v7, v6

    aget v6, v4, v7

    const/4 v8, 0x1

    .line 247
    aget v8, v4, v8

    const/4 v9, 0x2

    .line 248
    aget v9, v4, v9

    const/4 v10, 0x3

    .line 249
    aget v10, v4, v10

    const/4 v11, 0x4

    .line 250
    aget v11, v4, v11

    const/4 v12, 0x5

    .line 251
    aget v12, v4, v12

    const/4 v13, 0x6

    .line 252
    aget v13, v4, v13

    const/4 v14, 0x7

    .line 253
    aget v14, v4, v14

    const/16 v15, 0x8

    .line 254
    aget v15, v4, v15

    const/16 v16, 0x9

    .line 255
    aget v16, v4, v16

    const/16 v17, 0xa

    .line 256
    aget v4, v4, v17

    .line 258
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    move/from16 v17, v7

    move v7, v8

    move v8, v9

    move v9, v10

    move v10, v11

    move v11, v12

    move v12, v13

    move v13, v14

    move v14, v15

    move/from16 v15, v16

    move/from16 v16, v4

    .line 260
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    move-object/from16 v18, v0

    .line 262
    iget v0, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    move/from16 v19, v0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda3;

    move-object/from16 v17, v18

    move/from16 v20, v19

    invoke-direct/range {v0 .. v17}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFFFFFFFFFF[F)V

    move-object v1, v0

    move/from16 v0, v20

    const/4 v7, 0x0

    invoke-static {v7, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 11

    .line 103
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 104
    iget-object v9, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 106
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v10, 0x0

    aget v6, v0, v10

    const/4 v1, 0x1

    .line 107
    aget v7, v0, v1

    const/4 v1, 0x2

    .line 108
    aget v8, v0, v1

    .line 110
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    .line 112
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 114
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda1;

    move-object v3, p1

    move-object v1, p2

    invoke-direct/range {v0 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFF[F)V

    invoke-static {v10, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 13

    .line 132
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 133
    iget-object v11, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 135
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v12, 0x0

    aget v6, v0, v12

    const/4 v1, 0x1

    .line 136
    aget v7, v0, v1

    const/4 v1, 0x2

    .line 137
    aget v8, v0, v1

    const/4 v1, 0x3

    .line 138
    aget v9, v0, v1

    const/4 v1, 0x4

    .line 139
    aget v10, v0, v1

    .line 141
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    .line 143
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 145
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda4;

    move-object v3, p1

    move-object v1, p2

    invoke-direct/range {v0 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFFFF[F)V

    invoke-static {v12, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 16

    move-object/from16 v3, p1

    .line 165
    iget-object v5, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v1, p2

    .line 166
    iget-object v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v0, p0

    .line 168
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v14, 0x0

    aget v6, v2, v14

    const/4 v4, 0x1

    .line 169
    aget v7, v2, v4

    const/4 v4, 0x2

    .line 170
    aget v8, v2, v4

    const/4 v4, 0x3

    .line 171
    aget v9, v2, v4

    const/4 v4, 0x4

    .line 172
    aget v10, v2, v4

    const/4 v4, 0x5

    .line 173
    aget v11, v2, v4

    const/4 v4, 0x6

    .line 174
    aget v12, v2, v4

    .line 176
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    .line 178
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 180
    iget v15, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda8;

    invoke-direct/range {v0 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda8;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFFFFFF[F)V

    invoke-static {v14, v15, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 18

    move-object/from16 v3, p1

    .line 202
    iget-object v5, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v1, p2

    .line 203
    iget-object v15, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v0, p0

    .line 205
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v4, 0x0

    aget v6, v2, v4

    const/4 v7, 0x1

    .line 206
    aget v7, v2, v7

    const/4 v8, 0x2

    .line 207
    aget v8, v2, v8

    const/4 v9, 0x3

    .line 208
    aget v9, v2, v9

    const/4 v10, 0x4

    .line 209
    aget v10, v2, v10

    const/4 v11, 0x5

    .line 210
    aget v11, v2, v11

    const/4 v12, 0x6

    .line 211
    aget v12, v2, v12

    const/4 v13, 0x7

    .line 212
    aget v13, v2, v13

    const/16 v14, 0x8

    .line 213
    aget v14, v2, v14

    .line 215
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    move v0, v4

    .line 217
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 219
    iget v0, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    move/from16 v16, v0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda6;

    move/from16 v17, v16

    invoke-direct/range {v0 .. v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda6;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[FFFFFFFFFF[F)V

    move-object v1, v0

    move/from16 v0, v17

    const/4 v2, 0x0

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Z
    .locals 4

    .line 69
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    div-int/lit8 v2, v1, 0x2

    const/4 v3, 0x0

    if-ne v0, v2, :cond_6

    rem-int/lit8 v0, v1, 0x2

    if-nez v0, :cond_0

    goto :goto_1

    :cond_0
    const/4 v0, 0x3

    if-eq v1, v0, :cond_5

    const/4 v0, 0x5

    if-eq v1, v0, :cond_4

    const/4 v0, 0x7

    if-eq v1, v0, :cond_3

    const/16 v0, 0x9

    if-eq v1, v0, :cond_2

    const/16 v0, 0xb

    if-eq v1, v0, :cond_1

    return v3

    .line 77
    :cond_1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->vertical11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 76
    :cond_2
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->vertical9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 75
    :cond_3
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->vertical7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 74
    :cond_4
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->vertical5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 73
    :cond_5
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->vertical3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    :goto_0
    const/4 p0, 0x1

    return p0

    :cond_6
    :goto_1
    return v3
.end method

.method public static vertical11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 20

    move-object/from16 v2, p1

    .line 464
    iget-object v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v1, p2

    .line 465
    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v3, p0

    .line 467
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v6, v4, v6

    const/4 v7, 0x1

    .line 468
    aget v7, v4, v7

    const/4 v8, 0x2

    .line 469
    aget v8, v4, v8

    const/4 v9, 0x3

    .line 470
    aget v9, v4, v9

    const/4 v10, 0x4

    .line 471
    aget v10, v4, v10

    const/4 v11, 0x5

    .line 472
    aget v11, v4, v11

    const/4 v12, 0x6

    .line 473
    aget v12, v4, v12

    const/4 v13, 0x7

    .line 474
    aget v13, v4, v13

    const/16 v14, 0x8

    .line 475
    aget v14, v4, v14

    const/16 v15, 0x9

    .line 476
    aget v15, v4, v15

    const/16 v16, 0xa

    .line 477
    aget v16, v4, v16

    .line 479
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 481
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 482
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v17

    move-object/from16 v18, v0

    sub-int v0, v17, v3

    move/from16 v17, v0

    .line 486
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda7;

    move/from16 v19, v17

    move-object/from16 v17, v18

    invoke-direct/range {v0 .. v17}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda7;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFFFFFFFF[F)V

    move-object v1, v0

    move/from16 v0, v19

    invoke-static {v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 10

    .line 288
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 289
    iget-object v9, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 291
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v1, 0x0

    aget v6, v0, v1

    const/4 v1, 0x1

    .line 292
    aget v7, v0, v1

    const/4 v1, 0x2

    .line 293
    aget v8, v0, v1

    .line 295
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 297
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 298
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p0

    sub-int/2addr p0, v3

    .line 302
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda2;

    move-object v2, p1

    move-object v1, p2

    invoke-direct/range {v0 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFF[F)V

    invoke-static {v3, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 12

    .line 323
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 324
    iget-object v11, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 326
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v1, 0x0

    aget v6, v0, v1

    const/4 v1, 0x1

    .line 327
    aget v7, v0, v1

    const/4 v1, 0x2

    .line 328
    aget v8, v0, v1

    const/4 v1, 0x3

    .line 329
    aget v9, v0, v1

    const/4 v1, 0x4

    .line 330
    aget v10, v0, v1

    .line 332
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 334
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 335
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p0

    sub-int/2addr p0, v3

    .line 339
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;

    move-object v2, p1

    move-object v1, p2

    invoke-direct/range {v0 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFF[F)V

    invoke-static {v3, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 14

    .line 364
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v1, p2

    .line 365
    iget-object v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 367
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v3, 0x0

    aget v6, v0, v3

    const/4 v3, 0x1

    .line 368
    aget v7, v0, v3

    const/4 v3, 0x2

    .line 369
    aget v8, v0, v3

    const/4 v3, 0x3

    .line 370
    aget v9, v0, v3

    const/4 v3, 0x4

    .line 371
    aget v10, v0, v3

    const/4 v3, 0x5

    .line 372
    aget v11, v0, v3

    const/4 v3, 0x6

    .line 373
    aget v12, v0, v3

    .line 375
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 377
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 378
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p0

    sub-int/2addr p0, v3

    .line 382
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda5;

    move-object v2, p1

    invoke-direct/range {v0 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFFFF[F)V

    invoke-static {v3, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 18

    move-object/from16 v2, p1

    .line 411
    iget-object v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v1, p2

    .line 412
    iget-object v15, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v0, p0

    .line 414
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v4, 0x0

    aget v6, v3, v4

    const/4 v4, 0x1

    .line 415
    aget v7, v3, v4

    const/4 v4, 0x2

    .line 416
    aget v8, v3, v4

    const/4 v4, 0x3

    .line 417
    aget v9, v3, v4

    const/4 v4, 0x4

    .line 418
    aget v10, v3, v4

    const/4 v4, 0x5

    .line 419
    aget v11, v3, v4

    const/4 v4, 0x6

    .line 420
    aget v12, v3, v4

    const/4 v4, 0x7

    .line 421
    aget v13, v3, v4

    const/16 v4, 0x8

    .line 422
    aget v14, v3, v4

    .line 424
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 426
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 427
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v0

    sub-int/2addr v0, v3

    move/from16 v16, v0

    .line 431
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda0;

    move/from16 v17, v16

    invoke-direct/range {v0 .. v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFFFFFF[F)V

    move-object v1, v0

    move/from16 v0, v17

    invoke-static {v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method
