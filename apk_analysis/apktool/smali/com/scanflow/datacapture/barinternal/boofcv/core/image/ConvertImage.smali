.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;
.super Ljava/lang/Object;
.source "ConvertImage.java"


# direct methods
.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;
    .locals 2

    if-nez p1, :cond_0

    .line 3016
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    goto :goto_0

    .line 3018
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 3021
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 3022
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-object p1

    .line 3024
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;
    .locals 2

    if-nez p1, :cond_0

    .line 2969
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    goto :goto_0

    .line 2971
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 2974
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 2975
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-object p1

    .line 2977
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;
    .locals 2

    if-nez p1, :cond_0

    .line 3451
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;-><init>(II)V

    goto :goto_0

    .line 3453
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 3456
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 3457
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    return-object p1

    .line 3459
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;
    .locals 2

    if-nez p1, :cond_0

    .line 3404
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;-><init>(II)V

    goto :goto_0

    .line 3406
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 3409
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 3410
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    return-object p1

    .line 3412
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;
    .locals 2

    if-nez p1, :cond_0

    .line 1711
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;-><init>(II)V

    goto :goto_0

    .line 1713
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 1716
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 1717
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V

    return-object p1

    .line 1719
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;
    .locals 2

    if-nez p1, :cond_0

    .line 1664
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;-><init>(II)V

    goto :goto_0

    .line 1666
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 1669
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 1670
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V

    return-object p1

    .line 1672
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;
    .locals 2

    if-nez p1, :cond_0

    .line 2146
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;-><init>(II)V

    goto :goto_0

    .line 2148
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 2151
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 2152
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V

    return-object p1

    .line 2154
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;
    .locals 2

    if-nez p1, :cond_0

    .line 2099
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;-><init>(II)V

    goto :goto_0

    .line 2101
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 2104
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 2105
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V

    return-object p1

    .line 2107
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;
    .locals 2

    if-nez p1, :cond_0

    .line 2581
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;-><init>(II)V

    goto :goto_0

    .line 2583
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 2586
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 2587
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    return-object p1

    .line 2589
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;
    .locals 2

    if-nez p1, :cond_0

    .line 2534
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;-><init>(II)V

    goto :goto_0

    .line 2536
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 2539
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 2540
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    return-object p1

    .line 2542
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;
    .locals 2

    if-nez p1, :cond_0

    .line 841
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;-><init>(II)V

    goto :goto_0

    .line 843
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 846
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 847
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V

    return-object p1

    .line 849
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;
    .locals 2

    if-nez p1, :cond_0

    .line 794
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;-><init>(II)V

    goto :goto_0

    .line 796
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 799
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 800
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V

    return-object p1

    .line 802
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;
    .locals 2

    if-nez p1, :cond_0

    .line 1276
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;-><init>(II)V

    goto :goto_0

    .line 1278
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 1281
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 1282
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    return-object p1

    .line 1284
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;
    .locals 2

    if-nez p1, :cond_0

    .line 1229
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;-><init>(II)V

    goto :goto_0

    .line 1231
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 1234
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 1235
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    return-object p1

    .line 1237
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    if-nez p1, :cond_0

    .line 406
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;-><init>(II)V

    goto :goto_0

    .line 408
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 411
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 412
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-object p1

    .line 414
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-object p1
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    if-nez p1, :cond_0

    .line 359
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;-><init>(II)V

    goto :goto_0

    .line 361
    :cond_0
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 364
    :goto_0
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_1

    .line 365
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-object p1

    .line 367
    :cond_1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-object p1
.end method
