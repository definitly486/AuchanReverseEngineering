.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;
.super Ljava/lang/Object;
.source "ConvolveImageNormalized.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 2

    .line 53
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 55
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageNormalized;->invokeNativeHorizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 58
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-lt v0, v1, :cond_1

    .line 59
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalizedNaive_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void

    .line 61
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->computeSum()F

    move-result v0

    const/high16 v1, 0x3f800000    # 1.0f

    sub-float/2addr v0, v1

    invoke-static {v0}, Ljava/lang/Math;->abs(F)F

    move-result v0

    const v1, 0x38d1b717    # 1.0E-4f

    cmpl-float v0, v0, v1

    if-lez v0, :cond_2

    .line 62
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->copy()Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    move-result-object p0

    .line 63
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;)V

    .line 66
    :cond_2
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNoBorder;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 67
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V
    .locals 2

    .line 923
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 925
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageNormalized;->invokeNativeHorizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 928
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-lt v0, v1, :cond_1

    .line 929
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalizedNaive_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    return-void

    .line 931
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->computeSum()I

    move-result v0

    invoke-static {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNoBorder;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;I)V

    .line 932
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    return-void
.end method

.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V
    .locals 2

    .line 533
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 535
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageNormalized;->invokeNativeHorizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 538
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-lt v0, v1, :cond_1

    .line 539
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalizedNaive_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    return-void

    .line 541
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->computeSum()I

    move-result v0

    invoke-static {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNoBorder;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    .line 542
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 2

    .line 79
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 81
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageNormalized;->invokeNativeVertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 84
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-lt v0, v1, :cond_1

    .line 85
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalizedNaive_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void

    .line 87
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->computeSum()F

    move-result v0

    const/high16 v1, 0x3f800000    # 1.0f

    sub-float/2addr v0, v1

    invoke-static {v0}, Ljava/lang/Math;->abs(F)F

    move-result v0

    const v1, 0x38d1b717    # 1.0E-4f

    cmpl-float v0, v0, v1

    if-lez v0, :cond_2

    .line 88
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->copy()Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    move-result-object p0

    .line 89
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;)V

    .line 92
    :cond_2
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNoBorder;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 93
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V
    .locals 2

    .line 944
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 946
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageNormalized;->invokeNativeVertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 949
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-lt v0, v1, :cond_1

    .line 950
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalizedNaive_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    return-void

    .line 952
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->computeSum()I

    move-result v0

    const/4 v1, 0x0

    invoke-static {p0, p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNoBorder;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    .line 953
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V
    .locals 2

    .line 554
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 556
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/BOverrideConvolveImageNormalized;->invokeNativeVertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 559
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-lt v0, v1, :cond_1

    .line 560
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalizedNaive_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    return-void

    .line 562
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->computeSum()I

    move-result v0

    const/4 v1, 0x0

    invoke-static {p0, p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNoBorder;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    .line 563
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/normalized/ConvolveNormalized_JustBorder_SB;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    return-void
.end method
