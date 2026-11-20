.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNoBorder;
.super Ljava/lang/Object;
.source "ConvolveImageNoBorder.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 1

    .line 58
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->checkSameShape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 60
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 61
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 62
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void

    .line 64
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 65
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    :cond_1
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;I)V
    .locals 1

    .line 539
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->checkSameShape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 541
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 542
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;I)Z

    move-result v0

    if-nez v0, :cond_1

    .line 543
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;I)V

    return-void

    .line 545
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U16_I16_Div;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;I)Z

    move-result v0

    if-nez v0, :cond_1

    .line 546
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;I)V

    :cond_1
    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 1

    .line 403
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->checkSameShape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 405
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 406
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)Z

    move-result v0

    if-nez v0, :cond_1

    .line 407
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    return-void

    .line 409
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)Z

    move-result v0

    if-nez v0, :cond_1

    .line 410
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    :cond_1
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 1

    .line 70
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->checkSameShape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 72
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 73
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 74
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void

    .line 76
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 77
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    :cond_1
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 1

    .line 552
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->checkSameShape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 554
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 555
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 556
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void

    .line 558
    :cond_0
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U16_I16_Div;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 559
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    :cond_1
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 1

    .line 416
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->checkSameShape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 418
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 419
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 420
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void

    .line 422
    :cond_0
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 423
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    :cond_1
    return-void
.end method
