.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;
.super Ljava/lang/Object;
.source "AdjustPolygonForThresholdBias.java"


# instance fields
.field private final ga:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

.field private final gb:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

.field private final intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field private final segments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 39
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->segments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 40
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->ga:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 41
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->gb:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 42
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method


# virtual methods
.method public process(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Z)V
    .locals 19

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    .line 52
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v2

    .line 53
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->segments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v3, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    add-int/lit8 v3, v2, -0x1

    move v6, v3

    const/4 v5, 0x0

    :goto_0
    if-ge v5, v2, :cond_4

    if-eqz p2, :cond_0

    move v7, v5

    goto :goto_1

    :cond_0
    move v7, v6

    move v6, v5

    .line 67
    :goto_1
    invoke-virtual {v1, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v8

    invoke-virtual {v1, v7}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v7

    .line 69
    iget-wide v9, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v11, v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v9, v11

    .line 70
    iget-wide v11, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v13, v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v11, v13

    mul-double v13, v9, v9

    mul-double v15, v11, v11

    add-double/2addr v13, v15

    .line 71
    invoke-static {v13, v14}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v13

    const-wide/16 v15, 0x0

    cmpl-double v17, v13, v15

    if-eqz v17, :cond_3

    cmpg-double v17, v9, v15

    if-gez v17, :cond_1

    move-wide v9, v15

    :cond_1
    cmpl-double v17, v11, v15

    if-lez v17, :cond_2

    move-wide v11, v15

    .line 82
    :cond_2
    iget-object v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->segments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v15, v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    .line 83
    iget-object v15, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move/from16 v17, v5

    iget-wide v4, v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    div-double/2addr v11, v13

    sub-double/2addr v4, v11

    iput-wide v4, v15, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 84
    iget-wide v4, v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    div-double/2addr v9, v13

    add-double/2addr v4, v9

    iput-wide v4, v15, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 85
    iget-object v4, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v5, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v5, v11

    iput-wide v5, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 86
    iget-wide v5, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-double/2addr v5, v9

    iput-wide v5, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-int/lit8 v5, v17, 0x1

    move/from16 v6, v17

    goto :goto_0

    .line 73
    :cond_3
    new-instance v1, Ljava/lang/RuntimeException;

    const-string v2, "Two identical corners!"

    invoke-direct {v1, v2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v1

    :cond_4
    move v4, v3

    const/4 v3, 0x0

    :goto_2
    if-ge v3, v2, :cond_7

    if-eqz p2, :cond_5

    move v5, v3

    goto :goto_3

    :cond_5
    move v5, v4

    move v4, v3

    .line 100
    :goto_3
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->segments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v6, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->ga:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-static {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 101
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->segments:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->gb:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-static {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 103
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->ga:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->gb:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v4, v6, v7}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v4

    if-eqz v4, :cond_6

    .line 105
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v1, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v6

    invoke-virtual {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance2(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v6

    const-wide/high16 v8, 0x4034000000000000L    # 20.0

    cmpg-double v4, v6, v8

    if-gez v4, :cond_6

    .line 106
    invoke-virtual {v1, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v4

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    :cond_6
    add-int/lit8 v4, v3, 0x1

    move/from16 v18, v4

    move v4, v3

    move/from16 v3, v18

    goto :goto_2

    :cond_7
    const-wide v2, 0x3e45798ee2308c3aL    # 1.0E-8

    .line 114
    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPolygons2D_F64;->removeAdjacentDuplicates(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;D)V

    return-void
.end method
