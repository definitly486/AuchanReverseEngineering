.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;
.super Ljava/lang/Object;
.source "ThresholdNick.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;


# instance fields
.field down:Z

.field imageI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field k:F

.field meanI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field meanImage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field work:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZ)V
    .locals 2

    .line 72
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 58
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    const/4 v1, 0x1

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->imageI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 59
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanImage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 60
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 62
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 63
    new-instance v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->work:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    .line 73
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->k:F

    .line 74
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 75
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->down:Z

    return-void
.end method


# virtual methods
.method public getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 145
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 13

    .line 86
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 87
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->imageI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 88
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanImage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 89
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 90
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 91
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->imageI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 93
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v1, v2}, Ljava/lang/Math;->min(II)I

    move-result v1

    int-to-double v1, v1

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    mul-int/lit8 v1, v0, 0x2

    const/4 v2, 0x1

    add-int/2addr v1, v2

    mul-int/2addr v1, v1

    int-to-float v1, v1

    .line 98
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanImage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->work:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    invoke-static {p1, v3, v0, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 101
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->imageI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {p1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;->pow2(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    .line 104
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->imageI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->tmp:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->work:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    invoke-static {v3, v4, v0, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/blur/BlurImageOps;->mean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 106
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->down:Z

    const/4 v3, 0x0

    if-eqz v0, :cond_2

    move v0, v3

    .line 108
    :goto_0
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v4, :cond_5

    .line 109
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v4, v0

    .line 110
    iget v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v0

    add-int/2addr v5, v6

    .line 111
    iget v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v7, v0

    add-int/2addr v6, v7

    move v7, v3

    .line 113
    :goto_1
    iget v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v7, v8, :cond_1

    .line 114
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanImage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v8, v8, v4

    .line 115
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v9, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v9, v9, v4

    mul-float v10, v8, v8

    div-float/2addr v10, v1

    sub-float/2addr v9, v10

    .line 118
    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->k:F

    float-to-double v11, v9

    invoke-static {v11, v12}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v11

    double-to-float v9, v11

    mul-float/2addr v10, v9

    add-float/2addr v8, v10

    .line 119
    iget-object v9, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v10, v6, 0x1

    iget-object v11, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v12, v5, 0x1

    aget v5, v11, v5

    cmpg-float v5, v5, v8

    if-gtz v5, :cond_0

    move v5, v2

    goto :goto_2

    :cond_0
    move v5, v3

    :goto_2
    int-to-byte v5, v5

    aput-byte v5, v9, v6

    add-int/lit8 v7, v7, 0x1

    add-int/lit8 v4, v4, 0x1

    move v6, v10

    move v5, v12

    goto :goto_1

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_2
    move v0, v3

    .line 125
    :goto_3
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v0, v4, :cond_5

    .line 126
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v4, v0

    .line 127
    iget v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v0

    add-int/2addr v5, v6

    .line 128
    iget v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v7, v0

    add-int/2addr v6, v7

    move v7, v3

    .line 130
    :goto_4
    iget v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v7, v8, :cond_4

    .line 131
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanImage:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v8, v8, v4

    .line 132
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->meanI2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v9, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v9, v9, v4

    mul-float v10, v8, v8

    div-float/2addr v10, v1

    sub-float/2addr v9, v10

    .line 135
    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->k:F

    float-to-double v11, v9

    invoke-static {v11, v12}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v11

    double-to-float v9, v11

    mul-float/2addr v10, v9

    add-float/2addr v8, v10

    .line 136
    iget-object v9, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v10, v6, 0x1

    iget-object v11, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v12, v5, 0x1

    aget v5, v11, v5

    cmpl-float v5, v5, v8

    if-ltz v5, :cond_3

    move v5, v2

    goto :goto_5

    :cond_3
    move v5, v3

    :goto_5
    int-to-byte v5, v5

    aput-byte v5, v9, v6

    add-int/lit8 v7, v7, 0x1

    add-int/lit8 v4, v4, 0x1

    move v6, v10

    move v5, v12

    goto :goto_4

    :cond_4
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_5
    return-void
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 46
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNick;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method
