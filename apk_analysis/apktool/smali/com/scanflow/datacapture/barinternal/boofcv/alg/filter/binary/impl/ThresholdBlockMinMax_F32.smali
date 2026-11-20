.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;
.source "ThresholdBlockMinMax_F32.java"


# instance fields
.field scale:F


# direct methods
.method public constructor <init>(FFZ)V
    .locals 2

    float-to-double v0, p1

    .line 38
    invoke-direct {p0, v0, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;-><init>(DZ)V

    .line 39
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;->scale:F

    return-void
.end method


# virtual methods
.method public computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;)V
    .locals 8

    .line 128
    invoke-virtual {p6, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->unsafe_get(II)F

    move-result v0

    const/4 v1, 0x0

    move v2, v0

    move v3, v1

    :goto_0
    if-ge v3, p4, :cond_3

    .line 131
    iget v4, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v5, p2, v3

    iget v6, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, v6

    add-int/2addr v4, v5

    add-int/2addr v4, p1

    move v5, v1

    :goto_1
    if-ge v5, p3, :cond_2

    .line 133
    iget-object v6, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v7, v4, 0x1

    aget v4, v6, v4

    cmpg-float v6, v4, v0

    if-gez v6, :cond_0

    move v0, v4

    goto :goto_2

    :cond_0
    cmpl-float v6, v4, v2

    if-lez v6, :cond_1

    move v2, v4

    :cond_1
    :goto_2
    add-int/lit8 v5, v5, 0x1

    move v4, v7

    goto :goto_1

    :cond_2
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 141
    :cond_3
    iget-object p1, p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    aput v0, p1, p5

    add-int/lit8 p5, p5, 0x1

    .line 142
    aput v2, p1, p5

    return-void
.end method

.method public bridge synthetic computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 0

    .line 32
    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    check-cast p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    invoke-virtual/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;)V

    return-void
.end method

.method public copy()Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;
    .locals 4

    .line 115
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->minimumSpread:D

    double-to-float v1, v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;->scale:F

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->down:Z

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;-><init>(FFZ)V

    return-object v0
.end method

.method public bridge synthetic createStats()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 1

    .line 32
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;->createStats()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    move-result-object v0

    return-object v0
.end method

.method public createStats()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;
    .locals 3

    .line 120
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    const/4 v1, 0x1

    const/4 v2, 0x2

    invoke-direct {v0, v1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;-><init>(III)V

    return-object v0
.end method

.method public thresholdBlock(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 19

    move-object/from16 v0, p0

    move/from16 v1, p1

    move/from16 v2, p2

    move-object/from16 v3, p3

    move-object/from16 v4, p4

    move-object/from16 v5, p5

    .line 45
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->blockWidth:I

    mul-int v7, v1, v6

    .line 46
    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->blockHeight:I

    mul-int v9, v2, v8

    .line 48
    iget v10, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/lit8 v11, v10, -0x1

    if-ne v1, v11, :cond_0

    iget v6, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    goto :goto_0

    :cond_0
    add-int/lit8 v11, v1, 0x1

    mul-int/2addr v6, v11

    .line 49
    :goto_0
    iget v11, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    const/4 v12, 0x1

    sub-int/2addr v11, v12

    if-ne v2, v11, :cond_1

    iget v8, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    goto :goto_1

    :cond_1
    add-int/lit8 v11, v2, 0x1

    mul-int/2addr v8, v11

    .line 53
    :goto_1
    iget-boolean v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->thresholdFromLocalBlocks:Z

    const/4 v13, 0x0

    if-eqz v11, :cond_2

    sub-int/2addr v10, v12

    add-int/lit8 v11, v1, 0x1

    .line 54
    invoke-static {v10, v11}, Ljava/lang/Math;->min(II)I

    move-result v10

    .line 55
    iget v11, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v11, v12

    add-int/lit8 v14, v2, 0x1

    invoke-static {v11, v14}, Ljava/lang/Math;->min(II)I

    move-result v11

    add-int/lit8 v1, v1, -0x1

    .line 57
    invoke-static {v13, v1}, Ljava/lang/Math;->max(II)I

    move-result v1

    add-int/lit8 v2, v2, -0x1

    .line 58
    invoke-static {v13, v2}, Ljava/lang/Math;->max(II)I

    move-result v2

    goto :goto_2

    :cond_2
    move v10, v1

    move v11, v2

    :goto_2
    const v14, 0x7f7fffff    # Float.MAX_VALUE

    const v15, -0x800001

    :goto_3
    if-gt v2, v11, :cond_6

    move v12, v1

    :goto_4
    if-gt v12, v10, :cond_5

    .line 70
    invoke-virtual {v4, v12, v2, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->getBand(III)F

    move-result v17

    const/4 v13, 0x1

    .line 71
    invoke-virtual {v4, v12, v2, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->getBand(III)F

    move-result v18

    cmpg-float v13, v17, v14

    if-gez v13, :cond_3

    move/from16 v14, v17

    :cond_3
    cmpl-float v13, v18, v15

    if-lez v13, :cond_4

    move/from16 v15, v18

    :cond_4
    add-int/lit8 v12, v12, 0x1

    const/4 v13, 0x0

    goto :goto_4

    :cond_5
    add-int/lit8 v2, v2, 0x1

    const/4 v12, 0x1

    const/4 v13, 0x0

    goto :goto_3

    .line 81
    :cond_6
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->minimumSpread:D

    double-to-float v1, v1

    .line 82
    iget-boolean v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->down:Z

    const/high16 v4, 0x40000000    # 2.0f

    if-eqz v2, :cond_a

    :goto_5
    if-ge v9, v8, :cond_e

    .line 84
    iget v2, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v10, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v9

    add-int/2addr v2, v10

    add-int/2addr v2, v7

    .line 85
    iget v10, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v11, v9

    add-int/2addr v10, v11

    add-int/2addr v10, v7

    move v11, v7

    :goto_6
    if-ge v11, v6, :cond_9

    sub-float v12, v15, v14

    cmpg-float v12, v12, v1

    if-gtz v12, :cond_7

    .line 89
    iget-object v12, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/16 v16, 0x1

    aput-byte v16, v12, v10

    move/from16 p1, v4

    goto :goto_8

    .line 91
    :cond_7
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;->scale:F

    add-float v13, v15, v14

    mul-float/2addr v12, v13

    div-float/2addr v12, v4

    .line 92
    iget-object v13, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move/from16 p1, v4

    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v4, v4, v2

    cmpg-float v4, v4, v12

    if-gtz v4, :cond_8

    const/4 v4, 0x1

    goto :goto_7

    :cond_8
    const/4 v4, 0x0

    :goto_7
    aput-byte v4, v13, v10

    :goto_8
    add-int/lit8 v11, v11, 0x1

    add-int/lit8 v10, v10, 0x1

    add-int/lit8 v2, v2, 0x1

    move/from16 v4, p1

    goto :goto_6

    :cond_9
    move/from16 p1, v4

    add-int/lit8 v9, v9, 0x1

    goto :goto_5

    :cond_a
    move/from16 p1, v4

    :goto_9
    if-ge v9, v8, :cond_e

    .line 98
    iget v2, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v9

    add-int/2addr v2, v4

    add-int/2addr v2, v7

    .line 99
    iget v4, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v10, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v10, v9

    add-int/2addr v4, v10

    add-int/2addr v4, v7

    move v10, v7

    :goto_a
    if-ge v10, v6, :cond_d

    sub-float v11, v15, v14

    cmpg-float v11, v11, v1

    if-gtz v11, :cond_b

    .line 103
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/16 v16, 0x1

    aput-byte v16, v11, v4

    goto :goto_c

    :cond_b
    const/16 v16, 0x1

    .line 105
    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;->scale:F

    add-float v12, v15, v14

    mul-float/2addr v11, v12

    div-float v11, v11, p1

    .line 106
    iget-object v12, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget-object v13, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v13, v13, v2

    cmpl-float v11, v13, v11

    if-lez v11, :cond_c

    move/from16 v13, v16

    goto :goto_b

    :cond_c
    const/4 v13, 0x0

    :goto_b
    aput-byte v13, v12, v4

    :goto_c
    add-int/lit8 v10, v10, 0x1

    add-int/lit8 v4, v4, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_a

    :cond_d
    const/16 v16, 0x1

    add-int/lit8 v9, v9, 0x1

    goto :goto_9

    :cond_e
    return-void
.end method

.method public bridge synthetic thresholdBlock(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 32
    check-cast p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    check-cast p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    invoke-virtual/range {p0 .. p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_F32;->thresholdBlock(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method
