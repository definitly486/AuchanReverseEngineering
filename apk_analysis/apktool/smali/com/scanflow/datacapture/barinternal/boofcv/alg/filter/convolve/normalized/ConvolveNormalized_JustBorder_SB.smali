.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;
.super Ljava/lang/Object;
.source "ConvolveNormalized_JustBorder_SB.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 22

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 43
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 44
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 45
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    .line 47
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v6

    .line 48
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v4

    sub-int v7, v6, v4

    add-int/lit8 v8, v7, -0x1

    .line 51
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v9

    .line 52
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v10

    const/4 v12, 0x0

    :goto_0
    if-ge v12, v10, :cond_4

    .line 55
    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v12

    add-int/2addr v13, v14

    .line 56
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v12

    add-int/2addr v14, v15

    add-int v15, v14, v4

    move v11, v14

    :goto_1
    const/16 v16, 0x0

    if-ge v11, v15, :cond_1

    add-int v17, v7, v11

    sub-int v17, v17, v14

    sub-int v17, v6, v17

    move/from16 v18, v14

    move/from16 v0, v17

    move/from16 v17, v16

    :goto_2
    if-ge v0, v6, :cond_0

    .line 65
    aget v19, v5, v0

    add-float v17, v17, v19

    add-int/lit8 v20, v18, 0x1

    .line 67
    aget v18, v2, v18

    mul-float v18, v18, v19

    add-float v16, v16, v18

    add-int/lit8 v0, v0, 0x1

    move/from16 v18, v20

    goto :goto_2

    :cond_0
    add-int/lit8 v0, v13, 0x1

    div-float v16, v16, v17

    .line 69
    aput v16, v3, v13

    add-int/lit8 v11, v11, 0x1

    move v13, v0

    move-object/from16 v0, p1

    goto :goto_1

    :cond_1
    add-int v0, v4, v8

    sub-int v0, v9, v0

    add-int/2addr v11, v0

    add-int/2addr v13, v0

    add-int/2addr v14, v9

    :goto_3
    if-ge v11, v14, :cond_3

    sub-int v0, v11, v4

    sub-int v15, v14, v0

    move/from16 v17, v0

    move/from16 v18, v16

    move/from16 v19, v18

    const/4 v0, 0x0

    :goto_4
    if-ge v0, v15, :cond_2

    .line 83
    aget v20, v5, v0

    add-float v19, v19, v20

    add-int/lit8 v21, v17, 0x1

    .line 85
    aget v17, v2, v17

    mul-float v17, v17, v20

    add-float v18, v18, v17

    add-int/lit8 v0, v0, 0x1

    move/from16 v17, v21

    goto :goto_4

    :cond_2
    add-int/lit8 v0, v13, 0x1

    div-float v18, v18, v19

    .line 87
    aput v18, v3, v13

    add-int/lit8 v11, v11, 0x1

    move v13, v0

    goto :goto_3

    :cond_3
    add-int/lit8 v12, v12, 0x1

    move-object/from16 v0, p1

    goto :goto_0

    :cond_4
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V
    .locals 22

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 927
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    .line 928
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    move-object/from16 v4, p0

    .line 929
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 931
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v6

    .line 932
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v4

    sub-int v7, v6, v4

    add-int/lit8 v8, v7, -0x1

    .line 935
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v9

    .line 936
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v10

    const/4 v12, 0x0

    :goto_0
    if-ge v12, v10, :cond_4

    .line 939
    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v12

    add-int/2addr v13, v14

    .line 940
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v12

    add-int/2addr v14, v15

    add-int v15, v14, v4

    move v11, v14

    :goto_1
    const v16, 0xffff

    if-ge v11, v15, :cond_1

    add-int v17, v7, v11

    sub-int v17, v17, v14

    sub-int v17, v6, v17

    move/from16 v19, v14

    move/from16 v0, v17

    const/16 v17, 0x0

    const/16 v18, 0x0

    :goto_2
    if-ge v0, v6, :cond_0

    .line 949
    aget v20, v5, v0

    add-int v18, v18, v20

    add-int/lit8 v21, v19, 0x1

    .line 951
    aget-short v19, v2, v19

    and-int v19, v19, v16

    mul-int v19, v19, v20

    add-int v17, v17, v19

    add-int/lit8 v0, v0, 0x1

    move/from16 v19, v21

    goto :goto_2

    :cond_0
    add-int/lit8 v0, v13, 0x1

    .line 953
    div-int/lit8 v16, v18, 0x2

    add-int v17, v17, v16

    move/from16 v16, v0

    div-int v0, v17, v18

    int-to-short v0, v0

    aput-short v0, v3, v13

    add-int/lit8 v11, v11, 0x1

    move-object/from16 v0, p1

    move/from16 v13, v16

    goto :goto_1

    :cond_1
    add-int v0, v4, v8

    sub-int v0, v9, v0

    add-int/2addr v11, v0

    add-int/2addr v13, v0

    add-int/2addr v14, v9

    :goto_3
    if-ge v11, v14, :cond_3

    sub-int v0, v11, v4

    sub-int v15, v14, v0

    move/from16 v17, v0

    const/4 v0, 0x0

    const/16 v18, 0x0

    const/16 v19, 0x0

    :goto_4
    if-ge v0, v15, :cond_2

    .line 967
    aget v20, v5, v0

    add-int v19, v19, v20

    add-int/lit8 v21, v17, 0x1

    .line 969
    aget-short v17, v2, v17

    and-int v17, v17, v16

    mul-int v17, v17, v20

    add-int v18, v18, v17

    add-int/lit8 v0, v0, 0x1

    move/from16 v17, v21

    goto :goto_4

    :cond_2
    add-int/lit8 v0, v13, 0x1

    .line 971
    div-int/lit8 v15, v19, 0x2

    add-int v18, v18, v15

    div-int v15, v18, v19

    int-to-short v15, v15

    aput-short v15, v3, v13

    add-int/lit8 v11, v11, 0x1

    move v13, v0

    goto :goto_3

    :cond_3
    add-int/lit8 v12, v12, 0x1

    move-object/from16 v0, p1

    goto/16 :goto_0

    :cond_4
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V
    .locals 22

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 485
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 486
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 487
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 489
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v6

    .line 490
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v4

    sub-int v7, v6, v4

    add-int/lit8 v8, v7, -0x1

    .line 493
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v9

    .line 494
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v10

    const/4 v12, 0x0

    :goto_0
    if-ge v12, v10, :cond_4

    .line 497
    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v12

    add-int/2addr v13, v14

    .line 498
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v12

    add-int/2addr v14, v15

    add-int v15, v14, v4

    move v11, v14

    :goto_1
    if-ge v11, v15, :cond_1

    add-int v16, v7, v11

    sub-int v16, v16, v14

    sub-int v16, v6, v16

    move/from16 v18, v14

    move/from16 v0, v16

    const/16 v16, 0x0

    const/16 v17, 0x0

    :goto_2
    if-ge v0, v6, :cond_0

    .line 507
    aget v19, v5, v0

    add-int v17, v17, v19

    add-int/lit8 v20, v18, 0x1

    move/from16 v21, v0

    .line 509
    aget-byte v0, v2, v18

    and-int/lit16 v0, v0, 0xff

    mul-int v0, v0, v19

    add-int v16, v16, v0

    add-int/lit8 v0, v21, 0x1

    move/from16 v18, v20

    goto :goto_2

    :cond_0
    add-int/lit8 v0, v13, 0x1

    .line 511
    div-int/lit8 v18, v17, 0x2

    add-int v16, v16, v18

    move/from16 v18, v0

    div-int v0, v16, v17

    int-to-byte v0, v0

    aput-byte v0, v3, v13

    add-int/lit8 v11, v11, 0x1

    move-object/from16 v0, p1

    move/from16 v13, v18

    goto :goto_1

    :cond_1
    add-int v0, v4, v8

    sub-int v0, v9, v0

    add-int/2addr v11, v0

    add-int/2addr v13, v0

    add-int/2addr v14, v9

    :goto_3
    if-ge v11, v14, :cond_3

    sub-int v0, v11, v4

    sub-int v15, v14, v0

    move/from16 v16, v0

    const/4 v0, 0x0

    const/16 v17, 0x0

    const/16 v18, 0x0

    :goto_4
    if-ge v0, v15, :cond_2

    .line 525
    aget v19, v5, v0

    add-int v18, v18, v19

    add-int/lit8 v20, v16, 0x1

    move/from16 v21, v0

    .line 527
    aget-byte v0, v2, v16

    and-int/lit16 v0, v0, 0xff

    mul-int v0, v0, v19

    add-int v17, v17, v0

    add-int/lit8 v0, v21, 0x1

    move/from16 v16, v20

    goto :goto_4

    :cond_2
    add-int/lit8 v0, v13, 0x1

    .line 529
    div-int/lit8 v15, v18, 0x2

    add-int v17, v17, v15

    div-int v15, v17, v18

    int-to-byte v15, v15

    aput-byte v15, v3, v13

    add-int/lit8 v11, v11, 0x1

    move v13, v0

    goto :goto_3

    :cond_3
    add-int/lit8 v12, v12, 0x1

    move-object/from16 v0, p1

    goto/16 :goto_0

    :cond_4
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 22

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 93
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 94
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 95
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    .line 97
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v6

    .line 98
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v4

    sub-int v7, v6, v4

    add-int/lit8 v7, v7, -0x1

    .line 101
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v8

    .line 102
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v9

    sub-int v7, v9, v7

    const/4 v11, 0x0

    :goto_0
    if-ge v11, v4, :cond_3

    .line 107
    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v11

    add-int/2addr v13, v14

    .line 108
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v11

    add-int/2addr v14, v15

    add-int v15, v14, v8

    sub-int v16, v4, v11

    move/from16 v10, v16

    const/16 v17, 0x0

    :goto_1
    if-ge v10, v6, :cond_0

    .line 115
    aget v18, v5, v10

    add-float v17, v17, v18

    add-int/lit8 v10, v10, 0x1

    goto :goto_1

    :cond_0
    :goto_2
    if-ge v14, v15, :cond_2

    .line 120
    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v11

    sub-int v10, v14, v10

    move/from16 v12, v16

    const/16 v19, 0x0

    :goto_3
    if-ge v12, v6, :cond_1

    .line 122
    aget v20, v2, v10

    aget v21, v5, v12

    mul-float v20, v20, v21

    add-float v19, v19, v20

    add-int/lit8 v12, v12, 0x1

    move-object/from16 v20, v2

    .line 121
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v10, v2

    move-object/from16 v2, v20

    goto :goto_3

    :cond_1
    move-object/from16 v20, v2

    add-int/lit8 v2, v13, 0x1

    div-float v19, v19, v17

    .line 124
    aput v19, v3, v13

    add-int/lit8 v14, v14, 0x1

    move v13, v2

    move-object/from16 v2, v20

    goto :goto_2

    :cond_2
    move-object/from16 v20, v2

    add-int/lit8 v11, v11, 0x1

    goto :goto_0

    :cond_3
    move-object/from16 v20, v2

    :goto_4
    if-ge v7, v9, :cond_7

    .line 129
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v7

    add-int/2addr v2, v6

    .line 130
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v7

    add-int/2addr v6, v10

    add-int v10, v6, v8

    sub-int v11, v7, v4

    sub-int v11, v9, v11

    const/4 v12, 0x0

    const/4 v13, 0x0

    :goto_5
    if-ge v12, v11, :cond_4

    .line 137
    aget v14, v5, v12

    add-float/2addr v13, v14

    add-int/lit8 v12, v12, 0x1

    goto :goto_5

    :cond_4
    :goto_6
    if-ge v6, v10, :cond_6

    .line 142
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v4

    sub-int v12, v6, v12

    const/4 v14, 0x0

    const/4 v15, 0x0

    :goto_7
    if-ge v14, v11, :cond_5

    .line 144
    aget v16, v20, v12

    aget v17, v5, v14

    mul-float v16, v16, v17

    add-float v15, v15, v16

    add-int/lit8 v14, v14, 0x1

    .line 143
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v12, v1

    move-object/from16 v1, p2

    goto :goto_7

    :cond_5
    add-int/lit8 v1, v2, 0x1

    div-float/2addr v15, v13

    .line 146
    aput v15, v3, v2

    add-int/lit8 v6, v6, 0x1

    move v2, v1

    move-object/from16 v1, p2

    goto :goto_6

    :cond_6
    add-int/lit8 v7, v7, 0x1

    move-object/from16 v1, p2

    goto :goto_4

    :cond_7
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V
    .locals 22

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 977
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    .line 978
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    move-object/from16 v4, p0

    .line 979
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 981
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v6

    .line 982
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v4

    sub-int v7, v6, v4

    add-int/lit8 v7, v7, -0x1

    .line 985
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v8

    .line 986
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v9

    sub-int v7, v9, v7

    const/4 v11, 0x0

    :goto_0
    if-ge v11, v4, :cond_3

    .line 991
    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v11

    add-int/2addr v13, v14

    .line 992
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v11

    add-int/2addr v14, v15

    add-int v15, v14, v8

    sub-int v16, v4, v11

    move/from16 v10, v16

    const/16 v17, 0x0

    :goto_1
    if-ge v10, v6, :cond_0

    .line 999
    aget v18, v5, v10

    add-int v17, v17, v18

    add-int/lit8 v10, v10, 0x1

    goto :goto_1

    :cond_0
    :goto_2
    if-ge v14, v15, :cond_2

    .line 1004
    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v11

    sub-int v10, v14, v10

    move/from16 v12, v16

    const v18, 0xffff

    const/16 v19, 0x0

    :goto_3
    if-ge v12, v6, :cond_1

    .line 1006
    aget-short v20, v2, v10

    and-int v20, v20, v18

    aget v21, v5, v12

    mul-int v20, v20, v21

    add-int v19, v19, v20

    add-int/lit8 v12, v12, 0x1

    move-object/from16 v20, v2

    .line 1005
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v10, v2

    move-object/from16 v2, v20

    goto :goto_3

    :cond_1
    move-object/from16 v20, v2

    add-int/lit8 v2, v13, 0x1

    .line 1008
    div-int/lit8 v10, v17, 0x2

    add-int v19, v19, v10

    div-int v10, v19, v17

    int-to-short v10, v10

    aput-short v10, v3, v13

    add-int/lit8 v14, v14, 0x1

    move v13, v2

    move-object/from16 v2, v20

    goto :goto_2

    :cond_2
    move-object/from16 v20, v2

    add-int/lit8 v11, v11, 0x1

    goto :goto_0

    :cond_3
    move-object/from16 v20, v2

    const v18, 0xffff

    :goto_4
    if-ge v7, v9, :cond_7

    .line 1013
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v7

    add-int/2addr v2, v6

    .line 1014
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v7

    add-int/2addr v6, v10

    add-int v10, v6, v8

    sub-int v11, v7, v4

    sub-int v11, v9, v11

    const/4 v12, 0x0

    const/4 v13, 0x0

    :goto_5
    if-ge v12, v11, :cond_4

    .line 1021
    aget v14, v5, v12

    add-int/2addr v13, v14

    add-int/lit8 v12, v12, 0x1

    goto :goto_5

    :cond_4
    :goto_6
    if-ge v6, v10, :cond_6

    .line 1026
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v4

    sub-int v12, v6, v12

    const/4 v14, 0x0

    const/4 v15, 0x0

    :goto_7
    if-ge v14, v11, :cond_5

    .line 1028
    aget-short v16, v20, v12

    and-int v16, v16, v18

    aget v17, v5, v14

    mul-int v16, v16, v17

    add-int v15, v15, v16

    add-int/lit8 v14, v14, 0x1

    .line 1027
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v12, v1

    move-object/from16 v1, p2

    goto :goto_7

    :cond_5
    add-int/lit8 v1, v2, 0x1

    .line 1030
    div-int/lit8 v12, v13, 0x2

    add-int/2addr v15, v12

    div-int/2addr v15, v13

    int-to-short v12, v15

    aput-short v12, v3, v2

    add-int/lit8 v6, v6, 0x1

    move v2, v1

    move-object/from16 v1, p2

    goto :goto_6

    :cond_6
    add-int/lit8 v7, v7, 0x1

    move-object/from16 v1, p2

    goto :goto_4

    :cond_7
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V
    .locals 21

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 535
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 536
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 537
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    .line 539
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v6

    .line 540
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v4

    sub-int v7, v6, v4

    add-int/lit8 v7, v7, -0x1

    .line 543
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v8

    .line 544
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v9

    sub-int v7, v9, v7

    const/4 v11, 0x0

    :goto_0
    if-ge v11, v4, :cond_3

    .line 549
    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v13, v11

    add-int/2addr v12, v13

    .line 550
    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v11

    add-int/2addr v13, v14

    add-int v14, v13, v8

    sub-int v15, v4, v11

    move v10, v15

    const/16 v16, 0x0

    :goto_1
    if-ge v10, v6, :cond_0

    .line 557
    aget v17, v5, v10

    add-int v16, v16, v17

    add-int/lit8 v10, v10, 0x1

    goto :goto_1

    :cond_0
    :goto_2
    if-ge v13, v14, :cond_2

    .line 562
    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v11

    sub-int v10, v13, v10

    move-object/from16 v17, v2

    move v2, v15

    const/16 v18, 0x0

    :goto_3
    if-ge v2, v6, :cond_1

    move/from16 v19, v2

    .line 564
    aget-byte v2, v17, v10

    and-int/lit16 v2, v2, 0xff

    aget v20, v5, v19

    mul-int v2, v2, v20

    add-int v18, v18, v2

    add-int/lit8 v2, v19, 0x1

    move/from16 v19, v2

    .line 563
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v10, v2

    move/from16 v2, v19

    goto :goto_3

    :cond_1
    add-int/lit8 v2, v12, 0x1

    .line 566
    div-int/lit8 v10, v16, 0x2

    add-int v18, v18, v10

    div-int v10, v18, v16

    int-to-byte v10, v10

    aput-byte v10, v3, v12

    add-int/lit8 v13, v13, 0x1

    move v12, v2

    move-object/from16 v2, v17

    goto :goto_2

    :cond_2
    move-object/from16 v17, v2

    add-int/lit8 v11, v11, 0x1

    goto :goto_0

    :cond_3
    move-object/from16 v17, v2

    :goto_4
    if-ge v7, v9, :cond_7

    .line 571
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v7

    add-int/2addr v2, v6

    .line 572
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v7

    add-int/2addr v6, v10

    add-int v10, v6, v8

    sub-int v11, v7, v4

    sub-int v11, v9, v11

    const/4 v12, 0x0

    const/4 v13, 0x0

    :goto_5
    if-ge v12, v11, :cond_4

    .line 579
    aget v14, v5, v12

    add-int/2addr v13, v14

    add-int/lit8 v12, v12, 0x1

    goto :goto_5

    :cond_4
    :goto_6
    if-ge v6, v10, :cond_6

    .line 584
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v4

    sub-int v12, v6, v12

    const/4 v14, 0x0

    const/4 v15, 0x0

    :goto_7
    if-ge v14, v11, :cond_5

    .line 586
    aget-byte v1, v17, v12

    and-int/lit16 v1, v1, 0xff

    aget v16, v5, v14

    mul-int v1, v1, v16

    add-int/2addr v15, v1

    add-int/lit8 v14, v14, 0x1

    .line 585
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v12, v1

    move-object/from16 v1, p2

    goto :goto_7

    :cond_5
    add-int/lit8 v1, v2, 0x1

    .line 588
    div-int/lit8 v12, v13, 0x2

    add-int/2addr v15, v12

    div-int/2addr v15, v13

    int-to-byte v12, v15

    aput-byte v12, v3, v2

    add-int/lit8 v6, v6, 0x1

    move v2, v1

    move-object/from16 v1, p2

    goto :goto_6

    :cond_6
    add-int/lit8 v7, v7, 0x1

    move-object/from16 v1, p2

    goto :goto_4

    :cond_7
    return-void
.end method
