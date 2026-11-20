.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;
.super Ljava/lang/Object;
.source "KernelMath.java"


# direct methods
.method public static convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;F)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;
    .locals 3

    .line 569
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;-><init>(II)V

    .line 570
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    invoke-static {v1, v2, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->convert([F[IIF)V

    return-object v0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;
    .locals 3

    .line 577
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;-><init>(II)V

    .line 578
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;->data:[D

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    invoke-static {v1, v2, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->convert([D[IID)V

    return-object v0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;F)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_S32;
    .locals 3

    .line 562
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_S32;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_S32;-><init>(I)V

    .line 563
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;->data:[F

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_S32;->data:[I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    mul-int/2addr p0, p0

    invoke-static {v1, v2, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->convert([F[IIF)V

    return-object v0
.end method

.method public static convert([D[IID)V
    .locals 3

    .line 593
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->maxAbs([DI)D

    move-result-wide v0

    mul-double/2addr v0, p3

    .line 594
    invoke-static {p0, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->minAbs([DID)D

    move-result-wide p3

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p2, :cond_0

    .line 597
    aget-wide v1, p0, v0

    div-double/2addr v1, p3

    double-to-int v1, v1

    aput v1, p1, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static convert([F[IIF)V
    .locals 2

    .line 584
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->maxAbs([FI)F

    move-result v0

    mul-float/2addr v0, p3

    .line 585
    invoke-static {p0, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->minAbs([FIF)F

    move-result p3

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p2, :cond_0

    .line 588
    aget v1, p0, v0

    div-float/2addr v1, p3

    float-to-int v1, v1

    aput v1, p1, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static convolve2D(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;
    .locals 10

    .line 342
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    if-ne v0, v1, :cond_3

    .line 344
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    div-int/lit8 v1, v1, 0x2

    if-ne v2, v1, :cond_2

    .line 349
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;

    invoke-direct {v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;-><init>(I)V

    const/4 v2, 0x0

    move v3, v2

    move v4, v3

    :goto_0
    if-ge v3, v0, :cond_1

    move v5, v2

    :goto_1
    if-ge v5, v0, :cond_0

    .line 354
    iget-object v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;->data:[F

    add-int/lit8 v7, v4, 0x1

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    aget v8, v8, v3

    iget-object v9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    aget v9, v9, v5

    mul-float/2addr v8, v9

    aput v8, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v7

    goto :goto_1

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return-object v1

    .line 345
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Only kernels with the offset in the middle supported"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 343
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Only kernels with the same width supported"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convolve2D(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;
    .locals 13

    .line 369
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    if-ne v0, v1, :cond_3

    .line 371
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    div-int/lit8 v1, v1, 0x2

    if-ne v2, v1, :cond_2

    .line 376
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;

    invoke-direct {v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;-><init>(I)V

    const/4 v2, 0x0

    move v3, v2

    move v4, v3

    :goto_0
    if-ge v3, v0, :cond_1

    move v5, v2

    :goto_1
    if-ge v5, v0, :cond_0

    .line 381
    iget-object v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;->data:[D

    add-int/lit8 v7, v4, 0x1

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;->data:[D

    aget-wide v9, v8, v3

    iget-object v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;->data:[D

    aget-wide v11, v8, v5

    mul-double/2addr v9, v11

    aput-wide v9, v6, v4

    add-int/lit8 v5, v5, 0x1

    move v4, v7

    goto :goto_1

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return-object v1

    .line 372
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Only kernels with the offset in the middle supported"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 370
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Only kernels with the same width supported"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static maxAbs([DI)D
    .locals 6

    const-wide/16 v0, 0x0

    const/4 v2, 0x0

    :goto_0
    if-ge v2, p1, :cond_1

    .line 615
    aget-wide v3, p0, v2

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v3

    cmpl-double v5, v3, v0

    if-lez v5, :cond_0

    move-wide v0, v3

    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-wide v0
.end method

.method public static maxAbs([FI)F
    .locals 4

    const/4 v0, 0x0

    const/4 v1, 0x0

    :goto_0
    if-ge v1, p1, :cond_1

    .line 604
    aget v2, p0, v1

    invoke-static {v2}, Ljava/lang/Math;->abs(F)F

    move-result v2

    cmpl-float v3, v2, v0

    if-lez v3, :cond_0

    move v0, v2

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return v0
.end method

.method public static minAbs([DID)D
    .locals 6

    const-wide v0, 0x47efffffe0000000L    # 3.4028234663852886E38

    const/4 v2, 0x0

    :goto_0
    if-ge v2, p1, :cond_1

    .line 637
    aget-wide v3, p0, v2

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v3

    cmpg-double v5, v3, v0

    if-gez v5, :cond_0

    cmpl-double v5, v3, p2

    if-ltz v5, :cond_0

    move-wide v0, v3

    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-wide v0
.end method

.method public static minAbs([FIF)F
    .locals 4

    const v0, 0x7f7fffff    # Float.MAX_VALUE

    const/4 v1, 0x0

    :goto_0
    if-ge v1, p1, :cond_1

    .line 626
    aget v2, p0, v1

    invoke-static {v2}, Ljava/lang/Math;->abs(F)F

    move-result v2

    cmpg-float v3, v2, v0

    if-gez v3, :cond_0

    cmpl-float v3, v2, p2

    if-ltz v3, :cond_0

    move v0, v2

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return v0
.end method

.method public static normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;)V
    .locals 4

    .line 422
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v0, 0x0

    const/4 v1, 0x0

    move v2, v1

    .line 424
    :goto_0
    array-length v3, p0

    if-ge v2, v3, :cond_0

    aget v3, p0, v2

    add-float/2addr v0, v3

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 425
    :cond_0
    :goto_1
    array-length v2, p0

    if-ge v1, v2, :cond_1

    aget v2, p0, v1

    div-float/2addr v2, v0

    aput v2, p0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method

.method public static normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;)V
    .locals 6

    .line 430
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;->data:[D

    const-wide/16 v0, 0x0

    const/4 v2, 0x0

    move v3, v2

    .line 432
    :goto_0
    array-length v4, p0

    if-ge v3, v4, :cond_0

    aget-wide v4, p0, v3

    add-double/2addr v0, v4

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 433
    :cond_0
    :goto_1
    array-length v3, p0

    if-ge v2, v3, :cond_1

    aget-wide v3, p0, v2

    div-double/2addr v3, v0

    aput-wide v3, p0, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method

.method public static normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;)V
    .locals 4

    .line 443
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;->data:[F

    const/4 v0, 0x0

    const/4 v1, 0x0

    move v2, v1

    .line 445
    :goto_0
    array-length v3, p0

    if-ge v2, v3, :cond_0

    aget v3, p0, v2

    add-float/2addr v0, v3

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 446
    :cond_0
    :goto_1
    array-length v2, p0

    if-ge v1, v2, :cond_1

    aget v2, p0, v1

    div-float/2addr v2, v0

    aput v2, p0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method

.method public static normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;)V
    .locals 6

    .line 451
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;->data:[D

    const-wide/16 v0, 0x0

    const/4 v2, 0x0

    move v3, v2

    .line 453
    :goto_0
    array-length v4, p0

    if-ge v3, v4, :cond_0

    aget-wide v4, p0, v3

    add-double/2addr v0, v4

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 454
    :cond_0
    :goto_1
    array-length v3, p0

    if-ge v2, v3, :cond_1

    aget-wide v3, p0, v2

    div-double/2addr v3, v0

    aput-wide v3, p0, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method
