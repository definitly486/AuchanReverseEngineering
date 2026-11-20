.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;
.super Ljava/lang/Object;
.source "ImplConvertPlanarToGray_MT.java"


# direct methods
.method public static synthetic $r8$lambda$6yXkaxKSKbRdBPsdYnbhV_wT7PM(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I)V
    .locals 5

    const/4 v0, 0x0

    .line 131
    invoke-virtual {p0, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 132
    invoke-virtual {p1, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p5

    .line 134
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_0

    .line 135
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v2, v2, v1

    const v3, 0xffff

    and-int/2addr v2, v3

    .line 136
    iget-object v4, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v4, v4, v1

    and-int/2addr v4, v3

    add-int/2addr v2, v4

    .line 137
    iget-object v4, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v4, v4, v1

    and-int/2addr v3, v4

    add-int/2addr v2, v3

    .line 139
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v4, p5, 0x1

    div-int/lit8 v2, v2, 0x3

    int-to-short v2, v2

    aput-short v2, v3, p5

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    move p5, v4

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$8EePyDZrRb5RaaoCORqC5zbMo_U(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V
    .locals 5

    const/4 v0, 0x0

    .line 55
    invoke-virtual {p0, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 56
    invoke-virtual {p1, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p5

    .line 58
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_0

    .line 59
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v2, v2, v1

    and-int/lit16 v2, v2, 0xff

    .line 60
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v3, v3, v1

    and-int/lit16 v3, v3, 0xff

    add-int/2addr v2, v3

    .line 61
    iget-object v3, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v3, v3, v1

    and-int/lit16 v3, v3, 0xff

    add-int/2addr v2, v3

    .line 63
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v4, p5, 0x1

    div-int/lit8 v2, v2, 0x3

    int-to-byte v2, v2

    aput-byte v2, v3, p5

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    move p5, v4

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$9aKDVmw16Bu83saXcvlHJxW_x_I(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;II)V
    .locals 9

    const/4 v0, 0x0

    .line 334
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 335
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 337
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    const-wide/16 v3, 0x0

    move v5, v0

    :goto_1
    if-ge v5, p2, :cond_0

    .line 340
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v6, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    aget-object v6, v6, v5

    iget-object v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v7, v6, v1

    add-double/2addr v3, v7

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    .line 342
    :cond_0
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v6, p3, 0x1

    int-to-double v7, p2

    div-double/2addr v3, v7

    aput-wide v3, v5, p3

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v1, v1, 0x1

    move p3, v6

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$Ar--_zjdIGgFxRAeHnhsQ2rC5yw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V
    .locals 7

    const/4 v0, 0x0

    .line 296
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 297
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 299
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    const/4 v3, 0x0

    move v4, v0

    :goto_1
    if-ge v4, p2, :cond_0

    .line 302
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v5, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    aget-object v5, v5, v4

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v5, v5, v1

    add-float/2addr v3, v5

    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    .line 304
    :cond_0
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v5, p3, 0x1

    int-to-float v6, p2

    div-float/2addr v3, v6

    aput v3, v4, p3

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v1, v1, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$CkqFFBMQnpUL_qu3fIK-S_rzbAk(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;II)V
    .locals 6

    const/4 v0, 0x0

    .line 106
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 107
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 109
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    move v3, v0

    move v4, v3

    :goto_1
    if-ge v3, p2, :cond_0

    .line 112
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v5, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    aget-object v5, v5, v3

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v5, v5, v1

    add-int/2addr v4, v5

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 114
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    int-to-byte v4, v4

    aput-byte v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v1, v1, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$DNGKJhP51LGsE8kCGUrfQ0goswc(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;II)V
    .locals 6

    const/4 v0, 0x0

    .line 220
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 221
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 223
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    move v3, v0

    move v4, v3

    :goto_1
    if-ge v3, p2, :cond_0

    .line 226
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v5, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    aget-object v5, v5, v3

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v5, v5, v1

    add-int/2addr v4, v5

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 228
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    aput v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v1, v1, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$EPsbTrbjZT6Z-ss6cSVk_0SN_G4(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II)V
    .locals 7

    const/4 v0, 0x0

    .line 144
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 145
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 147
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    move v3, v0

    move v4, v3

    :goto_1
    if-ge v3, p2, :cond_0

    .line 150
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v5, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    aget-object v5, v5, v3

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v5, v5, v1

    const v6, 0xffff

    and-int/2addr v5, v6

    add-int/2addr v4, v5

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 152
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    int-to-short v4, v4

    aput-short v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v1, v1, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$OzX5-KtHfsVgdBkYe6YqfHc6yD0(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I)V
    .locals 6

    const/4 v0, 0x0

    .line 283
    invoke-virtual {p0, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 284
    invoke-virtual {p1, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p5

    .line 286
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_0

    .line 287
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v2, v2, v1

    .line 288
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v3, v3, v1

    add-float/2addr v2, v3

    .line 289
    iget-object v3, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v3, v3, v1

    add-float/2addr v2, v3

    .line 291
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v4, p5, 0x1

    const/high16 v5, 0x40400000    # 3.0f

    div-float/2addr v2, v5

    aput v2, v3, p5

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    move p5, v4

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$_7R9Zu1qeVnHN210XL-OdWiyD4Y(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;I)V
    .locals 8

    const/4 v0, 0x0

    .line 321
    invoke-virtual {p0, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 322
    invoke-virtual {p1, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p5

    .line 324
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_0

    .line 325
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v3, v2, v1

    .line 326
    iget-object v2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v5, v2, v1

    add-double/2addr v3, v5

    .line 327
    iget-object v2, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v5, v2, v1

    add-double/2addr v3, v5

    .line 329
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v5, p5, 0x1

    const-wide/high16 v6, 0x4008000000000000L    # 3.0

    div-double/2addr v3, v6

    aput-wide v3, v2, p5

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    move p5, v5

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$_ANHPtn-U9-8-VSVtPPVfcAaCFA(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 6

    const/4 v0, 0x0

    .line 68
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 69
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 71
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    move v3, v0

    move v4, v3

    :goto_1
    if-ge v3, p2, :cond_0

    .line 74
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v5, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    aget-object v5, v5, v3

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v5, v5, v1

    and-int/lit16 v5, v5, 0xff

    add-int/2addr v4, v5

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 76
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    int-to-byte v4, v4

    aput-byte v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v1, v1, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$cLostc2k0_cZ3k3VNlRsPA01Zoo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I)V
    .locals 5

    const/4 v0, 0x0

    .line 207
    invoke-virtual {p0, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 208
    invoke-virtual {p1, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p5

    .line 210
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_0

    .line 211
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v2, v2, v1

    .line 212
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v3, v3, v1

    add-int/2addr v2, v3

    .line 213
    iget-object v3, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v3, v3, v1

    add-int/2addr v2, v3

    .line 215
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v4, p5, 0x1

    div-int/lit8 v2, v2, 0x3

    aput v2, v3, p5

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    move p5, v4

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$iTbMCq5AiGra-icD5ZVMw52XWZM(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;I)V
    .locals 8

    const/4 v0, 0x0

    .line 245
    invoke-virtual {p0, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 246
    invoke-virtual {p1, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p5

    .line 248
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_0

    .line 249
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v3, v2, v1

    .line 250
    iget-object v2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v5, v2, v1

    add-long/2addr v3, v5

    .line 251
    iget-object v2, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v5, v2, v1

    add-long/2addr v3, v5

    .line 253
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v5, p5, 0x1

    const-wide/16 v6, 0x3

    div-long/2addr v3, v6

    aput-wide v3, v2, p5

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    move p5, v5

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$lN3R2hYQYCMVibOhGHaFilMjqx8(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I)V
    .locals 5

    const/4 v0, 0x0

    .line 93
    invoke-virtual {p0, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 94
    invoke-virtual {p1, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p5

    .line 96
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_0

    .line 97
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v2, v2, v1

    .line 98
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v3, v3, v1

    add-int/2addr v2, v3

    .line 99
    iget-object v3, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v3, v3, v1

    add-int/2addr v2, v3

    .line 101
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v4, p5, 0x1

    div-int/lit8 v2, v2, 0x3

    int-to-byte v2, v2

    aput-byte v2, v3, p5

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    move p5, v4

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$sG6sABLv7fUAxFH2BFt05jSA01k(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;II)V
    .locals 6

    const/4 v0, 0x0

    .line 182
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 183
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 185
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    move v3, v0

    move v4, v3

    :goto_1
    if-ge v3, p2, :cond_0

    .line 188
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v5, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    aget-object v5, v5, v3

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v5, v5, v1

    add-int/2addr v4, v5

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 190
    :cond_0
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v5, p3, 0x1

    div-int/2addr v4, p2

    int-to-short v4, v4

    aput-short v4, v3, p3

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v1, v1, 0x1

    move p3, v5

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$tb4hQSOdMkaxqRfM-GeYnZnTAPg(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I)V
    .locals 5

    const/4 v0, 0x0

    .line 169
    invoke-virtual {p0, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 170
    invoke-virtual {p1, v0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p5

    .line 172
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v0, v2, :cond_0

    .line 173
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v2, v2, v1

    .line 174
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v3, v3, v1

    add-int/2addr v2, v3

    .line 175
    iget-object v3, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v3, v3, v1

    add-int/2addr v2, v3

    .line 177
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v4, p5, 0x1

    div-int/lit8 v2, v2, 0x3

    int-to-short v2, v2

    aput-short v2, v3, p5

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    move p5, v4

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$yf8qdaHiVZb2SdvrxPrFPpwWF2s(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;II)V
    .locals 9

    const/4 v0, 0x0

    .line 258
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v1

    .line 259
    invoke-virtual {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p3

    move v2, v0

    .line 261
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v3, :cond_1

    const-wide/16 v3, 0x0

    move v5, v0

    :goto_1
    if-ge v5, p2, :cond_0

    .line 264
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v6, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    aget-object v6, v6, v5

    iget-object v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v7, v6, v1

    add-long/2addr v3, v7

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    .line 266
    :cond_0
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v6, p3, 0x1

    int-to-long v7, p2

    div-long/2addr v3, v7

    aput-wide v3, v5, p3

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v1, v1, 0x1

    move p3, v6

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 9

    .line 273
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 276
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_1

    .line 278
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 279
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v7, v0

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    const/4 v0, 0x2

    .line 280
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 282
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda4;

    move-object v4, p0

    move-object v5, p1

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    invoke-static {v1, v0, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_1
    move-object v4, p0

    move-object v5, p1

    .line 295
    iget p0, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda5;

    invoke-direct {p1, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I)V

    invoke-static {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V
    .locals 9

    .line 311
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 314
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_1

    .line 316
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    .line 317
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v7, v0

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    const/4 v0, 0x2

    .line 318
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    .line 320
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;

    move-object v4, p0

    move-object v5, p1

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    invoke-static {v1, v0, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_1
    move-object v4, p0

    move-object v5, p1

    .line 333
    iget p0, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda1;

    invoke-direct {p1, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;I)V

    invoke-static {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V
    .locals 9

    .line 159
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 162
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_1

    .line 164
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    .line 165
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v7, v0

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    const/4 v0, 0x2

    .line 166
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    .line 168
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda6;

    move-object v4, p0

    move-object v5, p1

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda6;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V

    invoke-static {v1, v0, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_1
    move-object v4, p0

    move-object v5, p1

    .line 181
    iget p0, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda7;

    invoke-direct {p1, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda7;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I)V

    invoke-static {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V
    .locals 9

    .line 197
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 200
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_1

    .line 202
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    .line 203
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v7, v0

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    const/4 v0, 0x2

    .line 204
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    .line 206
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda10;

    move-object v4, p0

    move-object v5, p1

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda10;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V

    invoke-static {v1, v0, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_1
    move-object v4, p0

    move-object v5, p1

    .line 219
    iget p0, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda11;

    invoke-direct {p1, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda11;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I)V

    invoke-static {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V
    .locals 9

    .line 235
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 238
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_1

    .line 240
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    .line 241
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v7, v0

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    const/4 v0, 0x2

    .line 242
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    .line 244
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda14;

    move-object v4, p0

    move-object v5, p1

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda14;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    invoke-static {v1, v0, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_1
    move-object v4, p0

    move-object v5, p1

    .line 257
    iget p0, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda15;

    invoke-direct {p1, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda15;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;I)V

    invoke-static {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V
    .locals 9

    .line 83
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 86
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_1

    .line 88
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    .line 89
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v7, v0

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    const/4 v0, 0x2

    .line 90
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    .line 92
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda2;

    move-object v4, p0

    move-object v5, p1

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V

    invoke-static {v1, v0, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_1
    move-object v4, p0

    move-object v5, p1

    .line 105
    iget p0, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda3;

    invoke-direct {p1, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I)V

    invoke-static {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V
    .locals 9

    .line 121
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 124
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_1

    .line 126
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 127
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v7, v0

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    const/4 v0, 0x2

    .line 128
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 130
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda12;

    move-object v4, p0

    move-object v5, p1

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda12;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    invoke-static {v1, v0, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_1
    move-object v4, p0

    move-object v5, p1

    .line 143
    iget p0, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda13;

    invoke-direct {p1, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda13;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I)V

    invoke-static {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 9

    .line 45
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 48
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_1

    .line 50
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 51
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v7, v0

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 v0, 0x2

    .line 52
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 54
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda8;

    move-object v4, p0

    move-object v5, p1

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda8;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    invoke-static {v1, v0, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_1
    move-object v4, p0

    move-object v5, p1

    .line 67
    iget p0, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;

    invoke-direct {p1, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    invoke-static {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method
