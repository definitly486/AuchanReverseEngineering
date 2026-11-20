.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT;
.super Ljava/lang/Object;
.source "ImplPixelMath_MT.java"


# direct methods
.method public static synthetic $r8$lambda$P-XEF-FHqskfW2hyw-1M_u__JBw(IIIII[F[FI)V
    .locals 0

    mul-int/2addr p1, p7

    add-int/2addr p0, p1

    mul-int/2addr p7, p3

    add-int/2addr p2, p7

    add-int/2addr p4, p0

    :goto_0
    if-ge p0, p4, :cond_0

    .line 2970
    aget p1, p5, p0

    mul-float/2addr p1, p1

    .line 2971
    aput p1, p6, p2

    add-int/lit8 p0, p0, 0x1

    add-int/lit8 p2, p2, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$VfgOxs0KC1cevgNzA6l06kr6Fsw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V
    .locals 5

    .line 2713
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v1

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 2714
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v2

    mul-int/2addr v2, p4

    add-int/2addr v1, v2

    .line 2715
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v2

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v3

    mul-int/2addr p4, v3

    add-int/2addr v2, p4

    add-int/2addr p3, v0

    :goto_0
    if-ge v0, p3, :cond_0

    .line 2720
    iget-object p4, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v3, v3, v0

    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v4, v4, v1

    sub-float/2addr v3, v4

    aput v3, p4, v2

    add-int/lit8 v0, v0, 0x1

    add-int/lit8 v1, v1, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$naEPRi3qP48j3KNkWiVMqlxZ42A(IIIII[F[FI)V
    .locals 2

    mul-int/2addr p1, p7

    add-int/2addr p0, p1

    mul-int/2addr p7, p3

    add-int/2addr p2, p7

    add-int/2addr p4, p0

    :goto_0
    if-ge p0, p4, :cond_0

    .line 2910
    aget p1, p6, p0

    float-to-double v0, p1

    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    double-to-float p1, v0

    aput p1, p5, p2

    add-int/lit8 p0, p0, 0x1

    add-int/lit8 p2, p2, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static pow2([FII[FIIII)V
    .locals 8

    .line 2964
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT$$ExternalSyntheticLambda1;

    move-object v6, p0

    move v1, p1

    move v2, p2

    move-object v7, p3

    move v3, p4

    move v4, p5

    move v5, p7

    invoke-direct/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT$$ExternalSyntheticLambda1;-><init>(IIIII[F[F)V

    const/4 p0, 0x0

    invoke-static {p0, p6, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static sqrt([FII[FIIII)V
    .locals 8

    .line 2904
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT$$ExternalSyntheticLambda2;

    move-object v7, p0

    move v1, p1

    move v2, p2

    move-object v6, p3

    move v3, p4

    move v4, p5

    move v5, p7

    invoke-direct/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT$$ExternalSyntheticLambda2;-><init>(IIIII[F[F)V

    const/4 p0, 0x0

    invoke-static {p0, p6, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static subtract(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 3

    .line 2709
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v0

    .line 2710
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v1

    .line 2712
    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT$$ExternalSyntheticLambda0;

    invoke-direct {v2, p0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;I)V

    const/4 p0, 0x0

    invoke-static {p0, v0, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method
