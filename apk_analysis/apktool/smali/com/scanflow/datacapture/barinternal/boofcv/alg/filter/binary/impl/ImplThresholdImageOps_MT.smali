.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;
.super Ljava/lang/Object;
.source "ImplThresholdImageOps_MT.java"


# direct methods
.method public static synthetic $r8$lambda$2AdAP9D97eJraneJFObxflK4gls(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    .line 179
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 180
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 182
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 183
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v5, v0, 0x1

    aget v0, v4, v0

    if-gt v0, p2, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$2tK6urmRJ2cCEgmU9GrD8QkITWE(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;FI)V
    .locals 8

    .line 408
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 409
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 410
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 412
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 415
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v4, v2, 0x1

    aget v2, v3, v2

    .line 416
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v1, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v7, v0, 0x1

    aget v0, v6, v0

    mul-float/2addr v0, p3

    cmpl-float v0, v0, v2

    if-lez v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    aput-byte v0, v3, v1

    move v2, v4

    move v1, v5

    move v0, v7

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$46qDHGtpefM5Oy9Tfm7il7cdoZw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;FI)V
    .locals 5

    .line 453
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 454
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 455
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 457
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 460
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v3, v3, v2

    .line 462
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v4, v4, v0

    mul-float/2addr v4, p3

    cmpl-float v3, v4, v3

    if-lez v3, :cond_0

    .line 463
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x1

    aput-byte v4, v3, v1

    goto :goto_1

    .line 465
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x0

    aput-byte v4, v3, v1

    :goto_1
    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$7VN2tCPrF829C1aTM9HufITA1j8(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    .line 127
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 128
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 130
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 131
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v5, v0, 0x1

    aget-short v0, v4, v0

    if-gt v0, p2, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$9J6lngSn9VicLtsGyFWgCYdRGv4(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;FI)V
    .locals 8

    .line 395
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 396
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 397
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 399
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 402
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v4, v2, 0x1

    aget v2, v3, v2

    mul-float/2addr v2, p3

    .line 403
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v1, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v7, v0, 0x1

    aget v0, v6, v0

    cmpg-float v0, v0, v2

    if-gtz v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    aput-byte v0, v3, v1

    move v2, v4

    move v1, v5

    move v0, v7

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$Gn-fCAblNXgod9vqOH6wofi8NTU(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;FI)V
    .locals 9

    .line 304
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 305
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 306
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 308
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 311
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v4, v2, 0x1

    aget-short v2, v3, v2

    const v3, 0xffff

    and-int/2addr v2, v3

    int-to-float v2, v2

    mul-float/2addr v2, p3

    .line 312
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v1, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v0, 0x1

    aget-short v0, v7, v0

    and-int/2addr v0, v3

    int-to-float v0, v0

    cmpg-float v0, v0, v2

    if-gtz v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    aput-byte v0, v5, v1

    move v2, v4

    move v1, v6

    move v0, v8

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$I0rf3cAavYtIx0UI233tyU0LRmU(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;FI)V
    .locals 5

    .line 436
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 437
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 438
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 440
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 443
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v3, v3, v2

    mul-float/2addr v3, p3

    .line 445
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v4, v4, v0

    cmpg-float v3, v4, v3

    if-gtz v3, :cond_0

    .line 446
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x1

    aput-byte v4, v3, v1

    goto :goto_1

    .line 448
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x0

    aput-byte v4, v3, v1

    :goto_1
    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$IgmUDAADl33PqJ_TGYvJajf9FWg(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    .line 153
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 154
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 156
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 157
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v5, v0, 0x1

    aget-short v0, v4, v0

    const v4, 0xffff

    and-int/2addr v0, v4

    if-gt v0, p2, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$IpMu9dH1wX7xgi7lrYgNg_cWagk(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;FI)V
    .locals 6

    .line 345
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 346
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 347
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 349
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 352
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v3, v3, v2

    const v4, 0xffff

    and-int/2addr v3, v4

    int-to-float v3, v3

    mul-float/2addr v3, p3

    .line 354
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v5, v5, v0

    and-int/2addr v4, v5

    int-to-float v4, v4

    cmpg-float v3, v4, v3

    if-gtz v3, :cond_0

    .line 355
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x1

    aput-byte v4, v3, v1

    goto :goto_1

    .line 357
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x0

    aput-byte v4, v3, v1

    :goto_1
    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$JS4RlNsMhWDUslc3cULM1kghGbE(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DI)V
    .locals 8

    .line 84
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 85
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v2

    add-int/2addr v1, p4

    .line 87
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p4, :cond_1

    .line 88
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v5, v0, 0x1

    aget-wide v6, v4, v0

    cmpl-double v0, v6, p2

    if-lez v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p4, p4, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$RFa7C3tCC2T_vLJJnHufDnWjhPk(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;FI)V
    .locals 9

    .line 317
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 318
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 319
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 321
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 324
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v4, v2, 0x1

    aget-short v2, v3, v2

    const v3, 0xffff

    and-int/2addr v2, v3

    int-to-float v2, v2

    .line 325
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v1, 0x1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v0, 0x1

    aget-short v0, v7, v0

    and-int/2addr v0, v3

    int-to-float v0, v0

    mul-float/2addr v0, p3

    cmpl-float v0, v0, v2

    if-lez v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    aput-byte v0, v5, v1

    move v2, v4

    move v1, v6

    move v0, v8

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$ThjauhXqvNHeRgiY5helJMdD54M(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    .line 188
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 189
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 191
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 192
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v5, v0, 0x1

    aget v0, v4, v0

    if-le v0, p2, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$VeSRL_t-_6iPCjqcjgRJDbnwazQ(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FI)V
    .locals 6

    .line 58
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 59
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 61
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 62
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v5, v0, 0x1

    aget v0, v4, v0

    cmpl-float v0, v0, p2

    if-lez v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$WXnanuaN5c6c5kVRm6a8XXyn_JM(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FI)V
    .locals 5

    .line 254
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 255
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 256
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 258
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 261
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v3, v3, v2

    and-int/lit16 v3, v3, 0xff

    int-to-float v3, v3

    mul-float/2addr v3, p3

    .line 263
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v4, v4, v0

    and-int/lit16 v4, v4, 0xff

    int-to-float v4, v4

    cmpg-float v3, v4, v3

    if-gtz v3, :cond_0

    .line 264
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x1

    aput-byte v4, v3, v1

    goto :goto_1

    .line 266
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x0

    aput-byte v4, v3, v1

    :goto_1
    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$XmA7l7CorlqxA7RWQ9jqyk-lDkU(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FI)V
    .locals 6

    .line 49
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 50
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 52
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 53
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v5, v0, 0x1

    aget v0, v4, v0

    cmpg-float v0, v0, p2

    if-gtz v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$iToHprxso2CkpMTjXEvR2njaVtI(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    .line 162
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 163
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 165
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 166
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v5, v0, 0x1

    aget-short v0, v4, v0

    const v4, 0xffff

    and-int/2addr v0, v4

    if-le v0, p2, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$jvtMmmvPL6OgZTX8Y0EsG5qKAds(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FI)V
    .locals 8

    .line 213
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 214
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 215
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 217
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 220
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v4, v2, 0x1

    aget-byte v2, v3, v2

    and-int/lit16 v2, v2, 0xff

    int-to-float v2, v2

    mul-float/2addr v2, p3

    .line 221
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v1, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v0, 0x1

    aget-byte v0, v6, v0

    and-int/lit16 v0, v0, 0xff

    int-to-float v0, v0

    cmpg-float v0, v0, v2

    if-gtz v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    aput-byte v0, v3, v1

    move v2, v4

    move v1, v5

    move v0, v7

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$kAbYuM5DPRdKdt1tDjvEbBlfKks(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    .line 110
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 111
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 113
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 114
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v0, 0x1

    aget-byte v0, v4, v0

    and-int/lit16 v0, v0, 0xff

    if-le v0, p2, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$kIV4vatD8hOBs7TrAJimP2lCei8(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;FI)V
    .locals 6

    .line 362
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 363
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 364
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 366
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 369
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v3, v3, v2

    const v4, 0xffff

    and-int/2addr v3, v4

    .line 371
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v5, v5, v0

    and-int/2addr v4, v5

    int-to-float v4, v4

    mul-float/2addr v4, p3

    int-to-float v3, v3

    cmpl-float v3, v4, v3

    if-lez v3, :cond_0

    .line 372
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x1

    aput-byte v4, v3, v1

    goto :goto_1

    .line 374
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x0

    aput-byte v4, v3, v1

    :goto_1
    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$qktt-MkZfpf0CBPxdqyi3ebXB78(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    .line 136
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 137
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 139
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 140
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v5, v0, 0x1

    aget-short v0, v4, v0

    if-le v0, p2, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$rNjhXI97YM8inPDUeLc21wNc7io(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    .line 101
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p3

    add-int/2addr v0, v1

    .line 102
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v2

    add-int/2addr v1, p3

    .line 104
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p3, :cond_1

    .line 105
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v0, 0x1

    aget-byte v0, v4, v0

    and-int/lit16 v0, v0, 0xff

    if-gt v0, p2, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p3, p3, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$rYU_rHN7HSEzWQB34Je1JF4v47w(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FI)V
    .locals 5

    .line 271
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 272
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 273
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 275
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 278
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v3, v3, v2

    and-int/lit16 v3, v3, 0xff

    .line 280
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v4, v4, v0

    and-int/lit16 v4, v4, 0xff

    int-to-float v4, v4

    mul-float/2addr v4, p3

    int-to-float v3, v3

    cmpl-float v3, v4, v3

    if-lez v3, :cond_0

    .line 281
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x1

    aput-byte v4, v3, v1

    goto :goto_1

    .line 283
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/4 v4, 0x0

    aput-byte v4, v3, v1

    :goto_1
    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$vBDzEjo-1Dh5BVn-BBxHjrMd4H8(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FI)V
    .locals 8

    .line 226
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 227
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 228
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    .line 230
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr p4, v0

    :goto_0
    if-ge v0, p4, :cond_1

    .line 233
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v4, v2, 0x1

    aget-byte v2, v3, v2

    and-int/lit16 v2, v2, 0xff

    int-to-float v2, v2

    .line 234
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v1, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v0, 0x1

    aget-byte v0, v6, v0

    and-int/lit16 v0, v0, 0xff

    int-to-float v0, v0

    mul-float/2addr v0, p3

    cmpl-float v0, v0, v2

    if-lez v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    aput-byte v0, v3, v1

    move v2, v4

    move v1, v5

    move v0, v7

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$vT__BKfe7J2iSp8PgJxmV4KXkRw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DI)V
    .locals 8

    .line 75
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 76
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p4, v2

    add-int/2addr v1, p4

    .line 78
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    :goto_0
    if-lez p4, :cond_1

    .line 79
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v5, v0, 0x1

    aget-wide v6, v4, v0

    cmpg-double v0, v6, p2

    if-gtz v0, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_1
    int-to-byte v0, v0

    aput-byte v0, v2, v1

    add-int/lit8 p4, p4, -0x1

    move v1, v3

    move v0, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 6

    .line 428
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

    .line 432
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    const/4 p0, 0x0

    if-eqz p4, :cond_0

    .line 435
    iget p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda18;

    invoke-direct {p4, v0, p1, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda18;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F)V

    invoke-static {p0, p2, p4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 452
    :cond_0
    iget p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;

    invoke-direct {p4, v0, p1, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F)V

    invoke-static {p0, p2, p4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 6

    .line 337
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

    .line 341
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    const/4 p0, 0x0

    if-eqz p4, :cond_0

    .line 344
    iget p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda6;

    invoke-direct {p4, v0, p1, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda6;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;F)V

    invoke-static {p0, p2, p4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 361
    :cond_0
    iget p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda7;

    invoke-direct {p4, v0, p1, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda7;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;F)V

    invoke-static {p0, p2, p4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 6

    .line 246
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

    .line 250
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 p0, 0x0

    if-eqz p4, :cond_0

    .line 253
    iget p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda4;

    invoke-direct {p4, v0, p1, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;F)V

    invoke-static {p0, p2, p4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 270
    :cond_0
    iget p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda5;

    invoke-direct {p4, v0, p1, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;F)V

    invoke-static {p0, p2, p4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    .line 387
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v0

    int-to-double v0, v0

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result p2

    div-int/lit8 p2, p2, 0x2

    .line 391
    invoke-static {p0, p5, p2, p6, p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    const/4 p2, 0x0

    if-eqz p4, :cond_0

    .line 394
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda22;

    invoke-direct {p6, p0, p1, p5, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda22;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F)V

    invoke-static {p2, p4, p6}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 407
    :cond_0
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda23;

    invoke-direct {p6, p0, p1, p5, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda23;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F)V

    invoke-static {p2, p4, p6}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    .line 296
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v0

    int-to-double v0, v0

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result p2

    div-int/lit8 p2, p2, 0x2

    .line 300
    invoke-static {p0, p5, p2, p6, p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    const/4 p2, 0x0

    if-eqz p4, :cond_0

    .line 303
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda20;

    invoke-direct {p6, p0, p1, p5, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda20;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;F)V

    invoke-static {p2, p4, p6}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 316
    :cond_0
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda21;

    invoke-direct {p6, p0, p1, p5, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda21;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;F)V

    invoke-static {p2, p4, p6}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    .line 205
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v0

    int-to-double v0, v0

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result p2

    div-int/lit8 p2, p2, 0x2

    .line 209
    invoke-static {p0, p5, p2, p6, p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 p2, 0x0

    if-eqz p4, :cond_0

    .line 212
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda0;

    invoke-direct {p6, p0, p1, p5, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;F)V

    invoke-static {p2, p4, p6}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 225
    :cond_0
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda1;

    invoke-direct {p6, p0, p1, p5, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;F)V

    invoke-static {p2, p4, p6}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    const/4 v0, 0x0

    if-eqz p3, :cond_0

    .line 48
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda16;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda16;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;F)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 57
    :cond_0
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda17;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda17;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;F)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    const/4 v0, 0x0

    if-eqz p4, :cond_0

    .line 74
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda8;

    invoke-direct {v1, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda8;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;D)V

    invoke-static {v0, p4, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 83
    :cond_0
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda9;

    invoke-direct {v1, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda9;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;D)V

    invoke-static {v0, p4, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    const/4 v0, 0x0

    if-eqz p3, :cond_0

    .line 126
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda10;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda10;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 135
    :cond_0
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda11;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda11;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    const/4 v0, 0x0

    if-eqz p3, :cond_0

    .line 178
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda12;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda12;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 187
    :cond_0
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda13;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda13;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    const/4 v0, 0x0

    if-eqz p3, :cond_0

    .line 152
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda2;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 161
    :cond_0
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda3;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    const/4 v0, 0x0

    if-eqz p3, :cond_0

    .line 100
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda14;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda14;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1

    .line 109
    :cond_0
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda15;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda15;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-object p1
.end method
