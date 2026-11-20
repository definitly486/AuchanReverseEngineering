.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps;
.super Ljava/lang/Object;
.source "GeneralizedImageOps.java"


# direct methods
.method public static convertGenericToSpecificType(Ljava/lang/Class;)Ljava/lang/Object;
    .locals 1

    .line 269
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    if-ne p0, v0, :cond_0

    .line 270
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p0

    .line 271
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    if-ne p0, v0, :cond_1

    .line 272
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    return-object p0

    .line 273
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;

    if-ne p0, v0, :cond_2

    .line 274
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    return-object p0

    .line 275
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;

    if-ne p0, v0, :cond_3

    .line 276
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;

    :cond_3
    return-object p0
.end method

.method public static createGrowArray(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;
    .locals 2

    .line 251
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->isInteger()Z

    move-result v0

    const/16 v1, 0x40

    if-eqz v0, :cond_1

    .line 252
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object p0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->getNumBits()I

    move-result p0

    if-ge p0, v1, :cond_0

    .line 253
    new-instance p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    return-object p0

    .line 255
    :cond_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    return-object p0

    .line 257
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object p0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->getNumBits()I

    move-result p0

    if-ge p0, v1, :cond_2

    .line 258
    new-instance p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    return-object p0

    .line 260
    :cond_2
    new-instance p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps$$ExternalSyntheticLambda1;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    return-object p0
.end method

.method public static createSingleBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
    .locals 1

    .line 112
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->GRAY:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    invoke-static {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getImageClass(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;)Ljava/lang/Class;

    move-result-object p0

    .line 113
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps;->createSingleBand(Ljava/lang/Class;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    return-object p0
.end method

.method public static createSingleBand(Ljava/lang/Class;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
    .locals 0

    .line 129
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps;->convertGenericToSpecificType(Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Ljava/lang/Class;

    .line 130
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->create(Ljava/lang/Class;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    return-object p0
.end method
