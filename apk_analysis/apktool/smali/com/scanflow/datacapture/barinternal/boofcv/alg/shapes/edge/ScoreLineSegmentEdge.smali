.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;
.source "ScoreLineSegmentEdge.java"


# instance fields
.field averageDown:D

.field averageUp:D

.field numSamples:I

.field samplesInside:I


# direct methods
.method public constructor <init>(ILjava/lang/Class;)V
    .locals 0

    .line 52
    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;-><init>(Ljava/lang/Class;)V

    .line 53
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->numSamples:I

    return-void
.end method


# virtual methods
.method public computeAverageDerivative(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;DD)D
    .locals 26

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    const/4 v3, 0x0

    .line 77
    iput v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->samplesInside:I

    const-wide/16 v4, 0x0

    .line 78
    iput-wide v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageDown:D

    iput-wide v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageUp:D

    .line 80
    :goto_0
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->numSamples:I

    if-ge v3, v6, :cond_2

    .line 81
    iget-wide v7, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v9, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v7, v9

    int-to-double v11, v3

    mul-double/2addr v7, v11

    add-int/lit8 v13, v6, -0x1

    int-to-double v13, v13

    div-double/2addr v7, v13

    add-double v14, v7, v9

    .line 82
    iget-wide v7, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v9, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v7, v9

    mul-double/2addr v7, v11

    add-int/lit8 v6, v6, -0x1

    int-to-double v11, v6

    div-double/2addr v7, v11

    add-double v16, v7, v9

    add-double v18, v14, p3

    add-double v10, v16, p5

    .line 86
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->getWidth()I

    move-result v6

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v7}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->getHeight()I

    move-result v7

    move-wide/from16 v8, v18

    invoke-static/range {v6 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->isInside(IIDD)Z

    move-result v6

    if-nez v6, :cond_0

    goto :goto_1

    :cond_0
    sub-double v22, v14, p3

    sub-double v20, v16, p5

    .line 91
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->getWidth()I

    move-result v6

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v7}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->getHeight()I

    move-result v7

    move-wide/from16 v24, v20

    move/from16 v20, v6

    move/from16 v21, v7

    invoke-static/range {v20 .. v25}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->isInside(IIDD)Z

    move-result v6

    if-nez v6, :cond_1

    goto :goto_1

    .line 94
    :cond_1
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->samplesInside:I

    add-int/lit8 v6, v6, 0x1

    iput v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->samplesInside:I

    .line 96
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    move-wide/from16 v20, v10

    invoke-virtual/range {v13 .. v21}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->compute(DDDD)D

    move-result-wide v6

    .line 97
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    move-wide/from16 v18, v22

    move-wide/from16 v20, v24

    invoke-virtual/range {v13 .. v21}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->compute(DDDD)D

    move-result-wide v8

    .line 101
    iget-wide v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageUp:D

    add-double/2addr v10, v6

    iput-wide v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageUp:D

    .line 102
    iget-wide v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageDown:D

    add-double/2addr v6, v8

    iput-wide v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageDown:D

    :goto_1
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 105
    :cond_2
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->samplesInside:I

    if-nez v1, :cond_3

    return-wide v4

    .line 107
    :cond_3
    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageUp:D

    int-to-double v4, v1

    div-double/2addr v2, v4

    iput-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageUp:D

    .line 108
    iget-wide v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageDown:D

    int-to-double v6, v1

    div-double/2addr v4, v6

    iput-wide v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageDown:D

    sub-double/2addr v2, v4

    return-wide v2
.end method

.method public getAverageDown()D
    .locals 2

    .line 130
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageDown:D

    return-wide v0
.end method

.method public getAverageUp()D
    .locals 2

    .line 126
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->averageUp:D

    return-wide v0
.end method

.method public getSamplesInside()I
    .locals 1

    .line 114
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->samplesInside:I

    return v0
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 1

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->wrap(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 62
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;)V

    return-void
.end method
