.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;
.super Ljava/lang/Object;
.source "ConvolveImageUnrolled_SB_MT_U8_I8_Div.java"


# direct methods
.method public static synthetic $r8$lambda$25RPMZ8erj4DTB3StAoBuzyxSRM(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIIIII[BIII)V
    .locals 4

    .line 352
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p13

    add-int/2addr v0, p0

    .line 353
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int p2, p13, p2

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr p0, p2

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 359
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    .line 360
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v2, p0, v1

    .line 361
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p6

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 363
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p7

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 365
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p8

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 367
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p9

    add-int/2addr p2, v1

    add-int/lit8 v1, v0, 0x1

    add-int/2addr p2, p11

    .line 369
    div-int p2, p2, p12

    int-to-byte p2, p2

    aput-byte p2, p10, v0

    add-int/lit8 p0, p0, 0x1

    move v0, v1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$3ouIbBuS16mw2RJh3E_tZNJCjcg(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIIIII[BIII)V
    .locals 2

    .line 153
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p13

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 154
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

    .line 159
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    add-int/lit8 p13, p0, 0x2

    .line 160
    aget-byte v1, p4, p1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p6

    add-int/2addr p2, v1

    add-int/lit8 v1, p0, 0x3

    .line 161
    aget-byte p13, p4, p13

    and-int/lit16 p13, p13, 0xff

    mul-int/2addr p13, p7

    add-int/2addr p2, p13

    add-int/lit8 p0, p0, 0x4

    .line 162
    aget-byte p13, p4, v1

    and-int/lit16 p13, p13, 0xff

    mul-int/2addr p13, p8

    add-int/2addr p2, p13

    .line 163
    aget-byte p0, p4, p0

    and-int/lit16 p0, p0, 0xff

    mul-int/2addr p0, p9

    add-int/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    add-int/2addr p2, p11

    .line 165
    div-int/2addr p2, p12

    int-to-byte p2, p2

    aput-byte p2, p10, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$5XdUXYmTzF14KhQONj29ANbrPNs(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIIIIIIIII[BIII)V
    .locals 4

    .line 446
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p17

    add-int/2addr v0, p0

    .line 447
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int p2, p17, p2

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr p0, p2

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 453
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    .line 454
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v2, p0, v1

    .line 455
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p6

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 457
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p7

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 459
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p8

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 461
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p9

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 463
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p10

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 465
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p11

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 467
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int v3, v3, p12

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 469
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int v1, v1, p13

    add-int/2addr p2, v1

    add-int/lit8 v1, v0, 0x1

    add-int p2, p2, p15

    .line 471
    div-int p2, p2, p16

    int-to-byte p2, p2

    aput-byte p2, p14, v0

    add-int/lit8 p0, p0, 0x1

    move v0, v1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$7lkffpuY-a1C_S9-XkBoFsbO1kc(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIIIIIII[BIII)V
    .locals 4

    .line 396
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p15

    add-int/2addr v0, p0

    .line 397
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int p2, p15, p2

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr p0, p2

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 403
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    .line 404
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v2, p0, v1

    .line 405
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p6

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 407
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p7

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 409
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p8

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 411
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p9

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 413
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p10

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 415
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p11

    add-int/2addr p2, v1

    add-int/lit8 v1, v0, 0x1

    add-int p2, p2, p13

    .line 417
    div-int p2, p2, p14

    int-to-byte p2, p2

    aput-byte p2, p12, v0

    add-int/lit8 p0, p0, 0x1

    move v0, v1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$Hhv9YV4cAMD8ZLFjfUjRhnw2Yt8(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIII[BIII)V
    .locals 3

    .line 314
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p11

    add-int/2addr v0, p0

    .line 315
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int/2addr p11, p2

    iget p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p11, p2

    add-int/2addr p0, p11

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 321
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    .line 322
    iget p11, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v1, p0, p11

    .line 323
    aget-byte v2, p4, v1

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p6

    add-int/2addr p2, v2

    add-int/2addr v1, p11

    .line 325
    aget-byte p11, p4, v1

    and-int/lit16 p11, p11, 0xff

    mul-int/2addr p11, p7

    add-int/2addr p2, p11

    add-int/lit8 p11, v0, 0x1

    add-int/2addr p2, p9

    .line 327
    div-int/2addr p2, p10

    int-to-byte p2, p2

    aput-byte p2, p8, v0

    add-int/lit8 p0, p0, 0x1

    move v0, p11

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$KtcFaVQd_7KwOCRyxcnUft9MOas(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIIIIIIIIIII[BIII)V
    .locals 4

    .line 502
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p19

    add-int/2addr v0, p0

    .line 503
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int p2, p19, p2

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr p0, p2

    add-int/2addr p3, p0

    :goto_0
    if-ge p0, p3, :cond_0

    .line 509
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    .line 510
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v2, p0, v1

    .line 511
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p6

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 513
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p7

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 515
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p8

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 517
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p9

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 519
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p10

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 521
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int/2addr v3, p11

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 523
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int v3, v3, p12

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 525
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int v3, v3, p13

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 527
    aget-byte v3, p4, v2

    and-int/lit16 v3, v3, 0xff

    mul-int v3, v3, p14

    add-int/2addr p2, v3

    add-int/2addr v2, v1

    .line 529
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int v1, v1, p15

    add-int/2addr p2, v1

    add-int/lit8 v1, v0, 0x1

    add-int p2, p2, p17

    .line 531
    div-int p2, p2, p18

    int-to-byte p2, p2

    aput-byte p2, p16, v0

    add-int/lit8 p0, p0, 0x1

    move v0, v1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$h_KEtEaO6oqE7Wvvsrz4gQlfnpE(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIIIIIIIII[BIII)V
    .locals 3

    .line 229
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p17

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 230
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

    .line 235
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    add-int/lit8 v1, p0, 0x2

    .line 236
    aget-byte v2, p4, p1

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p6

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x3

    .line 237
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p7

    add-int/2addr p2, v1

    add-int/lit8 v1, p0, 0x4

    .line 238
    aget-byte v2, p4, v2

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p8

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x5

    .line 239
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p9

    add-int/2addr p2, v1

    add-int/lit8 v1, p0, 0x6

    .line 240
    aget-byte v2, p4, v2

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p10

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x7

    .line 241
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p11

    add-int/2addr p2, v1

    add-int/lit8 p0, p0, 0x8

    .line 242
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p12

    add-int/2addr p2, v1

    .line 243
    aget-byte p0, p4, p0

    and-int/lit16 p0, p0, 0xff

    mul-int p0, p0, p13

    add-int/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    add-int p2, p2, p15

    .line 245
    div-int p2, p2, p16

    int-to-byte p2, p2

    aput-byte p2, p14, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$hm15O1NSK9GTXSe3HPsuNCJ8EYQ(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIIIIIII[BIII)V
    .locals 3

    .line 189
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p15

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 190
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

    .line 195
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    add-int/lit8 v1, p0, 0x2

    .line 196
    aget-byte v2, p4, p1

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p6

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x3

    .line 197
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p7

    add-int/2addr p2, v1

    add-int/lit8 v1, p0, 0x4

    .line 198
    aget-byte v2, p4, v2

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p8

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x5

    .line 199
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p9

    add-int/2addr p2, v1

    add-int/lit8 p0, p0, 0x6

    .line 200
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p10

    add-int/2addr p2, v1

    .line 201
    aget-byte p0, p4, p0

    and-int/lit16 p0, p0, 0xff

    mul-int/2addr p0, p11

    add-int/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    add-int p2, p2, p13

    .line 203
    div-int p2, p2, p14

    int-to-byte p2, p2

    aput-byte p2, p12, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$spRpiw8VmuRjZ-FAfmCn5cMjolo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIII[BIII)V
    .locals 1

    .line 121
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p11

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 122
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

    .line 127
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    add-int/lit8 p0, p0, 0x2

    .line 128
    aget-byte p11, p4, p1

    and-int/lit16 p11, p11, 0xff

    mul-int/2addr p11, p6

    add-int/2addr p2, p11

    .line 129
    aget-byte p0, p4, p0

    and-int/lit16 p0, p0, 0xff

    mul-int/2addr p0, p7

    add-int/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    add-int/2addr p2, p9

    .line 131
    div-int/2addr p2, p10

    int-to-byte p2, p2

    aput-byte p2, p8, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$tGAzS4VicsKYtP_hzIAJhXtA7IQ(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIIIIIIIIIII[BIII)V
    .locals 3

    .line 273
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p19

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 274
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p2, p2, p19

    add-int/2addr p0, p2

    sub-int/2addr p0, p1

    add-int/2addr p3, p0

    sub-int/2addr p3, p1

    add-int/2addr p0, p1

    :goto_0
    if-ge p0, p3, :cond_0

    add-int/lit8 p1, p0, 0x1

    .line 279
    aget-byte p2, p4, p0

    and-int/lit16 p2, p2, 0xff

    mul-int/2addr p2, p5

    add-int/lit8 v1, p0, 0x2

    .line 280
    aget-byte v2, p4, p1

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p6

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x3

    .line 281
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p7

    add-int/2addr p2, v1

    add-int/lit8 v1, p0, 0x4

    .line 282
    aget-byte v2, p4, v2

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p8

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x5

    .line 283
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p9

    add-int/2addr p2, v1

    add-int/lit8 v1, p0, 0x6

    .line 284
    aget-byte v2, p4, v2

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p10

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x7

    .line 285
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, p11

    add-int/2addr p2, v1

    add-int/lit8 v1, p0, 0x8

    .line 286
    aget-byte v2, p4, v2

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, p12

    add-int/2addr p2, v2

    add-int/lit8 v2, p0, 0x9

    .line 287
    aget-byte v1, p4, v1

    and-int/lit16 v1, v1, 0xff

    mul-int v1, v1, p13

    add-int/2addr p2, v1

    add-int/lit8 p0, p0, 0xa

    .line 288
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int v1, v1, p14

    add-int/2addr p2, v1

    .line 289
    aget-byte p0, p4, p0

    and-int/lit16 p0, p0, 0xff

    mul-int p0, p0, p15

    add-int/2addr p2, p0

    add-int/lit8 p0, v0, 0x1

    add-int p2, p2, p17

    .line 291
    div-int p2, p2, p18

    int-to-byte p2, p2

    aput-byte p2, p16, v0

    move v0, p0

    move p0, p1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)Z
    .locals 4

    .line 56
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

    .line 64
    :cond_1
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->horizontal11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    goto :goto_0

    .line 63
    :cond_2
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->horizontal9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    goto :goto_0

    .line 62
    :cond_3
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->horizontal7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    goto :goto_0

    .line 61
    :cond_4
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->horizontal5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    goto :goto_0

    .line 60
    :cond_5
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->horizontal3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    :goto_0
    const/4 p0, 0x1

    return p0

    :cond_6
    :goto_1
    return v3
.end method

.method public static horizontal11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 22

    move-object/from16 v3, p1

    .line 252
    iget-object v5, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v1, p2

    .line 253
    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v2, p0

    .line 255
    iget-object v4, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    move v7, v6

    aget v6, v4, v7

    const/4 v8, 0x1

    .line 256
    aget v8, v4, v8

    const/4 v9, 0x2

    .line 257
    aget v9, v4, v9

    const/4 v10, 0x3

    .line 258
    aget v10, v4, v10

    const/4 v11, 0x4

    .line 259
    aget v11, v4, v11

    const/4 v12, 0x5

    .line 260
    aget v12, v4, v12

    const/4 v13, 0x6

    .line 261
    aget v13, v4, v13

    const/4 v14, 0x7

    .line 262
    aget v14, v4, v14

    const/16 v15, 0x8

    .line 263
    aget v15, v4, v15

    const/16 v16, 0x9

    .line 264
    aget v16, v4, v16

    const/16 v17, 0xa

    .line 265
    aget v4, v4, v17

    .line 267
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

    .line 269
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 270
    div-int/lit8 v18, p3, 0x2

    move-object/from16 v19, v0

    .line 272
    iget v0, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    move/from16 v20, v0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda1;

    move-object/from16 v17, v19

    move/from16 v21, v20

    move/from16 v19, p3

    invoke-direct/range {v0 .. v19}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIIIIIIIIIII[BII)V

    move-object v1, v0

    move/from16 v0, v21

    const/4 v7, 0x0

    invoke-static {v7, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 13

    .line 108
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 109
    iget-object v9, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 111
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v12, 0x0

    aget v6, v0, v12

    const/4 v2, 0x1

    .line 112
    aget v7, v0, v2

    const/4 v2, 0x2

    .line 113
    aget v8, v0, v2

    .line 115
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    .line 117
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 118
    div-int/lit8 v10, p3, 0x2

    .line 120
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;

    move-object v3, p1

    move-object v1, p2

    move/from16 v11, p3

    invoke-direct/range {v0 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIII[BII)V

    invoke-static {v12, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 16

    move-object/from16 v3, p1

    .line 138
    iget-object v5, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v1, p2

    .line 139
    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v0, p0

    .line 141
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v14, 0x0

    aget v6, v2, v14

    const/4 v4, 0x1

    .line 142
    aget v7, v2, v4

    const/4 v4, 0x2

    .line 143
    aget v8, v2, v4

    const/4 v4, 0x3

    .line 144
    aget v9, v2, v4

    const/4 v4, 0x4

    .line 145
    aget v10, v2, v4

    .line 147
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    .line 149
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 150
    div-int/lit8 v12, p3, 0x2

    .line 152
    iget v15, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda7;

    move/from16 v13, p3

    invoke-direct/range {v0 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda7;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIIIII[BII)V

    invoke-static {v14, v15, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 18

    move-object/from16 v3, p1

    .line 172
    iget-object v5, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v1, p2

    .line 173
    iget-object v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v0, p0

    .line 175
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v4, 0x0

    aget v6, v2, v4

    const/4 v7, 0x1

    .line 176
    aget v7, v2, v7

    const/4 v8, 0x2

    .line 177
    aget v8, v2, v8

    const/4 v9, 0x3

    .line 178
    aget v9, v2, v9

    const/4 v10, 0x4

    .line 179
    aget v10, v2, v10

    const/4 v11, 0x5

    .line 180
    aget v11, v2, v11

    const/4 v12, 0x6

    .line 181
    aget v12, v2, v12

    .line 183
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    move v0, v4

    .line 185
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 186
    div-int/lit8 v14, p3, 0x2

    .line 188
    iget v15, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    move/from16 v16, v0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda9;

    move/from16 v17, v15

    move/from16 v15, p3

    invoke-direct/range {v0 .. v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda9;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIIIIIII[BII)V

    move-object v1, v0

    move/from16 v0, v17

    const/4 v2, 0x0

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 19

    move-object/from16 v3, p1

    .line 210
    iget-object v5, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v1, p2

    .line 211
    iget-object v15, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v0, p0

    .line 213
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v4, 0x0

    aget v6, v2, v4

    const/4 v7, 0x1

    .line 214
    aget v7, v2, v7

    const/4 v8, 0x2

    .line 215
    aget v8, v2, v8

    const/4 v9, 0x3

    .line 216
    aget v9, v2, v9

    const/4 v10, 0x4

    .line 217
    aget v10, v2, v10

    const/4 v11, 0x5

    .line 218
    aget v11, v2, v11

    const/4 v12, 0x6

    .line 219
    aget v12, v2, v12

    const/4 v13, 0x7

    .line 220
    aget v13, v2, v13

    const/16 v14, 0x8

    .line 221
    aget v14, v2, v14

    .line 223
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v2

    move v0, v4

    .line 225
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 226
    div-int/lit8 v16, p3, 0x2

    .line 228
    iget v0, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    move/from16 v17, v0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda6;

    move/from16 v18, v17

    move/from16 v17, p3

    invoke-direct/range {v0 .. v17}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda6;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIIIIIIIII[BII)V

    move-object v1, v0

    move/from16 v0, v18

    const/4 v2, 0x0

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Z
    .locals 4

    .line 74
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

    .line 82
    :cond_1
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->vertical11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    goto :goto_0

    .line 81
    :cond_2
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->vertical9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    goto :goto_0

    .line 80
    :cond_3
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->vertical7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    goto :goto_0

    .line 79
    :cond_4
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->vertical5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    goto :goto_0

    .line 78
    :cond_5
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->vertical3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    :goto_0
    const/4 p0, 0x1

    return p0

    :cond_6
    :goto_1
    return v3
.end method

.method public static vertical11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 21

    move-object/from16 v2, p1

    .line 478
    iget-object v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v1, p2

    .line 479
    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v3, p0

    .line 481
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v6, v4, v6

    const/4 v7, 0x1

    .line 482
    aget v7, v4, v7

    const/4 v8, 0x2

    .line 483
    aget v8, v4, v8

    const/4 v9, 0x3

    .line 484
    aget v9, v4, v9

    const/4 v10, 0x4

    .line 485
    aget v10, v4, v10

    const/4 v11, 0x5

    .line 486
    aget v11, v4, v11

    const/4 v12, 0x6

    .line 487
    aget v12, v4, v12

    const/4 v13, 0x7

    .line 488
    aget v13, v4, v13

    const/16 v14, 0x8

    .line 489
    aget v14, v4, v14

    const/16 v15, 0x9

    .line 490
    aget v15, v4, v15

    const/16 v16, 0xa

    .line 491
    aget v16, v4, v16

    .line 493
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 495
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 496
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v17

    .line 497
    div-int/lit8 v18, p3, 0x2

    move-object/from16 v19, v0

    sub-int v0, v17, v3

    move/from16 v17, v0

    .line 501
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda2;

    move/from16 v20, v17

    move-object/from16 v17, v19

    move/from16 v19, p3

    invoke-direct/range {v0 .. v19}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIIIIIIIIIII[BII)V

    move-object v1, v0

    move/from16 v0, v20

    invoke-static {v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 12

    .line 298
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 299
    iget-object v9, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 301
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v1, 0x0

    aget v6, v0, v1

    const/4 v1, 0x1

    .line 302
    aget v7, v0, v1

    const/4 v1, 0x2

    .line 303
    aget v8, v0, v1

    .line 305
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 307
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 308
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p0

    .line 309
    div-int/lit8 v10, p3, 0x2

    sub-int/2addr p0, v3

    .line 313
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda4;

    move-object v2, p1

    move-object v1, p2

    move v11, p3

    invoke-direct/range {v0 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIII[BII)V

    invoke-static {v3, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 14

    .line 334
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v1, p2

    .line 335
    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 337
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v3, 0x0

    aget v6, v0, v3

    const/4 v3, 0x1

    .line 338
    aget v7, v0, v3

    const/4 v3, 0x2

    .line 339
    aget v8, v0, v3

    const/4 v3, 0x3

    .line 340
    aget v9, v0, v3

    const/4 v3, 0x4

    .line 341
    aget v10, v0, v3

    .line 343
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 345
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 346
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p0

    .line 347
    div-int/lit8 v12, p3, 0x2

    sub-int/2addr p0, v3

    .line 351
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda5;

    move-object v2, p1

    move/from16 v13, p3

    invoke-direct/range {v0 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIIIII[BII)V

    invoke-static {v3, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 17

    move-object/from16 v2, p1

    .line 376
    iget-object v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v1, p2

    .line 377
    iget-object v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v0, p0

    .line 379
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v4, 0x0

    aget v6, v3, v4

    const/4 v4, 0x1

    .line 380
    aget v7, v3, v4

    const/4 v4, 0x2

    .line 381
    aget v8, v3, v4

    const/4 v4, 0x3

    .line 382
    aget v9, v3, v4

    const/4 v4, 0x4

    .line 383
    aget v10, v3, v4

    const/4 v4, 0x5

    .line 384
    aget v11, v3, v4

    const/4 v4, 0x6

    .line 385
    aget v12, v3, v4

    .line 387
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 389
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 390
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v0

    .line 391
    div-int/lit8 v14, p3, 0x2

    sub-int/2addr v0, v3

    move v15, v0

    .line 395
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda3;

    move/from16 v16, v15

    move/from16 v15, p3

    invoke-direct/range {v0 .. v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIIIIIII[BII)V

    move/from16 v15, v16

    invoke-static {v3, v15, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 19

    move-object/from16 v2, p1

    .line 424
    iget-object v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v1, p2

    .line 425
    iget-object v15, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v0, p0

    .line 427
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v4, 0x0

    aget v6, v3, v4

    const/4 v4, 0x1

    .line 428
    aget v7, v3, v4

    const/4 v4, 0x2

    .line 429
    aget v8, v3, v4

    const/4 v4, 0x3

    .line 430
    aget v9, v3, v4

    const/4 v4, 0x4

    .line 431
    aget v10, v3, v4

    const/4 v4, 0x5

    .line 432
    aget v11, v3, v4

    const/4 v4, 0x6

    .line 433
    aget v12, v3, v4

    const/4 v4, 0x7

    .line 434
    aget v13, v3, v4

    const/16 v4, 0x8

    .line 435
    aget v14, v3, v4

    .line 437
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v3

    .line 439
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 440
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v0

    .line 441
    div-int/lit8 v16, p3, 0x2

    sub-int/2addr v0, v3

    move/from16 v17, v0

    .line 445
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda8;

    move/from16 v18, v17

    move/from16 v17, p3

    invoke-direct/range {v0 .. v17}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda8;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[BIIIIIIIII[BII)V

    move-object v1, v0

    move/from16 v0, v18

    invoke-static {v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method
