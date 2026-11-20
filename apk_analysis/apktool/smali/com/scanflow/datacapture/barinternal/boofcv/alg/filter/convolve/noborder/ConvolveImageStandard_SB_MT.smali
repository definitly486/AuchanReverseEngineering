.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;
.super Ljava/lang/Object;
.source "ConvolveImageStandard_SB_MT.java"


# direct methods
.method public static synthetic $r8$lambda$CHLItFel9YWGPsJHIyOP6OGzNPo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[B[I[BIII)V
    .locals 3

    .line 500
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p10

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 501
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p10, p1

    add-int/2addr p0, p10

    add-int/2addr p3, p0

    add-int/lit8 p1, p4, -0x1

    sub-int/2addr p3, p1

    :goto_0
    if-ge p0, p3, :cond_1

    const/4 p1, 0x0

    move p10, p0

    move p2, p1

    :goto_1
    if-ge p1, p4, :cond_0

    add-int/lit8 v1, p10, 0x1

    .line 508
    aget-byte p10, p5, p10

    and-int/lit16 p10, p10, 0xff

    aget v2, p6, p1

    mul-int/2addr p10, v2

    add-int/2addr p2, p10

    add-int/lit8 p1, p1, 0x1

    move p10, v1

    goto :goto_1

    :cond_0
    add-int/lit8 p1, v0, 0x1

    add-int/2addr p2, p8

    .line 510
    div-int/2addr p2, p9

    int-to-byte p2, p2

    aput-byte p2, p7, v0

    add-int/lit8 p0, p0, 0x1

    move v0, p1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$J8J23T-tHnWcwZK07ug78yK1ZXA(II[ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I[SLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;[SIDLcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)V
    .locals 13

    move-object/from16 v0, p3

    move-object/from16 v1, p6

    const/4 v2, 0x1

    move-object/from16 v3, p11

    .line 839
    invoke-static {v3, p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I

    move-result-object v2

    move/from16 v3, p12

    move/from16 v4, p13

    :goto_0
    if-ge v3, v4, :cond_3

    const/4 v5, 0x0

    move v6, v5

    :goto_1
    if-ge v6, p1, :cond_1

    .line 842
    aget v7, p2, v6

    .line 843
    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v9, v3, p4

    add-int/2addr v9, v6

    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v9, v10

    add-int/2addr v8, v9

    move v9, v5

    :goto_2
    if-ge v9, p0, :cond_0

    .line 845
    aget v10, v2, v9

    add-int/lit8 v11, v8, 0x1

    aget-short v8, p5, v8

    const v12, 0xffff

    and-int/2addr v8, v12

    mul-int/2addr v8, v7

    add-int/2addr v10, v8

    aput v10, v2, v9

    add-int/lit8 v9, v9, 0x1

    move v8, v11

    goto :goto_2

    :cond_0
    add-int/lit8 v6, v6, 0x1

    goto :goto_1

    .line 849
    :cond_1
    iget v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v7, v3

    add-int/2addr v6, v7

    move v7, v5

    :goto_3
    if-ge v7, p0, :cond_2

    add-int/lit8 v8, v6, 0x1

    .line 851
    aget v9, v2, v7

    add-int v9, v9, p8

    int-to-double v9, v9

    mul-double v9, v9, p9

    double-to-int v9, v9

    int-to-short v9, v9

    aput-short v9, p7, v6

    add-int/lit8 v7, v7, 0x1

    move v6, v8

    goto :goto_3

    .line 853
    :cond_2
    invoke-static {v2, v5, p0, v5}, Ljava/util/Arrays;->fill([IIII)V

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static synthetic $r8$lambda$Qnl-XEX3Ijy56wcd0ebmQ31SfkQ(II[ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;[BIDLcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)V
    .locals 11

    move-object/from16 v0, p6

    const/4 v1, 0x1

    move-object/from16 v2, p11

    .line 532
    invoke-static {v2, p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I

    move-result-object v1

    move/from16 v2, p12

    move/from16 v3, p13

    :goto_0
    if-ge v2, v3, :cond_3

    const/4 v4, 0x0

    move v5, v4

    :goto_1
    if-ge v5, p1, :cond_1

    .line 535
    aget v6, p2, v5

    .line 536
    iget v7, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v8, v2, p4

    add-int/2addr v8, v5

    iget v9, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v8, v9

    add-int/2addr v7, v8

    move v8, v4

    :goto_2
    if-ge v8, p0, :cond_0

    .line 538
    aget v9, v1, v8

    add-int/lit8 v10, v7, 0x1

    aget-byte v7, p5, v7

    and-int/lit16 v7, v7, 0xff

    mul-int/2addr v7, v6

    add-int/2addr v9, v7

    aput v9, v1, v8

    add-int/lit8 v8, v8, 0x1

    move v7, v10

    goto :goto_2

    :cond_0
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    .line 542
    :cond_1
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v2

    add-int/2addr v5, v6

    move v6, v4

    :goto_3
    if-ge v6, p0, :cond_2

    add-int/lit8 v7, v5, 0x1

    .line 544
    aget v8, v1, v6

    add-int v8, v8, p8

    int-to-double v8, v8

    mul-double v8, v8, p9

    double-to-int v8, v8

    int-to-byte v8, v8

    aput-byte v8, p7, v5

    add-int/lit8 v6, v6, 0x1

    move v5, v7

    goto :goto_3

    .line 546
    :cond_2
    invoke-static {v1, v4, p0, v4}, Ljava/util/Arrays;->fill([IIII)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static synthetic $r8$lambda$e4rDyyEbyojip-b3SYDz09JSCsU(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II[S[I[SIII)V
    .locals 3

    .line 807
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p10

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 808
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p10, p1

    add-int/2addr p0, p10

    add-int/2addr p3, p0

    add-int/lit8 p1, p4, -0x1

    sub-int/2addr p3, p1

    :goto_0
    if-ge p0, p3, :cond_1

    const/4 p1, 0x0

    move p10, p0

    move p2, p1

    :goto_1
    if-ge p1, p4, :cond_0

    add-int/lit8 v1, p10, 0x1

    .line 815
    aget-short p10, p5, p10

    const v2, 0xffff

    and-int/2addr p10, v2

    aget v2, p6, p1

    mul-int/2addr p10, v2

    add-int/2addr p2, p10

    add-int/lit8 p1, p1, 0x1

    move p10, v1

    goto :goto_1

    :cond_0
    add-int/lit8 p1, v0, 0x1

    add-int/2addr p2, p8

    .line 817
    div-int/2addr p2, p9

    int-to-short p2, p2

    aput-short p2, p7, v0

    add-int/lit8 p0, p0, 0x1

    move v0, p1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$scxwqx4jadWC5F8urfRkdFBhJbE(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;[FIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[F[FI)V
    .locals 8

    .line 86
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int p0, p0, p8

    add-int/2addr v0, p0

    add-int p0, v0, p2

    const/4 v1, 0x0

    .line 87
    invoke-static {p1, v0, p0, v1}, Ljava/util/Arrays;->fill([FIIF)V

    const/4 p0, 0x0

    :goto_0
    if-ge p0, p3, :cond_1

    .line 90
    iget v1, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v2, p8, p5

    add-int/2addr v2, p0

    iget v3, p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v3

    add-int/2addr v1, v2

    add-int v2, v1, p2

    .line 93
    aget v3, p6, p0

    move v4, v0

    :goto_1
    if-ge v1, v2, :cond_0

    add-int/lit8 v5, v4, 0x1

    .line 95
    aget v6, p1, v4

    aget v7, p7, v1

    mul-float/2addr v7, v3

    add-float/2addr v6, v7

    aput v6, p1, v4

    add-int/lit8 v1, v1, 0x1

    move v4, v5

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$zoYq367_MTEaE3PKsPZz1py4LDY(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[F[F[FI)V
    .locals 3

    .line 58
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p0, p8

    add-int/2addr v0, p0

    add-int/2addr v0, p1

    .line 59
    iget p0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p8, p1

    add-int/2addr p0, p8

    add-int/2addr p3, p0

    add-int/lit8 p1, p4, -0x1

    sub-int/2addr p3, p1

    :goto_0
    if-ge p0, p3, :cond_1

    const/4 p1, 0x0

    const/4 p2, 0x0

    move p8, p0

    :goto_1
    if-ge p2, p4, :cond_0

    add-int/lit8 v1, p8, 0x1

    .line 66
    aget p8, p5, p8

    aget v2, p6, p2

    mul-float/2addr p8, v2

    add-float/2addr p1, p8

    add-int/lit8 p2, p2, 0x1

    move p8, v1

    goto :goto_1

    :cond_0
    add-int/lit8 p2, v0, 0x1

    .line 68
    aput p1, p7, v0

    add-int/lit8 p0, p0, 0x1

    move v0, p2

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 9

    .line 48
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 49
    iget-object v8, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 50
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    .line 52
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v2

    .line 53
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v5

    .line 55
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 57
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda1;

    move-object v3, p1

    move-object v1, p2

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[F[F[F)V

    const/4 p1, 0x0

    invoke-static {p1, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;I)V
    .locals 11

    .line 796
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    .line 797
    iget-object v8, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    .line 798
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 800
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v2

    .line 801
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v5

    .line 802
    div-int/lit8 v9, p3, 0x2

    .line 804
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 806
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;

    move-object v3, p1

    move-object v1, p2

    move v10, p3

    invoke-direct/range {v0 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II[S[I[SII)V

    const/4 p1, 0x0

    invoke-static {p1, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 11

    .line 489
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 490
    iget-object v8, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 491
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 493
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v2

    .line 494
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v5

    .line 495
    div-int/lit8 v9, p3, 0x2

    .line 497
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v4

    .line 499
    iget p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda4;

    move-object v3, p1

    move-object v1, p2

    move v10, p3

    invoke-direct/range {v0 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II[B[I[BII)V

    const/4 p1, 0x0

    invoke-static {p1, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 9

    .line 74
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 75
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 76
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    .line 78
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v6

    .line 79
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v4

    .line 81
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v3

    .line 82
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p0

    sub-int v0, v4, v6

    add-int/lit8 v0, v0, -0x1

    sub-int/2addr p0, v0

    .line 85
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda0;

    move-object v5, p1

    move-object v1, p2

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;[FIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I[F[F)V

    invoke-static {v6, p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 14

    move/from16 v0, p3

    .line 824
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    move-object/from16 v2, p4

    invoke-static {v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object v1

    .line 825
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    move-object/from16 v9, p2

    .line 826
    iget-object v10, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    .line 827
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 829
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v7

    .line 830
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v4

    .line 831
    div-int/lit8 v11, v0, 0x2

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    int-to-double v12, v0

    div-double v12, v2, v12

    .line 834
    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v3

    .line 835
    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p0

    sub-int v0, v4, v7

    add-int/lit8 v0, v0, -0x1

    sub-int/2addr p0, v0

    .line 838
    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda2;

    move-object v6, p1

    invoke-direct/range {v2 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda2;-><init>(II[ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I[SLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;[SID)V

    invoke-static {v7, p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 14

    move/from16 v0, p3

    .line 517
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    move-object/from16 v2, p4

    invoke-static {v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object v1

    .line 518
    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v9, p2

    .line 519
    iget-object v10, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 520
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 522
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v7

    .line 523
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v4

    .line 524
    div-int/lit8 v11, v0, 0x2

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    int-to-double v12, v0

    div-double v12, v2, v12

    .line 527
    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v3

    .line 528
    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p0

    sub-int v0, v4, v7

    add-int/lit8 v0, v0, -0x1

    sub-int/2addr p0, v0

    .line 531
    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;

    move-object v6, p1

    invoke-direct/range {v2 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;-><init>(II[ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;[BID)V

    invoke-static {v7, p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V

    return-void
.end method
