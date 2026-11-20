.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;
.super Ljava/lang/Object;
.source "SplitMergeLineRefine_to_PointsToPolyline.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;


# instance fields
.field convex:Z

.field maxVertexes:I

.field minVertexes:I

.field private final pruned:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

.field private pruner:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;

.field refine:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;

.field splitMerge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;

.field tmp:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;)V
    .locals 5

    .line 60
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const v0, 0x7fffffff

    .line 45
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->maxVertexes:I

    const/4 v0, 0x3

    .line 46
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->minVertexes:I

    .line 53
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->pruned:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    const/4 v0, 0x1

    .line 56
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->convex:Z

    .line 58
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->tmp:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 61
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->minimumSide:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->copy()Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    .line 62
    iget-boolean v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->loop:Z

    if-eqz v1, :cond_0

    .line 63
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->splitFraction:D

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->iterations:I

    invoke-direct {v1, v2, v3, v0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;-><init>(DLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;I)V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->splitMerge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;

    goto :goto_0

    .line 65
    :cond_0
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitSegment;

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->splitFraction:D

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->iterations:I

    invoke-direct {v1, v2, v3, v0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitSegment;-><init>(DLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;I)V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->splitMerge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;

    .line 68
    :goto_0
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->refine:I

    if-lez v0, :cond_1

    .line 69
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;

    iget-boolean v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->loop:Z

    invoke-direct {v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;-><init>(ZI)V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->refine:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;

    .line 72
    :cond_1
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->pruneSplitPenalty:D

    const-wide/16 v2, 0x0

    cmpl-double v2, v0, v2

    if-lez v2, :cond_2

    .line 73
    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;

    invoke-direct {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;-><init>(D)V

    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->pruner:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;

    .line 76
    :cond_2
    iget-boolean v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->convex:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->convex:Z

    .line 77
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->minimumSides:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->minVertexes:I

    .line 78
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->maximumSides:I

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->maxVertexes:I

    return-void
.end method


# virtual methods
.method public getMinimumSides()I
    .locals 1

    .line 114
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->minVertexes:I

    return v0
.end method

.method public isLoop()Z
    .locals 1

    .line 131
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->splitMerge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;

    instance-of v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;

    return v0
.end method

.method public process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 9

    .line 83
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->splitMerge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 87
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->refine:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;

    if-eqz v0, :cond_1

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->fit(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v0

    if-nez v0, :cond_1

    return v1

    .line 91
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->pruner:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;

    if-eqz v0, :cond_2

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->pruned:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0, p1, p2, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->prune(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 92
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->pruned:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 95
    :cond_2
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->maxVertexes:I

    if-gt v0, v2, :cond_7

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->minVertexes:I

    if-ge v0, v2, :cond_3

    goto :goto_2

    .line 98
    :cond_3
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->tmp:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    move v4, v1

    .line 99
    :goto_0
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge v4, v0, :cond_4

    .line 100
    invoke-virtual {p2, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v0

    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 101
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->tmp:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v5, v2

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v7, v0

    invoke-virtual/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->set(IDD)V

    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 104
    :cond_4
    iget-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->convex:Z

    if-eqz p1, :cond_6

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->tmp:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPolygons2D_F64;->isConvex(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z

    move-result p1

    if-eqz p1, :cond_5

    goto :goto_1

    :cond_5
    return v1

    :cond_6
    :goto_1
    const/4 p1, 0x1

    return p1

    :cond_7
    :goto_2
    return v1
.end method

.method public setConvex(Z)V
    .locals 0

    .line 136
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->convex:Z

    return-void
.end method

.method public setMaximumSides(I)V
    .locals 1

    .line 119
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->maxVertexes:I

    .line 121
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->splitMerge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;

    mul-int/lit8 p1, p1, 0x2

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->setAbortSplits(I)V

    return-void
.end method

.method public setMinimumSides(I)V
    .locals 0

    .line 109
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;->minVertexes:I

    return-void
.end method
