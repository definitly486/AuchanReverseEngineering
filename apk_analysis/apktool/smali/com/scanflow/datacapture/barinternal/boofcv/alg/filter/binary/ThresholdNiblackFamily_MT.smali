.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;
.source "ThresholdNiblackFamily_MT.java"


# direct methods
.method public static synthetic $r8$lambda$Qi3Rg0LWXfegsxJoFfZU0LqKSm0(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V
    .locals 9

    .line 39
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v0, p3

    .line 40
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p3

    add-int/2addr v1, v2

    .line 41
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v3

    add-int/2addr v2, p3

    const/4 p3, 0x0

    move v3, p3

    .line 43
    :goto_0
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v3, v4, :cond_1

    .line 44
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->op:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v5, v5, v0

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v6, v6, v0

    invoke-interface {v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;->compute(FF)F

    move-result v4

    .line 45
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v2, 0x1

    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v8, v1, 0x1

    aget v1, v7, v1

    cmpg-float v1, v1, v4

    if-gtz v1, :cond_0

    const/4 v1, 0x1

    goto :goto_1

    :cond_0
    move v1, p3

    :goto_1
    int-to-byte v1, v1

    aput-byte v1, v5, v2

    add-int/lit8 v3, v3, 0x1

    add-int/lit8 v0, v0, 0x1

    move v2, v6

    move v1, v8

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static synthetic $r8$lambda$nal9l7lLBP8HhWO0aQbO6XFW8n0(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V
    .locals 9

    .line 50
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v0, p3

    .line 51
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, p3

    add-int/2addr v1, v2

    .line 52
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p3, v3

    add-int/2addr v2, p3

    const/4 p3, 0x0

    move v3, p3

    .line 54
    :goto_0
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v3, v4, :cond_1

    .line 55
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->op:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v5, v5, v0

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v6, v6, v0

    invoke-interface {v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;->compute(FF)F

    move-result v4

    .line 56
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v2, 0x1

    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v8, v1, 0x1

    aget v1, v7, v1

    cmpl-float v1, v1, v4

    if-ltz v1, :cond_0

    const/4 v1, 0x1

    goto :goto_1

    :cond_0
    move v1, p3

    :goto_1
    int-to-byte v1, v1

    aput-byte v1, v5, v2

    add-int/lit8 v3, v3, 0x1

    add-int/lit8 v0, v0, 0x1

    move v2, v6

    move v1, v8

    goto :goto_0

    :cond_1
    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;)V
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;)V

    return-void
.end method


# virtual methods
.method protected applyThresholding(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 3

    .line 37
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->down:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    .line 38
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT$$ExternalSyntheticLambda0;

    invoke-direct {v2, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    invoke-static {v1, v0, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 49
    :cond_0
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT$$ExternalSyntheticLambda1;

    invoke-direct {v2, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    invoke-static {v1, v0, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method
