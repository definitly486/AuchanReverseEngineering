.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalizedNaive_SB;
.super Ljava/lang/Object;
.source "ConvolveNormalizedNaive_SB.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 12

    .line 44
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v0

    .line 46
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v1

    .line 47
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v2

    const/4 v3, 0x0

    move v4, v3

    :goto_0
    if-ge v4, v2, :cond_4

    move v5, v3

    :goto_1
    if-ge v5, v1, :cond_3

    sub-int v6, v5, v0

    .line 55
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v7

    add-int/2addr v7, v6

    if-gez v6, :cond_0

    move v6, v3

    :cond_0
    if-le v7, v1, :cond_1

    move v7, v1

    :cond_1
    const/4 v8, 0x0

    move v9, v8

    :goto_2
    if-ge v6, v7, :cond_2

    sub-int v10, v6, v5

    add-int/2addr v10, v0

    .line 61
    invoke-virtual {p0, v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->get(I)F

    move-result v10

    .line 62
    invoke-virtual {p1, v6, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->get(II)F

    move-result v11

    mul-float/2addr v11, v10

    add-float/2addr v8, v11

    add-float/2addr v9, v10

    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    :cond_2
    div-float/2addr v8, v9

    .line 65
    invoke-virtual {p2, v5, v4, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->set(IIF)V

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_3
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V
    .locals 12

    .line 688
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v0

    .line 690
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v1

    .line 691
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v2

    const/4 v3, 0x0

    move v4, v3

    :goto_0
    if-ge v4, v2, :cond_4

    move v5, v3

    :goto_1
    if-ge v5, v1, :cond_3

    sub-int v6, v5, v0

    .line 699
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v7

    add-int/2addr v7, v6

    if-gez v6, :cond_0

    move v6, v3

    :cond_0
    if-le v7, v1, :cond_1

    move v7, v1

    :cond_1
    move v8, v3

    move v9, v8

    :goto_2
    if-ge v6, v7, :cond_2

    sub-int v10, v6, v5

    add-int/2addr v10, v0

    .line 705
    invoke-virtual {p0, v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->get(I)I

    move-result v10

    .line 706
    invoke-virtual {p1, v6, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;->get(II)I

    move-result v11

    mul-int/2addr v11, v10

    add-int/2addr v8, v11

    add-int/2addr v9, v10

    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    .line 709
    :cond_2
    div-int/lit8 v6, v9, 0x2

    add-int/2addr v8, v6

    div-int/2addr v8, v9

    invoke-virtual {p2, v5, v4, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->set(III)V

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_3
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V
    .locals 12

    .line 366
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v0

    .line 368
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v1

    .line 369
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v2

    const/4 v3, 0x0

    move v4, v3

    :goto_0
    if-ge v4, v2, :cond_4

    move v5, v3

    :goto_1
    if-ge v5, v1, :cond_3

    sub-int v6, v5, v0

    .line 377
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v7

    add-int/2addr v7, v6

    if-gez v6, :cond_0

    move v6, v3

    :cond_0
    if-le v7, v1, :cond_1

    move v7, v1

    :cond_1
    move v8, v3

    move v9, v8

    :goto_2
    if-ge v6, v7, :cond_2

    sub-int v10, v6, v5

    add-int/2addr v10, v0

    .line 383
    invoke-virtual {p0, v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->get(I)I

    move-result v10

    .line 384
    invoke-virtual {p1, v6, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;->get(II)I

    move-result v11

    mul-int/2addr v11, v10

    add-int/2addr v8, v11

    add-int/2addr v9, v10

    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    .line 387
    :cond_2
    div-int/lit8 v6, v9, 0x2

    add-int/2addr v8, v6

    div-int/2addr v8, v9

    invoke-virtual {p2, v5, v4, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->set(III)V

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_3
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 12

    .line 72
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v0

    .line 74
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v1

    .line 75
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v2

    const/4 v3, 0x0

    move v4, v3

    :goto_0
    if-ge v4, v2, :cond_4

    move v5, v3

    :goto_1
    if-ge v5, v1, :cond_3

    sub-int v6, v4, v0

    .line 83
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v7

    add-int/2addr v7, v6

    if-gez v6, :cond_0

    move v6, v3

    :cond_0
    if-le v7, v2, :cond_1

    move v7, v2

    :cond_1
    const/4 v8, 0x0

    move v9, v8

    :goto_2
    if-ge v6, v7, :cond_2

    sub-int v10, v6, v4

    add-int/2addr v10, v0

    .line 89
    invoke-virtual {p0, v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->get(I)F

    move-result v10

    .line 90
    invoke-virtual {p1, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->get(II)F

    move-result v11

    mul-float/2addr v11, v10

    add-float/2addr v8, v11

    add-float/2addr v9, v10

    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    :cond_2
    div-float/2addr v8, v9

    .line 93
    invoke-virtual {p2, v5, v4, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->set(IIF)V

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_3
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V
    .locals 12

    .line 716
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v0

    .line 718
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v1

    .line 719
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v2

    const/4 v3, 0x0

    move v4, v3

    :goto_0
    if-ge v4, v2, :cond_4

    move v5, v3

    :goto_1
    if-ge v5, v1, :cond_3

    sub-int v6, v4, v0

    .line 727
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v7

    add-int/2addr v7, v6

    if-gez v6, :cond_0

    move v6, v3

    :cond_0
    if-le v7, v2, :cond_1

    move v7, v2

    :cond_1
    move v8, v3

    move v9, v8

    :goto_2
    if-ge v6, v7, :cond_2

    sub-int v10, v6, v4

    add-int/2addr v10, v0

    .line 733
    invoke-virtual {p0, v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->get(I)I

    move-result v10

    .line 734
    invoke-virtual {p1, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;->get(II)I

    move-result v11

    mul-int/2addr v11, v10

    add-int/2addr v8, v11

    add-int/2addr v9, v10

    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    .line 737
    :cond_2
    div-int/lit8 v6, v9, 0x2

    add-int/2addr v8, v6

    div-int/2addr v8, v9

    invoke-virtual {p2, v5, v4, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->set(III)V

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_3
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V
    .locals 12

    .line 394
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getOffset()I

    move-result v0

    .line 396
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v1

    .line 397
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v2

    const/4 v3, 0x0

    move v4, v3

    :goto_0
    if-ge v4, v2, :cond_4

    move v5, v3

    :goto_1
    if-ge v5, v1, :cond_3

    sub-int v6, v4, v0

    .line 405
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getWidth()I

    move-result v7

    add-int/2addr v7, v6

    if-gez v6, :cond_0

    move v6, v3

    :cond_0
    if-le v7, v2, :cond_1

    move v7, v2

    :cond_1
    move v8, v3

    move v9, v8

    :goto_2
    if-ge v6, v7, :cond_2

    sub-int v10, v6, v4

    add-int/2addr v10, v0

    .line 411
    invoke-virtual {p0, v10}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->get(I)I

    move-result v10

    .line 412
    invoke-virtual {p1, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;->get(II)I

    move-result v11

    mul-int/2addr v11, v10

    add-int/2addr v8, v11

    add-int/2addr v9, v10

    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    .line 415
    :cond_2
    div-int/lit8 v6, v9, 0x2

    add-int/2addr v8, v6

    div-int/2addr v8, v9

    invoke-virtual {p2, v5, v4, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->set(III)V

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_3
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method
