.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;
.super Ljava/lang/Object;
.source "GThresholdImageOps.java"


# direct methods
.method public static computeEntropy(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;DD)D
    .locals 2

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    add-double/2addr p3, v0

    sub-double/2addr p3, p1

    double-to-int p3, p3

    .line 423
    new-array p4, p3, [I

    .line 425
    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/GImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;D[I)V

    .line 428
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, p0

    .line 430
    invoke-static {p4, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;->computeEntropy([III)I

    move-result p0

    int-to-double p3, p0

    add-double/2addr p3, p1

    return-wide p3
.end method

.method public static computeEntropy([III)I
    .locals 22

    move/from16 v0, p1

    move/from16 v1, p2

    .line 453
    new-array v2, v0, [D

    const/4 v3, 0x0

    move v4, v3

    :goto_0
    const-wide/16 v5, 0x0

    if-ge v4, v0, :cond_1

    .line 455
    aget v7, p0, v4

    if-nez v7, :cond_0

    .line 457
    aput-wide v5, v2, v4

    goto :goto_1

    :cond_0
    int-to-double v5, v7

    int-to-double v7, v1

    div-double/2addr v5, v7

    .line 459
    aput-wide v5, v2, v4

    .line 460
    invoke-static {v5, v6}, Ljava/lang/Math;->log(D)D

    move-result-wide v7

    mul-double/2addr v5, v7

    aput-wide v5, v2, v4

    :goto_1
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_1
    move v4, v3

    move v7, v4

    move v8, v7

    move-wide v9, v5

    :goto_2
    if-ge v4, v0, :cond_6

    .line 469
    aget v11, p0, v4

    add-int/2addr v8, v11

    int-to-double v11, v8

    int-to-double v13, v1

    div-double/2addr v11, v13

    cmpl-double v13, v11, v5

    if-eqz v13, :cond_5

    const-wide/high16 v13, 0x3ff0000000000000L    # 1.0

    cmpl-double v15, v11, v13

    if-nez v15, :cond_2

    goto :goto_5

    :cond_2
    sub-double/2addr v13, v11

    move v15, v3

    move-wide/from16 v16, v5

    :goto_3
    if-gt v15, v4, :cond_3

    .line 478
    aget-wide v18, v2, v15

    add-double v16, v16, v18

    add-int/lit8 v15, v15, 0x1

    goto :goto_3

    :cond_3
    div-double v16, v16, v11

    add-int/lit8 v15, v4, 0x1

    move-wide/from16 v18, v5

    :goto_4
    if-ge v15, v0, :cond_4

    .line 484
    aget-wide v20, v2, v15

    add-double v18, v18, v20

    add-int/lit8 v15, v15, 0x1

    goto :goto_4

    :cond_4
    div-double v18, v18, v13

    .line 488
    invoke-static {v11, v12}, Ljava/lang/Math;->log(D)D

    move-result-wide v11

    invoke-static {v13, v14}, Ljava/lang/Math;->log(D)D

    move-result-wide v13

    add-double/2addr v11, v13

    sub-double v11, v11, v16

    sub-double v11, v11, v18

    cmpl-double v13, v11, v9

    if-lez v13, :cond_5

    move v7, v4

    move-wide v9, v11

    :cond_5
    :goto_5
    add-int/lit8 v4, v4, 0x1

    goto :goto_2

    :cond_6
    return v7
.end method

.method public static computeHuang(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;DD)D
    .locals 2

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    add-double/2addr p3, v0

    sub-double/2addr p3, p1

    double-to-int p3, p3

    .line 313
    new-array p4, p3, [I

    .line 315
    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/GImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;D[I)V

    .line 317
    invoke-static {p4, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;->computeHuang([II)I

    move-result p0

    int-to-double p3, p0

    add-double/2addr p3, p1

    return-wide p3
.end method

.method public static computeHuang([II)I
    .locals 27

    move/from16 v0, p1

    const/4 v1, 0x0

    move v2, v1

    :goto_0
    if-ge v2, v0, :cond_1

    .line 340
    aget v3, p0, v2

    if-eqz v3, :cond_0

    move v1, v2

    goto :goto_1

    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    :goto_1
    add-int/lit8 v2, v0, -0x1

    move v3, v2

    :goto_2
    if-lt v3, v1, :cond_3

    .line 349
    aget v4, p0, v3

    if-eqz v4, :cond_2

    move v2, v3

    goto :goto_3

    :cond_2
    add-int/lit8 v3, v3, -0x1

    goto :goto_2

    :cond_3
    :goto_3
    sub-int v3, v2, v1

    int-to-double v3, v3

    const-wide/high16 v5, 0x3ff0000000000000L    # 1.0

    div-double v3, v5, v3

    .line 355
    new-array v7, v0, [D

    move v10, v1

    const-wide/16 v11, 0x0

    const-wide/16 v13, 0x0

    :goto_4
    if-ge v10, v0, :cond_4

    move-wide v15, v5

    int-to-long v5, v10

    .line 359
    aget v8, p0, v10

    move-wide/from16 v19, v3

    int-to-long v3, v8

    mul-long/2addr v5, v3

    add-long/2addr v11, v5

    int-to-long v3, v8

    add-long/2addr v13, v3

    long-to-double v3, v11

    long-to-double v5, v13

    div-double/2addr v3, v5

    .line 362
    aput-wide v3, v7, v10

    add-int/lit8 v10, v10, 0x1

    move-wide v5, v15

    move-wide/from16 v3, v19

    goto :goto_4

    :cond_4
    move-wide/from16 v19, v3

    move-wide v15, v5

    .line 366
    new-array v0, v0, [D

    move v3, v2

    const-wide/16 v8, 0x0

    const-wide/16 v17, 0x0

    :goto_5
    if-ltz v3, :cond_5

    int-to-long v4, v3

    .line 370
    aget v6, p0, v3

    int-to-long v10, v6

    mul-long/2addr v4, v10

    add-long/2addr v8, v4

    int-to-long v4, v6

    add-long v4, v17, v4

    long-to-double v10, v8

    long-to-double v12, v4

    div-double/2addr v10, v12

    .line 373
    aput-wide v10, v0, v3

    add-int/lit8 v3, v3, -0x1

    move-wide/from16 v17, v4

    goto :goto_5

    :cond_5
    const/4 v3, -0x1

    const-wide v4, 0x7fefffffffffffffL    # Double.MAX_VALUE

    move v6, v1

    :goto_6
    if-gt v6, v2, :cond_b

    const-wide/16 v8, 0x0

    move v10, v1

    :goto_7
    const-wide v13, 0x3eb0c6f7a0b5ed8dL    # 1.0E-6

    if-gt v10, v6, :cond_7

    const-wide v17, 0x3feffffde7210be9L    # 0.999999

    int-to-double v11, v10

    .line 384
    aget-wide v21, v7, v6

    sub-double v11, v11, v21

    invoke-static {v11, v12}, Ljava/lang/Math;->abs(D)D

    move-result-wide v11

    mul-double v11, v11, v19

    add-double/2addr v11, v15

    div-double v11, v15, v11

    cmpg-double v13, v11, v13

    if-ltz v13, :cond_6

    cmpl-double v13, v11, v17

    if-gtz v13, :cond_6

    .line 387
    aget v13, p0, v10

    int-to-double v13, v13

    move-object/from16 v22, v0

    move/from16 v21, v1

    neg-double v0, v11

    invoke-static {v11, v12}, Ljava/lang/Math;->log(D)D

    move-result-wide v17

    mul-double v0, v0, v17

    sub-double v11, v15, v11

    invoke-static {v11, v12}, Ljava/lang/Math;->log(D)D

    move-result-wide v17

    mul-double v11, v11, v17

    sub-double/2addr v0, v11

    mul-double/2addr v13, v0

    add-double/2addr v8, v13

    goto :goto_8

    :cond_6
    move-object/from16 v22, v0

    move/from16 v21, v1

    :goto_8
    add-int/lit8 v10, v10, 0x1

    move/from16 v1, v21

    move-object/from16 v0, v22

    goto :goto_7

    :cond_7
    move-object/from16 v22, v0

    move/from16 v21, v1

    const-wide v17, 0x3feffffde7210be9L    # 0.999999

    add-int/lit8 v0, v6, 0x1

    move v1, v0

    :goto_9
    if-gt v1, v2, :cond_9

    int-to-double v10, v1

    .line 393
    aget-wide v23, v22, v6

    sub-double v10, v10, v23

    invoke-static {v10, v11}, Ljava/lang/Math;->abs(D)D

    move-result-wide v10

    mul-double v10, v10, v19

    add-double/2addr v10, v15

    div-double v10, v15, v10

    cmpg-double v12, v10, v13

    if-ltz v12, :cond_8

    cmpl-double v12, v10, v17

    if-gtz v12, :cond_8

    .line 396
    aget v12, p0, v1

    int-to-double v13, v12

    move/from16 p1, v0

    move v12, v1

    neg-double v0, v10

    invoke-static {v10, v11}, Ljava/lang/Math;->log(D)D

    move-result-wide v25

    mul-double v0, v0, v25

    sub-double v10, v15, v10

    invoke-static {v10, v11}, Ljava/lang/Math;->log(D)D

    move-result-wide v25

    mul-double v10, v10, v25

    sub-double/2addr v0, v10

    mul-double/2addr v13, v0

    add-double/2addr v8, v13

    goto :goto_a

    :cond_8
    move/from16 p1, v0

    move v12, v1

    :goto_a
    add-int/lit8 v1, v12, 0x1

    move/from16 v0, p1

    const-wide v13, 0x3eb0c6f7a0b5ed8dL    # 1.0E-6

    goto :goto_9

    :cond_9
    move/from16 p1, v0

    cmpg-double v0, v8, v4

    if-gez v0, :cond_a

    move v3, v6

    move-wide v4, v8

    :cond_a
    move/from16 v6, p1

    move/from16 v1, v21

    move-object/from16 v0, v22

    goto/16 :goto_6

    :cond_b
    return v3
.end method

.method public static computeLi(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;DD)D
    .locals 2

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    add-double/2addr p3, v0

    sub-double/2addr p3, p1

    double-to-int p3, p3

    .line 215
    new-array p4, p3, [I

    .line 217
    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/GImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;D[I)V

    .line 219
    invoke-static {p4, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;->computeLi([II)I

    move-result p0

    int-to-double p3, p0

    add-double/2addr p3, p1

    return-wide p3
.end method

.method public static computeLi([II)I
    .locals 19

    .line 252
    invoke-static/range {p0 .. p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/HistogramStatistics;->mean([II)D

    move-result-wide v0

    const-wide/high16 v2, 0x3fe0000000000000L    # 0.5

    add-double/2addr v0, v2

    double-to-int v0, v0

    :goto_0
    int-to-double v4, v0

    add-double/2addr v4, v2

    double-to-int v1, v4

    const-wide/16 v4, 0x0

    const/4 v6, 0x0

    move-wide v7, v4

    move-wide v9, v7

    :goto_1
    if-gt v6, v1, :cond_0

    int-to-long v11, v6

    .line 263
    aget v13, p0, v6

    int-to-long v14, v13

    mul-long/2addr v11, v14

    add-long/2addr v9, v11

    int-to-long v11, v13

    add-long/2addr v7, v11

    add-int/lit8 v6, v6, 0x1

    goto :goto_1

    :cond_0
    cmp-long v6, v7, v4

    if-nez v6, :cond_1

    const-wide/16 v9, 0x0

    goto :goto_2

    :cond_1
    long-to-double v9, v9

    long-to-double v6, v7

    div-double/2addr v9, v6

    :goto_2
    add-int/lit8 v6, v1, 0x1

    move/from16 v7, p1

    move-wide v15, v2

    move-wide v2, v4

    move-wide v13, v2

    :goto_3
    if-ge v6, v7, :cond_2

    move-wide/from16 v17, v4

    int-to-long v4, v6

    .line 272
    aget v8, p0, v6

    int-to-long v11, v8

    mul-long/2addr v4, v11

    add-long/2addr v2, v4

    int-to-long v4, v8

    add-long/2addr v13, v4

    add-int/lit8 v6, v6, 0x1

    move-wide/from16 v4, v17

    goto :goto_3

    :cond_2
    move-wide/from16 v17, v4

    cmp-long v4, v13, v17

    if-nez v4, :cond_3

    const-wide/16 v11, 0x0

    goto :goto_4

    :cond_3
    long-to-double v2, v2

    long-to-double v4, v13

    div-double v11, v2, v4

    :goto_4
    sub-double v2, v9, v11

    .line 285
    invoke-static {v9, v10}, Ljava/lang/Math;->log(D)D

    move-result-wide v4

    invoke-static {v11, v12}, Ljava/lang/Math;->log(D)D

    move-result-wide v8

    sub-double/2addr v4, v8

    div-double/2addr v2, v4

    .line 287
    sget-wide v4, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->EPS:D

    neg-double v4, v4

    cmpg-double v4, v2, v4

    if-gez v4, :cond_4

    sub-double/2addr v2, v15

    :goto_5
    double-to-int v2, v2

    goto :goto_6

    :cond_4
    add-double/2addr v2, v15

    goto :goto_5

    :goto_6
    sub-int v0, v2, v0

    .line 294
    invoke-static {v0}, Ljava/lang/Math;->abs(I)I

    move-result v0

    int-to-double v3, v0

    cmpl-double v0, v3, v15

    if-gtz v0, :cond_5

    return v1

    :cond_5
    move v0, v2

    move-wide v2, v15

    goto :goto_0
.end method

.method public static computeOtsu(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;DD)D
    .locals 2

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    add-double/2addr p3, v0

    sub-double/2addr p3, p1

    double-to-int p3, p3

    .line 57
    new-array p4, p3, [I

    .line 59
    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/GImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;D[I)V

    .line 62
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, p0

    .line 64
    invoke-static {p4, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;->computeOtsu([III)I

    move-result p0

    int-to-double p3, p0

    add-double/2addr p3, p1

    return-wide p3
.end method

.method public static computeOtsu([III)I
    .locals 20

    move/from16 v0, p1

    int-to-double v1, v0

    const-wide/16 v3, 0x0

    const/4 v5, 0x0

    move-wide v7, v3

    move v6, v5

    :goto_0
    if-ge v6, v0, :cond_0

    int-to-double v9, v6

    div-double/2addr v9, v1

    .line 110
    aget v11, p0, v6

    int-to-double v11, v11

    mul-double/2addr v9, v11

    add-double/2addr v7, v9

    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_0
    move v9, v5

    move v10, v9

    move v11, v10

    move-wide v5, v3

    :goto_1
    if-ge v9, v0, :cond_4

    .line 119
    aget v12, p0, v9

    add-int/2addr v10, v12

    if-nez v10, :cond_1

    move-wide/from16 v16, v1

    goto :goto_2

    :cond_1
    sub-int v13, p2, v10

    if-nez v13, :cond_2

    goto :goto_3

    :cond_2
    int-to-double v14, v9

    div-double/2addr v14, v1

    move-wide/from16 v16, v1

    int-to-double v0, v12

    mul-double/2addr v14, v0

    add-double/2addr v3, v14

    int-to-double v0, v10

    div-double v14, v3, v0

    sub-double v18, v7, v3

    int-to-double v12, v13

    div-double v18, v18, v12

    mul-double/2addr v0, v12

    sub-double v14, v14, v18

    mul-double/2addr v0, v14

    mul-double/2addr v0, v14

    cmpl-double v2, v0, v5

    if-lez v2, :cond_3

    move-wide v5, v0

    move v11, v9

    :cond_3
    :goto_2
    add-int/lit8 v9, v9, 0x1

    move/from16 v0, p1

    move-wide/from16 v1, v16

    goto :goto_1

    :cond_4
    :goto_3
    return v11
.end method

.method public static localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    .line 596
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-eqz v0, :cond_0

    .line 597
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    double-to-float p3, p3

    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    check-cast p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move p4, p5

    move-object p5, p6

    move-object p6, p7

    invoke-static/range {p0 .. p6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    :cond_0
    move-object v1, p2

    move-object p2, p1

    move p1, p5

    move-wide p4, p3

    move-object p3, v1

    .line 599
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-eqz v0, :cond_1

    .line 600
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    double-to-float p4, p4

    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    check-cast p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move p5, p1

    move-object p1, p0

    invoke-static/range {p1 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 602
    :cond_1
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    if-eqz v0, :cond_2

    .line 603
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    double-to-float p4, p4

    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    check-cast p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move p5, p1

    move-object p1, p0

    invoke-static/range {p1 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->localGaussian(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 606
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Unknown image type: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    .line 556
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-eqz v0, :cond_0

    .line 557
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    double-to-float p3, p3

    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    check-cast p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move p4, p5

    move-object p5, p6

    move-object p6, p7

    move-object p7, p8

    invoke-static/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    :cond_0
    move-object v1, p2

    move-object p2, p1

    move p1, p5

    move-wide p4, p3

    move-object p3, v1

    .line 559
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-eqz v0, :cond_1

    .line 560
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    double-to-float p4, p4

    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    check-cast p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move p5, p1

    move-object p1, p0

    invoke-static/range {p1 .. p8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 562
    :cond_1
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    if-eqz v0, :cond_2

    .line 563
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    double-to-float p4, p4

    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    check-cast p7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move p5, p1

    move-object p1, p0

    invoke-static/range {p1 .. p8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;FZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 566
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Unknown image type: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 1

    .line 513
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-eqz v0, :cond_0

    .line 514
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    double-to-float p2, p2

    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;FZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 515
    :cond_0
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-eqz v0, :cond_1

    .line 516
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    double-to-int p2, p2

    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 517
    :cond_1
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    if-eqz v0, :cond_2

    .line 518
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    double-to-int p2, p2

    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 519
    :cond_2
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    if-eqz v0, :cond_3

    .line 520
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    double-to-int p2, p2

    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 521
    :cond_3
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    if-eqz v0, :cond_4

    .line 522
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    double-to-int p2, p2

    invoke-static {p0, p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 523
    :cond_4
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    if-eqz v0, :cond_5

    .line 524
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 526
    :cond_5
    new-instance p1, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Unknown image type: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
