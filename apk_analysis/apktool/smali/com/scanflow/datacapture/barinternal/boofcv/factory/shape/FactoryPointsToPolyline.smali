.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/FactoryPointsToPolyline;
.super Ljava/lang/Object;
.source "FactoryPointsToPolyline.java"


# direct methods
.method public static create(Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;
    .locals 1

    .line 36
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;

    if-eqz v0, :cond_0

    .line 37
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/FactoryPointsToPolyline;->splitMerge(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    move-result-object p0

    return-object p0

    .line 38
    :cond_0
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;

    if-eqz v0, :cond_1

    .line 39
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/FactoryPointsToPolyline;->splitMerge(Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    move-result-object p0

    return-object p0

    .line 41
    :cond_1
    new-instance p0, Ljava/lang/RuntimeException;

    const-string v0, "Unknown"

    invoke-direct {p0, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static splitMerge(Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;
    .locals 1

    if-nez p0, :cond_0

    .line 62
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;-><init>()V

    .line 63
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->checkValidity()V

    .line 64
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/NewSplitMerge_to_PointsToPolyline;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;)V

    return-object v0
.end method

.method public static splitMerge(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;
    .locals 1

    if-nez p0, :cond_0

    .line 55
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;-><init>()V

    .line 56
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;->checkValidity()V

    .line 57
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/SplitMergeLineRefine_to_PointsToPolyline;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigSplitMergeLineFit;)V

    return-object v0
.end method
