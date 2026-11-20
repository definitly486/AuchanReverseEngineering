.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;
.super Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;
.source "ConfigPolylineSplitMerge.java"


# instance fields
.field public convexTest:D

.field public cornerScorePenalty:D

.field public extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field public maxNumberOfSideSamples:I

.field public maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field public minimumSideLength:I

.field public refineIterations:I

.field public thresholdSideSplitScore:D


# direct methods
.method public constructor <init>()V
    .locals 4

    .line 28
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;-><init>()V

    const/4 v0, 0x2

    .line 32
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->minimumSideLength:I

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    const-wide/16 v2, 0x0

    .line 38
    invoke-static {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->relative(DD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const-wide v0, 0x3f9999999999999aL    # 0.025

    .line 44
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->cornerScorePenalty:D

    const-wide v0, 0x3fc999999999999aL    # 0.2

    .line 50
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->thresholdSideSplitScore:D

    const/16 v0, 0x32

    .line 56
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->maxNumberOfSideSamples:I

    const-wide/high16 v0, 0x4004000000000000L    # 2.5

    .line 64
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->convexTest:D

    const-wide v0, 0x3fa999999999999aL    # 0.05

    const-wide/high16 v2, 0x4008000000000000L    # 3.0

    .line 70
    invoke-static {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->relative(DD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const/16 v0, 0xa

    .line 76
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->refineIterations:I

    return-void
.end method


# virtual methods
.method public checkValidity()V
    .locals 1

    .line 93
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->checkValidity()V

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 17

    move-object/from16 v0, p0

    .line 98
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->minimumSideLength:I

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-wide v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->cornerScorePenalty:D

    iget-wide v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->thresholdSideSplitScore:D

    iget v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->maxNumberOfSideSamples:I

    iget-wide v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->convexTest:D

    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->refineIterations:I

    iget-boolean v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->loops:Z

    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->minimumSides:I

    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->maximumSides:I

    iget-boolean v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->convex:Z

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    move/from16 v16, v15

    const-string v15, "ConfigPolylineSplitMerge{minimumSideLength="

    invoke-virtual {v0, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", extraConsider="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", cornerScorePenalty="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v3, v4}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v1, ", thresholdSideSplitScore="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v5, v6}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v1, ", maxNumberOfSideSamples="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v7}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", convexTest="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v8, v9}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v1, ", maxSideError="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", refineIterations="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v11}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", loops="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v12}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", minimumSides="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v13}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", maximumSides="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v14}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", convex="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move/from16 v1, v16

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, "}"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
