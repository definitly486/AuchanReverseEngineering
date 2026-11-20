.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;
.source "SnapToLineEdge.java"


# instance fields
.field protected center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field protected lineSamples:I

.field protected localScale:D

.field private final polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

.field protected radialSamples:I

.field protected samplePts:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field protected weights:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;


# direct methods
.method public constructor <init>(IILjava/lang/Class;)V
    .locals 1

    .line 84
    invoke-direct {p0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;-><init>(Ljava/lang/Class;)V

    .line 66
    new-instance p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-direct {p3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;-><init>()V

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    .line 68
    new-instance p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    invoke-direct {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;-><init>()V

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->weights:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    .line 70
    new-instance p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;-><init>()V

    invoke-direct {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->samplePts:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 73
    new-instance p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {p3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    const/4 p3, 0x1

    if-lt p2, p3, :cond_0

    .line 89
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->lineSamples:I

    .line 90
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->radialSamples:I

    return-void

    .line 87
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Tangential samples must be >= 1 or else it won\'t work"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method protected computePointsAndWeights(DDDDDD)V
    .locals 27

    move-object/from16 v0, p0

    .line 144
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->samplePts:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 145
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->weights:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    .line 146
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->radialSamples:I

    mul-int/lit8 v1, v1, 0x2

    add-int/lit8 v2, v1, 0x2

    add-int/lit8 v3, v1, 0x1

    int-to-double v4, v2

    mul-double v6, v4, p9

    mul-double v4, v4, p11

    const/4 v8, 0x0

    .line 151
    :goto_0
    iget v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->lineSamples:I

    if-ge v8, v9, :cond_6

    int-to-double v10, v8

    add-int/lit8 v9, v9, -0x1

    int-to-double v12, v9

    div-double/2addr v10, v12

    mul-double v12, p1, v10

    add-double v12, p5, v12

    const-wide/high16 v14, 0x4000000000000000L    # 2.0

    div-double v16, v6, v14

    sub-double v12, v12, v16

    mul-double v10, v10, p3

    add-double v10, p7, v10

    div-double v14, v4, v14

    sub-double/2addr v10, v14

    .line 158
    iget-object v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    invoke-virtual {v9, v12, v13, v10, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->isInside(DD)Z

    move-result v9

    if-eqz v9, :cond_5

    iget-object v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    add-double v14, v12, v6

    move/from16 v16, v3

    add-double v2, v10, v4

    invoke-virtual {v9, v14, v15, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->isInside(DD)Z

    move-result v2

    if-nez v2, :cond_0

    move v15, v1

    move-wide/from16 v18, v4

    move/from16 v9, v16

    goto/16 :goto_4

    .line 161
    :cond_0
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    add-double v23, v12, p9

    add-double v25, v10, p11

    move-object/from16 v18, v2

    move-wide/from16 v21, v10

    move-wide/from16 v19, v12

    invoke-virtual/range {v18 .. v26}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->compute(DDDD)D

    move-result-wide v2

    move/from16 v9, v16

    const/4 v10, 0x0

    :goto_1
    move-wide/from16 v19, v23

    move-wide/from16 v21, v25

    if-ge v10, v9, :cond_1

    if-ne v10, v1, :cond_2

    .line 166
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    add-double v12, v19, p9

    add-double v14, v21, p11

    invoke-virtual {v11, v12, v13, v14, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->isInside(DD)Z

    move-result v11

    if-nez v11, :cond_2

    :cond_1
    move v15, v1

    :goto_2
    move-wide/from16 v18, v4

    goto :goto_4

    .line 168
    :cond_2
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    add-double v23, v19, p9

    add-double v25, v21, p11

    move-object/from16 v18, v11

    invoke-virtual/range {v18 .. v26}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->compute(DDDD)D

    move-result-wide v11

    sub-double/2addr v2, v11

    const-wide/16 v13, 0x0

    cmpg-double v15, v2, v13

    if-gez v15, :cond_3

    neg-double v2, v2

    :cond_3
    cmpl-double v13, v2, v13

    if-lez v13, :cond_4

    .line 174
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->weights:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    invoke-virtual {v13, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->add(D)V

    .line 175
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->samplePts:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v13, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double v19, v19, v13

    iget-wide v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->localScale:D

    move v15, v1

    div-double v0, v19, v13

    move-wide/from16 v18, v4

    iget-wide v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double v21, v21, v3

    div-double v3, v21, v13

    invoke-virtual {v2, v0, v1, v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    goto :goto_3

    :cond_4
    move v15, v1

    move-wide/from16 v18, v4

    :goto_3
    add-int/lit8 v10, v10, 0x1

    move-object/from16 v0, p0

    move-wide v2, v11

    move v1, v15

    move-wide/from16 v4, v18

    goto :goto_1

    :cond_5
    move v15, v1

    move v9, v3

    goto :goto_2

    :goto_4
    add-int/lit8 v8, v8, 0x1

    move-object/from16 v0, p0

    move v3, v9

    move v1, v15

    move-wide/from16 v4, v18

    goto/16 :goto_0

    :cond_6
    return-void
.end method

.method protected localToGlobal(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)V
    .locals 7

    .line 189
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->localScale:D

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    mul-double/2addr v0, v2

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    mul-double/2addr v3, v5

    sub-double/2addr v0, v3

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    mul-double/2addr v2, v4

    sub-double/2addr v0, v2

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    return-void
.end method

.method public refine(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Z
    .locals 16

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    move-object/from16 v13, p3

    .line 105
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v4, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v6, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    add-double/2addr v4, v6

    const-wide/high16 v6, 0x4000000000000000L    # 2.0

    div-double/2addr v4, v6

    iput-wide v4, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 106
    iget-wide v4, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v8, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-double/2addr v4, v8

    div-double/2addr v4, v6

    iput-wide v4, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 107
    invoke-virtual {v1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v3

    iput-wide v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->localScale:D

    .line 110
    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v5, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v3, v5

    .line 111
    iget-wide v5, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v7, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v5, v7

    mul-double v7, v3, v3

    mul-double v9, v5, v5

    add-double/2addr v7, v9

    .line 112
    invoke-static {v7, v8}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v7

    div-double v9, v5, v7

    neg-double v11, v3

    div-double/2addr v11, v7

    move-wide v7, v3

    move-wide v3, v5

    .line 121
    iget-wide v5, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    move-wide v14, v7

    move-wide v7, v1

    move-wide v1, v14

    invoke-virtual/range {v0 .. v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->computePointsAndWeights(DDDDDD)V

    .line 123
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->samplePts:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size()I

    move-result v1

    const/4 v2, 0x4

    if-lt v1, v2, :cond_1

    .line 125
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->samplePts:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v1

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->weights:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->data:[D

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/georegression/fitting/line/FitLine_F64;->polar(Ljava/util/List;[DLcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    move-result-object v1

    if-eqz v1, :cond_0

    .line 128
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-static {v1, v13}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 131
    invoke-virtual {v0, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->localToGlobal(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)V

    const/4 v1, 0x1

    return v1

    .line 126
    :cond_0
    new-instance v1, Ljava/lang/RuntimeException;

    const-string v2, "All weights were zero, bug some place"

    invoke-direct {v1, v2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v1

    :cond_1
    const/4 v1, 0x0

    return v1
.end method
