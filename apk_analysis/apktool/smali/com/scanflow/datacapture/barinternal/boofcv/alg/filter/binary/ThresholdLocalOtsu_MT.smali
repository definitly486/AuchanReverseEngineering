.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;
.source "ThresholdLocalOtsu_MT.java"


# direct methods
.method public static synthetic $r8$lambda$dUCKF_QMbnfjPIhcrBpWUGX8CfQ(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IBBIII)V
    .locals 16

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p3

    .line 43
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->helpers:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->pop()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;

    move/from16 v4, p8

    :goto_0
    move/from16 v5, p9

    if-ge v4, v5, :cond_3

    .line 45
    iget v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v7, v4

    add-int/2addr v6, v7

    add-int v6, v6, p2

    .line 46
    iget v7, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v8, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v8, v4

    add-int/2addr v7, v8

    add-int v7, v7, p2

    sub-int v8, v4, p4

    const/4 v9, 0x0

    .line 48
    invoke-virtual {v3, v9, v8, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->computeHistogram(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 49
    iget-object v9, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v10, v7, 0x1

    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v12, v6, 0x1

    aget-byte v6, v11, v6

    and-int/lit16 v6, v6, 0xff

    int-to-double v13, v6

    iget-object v6, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    move v11, v4

    iget-wide v4, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    cmpg-double v4, v13, v4

    if-gtz v4, :cond_0

    move/from16 v4, p5

    goto :goto_1

    :cond_0
    move/from16 v4, p6

    :goto_1
    aput-byte v4, v9, v7

    add-int/lit8 v4, p2, 0x1

    move/from16 v5, p7

    :goto_2
    if-ge v4, v5, :cond_2

    sub-int v6, v4, p2

    .line 52
    invoke-virtual {v3, v6, v8, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramX(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 53
    iget-object v6, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v7, v10, 0x1

    iget-object v9, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v13, v12, 0x1

    aget-byte v9, v9, v12

    and-int/lit16 v9, v9, 0xff

    int-to-double v14, v9

    iget-object v9, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    iget-wide v1, v9, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    cmpg-double v1, v14, v1

    if-gtz v1, :cond_1

    move/from16 v1, p5

    goto :goto_3

    :cond_1
    move/from16 v1, p6

    :goto_3
    aput-byte v1, v6, v10

    add-int/lit8 v4, v4, 0x1

    move-object/from16 v1, p1

    move-object/from16 v2, p3

    move v10, v7

    move v12, v13

    goto :goto_2

    :cond_2
    add-int/lit8 v4, v11, 0x1

    move-object/from16 v1, p1

    move-object/from16 v2, p3

    goto :goto_0

    .line 59
    :cond_3
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->helpers:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->recycle(Ljava/lang/Object;)V

    return-void
.end method

.method public constructor <init>(ZLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DDZ)V
    .locals 0

    .line 35
    invoke-direct/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;-><init>(ZLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DDZ)V

    return-void
.end method


# virtual methods
.method protected process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IIIIBB)V
    .locals 9

    .line 41
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;

    move-object v1, p0

    move-object v2, p1

    move-object v4, p2

    move v3, p3

    move v5, p4

    move v8, p5

    move/from16 v6, p7

    move/from16 v7, p8

    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IBBI)V

    invoke-static {p4, p6, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->helpers:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->pop()Ljava/lang/Object;

    move-result-object v0

    move-object v8, v0

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;

    move-object v3, p2

    move v6, p3

    move v4, p4

    move v7, p5

    move v5, p6

    .line 62
    invoke-virtual/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->applyToBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IIIILcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;)V

    .line 63
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->helpers:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {p1, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->recycle(Ljava/lang/Object;)V

    return-void
.end method
