.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;
.source "ThresholdBlockMinMax_U8.java"


# instance fields
.field scale:D


# direct methods
.method public constructor <init>(DDZ)V
    .locals 0

    .line 37
    invoke-direct {p0, p1, p2, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;-><init>(DZ)V

    .line 38
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;->scale:D

    return-void
.end method


# virtual methods
.method public computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;)V
    .locals 8

    .line 122
    invoke-virtual {p6, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;->unsafe_get(II)I

    move-result v0

    const/4 v1, 0x0

    move v2, v0

    move v3, v1

    :goto_0
    if-ge v3, p4, :cond_3

    .line 125
    iget v4, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v5, p2, v3

    iget v6, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, v6

    add-int/2addr v4, v5

    add-int/2addr v4, p1

    move v5, v1

    :goto_1
    if-ge v5, p3, :cond_2

    .line 127
    iget-object v6, p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v4, 0x1

    aget-byte v4, v6, v4

    and-int/lit16 v4, v4, 0xff

    if-ge v4, v0, :cond_0

    move v0, v4

    goto :goto_2

    :cond_0
    if-le v4, v2, :cond_1

    move v2, v4

    :cond_1
    :goto_2
    add-int/lit8 v5, v5, 0x1

    move v4, v7

    goto :goto_1

    :cond_2
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 135
    :cond_3
    iget-object p1, p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    int-to-byte p2, v0

    aput-byte p2, p1, p5

    add-int/lit8 p5, p5, 0x1

    int-to-byte p2, v2

    .line 136
    aput-byte p2, p1, p5

    return-void
.end method

.method public bridge synthetic computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 0

    .line 31
    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    check-cast p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    invoke-virtual/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;)V

    return-void
.end method

.method public copy()Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;
    .locals 6

    .line 141
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->minimumSpread:D

    double-to-float v1, v1

    float-to-double v1, v1

    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;->scale:D

    iget-boolean v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->down:Z

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;-><init>(DDZ)V

    return-object v0
.end method

.method public bridge synthetic createStats()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 1

    .line 31
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;->createStats()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    move-result-object v0

    return-object v0
.end method

.method public createStats()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;
    .locals 3

    .line 114
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    const/4 v1, 0x1

    const/4 v2, 0x2

    invoke-direct {v0, v1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;-><init>(III)V

    return-object v0
.end method

.method public thresholdBlock(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 18

    move-object/from16 v0, p0

    move/from16 v1, p1

    move/from16 v2, p2

    move-object/from16 v3, p3

    move-object/from16 v4, p4

    move-object/from16 v5, p5

    .line 44
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->blockWidth:I

    mul-int v7, v1, v6

    .line 45
    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->blockHeight:I

    mul-int v9, v2, v8

    .line 47
    iget v10, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/lit8 v11, v10, -0x1

    if-ne v1, v11, :cond_0

    iget v6, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    goto :goto_0

    :cond_0
    add-int/lit8 v11, v1, 0x1

    mul-int/2addr v6, v11

    .line 48
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

    .line 52
    :goto_1
    iget-boolean v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->thresholdFromLocalBlocks:Z

    const/4 v13, 0x0

    if-eqz v11, :cond_2

    sub-int/2addr v10, v12

    add-int/lit8 v11, v1, 0x1

    .line 53
    invoke-static {v10, v11}, Ljava/lang/Math;->min(II)I

    move-result v10

    .line 54
    iget v11, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v11, v12

    add-int/lit8 v14, v2, 0x1

    invoke-static {v11, v14}, Ljava/lang/Math;->min(II)I

    move-result v11

    add-int/lit8 v1, v1, -0x1

    .line 56
    invoke-static {v13, v1}, Ljava/lang/Math;->max(II)I

    move-result v1

    add-int/lit8 v2, v2, -0x1

    .line 57
    invoke-static {v13, v2}, Ljava/lang/Math;->max(II)I

    move-result v2

    goto :goto_2

    :cond_2
    move v10, v1

    move v11, v2

    :goto_2
    const v14, 0x7fffffff

    const v15, -0x7fffffff

    :goto_3
    if-gt v2, v11, :cond_6

    move v12, v1

    :goto_4
    if-gt v12, v10, :cond_5

    move/from16 p1, v1

    .line 69
    invoke-virtual {v4, v12, v2, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;->getBand(III)I

    move-result v1

    move/from16 v17, v7

    const/4 v13, 0x1

    .line 70
    invoke-virtual {v4, v12, v2, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;->getBand(III)I

    move-result v7

    if-ge v1, v14, :cond_3

    move v14, v1

    :cond_3
    if-le v7, v15, :cond_4

    move v15, v7

    :cond_4
    add-int/lit8 v12, v12, 0x1

    move/from16 v1, p1

    move/from16 v7, v17

    const/4 v13, 0x0

    goto :goto_4

    :cond_5
    move/from16 p1, v1

    move/from16 v17, v7

    add-int/lit8 v2, v2, 0x1

    const/4 v12, 0x1

    const/4 v13, 0x0

    goto :goto_3

    :cond_6
    move/from16 v17, v7

    .line 80
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->minimumSpread:D

    double-to-int v1, v1

    .line 81
    iget-boolean v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->down:Z

    if-eqz v2, :cond_a

    :goto_5
    if-ge v9, v8, :cond_e

    .line 83
    iget v2, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v9

    add-int/2addr v2, v4

    add-int v2, v2, v17

    .line 84
    iget v4, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v7, v9

    add-int/2addr v4, v7

    add-int v4, v4, v17

    move/from16 v7, v17

    :goto_6
    if-ge v7, v6, :cond_9

    sub-int v10, v15, v14

    if-gt v10, v1, :cond_7

    .line 88
    iget-object v10, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/16 v16, 0x1

    aput-byte v16, v10, v4

    goto :goto_8

    .line 90
    :cond_7
    iget-wide v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;->scale:D

    add-int v12, v15, v14

    div-int/lit8 v12, v12, 0x2

    int-to-double v12, v12

    mul-double/2addr v10, v12

    double-to-int v10, v10

    .line 91
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget-object v12, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v12, v12, v2

    and-int/lit16 v12, v12, 0xff

    if-gt v12, v10, :cond_8

    const/4 v13, 0x1

    goto :goto_7

    :cond_8
    const/4 v13, 0x0

    :goto_7
    aput-byte v13, v11, v4

    :goto_8
    add-int/lit8 v7, v7, 0x1

    add-int/lit8 v4, v4, 0x1

    add-int/lit8 v2, v2, 0x1

    goto :goto_6

    :cond_9
    add-int/lit8 v9, v9, 0x1

    goto :goto_5

    :cond_a
    :goto_9
    if-ge v9, v8, :cond_e

    .line 97
    iget v2, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v4, v9

    add-int/2addr v2, v4

    add-int v2, v2, v17

    .line 98
    iget v4, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v7, v9

    add-int/2addr v4, v7

    add-int v4, v4, v17

    move/from16 v7, v17

    :goto_a
    if-ge v7, v6, :cond_d

    sub-int v10, v15, v14

    if-gt v10, v1, :cond_b

    .line 102
    iget-object v10, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/16 v16, 0x1

    aput-byte v16, v10, v4

    goto :goto_c

    :cond_b
    const/16 v16, 0x1

    .line 104
    iget-wide v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;->scale:D

    add-int v12, v15, v14

    div-int/lit8 v12, v12, 0x2

    int-to-double v12, v12

    mul-double/2addr v10, v12

    double-to-int v10, v10

    .line 105
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget-object v12, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v12, v12, v2

    and-int/lit16 v12, v12, 0xff

    if-le v12, v10, :cond_c

    move/from16 v13, v16

    goto :goto_b

    :cond_c
    const/4 v13, 0x0

    :goto_b
    aput-byte v13, v11, v4

    :goto_c
    add-int/lit8 v7, v7, 0x1

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

    .line 31
    check-cast p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    check-cast p4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    invoke-virtual/range {p0 .. p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ThresholdBlockMinMax_U8;->thresholdBlock(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method
