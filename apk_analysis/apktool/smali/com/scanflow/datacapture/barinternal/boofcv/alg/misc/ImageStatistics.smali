.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;
.super Ljava/lang/Object;
.source "ImageStatistics.java"


# direct methods
.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F[I)V
    .locals 2

    .line 2058
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 2059
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v0, v1, :cond_0

    .line 2060
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F[I)V

    return-void

    .line 2062
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F[I)V

    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;D[I)V
    .locals 2

    .line 2353
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 2354
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v0, v1, :cond_0

    .line 2355
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;D[I)V

    return-void

    .line 2357
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;D[I)V

    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I[I)V
    .locals 2

    .line 1173
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 1174
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v0, v1, :cond_0

    .line 1175
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I[I)V

    return-void

    .line 1177
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I[I)V

    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I[I)V
    .locals 2

    .line 1468
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 1469
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v0, v1, :cond_0

    .line 1470
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I[I)V

    return-void

    .line 1472
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I[I)V

    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;J[I)V
    .locals 2

    .line 1763
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 1764
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v0, v1, :cond_0

    .line 1765
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;J[I)V

    return-void

    .line 1767
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;J[I)V

    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I[I)V
    .locals 2

    .line 595
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 596
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v0, v1, :cond_0

    .line 597
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I[I)V

    return-void

    .line 599
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I[I)V

    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I[I)V
    .locals 2

    .line 878
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 879
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v0, v1, :cond_0

    .line 880
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I[I)V

    return-void

    .line 882
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I[I)V

    return-void
.end method

.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[I)V
    .locals 2

    .line 300
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 301
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v0, v1, :cond_0

    .line 302
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[I)V

    return-void

    .line 304
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[I)V

    return-void
.end method

.method public static max(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)F
    .locals 4

    .line 1824
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int v2, v0, v1

    .line 1825
    sget-boolean v3, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v3, :cond_0

    sget v3, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v2, v3, :cond_0

    .line 1826
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static {v2, v3, v1, v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->max([FIIII)F

    move-result p0

    return p0

    .line 1828
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static {v2, v3, v1, v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->max([FIIII)F

    move-result p0

    return p0
.end method

.method public static min(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)F
    .locals 4

    .line 1794
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int v2, v0, v1

    .line 1795
    sget-boolean v3, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v3, :cond_0

    sget v3, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->SMALL_IMAGE:I

    if-lt v2, v3, :cond_0

    .line 1796
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static {v2, v3, v1, v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->min([FIIII)F

    move-result p0

    return p0

    .line 1798
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static {v2, v3, v1, v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics;->min([FIIII)F

    move-result p0

    return p0
.end method
