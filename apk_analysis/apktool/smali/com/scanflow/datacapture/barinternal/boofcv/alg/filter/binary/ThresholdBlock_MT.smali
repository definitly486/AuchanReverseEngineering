.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;
.source "ThresholdBlock_MT.java"


# direct methods
.method public static synthetic $r8$lambda$A_SfUZzdujV7dIxQsb6nOmjL2zo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;IIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;I)V
    .locals 9

    .line 55
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->processors:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->pop()Ljava/lang/Object;

    move-result-object v0

    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    .line 56
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->thresholdFromLocalBlocks:Z

    invoke-interface {v1, v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->init(IIZ)V

    .line 57
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    mul-int v3, p5, v0

    .line 59
    div-int p5, v3, v0

    mul-int/2addr p5, p1

    const/4 p1, 0x0

    move v2, p1

    move v6, p5

    :goto_0
    if-ge v2, p2, :cond_0

    .line 61
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-object v7, p4

    invoke-interface/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 60
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    add-int/2addr v2, p1

    add-int/2addr v6, p3

    goto :goto_0

    :cond_0
    move-object v7, p4

    .line 64
    iget p1, v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-eq p2, p1, :cond_1

    sub-int v4, p1, p2

    .line 65
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move v2, p2

    invoke-interface/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 67
    :cond_1
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->processors:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->recycle(Ljava/lang/Object;)V

    return-void
.end method

.method public static synthetic $r8$lambda$Pt3EE6LR3shwLSRXYi9R_MduhWY(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V
    .locals 7

    .line 90
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->processors:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->pop()Ljava/lang/Object;

    move-result-object v0

    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    .line 91
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->thresholdFromLocalBlocks:Z

    invoke-interface {v1, v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->init(IIZ)V

    const/4 v0, 0x0

    move v2, v0

    .line 93
    :goto_0
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    iget v0, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v0, :cond_0

    move-object v4, p1

    move-object v6, p2

    move v3, p3

    .line 94
    invoke-interface/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->thresholdBlock(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V
    .locals 0

    .line 39
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V

    return-void
.end method


# virtual methods
.method protected applyThreshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 2

    .line 89
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    const/4 p1, 0x0

    invoke-static {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method protected computeStatistics(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;II)V
    .locals 11

    .line 46
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getNumBands()I

    move-result v5

    .line 47
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    .line 49
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    div-int v1, p3, v0

    mul-int/2addr v0, v1

    if-ge v0, p3, :cond_0

    add-int/lit8 v1, v1, 0x1

    :cond_0
    move v0, v1

    .line 54
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;

    move-object v2, p0

    move-object v6, p1

    move v4, p2

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;IIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    move p1, v4

    move p2, v5

    move-object v9, v6

    const/4 v4, 0x0

    invoke-static {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    .line 72
    iget v0, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-eq p3, v0, :cond_2

    .line 73
    iget-object v0, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->processors:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->pop()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    .line 74
    iget v1, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    iget v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    iget-boolean v6, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->thresholdFromLocalBlocks:Z

    invoke-interface {v0, v1, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->init(IIZ)V

    .line 76
    iget v1, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    div-int v1, p3, v1

    mul-int/2addr v1, v3

    .line 78
    iget v3, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int v7, v3, p3

    move v8, v1

    :goto_0
    if-ge v4, p1, :cond_1

    .line 80
    iget v6, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    iget-object v10, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move v5, p3

    move-object v3, v0

    invoke-interface/range {v3 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 79
    iget p3, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    add-int/2addr v4, p3

    add-int/2addr v8, p2

    move p3, v5

    goto :goto_0

    :cond_1
    move v5, p3

    move-object v3, v0

    .line 82
    iget p2, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-eq p1, p2, :cond_2

    sub-int v6, p2, p1

    .line 83
    iget-object v10, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move v4, p1

    invoke-interface/range {v3 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    :cond_2
    return-void
.end method
