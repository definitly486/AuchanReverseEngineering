.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;
.super Ljava/lang/Object;
.source "ThresholdNiblackFamily.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Sauvola;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Niblack;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$WolfJolion;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;
    }
.end annotation


# instance fields
.field down:Z

.field inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field inputMeanPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field inputPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field inputPow2Mean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field k:F

.field maxStdev:F

.field minItensity:F

.field op:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;

.field stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field variant:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

.field width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field work:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;)V
    .locals 3

    .line 105
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 81
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    const/4 v1, 0x1

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 82
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 83
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMeanPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 84
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2Mean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 85
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 87
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 88
    new-instance v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->work:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    .line 106
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->k:F

    .line 107
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 108
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->down:Z

    .line 109
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->variant:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    .line 111
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$1;->$SwitchMap$boofcv$alg$filter$binary$ThresholdNiblackFamily$Variant:[I

    invoke-virtual {p4}, Ljava/lang/Enum;->ordinal()I

    move-result p2

    aget p1, p1, p2

    if-eq p1, v1, :cond_2

    const/4 p2, 0x2

    if-eq p1, p2, :cond_1

    const/4 p2, 0x3

    if-ne p1, p2, :cond_0

    .line 114
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$WolfJolion;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$WolfJolion;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;)V

    goto :goto_0

    .line 111
    :cond_0
    new-instance p1, Ljava/lang/IncompatibleClassChangeError;

    invoke-direct {p1}, Ljava/lang/IncompatibleClassChangeError;-><init>()V

    throw p1

    .line 113
    :cond_1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Niblack;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Niblack;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;)V

    goto :goto_0

    .line 112
    :cond_2
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Sauvola;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Sauvola;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;)V

    .line 114
    :goto_0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->op:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;

    return-void
.end method


# virtual methods
.method protected applyThresholding(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 12

    .line 157
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->down:Z

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-eqz v0, :cond_2

    move v0, v1

    .line 158
    :goto_0
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_5

    .line 159
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v3, v0

    .line 160
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, v0

    add-int/2addr v4, v5

    .line 161
    iget v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v0

    add-int/2addr v5, v6

    move v6, v1

    .line 163
    :goto_1
    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v6, v7, :cond_1

    .line 164
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->op:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v8, v8, v3

    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v9, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v9, v9, v3

    invoke-interface {v7, v8, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;->compute(FF)F

    move-result v7

    .line 165
    iget-object v8, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v9, v5, 0x1

    iget-object v10, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v11, v4, 0x1

    aget v4, v10, v4

    cmpg-float v4, v4, v7

    if-gtz v4, :cond_0

    move v4, v2

    goto :goto_2

    :cond_0
    move v4, v1

    :goto_2
    int-to-byte v4, v4

    aput-byte v4, v8, v5

    add-int/lit8 v6, v6, 0x1

    add-int/lit8 v3, v3, 0x1

    move v5, v9

    move v4, v11

    goto :goto_1

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_2
    move v0, v1

    .line 169
    :goto_3
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v3, :cond_5

    .line 170
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v3, v0

    .line 171
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, v0

    add-int/2addr v4, v5

    .line 172
    iget v5, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v0

    add-int/2addr v5, v6

    move v6, v1

    .line 174
    :goto_4
    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v6, v7, :cond_4

    .line 175
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->op:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v8, v8, v3

    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v9, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v9, v9, v3

    invoke-interface {v7, v8, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;->compute(FF)F

    move-result v7

    .line 176
    iget-object v8, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v9, v5, 0x1

    iget-object v10, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v11, v4, 0x1

    aget v4, v10, v4

    cmpl-float v4, v4, v7

    if-ltz v4, :cond_3

    move v4, v2

    goto :goto_5

    :cond_3
    move v4, v1

    :goto_5
    int-to-byte v4, v4

    aput-byte v4, v8, v5

    add-int/lit8 v6, v6, 0x1

    add-int/lit8 v3, v3, 0x1

    move v5, v9

    move v4, v11

    goto :goto_4

    :cond_4
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_5
    return-void
.end method

.method public getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 210
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 5

    .line 126
    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 127
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 128
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 129
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMeanPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 130
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2Mean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 131
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 132
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 133
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 135
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v1, v2}, Ljava/lang/Math;->min(II)I

    move-result v1

    int-to-double v1, v1

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    .line 138
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->work:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    invoke-static {p1, v1, v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 141
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;->pow2(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 142
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2Mean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->work:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    invoke-static {v1, v2, v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 143
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMeanPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;->pow2(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 144
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputPow2Mean:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->inputMeanPow2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;->subtract(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 145
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {v0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;->sqrt(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 147
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->variant:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->SAUVOLA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    if-eq v0, v1, :cond_0

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->WOLF_JOLION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    if-ne v0, v1, :cond_1

    .line 148
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->stdev:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->max(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)F

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->maxStdev:F

    .line 150
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->variant:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->WOLF_JOLION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    if-ne v0, v1, :cond_2

    .line 151
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->min(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)F

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->minItensity:F

    .line 153
    :cond_2
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->applyThresholding(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 65
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method
