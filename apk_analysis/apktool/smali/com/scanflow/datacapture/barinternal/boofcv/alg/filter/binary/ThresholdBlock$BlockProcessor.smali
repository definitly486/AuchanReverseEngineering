.class public interface abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;
.super Ljava/lang/Object;
.source "ThresholdBlock.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "BlockProcessor"
.end annotation


# virtual methods
.method public abstract computeBlockStatistics(IIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
.end method

.method public abstract copy()Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;
.end method

.method public abstract createStats()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
.end method

.method public abstract init(IIZ)V
.end method

.method public abstract thresholdBlock(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
.end method
