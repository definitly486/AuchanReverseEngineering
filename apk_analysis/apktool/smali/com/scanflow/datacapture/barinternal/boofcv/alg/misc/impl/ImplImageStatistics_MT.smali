.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;
.super Ljava/lang/Object;
.source "ImplImageStatistics_MT.java"


# direct methods
.method public static synthetic $r8$lambda$-iVURLV8Z4H1yb530Lg0lTfIzJ8([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILjava/util/List;II)V
    .locals 4

    .line 182
    array-length p0, p0

    new-array p0, p0, [I

    :goto_0
    if-ge p4, p5, :cond_1

    .line 184
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 185
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v1, v0

    :goto_1
    if-ge v0, v1, :cond_0

    .line 188
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v0, 0x1

    aget-byte v0, v2, v0

    and-int/lit16 v0, v0, 0xff

    sub-int/2addr v0, p2

    aget v2, p0, v0

    add-int/lit8 v2, v2, 0x1

    aput v2, p0, v0

    move v0, v3

    goto :goto_1

    :cond_0
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    .line 191
    :cond_1
    monitor-enter p3

    :try_start_0
    invoke-interface {p3, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    monitor-exit p3

    return-void

    :catchall_0
    move-exception p0

    monitor-exit p3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static synthetic $r8$lambda$2JuCKKLRen0CqBCzEB5-MRIvo3Q([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILjava/util/List;II)V
    .locals 4

    .line 588
    array-length p0, p0

    new-array p0, p0, [I

    :goto_0
    if-ge p4, p5, :cond_1

    .line 590
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 591
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v1, v0

    :goto_1
    if-ge v0, v1, :cond_0

    .line 594
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v3, v0, 0x1

    aget-short v0, v2, v0

    const v2, 0xffff

    and-int/2addr v0, v2

    sub-int/2addr v0, p2

    aget v2, p0, v0

    add-int/lit8 v2, v2, 0x1

    aput v2, p0, v0

    move v0, v3

    goto :goto_1

    :cond_0
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    .line 597
    :cond_1
    monitor-enter p3

    :try_start_0
    invoke-interface {p3, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    monitor-exit p3

    return-void

    :catchall_0
    move-exception p0

    monitor-exit p3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static synthetic $r8$lambda$Ifo38Oyzb6vYr3Dy4hYaGFtkW0k(FIII[FI)Ljava/lang/Number;
    .locals 0

    mul-int/2addr p5, p2

    add-int/2addr p1, p5

    add-int/2addr p3, p1

    :goto_0
    if-ge p1, p3, :cond_1

    .line 1319
    aget p2, p4, p1

    cmpl-float p5, p2, p0

    if-lez p5, :cond_0

    move p0, p2

    :cond_0
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    .line 1323
    :cond_1
    invoke-static {p0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$NE3z2Mmek2Gc6lBVnF4UAyqTLOA([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;ILjava/util/List;II)V
    .locals 4

    .line 402
    array-length p0, p0

    new-array p0, p0, [I

    :goto_0
    if-ge p4, p5, :cond_1

    .line 404
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 405
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v1, v0

    :goto_1
    if-ge v0, v1, :cond_0

    .line 408
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v3, v0, 0x1

    aget-byte v0, v2, v0

    sub-int/2addr v0, p2

    aget v2, p0, v0

    add-int/lit8 v2, v2, 0x1

    aput v2, p0, v0

    move v0, v3

    goto :goto_1

    :cond_0
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    .line 411
    :cond_1
    monitor-enter p3

    :try_start_0
    invoke-interface {p3, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    monitor-exit p3

    return-void

    :catchall_0
    move-exception p0

    monitor-exit p3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static synthetic $r8$lambda$SxfqGrwqUIDCikjjzYkyxGoUVzs([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;JLjava/util/List;II)V
    .locals 6

    .line 1248
    array-length p0, p0

    new-array p0, p0, [I

    :goto_0
    if-ge p5, p6, :cond_1

    .line 1250
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p5

    add-int/2addr v0, v1

    .line 1251
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v1, v0

    :goto_1
    if-ge v0, v1, :cond_0

    .line 1254
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v3, v0, 0x1

    aget-wide v4, v2, v0

    sub-long/2addr v4, p2

    long-to-int v0, v4

    aget v2, p0, v0

    add-int/lit8 v2, v2, 0x1

    aput v2, p0, v0

    move v0, v3

    goto :goto_1

    :cond_0
    add-int/lit8 p5, p5, 0x1

    goto :goto_0

    .line 1257
    :cond_1
    monitor-enter p4

    :try_start_0
    invoke-interface {p4, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    monitor-exit p4

    return-void

    :catchall_0
    move-exception p0

    monitor-exit p4
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static synthetic $r8$lambda$dOZHSPvt4OfgkPo1xU_o5P9l6lw([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;ILjava/util/List;II)V
    .locals 4

    .line 808
    array-length p0, p0

    new-array p0, p0, [I

    :goto_0
    if-ge p4, p5, :cond_1

    .line 810
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 811
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v1, v0

    :goto_1
    if-ge v0, v1, :cond_0

    .line 814
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v3, v0, 0x1

    aget-short v0, v2, v0

    sub-int/2addr v0, p2

    aget v2, p0, v0

    add-int/lit8 v2, v2, 0x1

    aput v2, p0, v0

    move v0, v3

    goto :goto_1

    :cond_0
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    .line 817
    :cond_1
    monitor-enter p3

    :try_start_0
    invoke-interface {p3, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    monitor-exit p3

    return-void

    :catchall_0
    move-exception p0

    monitor-exit p3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static synthetic $r8$lambda$n_GBbAl50qfnKR1JUvf7kq1pJV0([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;ILjava/util/List;II)V
    .locals 4

    .line 1028
    array-length p0, p0

    new-array p0, p0, [I

    :goto_0
    if-ge p4, p5, :cond_1

    .line 1030
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 1031
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v1, v0

    :goto_1
    if-ge v0, v1, :cond_0

    .line 1034
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v3, v0, 0x1

    aget v0, v2, v0

    sub-int/2addr v0, p2

    aget v2, p0, v0

    add-int/lit8 v2, v2, 0x1

    aput v2, p0, v0

    move v0, v3

    goto :goto_1

    :cond_0
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    .line 1037
    :cond_1
    monitor-enter p3

    :try_start_0
    invoke-interface {p3, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    monitor-exit p3

    return-void

    :catchall_0
    move-exception p0

    monitor-exit p3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static synthetic $r8$lambda$qPA5jK21VYOYfHMMxm2UAt6wLBY(FIII[FI)Ljava/lang/Number;
    .locals 0

    mul-int/2addr p5, p2

    add-int/2addr p1, p5

    add-int/2addr p3, p1

    :goto_0
    if-ge p1, p3, :cond_1

    .line 1302
    aget p2, p4, p1

    cmpg-float p5, p2, p0

    if-gez p5, :cond_0

    move p0, p2

    :cond_0
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    .line 1306
    :cond_1
    invoke-static {p0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$se-FM4OZH0Rxb_glzen62pFmbQg([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;FLjava/util/List;II)V
    .locals 4

    .line 1468
    array-length p0, p0

    new-array p0, p0, [I

    :goto_0
    if-ge p4, p5, :cond_1

    .line 1470
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 1471
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v1, v0

    :goto_1
    if-ge v0, v1, :cond_0

    .line 1474
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v3, v0, 0x1

    aget v0, v2, v0

    sub-float/2addr v0, p2

    float-to-int v0, v0

    aget v2, p0, v0

    add-int/lit8 v2, v2, 0x1

    aput v2, p0, v0

    move v0, v3

    goto :goto_1

    :cond_0
    add-int/lit8 p4, p4, 0x1

    goto :goto_0

    .line 1477
    :cond_1
    monitor-enter p3

    :try_start_0
    invoke-interface {p3, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    monitor-exit p3

    return-void

    :catchall_0
    move-exception p0

    monitor-exit p3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static synthetic $r8$lambda$zBY4b7_WFRxGm_wUPUzQ9a9PVY8([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;DLjava/util/List;II)V
    .locals 6

    .line 1688
    array-length p0, p0

    new-array p0, p0, [I

    :goto_0
    if-ge p5, p6, :cond_1

    .line 1690
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, p5

    add-int/2addr v0, v1

    .line 1691
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v1, v0

    :goto_1
    if-ge v0, v1, :cond_0

    .line 1694
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v3, v0, 0x1

    aget-wide v4, v2, v0

    sub-double/2addr v4, p2

    double-to-int v0, v4

    aget v2, p0, v0

    add-int/lit8 v2, v2, 0x1

    aput v2, p0, v0

    move v0, v3

    goto :goto_1

    :cond_0
    add-int/lit8 p5, p5, 0x1

    goto :goto_0

    .line 1697
    :cond_1
    monitor-enter p4

    :try_start_0
    invoke-interface {p4, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    monitor-exit p4

    return-void

    :catchall_0
    move-exception p0

    monitor-exit p4
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F[I)V
    .locals 5

    const/4 v0, 0x0

    .line 1464
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 1466
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 1467
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda2;

    invoke-direct {v3, p2, p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda2;-><init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;FLjava/util/List;)V

    invoke-static {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    move p0, v0

    .line 1478
    :goto_0
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result p1

    if-ge p0, p1, :cond_1

    .line 1479
    invoke-interface {v1, p0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [I

    move v2, v0

    .line 1480
    :goto_1
    array-length v3, p2

    if-ge v2, v3, :cond_0

    .line 1481
    aget v3, p2, v2

    aget v4, p1, v2

    add-int/2addr v3, v4

    aput v3, p2, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;D[I)V
    .locals 8

    const/4 v0, 0x0

    .line 1684
    invoke-static {p3, v0}, Ljava/util/Arrays;->fill([II)V

    .line 1686
    new-instance v6, Ljava/util/ArrayList;

    invoke-direct {v6}, Ljava/util/ArrayList;-><init>()V

    .line 1687
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda3;

    move-object v3, p0

    move-wide v4, p1

    move-object v2, p3

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda3;-><init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;DLjava/util/List;)V

    invoke-static {v0, v7, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    move p0, v0

    .line 1698
    :goto_0
    invoke-interface {v6}, Ljava/util/List;->size()I

    move-result p1

    if-ge p0, p1, :cond_1

    .line 1699
    invoke-interface {v6, p0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [I

    move p2, v0

    .line 1700
    :goto_1
    array-length p3, v2

    if-ge p2, p3, :cond_0

    .line 1701
    aget p3, v2, p2

    aget v1, p1, p2

    add-int/2addr p3, v1

    aput p3, v2, p2

    add-int/lit8 p2, p2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 804
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 806
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 807
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda8;

    invoke-direct {v3, p2, p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda8;-><init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;ILjava/util/List;)V

    invoke-static {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    move p0, v0

    .line 818
    :goto_0
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result p1

    if-ge p0, p1, :cond_1

    .line 819
    invoke-interface {v1, p0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [I

    move v2, v0

    .line 820
    :goto_1
    array-length v3, p2

    if-ge v2, v3, :cond_0

    .line 821
    aget v3, p2, v2

    aget v4, p1, v2

    add-int/2addr v3, v4

    aput v3, p2, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 1024
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 1026
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 1027
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda9;

    invoke-direct {v3, p2, p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda9;-><init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;ILjava/util/List;)V

    invoke-static {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    move p0, v0

    .line 1038
    :goto_0
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result p1

    if-ge p0, p1, :cond_1

    .line 1039
    invoke-interface {v1, p0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [I

    move v2, v0

    .line 1040
    :goto_1
    array-length v3, p2

    if-ge v2, v3, :cond_0

    .line 1041
    aget v3, p2, v2

    aget v4, p1, v2

    add-int/2addr v3, v4

    aput v3, p2, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;J[I)V
    .locals 8

    const/4 v0, 0x0

    .line 1244
    invoke-static {p3, v0}, Ljava/util/Arrays;->fill([II)V

    .line 1246
    new-instance v6, Ljava/util/ArrayList;

    invoke-direct {v6}, Ljava/util/ArrayList;-><init>()V

    .line 1247
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;

    move-object v3, p0

    move-wide v4, p1

    move-object v2, p3

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;-><init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;JLjava/util/List;)V

    invoke-static {v0, v7, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    move p0, v0

    .line 1258
    :goto_0
    invoke-interface {v6}, Ljava/util/List;->size()I

    move-result p1

    if-ge p0, p1, :cond_1

    .line 1259
    invoke-interface {v6, p0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [I

    move p2, v0

    .line 1260
    :goto_1
    array-length p3, v2

    if-ge p2, p3, :cond_0

    .line 1261
    aget p3, v2, p2

    aget v1, p1, p2

    add-int/2addr p3, v1

    aput p3, v2, p2

    add-int/lit8 p2, p2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 398
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 400
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 401
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda0;

    invoke-direct {v3, p2, p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda0;-><init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;ILjava/util/List;)V

    invoke-static {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    move p0, v0

    .line 412
    :goto_0
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result p1

    if-ge p0, p1, :cond_1

    .line 413
    invoke-interface {v1, p0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [I

    move v2, v0

    .line 414
    :goto_1
    array-length v3, p2

    if-ge v2, v3, :cond_0

    .line 415
    aget v3, p2, v2

    aget v4, p1, v2

    add-int/2addr v3, v4

    aput v3, p2, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 584
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 586
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 587
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda6;

    invoke-direct {v3, p2, p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda6;-><init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILjava/util/List;)V

    invoke-static {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    move p0, v0

    .line 598
    :goto_0
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result p1

    if-ge p0, p1, :cond_1

    .line 599
    invoke-interface {v1, p0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [I

    move v2, v0

    .line 600
    :goto_1
    array-length v3, p2

    if-ge v2, v3, :cond_0

    .line 601
    aget v3, p2, v2

    aget v4, p1, v2

    add-int/2addr v3, v4

    aput v3, p2, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[I)V
    .locals 5

    const/4 v0, 0x0

    .line 178
    invoke-static {p2, v0}, Ljava/util/Arrays;->fill([II)V

    .line 180
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 181
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;

    invoke-direct {v3, p2, p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;-><init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILjava/util/List;)V

    invoke-static {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    move p0, v0

    .line 192
    :goto_0
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result p1

    if-ge p0, p1, :cond_1

    .line 193
    invoke-interface {v1, p0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [I

    move v2, v0

    .line 194
    :goto_1
    array-length v3, p2

    if-ge v2, v3, :cond_0

    .line 195
    aget v3, p2, v2

    aget v4, p1, v2

    add-int/2addr v3, v4

    aput v3, p2, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static max([FIIII)F
    .locals 6

    .line 1311
    aget v1, p0, p1

    .line 1313
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda4;

    move-object v5, p0

    move v2, p1

    move v4, p3

    move v3, p4

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda4;-><init>(FIII[F)V

    const/4 p0, 0x0

    sget-object p1, Ljava/lang/Float;->TYPE:Ljava/lang/Class;

    invoke-static {p0, p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->max(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)Ljava/lang/Number;

    move-result-object p0

    .line 1323
    invoke-virtual {p0}, Ljava/lang/Number;->floatValue()F

    move-result p0

    return p0
.end method

.method public static min([FIIII)F
    .locals 6

    .line 1294
    aget v1, p0, p1

    .line 1296
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda7;

    move-object v5, p0

    move v2, p1

    move v4, p3

    move v3, p4

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda7;-><init>(FIII[F)V

    const/4 p0, 0x0

    sget-object p1, Ljava/lang/Float;->TYPE:Ljava/lang/Class;

    invoke-static {p0, p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->min(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)Ljava/lang/Number;

    move-result-object p0

    .line 1306
    invoke-virtual {p0}, Ljava/lang/Number;->floatValue()F

    move-result p0

    return p0
.end method
