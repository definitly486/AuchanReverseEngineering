.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Entropy;
.super Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;
.source "GlobalBinaryFilter.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Entropy"
.end annotation


# direct methods
.method public constructor <init>(DDDZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V
    .locals 0

    .line 135
    invoke-direct/range {p0 .. p8}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;-><init>(DDDZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V

    return-void
.end method


# virtual methods
.method computeThreshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)D
    .locals 4

    .line 140
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->minValue:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->maxValue:D

    invoke-static {p1, v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;->computeEntropy(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;DD)D

    move-result-wide v0

    return-wide v0
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 133
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-super {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method
