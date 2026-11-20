.class public Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;
.super Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;
.source "ConfigSplitMergeLineFit.java"


# instance fields
.field public iterations:I

.field public loop:Z

.field public minimumSide:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field public pruneSplitPenalty:D

.field public refine:I

.field public splitFraction:D


# direct methods
.method public constructor <init>()V
    .locals 4

    .line 33
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;-><init>()V

    const-wide v0, 0x3fa999999999999aL    # 0.05

    .line 38
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->splitFraction:D

    const/16 v0, 0xa

    .line 43
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->iterations:I

    const/16 v0, 0x14

    .line 50
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->refine:I

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    .line 57
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->pruneSplitPenalty:D

    const-wide v0, 0x3f9999999999999aL    # 0.025

    const-wide/high16 v2, 0x4024000000000000L    # 10.0

    .line 62
    invoke-static {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->relative(DD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->minimumSide:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const/4 v0, 0x1

    .line 67
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->loop:Z

    return-void
.end method


# virtual methods
.method public checkValidity()V
    .locals 1

    .line 82
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->minimumSide:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->checkValidity()V

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 7

    .line 87
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->splitFraction:D

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->iterations:I

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->minimumSide:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-boolean v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->loop:Z

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "ConfigSplitMergeLineFit{splitFraction="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v0, v1}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", iterations="

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, ", minimumSide="

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", loop="

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
