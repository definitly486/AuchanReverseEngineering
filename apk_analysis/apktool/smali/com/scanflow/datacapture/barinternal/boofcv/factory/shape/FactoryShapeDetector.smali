.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/FactoryShapeDetector;
.super Ljava/lang/Object;
.source "FactoryShapeDetector.java"


# direct methods
.method public static polygon(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;
    .locals 9

    if-nez p0, :cond_0

    .line 89
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;-><init>()V

    .line 90
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->checkValidity()V

    .line 92
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->refineContour:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_1

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;-><init>()V

    move-object v4, v0

    goto :goto_0

    :cond_1
    move-object v4, v1

    .line 94
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;

    if-eqz v0, :cond_2

    .line 95
    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/FactoryShapeDetector;->refinePolygon(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;

    move-result-object v1

    :cond_2
    move-object v5, v1

    .line 97
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/FactoryShapeDetector;->polygonContour(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    move-result-object v3

    .line 99
    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->minimumRefineEdgeIntensity:D

    iget-boolean v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->adjustForThresholdBias:Z

    invoke-direct/range {v2 .. v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;DZ)V

    return-object v2
.end method

.method public static polygonContour(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;
    .locals 11

    .line 106
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->checkValidity()V

    .line 108
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourToPoly:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;

    .line 109
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/FactoryPointsToPolyline;->create(Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    move-result-object v2

    .line 111
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/FactoryBinaryContourFinder;->linearExternal()Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinderLinearExternal;

    move-result-object v9

    .line 112
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourRule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    invoke-interface {v9, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->setConnectRule(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V

    .line 113
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-interface {v9, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->setMinContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V

    .line 114
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->maximumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-interface {v9, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->setMaxContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V

    .line 116
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->clockwise:Z

    iget-boolean v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->canTouchBorder:Z

    iget-wide v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumEdgeIntensity:D

    iget-wide v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->tangentEdgeIntensity:D

    move-object v10, p1

    invoke-direct/range {v1 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;ZZDDLcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;Ljava/lang/Class;)V

    return-object v1
.end method

.method public static refinePolygon(Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;
    .locals 11

    .line 123
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->cornerOffset:D

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->lineSamples:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->sampleRadius:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->maxIterations:I

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->convergeTolPixels:D

    iget-wide v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->maxCornerChangePixel:D

    move-object v10, p1

    invoke-direct/range {v0 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;-><init>(DIIIDDLjava/lang/Class;)V

    return-object v0
.end method
