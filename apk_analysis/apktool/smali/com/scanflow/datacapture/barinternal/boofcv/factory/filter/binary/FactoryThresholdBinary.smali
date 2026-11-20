.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;
.super Ljava/lang/Object;
.source "FactoryThresholdBinary.java"


# direct methods
.method public static blockMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 1

    .line 227
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 232
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-ne p5, v0, :cond_0

    .line 233
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMean_U8;

    invoke-direct {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMean_U8;-><init>(DZ)V

    goto :goto_0

    .line 235
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMean_F32;

    double-to-float p1, p1

    float-to-double p1, p1

    invoke-direct {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMean_F32;-><init>(DZ)V

    .line 237
    :goto_0
    sget-boolean p1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz p1, :cond_1

    .line 238
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

    invoke-direct {p1, v0, p0, p4, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V

    return-object p1

    .line 240
    :cond_1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;

    invoke-direct {p1, v0, p0, p4, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V

    return-object p1
.end method

.method public static blockMinMax(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZZDLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 7

    .line 197
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 202
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-ne p7, v0, :cond_0

    .line 203
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;

    move-wide v4, p1

    move v6, p3

    move-wide v2, p5

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;-><init>(DDZ)V

    goto :goto_0

    :cond_0
    move-wide v4, p1

    move v6, p3

    move-wide v2, p5

    .line 205
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;

    double-to-float p1, v2

    double-to-float p2, v4

    invoke-direct {v1, p1, p2, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;-><init>(FFZ)V

    .line 207
    :goto_0
    sget-boolean p1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz p1, :cond_1

    .line 208
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

    invoke-direct {p1, v1, p0, p4, p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V

    return-object p1

    .line 210
    :cond_1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;

    invoke-direct {p1, v1, p0, p4, p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V

    return-object p1
.end method

.method public static blockOtsu(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZZZDLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 8

    .line 256
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 260
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockOtsu;

    move-wide v5, p1

    move v7, p3

    move v2, p5

    move-wide v3, p6

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockOtsu;-><init>(ZDDZ)V

    .line 263
    sget-boolean p1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    const-class p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-eqz p1, :cond_0

    .line 264
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

    invoke-direct {p1, v1, p0, p4, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V

    goto :goto_0

    .line 266
    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;

    invoke-direct {p1, v1, p0, p4, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V

    .line 269
    :goto_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;

    move-object/from16 p2, p8

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;Ljava/lang/Class;)V

    return-object p0
.end method

.method public static globalEntropy(IIDZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 10

    .line 283
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 285
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Entropy;

    int-to-double v2, p0

    int-to-double v4, p1

    invoke-static {p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v9

    move-wide v6, p2

    move v8, p4

    invoke-direct/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Entropy;-><init>(DDDZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V

    return-object v1
.end method

.method public static globalFixed(DZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 1

    .line 298
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 300
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;

    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object p3

    invoke-direct {v0, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;-><init>(DZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V

    return-object v0
.end method

.method public static globalHuang(DDDZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 9

    .line 344
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Huang;

    invoke-static/range {p7 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    move-wide v1, p0

    move-wide v3, p2

    move-wide v5, p4

    move v7, p6

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Huang;-><init>(DDDZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V

    return-object v0
.end method

.method public static globalLi(DDDZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 9

    .line 330
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Li;

    invoke-static/range {p7 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    move-wide v1, p0

    move-wide v3, p2

    move-wide v5, p4

    move v7, p6

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Li;-><init>(DDDZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V

    return-object v0
.end method

.method public static globalOtsu(DDDZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 10

    .line 314
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 316
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Otsu;

    invoke-static/range {p7 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v9

    move-wide v2, p0

    move-wide v4, p2

    move-wide v6, p4

    move/from16 v8, p6

    invoke-direct/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Otsu;-><init>(DDDZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V

    return-object v1
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 7

    .line 54
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 56
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalGaussianBinaryFilter;

    invoke-static {p4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v6

    move-object v2, p0

    move-wide v3, p1

    move v5, p3

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalGaussianBinaryFilter;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V

    return-object v1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 7

    .line 153
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 155
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;

    invoke-static {p4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v6

    move-object v2, p0

    move-wide v3, p1

    move v5, p3

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V

    return-object v1
.end method

.method public static localNiblack(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 1

    .line 98
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->NIBLACK:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    invoke-static {v0, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localNiblackFamily(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0
.end method

.method protected static localNiblackFamily(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 1

    .line 114
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 118
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 119
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT;

    invoke-direct {v0, p1, p3, p2, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;)V

    goto :goto_0

    .line 121
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;

    invoke-direct {v0, p1, p3, p2, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;)V

    .line 123
    :goto_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;

    invoke-direct {p0, v0, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;Ljava/lang/Class;)V

    return-object p0
.end method

.method public static localNick(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 2

    .line 139
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;

    invoke-direct {v1, p0, p2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZ)V

    invoke-direct {v0, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;Ljava/lang/Class;)V

    return-object v0
.end method

.method public static localOtsu(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZZDLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 10

    .line 170
    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/BOverrideFactoryThresholdBinary;->$r8$clinit:I

    .line 174
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v0, :cond_0

    .line 175
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;

    move-object v3, p0

    move-wide v6, p1

    move v8, p3

    move v2, p4

    move-wide v4, p5

    invoke-direct/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;-><init>(ZLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DDZ)V

    goto :goto_0

    .line 177
    :cond_0
    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;

    move-object v4, p0

    move-wide v7, p1

    move v9, p3

    move v3, p4

    move-wide v5, p5

    invoke-direct/range {v2 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;-><init>(ZLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DDZ)V

    move-object v1, v2

    .line 179
    :goto_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;

    move-object/from16 p1, p7

    invoke-direct {p0, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;Ljava/lang/Class;)V

    return-object p0
.end method

.method public static localSauvola(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 1

    .line 70
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->SAUVOLA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    invoke-static {v0, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localNiblackFamily(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0
.end method

.method public static localWolf(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 1

    .line 84
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->WOLF_JOLION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    invoke-static {v0, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localNiblackFamily(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;
    .locals 9

    .line 356
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary$1;->$SwitchMap$boofcv$factory$filter$binary$ThresholdType:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->type:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_0

    new-instance p0, Ljava/lang/IncompatibleClassChangeError;

    invoke-direct {p0}, Ljava/lang/IncompatibleClassChangeError;-><init>()V

    throw p0

    .line 383
    :pswitch_0
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;

    .line 384
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget-boolean v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->thresholdFromLocalBlocks:Z

    iget-boolean v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;->useOtsu2:Z

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;->tuning:D

    move-object v8, p1

    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->blockOtsu(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZZZDLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_1
    move-object v7, p1

    .line 380
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget-boolean v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->thresholdFromLocalBlocks:Z

    move-object v5, v7

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->blockMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_2
    move-object v7, p1

    .line 375
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdBlockMinMax;

    .line 376
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget-boolean v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->thresholdFromLocalBlocks:Z

    iget-wide v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdBlockMinMax;->minimumSpread:D

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->blockMinMax(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZZDLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_3
    move-object v7, p1

    .line 370
    move-object p1, p0

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;

    .line 371
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget-boolean v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;->useOtsu2:Z

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;->tuning:D

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localOtsu(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZZDLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_4
    move-object v7, p1

    .line 367
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    invoke-static {p1, v0, v1, p0, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_5
    move-object v7, p1

    .line 366
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->nickK:F

    invoke-static {p1, v0, p0, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localNick(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_6
    move-object v7, p1

    .line 365
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->niblackK:F

    invoke-static {p1, v0, p0, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localWolf(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_7
    move-object v7, p1

    .line 364
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->niblackK:F

    invoke-static {p1, v0, p0, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localSauvola(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_8
    move-object v7, p1

    .line 363
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->niblackK:F

    invoke-static {p1, v0, p0, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localNiblack(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZFLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_9
    move-object v7, p1

    .line 362
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    invoke-static {p1, v0, v1, p0, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_a
    move-object v7, p1

    .line 361
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->minPixelValue:I

    int-to-double v0, p1

    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->maxPixelValue:I

    int-to-double v2, p1

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->globalHuang(DDDZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_b
    move-object v7, p1

    .line 360
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->minPixelValue:I

    int-to-double v0, p1

    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->maxPixelValue:I

    int-to-double v2, p1

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->globalLi(DDDZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_c
    move-object v7, p1

    .line 359
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->minPixelValue:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->maxPixelValue:I

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    move-object v5, v7

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->globalEntropy(IIDZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_d
    move-object v7, p1

    .line 358
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->minPixelValue:I

    int-to-double v0, p1

    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->maxPixelValue:I

    int-to-double v2, p1

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->globalOtsu(DDDZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_e
    move-object v7, p1

    .line 357
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->fixedThreshold:D

    iget-boolean p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    invoke-static {v0, v1, p0, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryThresholdBinary;->globalFixed(DZLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    move-result-object p0

    return-object p0

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_e
        :pswitch_d
        :pswitch_c
        :pswitch_b
        :pswitch_a
        :pswitch_9
        :pswitch_8
        :pswitch_7
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method
