.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/MaximumLineDistance;
.super Ljava/lang/Object;
.source "MaximumLineDistance.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;


# instance fields
.field line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 32
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/MaximumLineDistance;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    return-void
.end method


# virtual methods
.method public compareScore(DD)I
    .locals 1

    .line 72
    cmpl-double v0, p1, p3

    if-lez v0, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    cmpg-double p1, p1, p3

    if-gez p1, :cond_1

    const/4 p1, -0x1

    return p1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method

.method public selectSplitPoint(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;)V
    .locals 8

    .line 36
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/MaximumLineDistance;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    invoke-static {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->assignLine(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;)V

    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    const/4 v2, 0x1

    if-lt p3, p2, :cond_1

    .line 39
    iput p2, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    .line 40
    iput-wide v0, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->score:D

    add-int/2addr p2, v2

    :goto_0
    if-ge p2, p3, :cond_3

    .line 42
    invoke-interface {p1, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 43
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/MaximumLineDistance;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    iget v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v2, v2

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v4, v0

    invoke-static {v1, v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Distance2D_F64;->distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;DD)D

    move-result-wide v0

    .line 45
    iget-wide v2, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->score:D

    cmpl-double v2, v0, v2

    if-lez v2, :cond_0

    .line 46
    iput-wide v0, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->score:D

    .line 47
    iput p2, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    :cond_0
    add-int/lit8 p2, p2, 0x1

    goto :goto_0

    .line 51
    :cond_1
    iput p2, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    .line 52
    iput-wide v0, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->score:D

    .line 53
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    sub-int/2addr v0, p2

    add-int/2addr v0, p3

    :goto_1
    if-ge v2, v0, :cond_3

    add-int p3, p2, v2

    .line 55
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v1

    rem-int/2addr p3, v1

    .line 56
    invoke-interface {p1, p3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 57
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/MaximumLineDistance;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    iget v4, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v4, v4

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v6, v1

    invoke-static {v3, v4, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Distance2D_F64;->distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;DD)D

    move-result-wide v3

    .line 59
    iget-wide v5, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->score:D

    cmpl-double v1, v3, v5

    if-lez v1, :cond_2

    .line 60
    iput-wide v3, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->score:D

    .line 61
    iput p3, p4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    :cond_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_3
    return-void
.end method
