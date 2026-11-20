.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;
.super Ljava/lang/Object;
.source "ConvertInterleavedToSingle_MT.java"


# direct methods
.method public static synthetic $r8$lambda$0F8cJuxpb2kKhxLuyekw8GbQAdg(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V
    .locals 6

    const/4 v0, 0x0

    .line 400
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 401
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    .line 403
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_1

    add-int v2, v1, p2

    const/4 v3, 0x0

    :goto_1
    if-ge v1, v2, :cond_0

    .line 407
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    add-int/lit8 v5, v1, 0x1

    aget v1, v4, v1

    add-float/2addr v3, v1

    move v1, v5

    goto :goto_1

    .line 409
    :cond_0
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v4, p3, 0x1

    int-to-float v5, p2

    div-float/2addr v3, v5

    aput v3, v2, p3

    add-int/lit8 v0, v0, 0x1

    move p3, v4

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$2DipVWSs87EGuhP50Mp9qLmwxhY(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;II)V
    .locals 7

    const/4 v0, 0x0

    .line 241
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 242
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 244
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    add-int v3, v1, p2

    move v4, v0

    :goto_1
    if-ge v1, v3, :cond_0

    .line 248
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v6, v1, 0x1

    aget-short v1, v5, v1

    add-int/2addr v4, v1

    move v1, v6

    goto :goto_1

    .line 250
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    int-to-short v4, v4

    aput-short v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$5LIvScvvraMZc49VIAKn9YLb68k(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I)V
    .locals 6

    const/4 v0, 0x0

    .line 373
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 374
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 375
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 379
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    add-int/lit8 v3, v1, 0x1

    aget v4, v2, v1

    add-int/lit8 v1, v1, 0x2

    .line 380
    aget v2, v2, v3

    add-float/2addr v4, v2

    .line 381
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v3, p2, 0x1

    const/high16 v5, 0x40000000    # 2.0f

    div-float/2addr v4, v5

    aput v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$6xtMlq5hIWO795vx8bDdPA-Y6h4(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;II)V
    .locals 9

    const/4 v0, 0x0

    .line 347
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 348
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    .line 350
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_1

    add-int v2, v1, p2

    const-wide/16 v3, 0x0

    :goto_1
    if-ge v1, v2, :cond_0

    .line 354
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    add-int/lit8 v6, v1, 0x1

    aget-wide v7, v5, v1

    add-long/2addr v3, v7

    move v1, v6

    goto :goto_1

    .line 356
    :cond_0
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v5, p3, 0x1

    int-to-long v6, p2

    div-long/2addr v3, v6

    aput-wide v3, v2, p3

    add-int/lit8 v0, v0, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$6y3JVm1u78equ-_09sI4ZdEfQ5k(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;I)V
    .locals 8

    const/4 v0, 0x0

    .line 426
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 427
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 428
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 432
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    add-int/lit8 v3, v1, 0x1

    aget-wide v4, v2, v1

    add-int/lit8 v1, v1, 0x2

    .line 433
    aget-wide v6, v2, v3

    add-double/2addr v4, v6

    .line 434
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v3, p2, 0x1

    const-wide/high16 v6, 0x4000000000000000L    # 2.0

    div-double/2addr v4, v6

    aput-wide v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$9pcRhd11XNgsR0XGri3iJLhuw0I(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I)V
    .locals 6

    const/4 v0, 0x0

    .line 386
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 387
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 388
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 392
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    add-int/lit8 v3, v1, 0x1

    aget v4, v2, v1

    add-int/lit8 v5, v1, 0x2

    .line 393
    aget v3, v2, v3

    add-float/2addr v4, v3

    add-int/lit8 v1, v1, 0x3

    .line 394
    aget v2, v2, v5

    add-float/2addr v4, v2

    .line 395
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v3, p2, 0x1

    const/high16 v5, 0x40400000    # 3.0f

    div-float/2addr v4, v5

    aput v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$BolU2-stR5MgyMbPipUEkNXEPkc(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;II)V
    .locals 9

    const/4 v0, 0x0

    .line 453
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 454
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    .line 456
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_1

    add-int v2, v1, p2

    const-wide/16 v3, 0x0

    :goto_1
    if-ge v1, v2, :cond_0

    .line 460
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    add-int/lit8 v6, v1, 0x1

    aget-wide v7, v5, v1

    add-double/2addr v3, v7

    move v1, v6

    goto :goto_1

    .line 462
    :cond_0
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v5, p3, 0x1

    int-to-double v6, p2

    div-double/2addr v3, v6

    aput-wide v3, v2, p3

    add-int/lit8 v0, v0, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$DlPNIWt7OEnmEd0qK0p6pOoIDF4(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I)V
    .locals 5

    const/4 v0, 0x0

    .line 214
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 215
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 216
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 220
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v3, v1, 0x1

    aget-short v4, v2, v1

    add-int/lit8 v1, v1, 0x2

    .line 221
    aget-short v2, v2, v3

    add-int/2addr v4, v2

    .line 222
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x2

    int-to-short v4, v4

    aput-short v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$JQdCLeM_0LgRC5JA_ksbwp3Nib8(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V
    .locals 6

    const/4 v0, 0x0

    .line 68
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 69
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 70
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 74
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    aget-byte v4, v2, v1

    and-int/lit16 v4, v4, 0xff

    add-int/lit8 v5, v1, 0x2

    .line 75
    aget-byte v3, v2, v3

    and-int/lit16 v3, v3, 0xff

    add-int/2addr v4, v3

    add-int/lit8 v1, v1, 0x3

    .line 76
    aget-byte v2, v2, v5

    and-int/lit16 v2, v2, 0xff

    add-int/2addr v4, v2

    .line 77
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x3

    int-to-byte v4, v4

    aput-byte v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$LDoexoirWL2DfsjEJ7qJ1zTa0oI(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;I)V
    .locals 8

    const/4 v0, 0x0

    .line 320
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 321
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 322
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 326
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    add-int/lit8 v3, v1, 0x1

    aget-wide v4, v2, v1

    add-int/lit8 v1, v1, 0x2

    .line 327
    aget-wide v6, v2, v3

    add-long/2addr v4, v6

    .line 328
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v3, p2, 0x1

    const-wide/16 v6, 0x2

    div-long/2addr v4, v6

    aput-wide v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$MbarpG0UEaKaFxduU3XobYl3Gxk(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;II)V
    .locals 7

    const/4 v0, 0x0

    .line 294
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 295
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 297
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    add-int v3, v1, p2

    move v4, v0

    :goto_1
    if-ge v1, v3, :cond_0

    .line 301
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    add-int/lit8 v6, v1, 0x1

    aget v1, v5, v1

    add-int/2addr v4, v1

    move v1, v6

    goto :goto_1

    .line 303
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    aput v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$RkdK0yv5XuZqCKGNhF0HJt0VfmI(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I)V
    .locals 5

    const/4 v0, 0x0

    .line 267
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 268
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 269
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 273
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    add-int/lit8 v3, v1, 0x1

    aget v4, v2, v1

    add-int/lit8 v1, v1, 0x2

    .line 274
    aget v2, v2, v3

    add-int/2addr v4, v2

    .line 275
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x2

    aput v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$XQ-GznW16y_LXh6orWIJ06-1rdA(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I)V
    .locals 7

    const/4 v0, 0x0

    .line 174
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 175
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 176
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 180
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v3, v1, 0x1

    aget-short v4, v2, v1

    const v5, 0xffff

    and-int/2addr v4, v5

    add-int/lit8 v6, v1, 0x2

    .line 181
    aget-short v3, v2, v3

    and-int/2addr v3, v5

    add-int/2addr v4, v3

    add-int/lit8 v1, v1, 0x3

    .line 182
    aget-short v2, v2, v6

    and-int/2addr v2, v5

    add-int/2addr v4, v2

    .line 183
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x3

    int-to-short v4, v4

    aput-short v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$aVSDVDvhCkniPPCpBbRkQqRzXC0(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;II)V
    .locals 7

    const/4 v0, 0x0

    .line 135
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 136
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 138
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    add-int v3, v1, p2

    move v4, v0

    :goto_1
    if-ge v1, v3, :cond_0

    .line 142
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v6, v1, 0x1

    aget-byte v1, v5, v1

    add-int/2addr v4, v1

    move v1, v6

    goto :goto_1

    .line 144
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    int-to-byte v4, v4

    aput-byte v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$avsj8iVfACY9vi1yumEt_jXaxHw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II)V
    .locals 7

    const/4 v0, 0x0

    .line 188
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 189
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 191
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    add-int v3, v1, p2

    move v4, v0

    :goto_1
    if-ge v1, v3, :cond_0

    .line 195
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v6, v1, 0x1

    aget-short v1, v5, v1

    const v5, 0xffff

    and-int/2addr v1, v5

    add-int/2addr v4, v1

    move v1, v6

    goto :goto_1

    .line 197
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    int-to-short v4, v4

    aput-short v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$btWf_DldsidxkJWdtSr_wDKrmYU(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I)V
    .locals 6

    const/4 v0, 0x0

    .line 280
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 281
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 282
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 286
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    add-int/lit8 v3, v1, 0x1

    aget v4, v2, v1

    add-int/lit8 v5, v1, 0x2

    .line 287
    aget v3, v2, v3

    add-int/2addr v4, v3

    add-int/lit8 v1, v1, 0x3

    .line 288
    aget v2, v2, v5

    add-int/2addr v4, v2

    .line 289
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x3

    aput v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$esPZXNSA-xz50H_xn8X-DJsEHXw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;I)V
    .locals 9

    const/4 v0, 0x0

    .line 439
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 440
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 441
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 445
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    add-int/lit8 v3, v1, 0x1

    aget-wide v4, v2, v1

    add-int/lit8 v6, v1, 0x2

    .line 446
    aget-wide v7, v2, v3

    add-double/2addr v4, v7

    add-int/lit8 v1, v1, 0x3

    .line 447
    aget-wide v6, v2, v6

    add-double/2addr v4, v6

    .line 448
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v3, p2, 0x1

    const-wide/high16 v6, 0x4008000000000000L    # 3.0

    div-double/2addr v4, v6

    aput-wide v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$k0XsislLABNYNJHnh6fgijQYiwo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I)V
    .locals 6

    const/4 v0, 0x0

    .line 227
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 228
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 229
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 233
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v3, v1, 0x1

    aget-short v4, v2, v1

    add-int/lit8 v5, v1, 0x2

    .line 234
    aget-short v3, v2, v3

    add-int/2addr v4, v3

    add-int/lit8 v1, v1, 0x3

    .line 235
    aget-short v2, v2, v5

    add-int/2addr v4, v2

    .line 236
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x3

    int-to-short v4, v4

    aput-short v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$mIOLyf5RTzLfwv6gU6KyWzw9wKc(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;I)V
    .locals 9

    const/4 v0, 0x0

    .line 333
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 334
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 335
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 339
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    add-int/lit8 v3, v1, 0x1

    aget-wide v4, v2, v1

    add-int/lit8 v6, v1, 0x2

    .line 340
    aget-wide v7, v2, v3

    add-long/2addr v4, v7

    add-int/lit8 v1, v1, 0x3

    .line 341
    aget-wide v6, v2, v6

    add-long/2addr v4, v6

    .line 342
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v3, p2, 0x1

    const-wide/16 v6, 0x3

    div-long/2addr v4, v6

    aput-wide v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$n9AvgPMorITJHzpwV3k-TvUJWps(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I)V
    .locals 5

    const/4 v0, 0x0

    .line 108
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 109
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 110
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 114
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    aget-byte v4, v2, v1

    add-int/lit8 v1, v1, 0x2

    .line 115
    aget-byte v2, v2, v3

    add-int/2addr v4, v2

    .line 116
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x2

    int-to-byte v4, v4

    aput-byte v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$oKvFRO3Bq7d3e5VHsHcs-E3e6Bw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I)V
    .locals 6

    const/4 v0, 0x0

    .line 121
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 122
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 123
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 127
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    aget-byte v4, v2, v1

    add-int/lit8 v5, v1, 0x2

    .line 128
    aget-byte v3, v2, v3

    add-int/2addr v4, v3

    add-int/lit8 v1, v1, 0x3

    .line 129
    aget-byte v2, v2, v5

    add-int/2addr v4, v2

    .line 130
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x3

    int-to-byte v4, v4

    aput-byte v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$riDnPsRaHmHCbtQKKFtkPcj7t7o(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V
    .locals 5

    const/4 v0, 0x0

    .line 55
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 56
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 57
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 61
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v3, v1, 0x1

    aget-byte v4, v2, v1

    and-int/lit16 v4, v4, 0xff

    add-int/lit8 v1, v1, 0x2

    .line 62
    aget-byte v2, v2, v3

    and-int/lit16 v2, v2, 0xff

    add-int/2addr v4, v2

    .line 63
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x2

    int-to-byte v4, v4

    aput-byte v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$uEHWLUuunwXloGgMsvEyfgkuzis(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 7

    const/4 v0, 0x0

    .line 82
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 83
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 85
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    add-int v3, v1, p2

    move v4, v0

    :goto_1
    if-ge v1, v3, :cond_0

    .line 89
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    add-int/lit8 v6, v1, 0x1

    aget-byte v1, v5, v1

    and-int/lit16 v1, v1, 0xff

    add-int/2addr v4, v1

    move v1, v6

    goto :goto_1

    .line 91
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    int-to-byte v4, v4

    aput-byte v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$yH7Qcw3cXMN7rjU_0la1SuUtXJU(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I)V
    .locals 6

    const/4 v0, 0x0

    .line 161
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 162
    invoke-virtual {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p2

    .line 163
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v0, p2

    :goto_0
    if-ge p2, v0, :cond_0

    .line 167
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    add-int/lit8 v3, v1, 0x1

    aget-short v4, v2, v1

    const v5, 0xffff

    and-int/2addr v4, v5

    add-int/lit8 v1, v1, 0x2

    .line 168
    aget-short v2, v2, v3

    and-int/2addr v2, v5

    add-int/2addr v4, v2

    .line 169
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v3, p2, 0x1

    div-int/lit8 v4, v4, 0x2

    int-to-short v4, v4

    aput-short v4, v2, p2

    move p2, v3

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 7

    .line 363
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_1

    move v0, v2

    .line 366
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_0

    .line 367
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 368
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 369
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    :cond_1
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 372
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda9;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda9;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_3

    .line 385
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda10;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda10;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 399
    :cond_3
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda11;

    invoke-direct {v3, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda11;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I)V

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V
    .locals 7

    .line 416
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_1

    move v0, v2

    .line 419
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_0

    .line 420
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 421
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 422
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    :cond_1
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 425
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda12;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda12;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_3

    .line 438
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda13;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda13;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 452
    :cond_3
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda14;

    invoke-direct {v3, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda14;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;I)V

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V
    .locals 7

    .line 204
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_1

    move v0, v2

    .line 207
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_0

    .line 208
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 209
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 210
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    :cond_1
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 213
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_3

    .line 226
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda1;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 240
    :cond_3
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda2;

    invoke-direct {v3, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I)V

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V
    .locals 7

    .line 257
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_1

    move v0, v2

    .line 260
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_0

    .line 261
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 262
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 263
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    :cond_1
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 266
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda21;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda21;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_3

    .line 279
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda22;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda22;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 293
    :cond_3
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda23;

    invoke-direct {v3, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda23;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I)V

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V
    .locals 7

    .line 310
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_1

    move v0, v2

    .line 313
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_0

    .line 314
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 315
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 316
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    :cond_1
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 319
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda6;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda6;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_3

    .line 332
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda7;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda7;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 346
    :cond_3
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda8;

    invoke-direct {v3, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda8;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;I)V

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V
    .locals 7

    .line 98
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_1

    move v0, v2

    .line 101
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_0

    .line 102
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 103
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 104
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    :cond_1
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 107
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda15;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda15;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_3

    .line 120
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda16;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda16;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 134
    :cond_3
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda17;

    invoke-direct {v3, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda17;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I)V

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V
    .locals 7

    .line 151
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_1

    move v0, v2

    .line 154
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_0

    .line 155
    invoke-virtual {p0, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(II)I

    move-result v1

    .line 156
    invoke-virtual {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 157
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v4, v1, v5, v3, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    :cond_1
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 160
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda18;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda18;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_3

    .line 173
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda19;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda19;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 187
    :cond_3
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;

    invoke-direct {v3, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I)V

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 7

    .line 45
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result v0

    const/4 v1, 0x1

    const/4 v2, 0x0

    if-ne v0, v1, :cond_1

    move v0, v2

    .line 48
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v1, :cond_0

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
    return-void

    :cond_1
    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 54
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda3;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    const/4 v1, 0x3

    if-ne v0, v1, :cond_3

    .line 67
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda4;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 81
    :cond_3
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda5;

    invoke-direct {v3, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method
