.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;
.super Ljava/lang/Object;
.source "EdgeIntensityPolygon.java"


# instance fields
.field private averageInside:D

.field private averageOutside:D

.field private cornerOffset:D

.field private final offsetA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field private final offsetB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field scorer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;

.field private tangentDistance:D


# direct methods
.method public constructor <init>(DDILjava/lang/Class;)V
    .locals 1

    .line 63
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->offsetA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 44
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->offsetB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 64
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->cornerOffset:D

    .line 65
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->tangentDistance:D

    .line 67
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;

    invoke-direct {p1, p5, p6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;-><init>(ILjava/lang/Class;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->scorer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;

    return-void
.end method


# virtual methods
.method public computeEdge(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Z)Z
    .locals 26

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    const-wide/16 v2, 0x0

    .line 97
    iput-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageInside:D

    .line 98
    iput-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageOutside:D

    if-eqz p2, :cond_0

    const-wide/high16 v4, 0x3ff0000000000000L    # 1.0

    goto :goto_0

    :cond_0
    const-wide/high16 v4, -0x4010000000000000L    # -1.0

    .line 103
    :goto_0
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v6

    const/4 v7, 0x1

    sub-int/2addr v6, v7

    move v9, v6

    const/4 v6, 0x0

    const/4 v10, 0x0

    :goto_1
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v11

    if-ge v6, v11, :cond_3

    .line 105
    invoke-virtual {v1, v9}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v9

    .line 106
    invoke-virtual {v1, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v11

    .line 108
    iget-wide v12, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v14, v9, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v12, v14

    .line 109
    iget-wide v14, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    move/from16 p2, v7

    const/16 v16, 0x0

    iget-wide v7, v9, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v14, v7

    mul-double v7, v12, v12

    mul-double v17, v14, v14

    add-double v7, v7, v17

    .line 110
    invoke-static {v7, v8}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v7

    div-double/2addr v12, v7

    div-double/2addr v14, v7

    .line 115
    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->cornerOffset:D

    const-wide/high16 v19, 0x4008000000000000L    # 3.0

    mul-double v19, v19, v2

    cmpg-double v7, v7, v19

    if-gez v7, :cond_1

    .line 116
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->offsetA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v2, v9}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 117
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->offsetB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v2, v11}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    goto :goto_2

    .line 119
    :cond_1
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->offsetA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-wide/from16 v19, v2

    iget-wide v1, v9, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double v21, v19, v12

    add-double v1, v1, v21

    iput-wide v1, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 120
    iget-wide v1, v9, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double v8, v19, v14

    add-double/2addr v1, v8

    iput-wide v1, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 122
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->offsetB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v2, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double v7, v19, v12

    sub-double/2addr v2, v7

    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 123
    iget-wide v2, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double v7, v19, v14

    sub-double/2addr v2, v7

    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    :goto_2
    neg-double v1, v14

    .line 126
    iget-wide v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->tangentDistance:D

    mul-double/2addr v1, v7

    mul-double v22, v1, v4

    mul-double/2addr v12, v7

    mul-double v24, v12, v4

    .line 129
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->scorer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->offsetA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->offsetB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-object/from16 v19, v1

    move-object/from16 v20, v2

    move-object/from16 v21, v3

    invoke-virtual/range {v19 .. v25}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->computeAverageDerivative(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;DD)D

    .line 131
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->scorer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->getSamplesInside()I

    move-result v1

    if-lez v1, :cond_2

    add-int/lit8 v10, v10, 0x1

    .line 133
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageInside:D

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->scorer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->getAverageUp()D

    move-result-wide v7

    iget-wide v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->tangentDistance:D

    div-double/2addr v7, v11

    add-double/2addr v1, v7

    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageInside:D

    .line 134
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageOutside:D

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->scorer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->getAverageDown()D

    move-result-wide v7

    iget-wide v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->tangentDistance:D

    div-double/2addr v7, v11

    add-double/2addr v1, v7

    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageOutside:D

    :cond_2
    add-int/lit8 v1, v6, 0x1

    move/from16 v7, p2

    move v9, v6

    const-wide/16 v2, 0x0

    move v6, v1

    move-object/from16 v1, p1

    goto/16 :goto_1

    :cond_3
    move/from16 p2, v7

    const/16 v16, 0x0

    if-lez v10, :cond_4

    .line 139
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageInside:D

    int-to-double v3, v10

    div-double/2addr v1, v3

    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageInside:D

    .line 140
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageOutside:D

    div-double/2addr v1, v3

    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageOutside:D

    return p2

    :cond_4
    const-wide/16 v1, 0x0

    .line 142
    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageOutside:D

    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageInside:D

    return v16
.end method

.method public getAverageInside()D
    .locals 2

    .line 183
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageInside:D

    return-wide v0
.end method

.method public getAverageOutside()D
    .locals 2

    .line 187
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->averageOutside:D

    return-wide v0
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 1

    .line 86
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->scorer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/ScoreLineSegmentEdge;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    return-void
.end method
