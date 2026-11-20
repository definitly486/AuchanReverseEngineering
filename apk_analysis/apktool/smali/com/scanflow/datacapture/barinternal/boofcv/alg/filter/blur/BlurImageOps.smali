.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;
.super Ljava/lang/Object;
.source "BlurImageOps.java"


# direct methods
.method public static gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;
    .locals 10

    .line 650
    invoke-static/range {p0 .. p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    move-object v1, p1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move-object/from16 p1, p8

    .line 651
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    move-object v8, p1

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move-object v0, p0

    move-wide v2, p2

    move v4, p4

    move-wide v5, p5

    move/from16 v7, p7

    .line 653
    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BOverrideBlurImageOps;->invokeNativeGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result p1

    if-nez p1, :cond_1

    .line 656
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    invoke-static {p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(Ljava/lang/Class;DI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object v9

    check-cast v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    cmpl-double p2, p2, v5

    if-nez p2, :cond_0

    if-ne p4, v7, :cond_0

    move-object p1, v9

    goto :goto_0

    .line 658
    :cond_0
    invoke-static {p1, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(Ljava/lang/Class;DI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    .line 660
    :goto_0
    invoke-static {v9, p0, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 661
    invoke-static {p1, v8, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    :cond_1
    return-object v1
.end method

.method public static gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;
    .locals 9

    move-wide v5, p2

    move v7, p4

    move-object v0, p0

    move-object v1, p1

    move-wide v2, p2

    move v4, p4

    move-object v8, p5

    .line 632
    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move-result-object p0

    return-object p0
.end method

.method public static gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;
    .locals 10

    .line 431
    invoke-static/range {p0 .. p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    move-object v1, p1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move-object/from16 p1, p8

    .line 432
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    move-object v8, p1

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move-object v0, p0

    move-wide v2, p2

    move v4, p4

    move-wide v5, p5

    move/from16 v7, p7

    .line 434
    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BOverrideBlurImageOps;->invokeNativeGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result p1

    if-nez p1, :cond_1

    .line 437
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    invoke-static {p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(Ljava/lang/Class;DI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object v9

    check-cast v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    cmpl-double p2, p2, v5

    if-nez p2, :cond_0

    if-ne p4, v7, :cond_0

    move-object p1, v9

    goto :goto_0

    .line 439
    :cond_0
    invoke-static {p1, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(Ljava/lang/Class;DI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    .line 441
    :goto_0
    invoke-static {v9, p0, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    .line 442
    invoke-static {p1, v8, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;)V

    :cond_1
    return-object v1
.end method

.method public static gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;
    .locals 9

    move-wide v5, p2

    move v7, p4

    move-object v0, p0

    move-object v1, p1

    move-wide v2, p2

    move v4, p4

    move-object v8, p5

    .line 413
    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move-result-object p0

    return-object p0
.end method

.method public static gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 10

    .line 212
    invoke-static/range {p0 .. p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    move-object v1, p1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-object/from16 p1, p8

    .line 213
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    move-object v8, p1

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-object v0, p0

    move-wide v2, p2

    move v4, p4

    move-wide v5, p5

    move/from16 v7, p7

    .line 215
    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BOverrideBlurImageOps;->invokeNativeGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result p1

    if-nez p1, :cond_1

    .line 218
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    invoke-static {p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(Ljava/lang/Class;DI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object v9

    check-cast v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    cmpl-double p2, p2, v5

    if-nez p2, :cond_0

    if-ne p4, v7, :cond_0

    move-object p1, v9

    goto :goto_0

    .line 220
    :cond_0
    invoke-static {p1, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(Ljava/lang/Class;DI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    .line 222
    :goto_0
    invoke-static {v9, p0, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    .line 223
    invoke-static {p1, v8, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageNormalized;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    :cond_1
    return-object v1
.end method

.method public static gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 9

    move-wide v5, p2

    move v7, p4

    move-object v0, p0

    move-object v1, p1

    move-wide v2, p2

    move v4, p4

    move-object v8, p5

    .line 194
    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->gaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DIDILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0
.end method

.method public static mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;
    .locals 1

    if-lez p2, :cond_1

    if-lez p3, :cond_1

    .line 524
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 525
    invoke-static {p0, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p4

    check-cast p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 527
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BOverrideBlurImageOps;->invokeNativeMeanWeighted(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-object p1

    :cond_0
    mul-int/lit8 v0, p2, 0x2

    add-int/lit8 v0, v0, 0x1

    .line 532
    invoke-static {p0, p4, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageMean;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II)V

    mul-int/lit8 p0, p3, 0x2

    add-int/lit8 p0, p0, 0x1

    .line 533
    invoke-static {p4, p1, p3, p0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageMean;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-object p1

    .line 522
    :cond_1
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Radius must be > 0"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;
    .locals 6

    move v3, p2

    move-object v0, p0

    move-object v1, p1

    move v2, p2

    move-object v4, p3

    move-object v5, p4

    .line 506
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move-result-object p0

    return-object p0
.end method

.method public static mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;
    .locals 1

    if-lez p2, :cond_1

    if-lez p3, :cond_1

    .line 305
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 306
    invoke-static {p0, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p4

    check-cast p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 308
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BOverrideBlurImageOps;->invokeNativeMeanWeighted(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-object p1

    :cond_0
    mul-int/lit8 v0, p2, 0x2

    add-int/lit8 v0, v0, 0x1

    .line 313
    invoke-static {p0, p4, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageMean;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;II)V

    mul-int/lit8 p0, p3, 0x2

    add-int/lit8 p0, p0, 0x1

    .line 314
    invoke-static {p4, p1, p3, p0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageMean;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-object p1

    .line 303
    :cond_1
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Radius must be > 0"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;
    .locals 6

    move v3, p2

    move-object v0, p0

    move-object v1, p1

    move v2, p2

    move-object v4, p3

    move-object v5, p4

    .line 287
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move-result-object p0

    return-object p0
.end method

.method public static mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    if-lez p2, :cond_1

    if-lez p3, :cond_1

    .line 86
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 87
    invoke-static {p0, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p4

    check-cast p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 89
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BOverrideBlurImageOps;->invokeNativeMeanWeighted(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-object p1

    :cond_0
    mul-int/lit8 v0, p2, 0x2

    add-int/lit8 v0, v0, 0x1

    .line 94
    invoke-static {p0, p4, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageMean;->horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V

    mul-int/lit8 p0, p3, 0x2

    add-int/lit8 p0, p0, 0x1

    .line 95
    invoke-static {p4, p1, p3, p0, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/ConvolveImageMean;->vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-object p1

    .line 84
    :cond_1
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Radius must be > 0"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 6

    move v3, p2

    move-object v0, p0

    move-object v1, p1

    move v2, p2

    move-object v4, p3

    move-object v5, p4

    .line 68
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0
.end method
