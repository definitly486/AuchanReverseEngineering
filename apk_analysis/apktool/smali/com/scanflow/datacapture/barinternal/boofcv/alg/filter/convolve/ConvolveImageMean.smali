.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageMean;
.super Ljava/lang/Object;
.source "ConvolveImageMean.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V
    .locals 2

    .line 382
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 384
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageMean;->invokeNativeHorizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;II)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    :cond_0
    const/4 v0, 0x1

    .line 387
    invoke-static {p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernel;->table1D_F32(IIZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    move-result-object v0

    .line 388
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-le p3, v1, :cond_1

    .line 389
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void

    .line 391
    :cond_1
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 392
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_2

    .line 393
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V

    return-void

    .line 395
    :cond_2
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V

    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;II)V
    .locals 2

    .line 275
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 277
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageMean;->invokeNativeHorizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;II)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 280
    :cond_0
    invoke-static {p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernel;->table1D_S32(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    move-result-object v0

    .line 281
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-le p3, v1, :cond_1

    .line 282
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    return-void

    .line 284
    :cond_1
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    .line 285
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_2

    .line 286
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;II)V

    return-void

    .line 288
    :cond_2
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;II)V

    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V
    .locals 2

    .line 61
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 63
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageMean;->invokeNativeHorizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;II)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 66
    :cond_0
    invoke-static {p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernel;->table1D_S32(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    move-result-object v0

    .line 67
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-le p3, v1, :cond_1

    .line 68
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    return-void

    .line 70
    :cond_1
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    .line 71
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_2

    .line 72
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V

    return-void

    .line 74
    :cond_2
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 2

    .line 410
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 412
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageMean;->invokeNativeVertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;II)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    :cond_0
    const/4 v0, 0x1

    .line 415
    invoke-static {p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernel;->table1D_F32(IIZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    move-result-object v0

    .line 416
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-le p3, v1, :cond_1

    .line 417
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void

    .line 419
    :cond_1
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 420
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_2

    .line 421
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void

    .line 423
    :cond_2
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 2

    .line 303
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 305
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageMean;->invokeNativeVertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;II)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 308
    :cond_0
    invoke-static {p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernel;->table1D_S32(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    move-result-object v0

    .line 309
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-le p3, v1, :cond_1

    .line 310
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    return-void

    .line 312
    :cond_1
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    .line 313
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_2

    .line 314
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void

    .line 316
    :cond_2
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 2

    .line 89
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 91
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageMean;->invokeNativeVertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;II)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 94
    :cond_0
    invoke-static {p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernel;->table1D_S32(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    move-result-object v0

    .line 95
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-le p3, v1, :cond_1

    .line 96
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    return-void

    .line 98
    :cond_1
    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    .line 99
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_2

    .line 100
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void

    .line 102
    :cond_2
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void
.end method
