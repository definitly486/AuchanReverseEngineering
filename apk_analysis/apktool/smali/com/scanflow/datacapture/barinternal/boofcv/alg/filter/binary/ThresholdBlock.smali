.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;
.super Ljava/lang/Object;
.source "ThresholdBlock.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;
    }
.end annotation


# instance fields
.field protected blockHeight:I

.field protected blockWidth:I

.field imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field protected original:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

.field protected processors:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

.field protected requestedBlockWidth:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field protected stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

.field protected thresholdFromLocalBlocks:Z


# direct methods
.method public static synthetic $r8$lambda$rYKxCeZEF63--AEzW646cAxhqIk(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;
    .locals 0

    .line 81
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->copy()Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    move-result-object p0

    return-object p0
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;ZLjava/lang/Class;)V
    .locals 0

    .line 74
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 75
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->requestedBlockWidth:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 76
    invoke-static {p4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object p2

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 77
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->thresholdFromLocalBlocks:Z

    .line 78
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->createStats()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p2

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    .line 80
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->original:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    .line 81
    new-instance p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    new-instance p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$$ExternalSyntheticLambda0;

    invoke-direct {p3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;)V

    invoke-direct {p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack$Factory;)V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->processors:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    return-void
.end method


# virtual methods
.method protected applyThreshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 7

    const/4 v0, 0x0

    move v3, v0

    .line 134
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v3, v1, :cond_1

    move v2, v0

    .line 135
    :goto_1
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    iget v1, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v2, v1, :cond_0

    .line 136
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->original:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    move-object v4, p1

    move-object v6, p2

    invoke-interface/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->thresholdBlock(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    move-object v4, p1

    move-object v6, p2

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method protected computeStatistics(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;II)V
    .locals 11

    move v8, p3

    .line 145
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->original:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->thresholdFromLocalBlocks:Z

    invoke-interface {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->init(IIZ)V

    .line 147
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getNumBands()I

    move-result v9

    const/4 v10, 0x0

    move v0, v10

    move v2, v0

    :goto_0
    if-ge v2, v8, :cond_2

    move v5, v0

    move v1, v10

    :goto_1
    if-ge v1, p2, :cond_0

    .line 152
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->original:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-object v6, p1

    invoke-interface/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 151
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    add-int/2addr v1, v0

    add-int/2addr v5, v9

    goto :goto_1

    .line 155
    :cond_0
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-eq p2, v0, :cond_1

    move v1, v0

    .line 156
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->original:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    sub-int v3, v1, p2

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-object v6, p1

    move v1, p2

    invoke-interface/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    add-int/2addr v5, v9

    :cond_1
    move v0, v5

    .line 150
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    add-int/2addr v2, v1

    goto :goto_0

    .line 161
    :cond_2
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-eq v8, v1, :cond_4

    sub-int v4, v1, v8

    move v5, v0

    move v1, v10

    :goto_2
    if-ge v1, p2, :cond_3

    .line 165
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->original:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-object v6, p1

    move v2, v8

    invoke-interface/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 164
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    add-int/2addr v1, v0

    add-int/2addr v5, v9

    move v8, p3

    goto :goto_2

    .line 167
    :cond_3
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-eq p2, v0, :cond_4

    move v1, v0

    .line 168
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->original:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;

    sub-int v3, v1, p2

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-object v6, p1

    move v1, p2

    move v2, p3

    invoke-interface/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;->computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    :cond_4
    return-void
.end method

.method public getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 183
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 46
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 4

    .line 92
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 94
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->requestedBlockWidth:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v1, v2}, Ljava/lang/Math;->min(II)I

    move-result v1

    int-to-double v1, v1

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result v0

    .line 96
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p0, v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->selectBlockSize(III)V

    .line 98
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->stats:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    div-int/2addr v1, v2

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    div-int/2addr v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshape(II)V

    .line 101
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    rem-int v2, v0, v1

    if-nez v2, :cond_0

    goto :goto_0

    :cond_0
    sub-int v2, v0, v1

    .line 102
    rem-int/2addr v0, v1

    sub-int v0, v2, v0

    .line 103
    :goto_0
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    rem-int v3, v1, v2

    if-nez v3, :cond_1

    goto :goto_1

    :cond_1
    sub-int v3, v1, v2

    .line 104
    rem-int/2addr v1, v2

    sub-int v1, v3, v1

    .line 106
    :goto_1
    invoke-virtual {p0, p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->computeStatistics(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;II)V

    .line 107
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->applyThreshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method

.method selectBlockSize(III)V
    .locals 1

    if-ge p2, p3, :cond_0

    .line 116
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    goto :goto_0

    .line 118
    :cond_0
    div-int v0, p2, p3

    .line 119
    div-int/2addr p2, v0

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockHeight:I

    :goto_0
    if-ge p1, p3, :cond_1

    .line 123
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    return-void

    .line 125
    :cond_1
    div-int p2, p1, p3

    .line 126
    div-int/2addr p1, p2

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;->blockWidth:I

    return-void
.end method
