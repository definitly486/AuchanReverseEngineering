.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;
.super Ljava/lang/Object;
.source "NewSplitMerge_to_PointsToPolyline.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;


# instance fields
.field alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

.field refine:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;)V
    .locals 3

    .line 42
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    .line 44
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->minimumSideLength:I

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setMinimumSideLength(I)V

    .line 45
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->maxNumberOfSideSamples:I

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setMaxNumberOfSideSamples(I)V

    .line 46
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->maximumSides:I

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setMaxSides(I)V

    .line 47
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->minimumSides:I

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setMinSides(I)V

    .line 48
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setExtraConsider(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V

    .line 49
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget-boolean v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->convex:Z

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setConvex(Z)V

    .line 50
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget-wide v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->thresholdSideSplitScore:D

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setThresholdSideSplitScore(D)V

    .line 51
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget-wide v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->cornerScorePenalty:D

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setCornerScorePenalty(D)V

    .line 52
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget-wide v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->convexTest:D

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setConvexTest(D)V

    .line 53
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setMaxSideError(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V

    .line 54
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    iget-boolean v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->loops:Z

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setLoops(Z)V

    .line 56
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->refineIterations:I

    if-lez v0, :cond_0

    .line 57
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;

    iget-boolean p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->loops:Z

    invoke-direct {v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;-><init>(ZI)V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->refine:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;

    :cond_0
    return-void
.end method


# virtual methods
.method public getMinimumSides()I
    .locals 1

    .line 84
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->getMinSides()I

    move-result v0

    return v0
.end method

.method public isLoop()Z
    .locals 1

    .line 99
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->isLoops()Z

    move-result v0

    return v0
.end method

.method public process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 2

    .line 63
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->process(Ljava/util/List;)Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 66
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->getBestPolyline()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    move-result-object v0

    if-nez v0, :cond_1

    return v1

    .line 72
    :cond_1
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 74
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->refine:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;

    if-eqz v0, :cond_3

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->fit(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result p1

    if-eqz p1, :cond_2

    goto :goto_0

    :cond_2
    return v1

    :cond_3
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method public setConvex(Z)V
    .locals 1

    .line 104
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setConvex(Z)V

    return-void
.end method

.method public setMaximumSides(I)V
    .locals 1

    .line 89
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setMaxSides(I)V

    return-void
.end method

.method public setMinimumSides(I)V
    .locals 1

    .line 79
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setMinSides(I)V

    return-void
.end method
