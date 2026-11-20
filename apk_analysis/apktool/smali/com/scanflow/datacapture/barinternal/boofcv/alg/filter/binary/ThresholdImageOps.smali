.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;
.super Ljava/lang/Object;
.source "ThresholdImageOps.java"


# direct methods
.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 7

    .line 368
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v1, p1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 369
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {p0, p5, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p5

    move-object v5, p5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 370
    invoke-static {p0, p6, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v6, p1

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 372
    sget-boolean p1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz p1, :cond_0

    move-object v0, p0

    move-object v2, p2

    move v3, p3

    move v4, p4

    .line 373
    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1

    :cond_0
    move-object v0, p0

    move-object v2, p2

    move v3, p3

    move v4, p4

    .line 375
    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 7

    .line 303
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v1, p1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 304
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-static {p0, p5, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p5

    move-object v5, p5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 305
    invoke-static {p0, p6, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v6, p1

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 307
    sget-boolean p1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz p1, :cond_0

    move-object v0, p0

    move-object v2, p2

    move v3, p3

    move v4, p4

    .line 308
    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1

    :cond_0
    move-object v0, p0

    move-object v2, p2

    move v3, p3

    move v4, p4

    .line 310
    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 8

    .line 238
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v2, p1

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 239
    invoke-static {p0, p5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v6, p1

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 240
    invoke-static {p0, p6, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v7, p1

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 242
    sget-boolean p1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz p1, :cond_0

    move-object v1, p0

    move-object v3, p2

    move v4, p3

    move v5, p4

    .line 243
    invoke-static/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v2

    :cond_0
    move-object v1, p0

    move-object v3, p2

    move v4, p3

    move v5, p4

    .line 245
    invoke-static/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v2
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 8

    .line 336
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v1, p1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 337
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {p0, p5, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p5

    move-object v5, p5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 338
    invoke-static {p0, p6, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v6, p1

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 340
    sget-boolean p1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz p1, :cond_0

    move-object v0, p0

    move-object v2, p2

    move v3, p3

    move v4, p4

    move-object v7, p7

    .line 341
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1

    :cond_0
    move-object v0, p0

    move-object v2, p2

    move v3, p3

    move v4, p4

    move-object v7, p7

    .line 343
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 8

    .line 271
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v1, p1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 272
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-static {p0, p5, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p5

    move-object v5, p5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 273
    invoke-static {p0, p6, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    move-object v6, p1

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 275
    sget-boolean p1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz p1, :cond_0

    move-object v0, p0

    move-object v2, p2

    move v3, p3

    move v4, p4

    move-object v7, p7

    .line 276
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1

    :cond_0
    move-object v0, p0

    move-object v2, p2

    move v3, p3

    move v4, p4

    move-object v7, p7

    .line 278
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 8

    .line 206
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 207
    invoke-static {p0, p5, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v3

    move-object v5, v3

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 208
    invoke-static {p0, p6, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v1

    move-object v6, v1

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 210
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    move-object v0, p0

    move v3, p3

    move v4, p4

    move-object v7, p7

    move-object v1, v2

    move-object v2, p2

    .line 211
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1

    :cond_0
    move-object v0, p0

    move v3, p3

    move v4, p4

    move-object v7, p7

    move-object v1, v2

    move-object v2, p2

    .line 213
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object v1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 55
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 57
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 58
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1

    .line 60
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 79
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 81
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 82
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1

    .line 84
    :cond_0
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 127
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 129
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 130
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1

    .line 132
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 175
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 177
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 178
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1

    .line 180
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 151
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 153
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 154
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1

    .line 156
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 103
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->declareOrReshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 105
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 106
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1

    .line 108
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p1
.end method
