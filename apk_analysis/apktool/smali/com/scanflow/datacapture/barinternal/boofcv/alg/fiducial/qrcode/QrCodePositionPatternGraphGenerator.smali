.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;
.super Ljava/lang/Object;
.source "QrCodePositionPatternGraphGenerator.java"


# instance fields
.field protected connectLine:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

.field graph:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

.field protected intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field protected lineA:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

.field protected lineB:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

.field maxVersionQR:I

.field private final nn:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor;

.field private final search:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor$Search;

.field private final searchResults:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field protected verbose:Ljava/io/PrintStream;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 64
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/16 v0, 0x28

    .line 47
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->maxVersionQR:I

    .line 49
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->graph:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

    .line 52
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode$KdTreeSquareNode;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode$KdTreeSquareNode;-><init>()V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/FactoryNearestNeighbor;->kdtree(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->nn:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor;

    .line 53
    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor;->createSearch()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor$Search;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->search:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor$Search;

    .line 54
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->searchResults:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 57
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->lineA:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    .line 58
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->lineB:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    .line 59
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->connectLine:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    .line 60
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method


# virtual methods
.method considerConnect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)V
    .locals 20

    move-object/from16 v0, p0

    move-object/from16 v2, p1

    move-object/from16 v4, p2

    .line 115
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->lineA:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iput-object v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 116
    iget-object v3, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iput-object v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 118
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->graph:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->lineB:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-virtual {v3, v2, v1, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->findSideIntersect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;)I

    move-result v3

    .line 119
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->connectLine:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v1, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 120
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->graph:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->lineA:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->lineB:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-virtual {v1, v4, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->findSideIntersect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;)I

    move-result v5

    .line 121
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->connectLine:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v1, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    if-ltz v5, :cond_5

    if-gez v3, :cond_0

    goto/16 :goto_0

    .line 127
    :cond_0
    iget-object v1, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->sideLengths:[D

    aget-wide v6, v1, v3

    .line 128
    iget-object v1, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->sideLengths:[D

    aget-wide v8, v1, v5

    .line 132
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->connectLine:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v10, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v10, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v10

    invoke-virtual {v1, v10}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v10

    div-double/2addr v10, v6

    .line 133
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->connectLine:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v12, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v12, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v12

    invoke-virtual {v1, v12}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v12

    div-double/2addr v12, v8

    const-wide/high16 v14, 0x3fe0000000000000L    # 0.5

    sub-double/2addr v10, v14

    .line 135
    invoke-static {v10, v11}, Ljava/lang/Math;->abs(D)D

    move-result-wide v16

    const-wide v18, 0x3fd6666666666666L    # 0.35

    cmpl-double v1, v16, v18

    if-gtz v1, :cond_5

    sub-double/2addr v12, v14

    invoke-static {v12, v13}, Ljava/lang/Math;->abs(D)D

    move-result-wide v14

    cmpl-double v1, v14, v18

    if-lez v1, :cond_1

    goto/16 :goto_0

    .line 139
    :cond_1
    invoke-static {v10, v11}, Ljava/lang/Math;->abs(D)D

    move-result-wide v10

    invoke-static {v12, v13}, Ljava/lang/Math;->abs(D)D

    move-result-wide v12

    add-double/2addr v10, v12

    const-wide/high16 v12, 0x4000000000000000L    # 2.0

    div-double/2addr v10, v12

    sub-double v14, v6, v8

    .line 142
    invoke-static {v14, v15}, Ljava/lang/Math;->abs(D)D

    move-result-wide v14

    invoke-static {v6, v7, v8, v9}, Ljava/lang/Math;->max(DD)D

    move-result-wide v6

    div-double/2addr v14, v6

    const-wide/high16 v6, 0x3fd0000000000000L    # 0.25

    cmpl-double v1, v14, v6

    if-lez v1, :cond_2

    goto :goto_0

    .line 149
    :cond_2
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->graph:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

    invoke-virtual {v1, v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->almostParallel(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;I)Z

    move-result v1

    if-nez v1, :cond_3

    goto :goto_0

    .line 153
    :cond_3
    iget-wide v6, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->smallestSide:D

    iget-wide v8, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->largestSide:D

    div-double/2addr v6, v8

    iget-wide v8, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->smallestSide:D

    iget-wide v14, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->largestSide:D

    div-double/2addr v8, v14

    invoke-static {v6, v7, v8, v9}, Ljava/lang/Math;->max(DD)D

    move-result-wide v6

    const-wide v8, 0x3ff4cccccccccccdL    # 1.3

    cmpl-double v1, v6, v8

    if-lez v1, :cond_4

    goto :goto_0

    .line 160
    :cond_4
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->graph:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

    invoke-virtual {v1, v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->acuteAngle(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;I)D

    move-result-wide v6

    .line 161
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->lineA:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->getLength()D

    move-result-wide v8

    const-wide/high16 v14, 0x3ff0000000000000L    # 1.0

    add-double/2addr v6, v14

    div-double/2addr v10, v12

    add-double/2addr v6, v10

    mul-double/2addr v6, v8

    .line 166
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->graph:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

    invoke-virtual/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->checkConnect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ID)Z

    move-result v1

    .line 168
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->verbose:Ljava/io/PrintStream;

    if-eqz v2, :cond_5

    .line 169
    iget-object v3, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v8, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    invoke-static {v8, v9}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v3

    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v4, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    invoke-static {v4, v5}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v4

    invoke-static {v6, v7}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v5

    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v1

    filled-new-array {v3, v4, v5, v1}, [Ljava/lang/Object;

    move-result-object v1

    const-string v3, "_ (%.1f %.1f) score=%.2f change=%s\n"

    invoke-virtual {v2, v3, v1}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    :cond_5
    :goto_0
    return-void
.end method

.method public process(Ljava/util/List;)V
    .locals 9

    .line 77
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->graph:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->reset()V

    .line 80
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->nn:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor;

    const/4 v1, 0x0

    invoke-interface {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor;->setPoints(Ljava/util/List;Z)V

    move v0, v1

    .line 82
    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v2

    if-ge v0, v2, :cond_3

    .line 83
    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    move-object v4, v2

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;

    .line 88
    iget-wide v2, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->largestSide:D

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->maxVersionQR:I

    mul-int/lit8 v5, v5, 0x4

    add-int/lit8 v5, v5, 0x11

    int-to-double v5, v5

    const-wide/high16 v7, 0x401c000000000000L    # 7.0

    sub-double/2addr v5, v7

    mul-double/2addr v2, v5

    div-double/2addr v2, v7

    const-wide v5, 0x3ff3333333333333L    # 1.2

    mul-double/2addr v2, v5

    mul-double v5, v2, v2

    .line 93
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->search:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor$Search;

    const v7, 0x7fffffff

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->searchResults:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-interface/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor$Search;->findNearest(Ljava/lang/Object;DILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    .line 95
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->verbose:Ljava/io/PrintStream;

    const/4 v3, 0x1

    if-eqz v2, :cond_0

    .line 96
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v5, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    invoke-static {v5, v6}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v5

    iget-object v6, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v6, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    invoke-static {v6, v7}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v6

    iget-wide v7, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->largestSide:D

    invoke-static {v7, v8}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v7

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->searchResults:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v8, v8, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    sub-int/2addr v8, v3

    invoke-static {v8}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v8

    filled-new-array {v5, v6, v7, v8}, [Ljava/lang/Object;

    move-result-object v5

    const-string v6, "PP: (%.1f %.1f) width=%.1f neighbors=%d\n"

    invoke-virtual {v2, v6, v5}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 98
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->searchResults:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-le v2, v3, :cond_2

    move v2, v1

    .line 99
    :goto_1
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->searchResults:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v5, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ge v2, v5, :cond_2

    .line 100
    invoke-virtual {v3, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NnData;

    .line 102
    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NnData;->point:Ljava/lang/Object;

    if-ne v3, v4, :cond_1

    goto :goto_2

    .line 104
    :cond_1
    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    invoke-virtual {p0, v4, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->considerConnect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)V

    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_2
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public setMaxVersionQR(I)V
    .locals 0

    .line 47
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->maxVersionQR:I

    return-void
.end method
