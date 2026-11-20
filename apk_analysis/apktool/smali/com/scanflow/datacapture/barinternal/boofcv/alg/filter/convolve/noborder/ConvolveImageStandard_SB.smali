.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB;
.super Ljava/lang/Object;
.source "ConvolveImageStandard_SB.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 18

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 48
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 49
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 50
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    .line 52
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v6

    .line 53
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v4

    .line 55
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v7

    const/4 v8, 0x0

    move v9, v8

    .line 58
    :goto_0
    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v9, v10, :cond_2

    .line 59
    iget v10, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v11, v9

    add-int/2addr v10, v11

    add-int/2addr v10, v6

    .line 60
    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v9

    add-int/2addr v11, v12

    add-int v12, v11, v7

    add-int/lit8 v13, v4, -0x1

    sub-int/2addr v12, v13

    :goto_1
    if-ge v11, v12, :cond_1

    const/4 v13, 0x0

    move v14, v8

    move v15, v11

    :goto_2
    if-ge v14, v4, :cond_0

    add-int/lit8 v16, v15, 0x1

    .line 67
    aget v15, v2, v15

    aget v17, v5, v14

    mul-float v15, v15, v17

    add-float/2addr v13, v15

    add-int/lit8 v14, v14, 0x1

    move/from16 v15, v16

    goto :goto_2

    :cond_0
    add-int/lit8 v14, v10, 0x1

    .line 69
    aput v13, v3, v10

    add-int/lit8 v11, v11, 0x1

    move v10, v14

    goto :goto_1

    :cond_1
    add-int/lit8 v9, v9, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;I)V
    .locals 19

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 846
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    .line 847
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    move-object/from16 v4, p0

    .line 848
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 850
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v6

    .line 851
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v4

    .line 852
    div-int/lit8 v7, p3, 0x2

    .line 854
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v8

    const/4 v9, 0x0

    move v10, v9

    .line 857
    :goto_0
    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v10, v11, :cond_2

    .line 858
    iget v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v10

    add-int/2addr v11, v12

    add-int/2addr v11, v6

    .line 859
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v13, v10

    add-int/2addr v12, v13

    add-int v13, v12, v8

    add-int/lit8 v14, v4, -0x1

    sub-int/2addr v13, v14

    :goto_1
    if-ge v12, v13, :cond_1

    move v14, v9

    move v15, v14

    move/from16 v16, v12

    :goto_2
    if-ge v14, v4, :cond_0

    add-int/lit8 v17, v16, 0x1

    .line 866
    aget-short v16, v2, v16

    const v18, 0xffff

    and-int v16, v16, v18

    aget v18, v5, v14

    mul-int v16, v16, v18

    add-int v15, v15, v16

    add-int/lit8 v14, v14, 0x1

    move/from16 v16, v17

    goto :goto_2

    :cond_0
    add-int/lit8 v14, v11, 0x1

    add-int/2addr v15, v7

    .line 868
    div-int v15, v15, p3

    int-to-short v15, v15

    aput-short v15, v3, v11

    add-int/lit8 v12, v12, 0x1

    move v11, v14

    goto :goto_1

    :cond_1
    add-int/lit8 v10, v10, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 18

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 521
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 522
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 523
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 525
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v6

    .line 526
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v4

    .line 527
    div-int/lit8 v7, p3, 0x2

    .line 529
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v8

    const/4 v10, 0x0

    .line 532
    :goto_0
    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v10, v11, :cond_2

    .line 533
    iget v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v10

    add-int/2addr v11, v12

    add-int/2addr v11, v6

    .line 534
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v13, v10

    add-int/2addr v12, v13

    add-int v13, v12, v8

    add-int/lit8 v14, v4, -0x1

    sub-int/2addr v13, v14

    :goto_1
    if-ge v12, v13, :cond_1

    move/from16 v16, v12

    const/4 v14, 0x0

    const/4 v15, 0x0

    :goto_2
    if-ge v14, v4, :cond_0

    add-int/lit8 v17, v16, 0x1

    .line 541
    aget-byte v9, v2, v16

    and-int/lit16 v9, v9, 0xff

    aget v16, v5, v14

    mul-int v9, v9, v16

    add-int/2addr v15, v9

    add-int/lit8 v14, v14, 0x1

    move/from16 v16, v17

    goto :goto_2

    :cond_0
    add-int/lit8 v9, v11, 0x1

    add-int/2addr v15, v7

    .line 543
    div-int v15, v15, p3

    int-to-byte v14, v15

    aput-byte v14, v3, v11

    add-int/lit8 v12, v12, 0x1

    move v11, v9

    goto :goto_1

    :cond_1
    add-int/lit8 v10, v10, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 19

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 76
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 77
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 78
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    .line 80
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v6

    .line 81
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v4

    .line 83
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v7

    .line 84
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v8

    sub-int v9, v4, v6

    add-int/lit8 v9, v9, -0x1

    sub-int/2addr v8, v9

    move v9, v6

    :goto_0
    if-ge v9, v8, :cond_2

    .line 89
    iget v10, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v11, v9

    add-int/2addr v10, v11

    add-int v11, v10, v7

    const/4 v12, 0x0

    .line 90
    invoke-static {v3, v10, v11, v12}, Ljava/util/Arrays;->fill([FIIF)V

    const/4 v11, 0x0

    :goto_1
    if-ge v11, v4, :cond_1

    .line 93
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v13, v9, v6

    add-int/2addr v13, v11

    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v13, v14

    add-int/2addr v12, v13

    add-int v13, v12, v7

    .line 96
    aget v14, v5, v11

    move v15, v10

    :goto_2
    if-ge v12, v13, :cond_0

    add-int/lit8 v16, v15, 0x1

    .line 98
    aget v17, v3, v15

    aget v18, v2, v12

    mul-float v18, v18, v14

    add-float v17, v17, v18

    aput v17, v3, v15

    add-int/lit8 v12, v12, 0x1

    move/from16 v15, v16

    goto :goto_2

    :cond_0
    add-int/lit8 v11, v11, 0x1

    goto :goto_1

    :cond_1
    add-int/lit8 v9, v9, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 20

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move/from16 v2, p3

    .line 876
    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    move-object/from16 v4, p4

    invoke-static {v4, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object v3

    .line 877
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->grow()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 878
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    .line 879
    iget-object v5, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    move-object/from16 v6, p0

    .line 880
    iget-object v7, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 882
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v8

    .line 883
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v6

    .line 884
    div-int/lit8 v9, v2, 0x2

    const-wide/high16 v10, 0x3ff0000000000000L    # 1.0

    int-to-double v12, v2

    div-double/2addr v10, v12

    .line 887
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v2

    .line 888
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v12

    sub-int v13, v6, v8

    const/4 v14, 0x1

    sub-int/2addr v13, v14

    sub-int/2addr v12, v13

    .line 893
    invoke-static {v3, v2, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I

    move-result-object v3

    move v13, v8

    :goto_0
    if-ge v13, v12, :cond_3

    const/4 v15, 0x0

    :goto_1
    if-ge v15, v6, :cond_1

    .line 896
    aget v16, v7, v15

    .line 897
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v17, v13, v8

    add-int v17, v17, v15

    move-object/from16 p4, v4

    iget v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v17, v17, v4

    add-int v14, v14, v17

    const/4 v4, 0x0

    :goto_2
    if-ge v4, v2, :cond_0

    .line 899
    aget v17, v3, v4

    add-int/lit8 v18, v14, 0x1

    aget-short v14, p4, v14

    const v19, 0xffff

    and-int v14, v14, v19

    mul-int v14, v14, v16

    add-int v17, v17, v14

    aput v17, v3, v4

    add-int/lit8 v4, v4, 0x1

    move/from16 v14, v18

    goto :goto_2

    :cond_0
    add-int/lit8 v15, v15, 0x1

    move-object/from16 v4, p4

    goto :goto_1

    :cond_1
    move-object/from16 p4, v4

    .line 903
    iget v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v13

    add-int/2addr v4, v14

    const/4 v14, 0x0

    :goto_3
    if-ge v14, v2, :cond_2

    add-int/lit8 v15, v4, 0x1

    .line 905
    aget v16, v3, v14

    add-int v0, v16, v9

    int-to-double v0, v0

    mul-double/2addr v0, v10

    double-to-int v0, v0

    int-to-short v0, v0

    aput-short v0, v5, v4

    add-int/lit8 v14, v14, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move v4, v15

    goto :goto_3

    :cond_2
    const/4 v0, 0x0

    .line 907
    invoke-static {v3, v0, v2, v0}, Ljava/util/Arrays;->fill([IIII)V

    add-int/lit8 v13, v13, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move-object/from16 v4, p4

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 19

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move/from16 v2, p3

    .line 551
    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    move-object/from16 v4, p4

    invoke-static {v4, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object v3

    .line 552
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->grow()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 553
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 554
    iget-object v5, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v6, p0

    .line 555
    iget-object v7, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 557
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v8

    .line 558
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v6

    .line 559
    div-int/lit8 v9, v2, 0x2

    const-wide/high16 v10, 0x3ff0000000000000L    # 1.0

    int-to-double v12, v2

    div-double/2addr v10, v12

    .line 562
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v2

    .line 563
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v12

    sub-int v13, v6, v8

    const/4 v14, 0x1

    sub-int/2addr v13, v14

    sub-int/2addr v12, v13

    .line 568
    invoke-static {v3, v2, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I

    move-result-object v3

    move v13, v8

    :goto_0
    if-ge v13, v12, :cond_3

    const/4 v15, 0x0

    :goto_1
    if-ge v15, v6, :cond_1

    .line 571
    aget v16, v7, v15

    .line 572
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v17, v13, v8

    add-int v17, v17, v15

    move-object/from16 p4, v4

    iget v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v17, v17, v4

    add-int v14, v14, v17

    const/4 v4, 0x0

    :goto_2
    if-ge v4, v2, :cond_0

    .line 574
    aget v17, v3, v4

    add-int/lit8 v18, v14, 0x1

    aget-byte v14, p4, v14

    and-int/lit16 v14, v14, 0xff

    mul-int v14, v14, v16

    add-int v17, v17, v14

    aput v17, v3, v4

    add-int/lit8 v4, v4, 0x1

    move/from16 v14, v18

    goto :goto_2

    :cond_0
    add-int/lit8 v15, v15, 0x1

    move-object/from16 v4, p4

    goto :goto_1

    :cond_1
    move-object/from16 p4, v4

    .line 578
    iget v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v13

    add-int/2addr v4, v14

    const/4 v14, 0x0

    :goto_3
    if-ge v14, v2, :cond_2

    add-int/lit8 v15, v4, 0x1

    .line 580
    aget v16, v3, v14

    add-int v0, v16, v9

    int-to-double v0, v0

    mul-double/2addr v0, v10

    double-to-int v0, v0

    int-to-byte v0, v0

    aput-byte v0, v5, v4

    add-int/lit8 v14, v14, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move v4, v15

    goto :goto_3

    :cond_2
    const/4 v0, 0x0

    .line 582
    invoke-static {v3, v0, v2, v0}, Ljava/util/Arrays;->fill([IIII)V

    add-int/lit8 v13, v13, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move-object/from16 v4, p4

    goto :goto_0

    :cond_3
    return-void
.end method
